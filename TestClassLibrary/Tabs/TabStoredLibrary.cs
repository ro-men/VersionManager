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

namespace VerManagerLibrary_ClassLib
{
    public partial class TabStoredLibrary : UserControl
    {
        public TabStoredLibrary()
        {
            InitializeComponent();
        }
        private void TabStoredLibrary_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                SetupColumns();
                SetupTree(VMLCoordinator.LibraryDocumentDictionary);
                UpdateTree();
            }
        }
        #region Treelistview delegatori
        //TreeListView osnovni delegatori:
        // 1. CanExpandGetter - Info da li cvor ima childrene?
        // 2. ChildrenGetter - children collection

        private void SetupTree(Dictionary<string, DocumentClass> documentDictionary)
        {
            treeListView_Stablo.CanExpandGetter = delegate (object x)
            {
                DocumentClass inst = (DocumentClass)x;
                return inst.HasChindren;
            };

            treeListView_Stablo.ChildrenGetter = delegate (object x)
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
                if (!di.Used)
                    roots.Add(di);
            }
            this.treeListView_Stablo.Roots = roots;

        }
        #endregion
        private async void UpdateTree()
        {
            Dictionary<string, DocumentClass> documentDictionary = await VMLCoordinator.InitialDictionariesUpdate();
            SetupTree(documentDictionary);
            if (VMLCoordinator.deletedFilesKeys.Count() != 0) { MessageBox.Show("Number of deleted documents during LibraryUpdate: "+ VMLCoordinator.deletedFilesKeys.Count(), "Library update.", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            VMLCoordinator.StoreDocumentClassesDict(VMLCoordinator.LibraryDocumentDictionary);
        }

        private void button_UpdateLibrary_Click(object sender, EventArgs e)
        {
            UpdateLibrary updateLibrary = new UpdateLibrary();
            updateLibrary.Show();
        }
        private void SetupColumns()
        {
            this.clmn_PartName.ImageGetter = delegate (object x)
            {
                if (((DocumentClass)x).RevisionDict.Count() == 0)
                {
                    return 0;
                }
                else
                {
                    if (((DocumentClass)x).RevisionDict.Values.Contains(0) | ((DocumentClass)x).RevisionDict.Values.Contains(2))
                    {
                        return 2;
                    }
                    else if (((DocumentClass)x).RevisionDict.Values.Contains(4))
                    {
                        return 1;
                    }
                    else { return 0;}
                }
            };
        }
    }

}
