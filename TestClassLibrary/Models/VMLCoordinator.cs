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
using System.Text.Json.Serialization;
using System.IO;
using MECMOD;

namespace VerManagerLibrary_ClassLib
{
    public static class VMLCoordinator
    {
        public static string localCore = @"C:\Users\jagarinecr\Desktop\VML_Test\Local";
        public static string serverCore = @"C:\Users\jagarinecr\Desktop\VML_Test\Server";
        private static string pictureFolder = @"D:\vb_projects\TestnoPodrucje_CSharp\LearningSolution\pictures";
        public static Dictionary<string, RevisionClass> RevisionDictionary { get; set; } = CollectRevisionDocuments();
        //public static Dictionary<string, RevisionClass> RevisionDictionary { get; set; } = new Dictionary<string, RevisionClass>();
        public static Dictionary<string, DocumentClass> LibraryDocumentDictionary { get; set; } = CollectLibraryDocuments();
        public static Dictionary<string, DocumentClass> InSessionDocumentDictionary = new Dictionary<string, DocumentClass>();

        private static HashSet<string> CollectPictures() {
            HashSet<string> pictures = new HashSet<string>();
            string[] files = Directory.GetFiles(pictureFolder, "*.jpg");
            foreach (string path in files) {
                if (!pictures.Contains(path))
                    pictures.Add(path);
            }
            return pictures;
        }
        private static Dictionary<string, DocumentClassRAW> DisassembledDocumentClasses { get; set; }
        public static List<string> newFileKeys;

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
            InSessionDocumentDictionary = await VMLCoordinator.CollectInSessionDocuments();
        }

        public static async Task<Dictionary<string, DocumentClass>> CollectInSessionDocuments()
        {
            Console.WriteLine("CollectDocuments  ->  Start");
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            INFITF.Application App = CatiaLauncher();
            List<Product> products = new List<Product>();
            Regex reSearchPattern = new Regex(@"CATPart|CATProduct", RegexOptions.IgnoreCase);
            //Regex reSearchPatternDir = new Regex(@"D:\\CATIA\\local\\V2 RAZVOJ\\Knjiznica AD\\|D:\\CATIA\\local\\V2 RAZVOJ\\Knjiznica MD\\|D:\\CATIA\\local\\V2 RAZVOJ\\Osnovni Model V2\\", RegexOptions.IgnoreCase);
            Regex reSearchPatternDir = new Regex(@"C:\\Users\\jagarinecr\\Desktop\\VML_Test\\Local\\", RegexOptions.IgnoreCase);

            await Task.Run(() =>
            {
                foreach (Document doc in App.Documents)
                {
                    Match match = reSearchPattern.Match(doc.FullName.Split('.').Last());
                    if (match.Success)
                    {
                        Match matchDir = reSearchPatternDir.Match(doc.Path + @"\\");
                        if (matchDir.Success)
                        {
                            DocumentClass clsDoc;
                            if (!InSessionDocumentDictionary.ContainsKey(doc.FullName.Remove(0, localCore.Length)))
                            {
                                if (!LibraryDocumentDictionary.ContainsKey(doc.FullName.Remove(0, localCore.Length)))
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
                                    clsDoc = LibraryDocumentDictionary[doc.FullName.Remove(0, localCore.Length)];
                                }
                                InSessionDocumentDictionary.Add(clsDoc.Key, clsDoc);
                            }
                            else
                            {
                                clsDoc = InSessionDocumentDictionary[doc.FullName.Remove(0, localCore.Length)];
                            }
                            if (Path.GetExtension(doc.FullName).ToUpper() == ".CATPRODUCT")
                            {
                                //clsDoc.ChildrenDict.Keys.ToList().ForEach(key => {
                                //    LibraryDocumentDictionary[key].RemoveParent(clsDoc.Key);
                                //});
                                //clsDoc.ClearChildren();
                                ProductDocument oProdDoc = (ProductDocument)doc;
                                Product oProd = oProdDoc.Product;
                                products.Add(oProd);
                            }
                        }
                    }
                }
                foreach (Product product in products)
                {
                    UpdateChildren(product);
                };
                void UpdateChildren(Product oProd)
                {
                    Document doc = (Document)oProd.ReferenceProduct.Parent;
                    DocumentClass clsDoc = InSessionDocumentDictionary[doc.FullName.Remove(0, localCore.Length)];
                    if (oProd.Products.Count != 0)
                    {
                        List<string> activeChildren = new List<string>();
                        foreach (Product subProd in oProd.Products)
                        {
                            Document subDoc = (Document)subProd.ReferenceProduct.Parent;
                            if (subDoc.FullName != doc.FullName)
                            {
                                DocumentClass subclsDoc;
                                subclsDoc = InSessionDocumentDictionary[subDoc.FullName.Remove(0, localCore.Length)];
                                if (!clsDoc.ChildrenDict.ContainsKey(subclsDoc.Key))
                                {
                                    clsDoc.AddChild(subclsDoc);
                                    subclsDoc.AddParent(clsDoc);
                                }
                                activeChildren.Add(subclsDoc.Key);
                            }
                            else
                            {
                                UpdateChildren(subProd);
                            }
                        }
                        List<string> toRemove = new List<string>();
                        if (activeChildren.Count != clsDoc.ChildrenDict.Count) 
                        {
                            toRemove = clsDoc.ChildrenDict.Keys.ToList().Except(activeChildren).ToList();
                        }
                        foreach (string key in toRemove) 
                        {
                            InSessionDocumentDictionary[key].RemoveParent(clsDoc.Key);
                            clsDoc.RemoveChild(key);
                        }
                    }
                    else 
                    {
                        if (clsDoc.ChildrenDict.Count !=0)
                        {
                            clsDoc.ChildrenDict.Keys.ToList().ForEach(key =>
                            {
                                InSessionDocumentDictionary[key].RemoveParent(clsDoc.Key);
                            });
                            clsDoc.ClearChildren();
                        }
                    }
                }
            });
            watch.Stop();
            Console.WriteLine($"CollectDocuments  ->  Execution Time: {watch.ElapsedMilliseconds} ms");
            return InSessionDocumentDictionary;
        }

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

        #region ReadDocumentLibraryDictionary

        private static Dictionary<string, DocumentClass> CollectLibraryDocuments()
        {
            Dictionary<string, DocumentClass> libraryDocuments = new Dictionary<string, DocumentClass>();
            string libraryPath = @"D:\DATABASE\TestDict.JSON";
            string jsonString = System.IO.File.ReadAllText(libraryPath);
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
                kvp => kvp.Value.RevisionDocuments.Where(x => x.Value < 2).ToList().ForEach(
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

        public static void RemoveSelectionFromLibrary(List<DocumentClass> selectedDocuments)
        {
            foreach(DocumentClass documentClass in selectedDocuments)
            {
                documentClass.ChildrenDict.Keys.ToList().Where(x => LibraryDocumentDictionary.ContainsKey(x)).ToList().ForEach(key =>
                {
                    LibraryDocumentDictionary[key].RemoveParent(documentClass.Key);
                });
                documentClass.ParentsDict.Keys.ToList().Where(x => LibraryDocumentDictionary.ContainsKey(x)).ToList().ForEach(key =>
                {
                    LibraryDocumentDictionary[key].RemoveChild(documentClass.Key);
                });
                documentClass.RevisionDict.Keys.ToList().ForEach(key => RevisionDictionary[key].RemoveRevisionDocument(documentClass.Key));
                LibraryDocumentDictionary.Remove(documentClass.Key);
            };
        }

        public static async Task<Dictionary<string, DocumentClass>> InitialDictionaryUpdate()
        {
            var watchFindNonExistend = new System.Diagnostics.Stopwatch();
            watchFindNonExistend.Start();
            List<string> serverFileList = await CreateServerFileList();
            await Task.Run(() =>
            {
                List<string> newDocuments = serverFileList.Except(LibraryDocumentDictionary.Keys.ToList()).ToList();
                foreach(string key in newDocuments)
                {
                    DocumentClass documentClass = new DocumentClass
                    {
                        Key = key,
                    };
                    LibraryDocumentDictionary.Add(key, documentClass);
                }
            });
            watchFindNonExistend.Stop();
            Console.WriteLine($"watchRemoveNonExistend  ->  Execution Time: {watchFindNonExistend.ElapsedMilliseconds} ms");

            return LibraryDocumentDictionary;
        }
        public static async Task<List<string>> CreateServerFileList()
        {
            List<FileInfo> list = new List<FileInfo>();
            var watchEnumerateFilesFast = new System.Diagnostics.Stopwatch();
            await Task.Run(() =>
            {
                watchEnumerateFilesFast.Start();
                list = EnumerateFilesFast(@"C:\Users\jagarinecr\Desktop\VML_Test\Server", @"\.CATPart|\.CATProduct", SearchOption.AllDirectories);
                watchEnumerateFilesFast.Stop();
            });
            Console.WriteLine($"EnumerateFilesFast files count::  {list.Count}  -> time: {watchEnumerateFilesFast.ElapsedMilliseconds} ms");
            return list.Select(file => file.FullName.Remove(0, serverCore.Length)).ToList();
        }

        public static List<FileInfo> EnumerateFilesFast(string path, string searchPatternExpression, SearchOption searchOption)
        {
            var dirInfo = new DirectoryInfo(path);
            List<FileInfo> files;
            Regex reSearchPattern = new Regex(searchPatternExpression, RegexOptions.IgnoreCase);
            if (searchOption == SearchOption.TopDirectoryOnly)
                files = dirInfo.EnumerateFiles("*.*", SearchOption.TopDirectoryOnly).Where(f =>
                               reSearchPattern.IsMatch(Path.GetExtension(f.FullName)))
                    .ToList();
            else
                files = dirInfo.EnumerateFiles("*.*", SearchOption.TopDirectoryOnly).Where(f =>
                               reSearchPattern.IsMatch(Path.GetExtension(f.FullName)))
                    .Union
                    (
                        dirInfo.EnumerateDirectories()
                            .AsParallel()
                            .SelectMany(di => di.EnumerateFiles("*.*", SearchOption.AllDirectories).Where(f =>
                               reSearchPattern.IsMatch(Path.GetExtension(f.FullName)))
                            )
                    ).ToList();
            return files;
        }

        public static void StoreDocumentClassesDict()
        {
            var watchStore = new System.Diagnostics.Stopwatch();
            watchStore.Start();
            //disassembledDocumentClasses.Clear();
            foreach (KeyValuePair<string, DocumentClass> keyValuePair in LibraryDocumentDictionary.Where(kvp => kvp.Value.Modified))
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
            DisassembledDocumentClasses.Keys.Where(key => !LibraryDocumentDictionary.ContainsKey(key)).ToList().ForEach(key => DisassembledDocumentClasses.Remove(key));
            String jsonString = JsonSerializer.Serialize(DisassembledDocumentClasses);
            System.IO.File.WriteAllText(@"D:\DATABASE\TestDict.JSON", jsonString);
            watchStore.Stop();
            Console.WriteLine($"watchStore  ->  Execution Time: {watchStore.ElapsedMilliseconds} ms");
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
            System.IO.File.WriteAllText(@"D:\DATABASE\RevisionDict.JSON", jsonString);
            watchStore.Stop();
            Console.WriteLine($"watchStore  ->  Execution Time: {watchStore.ElapsedMilliseconds} ms");
        }

        private static Dictionary<string, RevisionClass> CollectRevisionDocuments()
        {
            Dictionary<string, RevisionClass> oDict = new Dictionary<string, RevisionClass>();
            string libraryPath = @"D:\DATABASE\RevisionDict.JSON";
            string jsonString = System.IO.File.ReadAllText(libraryPath);
            Dictionary<string, RevisionClassRAW> dictRAW = JsonSerializer.Deserialize<Dictionary<string, RevisionClassRAW>>(jsonString);
            HashSet<string> pics = CollectPictures();
            foreach (KeyValuePair<string, RevisionClassRAW> keyValue in dictRAW)
            {
                RevisionClass revisionClass = new RevisionClass();
                revisionClass.BuildRevisionClass(keyValue.Value);

                revisionClass.RevisionPics = pics.Where(path => path.Contains("_" + revisionClass.RevisionID + "_")).ToHashSet();
                oDict.Add(keyValue.Key, revisionClass);
            }
            return oDict;
        }
    }
}
