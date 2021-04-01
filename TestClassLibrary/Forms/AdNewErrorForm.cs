using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerManagerLibrary
{
    public partial class FormAddNewError : Form
    {
        public FormAddNewError()
        {
            InitializeComponent();
        }

        private void FormAddNewError_Load(object sender, EventArgs e)
        {
            ErrorClass errorClass = new ErrorClass("Ad Comment");
            DocumentClass coreDocument = TabInSessionDocs.selectedDocumentItem;
            textBoxSelectedItem.Text = coreDocument.FullName;
            textBoxErrorID.Text = errorClass.ErrorID;
        }

    }
}
