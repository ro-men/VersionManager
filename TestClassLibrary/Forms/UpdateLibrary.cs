using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;


namespace VerManagerLibrary
{
    public partial class UpdateLibrary : Form
    {
        public UpdateLibrary()
        {
            InitializeComponent();
            fillList();
        }
        private void fillList()
        {
            VMLCoordinator.dataBaseMissingKeys.ForEach(item => 
            { 
                FileInfo fileInfo     
                listView_MissingDoc.Items.Add(item);
            });
            VMLCoordinator.deletedFilesKeys.ForEach(item => listView_DeletedDoc.Items.Add(item));
        }
        private void button_AutoUpdate_Click(object sender, EventArgs e)
        {
            VMLCoordinator.UpdateLibrary(VMLCoordinator.dataBaseMissingKeys);
            this.Close();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
