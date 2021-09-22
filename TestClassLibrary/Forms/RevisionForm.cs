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

namespace VerManagerLibrary_ClassLib
{

    public partial class RevisionForm : Form
    {
        public static IList FirstLevelItems;
        public static IList SecondLevelItems;
        public static RevisionClass ORevision;
        public static Dictionary<string, DocumentClass> Library;

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
                this.FOLV_Library_PartName.MakeEqualGroupies(selectedNomenclatureValues.ToArray(), selectedNomenclatureValues.ToArray(), new object[] { }, new string[] { }, new string[] { });
                this.FOLV_LibraryList.ShowGroups = true;
                this.FOLV_LibraryList.BuildList();
            }
        }
        public void FormInput(RevisionClass revisionObject, Dictionary<string, DocumentClass> libraryObject) {
            Library = libraryObject;
            ORevision = revisionObject;
            FirstLevelItems = Library.Values.Where(value => ORevision.RevisionDocuments.Keys.Where(
                x => ORevision.RevisionDocuments[x] == 0 | ORevision.RevisionDocuments[x] == 3).ToList().Contains(value.Key)).ToList();
            SecondLevelItems = Library.Values.Where(value => ORevision.RevisionDocuments.Keys.Where(
                x => ORevision.RevisionDocuments[x] == 1 | ORevision.RevisionDocuments[x] == 4).ToList().Contains(value.Key)).ToList();
        }
        private void SetInitalData()
        {
            textBoxRevisionID.Text = ORevision.RevisionID;
            FDLV_SelectedList.SetObjects(FirstLevelItems);
            FOLV_LibraryList.SetObjects(Library.Values.Where(x => !FirstLevelItems.Contains(x)));
            UpdateImages();
        }
        private void SetupColumns()
        {
            this.FOLV_LibraryList.BooleanCheckStateGetter = delegate (Object rowObject) {
                return !"25".Contains(((DocumentClass)rowObject).RevisionStatus(ORevision.RevisionID).ToString());
            };

            this.FOLV_LibraryList.BooleanCheckStatePutter = delegate (Object rowObject, bool newValue)
            {
                if (newValue == true)
                {
                    ORevision.AddRevisionDocument(((DocumentClass)rowObject).Key, 1);
                    ((DocumentClass)rowObject).AddRevision(ORevision.RevisionID, 1);
                }
                else
                {
                    ORevision.RemoveRevisionDocument(((DocumentClass)rowObject).Key);
                    ((DocumentClass)rowObject).RemoveRevision(ORevision.RevisionID);
                }
                return newValue;
            };

            this.FOLV_Library_Resolve.AspectGetter = delegate (object x)
            {
                return "34".Contains(((DocumentClass)x).RevisionStatus(ORevision.RevisionID).ToString());
            };
            this.FOLV_Library_Resolve.AspectPutter = delegate (object x, object newValue)
            { if (((DocumentClass)x).RevisionStatus(ORevision.RevisionID) != 2)
                {
                    if ((bool)newValue)
                    {
                        ORevision.ModifyRevisionDocument(((DocumentClass)x).Key, 4);
                        ((DocumentClass)x).ModifyRevision(ORevision.RevisionID, 4);
                    }
                    else
                    {
                        ORevision.ModifyRevisionDocument(((DocumentClass)x).Key, 1);
                        ((DocumentClass)x).ModifyRevision(ORevision.RevisionID, 1);
                    }
                }
            };
            this.FOLV_Library_CurrentRevisionStatus.AspectGetter = delegate (object x)
            {
                if (((DocumentClass)x).RevisionStatus(ORevision.RevisionID) == 5 || ((DocumentClass)x).RevisionStatus(ORevision.RevisionID) == 2)
                {
                    if (FOLV_Library_Resolve.GetCheckState(x) == CheckState.Checked) { this.FOLV_Library_Resolve.PutCheckState(x, CheckState.Unchecked); };
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
            this.FDLV_Selected_Resolve.AspectGetter = delegate (object x)
            {
                if (((DocumentClass)x).RevisionStatus(ORevision.RevisionID) < 2) return false;
                return true;
            };
            this.FDLV_Selected_Resolve.AspectPutter = delegate (object x, object newValue)
            {
                if ((bool)newValue)
                {
                    ORevision.ModifyRevisionDocument(((DocumentClass)x).Key, 3);
                    ((DocumentClass)x).ModifyRevision(ORevision.RevisionID, 3);
                }
                else
                {
                    ORevision.ModifyRevisionDocument(((DocumentClass)x).Key, 0);
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
            SizeLastColumn(this.FOLV_LibraryList);
            SizeLastColumn(this.FDLV_SelectedList);
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

        private void textBoxFilterLibraryItems_TextChanged(object sender, EventArgs e)
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

        private void comboBoxFilterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            FOLV_LibraryList.AllColumns.ForEach(x => x.Searchable = false);
            FOLV_LibraryList.AllColumns[comboBoxFilterColumn.SelectedIndex].Searchable = true;
        }

        private void fastDataListView_Library_Resize(object sender, EventArgs e)
        {
            SizeLastColumn((ListView)sender);
        }
        private void SizeLastColumn(ListView lv)
        {
            lv.Columns[lv.Columns.Count - 1].Width = -2;
        }
        public void UpdateParents()
        {
            Library.Values.Where(dClass => dClass.RevisionDict.ContainsKey(ORevision.RevisionID) && dClass.RevisionDict[ORevision.RevisionID] == 2).ToList().ForEach(
            dClass => dClass.RemoveRevision(ORevision.RevisionID));
            ORevision.RevisionDocuments.Where(kvp => kvp.Value == 2).ToList().ForEach(kvp => ORevision.RemoveRevisionDocument(kvp.Key));
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
                        currentDocumentClass.AddRevision(ORevision.RevisionID, 2);
                        ORevision.AddRevisionDocument(currentDocumentClass.Key, 2);
                    }
                }
            }
        }
        private void button_StoreRevision_Click(object sender, EventArgs e)
        {
            UpdateParents();
            VMLCoordinator.LibraryDocumentDictionary = Library;
            VMLCoordinator.StoreDocumentClassesDict();
            if (VMLCoordinator.RevisionDictionary.ContainsKey(ORevision.RevisionID))
            { VMLCoordinator.RevisionDictionary[ORevision.RevisionID] = ORevision; }
            else
            { VMLCoordinator.RevisionDictionary.Add(ORevision.RevisionID, ORevision); }
            VMLCoordinator.StoreRevisionDict();
            revisionStored(ORevision.RevisionID);
            //this.Close();
        }
        public delegate void RevisionStored(string revisionKey);
        public RevisionStored revisionStored;

        private void checkBox_FilterLibrary_CheckedChanged(object sender, EventArgs e)
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
            }

        }
        private void listView_Images_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Images.SelectedItems.Count != 0)
            {
                string path = listView_Images.FocusedItem.SubItems[1].Text;
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = Image.FromFile(path);
            }
        }

        private void listView_Images_DoubleClick(object sender, EventArgs e)
        {
            if (listView_Images.SelectedItems.Count != 0)
            {
                string path = listView_Images.FocusedItem.SubItems[1].Text;
                Process.Start(path);
            }
        }

        private void button_AddImages_Click(object sender, EventArgs e)
        {
            string sLocation = @"D:\vb_projects\TestnoPodrucje_CSharp\LearningSolution\pictures\";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select pictures you want to attach...";
            ofd.Multiselect = true;
            ofd.Filter = "JPG|*.jpg|JPEG|*.jpeg|GIF|*.gif|PNG|*.png";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK) {
                string[] files = ofd.FileNames;
                foreach(string file in files)
                {
                    int index = ORevision.RevisionPics.Count() + 1;
                    string newName = "IMG_" + ORevision.RevisionID + "_" + index.ToString() + Path.GetExtension(file);
                    while (File.Exists(sLocation + newName))
                    {
                        index++;
                        newName = "IMG_" + ORevision.RevisionID + "_" + index.ToString() + Path.GetExtension(file);
                    }
                    File.Copy(file, sLocation + newName);
                    if (!ORevision.RevisionPics.Contains(sLocation + newName))
                    {
                        ORevision.RevisionPics.Add(sLocation + newName);
                    }
                }
                UpdateImages();
            }

        }
        private void UpdateImages()
        {
            listView_Images.Items.Clear();
            if (ORevision.RevisionPics != null)
            {
                ORevision.RevisionPics.ToList().ForEach(item =>
                {
                    ListViewItem listViewItem = listView_Images.Items.Add(Path.GetFileName(item));
                    listViewItem.SubItems.Add(item);
                });
            }
        }
        private void listView_Images_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView_Images.FocusedItem != null) contextMenuStrip_Images.Show(Cursor.Position);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
            foreach (ListViewItem item in listView_Images.SelectedItems)
            {
                string imagePath = item.SubItems[1].Text;
                File.Delete(imagePath);
                ORevision.RevisionPics.Remove(imagePath);
            }
            UpdateImages();
        }
    }
}
