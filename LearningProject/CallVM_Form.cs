using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VerManagerLibrary_ClassLib;

namespace LearningProject
{

    //forma koja poziva "VerManager_ClassLibrary" - glavni class library koji planiramo registrirati i pozvati pomoću VBA_App iz CATIA-e
    public partial class CallVM_Form : Form
    {
        public CallVM_Form()
        {
            InitializeComponent();
        }

        private void CallVM_Form_Load(object sender, EventArgs e)
        {
            var newForm = new VerManagerLibrary_ClassLib.VersionManagerForm();
            newForm.Visible = true;
        }
    }
}
