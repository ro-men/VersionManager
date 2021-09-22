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
using INFITF;
using System.Runtime.InteropServices;
using ProductStructureTypeLib;
using BrightIdeasSoftware;

namespace VerManagerLibrary_ClassLib
{
   
    public partial class VersionManagerForm : Form
    {

        public VersionManagerForm()
        {
            InitializeComponent();
            tabStoredLibrary1.switchTabCallBack = new SwitchTab(this.SwitchTabCallBackFn);
        }
        public delegate void SwitchTab(int index);
        private void SwitchTabCallBackFn(int index)
        {
            tabControl_Main.SelectedIndex = index;
        }
    }

}

