using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerManagerLibrary_ClassLib
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
            Setup_DLV_ItemsList();
        }
        private void Setup_FDLV_RevisionsList() 
        {
            FDLV_RevisionsList.SetObjects(VMLCoordinator.RevisionDictionary.Values);
            FDLV_Importance_level.AspectGetter = delegate (object x)
            {
                RevisionClass revision = (RevisionClass)x;
                if (revision.ImportanceLvl == 0) return "High";
                else if (revision.ImportanceLvl == 1) return "Medium";
                return "Low";
            };
        }
        private void FDLV_RevisionsList_SelectionChanged(object sender, EventArgs e)
        {
            if ((RevisionClass)FDLV_RevisionsList.SelectedObject != null) {
                RevisionClass revisionClass = (RevisionClass)FDLV_RevisionsList.SelectedObject;
                DLV_ItemsList.SetObjects(revisionClass.RevisionDocuments.Where(kvp => kvp.Value[0] != "2"));
                textBoxComent.Text = revisionClass.Comment;
            }
        }
        private void Setup_DLV_ItemsList()
        {
            DLV_Items_RevisionSolved.AspectGetter = delegate (object x) {
                if(Int32.Parse(((KeyValuePair<string, string[]>)x).Value[0]) < 2) return false;
                return true;
            };
            DLV_Items_Level.AspectGetter = delegate (object x) {
                if (((KeyValuePair<string, string[]>)x).Value[0] == "0" || ((KeyValuePair<string, string[]>)x).Value[0] == "3") return "Core Element";
                return "Other Object";
            };
        }
        private void FDLV_RevisionsList_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {
            if (FDLV_RevisionsList.SelectedObject != null) contextMenu_RightClick.Show(this.PointToScreen(e.Location));
        }
        private void StartRevisionEdit(object sender, EventArgs e) {

            var newForm = new RevisionForm();
            newForm.FormInput((RevisionClass)FDLV_RevisionsList.SelectedObject, VMLCoordinator.DocumentDictionary);
            newForm.Visible = true;
            newForm.RevisionObjectDelegate = new RevisionObjectDelegate(RevisionModified);
            newForm.checkBox_FilterLibrary.Checked = true;
        }
        private void RevisionModified(RevisionClass revision)
        {
            FDLV_RevisionsList.UpdateObject(revision);
            FDLV_RevisionsList.SelectObject(revision, true);
            DLV_ItemsList.SetObjects(revision.RevisionDocuments.Where(kvp => kvp.Value[0] != "2"));
            textBoxComent.Text = revision.Comment;
            textBoxComent.Update();
        }
        private void DeleteRevision(object sender, EventArgs e) {
            RevisionClass revisionClass = (RevisionClass)FDLV_RevisionsList.SelectedObject;
            foreach(string key in revisionClass.RevisionDocuments.Keys)
            {
                if (VMLCoordinator.DocumentDictionary.ContainsKey(key))
                {
                    DocumentClass documentClass = VMLCoordinator.DocumentDictionary[key];
                    documentClass.RemoveRevision(revisionClass.RevisionID);
                }
            }
            VMLCoordinator.StoreDocumentClassesDict();
            VMLCoordinator.RevisionDictionary.Remove(revisionClass.RevisionID);
            VMLCoordinator.StoreRevisionDict();
            FDLV_RevisionsList.RemoveObject(FDLV_RevisionsList.SelectedObject);
            DLV_ItemsList.ClearObjects();
        }
    }
}
