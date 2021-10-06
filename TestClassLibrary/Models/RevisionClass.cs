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
                if(revisionDocuments.Values.Min() < 2 ) return false;
                return true;
            }}
        private string comment;
        public string Comment { 
            get { return comment; } 
            set { comment = value; modified = true; } }
        private int importanceLvl;
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
        #region RevisionPics
        /// <summary>
        /// Kolekcija slika određene revizije.
        /// </summary>
        public HashSet<string> RevisionPics { get; set; }
        #endregion
        #region RevisionDocuments
        /// <summary>
        /// Odabrani dokumenti kod kreiranja nove nove revizije.
        /// </summary>
        private Dictionary<string, long> revisionDocuments = new Dictionary<string, long>(); //key -> DocumentClass_key; value -> RevisionDocument Info
        /// <summary>
        /// Add Document to revision and define its solved status.
        /// </summary>
        /// <param name="DocumentKey">Ključ dokumenta</param>
        /// <param name="rD_Info">      
        /// 0 - izvorno odabran dokument u reviziji - unsolved revision <br/>
        /// 1 - dokument iste/slične nomenklature - unsolved revision <br/>
        /// 3 - izvorno odabran dokument u reviziji - solved revision <br/>
        /// 4 - dokument iste/slične nomenklature - solved revision <br/>
        public void AddRevisionDocument(string DocumentKey, long rD_Info)
        {
            if (!revisionDocuments.ContainsKey(DocumentKey))
            {
                revisionDocuments.Add(DocumentKey, rD_Info);
                modified = true;
            }
        }
        public void ModifyRevisionDocument(string DocumentKey, long rD_Info)
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
        public IReadOnlyDictionary<string, long> RevisionDocuments => revisionDocuments;
        #endregion
        public void BuildRevisionClass(RevisionClassRAW RawClass)
        {
            revisionID = RawClass.RevisionID;
            revisionDocuments = RawClass.RevisionDocuments.ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
