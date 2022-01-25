using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using INFITF;
using ProductStructureTypeLib;
using System.Text.Json;
using System.IO;
using MECMOD;
using CATSmarTeamInteg;

namespace VerManagerLibrary_ClassLib
{
    public static class VMLCoordinator
    {
        private static readonly string confAddress = @"D:\vb_projects\TestnoPodrucje_CSharp\LearningSolution\VMLConf.txt";
        private static readonly string[] confData = System.IO.File.ReadAllLines(confAddress);
        public static string localCore = GetConfigurationLine("localCore");
        public static string serverCore = GetConfigurationLine("serverCore");
        public static string attachmentsFolder = GetConfigurationLine("attachmentsFolder");
        private static string doc_JSON = GetConfigurationLine("doc_JSON");
        private static string rev_JSON = GetConfigurationLine("rev_JSON");
        //public static Dictionary<string, RevisionClass> RevisionDictionary { get; set; } = new Dictionary<string, RevisionClass>();
        public static Dictionary<string, RevisionClass> RevisionDictionary { get; set; } = CollectRevisionDocuments();
        public static Dictionary<string, DocumentClass> DocumentDictionary { get; set; } = new Dictionary<string, DocumentClass>();
        private static HashSet<string> CollectAttachments() {
            HashSet<string> attachments = new HashSet<string>();
            try
            {
                string[] files = Directory.GetFiles(attachmentsFolder, "*.jpg").Concat(Directory.GetFiles(attachmentsFolder, "*.txt")).ToArray();
                foreach (string path in files)
                {
                    if (!attachments.Contains(path))
                        attachments.Add(path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return attachments;
        }
        public static List<string> newFileKeys;

        public static string GetConfigurationLine(string itemToSearch) {
            foreach (string line in confData) 
            {
                string sep = "\t";
                string[] splitContent = line.Split(sep.ToCharArray());
                if (splitContent[0] == itemToSearch)
                {
                    return splitContent[1];
                }
            }
            return "";
        }

        #region CollectCatiaDocuments region
        public static INFITF.Application CATIA = CatiaLauncher();
        private static INFITF.Application CatiaLauncher()
        {
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

        #region AsyncMemoryRead
        public static async Task<Dictionary<string, DocumentClass>> CollectInSessionDocuments()
        {
            Console.WriteLine("CollectDocuments  ->  Start");
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            INFITF.Application App = CatiaLauncher();
            List<Product> products = new List<Product>();
            Regex reSearchPattern = new Regex(@"CATPart|CATProduct", RegexOptions.IgnoreCase);
            //Regex reSearchPatternDir = new Regex(@"D:\\CATIA\\local\\V2 RAZVOJ\\Knjiznica AD\\|D:\\CATIA\\local\\V2 RAZVOJ\\Knjiznica MD\\|D:\\CATIA\\local\\V2 RAZVOJ\\Osnovni Model V2\\", RegexOptions.IgnoreCase);
            Regex reSearchPatternDir = new Regex(localCore.Replace(@"\", @"\\"), RegexOptions.IgnoreCase);

            await Task.Run(() =>
            {
                HashSet<Document> productsToCheck = new HashSet<Document>();
                foreach (Document doc in App.Documents)
                {
                    Match match = reSearchPattern.Match(doc.FullName.Split('.').Last());
                    if (match.Success)
                    {
                        Match matchDir = reSearchPatternDir.Match(doc.Path + @"\\");
                        if (matchDir.Success)
                        {
                            if (doc.FullName.ToUpper().Contains("CATPRODUCT")) productsToCheck.Add(doc);
                            DocumentClass clsDoc;
                            if (!DocumentDictionary.ContainsKey(doc.FullName.Remove(0, localCore.Length)))
                            {
                                if (!DocumentDictionary.ContainsKey(doc.FullName.Remove(0, localCore.Length)))
                                {
                                    clsDoc = new DocumentClass
                                    {
                                        CatiaDoc = doc,
                                        Location = doc.Path.Remove(0, localCore.Length) + @"\",
                                        Name = doc.get_Name(),
                                        LocalNomenclature = GetFileNomenclature(doc),
                                    };
                                }
                                else
                                {
                                    clsDoc = DocumentDictionary[doc.FullName.Remove(0, localCore.Length)];
                                }
                                DocumentDictionary.Add(clsDoc.Key, clsDoc);
                            }
                            else
                            {
                                clsDoc = DocumentDictionary[doc.FullName.Remove(0, localCore.Length)];
                            }
                            clsDoc.InSession = true;
                        }
                    }
                }
                //Zoran 
                Dictionary<string, List<string>> CompareAtributes = new Dictionary<string, List<string>>(); //List - podaci o documentclass iz baze
                foreach (DocumentClass clsDoc in DocumentDictionary.Values) 
                {
                    if (CompareAtributes.ContainsKey(clsDoc.Key))
                    {
                        clsDoc.SqlVersion = CompareAtributes[clsDoc.Key][0];
                        clsDoc.LocalVersion = GetLocalVersion(clsDoc.CatiaDoc);
                        clsDoc.SqlNomenclature = CompareAtributes[clsDoc.Key][1];
                        if (clsDoc.SqlNomenclature != clsDoc.LocalNomenclature || clsDoc.SqlVersion != clsDoc.LocalVersion) clsDoc.Modified = true;
                    }
                    else
                    {
                        clsDoc.LocalVersion = Environment.UserName + "_V_1";
                        if (GetLocalVersion(clsDoc.CatiaDoc) != clsDoc.LocalVersion) SetLocalVersion(clsDoc.CatiaDoc, clsDoc.LocalVersion);
                    }
                }
                foreach (Document doc in productsToCheck) {
                    StiEngine stiEngine = (StiEngine)CATIA.GetItem("CAIEngine");
                    StiDBItem DBItem = (StiDBItem)stiEngine.GetStiDBItemFromAnyObject(doc);
                    StiDBChildren stiChildren = (StiDBChildren)DBItem.GetChildren();
                    HashSet<string> activeChildren = new HashSet<string>();
                    DocumentClass clsDoc = DocumentDictionary[doc.FullName.Remove(0, localCore.Length)];
                    for (int x = 1; x <= stiChildren.Count; x++)
                    {
                        StiDBItem theChild = stiChildren.Item(x);
                        if (theChild.GetDocumentFullPath() == DBItem.GetDocumentFullPath())
                        {
                            CollectChildren(theChild, activeChildren);
                        }
                        else
                        {
                            if (!activeChildren.Contains(theChild.GetDocumentFullPath()) && theChild.GetDocumentFullPath().Contains(".CATP"))
                            {
                                DocumentClass subclsDoc;
                                string childKey = theChild.GetDocumentFullPath().Remove(0, localCore.Length).Replace(@"\\", @"\");
                                if (DocumentDictionary.ContainsKey(childKey))
                                {
                                    subclsDoc = DocumentDictionary[childKey];
                                    if (!clsDoc.ChildrenDict.ContainsKey(subclsDoc.Key))
                                    {
                                        clsDoc.AddChild(subclsDoc);
                                        subclsDoc.AddParent(clsDoc);
                                    }
                                    activeChildren.Add(childKey);
                                 }
                            }
                        }
                    }
                    List<string> toRemove = new List<string>();
                    if (activeChildren.Count != clsDoc.ChildrenDict.Count)
                    {
                        toRemove = clsDoc.ChildrenDict.Keys.ToList().Except(activeChildren).ToList();
                    }
                    foreach (string key in toRemove)
                    {
                        DocumentDictionary[key].RemoveParent(clsDoc.Key);
                        clsDoc.RemoveChild(key);
                    }
                }
                FillRevisionInfoInDocuments();
            });
            watch.Stop();
            Console.WriteLine($"CollectDocuments  ->  Execution Time: {watch.ElapsedMilliseconds} ms");
            return DocumentDictionary;
        }
        private static void CollectChildren(StiDBItem parent, HashSet<string> childernHashSet)
        {
            StiDBChildren stiChildren = (StiDBChildren)parent.GetChildren();
            for (int x = 1; x <= stiChildren.Count; x++)
            {
                StiDBItem theChild = stiChildren.Item(x);
                if (theChild.GetDocumentFullPath() == parent.GetDocumentFullPath())
                {
                    CollectChildren(theChild, childernHashSet);
                }
                else
                {
                    string childKey = theChild.GetDocumentFullPath().Remove(0, localCore.Length).Replace(@"\\", @"\");
                    childernHashSet.Add(childKey);
                    Console.WriteLine(childKey);
                }
            }
        }
        private static void FillRevisionInfoInDocuments()
        {
            foreach (RevisionClass rev in RevisionDictionary.Values)
            {
                foreach (string docKey in rev.RevisionDocuments.Keys)
                {
                    if (DocumentDictionary.ContainsKey(docKey))
                    {
                        DocumentClass doc = DocumentDictionary[docKey];
                        long solvedStatus = rev.RevisionDocuments[doc.Key].RD_Value;
                        bool solved = solvedStatus > 2;
                        Stack<DocumentClass> DocStack = new Stack<DocumentClass>();
                        DocStack.Push(doc);
                        while (DocStack.Count > 0)
                        {
                            DocumentClass currentDocument = DocStack.Pop();
                            currentDocument.ParentsDict.Values.ToList().ForEach(
                            x => DocStack.Push(x));
                            if (doc == currentDocument)
                            {
                                currentDocument.AddRevision(rev.RevisionID, solvedStatus);
                            }
                            else
                            {
                                if (!solved & (!currentDocument.RevisionDict.ContainsKey(rev.RevisionID) || currentDocument.RevisionDict[rev.RevisionID] > 2))
                                {
                                        currentDocument.AddRevision(rev.RevisionID, 2);
                                }
                            }
                        }
                    }
                
                }

            }
        }
        #endregion

        public static string GetFileNomenclature(INFITF.Document oDoc)
        {
            Product oProduct;
            if (Path.GetExtension(oDoc.FullName).ToUpper() == ".CATPRODUCT")
            {
                ProductDocument oProdDoc = (ProductDocument)oDoc;
                oProduct = oProdDoc.Product.ReferenceProduct;
            }
            else
            {
                PartDocument oPartDoc = (PartDocument)oDoc;
                oProduct = oPartDoc.Product.ReferenceProduct;
            }
            if(oProduct.get_Nomenclature() == "") return null;
            else return oProduct.get_Nomenclature();
        }
        public static string GetLocalVersion(INFITF.Document oDoc)
        {
            Product oProduct;
            if (Path.GetExtension(oDoc.FullName).ToUpper() == ".CATPRODUCT")
            {
                ProductDocument oProdDoc = (ProductDocument)oDoc;
                oProduct = oProdDoc.Product.ReferenceProduct;
            }
            else
            {
                PartDocument oPartDoc = (PartDocument)oDoc;
                oProduct = oPartDoc.Product.ReferenceProduct;
            }
            if (oProduct.get_Revision() == "") return Environment.UserName + "_V_1";
            else return oProduct.get_Revision();
        }
        public static void SetLocalVersion(INFITF.Document oDoc, string sVersion)
        {
            Product oProduct;
            if (Path.GetExtension(oDoc.FullName).ToUpper() == ".CATPRODUCT")
            {
                ProductDocument oProdDoc = (ProductDocument)oDoc;
                oProduct = oProdDoc.Product.ReferenceProduct;
            }
            else
            {
                PartDocument oPartDoc = (PartDocument)oDoc;
                oProduct = oPartDoc.Product.ReferenceProduct;
            }
            oProduct.set_Revision(sVersion);
            oDoc.Save();
        }
        #endregion

        #region DocumentLibrary_Setup_And_Edit
        public static Dictionary<string, DocumentClass> AddDocumentsFromLibrary(HashSet<string> addList, Dictionary<string, DocumentClass> DocumentDictionary)
        {
            Dictionary<string, DocumentClass> newDictionary = DocumentDictionary;
            //Metoda koja doda u "DocumentDictionary" objekte DokumenatClass prema popisu iz "addList" 
            return newDictionary;
        }
        #endregion

        public static void StoreDocumentClassesDict(Dictionary<string, DocumentClass> DictionaryToStore)
        {
            var watchStore = new System.Diagnostics.Stopwatch();
            watchStore.Start();
            
            Console.WriteLine($"watchStore  ->  Execution Time: {watchStore.ElapsedMilliseconds} ms");
        }
        private static Dictionary<string, RevisionClass> CollectRevisionDocuments()
        {
            Dictionary<string, RevisionClass> oDict = new Dictionary<string, RevisionClass>();
            string libraryPath = rev_JSON;
            string jsonString = System.IO.File.ReadAllText(libraryPath);
            Dictionary<string, RevisionClassRAW> dictRAW = JsonSerializer.Deserialize<Dictionary<string, RevisionClassRAW>>(jsonString);
            HashSet<string> attachmentDocs = CollectAttachments();
            foreach (KeyValuePair<string, RevisionClassRAW> keyValue in dictRAW)
            {
                RevisionClass revisionClass = new RevisionClass();
                revisionClass.BuildRevisionClass(keyValue.Value);
                revisionClass.Attachments = attachmentDocs.Where(path => path.Contains("_" + revisionClass.RevisionID + "_")).ToHashSet();
                oDict.Add(keyValue.Key, revisionClass);
            }
            return oDict;
        }
        public static void StoreRevisionDict()
        {
            var watchStore = new System.Diagnostics.Stopwatch();
            watchStore.Start();
            Dictionary<string, RevisionClassRAW> dictRAW = new Dictionary<string, RevisionClassRAW>();
            foreach (KeyValuePair<string,RevisionClass> keyValuePair in RevisionDictionary) {
                RevisionClassRAW revisionRAW = new RevisionClassRAW();
                revisionRAW.FillRCL(keyValuePair.Value);
                dictRAW.Add(keyValuePair.Key,revisionRAW);
            }
            String jsonString = JsonSerializer.Serialize(dictRAW);
            System.IO.File.WriteAllText(rev_JSON, jsonString);
            watchStore.Stop();
            Console.WriteLine($"watchStore  ->  Execution Time: {watchStore.ElapsedMilliseconds} ms");
        }
    }
}
