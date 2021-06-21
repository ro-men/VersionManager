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
                Comment = oRevision.Comment;
                CoreDocuments = oRevision.CoreDocuments.ToList();
                OtherDocuments = oRevision.OtherDocuments.ToList();
                Siblings = oRevision.Siblings.ToList();
            }
            public string RevisionID { get; set; }
            public string Comment { get; set; }
            public List<KeyValuePair<string, long>> CoreDocuments { get; set; }
            public List<KeyValuePair<string, long>> OtherDocuments { get; set; }
            public List<KeyValuePair<string, long>> Siblings { get; set; }

    }
}
