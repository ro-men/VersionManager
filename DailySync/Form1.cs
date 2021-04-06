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
using VerManagerLibrary;


namespace HelloWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            if (newAllFiles.SequenceEqual(VMLCoordinator.oldAllFiles))
            {
                textBox1.Text = "Iste";
            }
            else
            {
                List<string> newItems = newAllFiles.Except(VMLCoordinator.oldAllFiles).ToList();
                List<string> deletedItems = VMLCoordinator.oldAllFiles.Except(newAllFiles).ToList();
                textBox1.Text = "Nisu iste  " + newItems.Count + "  " + deletedItems.Count;
            }

        }

        public static List<string> newAllFiles = CreateNewAllFilesList();
        public static List<string> megaTree = ReadMegaTree();

        private static List<string> ReadMegaTree()
        {
            List<string> completeFileList = new List<string>();
            if (File.Exists(@"C:\Users\jagarinecr\Desktop\SyncTest\megaTree.JSON"))
            {
                string oldAllFilesPath = @"C:\Users\jagarinecr\Desktop\SyncTest\megaTree.JSON";
                string jsonString = System.IO.File.ReadAllText(oldAllFilesPath);
                completeFileList = JsonSerializer.Deserialize<List<string>>(jsonString);
            }
            return completeFileList;
        }
        private static List<string> CreateNewAllFilesList()
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
