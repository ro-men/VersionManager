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
        }

        private void FDLV_RevisionsList_SelectionChanged(object sender, EventArgs e)
        {
            if ((RevisionClass)FDLV_RevisionsList.SelectedObject != null) {
                RevisionClass revisionClass = (RevisionClass)FDLV_RevisionsList.SelectedObject;
                DLV_ItemsList.SetObjects(revisionClass.RevisionDocuments.Where(kvp => kvp.Value != 2));
            }
        }
        private void Setup_DLV_ItemsList()
        {
            DLV_Items_RevisionSolved.AspectGetter = delegate (object x) {
                if(((KeyValuePair<string, long>)x).Value < 2) return false;
                return true;
            };
            DLV_Items_Level.AspectGetter = delegate (object x) {
                if (((KeyValuePair<string, long>)x).Value == 0 || ((KeyValuePair<string, long>)x).Value == 3) return "Core Element";
                return "Other Object";
            };
        }

        private void FDLV_RevisionsList_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {
            if (FDLV_RevisionsList.SelectedObject != null) contextMenu_RightClick.Show(this.PointToScreen(e.Location));
        }
        private void StartRevisionEdit(object sender, EventArgs e) {

            var newForm = new RevisionForm();
            newForm.FormInput((RevisionClass)FDLV_RevisionsList.SelectedObject, VMLCoordinator.LibraryDocumentDictionary);
            newForm.revisionStored = new RevisionForm.RevisionStored(this.RevisionStoredCallbackFn);
            newForm.Visible = true;
            newForm.checkBox_FilterLibrary.Checked = true;
        }
        private void RevisionStoredCallbackFn(string key)
        {
            RevisionClass revisionClass = VMLCoordinator.RevisionDictionary[key];
            FDLV_RevisionsList.SelectObject(revisionClass, true);
            DLV_ItemsList.SetObjects(revisionClass.RevisionDocuments.Where(kvp => kvp.Value != 2));
            FDLV_RevisionsList.UpdateObject(revisionClass);
        }
        private void DeleteRevision(object sender, EventArgs e) {
            RevisionClass revisionClass = (RevisionClass)FDLV_RevisionsList.SelectedObject;
            foreach(string key in revisionClass.RevisionDocuments.Keys)
            {
                if (VMLCoordinator.LibraryDocumentDictionary.ContainsKey(key))
                {
                    DocumentClass documentClass = VMLCoordinator.LibraryDocumentDictionary[key];
                    documentClass.RemoveRevision(revisionClass.RevisionID);
                }
            }
            VMLCoordinator.StoreDocumentClassesDict();
            VMLCoordinator.RevisionDictionary.Remove(revisionClass.RevisionID);
            VMLCoordinator.StoreRevisionDict();
            FDLV_RevisionsList.RemoveObject(FDLV_RevisionsList.SelectedObject);
            DLV_ItemsList.Clear();
        }
    }
}
