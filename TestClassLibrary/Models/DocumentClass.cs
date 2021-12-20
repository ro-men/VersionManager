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
        private string oldVersion;
        public string OldVersion { get { return oldVersion; } }

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
            oldVersion = version;
            version = Environment.UserName + "_V_" + number.ToString();
        }
        public void UndoVersionIncrease()
        {
            version = oldVersion;
            oldVersion = null;
        }
        private string lockValue;
        public string GetLockValue { get { return lockValue; } }
        public void SetLock() { 
            if (lockValue == "")
            {
                lockValue = Environment.UserName;
            }
        }
        /// <summary>
        /// Ovo cita iz baze podataka.
        /// </summary>
        private DateTime? dataBaseFileDate;
        public DateTime? DataBaseFileDate { 
            get { return dataBaseFileDate; } 
            set { dataBaseFileDate = value; modified = true; }}
        /// <summary>
        /// Ovo cita iz fileAtributa na lokalnom disku.
        /// </summary>
        public DateTime? LocalFileDate { get { return new FileInfo(VMLCoordinator.localCore + Key).LastWriteTime; } }
        /// <summary>
        /// Ovo cita iz baze podataka.
        /// Ako je dokument zakljucana na aktivnog usera, onda provjerava vrijeme sa serverom.
        /// </summary>
        public DateTime? ServerFileDate { get { return new FileInfo(VMLCoordinator.serverCore + Key).LastWriteTime; } }
        /// <summary>
        /// Cita iz baze.
        /// Da bi se moglo editirati, dokument mora biti zakjucan na korisnika.
        /// </summary>
        private string newNomenclature;
        public string NewNomenclature { 
            get { return newNomenclature; } 
            set { newNomenclature = value; modified = true; } }
        /// <summary>
        /// Privremeni spremnik stare nomenklature prije zapisa u bazu. Za slucaj odustajanja.
        /// </summary>
        private string oldNomenclature;
        public string OldNomenclature { get { return oldNomenclature; } }
        /// <summary>
        /// Procedura koja privremeno sluzi za postavljanje vrijednosti nomenklatura u objektu.
        /// Vrijednost uzima iz baze. Za nove objekte iz parametra u Catia dokumentu.
        /// </summary>
        /// <param name="oValue"></param>
        public void SetInitaialNomenclature(string oValue)
        {
            oldNomenclature = oValue;
            newNomenclature = oValue;
        }
        /// <summary>
        /// Interni parametar. Nema komunikacije sa bazom.
        /// </summary>
        public bool Used { get { return ParentsDict.Count != 0; } }
        /// <summary>
        /// Bool koji određuje da li dokument postoji na serveru.
        /// Ranije je bila fileExists funkcija, no zbog brzine odaziva je promjenjeno u provjeru zapisa vremena u bazi.
        /// </summary>
        public bool OnServer { get { return ServerFileDate != null; } }
        /// <summary>
        /// Bool koji određuje da li dokument postoji lokalno.
        /// </summary>
        public bool OnLocalDisc { get { return LocalFileDate != null; } }
        /// <summary>
        /// Status dokumenta koji regulira moguće radnje na istom. (upload, sync, download ...)
        /// Treba još uskladiti sa CatiaDocNet statusom
        /// </summary>
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
        /// Product ima children komponente.
        /// </summary>
        public bool HasChindren { get { return childrenDict.Count != 0; } }
        /// <summary>
        /// DocumentClass objekt je izmjenjen i spremanje je potrebno.
        /// </summary>
        private bool modified = false;
        public bool Modified { get { return modified; } }
        /// <summary>
        /// Privremena procedura za upload dokumenta na mrežu.
        /// Ovo ce preuzeti CatiaDocNet
        /// </summary>
        public void UploadDoc()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(VMLCoordinator.serverCore + Key));
            System.IO.File.Copy(VMLCoordinator.localCore + Key, VMLCoordinator.serverCore + Key,true);
            modified = false;
        }
        /// <summary>
        /// Document PartName
        /// </summary>
        public string PartName { get { return Path.GetFileName(Key); } }
        public string Key { get; set; }
        /// <summary>
        /// Metoda koja izgradi "DocumentClass" instancu na temelju "sirove" instance koja je ucitana JsonSerializer-om.
        /// </summary>
        /// <param name="RawClass"></param>
        public void BuildDocumentClass(DocumentClassRAW RawClass, Dictionary<string, RevisionClass> completeRevisionsDict) {
            Key = RawClass.Key;
            completeRevisionsDict.Where(kvp => kvp.Value.RevisionDocuments.ContainsKey(Key)).ToList().ForEach(x => revisionDict.Add(x.Key, Int32.Parse(x.Value.RevisionDocuments[Key][0])));
            dataBaseFileDate = RawClass.LibraryTime;
            SetInitaialNomenclature(RawClass.Nomenclture);
            if (RawClass.Version != "") version = RawClass.Version;
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
    }
}