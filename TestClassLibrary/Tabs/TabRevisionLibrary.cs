using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerManagerLibrary
{
    public partial class TabRevisionLibrary : UserControl
    {
        public TabRevisionLibrary()
        {
            InitializeComponent();
        }

        private void TabRevisionLibrary_Load(object sender, EventArgs e)
        {
            Setup_FDLV_RevisionsList();
        }

        private void Setup_FDLV_RevisionsList() 
        {
            FDLV_RevisionsList.SetObjects(VMLCoordinator.RevisionDictionary.Values);
        }

        private void FDLV_RevisionsList_SelectionChanged(object sender, EventArgs e)
        {
            if ((RevisionClass)FDLV_RevisionsList.SelectedObject != null) {
                RevisionClass revisionClass = (RevisionClass)FDLV_RevisionsList.SelectedObject;
                Setup_DLV_ItemsList(revisionClass);
                DLV_ItemsList.SetObjects(revisionClass.CoreDocuments.Union(revisionClass.OtherDocuments));
            }
        }
        private void Setup_DLV_ItemsList(RevisionClass revisionClas)
        {
            DLV_Items_Level.AspectGetter = delegate (object x) {
                if (revisionClas.CoreDocuments.ContainsKey(((KeyValuePair<string,bool>)x).Key)) {
                    return "Core Element";
                }
                return "Other Object";
            
            };
        }
    }
}
