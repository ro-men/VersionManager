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
            foreach (string item in allFiles)
            {
                ListViewItem lvItem = listView1.Items.Add(item);
                lvItem.SubItems.Add(File.GetLastWriteTime(item).ToString());
            }

            String jsonString = JsonSerializer.Serialize(allFiles);
            System.IO.File.WriteAllText(@"D:\DATABASE\allFiles.JSON", jsonString);
        }

        public static List<string> allFiles = CreateList();
        private static List<string> CreateList()
        {
            List<string> libraryPath = new List<string> { @"K:\V2 RAZVOJ\Knjiznica AD", @"K:\V2 RAZVOJ\Knjiznica MD", @"K:\V2 TRANSFORMATOR\Osnovni Model V2" };
            List<string> ext = new List<string> { ".catproduct", ".catpart" };
            List<string> completeFileList = new List<string>();
            foreach (string dir in libraryPath)
            {
                IEnumerable<string> myFiles = Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories)
                    .Where(s => ext.Contains(Path.GetExtension(s).ToLower()));
                completeFileList.AddRange(myFiles.ToList());
            }
            return completeFileList;
        }
    }
}
