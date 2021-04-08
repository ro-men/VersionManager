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

namespace VerManagerLibrary
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
                SetupTree();
            }
        }
        #region Treelistview delegatori
        //TreeListView osnovni delegatori:
        // 1. CanExpandGetter - Info da li cvor ima childrene?
        // 2. ChildrenGetter - children collection

        private void SetupTree()
        {
            Dictionary<string, DocumentClass> documentDictionary = VMLCoordinator.LibraryDocumentDictionary;
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
                    return new ArrayList(inst.ChildrenDict.Values);
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
    }

}
