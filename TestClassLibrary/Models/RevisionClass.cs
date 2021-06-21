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
        public bool SolvedStatus { get { return Convert.ToBoolean(coreDocuments.Values.Where(x => x % 2 == 0).Count()) && Convert.ToBoolean(otherDocuments.Values.Where(x => x % 2 == 0).Count()/ otherDocuments.Values.Where(x => x % 2 == 0).Count()); } }
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
        private Dictionary<string, long> coreDocuments = new Dictionary<string, long>(); //key -> DocumentClass_key; value -> RevisionDocument Info
        /// <summary>
        /// Add "Core document" to revision and define its solved status.
        /// </summary>
        /// <param name="DocumentKey"></param>
        /// <param name="rD_Info"></param>
        public void AddCoreDocument(string DocumentKey, long rD_Info)
        {
            if (!coreDocuments.ContainsKey(DocumentKey))
            {
                coreDocuments.Add(DocumentKey, rD_Info);
            }
        }
        public void ModifyCoreDocument(string DocumentKey, long rD_Info)
        {
            coreDocuments[DocumentKey] = rD_Info;
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
        public IReadOnlyDictionary<string, long> CoreDocuments => coreDocuments;
        #endregion
        #region OtherDocuments
        /// <summary>
        /// Dokumenti identične nomenklature ili tipa koji sadrže istu potrebu za promjenom.
        /// </summary>
        private Dictionary<string, long> otherDocuments = new Dictionary<string, long>(); //key -> DocumentClass_key;  value -> RevisionDocument Info
        /// <summary>
        /// Add other documents to revision and define its solved status.
        /// </summary>
        /// <param name="DocumentKey"></param>
        /// <param name="rD_Info"></param>
        public void AddOtherDocument(string DocumentKey, long rD_Info)
        {
            if (!otherDocuments.ContainsKey(DocumentKey))
            {
               otherDocuments.Add(DocumentKey, rD_Info);
            }
        }
        public void ModifyOtherDocument(string DocumentKey, long rD_Info)
        {
            otherDocuments[DocumentKey]= rD_Info;
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
        public IReadOnlyDictionary<string, long> OtherDocuments => otherDocuments;
        #endregion
        #region Siblings
        /// <summary>
        /// Dokumenti koju su izravno povezani rodoslovnim stablom sa "EditedDocuments" te su kao takvi zastarjeli usljed potrebe za promjenom.
        /// </summary>
        private Dictionary<string, long> siblings = new Dictionary<string, long>(); //key -> DocumentClass_key; value -> RevisionDocument Info
        /// <summary>
        /// Add sibling documents to revision and define its solved status.
        /// Dokumenti koju su izravno povezani rodoslovnim stablom sa "EditedDocuments" te su kao takvi zastarjeli usljed potrebe za promjenom
        /// </summary>
        /// <param name="DocumentKey"></param>
        /// <param name="rD_Info"></param>
        public void AddSibling(string DocumentKey, long rD_Info)
        {
            if (!siblings.ContainsKey(DocumentKey))
            {
                siblings.Add(DocumentKey, rD_Info);
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
        public IReadOnlyDictionary<string,long> Siblings => siblings;
        #endregion

        public void BuildRevisionClass(RevisionClassRAW RawClass)
        {
            revisionID = RawClass.RevisionID;
            coreDocuments = RawClass.CoreDocuments.ToDictionary(x => x.Key, x => x.Value);
            otherDocuments = RawClass.OtherDocuments.ToDictionary(x => x.Key, x => x.Value);
            siblings = RawClass.Siblings.ToDictionary(x => x.Key, x => x.Value);
        }
    }
    /// <summary>
    /// Klasa koja sadrži informacije o dokumentu koji se nalazi u reviziji
    /// info: Level + SolvedStatus
    /// </summary>
}
