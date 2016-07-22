using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;

namespace Nikita.Applications.WinFramework
{
    public partial class FrmLeft : ToolWindow
    {
        public FrmLeft()
        {
            InitializeComponent();
        }

        protected override void OnRightToLeftLayoutChanged(EventArgs e)
        {
            //treeView1.RightToLeftLayout = RightToLeftLayout;
        }
    }
}