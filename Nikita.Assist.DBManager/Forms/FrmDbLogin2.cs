using Nikita.Base.DbSchemaReader.DataSchema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.DBManager
{
    public partial class FrmDbLogin2 : Form
    {
        public FrmDbLogin2(SqlType dbType)
        {
            InitializeComponent();
            this.dbType = dbType;
            this.Text = dbType + "连接管理";
        }

        /// <summary>
        /// 数据连接字符串
        /// </summary>
        public string DBConn
        {
            get;
            private set;
        }

        /// <summary>数据库类型
        ///  数据库类型
        /// </summary>
        private SqlType dbType
        {
            get;
            set;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
                return;
            bool flag = TestConn(this.dbType);
            if (flag)
            {
                DBConn = txtPath.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "数据库文件|*.db";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = "Data Source=" + dialog.FileName;
            }
        }

        /// <summary>检测输入是否合法
        /// 检测输入是否合法
        /// </summary>
        /// <returns>bool</returns>
        private bool CheckInput()
        {
            bool falg = true;
            if (txtPath.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请选择数据库");
                btnSelect_Click(null, null);
                falg = false;
            }
            return falg;
        }

        /// <summary>测试连接
        /// 测试连接
        /// </summary>
        /// <param name="strType">strType</param>
        /// <returns>bool</returns>
        private bool TestConn(SqlType dbType)
        {
            bool blnIsConnect = false;
            string strConn = txtPath.Text.Trim();
            IDBHelper dbHelper = DataBaseManager.GetDbHelper(dbType, strConn);
            if (dbHelper != null)
            {
                blnIsConnect = dbHelper.TestConn();
            }
            return blnIsConnect;
        }
    }
}