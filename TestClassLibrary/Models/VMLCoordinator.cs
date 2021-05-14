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
        public static Dictionary<string, DocumentClass> InSessionDocumentDictionary { get; } = CollectDocuments(CatiaLauncher());
        public static Dictionary<string, List<string>> ParentsDictionary { get; } = CreateInitialParentDictionary(InSessionDocumentDictionary);
        public static Dictionary<string, DocumentClass> LibraryDocumentDictionary { get; set; } = CollectLibraryDocuments(ParentsDictionary);
        public static List<string> oldAllFiles { get; } = ReadOldAllFilesList();

        private static List<string> ReadOldAllFilesList()
        {
            List<string> completeFileList = new List<string>();
            if (System.IO.File.Exists(@"C:\Users\jagarinecr\Desktop\SyncTest\oldAllFiles.JSON"))
            {
                string oldAllFilesPath = @"C:\Users\jagarinecr\Desktop\SyncTest\oldAllFiles.JSON";
                string jsonString = System.IO.File.ReadAllText(oldAllFilesPath);
                completeFileList = JsonSerializer.Deserialize<List<string>>(jsonString);
            }
            return completeFileList;
        }

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
            Console.WriteLine("CollectDocuments  ->  Start");
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            Dictionary<string, DocumentClass> CatiaDocuments = new Dictionary<string, DocumentClass>();
            foreach (Document doc in App.Documents)
            {
                DocumentClass clsDoc;
                if (!CatiaDocuments.ContainsKey(doc.FullName))
                {
                    clsDoc = new DocumentClass();
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
        
        private static Dictionary<string, DocumentClass> CollectLibraryDocuments(Dictionary<string, List<string>> parentsDictionary)
        {
                Dictionary<string, DocumentClass> libraryDocuments = new Dictionary<string, DocumentClass>();
                string libraryPath = @"D:\DATABASE\Library.JSON";
                string jsonString = System.IO.File.ReadAllText(libraryPath);
                libraryDocuments = JsonSerializer.Deserialize<Dictionary<string, DocumentClass>>(jsonString);
                foreach (KeyValuePair<string,List<string>> keyValuePair in parentsDictionary)
                {
                if (libraryDocuments.Keys.Contains(keyValuePair.Key))
                    {
                        foreach (string key in keyValuePair.Value)
                        {
                            libraryDocuments[keyValuePair.Key].AdParent(libraryDocuments[key]);
                            libraryDocuments[key].AdChild(libraryDocuments[keyValuePair.Key]);
                        }
                    }
                }
            return libraryDocuments;
        }

        #endregion

        private static Dictionary<string, List<string>> CreateInitialParentDictionary(Dictionary<string,DocumentClass> oDict)
        {
            Dictionary<string, List<string>> parentDictionary = new Dictionary<string, List<string>>();
            string libraryPath = @"D:\DATABASE\Parents.JSON";
            string jsonString = System.IO.File.ReadAllText(libraryPath);
            parentDictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonString) ?? new Dictionary<string, List<string>>();

            foreach (KeyValuePair<string,DocumentClass> keyValue in oDict)
            {
                if (keyValue.Value.Used)
                {
                    List<string> parentsList = keyValue.Value.ParentsDict.Keys.ToList();
                    if (parentDictionary.ContainsKey(keyValue.Key))
                     {
                        parentDictionary[keyValue.Key] = parentsList;
                    }
                    else
                    {
                        parentDictionary.Add(keyValue.Key, parentsList);
                    }
                }
            }

            return parentDictionary;
        }

        public static async Task<Dictionary<string,DocumentClass>> InitialDictionariesUpdate()
        {
            var watchRemoveNonExistend = new System.Diagnostics.Stopwatch();
            int removedItems = 0;

            watchRemoveNonExistend.Start();

            string[] existingFiles = await ReadLiveFileList();
            List<string> parents = VMLCoordinator.ParentsDictionary.Keys.ToList();
            List<string> deletedFiles = parents.Except(existingFiles).ToList();
            foreach (string item in deletedFiles)
            {
                VMLCoordinator.ParentsDictionary.Remove(item);
                removedItems += 1;
            }
            VMLCoordinator.LibraryDocumentDictionary  = CollectLibraryDocuments(VMLCoordinator.ParentsDictionary);
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
                list = EnumerateFilesFast(@"K:\V2 RAZVOJ", @"\.CATPart|\.CATProduct", SearchOption.AllDirectories);
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
    }
}
