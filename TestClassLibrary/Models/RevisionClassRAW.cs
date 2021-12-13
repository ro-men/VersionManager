using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerManagerLibrary_ClassLib
{
    public class RevisionClassRAW
    {
        /// <summary>
        /// json compatible class
        /// </summary>
            public void FillRCL(RevisionClass oRevision)
            {
                RevisionID = oRevision.RevisionID;
                ImportanceLevel = oRevision.ImportanceLvl;
                Comment = oRevision.Comment;
                RevisionDocuments = oRevision.RevisionDocuments.ToList();
            }
            public string RevisionID { get; set; }
            public int ImportanceLevel { get; set; }
            public string Comment { get; set; }
            public List<KeyValuePair<string, string[]>> RevisionDocuments { get; set; }
    }
}
