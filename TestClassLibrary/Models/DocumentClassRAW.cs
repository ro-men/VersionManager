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
    public class DocumentClassRAW
    {
        public void FillDCR(DocumentClass oDocumentClass) {
            this.Children = oDocumentClass.ChildrenDict.Keys.ToList();
            this.Parents = oDocumentClass.ParentsDict.Keys.ToList();
            oDocumentClass.RevisionDict.ToList().ForEach(x => Revisions.Add(x));
            this.Key = oDocumentClass.Key;
            this.Nomenclture = oDocumentClass.NewNomenclature;
            this.libraryTime = oDocumentClass.DataBaseFileDate;
        }
        public List<string> Children { get; set; }
        public List<string> Parents { get; set; }
        public List<KeyValuePair<string, long>> Revisions { get; set; } = new List<KeyValuePair<string, long>>();
        public String Key { get; set; }
        public String Nomenclture { get; set; }
        public DateTime libraryTime { get; set; }
    }
}
