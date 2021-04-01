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

namespace VerManagerLibrary
{
   
    public partial class VersionManagerForm : Form
    {

        public VersionManagerForm()
        {
            InitializeComponent();
            InitializeTabs();
        }

        void InitializeTabs()
        {
            VMLCoordinator coordinator = new VMLCoordinator();
            this.tabInSessionDocs1.Coordinator = coordinator;
            this.tabStoredLibrary1.Coordinator = coordinator;
        }
    }
}
