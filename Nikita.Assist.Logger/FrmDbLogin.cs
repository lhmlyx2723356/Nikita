using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Nikita.Assist.Logger.DAL;
using Nikita.Assist.Logger.Model;
using Nikita.Base.Define;
using Nikita.DataAccess4DBHelper;

namespace Nikita.Assist.Logger
{
    public partial class FrmDbLogin : Form
    {
        private SqlType sqlType;
        public FrmDbLogin(SqlType sqlType)
        {
            InitializeComponent();
            this.sqlType = sqlType;
            this.Text = sqlType + "连接管理";
        }
        DbConnectDAL dal = new DbConnectDAL();
        DataTable dt;
        public string strConn
        {
            get;
            set;
        }


        public string DBName
        {
            get;
            set;
        }
        private void frmDictionaryLogin_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            if (sqlType==SqlType.MySql)
            {
                label2.Text = "端口号:";
                cboLogin.Items.Clear();
                cboLogin.Text = "3306";
            }
            else if (sqlType==SqlType.SqlServer)
            {
                cboLogin.SelectedIndex = 0;
            }
            BindComboBox();
            this.cboServer.SelectedIndexChanged += cboServer_SelectedIndexChanged;
            this.cboServer.Select();
        }
        private void cboServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] drs = dt.Select("IP='" + cboServer.Text.Trim() + "'");
            if (drs.Length > 0)
            {
                cboUser.Text = drs[0]["User"].ToString();
                txtPassword.Text = DESEncryptHelper.Decrypt(drs[0]["Pwd"].ToString(), "test332211");

            }
        }
        private void BindComboBox()
        {
            dt = dal.GetList("Remark='" + this.sqlType.ToString().ToLower() + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                cboServer.DisplayMember = "IP";
                cboServer.ValueMember = "IP";
                cboServer.DataSource = dt;
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
                return;
            bool flag = TestConn(sqlType);
            if (flag)
            {
                if (chkRem.Checked)
                {
                    DataSet ds = dal.GetList("IP='" + cboServer.Text.Trim() + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dal.DeleteByCond("IP='" + cboServer.Text.Trim() + "'");
                    }
                    DbConnect model = new DbConnect();
                    model.CreateDate = DateTime.Now.ToString();
                    model.IP = cboServer.Text.Trim();
                    model.Pwd = DESEncryptHelper.Encrypt(txtPassword.Text.Trim(), "test332211");
                    model.User = cboUser.Text.Trim();
                    model.Remark = sqlType.ToString().ToLower();
                    dal.Add(model);
                }
                strConn = DESEncryptHelper.Encrypt(BuildConn(sqlType),"test332211");
                DBName = txtDB.Text.Trim();
                MessageBox.Show("连接成功");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("测试连接失败");
            }
        }

        private bool CheckInput()
        {
            bool falg = true;
            if (cboServer.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入服务器名称");
                cboServer.Select();
                falg = false;
            }
            else if (cboLogin.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请选择登录验证");
                cboLogin.Select();
                falg = false;
            }
            else if (cboUser.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入用户名");
                cboUser.Select();
                falg = false;
            }
            else if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入密码");
                txtPassword.Select();
                falg = false;
            }
            else if (txtDB.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入日志记录数据库名称");
                txtDB.Select();
                falg = false;
            }
            return falg;
        }

        private bool TestConn(SqlType strType)
        {
            bool blnIsConnect = false;
            string strConn = BuildConn(strType);
            IDbHelper dbHelper = LoggerHelper.GetDBHelper(strType,strConn);
            if (dbHelper != null)
            {
                blnIsConnect = dbHelper.TestConn();
            }
            return blnIsConnect;
        }

        private string BuildConn(SqlType sqlType)
        {
            string strConn = string.Empty;
            switch (sqlType)
            {
                case SqlType.MySql:
                    strConn = " server=" + cboServer.Text.Trim() + ";Port=" + cboLogin.Text.Trim() + ";database=" + txtDB.Text.Trim() + ";uid=" + cboUser.Text.Trim() + ";pwd=" + txtPassword.Text.Trim() + ";charset=utf8";
                    break;
                case SqlType.SqlServer:
                    strConn = "server=" + cboServer.Text.Trim() + ";uid=" + cboUser.Text.Trim() + ";pwd=" + txtPassword.Text.Trim() + ";database=" + txtDB.Text.Trim() + "";
                    break;
                case SqlType.Oracle:
                    break;
            }
            return strConn;
        }


    }
}