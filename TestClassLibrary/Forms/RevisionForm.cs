using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using VerManagerLibrary_ClassLib;

namespace VerManagerLibrary_ClassLib
{
    public delegate void RevisionObjectDelegate(RevisionClass revisionObject);
    public partial class RevisionForm : Form
    {
        public static IList FirstLevelItems;
        public static IList SecondLevelItems;
        public static RevisionClass ORevision;
        public static Dictionary<string, DocumentClass> Library;
        public RevisionObjectDelegate RevisionObjectDelegate;

        public RevisionForm()
        {
            InitializeComponent();
        }
        private void RevisionForm_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                SetInitalData();
                SetupColumns();
                ComboBoxSetup();
                List<string> selectedNomenclatureValues = new List<string>();
                SizeLastColumn(listView_Attachments);
                this.FOLV_Library_PartName.MakeEqualGroupies(selectedNomenclatureValues.ToArray(), selectedNomenclatureValues.ToArray(), new object[] { }, new string[] { }, new string[] { });
                this.FOLV_LibraryList.ShowGroups = true;
                this.FOLV_LibraryList.BuildList();
            }
        }
        public void FormInput(RevisionClass revisionObject, Dictionary<string, DocumentClass> libraryObject)
        {
            Library = libraryObject;
            ORevision = revisionObject;
            FirstLevelItems = Library.Values.Where(value => ORevision.RevisionDocuments.Keys.Where(
                x => ORevision.RevisionDocuments[x][0] == "0" | ORevision.RevisionDocuments[x][0] == "3").ToList().Contains(value.Key)).ToList();
            SecondLevelItems = Library.Values.Where(value => ORevision.RevisionDocuments.Keys.Where(
                x => ORevision.RevisionDocuments[x][0] == "1" | ORevision.RevisionDocuments[x][0] == "4").ToList().Contains(value.Key)).ToList();
        }
        private void SetInitalData()
        {
            textBoxRevisionID.Text = ORevision.RevisionID;
            comboBox_Importance.SelectedIndex = ORevision.ImportanceLvl;
            if (ORevision.Comment != "" && ORevision.Comment != null)
            {
                textBoxComent.Font = new Font(textBoxComent.Font, FontStyle.Regular);
                textBoxComent.ForeColor = SystemColors.WindowText;
                textBoxComent.Text = ORevision.Comment; 
            }
            FDLV_SelectedList.SetObjects(FirstLevelItems);
            if (checkBox_FilterLibrary.Checked) FOLV_LibraryList.SetObjects(Library.Values.Where(
                x =>
                !FirstLevelItems.Contains(x) &&
                x.RevisionDict.ContainsKey(ORevision.RevisionID) &&
                x.RevisionDict[ORevision.RevisionID] != 2
                ));
            else FOLV_LibraryList.SetObjects(Library.Values.Where(x => !FirstLevelItems.Contains(x)));
            UpdateAttachments();
        }
        private void SetupColumns()
        {
            this.FOLV_LibraryList.BooleanCheckStateGetter = delegate (Object rowObject)
            {
                return !"25".Contains(((DocumentClass)rowObject).RevisionStatus(ORevision.RevisionID).ToString());
            };
            this.FOLV_LibraryList.BooleanCheckStatePutter = delegate (Object rowObject, bool newValue)
            {
                if (newValue == true)
                {
                    string[] docAttributes = {"1",null, null};
                    ORevision.AddRevisionDocument(((DocumentClass)rowObject).Key, docAttributes);
                    ((DocumentClass)rowObject).AddRevision(ORevision.RevisionID, 1);
                }
                else
                {
                    ORevision.RemoveRevisionDocument(((DocumentClass)rowObject).Key);
                    ((DocumentClass)rowObject).RemoveRevision(ORevision.RevisionID);
                }
                return newValue;
            };
            this.FOLV_Library_Resolved.AspectGetter = delegate (object x)
            {
                return "34".Contains(((DocumentClass)x).RevisionStatus(ORevision.RevisionID).ToString());
            };
            this.FOLV_Library_Resolved.AspectPutter = delegate (object x, object newValue)
            {
                if (((DocumentClass)x).RevisionStatus(ORevision.RevisionID) != 2 && ((DocumentClass)x).RevisionStatus(ORevision.RevisionID) != 5)
                {
                    if ((bool)newValue)
                    {
                        ((DocumentClass)x).IncreaseVersion();
                        string[] docAttributes = { "4", ((DocumentClass)x).Version, ((DocumentClass)x).OldVersion };
                        ORevision.ModifyRevisionDocument(((DocumentClass)x).Key, docAttributes);
                        ((DocumentClass)x).ModifyRevision(ORevision.RevisionID, 4);
                    }
                    else
                    { 
                        if (((DocumentClass)x).OldVersion != null && ((DocumentClass)x).OldVersion == ORevision.RevisionDocuments[((DocumentClass)x).Key][2])
                        {
                            ((DocumentClass)x).UndoVersionIncrease();
                        }
                        string[] docAttributes = { "1", null, null };
                        ORevision.ModifyRevisionDocument(((DocumentClass)x).Key, docAttributes);
                        ((DocumentClass)x).ModifyRevision(ORevision.RevisionID, 1);
                    }
                }
            };
            this.FOLV_Library_SolvedVersion.AspectGetter = delegate (object x)
            {
                if (ORevision.RevisionDocuments.ContainsKey(((DocumentClass)x).Key))
                {
                    if (string.IsNullOrEmpty(ORevision.RevisionDocuments[((DocumentClass)x).Key][1])) return null;
                    else return ORevision.RevisionDocuments[((DocumentClass)x).Key][1];
                }
                else
                {
                    return null;
                }
            };
            this.FOLV_Library_OldVersion.AspectGetter = delegate (object x)
            {
                if (ORevision.RevisionDocuments.ContainsKey(((DocumentClass)x).Key))
                {
                    if (string.IsNullOrEmpty(ORevision.RevisionDocuments[((DocumentClass)x).Key][2])) return null;
                    else return ORevision.RevisionDocuments[((DocumentClass)x).Key][2];
                }
                else
                {
                    return null;
                }
            };
            this.FOLV_Library_CurrentRevisionStatus.AspectGetter = delegate (object x)
            {
                if (((DocumentClass)x).RevisionStatus(ORevision.RevisionID) == 5 || ((DocumentClass)x).RevisionStatus(ORevision.RevisionID) == 2)
                {
                    if (FOLV_Library_Resolved.GetCheckState(x) == CheckState.Checked) { this.FOLV_Library_Resolved.PutCheckState(x, CheckState.Unchecked); };
                    return "";
                }
                else
                {
                    if (((DocumentClass)x).RevisionStatus(ORevision.RevisionID) == 4) return "Solved";
                    return "Unsolved";
                };
            };
            this.FOLV_Library_CurrentRevisionStatus.ImageGetter = delegate (object x)
            {
                if (((DocumentClass)x).RevisionStatus(ORevision.RevisionID) == 5 || ((DocumentClass)x).RevisionStatus(ORevision.RevisionID) == 2)
                {
                    return -1;
                }
                else
                {
                    if (((DocumentClass)x).RevisionStatus(ORevision.RevisionID) == 4) return 0;
                    return 1;
                };
            };
            this.FDLV_Selected_Resolved.AspectGetter = delegate (object x)
            {
                if (((DocumentClass)x).RevisionStatus(ORevision.RevisionID) < 2) return false;
                return true;
            };
            this.FDLV_Selected_Resolved.AspectPutter = delegate (object x, object newValue)
            {
                if ((bool)newValue)
                {
                    ((DocumentClass)x).IncreaseVersion();
                    string[] docAttributes = { "3", ((DocumentClass)x).Version, ((DocumentClass)x).OldVersion };
                    ORevision.ModifyRevisionDocument(((DocumentClass)x).Key, docAttributes);
                    ((DocumentClass)x).ModifyRevision(ORevision.RevisionID, 3);
                }
                else
                {
                    if (((DocumentClass)x).OldVersion != null && ((DocumentClass)x).OldVersion == ORevision.RevisionDocuments[((DocumentClass)x).Key][2])
                    {
                        ((DocumentClass)x).UndoVersionIncrease();
                    }
                    string[] docAttributes = { "0", null, null };
                    ORevision.ModifyRevisionDocument(((DocumentClass)x).Key, docAttributes);
                    ((DocumentClass)x).ModifyRevision(ORevision.RevisionID, 0);
                }
            };
            this.FDLV_Selected_CurrentRevisionStatus.AspectGetter = delegate (object x)
            {
                if (((DocumentClass)x).RevisionStatus(ORevision.RevisionID) > 2) return "Solved";
                return "Unsolved";
            };
            this.FDLV_Selected_CurrentRevisionStatus.ImageGetter = delegate (object x)
            {
                if (((DocumentClass)x).RevisionStatus(ORevision.RevisionID) > 2) return 0;
                return 1;
            };
            this.FDLV_Selected_SolvedVersion.AspectGetter = delegate (object x)
            {
                if (ORevision.RevisionDocuments.ContainsKey(((DocumentClass)x).Key))
                {
                    if (string.IsNullOrEmpty(ORevision.RevisionDocuments[((DocumentClass)x).Key][1])) return null;
                    else return ORevision.RevisionDocuments[((DocumentClass)x).Key][1];
                }
                else
                {
                    return null;
                }
            };
            this.FDLV_Selected_OldVersion.AspectGetter = delegate (object x)
            {
                if (ORevision.RevisionDocuments.ContainsKey(((DocumentClass)x).Key))
                {
                    if (string.IsNullOrEmpty(ORevision.RevisionDocuments[((DocumentClass)x).Key][2])) return null;
                    else return ORevision.RevisionDocuments[((DocumentClass)x).Key][2];
                }
                else
                {
                    return null;
                }
            };
        }
        private void ComboBoxSetup()
        {
            List<string> headers = new List<string>();
            foreach (ColumnHeader columnHeader in FOLV_LibraryList.Columns)
            {
                headers.Add(columnHeader.Text);
            }
            comboBoxFilterColumn.Items.AddRange(headers.ToArray());
            comboBoxFilterColumn.SelectedIndex = 0;
            FOLV_LibraryList.AllColumns[0].Searchable = true;
        }
        private void TextBox_FilterLibraryItems_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFilterLibraryItems.TextLength > 1)
            {
                FOLV_LibraryList.ModelFilter = TextMatchFilter.Contains(this.FOLV_LibraryList, textBoxFilterLibraryItems.Text);
            }
            else
            {
                FOLV_LibraryList.ModelFilter = null;
            }
        }
        private void ComboBox_FilterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            FOLV_LibraryList.AllColumns.ForEach(x => x.Searchable = false);
            FOLV_LibraryList.AllColumns[comboBoxFilterColumn.SelectedIndex].Searchable = true;
        }
        private void ComboBox_Importance_SelectedIndexChanged(object sender, EventArgs e)
        {
            ORevision.ImportanceLvl = comboBox_Importance.SelectedIndex;
            if (RevisionObjectDelegate != null)
            {
                RevisionObjectDelegate(ORevision);
            }
        }
        public void UpdateParents()
        {
            Library.Values.Where(dClass => dClass.RevisionDict.ContainsKey(ORevision.RevisionID) && dClass.RevisionDict[ORevision.RevisionID] == 2).ToList().ForEach(
            dClass => dClass.RemoveRevision(ORevision.RevisionID));
            ORevision.RevisionDocuments.Where(kvp => kvp.Value[0] == "2").ToList().ForEach(kvp => ORevision.RemoveRevisionDocument(kvp.Key));
            Stack<DocumentClass> documentClasses = new Stack<DocumentClass>();
            foreach (string key in ORevision.RevisionDocuments.Keys.ToList())
            {
                DocumentClass documentClass = Library[key];
                documentClasses.Push(documentClass);
                while (documentClasses.Count > 0)
                {
                    DocumentClass currentDocumentClass = documentClasses.Pop();
                    currentDocumentClass.ParentsDict.Values.Where(dClass => !dClass.RevisionDict.ContainsKey(ORevision.RevisionID) || dClass.RevisionDict[ORevision.RevisionID] != 2).ToList().ForEach(
                        dClass => documentClasses.Push(dClass));
                    if (documentClass.RevisionStatus(ORevision.RevisionID) < 2)
                    {
                        string[] docAttributes = { "2", null, null};
                        currentDocumentClass.AddRevision(ORevision.RevisionID, 2);
                        ORevision.AddRevisionDocument(currentDocumentClass.Key, docAttributes);
                    }
                }
            }
        }
        private void Button_StoreRevision_Click(object sender, EventArgs e)
        {
            UpdateParents();
            VMLCoordinator.DocumentDictionary = Library;
            VMLCoordinator.StoreDocumentClassesDict();
            if (VMLCoordinator.RevisionDictionary.ContainsKey(ORevision.RevisionID))
            { VMLCoordinator.RevisionDictionary[ORevision.RevisionID] = ORevision; }
            else
            { VMLCoordinator.RevisionDictionary.Add(ORevision.RevisionID, ORevision); }
            VMLCoordinator.StoreRevisionDict();
            VMLCoordinator.StoreDocumentClassesDict();
            if (RevisionObjectDelegate != null)
            {
                RevisionObjectDelegate(ORevision);
            }
            this.Close();
        }
        private void CheckBox_FilterLibrary_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_FilterLibrary.Checked) FOLV_LibraryList.SetObjects(Library.Values.Where(
                x =>
                !FirstLevelItems.Contains(x) &&
                x.RevisionDict.ContainsKey(ORevision.RevisionID) &&
                x.RevisionDict[ORevision.RevisionID] != 2
                ));
            else FOLV_LibraryList.SetObjects(Library.Values.Where(x => !FirstLevelItems.Contains(x)));
            FOLV_LibraryList.RebuildColumns();
        }
        public void RemoveText(object sender, EventArgs e)
        {
            if (textBoxComent.Text == "Enter comment here...")
            {
                textBoxComent.Text = "";
                textBoxComent.Font = new Font(textBoxComent.Font, FontStyle.Regular);
                textBoxComent.ForeColor = SystemColors.WindowText;
            }
        }
        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxComent.Text))
            {
                textBoxComent.Text = "Enter comment here...";
                textBoxComent.Font = new Font(textBoxComent.Font, FontStyle.Italic);
                textBoxComent.ForeColor = SystemColors.GrayText;
                ORevision.Comment = "";
            }
            else
            {
                textBoxComent.Font = new Font(textBoxComent.Font, FontStyle.Regular);
                textBoxComent.ForeColor = SystemColors.WindowText;
                ORevision.Comment = textBoxComent.Text;
            }

        }
        private void ListView_Attachments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Attachments.SelectedItems.Count != 0)
            {
                string path = listView_Attachments.FocusedItem.SubItems[1].Text;
                if (path.Contains("IMG_"))
                {
                    if (pictureBox_ImageDisplay.Image != null) pictureBox_ImageDisplay.Image.Dispose();
                    pictureBox_ImageDisplay.Image = Image.FromFile(path);
                    pictureBox_ImageDisplay.Visible = true;
                    kwForm1.Visible = false;
                }
                else
                {
                    kwForm1.InitialInput(path, true, ORevision);
                    pictureBox_ImageDisplay.Visible = false;
                    kwForm1.Visible = true;
                }
            }
        }
        private void ListView_Attachments_DoubleClick(object sender, EventArgs e)
        {
            if (listView_Attachments.SelectedItems.Count != 0)
            {
                string path = listView_Attachments.FocusedItem.SubItems[1].Text;
                if (path.Contains("IMG_"))
                {
                    Process.Start(path);
                }
                else
                {
                    AddKW addKWForm = new AddKW();
                    addKWForm.SetRevision(ORevision, path);
                    addKWForm.ShowDialog();
                }
            }
        }
        private void DeleteAttachment(object sender, EventArgs e)
        {
            if (pictureBox_ImageDisplay.Image != null)   pictureBox_ImageDisplay.Image.Dispose();
            pictureBox_ImageDisplay.Image = null;
            pictureBox_ImageDisplay.Visible = true;
            kwForm1.Visible = false;
            foreach (ListViewItem item in listView_Attachments.SelectedItems)
            {
                string attachmentPath = item.SubItems[1].Text;
                File.Delete(attachmentPath);
                ORevision.Attachments.Remove(attachmentPath);
            }
            UpdateAttachments();
        }
        private void ListView_Attachments_Resize(object sender, System.EventArgs e)
        {
            SizeLastColumn((ListView)sender);
        }
        private void SizeLastColumn(ListView lv)
        {
            lv.Columns[lv.Columns.Count - 1].Width = -2;
        }
        private void Button_AddImages_Click(object sender, EventArgs e)
        {
            AddPicture addPictureForm = new AddPicture();
            RevisionObjectDelegate sendRevisionObject = new RevisionObjectDelegate(addPictureForm.SetRevision);
            sendRevisionObject(ORevision);
            addPictureForm.FormClosed += new FormClosedEventHandler(ChildClosed);
            addPictureForm.ShowDialog();
        }
        private void Button_AddKW_Click(object sender, EventArgs e)
        {
            AddKW AddKnowldgewareForm = new AddKW();
            AddKnowldgewareForm.SetRevision(ORevision, "");
            AddKnowldgewareForm.FormClosed += new FormClosedEventHandler(ChildClosed);
            AddKnowldgewareForm.ShowDialog();
        }
        private void ChildClosed(object sender, EventArgs e)
        {
            UpdateAttachments();
        }
        private void UpdateAttachments()
        {
            listView_Attachments.Items.Clear();
            if (ORevision.Attachments != null)
            {
                ORevision.Attachments.ToList().ForEach(item =>
                {
                    ListViewItem listViewItem = listView_Attachments.Items.Add(Path.GetFileName(item));
                    listViewItem.SubItems.Add(item);
                });
            }
        }
        private void ListView_Images_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView_Attachments.FocusedItem != null) contextMenuStrip_Images.Show(Cursor.Position);
            }
        }
        private void FDLV_SelectedList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (FDLV_SelectedList.FocusedItem != null) contextMenuStrip_SelectedItems.Show(Cursor.Position);
            }
        }
        private void DeleteSelectedItem(object sender, EventArgs e)
        {

            foreach (var theObject in FDLV_SelectedList.SelectedObjects)
            {
                DocumentClass document = (DocumentClass)theObject;
                ORevision.RemoveRevisionDocument(document.Key);
                document.RemoveRevision(ORevision.RevisionID);
            }
            FOLV_LibraryList.AddObjects(FDLV_SelectedList.SelectedObjects);
            FDLV_SelectedList.RemoveObjects(FDLV_SelectedList.SelectedObjects);
        }
    }
}
