using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.Logger
{
    public partial class FrmLoggerInit : Form
    {
        /// <summary>构造函数
        /// 构造函数
        /// </summary>
        public FrmLoggerInit()
        {
            InitializeComponent();
        }

        /// <summary>数据库名
        /// 数据库名
        /// </summary>
        private string m_strDBName;

        /// <summary>添加连接
        /// 添加连接
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnCon_Click(object sender, EventArgs e)
        {
            if (cboLogType.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请选择初始化日志类型");
                return;
            }
            FrmDbLogin login = new FrmDbLogin(cboLogType.Text);
            if (login.ShowDialog() == DialogResult.OK)
            {
                txtConnection.Text = login.strConn;
                m_strDBName = login.DBName;
                txtInitInfo.Text = GetCreateLogTableSql(cboLogType.Text);
            }
            else
            {
                txtInitInfo.Text = txtConnection.Text = string.Empty;
            }
        }

        /// <summary>
        /// 初始化日志表
        /// </summary>
        /// <param name="strExistsTbSql">判断日志表是否存在的sql语句</param>
        /// <param name="strTbName">表名</param>
        /// <param name="strDbName">数据库名</param>
        /// <returns></returns>
        private bool InitLogTable(string strExistsTbSql, string strTbName, string strDbName)
        {
            bool flag = true;
            string strConn = DESEncryptHelper.Decrypt(txtConnection.Text.Trim(), "test332211");
            IDBHelper dbHelper = LoggerHelper.GetDBHelper(this.cboLogType.Text, strConn);
            if (dbHelper != null)
            {
                dbHelper.CreateCommand(strExistsTbSql);
                int intResult = dbHelper.ExecuteQuery().Rows.Count; 
                if (intResult > 0)
                {
                    if (MessageBox.Show("已经存在日志记录表" + strTbName + ",是否删除重新建立？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string strDropTable = "DROP TABLE " + strTbName + "";
                        dbHelper.CreateCommand(strDropTable);
                        try
                        {
                            dbHelper.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("删除失败");
                            flag = false;
                        }
                        flag = DoCreateTable(dbHelper);
                    }
                }
                else
                {
                    flag = DoCreateTable(dbHelper);
                }
            }
            return flag;
        }

        /// <summary>
        /// 创建日志表
        /// </summary>
        /// <param name="dbHelper">dbHelper</param>
        /// <returns></returns>
        private bool DoCreateTable(IDBHelper dbHelper)
        {
            bool flag = true;
            try
            {
                string sql = GetCreateLogTableSql(this.cboLogType.Text);
                if (sql == string.Empty)
                {
                    MessageBox.Show("未能生成建表语句");
                    flag = false;
                }
                else
                {
                    dbHelper.CreateCommand(sql);
                    DataTable dt = dbHelper.ExecuteQuery();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("初始化失败");
                flag = false;
            }
            return flag;
        }

        private void FrmLoggerInit_Load(object sender, EventArgs e)
        {
            this.cboLogType.SelectedIndex = 0;
        }

        private void cboLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLogType.Text == "sqlite")
            {
                txtConnection.Visible = btnCon.Visible = false;
            }
            else
            {
                txtConnection.Visible = btnCon.Visible = true;
            }
        }

        /// <summary>执行初始化
        /// 执行初始化
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cboLogType.Text.Trim().ToLower() != "sqlite")
            {
                if (!CheckInit())
                    return;
                string strExistsTbSql = string.Empty;
                string strTbName = string.Empty;
                string strDbName = m_strDBName;
                if (cboLogType.Text.Trim().ToLower() == "mysql")
                {
                    strExistsTbSql = @"SELECT  1  FROM information_schema.TABLES WHERE table_name = 'mysqllog' AND TABLE_SCHEMA = '" + strDbName + "'";
                    strTbName = "mysqllog";
                }
                else if (cboLogType.Text.Trim().ToLower() == "sqlserver")
                {
                    /*判断表是否存在*/
                    strExistsTbSql = " SELECT 1FROM sysobjects WHERE id = OBJECT_ID(N'[SqlserverLog]') AND OBJECTPROPERTY(id,N'IsUserTable') = 1 ";
                    strTbName = "SqlserverLog";
                }
                bool flag = InitLogTable(strExistsTbSql, strTbName, m_strDBName);
                if (!flag)
                {
                    return;
                }
            }
            CreateIniFile();
            this.DialogResult = DialogResult.OK;
            StaticInfoHelper.LogType = cboLogType.Text.Trim().ToLower() + "log";
            StaticInfoHelper.ConnString = txtConnection.Text.Trim();
        }

        /// <summary>创建本地配置文件
        /// 创建本地配置文件
        /// </summary>
        private void CreateIniFile()
        {
            string filePath = Application.StartupPath + "\\" + "Log.ini";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            else
            {
                File.Delete(filePath);
                File.Create(filePath).Close();
            }
            if (cboLogType.Text.Trim().ToLower() == "sqlite")
            {
                INIOperationHelper.INIWriteValue(filePath, "LogConnection", "Connection", DESEncryptHelper.Encrypt("LogLocalDB", "test332211"));
            }
            else
            {
                INIOperationHelper.INIWriteValue(filePath, "LogConnection", "Connection", txtConnection.Text.Trim());
            }
            INIOperationHelper.INIWriteValue(filePath, "LogType", "Type", cboLogType.Text.Trim().ToLower() + "log");
        }

        /// <summary>检查初始化输入是否合法
        /// 检查初始化输入是否合法
        /// </summary>
        /// <returns></returns>
        private bool CheckInit()
        {
            bool Initflag = true;
            if (cboLogType.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请选择初始化数据库类型");
                cboLogType.Select();
                Initflag = false;
            }
            if (txtConnection.Text.Trim() == string.Empty || txtInitInfo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请选添加连接");
                Initflag = false;
            }
            return Initflag;
        }

        /// <summary>获取建表语句
        /// 获取建表语句
        /// </summary>
        /// <param name="strType">日志类型</param>
        /// <returns>建表语句</returns>
        private string GetCreateLogTableSql(string strType)
        {
            string strSql = string.Empty;
            if (strType.ToLower() == "mysql")
            {
                strSql = @"
                                    SET FOREIGN_KEY_CHECKS=0;
                                    -- ----------------------------
                                    -- Table structure for mysqllog
                                    -- ----------------------------
                                    DROP TABLE IF EXISTS `mysqllog`;
                                    CREATE TABLE `mysqllog` (
                                      `id` int(11) NOT NULL AUTO_INCREMENT,
                                      `Date` datetime DEFAULT NULL,
                                      `Level` tinyint(4) DEFAULT NULL,
                                      `Logger` varchar(50) DEFAULT NULL,
                                      `Message` varchar(8000) DEFAULT NULL,
                                      PRIMARY KEY (`id`)
                                    ) ENGINE=MyISAM DEFAULT CHARSET=utf8; 
";
            }
            else if (strType.ToLower() == "sqlserver")
            {
                strSql = @"
                                        CREATE TABLE [dbo].[SqlserverLog] (
                                        [id] int NOT NULL IDENTITY(1,1) ,
                                        [Date] datetime NULL ,
                                        [Level] tinyint NULL ,
                                        [Logger] varchar(50) NULL ,
                                        [Message] varchar(8000) NULL ,
                                         CONSTRAINT [PK_SqlserverLog] PRIMARY KEY CLUSTERED 
                                        (
	                                        [id] ASC
                                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                                        ) ON [PRIMARY]";

            }
            return strSql;
        }
    }
}
