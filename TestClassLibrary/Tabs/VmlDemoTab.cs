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
        protected virtual void InitializeTab() { }
    }
}
