using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public static Dictionary<string, DocumentClass> InSessionDocumentDictionary { get; set; } = CollectDocuments(CatiaLauncher());
        public static Dictionary<string, DocumentClass> LibraryDocumentDictionary { get; set; } = CollectLibraryDocuments();
        private static Dictionary<string, DocumentClassRAW> disassembledDocumentClasses = new Dictionary<string, DocumentClassRAW>();
        public static List<string> dataBaseMissingKeys;
        public static List<string> deletedFilesKeys;

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

        public static void UpdateLibrary(List<string> pathList) {
            INFITF.Application app = CatiaLauncher();
            if (app.Documents.Count < 2) {
                pathList.Where(path => !LibraryDocumentDictionary.ContainsKey(path)).ToList().ForEach(path =>
                {
                    Document doc = app.Documents.Read(path);
                    InSessionDocumentDictionary = CollectDocuments(app);
                    foreach (string key in InSessionDocumentDictionary.Keys.ToList())
                    {
                        if (!LibraryDocumentDictionary.ContainsKey(key)) {
                            LibraryDocumentDictionary.Add(key, InSessionDocumentDictionary[key]);
                        }
                        else {
                            LibraryDocumentDictionary[key].ChildrenDict.Keys.ToList().Where(x => !InSessionDocumentDictionary[key].ChildrenDict.ContainsKey(x)).ToList().ForEach(kk => 
                            { 
                                LibraryDocumentDictionary[key].ChildrenDict.Remove(kk);
                                LibraryDocumentDictionary[key].DocumentClassModified = true;
                            });
                            InSessionDocumentDictionary[key].ChildrenDict.Keys.ToList().Where(x => !LibraryDocumentDictionary[key].ChildrenDict.ContainsKey(x)).ToList().ForEach(kk => 
                            {
                                LibraryDocumentDictionary[key].ChildrenDict.Add(kk, InSessionDocumentDictionary[kk]);
                                LibraryDocumentDictionary[key].DocumentClassModified = true;
                            });
                            InSessionDocumentDictionary[key].ParentsDict.Keys.ToList().Where(x => !LibraryDocumentDictionary[key].ParentsDict.ContainsKey(x)).ToList().ForEach(kk =>
                            {
                                LibraryDocumentDictionary[key].ParentsDict.Add(kk, InSessionDocumentDictionary[kk]);
                                LibraryDocumentDictionary[key].DocumentClassModified = true;
                            });
                        }
                    };
                    doc.Close();
                }
                );
                StoreDocumentClassesDict(LibraryDocumentDictionary);
            }
        }

        public static Dictionary<string, DocumentClass> CollectDocuments(INFITF.Application App)
        {
            Console.WriteLine("CollectDocuments  ->  Start");
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            Dictionary<string, DocumentClass> CatiaDocuments = new Dictionary<string, DocumentClass>();
            Regex reSearchPattern = new Regex(@"CATPart|CATProduct", RegexOptions.IgnoreCase);

            foreach (Document doc in App.Documents)
            {
                Match match = reSearchPattern.Match(doc.FullName.Split('.').Last());
                if (match.Success)
                {
                    DocumentClass clsDoc;
                    if (!CatiaDocuments.ContainsKey(doc.FullName))
                    {
                        clsDoc = new DocumentClass();
                        clsDoc.DocumentClassModified = true;
                        clsDoc.FullName = doc.FullName;
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
                            subclsDoc = new DocumentClass();
                            subclsDoc.DocumentClassModified = true;
                            subclsDoc.FullName = subDoc.FullName;
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
            Console.WriteLine($"CollectDocuments  ->  Execution Time: {watch.ElapsedMilliseconds} ms");

            return CatiaDocuments;
        }

        #endregion

        #region ReadDocumentLibraryDictionary
        
        private static Dictionary<string, DocumentClass> CollectLibraryDocuments()
        {
            Dictionary<string, DocumentClass> libraryDocuments = new Dictionary<string, DocumentClass>();
            Dictionary<string, DocumentClassRAW> disassembledDocumentClasses = new Dictionary<string, DocumentClassRAW>();
            string libraryPath = @"D:\DATABASE\TestDict.JSON";
            string jsonString = System.IO.File.ReadAllText(libraryPath);
            disassembledDocumentClasses = JsonSerializer.Deserialize<Dictionary<string, DocumentClassRAW>>(jsonString);
            foreach (KeyValuePair<string, DocumentClassRAW> keyValue in disassembledDocumentClasses) {
                DocumentClass documentClass = new DocumentClass();
                documentClass.DocumentClassModified = false;
                documentClass.FullName = keyValue.Key;
                documentClass.DataBaseFileDate = keyValue.Value.libraryTime;
                libraryDocuments.Add(keyValue.Key, documentClass);
            }
            foreach (KeyValuePair<string, DocumentClassRAW> keyValue in disassembledDocumentClasses)
            {
                keyValue.Value.Children.ForEach(i => libraryDocuments[keyValue.Key].AdChild(libraryDocuments[i]));
                keyValue.Value.Parents.ForEach(i => libraryDocuments[keyValue.Key].AdParent(libraryDocuments[i]));
            }
            return libraryDocuments;
        }

        #endregion

        public static async Task<Dictionary<string, DocumentClass>> InitialDictionariesUpdate()
        {
            var watchRemoveNonExistend = new System.Diagnostics.Stopwatch();
            int removedItems = 0;

            watchRemoveNonExistend.Start();

            string[] allRealTimeLibraryKeys = await ReadLiveFileList();
            List<string> allDataBaseFileKeys = VMLCoordinator.LibraryDocumentDictionary.Keys.ToList();
            deletedFilesKeys = allDataBaseFileKeys.Except(allRealTimeLibraryKeys).ToList();
            dataBaseMissingKeys = allRealTimeLibraryKeys.Except(allDataBaseFileKeys).ToList();
            foreach (string item in deletedFilesKeys)
            {
                DocumentClass documentClass = LibraryDocumentDictionary[item];
                documentClass.ChildrenDict.Keys.ToList().Where(x => LibraryDocumentDictionary.ContainsKey(x)).ToList().ForEach(key => { 
                    LibraryDocumentDictionary[key].ParentsDict.Remove(item);
                    LibraryDocumentDictionary[key].DocumentClassModified = true;
                });
                documentClass.ParentsDict.Keys.ToList().Where(x => LibraryDocumentDictionary.ContainsKey(x)).ToList().ForEach(key =>
                {
                    LibraryDocumentDictionary[key].ChildrenDict.Remove(item);
                    LibraryDocumentDictionary[key].DocumentClassModified = true;
                });
                LibraryDocumentDictionary.Remove(item);
                removedItems += 1;
            }
            watchRemoveNonExistend.Stop();
            Console.WriteLine($"watchRemoveNonExistend  ->  Execution Time: {watchRemoveNonExistend.ElapsedMilliseconds} ms");
            return VMLCoordinator.LibraryDocumentDictionary;
        }
        public static async Task<string[]> ReadLiveFileList()
        {
            List<FileInfo> list = new List<FileInfo>();
            var watchEnumerateFilesFast = new System.Diagnostics.Stopwatch();
            await Task.Run(() =>
            {
                watchEnumerateFilesFast.Start();
                list = EnumerateFilesFast(@"K:\V2 TRANSFORMATOR\Knjiznica AD\02_Namoti\01_Namot_Sp2_00", @"\.CATPart|\.CATProduct", SearchOption.AllDirectories);
                watchEnumerateFilesFast.Stop();
            });
            Console.WriteLine($"EnumerateFilesFast files count::  {list.Count}  -> time: {watchEnumerateFilesFast.ElapsedMilliseconds} ms");
            return list.Select(file => file.FullName).ToArray();
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

        public static void StoreDocumentClassesDict(Dictionary<string, DocumentClass> oDict) 
        {
            var watchStore = new System.Diagnostics.Stopwatch();
            watchStore.Start();
            oDict.Keys.ToList().Where(key => oDict[key].DocumentClassModified).ToList().ForEach(x =>
            {
               DocumentClass documentClass = oDict[x];
               documentClass.DataBaseFileDate = documentClass.ActualFileDate;
               DocumentClassRAW documentClassRAW = new DocumentClassRAW();
               documentClassRAW.FillDCR(documentClass);
               disassembledDocumentClasses.Add(x, documentClassRAW);
            });
            String jsonString = JsonSerializer.Serialize(disassembledDocumentClasses);
            System.IO.File.WriteAllText(@"D:\DATABASE\TestDict.JSON", jsonString);
            watchStore.Stop();
            Console.WriteLine($"watchStore  ->  Execution Time: {watchStore.ElapsedMilliseconds} ms");
        }
    }
}
