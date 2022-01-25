using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            FDLV_Importance_level.AspectGetter = delegate (object x)
            {
                RevisionClass revision = (RevisionClass)x;
                if (revision.ImportanceLvl == 0) return "High";
                else if (revision.ImportanceLvl == 1) return "Medium";
                return "Low";
            };
            FDLV_RevisionsList.SetObjects(VMLCoordinator.RevisionDictionary.Values);
        }
        private void FDLV_RevisionsList_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            RevisionClass x = (RevisionClass)e.Model;
            if (x.SolvedStatus)
            {
                e.Item.BackColor = Color.LightGreen;
            }
            else
            {
                e.Item.BackColor = Color.LightPink;
            }
        }
        private void FDLV_RevisionsList_SelectionChanged(object sender, EventArgs e)
        {
            if ((RevisionClass)FDLV_RevisionsList.SelectedObject != null) {
                RevisionClass revisionClass = (RevisionClass)FDLV_RevisionsList.SelectedObject;
                DLV_ItemsList.SetObjects(revisionClass.RevisionDocuments.Where(kvp => kvp.Value.RD_Value != 2));
                textBoxComent.Text = revisionClass.Comment;
            }
        }
        private void Setup_DLV_ItemsList()
        {
            DLV_Items_PartName.AspectGetter = delegate (object x) {
                return Path.GetFileName(((KeyValuePair<string, RevisionClass.DocInfo>)x).Key);
            };
            DLV_Items_Path.AspectGetter = delegate (object x) {
                return Path.GetDirectoryName(((KeyValuePair<string, RevisionClass.DocInfo>)x).Key);
            };
            DLV_Items_RevisionSolved.AspectGetter = delegate (object x) {
                if(((KeyValuePair<string, RevisionClass.DocInfo>)x).Value.RD_Value < 2) return false;
                return true;
            };
            DLV_Items_NewVer.AspectGetter = delegate (object x) {
                return ((KeyValuePair<string, RevisionClass.DocInfo>)x).Value.NewVersion;
            };
            DLV_Items_OldVer.AspectGetter = delegate (object x) {
                return ((KeyValuePair<string, RevisionClass.DocInfo>)x).Value.OldVersion;
            };
        }
        private void DLV_ItemsList_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            KeyValuePair<string, RevisionClass.DocInfo> x = (KeyValuePair<string, RevisionClass.DocInfo>)e.Model;
            if (x.Value.RD_Value > 2)
            {
                e.Item.BackColor = Color.LightGreen;
            }
            else
            {
                e.Item.BackColor = Color.LightPink;
            }
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
            DLV_ItemsList.SetObjects(revision.RevisionDocuments.Where(kvp => kvp.Value.RD_Value != 2));
            textBoxComent.Text = revision.Comment;
            textBoxComent.Update();
        }
        private void DeleteRevision(object sender, EventArgs e) {
            RevisionClass revisionClass = (RevisionClass)FDLV_RevisionsList.SelectedObject;
            Dictionary<string, DocumentClass> toDelete = new Dictionary<string, DocumentClass>();
            foreach(string key in revisionClass.RevisionDocuments.Keys)
            {
                if (VMLCoordinator.DocumentDictionary.ContainsKey(key))
                {
                    DocumentClass documentClass = VMLCoordinator.DocumentDictionary[key];
                    documentClass.RemoveRevision(revisionClass.RevisionID);
                    toDelete.Add(key, documentClass);
                }
            }
            VMLCoordinator.StoreDocumentClassesDict(toDelete);
            VMLCoordinator.RevisionDictionary.Remove(revisionClass.RevisionID);
            VMLCoordinator.StoreRevisionDict();
            FDLV_RevisionsList.RemoveObject(FDLV_RevisionsList.SelectedObject);
            DLV_ItemsList.ClearObjects();
        }
    }
}
