using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Report.WinForm
{
    public partial class FrmReportBaseBottom : Form
    {
        public FrmReportBaseBottom()
        {
            InitializeComponent(); 
            ToolStrip toolStrip = (ToolStrip)reportViewer1.Controls.Find("toolStrip1", true)[0];
            toolStrip.GripStyle = ToolStripGripStyle.Visible;
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(toolStrip);
            this.reportViewer1.ShowToolBar = false; 
        }

        private void FrmReportBaseBottom_Load(object sender, EventArgs e)
        {

        }
    }
}
