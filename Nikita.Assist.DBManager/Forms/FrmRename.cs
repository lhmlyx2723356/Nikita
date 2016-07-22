using System;
using System.Windows.Forms;

namespace Nikita.Assist.DBManager
{
    public partial class FrmRename : Form
    {
        public FrmRename()
        {
            InitializeComponent();
            txtRename.Select();
        }

        public string Rename
        {
            get;
            private set;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtRename.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入名称");
                return;
            }
            Rename = txtRename.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }
    }
}