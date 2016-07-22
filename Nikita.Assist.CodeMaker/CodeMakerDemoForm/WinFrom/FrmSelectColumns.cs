using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.CodeMaker.CodeMakerDemoForm.WinFrom
{
    public partial class FrmSelectColumns : Form
    {
        public FrmSelectColumns()
        {
            InitializeComponent();
        }

        private List<string> m_lstList;
        public List<string> SelectList { get; set; }

        public FrmSelectColumns(List<string> lstList )
        {
            InitializeComponent();
            m_lstList =  lstList;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvwColumns.Nodes)
            {
                node.Checked = true;
            }
        }

        private void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvwColumns.Nodes)
            {
                node.Checked = !node.Checked;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvwColumns.Nodes)
            {
                node.Checked =false;
            }
        }
    }
}
