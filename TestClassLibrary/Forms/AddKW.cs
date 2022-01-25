using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerManagerLibrary_ClassLib
{
    public partial class AddKW : Form
    {
        public delegate void FormDelegate(Form parentForm);
        public FormDelegate FormDelegateCallBack;
        private RevisionClass revision;
        public AddKW()
        {
            InitializeComponent();
        }
        public void SetRevision(RevisionClass x, string KWPath)
        {
            revision = x;
            this.FormDelegateCallBack += new FormDelegate(kwForm_Input.SetParent);
            FormDelegateCallBack(this);
            kwForm_Input.InitialInput(KWPath, false, revision);
        }
    }
}
