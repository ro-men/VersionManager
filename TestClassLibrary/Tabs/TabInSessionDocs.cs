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
using INFITF;
using ProductStructureTypeLib;
using PARTITF;
using MECMOD;
using KnowledgewareTypeLib;


namespace VerManagerLibrary_ClassLib
{
    public partial class TabInSessionDocs : UserControl
    {
        public TabInSessionDocs()
        {
            InitializeComponent();
        }
        private void TabInSessionDocs_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                treeListView_Stablo.BringToFront();
                UpdateTab();
            }
        }
        private async void UpdateTab()
        {
            Dictionary<string, DocumentClass> documentDictionary = await VMLCoordinator.CollectInSessionDocuments();
            SetupTree(documentDictionary);
            SetupList(documentDictionary);
        }
        #region Treelistview Setup
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
            clmn_Stablo_Modified.AspectGetter = delegate (object rowObject) {
                DocumentClass document = (DocumentClass)rowObject;
                if (document.Modified) return document.Modified;
                return "";
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

        private void treeListView_Stablo_FormatRow(object sender, FormatRowEventArgs e)
        {
            DocumentClass documentClass = (DocumentClass)e.Model;
            //if (documentClass.Modified)
                //e.Item.BackColor = Color.LightBlue;
        }
        #endregion

        private void SetupList(Dictionary<string, DocumentClass> documentDictionary)
        {
            OLV_InSessionLista.SetObjects(documentDictionary.Values.Where(x => x.InSession == true));
            clmn_Lista_Status.GroupKeyGetter = delegate (object rowObject) {
                DocumentClass document = (DocumentClass)rowObject;
                return document.Status;
            };
            clmn_Lista_Modified.AspectGetter = delegate (object rowObject) {
                DocumentClass document = (DocumentClass)rowObject;
                if (document.Modified) return document.Modified.ToString();
                return "";
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
                        group.Subtitle = "Ne znam kaj tu piše.";
                        break;
                    default:
                        group.TitleImage = 3;
                        group.Subtitle = "User didn't upload documents.";
                        break;
                }

            };
            OLV_InSessionLista.ShowGroups = true;
            OLV_InSessionLista.Sort(clmn_Lista_Status);
        }

        #region EventHandlers

        private void button_NewRevision_Click(object sender, EventArgs e)
        {
            if (this.treeListView_Stablo.SelectedIndices.Count != 0) {

                IList selectedItems = this.treeListView_Stablo.SelectedObjects;
                RevisionClass newRevision = new RevisionClass();
                newRevision.CreateRevisionID();
                foreach (DocumentClass documentClass in selectedItems) {
                    newRevision.AddRevisionDocument(documentClass.Key, 3);
                    documentClass.AddRevision(newRevision.RevisionID, 3);
                }

                var newForm = new RevisionForm();
                newForm.FormInput(newRevision, VMLCoordinator.LibraryDocumentDictionary);
                newForm.Visible = true;
            }
            else
            {
                MessageBox.Show("Da bi kreirali reviziju morate odabrati barem jedan dokument iz liste.", "Unable to create", MessageBoxButtons.OK);
            }
        }
        private void List_CellEditStarting(object sender, CellEditEventArgs e)
        {
            e.Control.Bounds = e.ListViewItem.GetSubItemBounds(e.SubItemIndex);
        }

        #endregion

        private void checkBox_DisplayAsList_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DisplayAsList.Checked)
            {
                OLV_InSessionLista.RebuildColumns();
                OLV_InSessionLista.BringToFront();
            }
            else
            {
                treeListView_Stablo.BringToFront();
            }
        }

        private readonly List<DocumentClass> selectedItems = new List<DocumentClass>();
        private void InSession_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selectedItems.Clear();
                ObjectListView objectListView = (ObjectListView)sender;
                if (IsControlAtFront((Control)sender)) 
                {
                    foreach(DocumentClass documentClass in objectListView.SelectedObjects)
                    {
                        selectedItems.Add(documentClass);
                    }
                }
                if (selectedItems.Count != 0 && selectedItems.Where(x => x.Status != "Missing Database Input").Count() == 0) contextMenuStrip_MissingDataBaseInput.Show(Cursor.Position);
                if (selectedItems.Count != 0 && selectedItems.Where(x => x.Status != "New" && x.Modified == false).Count() == 0)
                {
                    if (selectedItems.Count == 1) { copyPartNameToolStripMenuItem.Enabled = true; } else { copyPartNameToolStripMenuItem.Enabled = false; }
                    contextMenuStrip_New.Show(Cursor.Position);
                } 
            }
        }

        private bool IsControlAtFront(Control control)
        {
            return control.Parent.Controls.GetChildIndex(control) == 0;
        }

        #region contextMenuStrip_MissingDataBaseInput
        private void DeleteFromServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete selected \"Network\" documents?", "Delete documents...", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                selectedItems.ForEach(item =>
                {
                    string filePath = VMLCoordinator.serverCore + item.Key;
                    System.IO.File.Delete(filePath);
                    var entries = Directory.EnumerateFileSystemEntries(Path.GetDirectoryName(filePath));
                    if (!entries.Any())
                    {
                        try
                        {
                            Directory.Delete(Path.GetDirectoryName(filePath));
                        }
                        catch (UnauthorizedAccessException) { }
                        catch (DirectoryNotFoundException) { }
                    };
                });
                treeListView_Stablo.RebuildAll(true);
                OLV_InSessionLista.RebuildColumns();
            }
        }
        private void StoreLastVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //GOJCETA PROCEDURA KOJA ZA LISTU ADRESA PROVJERAVA DA LI JE UPLOAD MOGUĆ
            bool possibleUpload = true;

            selectedItems.ForEach(item => {
                DocumentClass documentClass = (DocumentClass)item;
                string versionUserName = documentClass.Version.Split('_').First();
                if (documentClass.LocalFileDate == documentClass.DataBaseFileDate) { 
                }
            });
        }
        #endregion

        #region contextMenuStrip_New
        private void StoreInVML_Library_Click(object sender, EventArgs e)
        {
            foreach (DocumentClass documentClass in selectedItems.ToList())
            {
                AdNewChildrenToSelection(documentClass);
            }
            RegisterMissingDataBaseInput registerMissingDataBaseInput = new RegisterMissingDataBaseInput();
            registerMissingDataBaseInput.SetupForm(selectedItems);
            registerMissingDataBaseInput.Show();
            //if (selectedItems.Where(x => x.NewNomenclature == null).Count() == 0)
            //{
            //    foreach (DocumentClass documentClass in selectedItems)
            //    {
            //        UpdateFileParameters(documentClass);
            //        VMLCoordinator.LibraryDocumentDictionary.Add(documentClass.Key, documentClass);
            //    }
            //    VMLCoordinator.StoreDocumentClassesDict();
            //    foreach (DocumentClass documentClass in selectedItems)
            //    {
            //        documentClass.UploadDoc();
            //    }
            //    MessageBox.Show("Spremljeno je " + selectedItems.Count + " dokumenata.", "Saved", MessageBoxButtons.OK);
            //    OLV_InSessionLista.RefreshSelectedObjects();
            //}
            //else 
            //{
            //    MessageBox.Show("Documents without \"Nomenclature\" can not be uploaded.","Unable to upload document.", MessageBoxButtons.OK);
            //}
        }
        private void AdNewChildrenToSelection(DocumentClass documentClass)
        {
            foreach (DocumentClass child in documentClass.ChildrenDict.Values)
            {
                if (!selectedItems.Contains(child) & child.Modified)
                {
                    selectedItems.Add(child);
                }
                AdNewChildrenToSelection(child);
            }
        }
        private void UpdateFileParameters(DocumentClass documentClass)
        {
            string FilePath = Path.GetFileName(documentClass.Key);
            INFITF.Application CATIA = VMLCoordinator.CATIA;
            Documents oDocs = CATIA.Documents;
            Document oDoc = oDocs.Item(FilePath);
            Product oProduct;
            if (Path.GetExtension(FilePath).ToUpper() == ".CATPRODUCT")
            {
                ProductDocument oProdDoc = (ProductDocument)oDoc;
                oProduct = oProdDoc.Product.ReferenceProduct;
            }
            else
            {
                PartDocument oPartDoc = (PartDocument)oDoc;
                oProduct = oPartDoc.Product.ReferenceProduct;
            }
            oProduct.set_Nomenclature(documentClass.NewNomenclature);
            StrParam Version;
            try
            {
                Version = (StrParam)oProduct.UserRefProperties.Item("Version");
                Version.set_Value(documentClass.Version);
            }
            catch
            {
                Version = oProduct.UserRefProperties.CreateString("Version", documentClass.Version);
            }
            oDoc.Save();
        }
        private void copyPartNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Clipboard.SetText(selectedItems[0].PartName);
        }

        #endregion
    }
}
