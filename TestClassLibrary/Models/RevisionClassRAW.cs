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
            oRevision.RevisionDocuments.ToList().ForEach(x =>
            {
                List<KeyValuePair<string, string[]>> R_Documents = new List<KeyValuePair<string, string[]>>();
                string[] newValue = { x.Value.RD_Value.ToString(), x.Value.OldVersion, x.Value.NewVersion };
                RevisionDocuments.Add(new KeyValuePair<string, string[]>(x.Key, newValue));
            });
            }
            public string RevisionID { get; set; }
            public int ImportanceLevel { get; set; }
            public string Comment { get; set; }
        public List<KeyValuePair<string, string[]>> RevisionDocuments { get; set; } = new List<KeyValuePair<string, string[]>>();
    }
}
