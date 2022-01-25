using System;
using System.Collections.Generic;
using System.Linq;


namespace VerManagerLibrary_ClassLib
{
    public class DocumentClassRAW
    {
        public void FillDCR(DocumentClass oDocumentClass)
        {
            Children = oDocumentClass.ChildrenDict.Keys.ToList();
            Parents = oDocumentClass.ParentsDict.Keys.ToList();
            Key = oDocumentClass.Key;
            Nomenclture = oDocumentClass.LocalNomenclature;
            Version = oDocumentClass.LocalVersion;
        }
        public List<string> Children { get; set; }
        public List<string> Parents { get; set; }
        public String Key { get; set; }
        public String Version { get; set; }
        public String Nomenclture { get; set; }
    }
}
