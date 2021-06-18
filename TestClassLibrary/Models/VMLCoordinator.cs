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
        public static string localCore = @"D:\CATIA\local\V2 RAZVOJ";
        public static string serverCore = @"K:\V2 RAZVOJ";
        public static Dictionary<string, DocumentClass> LibraryDocumentDictionary { get; set; } = CollectLibraryDocuments();
        public static Dictionary<string, RevisionClass> RevisionDictionary { get; set; } = CollectRevisionDocuments();
        private static Dictionary<string, DocumentClassRAW> DisassembledDocumentClasses { get; set; }
        public static List<string> newFileKeys;
        public static List<string> deletedFilesKeys = new List<string>();

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

        public static async Task<Dictionary<string, DocumentClass>> CollectInSessionDocuments()
        {
            Console.WriteLine("CollectDocuments  ->  Start");
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            INFITF.Application App = CatiaLauncher();
            List<Product> products = new List<Product>();
            Regex reSearchPattern = new Regex(@"CATPart|CATProduct", RegexOptions.IgnoreCase);
            Regex reSearchPatternDir = new Regex(@"D:\\CATIA\\local\\V2 RAZVOJ\\Knjiznica AD\\|D:\\CATIA\\local\\V2 RAZVOJ\\Knjiznica MD\\|D:\\CATIA\\local\\V2 RAZVOJ\\Osnovni Model V2\\", RegexOptions.IgnoreCase);
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
                            if (!LibraryDocumentDictionary.ContainsKey(doc.FullName.Remove(0, localCore.Length)))
                            {
                                clsDoc = new DocumentClass();
                                clsDoc.Key = doc.FullName.Remove(0, localCore.Length);
                                clsDoc.InSession = true;
                                LibraryDocumentDictionary.Add(clsDoc.Key, clsDoc);
                            }
                            else
                            {
                                clsDoc = LibraryDocumentDictionary[doc.FullName.Remove(0, localCore.Length)];
                                clsDoc.InSession = true;
                            }
                            if (Path.GetExtension(doc.FullName).ToUpper() == ".CATPRODUCT")
                            {
                                clsDoc.ChildrenDict.Keys.ToList().ForEach(key => {
                                    LibraryDocumentDictionary[key].RemoveParent(clsDoc.Key);
                                });
                                clsDoc.ClearChildren();
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
                    DocumentClass clsDoc = LibraryDocumentDictionary[doc.FullName.Remove(0, localCore.Length)];
                    if (oProd.Products.Count != 0)
                    {
                        foreach (Product subProd in oProd.Products)
                        {
                            Document subDoc = (Document)subProd.ReferenceProduct.Parent;
                            if (subDoc.FullName != doc.FullName)
                            {
                                DocumentClass subclsDoc;
                                subclsDoc = LibraryDocumentDictionary[subDoc.FullName.Remove(0, localCore.Length)];
                                clsDoc.AddChild(subclsDoc);
                                subclsDoc.AddParent(clsDoc);
                            }
                            else
                            {
                                UpdateChildren(subProd);
                            }
                        }
                    }
                }
            });
            watch.Stop();
            Console.WriteLine($"CollectDocuments  ->  Execution Time: {watch.ElapsedMilliseconds} ms");
            return VMLCoordinator.LibraryDocumentDictionary;
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
                documentClass.BuildDocumentClass(RawClass);
                libraryDocuments.Add(RawClass.Key, documentClass);
            }
            foreach (DocumentClassRAW RawClass in DisassembledDocumentClasses.Values)
            {
                DocumentClass documentClass = libraryDocuments[RawClass.Key];
                documentClass.FillSiblings(RawClass, libraryDocuments);
            }
            return libraryDocuments;
        }
        #endregion

        public static async Task<Dictionary<string, DocumentClass>> InitialDictionariesUpdate()
        {
            var watchRemoveNonExistend = new System.Diagnostics.Stopwatch();
            int removedItems = 0;

            watchRemoveNonExistend.Start();
            await Task.Run(() =>
            {
                VMLCoordinator.LibraryDocumentDictionary.ToList().Where(kvp => kvp.Value.OnServer == false).ToList().ForEach(kvp =>
                {
                    DocumentClass documentClass = kvp.Value;
                    documentClass.ChildrenDict.Keys.ToList().Where(x => LibraryDocumentDictionary.ContainsKey(x)).ToList().ForEach(key =>
                    {
                        LibraryDocumentDictionary[key].RemoveParent(kvp.Key);
                    });
                    documentClass.ParentsDict.Keys.ToList().Where(x => LibraryDocumentDictionary.ContainsKey(x)).ToList().ForEach(key =>
                    {
                        LibraryDocumentDictionary[key].RemoveChild(kvp.Key);
                    });
                    LibraryDocumentDictionary.Remove(kvp.Key);
                    deletedFilesKeys.Add(kvp.Key);
                    removedItems += 1;
                });
            });

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
            //disassembledDocumentClasses.Clear();
            foreach (KeyValuePair<string, DocumentClass> keyValuePair in oDict.Where(kvp => kvp.Value.Modified))
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
            String jsonString = JsonSerializer.Serialize(DisassembledDocumentClasses);
            System.IO.File.WriteAllText(@"D:\DATABASE\TestDict.JSON", jsonString);
            watchStore.Stop();
            Console.WriteLine($"watchStore  ->  Execution Time: {watchStore.ElapsedMilliseconds} ms");
        }
        public static void StoreRevisionDict(Dictionary<string, RevisionClass> oDict)
        {
            var watchStore = new System.Diagnostics.Stopwatch();
            watchStore.Start();
            Dictionary<string, RevisionRAW> dictRAW = new Dictionary<string, RevisionRAW>();
            foreach (KeyValuePair<string,RevisionClass> keyValuePair in oDict) {
                RevisionRAW revisionRAW = new RevisionRAW();
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
            Dictionary<string, RevisionRAW> dictRAW = JsonSerializer.Deserialize<Dictionary<string, RevisionRAW>>(jsonString);
            foreach (KeyValuePair<string, RevisionRAW> keyValue in dictRAW)
            {
                RevisionClass revisionClass = new RevisionClass();
                revisionClass.BuildRevisionClass(keyValue.Value);
                oDict.Add(keyValue.Key, revisionClass);
            }
            return oDict;
        }
    }
    /// <summary>
    /// json compatible class
    /// </summary>
    public class RevisionRAW
    {
        public void FillRCL(RevisionClass oRevision)
        {
            RevisionID = oRevision.RevisionID;
            Comment = oRevision.Comment;
            CoreDocuments = oRevision.CoreDocuments.ToList();
            OtherDocuments = oRevision.OtherDocuments.ToList();
            Siblings = oRevision.Siblings.ToList();
        }
        public string RevisionID { get; set; }
        public string Comment { get; set; }
        public List<KeyValuePair<string, bool>> CoreDocuments { get; set; }
        public List<KeyValuePair<string, bool>> OtherDocuments { get; set; }
        public List<string> Siblings { get; set; }
    }
}
