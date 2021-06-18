﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INFITF;
using System.IO;

namespace VerManagerLibrary
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
            parentsDict.Remove(key); 
            modified = true;
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
        /// Key:<br/> 
        /// ID revizije<para/>
        /// </summary>
        /// <returns>
        /// 0 - izvorno odabran dokument u reviziji - unsolved revision <br/>
        /// 1 - izvorno odabran dokument u reviziji - solved revision <br/>
        /// 2 - dokument iste/slične nomenklature - unsolved revision <br/>
        /// 3 - dokument iste/slične nomenklature - solved revision <br/>
        /// 4 - dokument roditelj koji postaje zastarjeli usljed ove revizije <br/>
        /// </returns>
        private Dictionary<string, long> revisionDict = new Dictionary<string, long>();
        /// <summary>
        /// Add a new Revision to dictionary::
        /// </summary>
        /// <param name="RevisionID">[Key] -> RevisionID</param>
        /// <param name="RevisionLevel"> <para/>    
        /// 0 - izvorno odabran dokument u reviziji - unsolved revision <br/>
        /// 1 - izvorno odabran dokument u reviziji - solved revision <br/>
        /// 2 - dokument iste/slične nomenklature - unsolved revision <br/>
        /// 3 - dokument iste/slične nomenklature - solved revision <br/>
        /// 4 - dokument roditelj koji postaje zastarjeli usljed ove revizije <br/>
        public void AddRevision(string RevisionID, long RevisionLevel)
        {
            if (!revisionDict.ContainsKey(RevisionID))
            {
                revisionDict.Add(RevisionID, RevisionLevel);
                modified = true;
            }
            else if (revisionDict[RevisionID] > RevisionLevel)
            {
                revisionDict[RevisionID] = RevisionLevel;
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
        public IReadOnlyDictionary<string, long> RevisionDict => revisionDict;
        #endregion
        private DateTime dataBaseFileDate;
        public DateTime DataBaseFileDate { 
            get { return dataBaseFileDate; } 
            set { dataBaseFileDate = value; modified = true; }}
        public DateTime LocalFileDate { get { return new FileInfo(VMLCoordinator.localCore + key).LastWriteTime; } }
        public DateTime ServerFileDate { get { return new FileInfo(VMLCoordinator.serverCore + key).LastWriteTime; } }
        public string OldNomenclature { get; set; }
        private string newNomenclature;
        public string NewNomenclature { 
            get { return newNomenclature; } 
            set { newNomenclature = value; modified = true; } }
        public bool Used { get { return ParentsDict.Count != 0; } }
        public bool OnServer { get { return System.IO.File.Exists(VMLCoordinator.serverCore + key); } }
        public bool OnLocalDisc { get { return System.IO.File.Exists(VMLCoordinator.localCore + key); } }
        public bool InSession { get; set; }
        public bool CurentRevisionStatus { get; set; }
        public bool HasChindren { get { return childrenDict.Count != 0; } }

        private bool modified; 
        public bool Modified { get { return modified; } }
        public string PartName { get { return Path.GetFileName(key); } }
        private string key;
        public string Key { 
            get { return key;} 
            set { key = value; modified = true; } }
        /// <summary>
        /// Metoda koja izgradi "DocumentClass" instancu na temelju "sirove" instance koja je ucitana JsonSerializer-om.
        /// </summary>
        /// <param name="RawClass"></param>
        public void BuildDocumentClass(DocumentClassRAW RawClass) {
            key = RawClass.Key;
            dataBaseFileDate = RawClass.libraryTime;
            OldNomenclature = RawClass.Nomenclture;
            newNomenclature = RawClass.Nomenclture;
            if(RawClass.Revisions != null) RawClass.Revisions.ForEach(x => revisionDict.Add(x.Key, x.Value));
        }
        public void FillSiblings(DocumentClassRAW RawClass,Dictionary<string,DocumentClass> DCLibrary)
        {
            RawClass.Children.ForEach(i => childrenDict.Add(i,DCLibrary[i]));
            RawClass.Parents.ForEach(i => parentsDict.Add(i, DCLibrary[i]));
        }
    }
}