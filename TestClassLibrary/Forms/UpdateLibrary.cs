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
            List<FileInfo> fileInfos = new List<FileInfo>();
            VMLCoordinator.newFileKeys.ForEach(item => fileInfos.Add(new FileInfo(item)));
            fastDataListView_new.SetObjects(fileInfos);
            VMLCoordinator.deletedFilesKeys.ForEach(item => {
                string[] row = {Path.GetFileName(item), Path.GetDirectoryName(item)};
                var listViewItem = new ListViewItem(row);
                listView_DeletedDoc.Items.Add(listViewItem);
            });
            fastDataListView_modified.SetObjects(VMLCoordinator.LibraryDocumentDictionary.Where(kvp => kvp.Value.DataBaseFileDate != kvp.Value.LocalFileDate));
        }
    }
}
