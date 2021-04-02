using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerManagerLibrary;
using System.Runtime.InteropServices;
using INFITF;
using ProductStructureTypeLib;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace VerManagerLibrary
{
    public static class VMLCoordinator
    {
        public static  Dictionary<string, DocumentClass> InSessionDocumentDictionary { get; } = CollectDocuments(CatiaLauncher());
        public static Dictionary<string, List<string>> ParentsDictionary { get; } = CreateParentDictionary(InSessionDocumentDictionary);
        public static Dictionary<string, DocumentClass> LibraryDocumentDictionary { get; } = CollectLibraryDocuments(ParentsDictionary);

        #region CollectCatiaDocuments region

        private static INFITF.Application CatiaLauncher()
        {
            INFITF.Application CATIA;
            //Ovaj dio veze program na prvu aktivnu CATIA-u
            //Ako u procesima ne postoji instanca CATIA-e, onda program otvara novu instancu
            try
            {
                CATIA = Marshal.GetActiveObject("CATIA.Application") as INFITF.Application;
            }
            catch (Exception)
            {
                Type typeApp = Type.GetTypeFromProgID("CATIA.Application");
                CATIA = System.Activator.CreateInstance(typeApp) as INFITF.Application;
            }
            CATIA.Visible = true;
            return CATIA;
        }

        //Za svaki dokument u radnoj memoriji CATIA-e program kreira costum made "ClassDocument" objekt sa odgovarajućim atributima

        private static Dictionary<string, DocumentClass> CollectDocuments(INFITF.Application App)
            {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            Dictionary<string, DocumentClass> CatiaDocuments = new Dictionary<string, DocumentClass>();
            foreach (Document doc in App.Documents)
            {
                DocumentClass clsDoc;
                if (!CatiaDocuments.ContainsKey(doc.FullName))
                {
                    clsDoc = new DocumentClass(doc.FullName);
                    CatiaDocuments.Add(doc.FullName, clsDoc);
                }
                else
                {
                    clsDoc = CatiaDocuments[doc.FullName];
                }

                if (doc.FullName.IndexOf(".CATProduct") != -1)
                {
                    ProductDocument oProdDoc = (ProductDocument)doc;
                    Product oProd = oProdDoc.Product;
                    if (oProd.Products.Count != 0)
                    {
                        CollectChildren(oProd, clsDoc, CatiaDocuments);
                    }
                }
             }
            //Za odgovarajuće komponente unutar Producta, program kreira "classDocument objekt" te ga stavlja u dictionary od roditeljskog objekta u funkciju "Child"
            void CollectChildren(Product oProd, DocumentClass clsDoc, Dictionary<string,DocumentClass> DocumentDictionary)
            {
                DocumentClass subclsDoc;

                Document mainDoc = (Document)oProd.ReferenceProduct.Parent;
                foreach (Product subProd in oProd.Products)
                {
                    Document subDoc = (Document)subProd.ReferenceProduct.Parent;
                    if (subDoc.FullName != mainDoc.FullName)
                    {
                        if (DocumentDictionary.ContainsKey(subDoc.FullName))
                        {
                            subclsDoc = DocumentDictionary[subDoc.FullName];
                        }
                        else
                        {
                            subclsDoc = new DocumentClass(subDoc.FullName);
                            DocumentDictionary.Add(subDoc.FullName, subclsDoc);
                        }

                        clsDoc.AdChild(subclsDoc);
                        subclsDoc.AdParent(clsDoc);
                    }
                    else
                    {
                        CollectChildren(subProd, clsDoc, DocumentDictionary);
                    }
                }
            }
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            return CatiaDocuments;
        }

        #endregion

        #region ReadDocumentLibraryDictionary
        
        private static Dictionary<string, DocumentClass> CollectLibraryDocuments(Dictionary<string, List<string>> parentsDictionary)
        {
            Dictionary<string, DocumentClass> libraryDocuments = new Dictionary<string, DocumentClass>();
                string libraryPath = @"D:\DATABASE\Library.JSON";
                string jsonString = System.IO.File.ReadAllText(libraryPath);
                //libraryDocuments = costumeConverter.DeserializeData(jsonString);
                libraryDocuments = JsonSerializer.Deserialize<Dictionary<string, DocumentClass>>(jsonString);
                foreach (KeyValuePair<string,List<string>> keyValuePair in parentsDictionary)
                {
                if (libraryDocuments.Keys.Contains(keyValuePair.Key))
                    {
                        foreach (string key in keyValuePair.Value)
                        {
                            libraryDocuments[keyValuePair.Key].AdChild(libraryDocuments[key]);
                            libraryDocuments[key].AdParent(libraryDocuments[keyValuePair.Key]);
                        }
                    }
                }

            return libraryDocuments;
        }

        #endregion

        private static Dictionary<string, List<string>> CreateParentDictionary(Dictionary<string,DocumentClass> oDict)
        {
            Dictionary<string, List<string>> parentDictionary = new Dictionary<string, List<string>>();
                string libraryPath = @"D:\DATABASE\Parents.JSON";
                string jsonString = System.IO.File.ReadAllText(libraryPath);
                parentDictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonString) ?? new Dictionary<string, List<string>>();
                int removedItems = 0;
            foreach (KeyValuePair<string, List<string>> keyValue in parentDictionary)
            {
                if (!System.IO.File.Exists(keyValue.Key))
                    {
                    parentDictionary.Remove(keyValue.Key);
                    removedItems += 1;
                }
            }
            Console.WriteLine("Removed items: " + removedItems);

            foreach (KeyValuePair<string,DocumentClass> keyValue in oDict)
            {
                if (keyValue.Value.HasChindren)
                {
                    List<string> childrenList = keyValue.Value.ChildrenDict.Keys.ToList();
                    if (parentDictionary.ContainsKey(keyValue.Key))
                        {
                        parentDictionary[keyValue.Key] = childrenList;
                    }
                    else
                    {
                        parentDictionary.Add(keyValue.Key, childrenList);
                    }
                }
            }
            jsonString = JsonSerializer.Serialize(parentDictionary);
            System.IO.File.WriteAllText(libraryPath, jsonString);
            return parentDictionary;
        }
    }
}
