using Nikita.Base.DbSchemaReader.DataSchema;
using Nikita.Assist.DBManager.DAL;
using Nikita.Assist.DBManager.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;

namespace Nikita.Assist.DBManager
{
    public partial class FrmDbLogin : Form
    {
        /// <summary>
        /// 连接对象类
        /// </summary>
        private DbConnectDAL m_dalConn;

        /// <summary>
        /// 表
        /// </summary>
        private DataTable m_dt;


        /// <summary>
        /// 服务器下的所有DB
        /// </summary>
        private DataTable m_ServerDB;


        public FrmDbLogin(SqlType dbType)
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

        public string Port
        {
            get;
            private set;
        }

        public string PWD
        {
            get;
            private set;
        }

        public string Server
        {
            get;
            private set;
        }

        public string UID
        {
            get;
            private
            set;
        }

        /// <summary>数据库类型
        ///  数据库类型
        /// </summary>
        private SqlType dbType
        {
            get;
            set;
        }
        /// <summary>加载类型
        ///  加载类型
        /// </summary>
        public List<string> LoadType
        {
            get;
            set;
        }
        /// <summary>加载数据库
        ///  加载数据库
        /// </summary>
        public DataTable LoadDatabase
        {
            get;
            set;
        }


        private string[] LoadTypeAry = { "表", "视图", "存储过程&函数" };

        /// <summary>绑定
        /// 绑定
        /// </summary>
        private void BindComboBox()
        {
            m_dt = m_dalConn.GetList("Remark='" + this.dbType + "'").Tables[0];
            if (m_dt.Rows.Count > 0)
            {
                cboServer.DisplayMember = @"IP";
                cboServer.ValueMember = @"IP";
                cboServer.DataSource = m_dt;
            }
        }

        /// <summary>取消
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>连接
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
                return;
#if !DEBUG
            if (txtDB.Text.Trim() == string.Empty)
            {
                m_ServerDB = DataBaseManager.GetDataBase(dbType, BuildConn(this.dbType));
                if (m_ServerDB.Rows.Count > 5)
                {
                    dialog = MessageBox.Show(@"一共需要加载【" + m_ServerDB.Rows.Count + "】个数据库，需要时间较长，建议按需加载", "提示", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        btnSelectDB_Click(null, null);
                        return;
                    }
                }
            }
#endif
#if  DEBUG
            LoadDatabase = new DataTable();
            LoadDatabase.Columns.Add("name", typeof(string));
            DataRow dr = LoadDatabase.NewRow();
            dr["name"] =GlobalHelp.DefauleDatabase;
            LoadDatabase.Rows.Add(dr);
#endif

            bool flag = TestConn(this.dbType);
            if (flag)
            {
                if (chkRem.Checked)
                {
                    DataSet ds = m_dalConn.GetList("IP='" + cboServer.Text.Trim() + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        m_dalConn.DeleteByCond("IP='" + cboServer.Text.Trim() + "'");
                    }
                    DbConnect model = new DbConnect
                    {
                        IP = cboServer.Text.Trim(),
                        Pwd = DESEncryptHelper.Encrypt(txtPassword.Text.Trim(), "test332211"),
                        User = cboUser.Text.Trim(),
                        Remark = this.dbType.ToString(),
                        CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                    m_dalConn.Add(model);
                }
                DBConn = BuildConn(this.dbType);
                Server = cboServer.Text.Trim();
                UID = cboUser.Text.Trim();
                PWD = txtPassword.Text.Trim();
                if (this.dbType == SqlType.MySql)
                {
                    Port = cboLogin.Text.Trim();
                }
                List<string> lstLoadType = new List<string>();
                foreach (CCBoxItem item in chkAllowType.CheckedItems)
                {
                    lstLoadType.Add(item.Name);
                }
                LoadType = lstLoadType;

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(@"连接失败");
            }
        }

        /// <summary>构建数据库连接字符串
        /// 构建数据库连接字符串
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        private string BuildConn(SqlType dbType)
        {
            string strConn = string.Empty;
            switch (dbType)
            {
                case SqlType.SqlServer:
                    strConn = @"server=" + cboServer.Text.Trim() + ";uid=" + cboUser.Text.Trim() + ";pwd=" + txtPassword.Text.Trim() + ";database=master";
                    break;

                case SqlType.MySql:
                    strConn = @" server=" + cboServer.Text.Trim() + ";Port=" + cboLogin.Text.Trim() + ";database=mysql;uid=" + cboUser.Text.Trim() + ";pwd=" + txtPassword.Text.Trim() + ";charset=utf8";
                    break;

                case SqlType.Oracle:
                    break;
            }
            return strConn;
        }

        private void cboServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] drs = m_dt.Select("IP='" + cboServer.Text.Trim() + "'");
            if (drs.Length > 0)
            {
                cboUser.Text = drs[0]["User"].ToString();
                txtPassword.Text = DESEncryptHelper.Decrypt(drs[0]["Pwd"].ToString(), "test332211");
            }
        }

        /// <summary>检测输入是否合法
        /// 检测输入是否合法
        /// </summary>
        /// <returns>bool</returns>
        private bool CheckInput()
        {
            bool falg = true;
            if (cboServer.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"请输入服务器名称");
                cboServer.Select();
                falg = false;
            }
            else if (cboLogin.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"请选择登录验证");
                cboLogin.Select();
                falg = false;
            }
            else if (cboUser.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"请输入用户名");
                cboUser.Select();
                falg = false;
            }
            else if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"请输入密码");
                txtPassword.Select();
                falg = false;
            }

            if (chkAllowType.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"请选择加载类型");
                chkAllowType.Select();
                falg = false;
            }
            return falg;
        }

        private void frmDictionaryLogin_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < LoadTypeAry.Length; i++)
            {
                CCBoxItem item = new CCBoxItem(LoadTypeAry[i], i);
                chkAllowType.Items.Add(item);
            }
            chkAllowType.MaxDropDownItems = 3;
            chkAllowType.DisplayMember = @"Name";
            chkAllowType.ValueSeparator = @",";
            chkAllowType.SetItemChecked(0, true);
            m_dt = new DataTable();
            m_dalConn = new DbConnectDAL();
            if (this.dbType == SqlType.MySql)
            {
                label2.Text = @"端口号:";
                cboLogin.Items.Clear();
                cboLogin.Text = @"3306";
            }
            else if (this.dbType == SqlType.SqlServer)
            {
                cboLogin.SelectedIndex = 0;
            }
            BindComboBox();
            this.cboServer.SelectedIndexChanged += cboServer_SelectedIndexChanged;

            if (cboServer.Items.Count > 0)
            {
                cboServer_SelectedIndexChanged(null, null);
            }
            else
            {
                this.cboServer.Select();
            }

#if DEBUG
            btnOK_Click(null, null);
#endif
        }

        /// <summary>测试连接
        /// 测试连接
        /// </summary>
        /// <param name="dbType">dbType</param>
        /// <returns>bool</returns>
        private bool TestConn(SqlType dbType)
        {
            bool blnIsConnect = false;
            string strConn = BuildConn(dbType);
            IDBHelper dbHelper = DataBaseManager.GetDbHelper(dbType, strConn);
            if (dbHelper != null)
            {
                blnIsConnect = dbHelper.TestConn();
            }
            return blnIsConnect;
        }

        private void btnSelectDB_Click(object sender, EventArgs e)
        {
            if (m_ServerDB == null || m_ServerDB.Rows.Count == 0)
            {
                m_ServerDB = DataBaseManager.GetDataBase(dbType, BuildConn(this.dbType));
            }

            FrmSelectDataBases frmSelectDb = new FrmSelectDataBases(m_ServerDB);
            if (frmSelectDb.ShowDialog() == DialogResult.OK)
            {
                LoadDatabase = frmSelectDb.LoadDataBase;
                foreach (DataRow dr in LoadDatabase.Rows)
                {
                    txtDB.Text += dr[0] + @",";
                }
                txtDB.Text = txtDB.Text.TrimEnd(',');
            }
        }
    }
}