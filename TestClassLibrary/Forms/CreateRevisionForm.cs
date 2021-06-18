using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace VerManagerLibrary
{

    public partial class FormCreateRevision : Form
    {
        IList selectedItems;
        RevisionClass oRevision = new RevisionClass();
        public FormCreateRevision(IList selectedItems)
        {
           InitializeComponent();
           this.selectedItems = selectedItems;
        }

        private void FormAddNewError_Load(object sender, EventArgs e)
        {
            oRevision.CreateRevisionID();
            SetupColumns();
            this.FDLV_SelectedList.SetObjects(selectedItems);
            this.FDLV_LibraryList.SetObjects(VMLCoordinator.LibraryDocumentDictionary.Values.Where(x => !selectedItems.Contains(x)));
            List<string> selectedNomenclatureValues = new List<string>();
            foreach (DocumentClass documentClass in selectedItems) {
                documentClass.CurentRevisionStatus = true;
                selectedNomenclatureValues.Add(documentClass.PartName);
            }
                      
            this.FDLV_Library_PartName.MakeEqualGroupies(selectedNomenclatureValues.ToArray(), selectedNomenclatureValues.ToArray(), new object[] { }, new string[] { }, new string[] { });
            this.FDLV_LibraryList.ShowGroups = true;
            this.FDLV_LibraryList.BuildList();

            ComboBoxSetup();

            textBoxRevisionID.Text = oRevision.RevisionID;
        }
        private void SetupColumns()
        {
            this.FDLV_Library_Resolve.AspectGetter = delegate (object x) { return ((DocumentClass)x).CurentRevisionStatus;};
            this.FDLV_Library_Resolve.AspectPutter = delegate (object x, object newValue) {((DocumentClass)x).CurentRevisionStatus = (bool)newValue;};
            this.FDLV_Library_CurrentRevisionStatus.AspectGetter = delegate (object x) {
                if (!this.FDLV_LibraryList.CheckedObjects.Contains(x))
                {
                    this.FDLV_Library_Resolve.PutCheckState(x, CheckState.Unchecked);
                    return "";
                }
                else
                {
                    if (((DocumentClass)x).CurentRevisionStatus) return "Solved";
                    return "Unsolved";
                };
            };
            this.FDLV_Library_CurrentRevisionStatus.ImageGetter = delegate (object x) {
                if (!this.FDLV_LibraryList.CheckedObjects.Contains(x))
                {
                    return -1;
                }
                else
                {
                    if (((DocumentClass)x).CurentRevisionStatus) return 0;
                    return 1;
                };
            };
            this.FDLV_Selected_Resolve.AspectGetter = delegate (object x) { return ((DocumentClass)x).CurentRevisionStatus; };
            this.FDLV_Selected_Resolve.AspectPutter = delegate (object x, object newValue) { ((DocumentClass)x).CurentRevisionStatus = (bool)newValue; };
            this.FDLV_Selected_CurrentRevisionStatus.AspectGetter = delegate (object x) {
                if (((DocumentClass)x).CurentRevisionStatus) return "Solved";
                return "Unsolved";
            };
            this.FDLV_Selected_CurrentRevisionStatus.ImageGetter = delegate (object x) {
                if (((DocumentClass)x).CurentRevisionStatus) return 0;
                return 1;
            };
            SizeLastColumn(this.FDLV_LibraryList);
            SizeLastColumn(this.FDLV_SelectedList);
        }

        private void textBoxFilterPartName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFilterPartName.TextLength > 1)
            {
                FDLV_LibraryList.ModelFilter = TextMatchFilter.Contains(this.FDLV_LibraryList, textBoxFilterPartName.Text);
            }
            else {
                FDLV_LibraryList.ModelFilter = null;
            }
        }
        private void ComboBoxSetup() 
        {
            List<string> headers = new List<string>();
            foreach (ColumnHeader columnHeader in FDLV_LibraryList.Columns) {
                headers.Add(columnHeader.Text);
            }
            comboBoxFilterColumn.Items.AddRange(headers.ToArray());
            comboBoxFilterColumn.SelectedIndex = 0;
            FDLV_LibraryList.AllColumns[0].Searchable = true;
        }
        private void comboBoxFilterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            FDLV_LibraryList.AllColumns.ForEach(x => x.Searchable = false);
            FDLV_LibraryList.AllColumns[comboBoxFilterColumn.SelectedIndex].Searchable = true;
        }

        private void fastDataListView_Library_Resize(object sender, EventArgs e)
        {
            SizeLastColumn((ListView)sender);
        }
        private void SizeLastColumn(ListView lv)
        {
            lv.Columns[lv.Columns.Count - 1].Width = -2;
        }

        private void button_CreateRevision_Click(object sender, EventArgs e)
        {
            foreach (DocumentClass documentClass in selectedItems) {
                if (oRevision.OtherDocuments.ContainsKey(documentClass.Key)) oRevision.RemoveOtherDocument(documentClass.Key);
                if (oRevision.Siblings.Contains(documentClass.Key)) oRevision.RemoveSibling(documentClass.Key);
                oRevision.AddCoreDocument(documentClass.Key, documentClass.CurentRevisionStatus);
                if (documentClass.CurentRevisionStatus)
                {
                    documentClass.AddRevision(oRevision.RevisionID, 1);
                    FillParents(documentClass);
                } 
                else
                {
                    documentClass.AddRevision(oRevision.RevisionID, 0);
                    FillParents(documentClass);
                }

            }
            IList CheckedItems = this.FDLV_LibraryList.CheckedObjects;
            foreach (DocumentClass documentClass in CheckedItems)
            {
                if (oRevision.Siblings.Contains(documentClass.Key)) oRevision.RemoveSibling(documentClass.Key);
                if (!oRevision.CoreDocuments.ContainsKey(documentClass.Key)) { oRevision.AddOtherDocument(documentClass.Key, documentClass.CurentRevisionStatus); }
                if (documentClass.CurentRevisionStatus)
                {
                    documentClass.AddRevision(oRevision.RevisionID, 3);
                    FillParents(documentClass);
                }
                else
                {
                    documentClass.AddRevision(oRevision.RevisionID, 2);
                    FillParents(documentClass);
                }
            }

            void FillParents(DocumentClass documentClass) {
                Stack<DocumentClass> documentClasses = new Stack<DocumentClass>();

                documentClasses.Push(documentClass);
                while (documentClasses.Count > 0)
                {
                    DocumentClass currentDocumentClass = documentClasses.Pop();
                    currentDocumentClass.ParentsDict.Values.ToList().ForEach(x => documentClasses.Push(x));
                    currentDocumentClass.AddRevision(oRevision.RevisionID, 4);
                    if ((!oRevision.CoreDocuments.ContainsKey(currentDocumentClass.Key)) && (!oRevision.OtherDocuments.ContainsKey(currentDocumentClass.Key))) { oRevision.AddSibling(currentDocumentClass.Key);}
                }
            };

            VMLCoordinator.StoreDocumentClassesDict(VMLCoordinator.LibraryDocumentDictionary);
            VMLCoordinator.RevisionDictionary.Add(oRevision.RevisionID, oRevision);
            VMLCoordinator.StoreRevisionDict(VMLCoordinator.RevisionDictionary);
            this.Close();
        }
    }
}
