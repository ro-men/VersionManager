using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VerManagerLibrary
{   
    public class RevisionClass
    {
        private string revisionID;
        public string RevisionID { get { return revisionID; } }
        public bool SolvedStatus { get { return !coreDocuments.Values.Contains(false) && !otherDocuments.Values.Contains(false); } }
        private string comment;
        public string Comment { 
            get { return comment; } 
            set { comment = value; modified = true; } }
        private bool modified;
        public bool Modified { get { return modified; } }
        private static int RevisionIndex;
        public void CreateRevisionID()
        {
            DateTime today = DateTime.Today;
            RevisionIndex = FindIndex();
            string IDValue = Environment.UserName + "_" + today.Date.ToString("MM_dd_yyyy") + "_" + RevisionIndex.ToString();
            revisionID = IDValue;
            modified = true;
        }

        private static int FindIndex() {
            int index = VMLCoordinator.RevisionDictionary.Keys.ToList().Where(x =>
                x.Contains(Environment.UserName) && x.Contains(DateTime.Today.Date.ToString("MM_dd_yyyy"))).Count() + 1;
                
            return index;
        }
        #region CoreDocuments
        /// <summary>
        /// Izravno odabrani dokumenti kod kreiranja nove "greške".
        /// </summary>
        private Dictionary<string, bool> coreDocuments = new Dictionary<string, bool>(); //key -> DocumentClass_key; value -> STATUS: [True(Solved) // False(Unsolved)]
        /// <summary>
        /// Add "Core document" to revision and define its solved status.
        /// </summary>
        /// <param name="DocumentKey"></param>
        /// <param name="SolvedStatus"></param>
        public void AddCoreDocument(string DocumentKey, bool SolvedStatus)
        {
            if (!coreDocuments.ContainsKey(DocumentKey))
            {
                coreDocuments.Add(DocumentKey, SolvedStatus);
            }
        }
        public void ModifyCoreDocument(string DocumentKey, bool SolvedStatus)
        {
            coreDocuments[DocumentKey] = SolvedStatus;
            modified = true;
        }
        public void RemoveCoreDocument(string key)
        {
            coreDocuments.Remove(key);
            modified = true;
        }
        public void ClearCoreDocuments()
        {
            coreDocuments.Clear();
            modified = true;
        }
        public IReadOnlyDictionary<string, bool> CoreDocuments => coreDocuments;
        #endregion
        #region OtherDocuments
        /// <summary>
        /// Dokumenti identične nomenklature ili tipa koji sadrže istu potrebu za promjenom.
        /// </summary>
        private Dictionary<string, bool> otherDocuments = new Dictionary<string, bool>(); //key -> DocumentClass_key; value -> STATUS: [True(Solved) // False(Unsolved)]
        /// <summary>
        /// Add other documents to revision and define its solved status.
        /// </summary>
        /// <param name="DocumentKey"></param>
        /// <param name="SolvedStatus"></param>
        public void AddOtherDocument(string DocumentKey, bool SolvedStatus)
        {
            if (!otherDocuments.ContainsKey(DocumentKey))
            {
               otherDocuments.Add(DocumentKey, SolvedStatus);
            }
        }
        public void ModifyOtherDocument(string DocumentKey, bool SolvedStatus)
        {
            otherDocuments[DocumentKey]= SolvedStatus;
            modified = true;
        }
        public void RemoveOtherDocument(string key)
        {
            otherDocuments.Remove(key);
            modified = true;
        }
        public void ClearOtherDocuments()
        {
            otherDocuments.Clear();
            modified = true;
        }
        public IReadOnlyDictionary<string, bool> OtherDocuments => otherDocuments;
        #endregion
        #region Siblings
        /// <summary>
        /// Dokumenti koju su izravno povezani rodoslovnim stablom sa "EditedDocuments" te su kao takvi zastarjeli usljed potrebe za promjenom.
        /// </summary>
        private readonly HashSet<string> siblings = new HashSet<string>(); //key -> DocumentClass_key
        /// <summary>
        /// Add sibling documents to revision and define its solved status.
        /// Dokumenti koju su izravno povezani rodoslovnim stablom sa "EditedDocuments" te su kao takvi zastarjeli usljed potrebe za promjenom
        /// </summary>
        /// <param name="DocumentKey"></param>
        /// <param name="SolvedStatus"></param>
        public void AddSibling(string DocumentKey)
        {
            if (!siblings.Contains(DocumentKey))
            {
                siblings.Add(DocumentKey);
            }
        }
        public void RemoveSibling(string key)
        {
            siblings.Remove(key);
            modified = true;
        }
        public void ClearSiblings()
        {
            siblings.Clear();
            modified = true;
        }
        public IReadOnlyList<string> Siblings => siblings.ToList();
        #endregion

        public void BuildRevisionClass(RevisionRAW RawClass)
        {
            revisionID = RawClass.RevisionID;
            coreDocuments = RawClass.CoreDocuments.ToDictionary(x => x.Key, x => x.Value);
            otherDocuments = RawClass.OtherDocuments.ToDictionary(x => x.Key, x => x.Value);
            RawClass.Siblings.ForEach(x => siblings.Add(x));
        }
    }
}
