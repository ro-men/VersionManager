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
        //public static Dictionary<string, DocumentClass> DocumentDictionary { get; set; } = CollectLibraryDocuments();
        public static Dictionary<string, DocumentClass> DocumentDictionary { get; set; } = new Dictionary<string, DocumentClass>();
        private static HashSet<string> CollectPictures() {
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
        private static Dictionary<string, DocumentClassRAW> DisassembledDocumentClasses { get; set; }
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

        public static bool CheckInSession(string key)
        {
            Document testDocument;
            try 
	        {
                testDocument = CATIA.Documents.Item(Path.GetFileName(key));
                if (testDocument.FullName == localCore + key) return true;
                return false;
            }
	        catch 
	        {
                return false;
            }
        }

        /// <summary>
        /// Ucitava u radnu memoriju Catia-e sve dokumente iz liste.
        /// </summary>
        /// <param name="listToRead"></param>
        public static async void ReadList(List<DocumentClass> listToRead) 
        {
            INFITF.Application App = CatiaLauncher();
            foreach (DocumentClass documentClass in listToRead) 
            {
                if (!documentClass.InSession)
                {
                    Document oDoc = App.Documents.Read(localCore + documentClass.Key);
                    Product oProduct;
                    if (documentClass.NewNomenclature == null || documentClass.NewNomenclature == "")
                    {
                        try
                        {
                            PartDocument oPartDoc = (PartDocument)oDoc;
                            oProduct = oPartDoc.Product.ReferenceProduct;
                        }
                        catch (Exception)
                        {
                            ProductDocument oProductDoc = (ProductDocument)oDoc;
                            oProduct = oProductDoc.Product.ReferenceProduct;
                        }
                        documentClass.NewNomenclature = oProduct.get_Nomenclature();
                    }                    
                }
            }
            DocumentDictionary = await VMLCoordinator.CollectInSessionDocuments();
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
                                        Key = doc.FullName.Remove(0, localCore.Length),
                                    };
                                    clsDoc.SetInitaialNomenclature(GetNomenclature(doc));
                                    clsDoc.IncreaseVersion();
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
                            collectChildren(theChild, activeChildren);
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
            });
            watch.Stop();
            Console.WriteLine($"CollectDocuments  ->  Execution Time: {watch.ElapsedMilliseconds} ms");
            return DocumentDictionary;
        }
        private static void collectChildren(StiDBItem parent, HashSet<string> childernHashSet)
        {
            StiDBChildren stiChildren = (StiDBChildren)parent.GetChildren();
            for (int x = 1; x <= stiChildren.Count; x++)
            {
                StiDBItem theChild = stiChildren.Item(x);
                if (theChild.GetDocumentFullPath() == parent.GetDocumentFullPath())
                {
                    collectChildren(theChild, childernHashSet);
                }
                else
                {
                    string childKey = theChild.GetDocumentFullPath().Remove(0, localCore.Length).Replace(@"\\", @"\");
                    childernHashSet.Add(childKey);
                    Console.WriteLine(childKey);
                }
            }
        }
        #endregion

        private static string GetNomenclature(INFITF.Document oDoc)
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
        #endregion

        #region DocumentLibrary_Setup_And_Edit
        /// <summary>
        /// Učitava sve dokumente iz baze podataka te im pridodaje potrebne atribute.
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, DocumentClass> CollectLibraryDocuments()
        {
            Dictionary<string, DocumentClass> libraryDocuments = new Dictionary<string, DocumentClass>();
            string jsonString = System.IO.File.ReadAllText(doc_JSON);
            DisassembledDocumentClasses = JsonSerializer.Deserialize<Dictionary<string, DocumentClassRAW>>(jsonString);
            foreach (DocumentClassRAW RawClass in DisassembledDocumentClasses.Values) {
                DocumentClass documentClass = new DocumentClass();
                documentClass.BuildDocumentClass(RawClass, RevisionDictionary);
                libraryDocuments.Add(RawClass.Key, documentClass);
            }
            foreach (DocumentClassRAW RawClass in DisassembledDocumentClasses.Values)
            {
                DocumentClass documentClass = libraryDocuments[RawClass.Key];
                documentClass.FillSiblings(RawClass, libraryDocuments);
            }
            RevisionDictionary.Where(kvp => !kvp.Value.SolvedStatus).ToList().ForEach(
                kvp => kvp.Value.RevisionDocuments.Where(x => Int32.Parse(x.Value[0]) < 2).ToList().ForEach(
                    item => {
                        Stack<DocumentClass> documentClasses = new Stack<DocumentClass>();
                        documentClasses.Push(libraryDocuments[item.Key]);
                        while (documentClasses.Count > 0)
                        {
                            DocumentClass currentDocumentClass = documentClasses.Pop();
                            currentDocumentClass.ParentsDict.Values.ToList().ForEach(x => documentClasses.Push(x));
                            currentDocumentClass.AddRevision(kvp.Key, 2);
                        }
                    }));
            return libraryDocuments;
        }
        #endregion

        public static void StoreDocumentClassesDict()
        {
            var watchStore = new System.Diagnostics.Stopwatch();
            watchStore.Start();
            //disassembledDocumentClasses.Clear();
            foreach (KeyValuePair<string, DocumentClass> keyValuePair in DocumentDictionary.Where(kvp => kvp.Value.Modified))
            {
                keyValuePair.Value.DataBaseFileDate = keyValuePair.Value.LocalFileDate;
                //keyValuePair.Value.ClearRevisions();
                DocumentClassRAW documentClassRAW = new DocumentClassRAW();
                documentClassRAW.FillDCR(keyValuePair.Value);
                try
                {
                    DisassembledDocumentClasses.Add(keyValuePair.Key, documentClassRAW);
                }
                catch (Exception)
                {
                    DisassembledDocumentClasses[keyValuePair.Key] = documentClassRAW;
                }
            }
            DisassembledDocumentClasses.Keys.Where(key => !DocumentDictionary.ContainsKey(key)).ToList().ForEach(key => DisassembledDocumentClasses.Remove(key));
            String jsonString = JsonSerializer.Serialize(DisassembledDocumentClasses);
            System.IO.File.WriteAllText(doc_JSON, jsonString);
            watchStore.Stop();
            Console.WriteLine($"watchStore  ->  Execution Time: {watchStore.ElapsedMilliseconds} ms");
        }
        private static Dictionary<string, RevisionClass> CollectRevisionDocuments()
        {
            Dictionary<string, RevisionClass> oDict = new Dictionary<string, RevisionClass>();
            string libraryPath = rev_JSON;
            string jsonString = System.IO.File.ReadAllText(libraryPath);
            Dictionary<string, RevisionClassRAW> dictRAW = JsonSerializer.Deserialize<Dictionary<string, RevisionClassRAW>>(jsonString);
            HashSet<string> attachmentDocs = CollectPictures();
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
