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
            this.Errors = oDocumentClass.ErrorsDict.Keys.ToList();
            this.FullName = oDocumentClass.FullName;
            this.libraryTime = oDocumentClass.DataBaseFileDate;
        }
        public List<string> Children { get; set; }
        public List<string> Parents { get; set; }
        public List<string> Errors { get; set; }
        public String FullName { get; set; }
        public DateTime libraryTime { get; set; }
    }
}
