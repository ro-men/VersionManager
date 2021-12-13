using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using INFITF;
using ProductStructureTypeLib;
using MECMOD;
using KnowledgewareTypeLib;

namespace VerManagerLibrary_ClassLib
{
    public partial class RegisterMissingDataBaseInput : Form
    {

        public RegisterMissingDataBaseInput()
        {
            InitializeComponent();
        }

        public void SetupForm(List<DocumentClass> documentClasses) 
        {
            OLV_SelectedDocuments.SetObjects(documentClasses);
            clmn_Lista_Dirty.GroupKeyGetter = delegate (object rowObject) {
                DocumentClass document = (DocumentClass)rowObject;
                if (document.Modified) return document.Modified;
                return "";
            };
            SetButtons();
        }
        private void SetButtons() 
        {
            if (CheckForDownload())
            {
                button_DownloadNewer.Enabled = true;
                button_Read.Enabled = false;
                button_Register.Enabled = false;
            }
            else
            {
                button_DownloadNewer.Enabled = false;
                if (!CheckInMemory())
                {
                    button_Read.Enabled = true;
                    button_Register.Enabled = false;
                }
                else
                {
                    button_Read.Enabled = false;
                    button_Register.Enabled = true;
                }
            }
        }
        private bool CheckForDownload() 
        {
            bool boolValue = false;
            foreach (DocumentClass documentClass in OLV_SelectedDocuments.Objects)
            {
                if (!documentClass.OnLocalDisc || documentClass.ServerFileDate > documentClass.LocalFileDate) {
                    boolValue = true;
                    break;
                }
            }
            return boolValue;
        }
        private bool CheckInMemory()
        {
            bool boolValue = true;
            foreach (DocumentClass documentClass in OLV_SelectedDocuments.Objects)
            {
                if (!documentClass.InSession)
                {
                    boolValue = false;
                    break;
                }
            }
            return boolValue;
        }

        private void button_Read_Click(object sender, EventArgs e)
        {
            List<DocumentClass> toRead = new List<DocumentClass>();
            foreach (DocumentClass documentClass in OLV_SelectedDocuments.Objects)
            {
                if (!documentClass.InSession) {
                    toRead.Add(documentClass);
                }
            }
            VMLCoordinator.ReadList(toRead);
            MessageBox.Show("Documents are in session.","Process done.");
            OLV_SelectedDocuments.RefreshObjects(toRead);
            SetButtons();
        }

        private void button_Register_Click(object sender, EventArgs e)
        {
            List<DocumentClass> toRegister = new List<DocumentClass>();
            foreach (DocumentClass documentClass in OLV_SelectedDocuments.Objects)
            {
                    toRegister.Add(documentClass);
            }
            if (toRegister.Where(x => x.NewNomenclature == null).Count() == 0)
            {
                foreach (DocumentClass documentClass in toRegister)
                {
                    UpdateFileParameters(documentClass);
                    try
                    {
                        VMLCoordinator.DocumentDictionary.Add(documentClass.Key, documentClass);
                    }
                    catch (Exception)
                    {

                        VMLCoordinator.DocumentDictionary[documentClass.Key]= documentClass;
                    }
                }
                VMLCoordinator.StoreDocumentClassesDict();
                foreach (DocumentClass documentClass in toRegister)
                {
                    documentClass.UploadDoc();
                }
                MessageBox.Show("Spremljeno je " + toRegister.Count + " dokumenata.", "Saved", MessageBoxButtons.OK);
                OLV_SelectedDocuments.RefreshSelectedObjects();
            }
            else
            {
                MessageBox.Show("Documents without \"Nomenclature\" can not be uploaded. Set all \"Nomenclature\" before upload.", "Unable to upload document.", MessageBoxButtons.OK);
            }
            this.Close();
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
    }
}
