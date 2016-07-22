using Nikita.Base.DbSchemaReader.DataSchema;
using System;
using System.Windows.Forms;

namespace Nikita.Assist.DBManager
{
    public partial class FrmCreateDatabase : Form
    {
        private SqlType m_dbType;

        public FrmCreateDatabase(SqlType dbType)
        {
            InitializeComponent();
            txtDbName.Select();
            this.m_dbType = dbType;
        }

        public string CreateDatabaseScript
        {
            get;
            private set;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtDbName.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"请输入数据库名称");
                txtDbName.Select();
                return;
            }
            if (txtPath.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"请选择路径");
                btnSelectPath_Click(null, null);
                return;
            }

            CreateDatabaseScript = DataBaseManager.GenCreateDatabaseScripts(m_dbType, txtDbName.Text.Trim(), txtPath.Text.Trim());
            this.DialogResult = DialogResult.OK;
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog {Description = @"选择数据库路径"};
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dialog.SelectedPath;
            }
        }

        private void tnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}