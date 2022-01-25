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
        public RevisionObjectDelegate RevisionObjectDelegate; //Za vraćanje objekta revizija u glavni prozor prilikom zatvaranja. 
        public RevisionForm()
        {
            InitializeComponent();
        }
        public void FormInput(RevisionClass revisionObject, Dictionary<string, DocumentClass> libraryObject)
        {
            ORevision = revisionObject;
            ImportedDocumentLibrary = libraryObject;
        }
        private RevisionClass ORevision;
        private Dictionary<string, DocumentClass> ImportedDocumentLibrary;
        private class ExpandedDocument
        {
            public RevisionClass.DocInfo NewDocInfo { get; set; } = new RevisionClass.DocInfo();
            public DocumentClass ReferencedDocument { get; set; }        
            public int NewVersionIndex;
            public ExpandedDocument(DocumentClass DocumentValue, RevisionClass RevisionValue)
            {
                ReferencedDocument = DocumentValue;
                NewVersionIndex = Int32.Parse(DocumentValue.LocalVersion.Split('_').Last()) + 1;
                if (RevisionValue.RevisionDocuments.ContainsKey(DocumentValue.Key) && RevisionValue.RevisionDocuments[DocumentValue.Key].RD_Value != 2)
                {
                    NewDocInfo.RD_Value = RevisionValue.RevisionDocuments[DocumentValue.Key].RD_Value;
                    NewDocInfo.OldVersion = RevisionValue.RevisionDocuments[DocumentValue.Key].OldVersion;
                    NewDocInfo.NewVersion = RevisionValue.RevisionDocuments[DocumentValue.Key].NewVersion;
                }
            }
        }
        private List<ExpandedDocument> FirstLevelItems;
        private List<ExpandedDocument> SecondLevelItems;
        private readonly Dictionary<string, ExpandedDocument> ExpandedDocumentsLibrary = new Dictionary<string, ExpandedDocument>();
        private void RevisionForm_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                SetupColumns();
                SetInitalData();
                ComboBoxSetup();
                SizeLastColumn(listView_Attachments);
            }
        }
        private void SetInitalData()
        {
            foreach (KeyValuePair<string, DocumentClass> kvp in VMLCoordinator.AddDocumentsFromLibrary(ORevision.RevisionDocuments.Keys.ToHashSet(), ImportedDocumentLibrary))
            {
                ExpandedDocument NewItem = new ExpandedDocument(kvp.Value, ORevision);
                ExpandedDocumentsLibrary.Add(kvp.Key, NewItem);
            }
            FirstLevelItems = ExpandedDocumentsLibrary.Values.Where(value => value.NewDocInfo.RD_Value == 0 | value.NewDocInfo.RD_Value == 3).ToList();
            SecondLevelItems = ExpandedDocumentsLibrary.Values.Where(value => value.NewDocInfo.RD_Value == 1 | value.NewDocInfo.RD_Value == 4).ToList();
            textBoxRevisionID.Text = ORevision.RevisionID;
            comboBox_Importance.SelectedIndex = ORevision.ImportanceLvl;
            if (ORevision.Comment != "" && ORevision.Comment != null)
            {
                textBoxComent.Font = new Font(textBoxComent.Font, FontStyle.Regular);
                textBoxComent.ForeColor = SystemColors.WindowText;
                textBoxComent.Text = ORevision.Comment; 
            }
            FDLV_SelectedList.SetObjects(FirstLevelItems);
            if (checkBox_FilterLibrary.Checked) FOLV_LibraryList.SetObjects(SecondLevelItems);
            else FOLV_LibraryList.SetObjects(ExpandedDocumentsLibrary.Values.Where(x => !FirstLevelItems.Contains(x)));
            LoadAttachments();
        }
        private void SetupColumns()
        {
            this.FDLV_Selected_PartName.AspectGetter = delegate (object x)
            {
                return ((ExpandedDocument)x).ReferencedDocument.Name;
            };
            this.FDLV_Selected_FullName.AspectGetter = delegate (object x)
            {
                return ((ExpandedDocument)x).ReferencedDocument.Location;
            };
            this.FDLV_Selected_Nomenclature.AspectGetter = delegate (object x)
            {
                return ((ExpandedDocument)x).ReferencedDocument.LocalNomenclature;
            };
            this.FDLV_Selected_Resolved.AspectGetter = delegate (object x)
            {
                if (((ExpandedDocument)x).NewDocInfo.RD_Value < 2) return false;
                return true;
            };
            this.FDLV_Selected_Resolved.AspectPutter = delegate (object x, object newValue)
            {
                if (/*((ExpandedDocument)x).ReferencedDocument.LockedBy == Environment.UserName && */((ExpandedDocument)x).ReferencedDocument.SyncStatus == null)
                {
                    RevisionClass.DocInfo docAttributes = new RevisionClass.DocInfo
                    {
                        RD_Value = (bool)newValue ? 3 : 0,
                        OldVersion = (bool)newValue ? ((ExpandedDocument)x).ReferencedDocument.LocalVersion : null,
                        NewVersion = (bool)newValue ? Environment.UserName + "_V_" + ((ExpandedDocument)x).NewVersionIndex.ToString() : null,
                    };
                    ((ExpandedDocument)x).NewDocInfo = docAttributes;
                }
                else
                {
                    MessageBox.Show("Nemoguće izmjeniti 'Resolved' status. Nisu ispunjeni svi uvjeti:\n" +
                         $"\n\t- File\t\tInSession\t\"{((ExpandedDocument)x).ReferencedDocument.InSession}\"" +
                         $"\n\t- Locked\t\t== UserName\t\"{((ExpandedDocument)x).ReferencedDocument.LockedBy}\"" +
                         $"\n\t- SyncStatus\t<> Updated\t\"{((ExpandedDocument)x).ReferencedDocument.SyncStatus}\"" +
                         $"\n\t- SyncStatus\t<> Outdated\t\"{((ExpandedDocument)x).ReferencedDocument.SyncStatus}\"", "Unable to edit status.", MessageBoxButtons.OK);
                }
            };
            this.FDLV_Selected_CurrentRevisionStatus.AspectGetter = delegate (object x)
            {
                if (((ExpandedDocument)x).NewDocInfo.RD_Value > 2) return "Solved";
                return "Unsolved";
            };
            this.FDLV_Selected_CurrentRevisionStatus.ImageGetter = delegate (object x)
            {
                if (((ExpandedDocument)x).NewDocInfo.RD_Value > 2) return 0;
                return 1;
            };
            this.FDLV_Selected_SolvedVersion.AspectGetter = delegate (object x)
            {
                return ((ExpandedDocument)x).NewDocInfo.NewVersion;
            };
            this.FDLV_Selected_OldVersion.AspectGetter = delegate (object x)
            {
                return ((ExpandedDocument)x).NewDocInfo.OldVersion;
            };
           
            this.FOLV_LibraryList.BooleanCheckStateGetter = delegate (Object rowObject)
            {
                return !"25".Contains(((ExpandedDocument)rowObject).NewDocInfo.RD_Value.ToString());
            };
            this.FOLV_LibraryList.BooleanCheckStatePutter = delegate (Object rowObject, bool newValue)
            {
                if (newValue == true)
                {
                    ((ExpandedDocument)rowObject).NewDocInfo.RD_Value = 1;
                    SecondLevelItems.Add((ExpandedDocument)rowObject);
                }
                else
                {
                    ((ExpandedDocument)rowObject).NewDocInfo.RD_Value = 5;
                    SecondLevelItems.Remove((ExpandedDocument)rowObject);
                }
                return newValue;
            };
            this.FOLV_Library_PartName.AspectGetter = delegate (object x)
            {
                return ((ExpandedDocument)x).ReferencedDocument.Name;
            };
            this.FOLV_Library_FullName.AspectGetter = delegate (object x)
            {
                return ((ExpandedDocument)x).ReferencedDocument.Location;
            };
            this.FOLV_Library_Nomenclature.AspectGetter = delegate (object x)
            {
                return ((ExpandedDocument)x).ReferencedDocument.LocalNomenclature;
            };
            this.FOLV_Library_Resolved.AspectGetter = delegate (object x)
            {
                return "34".Contains(((ExpandedDocument)x).NewDocInfo.RD_Value.ToString());
            };
            this.FOLV_Library_Resolved.AspectPutter = delegate (object x, object newValue)
            {
                if (((ExpandedDocument)x).NewDocInfo.RD_Value != 2 && ((ExpandedDocument)x).NewDocInfo.RD_Value != 5)
                {
                    if (/*((ExpandedDocument)x).ReferencedDocument.LockedBy == Environment.UserName && */((ExpandedDocument)x).ReferencedDocument.SyncStatus == null)
                    {
                        RevisionClass.DocInfo docAttributes = new RevisionClass.DocInfo
                        {
                            RD_Value = (bool)newValue ? 4 : 1,
                            OldVersion = (bool)newValue ? ((ExpandedDocument)x).ReferencedDocument.LocalVersion : null,
                            NewVersion = (bool)newValue ? Environment.UserName + "_V_" + ((ExpandedDocument)x).NewVersionIndex.ToString() : null,
                        };
                        ((ExpandedDocument)x).NewDocInfo = docAttributes;
                    }
                    else
                    {
                        MessageBox.Show("Nemoguće izmjeniti 'Resolved' status. Nisu ispunjeni svi uvjeti:\n" +
                             $"\n\t- File\t\tInSession\t\"{((ExpandedDocument)x).ReferencedDocument.InSession}\"" +
                             $"\n\t- Locked\t\t== UserName\t\"{((ExpandedDocument)x).ReferencedDocument.LockedBy}\"" +
                             $"\n\t- SyncStatus\t<> Updated\t\"{((ExpandedDocument)x).ReferencedDocument.SyncStatus}\"" +
                             $"\n\t- SyncStatus\t<> Outdated\t\"{((ExpandedDocument)x).ReferencedDocument.SyncStatus}\"", "Unable to edit status.", MessageBoxButtons.OK);
                    }
                }
            };
            this.FOLV_Library_CurrentRevisionStatus.AspectGetter = delegate (object x)
            {
                if (((ExpandedDocument)x).NewDocInfo.RD_Value == 5 || ((ExpandedDocument)x).NewDocInfo.RD_Value == 2)
                {
                    if (FOLV_Library_Resolved.GetCheckState(x) == CheckState.Checked) { this.FOLV_Library_Resolved.PutCheckState(x, CheckState.Unchecked); };
                    return "";
                }
                else
                {
                    if (((ExpandedDocument)x).NewDocInfo.RD_Value == 4) return "Solved";
                    return "Unsolved";
                };
            };
            this.FOLV_Library_CurrentRevisionStatus.ImageGetter = delegate (object x)
            {
                switch (((ExpandedDocument)x).NewDocInfo.RD_Value)
                {
                    case 0:
                        return 1;
                    case 1:
                        return 1;
                    case 2:
                        return -1;
                    case 3:
                        return 1;
                    case 4:
                        return 0;
                    default:
                        return -1;
                }
            };
            this.FOLV_Library_SolvedVersion.AspectGetter = delegate (object x)
            {
                return ((ExpandedDocument)x).NewDocInfo.NewVersion;
            };
            this.FOLV_Library_OldVersion.AspectGetter = delegate (object x)
            {
                return ((ExpandedDocument)x).NewDocInfo.OldVersion;
            };
        }
        private void ComboBoxSetup()
        {
            comboBoxFilterColumn.Items.AddRange( new string[] { "PartName","Path" ,"Nomenclature" });
            comboBoxFilterColumn.SelectedIndex = 0;
            comboBox_Operation.Items.AddRange(new string[] { "Add to list", "New search" });
            comboBox_Operation.SelectedIndex = 0;
            comboBox_SearchAttribute.Items.AddRange(new string[] { "PartName", "Nomenclature", "Path" });
            comboBox_SearchAttribute.SelectedIndex = 0;
            comboBox_Mod.Items.AddRange(new string[] { "Equals", "Begins with", "Contains" });
            comboBox_Mod.SelectedIndex = 0;

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
        private void Button_StoreRevision_Click(object sender, EventArgs e)
        {
            RebuildRevision();
            RebuildDocumentClasses();
            List<ExpandedDocument> ExpandedDocToSave = FirstLevelItems.Concat(SecondLevelItems).Where(x => x.NewDocInfo.NewVersion != null && Int32.Parse(x.NewDocInfo.NewVersion.Split('_').Last()) == x.NewVersionIndex).ToList();
            VMLCoordinator.StoreRevisionDict(); //Ovdje spremamo reviziju
            Dictionary<string, DocumentClass> DocToSave = new Dictionary<string, DocumentClass>();
            ExpandedDocToSave.ForEach(edoc => DocToSave.Add(edoc.ReferencedDocument.Key,edoc.ReferencedDocument));
            VMLCoordinator.StoreDocumentClassesDict(DocToSave); //Ovdje spremamo dokumente i uploadamo "ExpandedDocToSave"
            RevisionObjectDelegate?.Invoke(ORevision);
            this.Close();
        }
        private void RebuildRevision()
        {
            ORevision.ClearRevisionDocuments();
            ORevision.Attachments.Clear();
            FirstLevelItems.Concat(SecondLevelItems).ToList().ForEach(x => ORevision.AddRevisionDocument(x.ReferencedDocument.Key,x.NewDocInfo));
            foreach(ListViewItem item in listView_Attachments.Items)
            {
                if (item.SubItems[1].Text.Contains(Path.GetTempPath())) File.Move(Path.GetTempPath() + item.Text, VMLCoordinator.attachmentsFolder + item.Text);
                ORevision.Attachments.Add(VMLCoordinator.attachmentsFolder + item.Text);
            }
            ORevision.Comment = textBoxComent.Text == "Enter comment here..."? "" : textBoxComent.Text;
            ORevision.ImportanceLvl = comboBox_Importance.SelectedIndex;
        }
        private void RebuildDocumentClasses()
        {
            Stack<ExpandedDocument> DocStack = new Stack<ExpandedDocument>();
            foreach (string key in ORevision.RevisionDocuments.Keys)
            {
                ExpandedDocument expandedDocument = ExpandedDocumentsLibrary[key];
                DocStack.Push(expandedDocument);
                while (DocStack.Count > 0)
                {
                    ExpandedDocument currentExpandedDocument = DocStack.Pop();
                    currentExpandedDocument.ReferencedDocument.ParentsDict.Keys.ToList().ForEach(
                    x => DocStack.Push(ExpandedDocumentsLibrary[x]));
                    if (currentExpandedDocument.NewDocInfo.RD_Value == 5) currentExpandedDocument.NewDocInfo.RD_Value = 2;
                }
            }
            foreach (ExpandedDocument eDoc in ExpandedDocumentsLibrary.Values)
            {
                DocumentClass Doc = eDoc.ReferencedDocument;
                if (Doc.LocalVersion != eDoc.NewDocInfo.NewVersion && eDoc.NewDocInfo.NewVersion != null) Doc.LocalVersion = eDoc.NewDocInfo.NewVersion;
                if (eDoc.NewDocInfo.RD_Value != 5)
                {
                    Doc.AddRevision(ORevision.RevisionID, eDoc.NewDocInfo.RD_Value);
                }
                else
                {
                    Doc.RemoveRevision(ORevision.RevisionID);
                }
            }
        }
        private void CheckBox_FilterLibrary_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_FilterLibrary.Checked) FOLV_LibraryList.SetObjects(SecondLevelItems);
            else FOLV_LibraryList.SetObjects(ExpandedDocumentsLibrary.Values.Where(x => !FirstLevelItems.Contains(x)));
            FOLV_LibraryList.RebuildColumns();
        }
        private void RemoveText(object sender, EventArgs e)
        {
            if (textBoxComent.Text == "Enter comment here...")
            {
                textBoxComent.Text = "";
                textBoxComent.Font = new Font(textBoxComent.Font, FontStyle.Regular);
                textBoxComent.ForeColor = SystemColors.WindowText;
            }
        }
        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxComent.Text))
            {
                textBoxComent.Text = "Enter comment here...";
                textBoxComent.Font = new Font(textBoxComent.Font, FontStyle.Italic);
                textBoxComent.ForeColor = SystemColors.GrayText;
            }
            else
            {
                textBoxComent.Font = new Font(textBoxComent.Font, FontStyle.Regular);
                textBoxComent.ForeColor = SystemColors.WindowText;
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
                    kwForm_Display.Visible = false;
                }
                else
                {
                    kwForm_Display.InitialInput(path, true, ORevision);
                    pictureBox_ImageDisplay.Visible = false;
                    kwForm_Display.Visible = true;
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
                    AddKW AddKnowldgewareForm = new AddKW();
                    AddKnowldgewareForm.SetRevision(ORevision, path);
                    AddKnowldgewareForm.ShowDialog();
                }
            }
        }
        private void DeleteAttachment(object sender, EventArgs e)
        {
            pictureBox_ImageDisplay.Visible = true;
            kwForm_Display.Visible = false;
            List<ListViewItem> FailedToDelete = new List<ListViewItem>();
            foreach (ListViewItem item in listView_Attachments.SelectedItems)
            {
                if (pictureBox_ImageDisplay.Image != null) pictureBox_ImageDisplay.Image.Dispose();
                pictureBox_ImageDisplay.Image = null;
                string attachmentPath = item.SubItems[1].Text;
                if (File.Exists(attachmentPath))
                {
                    try
                    {
                        File.Delete(attachmentPath);
                        listView_Attachments.Items.Remove(item);
                    }
                    catch 
                    {
                        FailedToDelete.Add(item);
                    }
                }
            }
            if (FailedToDelete.Count != 0)
            {
                Wait(1000);
                int finalFaliure = 0;
                FailedToDelete.ForEach(item => {
                    try
                    {
                        File.Delete(item.SubItems[1].Text);
                        listView_Attachments.Items.Remove(item);
                    }
                    catch 
                    {
                        finalFaliure++;
                    }
                });
                if (finalFaliure != 0) MessageBox.Show($"Failed to delete {finalFaliure} items.");
            }
        }
        public void Wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
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
            addPictureForm.SetRevision(ORevision);
            addPictureForm.PicturePathDelegate = new StringHashSetDelegate(AddAttachmentPath);
            addPictureForm.ShowDialog();
        }
        private void Button_AddKW_Click(object sender, EventArgs e)
        {
            AddKW AddKnowldgewareForm = new AddKW();
            AddKnowldgewareForm.SetRevision(ORevision, "");
            AddKnowldgewareForm.kwForm_Input.KWPathDelegate = new StringHashSetDelegate(AddAttachmentPath);
            AddKnowldgewareForm.ShowDialog();
        }
        private void AddAttachmentPath(HashSet<string> value)
        {
            foreach(string line in value)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { Path.GetFileName(line), line });
                listView_Attachments.Items.Add(listViewItem);
            }
        }
        private void LoadAttachments()
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
            foreach (ExpandedDocument theObject in FDLV_SelectedList.SelectedObjects)
            {
                FirstLevelItems.Remove(theObject);
                theObject.NewDocInfo = new RevisionClass.DocInfo()
                {
                    RD_Value = 5,
                    NewVersion = null,
                    OldVersion = null,
                };
            }
            FOLV_LibraryList.AddObjects(FDLV_SelectedList.SelectedObjects);
            FDLV_SelectedList.RemoveObjects(FDLV_SelectedList.SelectedObjects);
        }
    }
}
