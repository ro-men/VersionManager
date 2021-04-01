using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace VerManagerLibrary
{
    public partial class VmlDemoTab : UserControl
    {
        public VMLCoordinator Coordinator
        {
            get { return coordinator; }
            set
            {
                coordinator = value;
                if (value != null)
                {
                    this.InitializeTab();
                }
            }
        }
        private VMLCoordinator coordinator;
        private TreeListView treeListView;
        protected virtual void InitializeTab() { }
        public TreeListView TreeListView
        {
            get { return this.treeListView; }
            protected set { this.treeListView = value; }
        }
    }
}
