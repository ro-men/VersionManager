using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INFITF;


namespace TestClassLibrary
{
    class ClassDocument
    {
        public Document Odoc { get; set; }
        public Boolean used { get; set; }
        public Dictionary<string, Document> docDict = new Dictionary<string, Document>();

        public ClassDocument(Document oDocument, Boolean _used = false)
        {
            this.Odoc = oDocument;
            this.used = _used;
        }

        public void AdChild(Document oDocument)
        {
            if (!docDict.ContainsKey(oDocument.FullName))
            {
                docDict.Add(oDocument.FullName, oDocument);
            }
        }

    }
}
