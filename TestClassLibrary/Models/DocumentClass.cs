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
    public class CatiaFileInfo
    {
        #region properties
        public string Status { get; set; }
        public DateTime? LocalTime { get; set; }
        public DateTime? ServerTime { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string LockedBy { get; set; }
        public string SyncStatus { get; set; }
        public DateTime? LockTime { get; set; }
        public DateTime? SyncTime { get; set; }
        #endregion
    }
    public class DocumentClass : CatiaFileInfo
    {
        #region ChildrenDict
        private Dictionary<string, DocumentClass> childrenDict = new Dictionary<string, DocumentClass>();
        /// <summary>
        /// Add child to this document.
        public void AddChild(DocumentClass documentClassInstance)
        {
            if (!childrenDict.ContainsKey(documentClassInstance.Key))
            {
                childrenDict.Add(documentClassInstance.Key, documentClassInstance);
                Modified = true;
            }
        }
        public void RemoveChild(string key) {
            childrenDict.Remove(key);
            Modified = true;
        }
        public void ClearChildren()
        {
            childrenDict.Clear();
            Modified = true;
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
                Modified = true;
            }
        }
        public void RemoveParent(string key)
        {
            if (parentsDict.ContainsKey(key))
            {
                parentsDict.Remove(key);
                Modified = true;
            }
        }
        public void ClearParents()
        {
            parentsDict.Clear();
            Modified = true;
        }
        public IReadOnlyDictionary<string, DocumentClass> ParentsDict => parentsDict;
        #endregion
        #region RevisionDictionary
        /// <summary>
        /// Imenik sa svim revizijama koje su vezane na aktualni dokument.<para/>
        /// </summary>
        private readonly Dictionary<string, long> revisionDict = new Dictionary<string, long>();
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
                Modified = true;
            }
            else if (revisionDict[RevisionID] > rD_Info)
            {
                revisionDict[RevisionID] = rD_Info;
                Modified = true;
            }
        }
        public void RemoveRevision(string key)
        {
            revisionDict.Remove(key);
            Modified = true;
        }
        public void ClearRevisions()
        {
            revisionDict.Clear();
            Modified = true;
        }
        public IReadOnlyDictionary<string, long> RevisionDict => revisionDict;
        #endregion
        public Document CatiaDoc{ get; set; }
        #region Version
        public string SqlVersion { get; set; }
        /// <summary>
        /// Environment.UserName + "_V_" + Number
        /// </summary>
        public string OldVersion { get; set; }
        public string LocalVersion {get; set; }
        public void IncreaseVersion()
        {
            int number = Int32.Parse(LocalVersion.Split('_').Last()) + 1;
            OldVersion = LocalVersion;
            LocalVersion = Environment.UserName + "_V_" + number.ToString();
            VMLCoordinator.SetLocalVersion(CatiaDoc, LocalVersion);
            CatiaDoc.Save();
            Modified = true;
        }
        public void UndoVersionIncrease()
        {
            if (OldVersion != null)
            {
                LocalVersion = OldVersion;
                VMLCoordinator.SetLocalVersion(CatiaDoc, LocalVersion);
                CatiaDoc.Save();
                OldVersion = null;
                Modified = true;
            }
        }
        #endregion
        #region Nomenclature
        /// <summary>
        /// Cita iz baze.
        /// Da bi se moglo editirati, dokument mora biti zakjucan na korisnika.
        /// </summary>
        public string LocalNomenclature { get; set; }
        /// <summary>
        /// Privremeni spremnik stare nomenklature prije zapisa u bazu. Za slucaj odustajanja.
        /// </summary>
        public string SqlNomenclature { get; set; }
        /// <summary>
        /// Procedura koja privremeno sluzi za postavljanje vrijednosti nomenklatura u objektu.
        /// Vrijednost uzima iz baze. Za nove objekte iz parametra u Catia dokumentu.
        /// </summary>
        /// <param name="oValue"></param>
        #endregion
        public string Key { get { return Location + Name; } }
        /// <summary>
        /// Bool koji definira da li je dokument ucitan u session Catia-e.
        /// </summary>
        public bool InSession { get; set; }
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
        /// <summary>
        /// DocumentClass objekt je izmjenjen i spremanje je potrebno.
        /// </summary>
        public bool Modified { get; set; }
        /// <summary>
        /// Privremena procedura za upload dokumenta na mrežu.
        /// Ovo ce preuzeti CatiaDocNet
        /// </summary>

        #region Privremeno_IZBACITI
        public void UploadDoc()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(VMLCoordinator.serverCore + Key));
            System.IO.File.Copy(VMLCoordinator.localCore + Key, VMLCoordinator.serverCore + Key,true);
            Modified = false;
        }

        /// <summary>
        /// Metoda koja izgradi "DocumentClass" instancu na temelju "sirove" instance koja je ucitana JsonSerializer-om.
        /// </summary>
        /// <param name="RawClass"></param>
        public void BuildDocumentClass(DocumentClassRAW RawClass, Dictionary<string, RevisionClass> completeRevisionsDict) {
            Location = new FileInfo(RawClass.Key).Directory.FullName + @"\";
            Name = new FileInfo(RawClass.Key).Name;
            completeRevisionsDict.Where(kvp => kvp.Value.RevisionDocuments.ContainsKey(Key)).ToList().ForEach(x => revisionDict.Add(x.Key, x.Value.RevisionDocuments[Key].RD_Value));
            SqlNomenclature = RawClass.Nomenclture;
            if (RawClass.Version != "") SqlVersion = RawClass.Version;
            else IncreaseVersion();
        }
        /// <summary>
        /// Metoda za inicijalno popunjavanje "parent" i "children" kolekcija.
        /// </summary>
        /// <param name="RawClass"></param>
        /// <param name="DCLibrary"></param>
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
        #endregion
    }
}