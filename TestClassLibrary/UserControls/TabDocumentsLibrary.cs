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
    public partial class TabDocumentsLibrary : UserControl
    {
        private Dictionary<string, DocumentClass> displayedDocuments = new Dictionary<string, DocumentClass>();
        private readonly List<DocumentClass> selectedItems = new List<DocumentClass>();
        public TabDocumentsLibrary()
        {
            InitializeComponent();
        }
        private void TabDocumentsLibrary_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                treeListView_Stablo.BringToFront();
                displayedDocuments = VMLCoordinator.DocumentDictionary;
                SetupTree();
                SetupDocumentList();
                InitialTabUpdate();
            }
        }
        private async void InitialTabUpdate()
        {
            displayedDocuments = await VMLCoordinator.CollectInSessionDocuments();
            SetupTree();
            SetupDocumentList();
        }
        #region Treelistview Setup
        //TreeListView osnovni delegatori:
        // 1. CanExpandGetter - Info da li cvor ima childrene?
        // 2. ChildrenGetter - children collection
        private void SetupTree()
        {
            clmn_Stablo_Version.AspectGetter = delegate (object rowObject) {
                DocumentClass document = (DocumentClass)rowObject;
                if (document.Modified) return document.Modified;
                return "";
            };
            clmn_Stablo_PartName.ImageGetter = delegate (object rowObject)
            {
                DocumentClass document = (DocumentClass)rowObject;
                if (document.InSession) return 6;
                else return -1;
            };
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
            
            foreach (DocumentClass di in displayedDocuments.Values)
            {
                //if ((di.InSession) && (!di.Used) | (di.ParentsDict.Values.Where(x => x.InSession).Count() == 0))
                if (!di.Used )
                    roots.Add(di);
            }
            this.treeListView_Stablo.Roots = roots;
        }
        private void TreeListView_Stablo_FormatRow(object sender, FormatRowEventArgs e)
        {
            DocumentClass document = (DocumentClass)e.Model;
            if (document.RevisionDict.Count() != 0)
            {
                if (document.RevisionDict.Values.Min() < 2)
                {
                    e.Item.BackColor = Color.Red;
                }
                else if (document.RevisionDict.Values.Contains(2))
                {
                    e.Item.BackColor = Color.LightPink;
                }
            }
        }

        #endregion
        #region Document Listview Setup
        private void SetupDocumentList()
        {
            OLV_DocumentsLista.SetObjects(displayedDocuments.Values);
            clmn_Lista_Modified.AspectGetter = delegate (object rowObject) {
                DocumentClass document = (DocumentClass)rowObject;
                if (document.Modified) return document.Modified.ToString();
                return "";
            };
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
                        group.Subtitle = "Need to update version.";
                        break;
                    default:
                        group.TitleImage = 3;
                        group.Subtitle = "User didn't upload documents.";
                        break;
                }

            };
            OLV_DocumentsLista.ShowGroups = false;
            //OLV_DocumentsLista.Sort(clmn_Lista_Status);
        }
        private void OLV_DocumentsLista_FormatRow(object sender, FormatRowEventArgs e)
        {
            DocumentClass document = (DocumentClass)e.Model;
            if (document.RevisionDict.Count() != 0)
            {
                if (document.RevisionDict.Values.Min() < 2)
                {
                    e.Item.BackColor = Color.Red;
                }
                else if (document.RevisionDict.Values.Contains(2))
                {
                    e.Item.BackColor = Color.LightPink;
                }
            }
        }
        #endregion
        #region Revision Listview Setup
        private void OLV_RevisionList_FormatRow(object sender, FormatRowEventArgs e)
        {
            RevisionClass revision = (RevisionClass)e.Model;
            if (revision.SolvedStatus == true)
            {
                e.Item.BackColor = Color.LightGreen;
            }
            else
            {
                e.Item.BackColor = Color.LightPink;
            }
        }
        private void SetupRevisionList()
        {
            if (selectedItems.Count == 1)
            {
                List<string> keyValues = selectedItems[0].RevisionDict.Keys.ToList();
                if (keyValues.Count() != 0)
                {
                    clmn_Lista_II_ImportanceLevel.AspectGetter = delegate (object rowObject)
                    {
                        RevisionClass revision = (RevisionClass)rowObject;
                        if (revision.ImportanceLvl == 0) return "High";
                        else if (revision.ImportanceLvl == 1) return "Medium";
                        return "Low";
                    };
                    OLV_RevisionList.SetObjects(VMLCoordinator.RevisionDictionary.Values.ToList().Where(x => keyValues.Contains(x.RevisionID)));
                }
                else
                {
                    OLV_RevisionList.ClearObjects();
                }
            }
            else 
            {
                OLV_RevisionList.ClearObjects();
            }
            clmn_Lista_II_SolvedStatus.GroupKeyGetter = delegate (object rowObject) {
                RevisionClass revision = (RevisionClass)rowObject;
                return revision.SolvedStatus;
            };
            OLV_RevisionList.ShowGroups = true;
            OLV_RevisionList.Sort(clmn_Lista_II_SolvedStatus);
        }
        #endregion
        #region Event Handlers
        private void Button_NewRevision_Click(object sender, EventArgs e)
        {
            if (selectedItems.Count != 0) {
                RevisionClass newRevision = new RevisionClass();
                newRevision.CreateRevisionID();
                foreach (DocumentClass documentClass in selectedItems) {
                    //documentClass.IncreaseVersion();
                    string[] docAttributes = { "0", null, null };
                    newRevision.AddRevisionDocument(documentClass.Key, docAttributes);
                    documentClass.AddRevision(newRevision.RevisionID, 0);
                }

                var newForm = new RevisionForm();
                newForm.FormInput(newRevision, VMLCoordinator.DocumentDictionary);
                newForm.RevisionObjectDelegate  = new RevisionObjectDelegate(RevisionModified);
                newForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Da bi kreirali reviziju morate odabrati barem jedan dokument iz liste.", "Unable to create", MessageBoxButtons.OK);
            }
        }
        private void RevisionModified(RevisionClass revision)
        {
            OLV_RevisionList.UpdateObject(revision);  
        }
        private void List_CellEditStarting(object sender, CellEditEventArgs e)
        {
            e.Control.Bounds = e.ListViewItem.GetSubItemBounds(e.SubItemIndex);
        }
        private void CheckBox_DisplayType_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DisplayType.Checked)
            {
                OLV_DocumentsLista.RebuildColumns();
                OLV_DocumentsLista.BringToFront();
                checkBox_DisplayType.Text = "Display as tree";
            }
            else
            {
                treeListView_Stablo.CollapseAll();
                treeListView_Stablo.BringToFront();
                checkBox_DisplayType.Text = "Display as list";
            }
        }
        private void Documents_SelectionChanged(object sender, EventArgs e)
        {
            selectedItems.Clear();
            ObjectListView objectListView = (ObjectListView)sender;

            foreach (DocumentClass documentClass in objectListView.SelectedObjects)
            {
                selectedItems.Add(documentClass);
            }
            SetupRevisionList();
        }
        private void OLV_RevisionList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var newForm = new RevisionForm();
            newForm.FormInput((RevisionClass)OLV_RevisionList.SelectedObject, VMLCoordinator.DocumentDictionary);
            //newForm.revisionStored = new RevisionStoredDelegate(this.RevisionAdded);
            newForm.RevisionObjectDelegate = new RevisionObjectDelegate(RevisionModified);
            newForm.checkBox_FilterLibrary.Checked = true;
            newForm.ShowDialog();
        }
        private void Documents_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (selectedItems.Count != 0 && selectedItems.Where(x => x.Status != "Missing Database Input").Count() == 0) contextMenuStrip_MissingDataBaseInput.Show(Cursor.Position);
                if (selectedItems.Count != 0 && selectedItems.Where(x => x.Status != "New" && x.Modified == false).Count() == 0)
                {
                    if (selectedItems.Count == 1) { copyPartNameToolStripMenuItem.Enabled = true; } else { copyPartNameToolStripMenuItem.Enabled = false; }
                    contextMenuStrip_New.Show(Cursor.Position);
                }
            }
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
                OLV_DocumentsLista.RebuildColumns();
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
        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeListView_Stablo.CollapseAll();
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

        #endregion

        private void radioButton_Library_CheckedChanged(object sender, EventArgs e)
        {
                comboBoxFilterColumn.Visible = radioButton_Library.Checked;
                textBoxFilterLibraryItems.Visible = radioButton_Library.Checked;
                label_Search.Visible = radioButton_Library.Checked;
        }

        private void textBoxFilterLibraryItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) MessageBox.Show("Enter");
        }
    }
}
