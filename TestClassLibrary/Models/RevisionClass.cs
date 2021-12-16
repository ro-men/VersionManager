using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VerManagerLibrary_ClassLib
{   
    public class RevisionClass
    {
        private string revisionID;
        public string RevisionID { get { return revisionID; } }
        public bool SolvedStatus { get {
                if(revisionDocuments.Values.Where(x => Int32.Parse(x[0]) < 2).ToList().Count() > 0 ) return false;
                return true;
            }}
        private string comment;
        public string Comment { 
            get { return comment; } 
            set { comment = value; modified = true; } }
        private int importanceLvl = 0;
        /// <summary>
        /// Value from 1 (high) to 3 (low)
        /// </summary>
        public int ImportanceLvl
        {
            get { return importanceLvl; }
            set { importanceLvl = value; modified = true; }
        }
        private bool modified;
        public bool Modified { get { return modified; } }
        public void CreateRevisionID()
        {
            DateTime today = DateTime.Today;
            int index = VMLCoordinator.RevisionDictionary.Keys.ToList().Where(x =>
                x.Contains(Environment.UserName) && x.Contains(DateTime.Today.Date.ToString("MM_dd_yyyy"))).Count() + 1;
            string IDValue = Environment.UserName + "_" + today.Date.ToString("MM_dd_yyyy") + "_" + index.ToString();
            while (VMLCoordinator.RevisionDictionary.ContainsKey(IDValue))
            {
                index ++;
                IDValue = Environment.UserName + "_" + today.Date.ToString("MM_dd_yyyy") + "_" + index.ToString();
            }
            revisionID = IDValue;
            modified = true;
        }
        #region RevisionAttachments
        /// <summary>
        /// Kolekcija dokumenata koji dolaze uz određenu reviziju.
        /// </summary>
        public HashSet<string> Attachments { get; set; } = new HashSet<string>();
        #endregion
        #region RevisionDocuments
        /// <summary>
        /// Odabrani dokumenti kod kreiranja nove nove revizije.
        /// </summary>
        private Dictionary<string, string[]> revisionDocuments = new Dictionary<string, string[]>(); //key -> DocumentClass_key; value -> RevisionDocument Info
        /// <summary>
        /// Add Document to revision and define its solved status.
        /// </summary>
        /// <param name="DocumentKey">Ključ dokumenta</param>
        /// <param name="rD_Info">      
        /// 0 - izvorno odabran dokument u reviziji - unsolved revision <br/>
        /// 1 - dokument iste/slične nomenklature - unsolved revision <br/>
        /// 2 - dokument roditelj koji postaje zastarjeli usljed ove revizije <br/>
        /// 3 - izvorno odabran dokument u reviziji - solved revision <br/>
        /// 4 - dokument iste/slične nomenklature - solved revision <br/>
        /// string[2]::  <br/> 
        /// 0 - [0-1-2-3-4] gornji opis  <br/>
        /// 1 - solvedVersion - verzija u koju je prešao dokument kad je revizija riješena <br/>
        /// 2 - oldVersion - verzija dokumenta kad je dodan u reviziju <br/>
        public void AddRevisionDocument(string DocumentKey, string[] rD_Info)
        {
            if (!revisionDocuments.ContainsKey(DocumentKey))
            {
                revisionDocuments.Add(DocumentKey, rD_Info);
                modified = true;
            }
        }
        public void ModifyRevisionDocument(string DocumentKey, string[] rD_Info)
        {
            revisionDocuments[DocumentKey] = rD_Info;
            modified = true;
        }
        public void RemoveRevisionDocument(string key)
        {
            revisionDocuments.Remove(key);
            modified = true;
        }
        public void ClearRevisionDocuments()
        {
            revisionDocuments.Clear();
            modified = true;
        }
        public IReadOnlyDictionary<string, string[]> RevisionDocuments => revisionDocuments;
        #endregion
        public void BuildRevisionClass(RevisionClassRAW RawClass)
        {
            revisionID = RawClass.RevisionID;
            importanceLvl = 0;
            if (RawClass.Comment != "" && RawClass.Comment != null) comment = RawClass.Comment;
            revisionDocuments = RawClass.RevisionDocuments.ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
