using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INFITF;
using System.IO;

namespace VerManagerLibrary_ClassLib
{
    public class DocumentClass
    {
        #region ChildrenDict
        private Dictionary<string, DocumentClass> childrenDict = new Dictionary<string, DocumentClass>();
        /// <summary>
        /// Add child to this document.
        /// </summary>
        /// <param name="documentClassInstance"></param>
        public void AddChild(DocumentClass documentClassInstance)
        {
            if (!childrenDict.ContainsKey(documentClassInstance.Key))
            {
                childrenDict.Add(documentClassInstance.Key, documentClassInstance); 
                modified = true;
            }
        }
        public void RemoveChild(string key) {
            childrenDict.Remove(key); 
            modified = true;
        }
        public void ClearChildren()
        {
            childrenDict.Clear();
            modified = true;
        }
        public IReadOnlyDictionary<string, DocumentClass> ChildrenDict => childrenDict;
        #endregion
        #region ParentsDict
        private Dictionary<string, DocumentClass> parentsDict = new Dictionary<string, DocumentClass>();
        /// <summary>
        /// Add parent product to this document.
        /// </summary>
        /// <param name="documentClassInstance"></param>
        public void AddParent(DocumentClass documentClassInstance)
        {
            if (!parentsDict.ContainsKey(documentClassInstance.Key))
            {
                parentsDict.Add(documentClassInstance.Key, documentClassInstance); 
                modified = true;
            }
        }
        public void RemoveParent(string key)
        {
            if (parentsDict.ContainsKey(key))
            {
                parentsDict.Remove(key);
                modified = true;
            }
        }
        public void ClearParents()
        {
            parentsDict.Clear(); 
            modified = true;
        }
        public IReadOnlyDictionary<string, DocumentClass> ParentsDict => parentsDict;
        #endregion
        #region RevisionDictionary
        /// <summary>
        /// Imenik sa svim revizijama koje su vezane na aktualni dokument.<para/>
        /// </summary>
        private Dictionary<string, long> revisionDict = new Dictionary<string, long>();
        /// <summary>
        /// Add a new Revision to dictionary::
        /// </summary>
        /// <param name="RevisionID">[Key] -> RevisionID</param>
        /// <param name="rD_Info">        
        /// 0 - izvorno odabran dokument u reviziji - unsolved revision <br/>
        /// 1 - dokument iste/slične nomenklature - unsolved revision <br/>
        /// 2 - dokument roditelj koji postaje zastarjeli usljed ove revizije <br/>
        /// 3 - izvorno odabran dokument u reviziji - solved revision <br/>
        /// 4 - dokument iste/slične nomenklature - solved revision <br/>
        /// </param>    
        public void AddRevision(string RevisionID, long rD_Info)
        {
            if (!revisionDict.ContainsKey(RevisionID))
            {
                revisionDict.Add(RevisionID, rD_Info);
                modified = true;
            }
            else if (revisionDict[RevisionID] > rD_Info)
            {
                revisionDict[RevisionID] = rD_Info;
                modified = true;
            }
        }
        public void RemoveRevision(string key)
        {
            revisionDict.Remove(key);
            modified = true;
        }
        public void ClearRevisions()
        {
            revisionDict.Clear();
            modified = true;
        }
        public void ModifyRevision(string RevisionID, long rD_Info)
        {
            if (revisionDict.ContainsKey(RevisionID))
            {
                revisionDict[RevisionID] = rD_Info;
                modified = true;
            }
        }
        public IReadOnlyDictionary<string, long> RevisionDict => revisionDict;
        #endregion

        private string version;
        /// <summary>
        /// Environment.UserName + "_V_" + Number
        /// </summary>
        public string Version { get { return version; } }
        public void IncreaseVersion()
        {
            int number;
            if (version != null)
            {
                number = Int32.Parse(version.Split('_').Last()) + 1;
                modified = true;
            }
            else
            {
                number = 1;
            }
            version = Environment.UserName + "_V_" + number.ToString();
        }
        private DateTime? dataBaseFileDate;
        public DateTime? DataBaseFileDate { 
            get { return dataBaseFileDate; } 
            set { dataBaseFileDate = value; modified = true; }}
        public DateTime LocalFileDate { get { return new FileInfo(VMLCoordinator.localCore + Key).LastWriteTime; } }
        public DateTime ServerFileDate { get { return new FileInfo(VMLCoordinator.serverCore + Key).LastWriteTime; } }
        private string oldNomenclature;
        public string OldNomenclature { get { return oldNomenclature; } }
        private string newNomenclature;
        public string NewNomenclature { 
            get { return newNomenclature; } 
            set { newNomenclature = value; modified = true; } }
        public void SetInitaialNomenclature(string oValue)
        {
            oldNomenclature = oValue;
            newNomenclature = oValue;
        }
        public bool Used { get { return ParentsDict.Count != 0; } }
        public bool OnServer { get { return System.IO.File.Exists(VMLCoordinator.serverCore + Key); } }
        public bool OnLocalDisc { get { return System.IO.File.Exists(VMLCoordinator.localCore + Key); } }
        public string Status { get {
                if (dataBaseFileDate == null)
                {
                    if (!OnServer)
                    {
                        return "New";
                    }
                    else
                    {
                        return "Missing Database Input";
                    }
                }
                else
                {
                    if (!OnServer)
                    {
                        return "Missing server file - " + version;
                    }
                    else
                    {
                        if (ServerFileDate < dataBaseFileDate)
                        {
                            return "Server version obsolete: " + version;
                        }
                        else
                        {
                            if (LocalFileDate == dataBaseFileDate)
                            {
                                return "";
                            }
                            else
                            {
                                return "Local version modified.";
                            }
                        }
                    }
                }
            } }
        public bool InSession { get { return VMLCoordinator.CheckInSession(Key); } }
        /// <summary>
        /// 0 - izvorno odabran dokument u reviziji - unsolved revision <br/>
        /// 1 - dokument iste/slične nomenklature - unsolved revision <br/>
        /// 2 - dokument roditelj koji postaje zastarjeli usljed ove revizije <br/>
        /// 3 - izvorno odabran dokument u reviziji - solved revision <br/>
        /// 4 - dokument iste/slične nomenklature - solved revision <br/>
        /// 5 - dokument nema pridodanu reviziju i ni jedna revizija ne utječe na njega<br/>
        /// </summary>
        public long RevisionStatus(string revisionID) {
            if (revisionDict.ContainsKey(revisionID)) return revisionDict[revisionID];
            return 5;
        }
        public bool HasChindren { get { return childrenDict.Count != 0; } }
        private bool modified = false;
        public void UploadDoc()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(VMLCoordinator.serverCore + Key));
            System.IO.File.Copy(VMLCoordinator.localCore + Key, VMLCoordinator.serverCore + Key,true);
            modified = false;
        }
        public bool Modified { get { return modified; } }
        public string PartName { get { return Path.GetFileName(Key); } }
        public string Key { get; set; }

        /// <summary>
        /// Metoda koja izgradi "DocumentClass" instancu na temelju "sirove" instance koja je ucitana JsonSerializer-om.
        /// </summary>
        /// <param name="RawClass"></param>
        public void BuildDocumentClass(DocumentClassRAW RawClass, Dictionary<string, RevisionClass> completeRevisionsDict) {
            Key = RawClass.Key;
            completeRevisionsDict.Where(kvp => kvp.Value.RevisionDocuments.ContainsKey(Key)).ToList().ForEach(x => revisionDict.Add(x.Key, x.Value.RevisionDocuments[Key]));
            dataBaseFileDate = RawClass.LibraryTime;
            SetInitaialNomenclature(RawClass.Nomenclture);
            version = RawClass.Version;
        }
        public void FillSiblings(DocumentClassRAW RawClass,Dictionary<string,DocumentClass> DCLibrary)
        {
            RawClass.Children.ForEach(i =>
            {
                if (DCLibrary.ContainsKey(i))
                {
                    childrenDict.Add(i, DCLibrary[i]);
                };
            });
            RawClass.Parents.ForEach(i => 
            {
                if (DCLibrary.ContainsKey(i))
                {
                    parentsDict.Add(i, DCLibrary[i]);
                };
            });
        }
    }
}