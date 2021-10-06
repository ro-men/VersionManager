using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;

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
            Dictionary<string, DocumentClass> documentDictionary = await VMLCoordinator.InitialDictionaryUpdate();
            SetupTree(documentDictionary);
            SetupList(documentDictionary);
            treeListView_Stablo.RebuildAll(true);
        }

        private void SetupList(Dictionary<string, DocumentClass> documentDictionary)
        {
            FOLV_LibraryLista.SetObjects(documentDictionary.Values);
            clmn_Lista_Status.GroupKeyGetter = delegate (object rowObject) {
                DocumentClass document = (DocumentClass)rowObject;
                return document.Status;
            };

            clmn_Lista_Status.GroupFormatter = delegate (OLVGroup group, GroupingParameters parms)
            {
                switch (group.Key.ToString())
                {
                    case "":
                        group.TitleImage = -1;
                        group.Subtitle = "Up to date. Everything is ok.";
                        break;
                    case "New":
                        group.TitleImage = 0;
                        group.Subtitle = "Needs to be stored in library and uploaded.";
                        break;
                    case "Missing Database Input":
                        group.TitleImage = 1;
                        group.Subtitle = "Solve this problem please.";
                        break;
                    case "Obsolete version":
                        group.TitleImage = 2;
                        group.Subtitle = "Must update.";
                        break;
                    default:
                        group.TitleImage = 3;
                        group.Subtitle = "User didn't upload documents.";
                        break;
                }

            };
            FOLV_LibraryLista.ShowGroups = true;
            FOLV_LibraryLista.Sort(clmn_Lista_Status);
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
                    if (((DocumentClass)x).RevisionDict.Values.Min() < 2)
                    {
                        return 1;
                    }
                    else if (((DocumentClass)x).RevisionDict.Values.Contains(2))
                    {
                        return 2;
                    }
                    else { return 0;}
                }
            };
        }

        private readonly List<DocumentClass> selectedItems = new List<DocumentClass>();
        private void Library_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selectedItems.Clear();
                ObjectListView objectListView = (ObjectListView)sender;
                if (IsControlAtFront((Control)sender))
                {
                    foreach (DocumentClass documentClass in objectListView.SelectedObjects)
                    {
                        selectedItems.Add(documentClass);
                    }
                }
                if (selectedItems.Count != 0 && selectedItems.Where(x => !x.Status.Contains("Missing server file")).Count() == 0)
                {
                    if (selectedItems.Where(x => !x.InSession).Count() == 0)
                    {
                        contextMenuStrip_MissingServerFile.Items[0].Enabled = false;
                        contextMenuStrip_MissingServerFile.Items[1].Enabled = true;
                    }
                    else
                    {
                        contextMenuStrip_MissingServerFile.Items[0].Enabled = true;
                        contextMenuStrip_MissingServerFile.Items[1].Enabled = false;
                    }
                    contextMenuStrip_MissingServerFile.Show(Cursor.Position);
                }
                if (selectedItems.Count != 0 && selectedItems.Where(x => !x.Status.Contains("Missing Database Input")).Count() == 0)
                {
                    contextMenuStrip_MissingDataBaseInput.Show(Cursor.Position);
                }
                //if (selectedItems.Count != 0 && selectedItems.Where(x => x.Status != "New").Count() == 0) contextMenuStrip_New.Show(Cursor.Position);
            }
        }
        private bool IsControlAtFront(Control control)
        {
            return control.Parent.Controls.GetChildIndex(control) == 0;
        }


        private void TabStoredLibrary_Enter(object sender, EventArgs e)
        {
            treeListView_Stablo.Update();
        }

        private void checkBox_DisplayAsList_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DisplayAsList.Checked)
            {
                FOLV_LibraryLista.RebuildColumns();
                FOLV_LibraryLista.BringToFront();
            }
            else
            {
                treeListView_Stablo.BringToFront();
            }
        }

        #region contextMenuStrip_MissingServerFile

        private void deleteFromVMLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VMLCoordinator.RemoveSelectionFromLibrary(selectedItems);
            VMLCoordinator.StoreDocumentClassesDict();
            VMLCoordinator.StoreRevisionDict();
            FOLV_LibraryLista.RemoveObjects(selectedItems);
            treeListView_Stablo.RemoveObjects(selectedItems);
        }

        private void openAndContinueInSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckExistance(selectedItems))
            {
                VMLCoordinator.ReadList(selectedItems);
                switchTabCallBack(0);
            }
            else
            {
                MessageBox.Show("Unable to open selection. Some of the documents selected in list do not exist on your local disc.", "Unable to upload.", MessageBoxButtons.OK);
            }
        }

        private void continueInSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchTabCallBack(0);
        }
        #endregion

        public VersionManagerForm.SwitchTab switchTabCallBack;
        private bool CheckExistance(List<DocumentClass> itemsToCheck) 
        {
            if (itemsToCheck.Where(x => !File.Exists(VMLCoordinator.localCore + x.Key)).Count() == 0) return true;
            return false;         
        }

        private void Register_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterMissingDataBaseInput registerMissingDataBaseInput = new RegisterMissingDataBaseInput();
            registerMissingDataBaseInput.Show();
            registerMissingDataBaseInput.SetupForm(selectedItems);
        }
    }

}
