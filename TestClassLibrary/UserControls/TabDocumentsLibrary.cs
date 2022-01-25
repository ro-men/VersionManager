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
                SetupCombos();
                SetupDocumentTreelist();
                SetupDocumentList();
                InitialTabUpdate();
            }
        }
        private async void InitialTabUpdate()
        {
            displayedDocuments = await VMLCoordinator.CollectInSessionDocuments();
            SetupDocumentTreelist();
            SetupDocumentList();
            Console.WriteLine(groupBox_Controls.Width);
            Console.WriteLine(comboBox_Operation.Width);
        }
        #region Document Treelistview Setup
        //TreeListView osnovni delegatori:
        // 1. CanExpandGetter - Info da li cvor ima childrene?
        // 2. ChildrenGetter - children collection
        private void SetupDocumentTreelist()
        {
            clmn_Stablo_PartName.ImageGetter = delegate (object rowObject)
            {
                DocumentClass document = (DocumentClass)rowObject;
                if (document.InSession) return 0;
                else return -1;
            };
            this.treeListView_Stablo.CanExpandGetter = delegate (object x)
            {
                DocumentClass inst = (DocumentClass)x;
                return inst.ChildrenDict.Count != 0;
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
                if (di.ParentsDict.Count == 0)
                    roots.Add(di);
            }
            this.treeListView_Stablo.Roots = roots;
        }
        private void SetupDocumentList()
        {
            clmn_Lista_PartName.ImageGetter = delegate (object rowObject)
            {
                DocumentClass document = (DocumentClass)rowObject;
                if (document.InSession) return 0;
                else return -1;
            };
            OLV_DocumentsLista.SetObjects(displayedDocuments.Values);
        }
        private void ListView_FormatRow(object sender, FormatRowEventArgs e)
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
        private void ListView_FormatCell(object sender, FormatCellEventArgs e)
        {
            DocumentClass document = (DocumentClass)e.Model;
            if (e.ColumnIndex == this.clmn_Stablo_Nomenclature.Index && document.SqlNomenclature != null && document.LocalNomenclature != document.SqlNomenclature) 
            {
                e.SubItem.ForeColor = Color.Red;
            }
            if (e.ColumnIndex == this.clmn_Stablo_Version.Index && document.SqlVersion != null && document.LocalVersion != document.SqlVersion)
            {
                e.SubItem.ForeColor = Color.Red;
            }
        }
        
        #endregion

        #region Revision Listview Setup
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
                    clmn_Lista_II_RevisionObject.AspectGetter = delegate (object rowObject)
                    {
                        RevisionClass revision = (RevisionClass)rowObject;
                        if (revision.RevisionDocuments.ContainsKey(selectedItems[0].Key)) return "Selection";
                        return "Child";
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
        }

        #endregion
        #region Event Handlers
        private void Button_NewRevision_Click(object sender, EventArgs e)
        {
            if (selectedItems.Count != 0) {
                if (selectedItems.Where(x => x.Status == "New").Count() == 0)
                {
                    RevisionClass newRevision = new RevisionClass();
                    newRevision.CreateRevisionID();
                    foreach (DocumentClass documentClass in selectedItems)
                    {
                        RevisionClass.DocInfo docAttributes = new RevisionClass.DocInfo
                        { 
                            RD_Value = 0, 
                            OldVersion = null, 
                            NewVersion = null, 
                        };
                        newRevision.AddRevisionDocument(documentClass.Key, docAttributes);
                    }

                    var newForm = new RevisionForm();
                    newForm.FormInput(newRevision, VMLCoordinator.DocumentDictionary);
                    newForm.RevisionObjectDelegate = new RevisionObjectDelegate(RevisionModified);
                    newForm.ShowDialog();
                }
                else { MessageBox.Show("Nemoguće je kreirati reviziju sa novim dokumentom. Odabrani dokumenti moraju imati postojeću verziju na mreži.", "Unable to create revision.", MessageBoxButtons.OK); }
            }
            else
            {
                MessageBox.Show("Da bi kreirali reviziju morate odabrati barem jedan dokument iz liste.", "Unable to create revision.", MessageBoxButtons.OK);
            }
        }
        private void RevisionModified(RevisionClass revision)
        {
            if (!VMLCoordinator.RevisionDictionary.ContainsKey(revision.RevisionID)) VMLCoordinator.RevisionDictionary.Add(revision.RevisionID, revision);
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
        private void TextBoxFilterLibraryItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) MessageBox.Show("Enter");
        }
        private void CheckBox_Library_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_Operation.Visible = checkBox_Library.Checked; ;
            comboBox_Mod.Visible = checkBox_Library.Checked; ;
            comboBox_SearchAttribute.Visible = checkBox_Library.Checked; ;
            textBoxFilterLibraryItems.Visible = checkBox_Library.Checked;
            if (!checkBox_Library.Checked)
            {
                checkBox_Library.Text = "Display library";
                VMLCoordinator.DocumentDictionary = VMLCoordinator.DocumentDictionary.Where(kvp => kvp.Value.InSession).ToDictionary(x => x.Key, x => x.Value);
                SetupDocumentTreelist();
                SetupDocumentList();
            }
            else
            {
                checkBox_Library.Text = "Remove library";
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
        private void CollapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeListView_Stablo.CollapseAll();
        }
        #endregion
        #region contextMenuStrip_New

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
            oProduct.set_Nomenclature(documentClass.LocalNomenclature);
            StrParam Version;
            try
            {
                Version = (StrParam)oProduct.UserRefProperties.Item("Version");
                Version.set_Value(documentClass.LocalVersion);
            }
            catch
            {
                Version = oProduct.UserRefProperties.CreateString("Version", documentClass.LocalVersion);
            }
            oDoc.Save();
        }
        private void CopyPartNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Clipboard.SetText(selectedItems[0].Name);
        }

        #endregion

        #endregion
        private void SetupCombos()
        {
            comboBox_Operation.Items.AddRange(new string[] { "Add to list", "New search" });
            comboBox_Operation.SelectedIndex = 0;
            comboBox_SearchAttribute.Items.AddRange(new string[] { "PartName", "Nomenclature", "Path" });
            comboBox_SearchAttribute.SelectedIndex = 0;
            comboBox_Mod.Items.AddRange(new string[] { "Equals", "Begins with", "Contains" });
            comboBox_Mod.SelectedIndex = 0;
        }
        private readonly ToolTip Tip = new ToolTip
        {
            AutoPopDelay = 5000,
            InitialDelay = 1000,
            ReshowDelay = 1000,
            BackColor = Color.LightYellow,
        };
        private void OLV_DocumentsLista_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            Tip.RemoveAll();
            ObjectListView lista = (ObjectListView)sender;
            OLVListItem oLVListItem = (OLVListItem)e.Item;
            DocumentClass documentClass = (DocumentClass)oLVListItem.RowObject;
            Point p = lista.PointToClient(Cursor.Position);
            string columnName = this.GetColumnName(p, lista);
            string desc = "";
            switch (columnName) {
                case "Nomenclature":
                    if (documentClass.LocalNomenclature != documentClass.SqlNomenclature) desc = "Sql Nomenclature:\t" + documentClass.SqlNomenclature;
                    break;
                case "Version":
                    if (documentClass.LocalVersion != documentClass.SqlVersion) desc = "Sql Version:\t" + documentClass.SqlVersion;
                    break;
                default:
                    break;
            }
            if (desc != "")
            {
                Tip.SetToolTip(lista, desc);
            }
        }
        private string GetColumnName(Point hitPoint, ObjectListView objectListView)
        {
            string name = objectListView.Columns[0].Name;
            int right = 0;
            for (int j = 0; j < objectListView.Columns.Count; j++)
            {
                right += objectListView.Columns[j].Width;
                if (hitPoint.X < right)
                {
                    name = objectListView.Columns[j].Text;
                    break;
                }
            }
            return name;
        }


    }
}
