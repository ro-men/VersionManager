using System;
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
        public Dictionary<string, DocumentClass> ChildrenDict = new Dictionary<string, DocumentClass>();
        public Dictionary<string, DocumentClass> ParentsDict = new Dictionary<string, DocumentClass>();
        public Dictionary<string, long> ErrorsDict = new Dictionary<string, long>(); //key[string] => ErrorID; value[long] => ErrorLevel /0 - file from original selection; 1 - this file is also edited(same type or nomenclature as origin); 2 - parent or child of edited file 
        public DateTime DataBaseFileDate { get; set; }
        public DateTime ActualFileDate { get { return new FileInfo(FullName).LastWriteTime; } }
        public string Nomenclature { get; set; }
        public Boolean Used { get { return this.ParentsDict.Count != 0; } }
        public Boolean HasChindren { get { return this.ChildrenDict.Count != 0; } }
        public Boolean DocumentClassModified { get; set; }
        public String PartName { get { return Path.GetFileName(this.FullName); } }
        public String FullName { get; set; }

        public void AdChild(DocumentClass documentClassInstance)
        {
            if (!ChildrenDict.ContainsKey(documentClassInstance.FullName))
            {
                this.ChildrenDict.Add(documentClassInstance.FullName, documentClassInstance);
            }
        }
        public void AdParent(DocumentClass documentClassInstance)
        {
            if (!ParentsDict.ContainsKey(documentClassInstance.FullName))
            {
                this.ParentsDict.Add(documentClassInstance.FullName, documentClassInstance);
            }
        }
    }
}