using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using System.Text.Json;
using System.IO;

namespace VerManagerLibrary_ClassLib
{
    public partial class TabInSessionDocs : UserControl
    {
        public TabInSessionDocs()
        {
            InitializeComponent();
        }

        #region Treelistview delegatori
        //TreeListView osnovni delegatori:
        // 1. CanExpandGetter - Info da li cvor ima childrene?
        // 2. ChildrenGetter - children collection

        private void SetupTree(Dictionary<string, DocumentClass> documentDictionary)
        {
            this.treeListView_Stablo.CanExpandGetter = delegate (object x)
            {
                DocumentClass inst = (DocumentClass)x;
                return inst.HasChindren;
            };

            this.treeListView_Stablo.ChildrenGetter = delegate (object x)
            {
                try
                {
                    DocumentClass inst = (DocumentClass)x;
                    return new ArrayList(inst.ChildrenDict.Values.ToArray());
                }
                catch (UnauthorizedAccessException ex)
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.treeListView_Stablo.Collapse(x);
                        MessageBox.Show(this, ex.Message, "Unable to fetch items.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    });
                    return new ArrayList();
                }
            };

            // Definicija osnovnih cvorova
            ArrayList roots = new ArrayList();
                foreach (DocumentClass di in documentDictionary.Values)
                {
                    if ((di.InSession) && (!di.Used) | (di.ParentsDict.Values.Where(x => x.InSession).Count() == 0))
                        roots.Add(di);
                }
                this.treeListView_Stablo.Roots = roots;
        }

        private async void UpdateTree()
        {
            Dictionary<string, DocumentClass> documentDictionary = await VMLCoordinator.CollectInSessionDocuments();
            SetupTree(documentDictionary);
        }

        private void TabInSessionDocs_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                SetupTree(VMLCoordinator.LibraryDocumentDictionary);
                UpdateTree();
            }
        }

        #endregion


        #region EventHandlers

        private void buttonNewError_Click(object sender, EventArgs e)
        {
            if (this.treeListView_Stablo.SelectedIndices.Count != 0) {

                IList selectedItems = this.treeListView_Stablo.SelectedObjects;
                var newForm = new VerManagerLibrary_ClassLib.FormCreateRevision(selectedItems);
                newForm.Visible = true;
        }}

        private void saveLibrary(object sender, EventArgs e)
        {
            VMLCoordinator.StoreDocumentClassesDict(VMLCoordinator.LibraryDocumentDictionary);
        }
        private void treeListView_Stablo_FormatRow(object sender, FormatRowEventArgs e)
        {
            DocumentClass documentClass = (DocumentClass)e.Model;
            if (documentClass.NewNomenclature != documentClass.OldNomenclature)
                e.Item.BackColor = Color.Red;
        }

        #endregion


    }
}
