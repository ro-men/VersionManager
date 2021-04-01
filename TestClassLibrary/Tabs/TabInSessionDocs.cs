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

namespace VerManagerLibrary
{
    public partial class TabInSessionDocs : VmlDemoTab
    {
        public TabInSessionDocs()
        {
            InitializeComponent();
        }

        protected override void InitializeTab()
        {
            SetupTree();
        }


        #region Treelistview delegatori
        //TreeListView osnovni delegatori:
        // 1. CanExpandGetter - Info da li cvor ima childrene?
        // 2. ChildrenGetter - children collection

        private void SetupTree()
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

            foreach (DocumentClass di in VMLCoordinator.InSessionDocumentDictionary.Values)
            {
                if (!di.Used)
                    roots.Add(di);
            }
            this.treeListView_Stablo.Roots = roots;
        }

        #endregion


        #region EventHandlers
        private void button1_Click(object sender, EventArgs e)
        {
            ColumnSelectionForm form = new ColumnSelectionForm();
            form.OpenOn(this.treeListView_Stablo);
        }

        private void treeListView_Stablo_SelectionChanged(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            if (this.treeListView_Stablo.SelectedItem != null) {
                string key = treeListView_Stablo.SelectedItem.SubItems[1].Text;
                selectedDocumentItem = getDocumentItemByKey(key);
                //Dictionary<string, ErrorClass> errorDict = documentInstance.ErrorsDict;
                Dictionary<string, DocumentClass> errorDict = selectedDocumentItem.ParentsDict;

                foreach (KeyValuePair<string, DocumentClass> kvp in errorDict)
                {
                    DocumentClass doc = kvp.Value;
                    ListViewItem item = new ListViewItem(new[] { kvp.Key, doc.PartName });
                    this.listView1.Items.Add(item);
                }
            }
        }

        public DocumentClass getDocumentItemByKey(string key) 
        {
            Dictionary<string, DocumentClass> documentDictionary = VMLCoordinator.InSessionDocumentDictionary;
            return documentDictionary[key];
        }

        public static DocumentClass selectedDocumentItem;

        private void buttonNewError_Click(object sender, EventArgs e)
        {
            var newForm = new VerManagerLibrary.FormAddNewError();
            newForm.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string jsonString = JsonSerializer.Serialize(VMLCoordinator.ParentsDictionary);
            string path = @"D:\DATABASE\Parents.JSON";
            File.WriteAllText(path, jsonString);
            Dictionary<string, DocumentClass> allItems = new Dictionary<string, DocumentClass>();
            allItems = allItems.Concat(VMLCoordinator.LibraryDocumentDictionary).ToDictionary(x => x.Key, x => x.Value);
            foreach(string key in allItems.Keys.ToList())
            {
                if (VMLCoordinator.InSessionDocumentDictionary.Keys.Contains(key))
                {
                    allItems.Remove(key);
                }
            }
            allItems = allItems.Concat(VMLCoordinator.InSessionDocumentDictionary).ToDictionary(x => x.Key, x => x.Value);
            jsonString = JsonSerializer.Serialize(allItems);
            path = @"D:\DATABASE\Library.JSON";
            File.WriteAllText(path, jsonString);
        }
        #endregion

    }
}
