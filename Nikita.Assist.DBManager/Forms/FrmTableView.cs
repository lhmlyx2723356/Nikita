using Nikita.Base.DbSchemaReader.DataSchema;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;
using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Assist.DBManager
{
    public partial class FrmTableView : DockContentEx
    {
        private DatabaseSchema m_databaseSchema;
        private IDBHelper m_dbHelper;
        private SqlType m_dbType;
        private DataSet m_ds;
        private List<DataRow> m_lstCopyRow;
        private MySqlDataAdapter m_mysda;
        private SqlDataAdapter m_sda;
        private  SQLiteDataAdapter m_sqlitesda;
        private string m_strDbName;
        private string m_strServer;
        private string m_strTableName;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strServer">服务器名称</param>
        /// <param name="strDbName">数据库名称</param>
        /// <param name="strTableName">数据库表名</param>
        /// <param name="dbType">类型</param>
        public FrmTableView(ServerTag serverTag, string strDbName, string strTableName)
        {
            InitializeComponent();
            m_strTableName = strTableName;
            m_strServer = serverTag.Server;
            m_strDbName = strDbName;
            m_dbType = serverTag.DBType;
            grdTable.EditMode = DataGridViewEditMode.EditOnEnter;
            this.Text = "打开表" + "_" + m_strServer + "_" + m_strDbName + "_" + m_strTableName;
            m_databaseSchema = GlobalHelp.GetDatabaseSchema(serverTag.DBType, serverTag.Server, strDbName);
            m_dbHelper = DataBaseManager.GetDbHelper(m_dbType, m_databaseSchema.ConnectionString);
            m_lstCopyRow = new List<DataRow>();
            BindGrid(m_strTableName);
        }

        /// <summary>绑定
        /// 绑定
        /// </summary>
        /// <param name="strTableName"></param>
        private void BindGrid(string strTableName)
        {
            string strSql = "SELECT * FROM  " + strTableName;
            switch (m_dbType)
            {
                case SqlType.SqlServer:
                    SqlConnection conn = new SqlConnection(m_databaseSchema.ConnectionString);
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    m_sda = new SqlDataAdapter(cmd);
                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(m_sda);
                    m_ds = new DataSet();
                    m_sda.Fill(m_ds);
                    conn.Close();
                    //绑定数据源
                    grdTable.DataSource = m_ds.Tables[0];
                    break;

                case SqlType.Oracle:
                    break;

                case SqlType.MySql:
                    MySqlConnection myconn = new MySqlConnection(m_databaseSchema.ConnectionString);
                    MySqlCommand mycmd = new MySqlCommand(strSql, myconn);
                    m_mysda = new MySqlDataAdapter(mycmd);
                    MySqlCommandBuilder mycmdBuilder = new MySqlCommandBuilder(m_mysda);
                    m_ds = new DataSet();
                    m_mysda.Fill(m_ds);
                    myconn.Close();
                    //绑定数据源
                    grdTable.DataSource = m_ds.Tables[0];
                    break;

                case SqlType.SQLite:
                    SQLiteConnection sqliteconn = new SQLiteConnection(m_databaseSchema.ConnectionString);
                    SQLiteCommand sqlitecmd = new SQLiteCommand(strSql, sqliteconn);
                    m_sqlitesda = new SQLiteDataAdapter(sqlitecmd);
                    SQLiteCommandBuilder sqlitecmdBuilder = new SQLiteCommandBuilder(m_sqlitesda);
                    m_ds = new DataSet();
                    m_sqlitesda.Fill(m_ds);
                    sqliteconn.Close();
                    //绑定数据源
                    grdTable.DataSource = m_ds.Tables[0];
                    break;

                case SqlType.SqlServerCe:
                    break;

                case SqlType.PostgreSql:
                    break;

                case SqlType.Db2:
                    break;

                case SqlType.Accesss:
                    break;

                default:
                    break;
            }
        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            m_lstCopyRow.Clear();
            if (grdTable.SelectedRows.Count == 0)
            {
                return;
            }
            foreach (DataGridViewRow drRow in grdTable.SelectedRows)
            {
                DataRowView drView = drRow.DataBoundItem as System.Data.DataRowView;
                if (drView == null)
                {
                    continue;
                }
                m_lstCopyRow.Add(drView.Row);
            }
        }

        /// <summary>删除
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (grdTable.SelectedRows.Count == 0)
            {
                return;
            }
            foreach (DataGridViewRow item in grdTable.SelectedRows)
            {
                if (item.DataBoundItem == null)
                {
                    continue;
                }
                grdTable.Rows.Remove(item);
            }
        }

        private void cmdPaster_Click(object sender, EventArgs e)
        {
            if (m_lstCopyRow.Count == 0)
            {
                return;
            }
            if (grdTable.SelectedRows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < m_lstCopyRow.Count; i++)
            {
                DataRow drNew = m_ds.Tables[0].NewRow();
                drNew.ItemArray = m_lstCopyRow[i].ItemArray;
                m_ds.Tables[0].Rows.Add(drNew);
            }
            grdTable.DataSource = m_ds.Tables[0];
            m_lstCopyRow.Clear();
        }

        /// <summary>执行SQL
        /// 执行SQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRunSql_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = m_ds.Tables[0].GetChanges();
                if (dt == null)
                {
                    return;
                }
                switch (m_dbType)
                {
                    case SqlType.SqlServer:
                        m_sda.Update(dt);
                        m_ds.Tables[0].AcceptChanges();
                        break;

                    case SqlType.Oracle:
                        break;

                    case SqlType.MySql:
                        m_mysda.Update(dt);
                        m_ds.Tables[0].AcceptChanges();
                        break;

                    case SqlType.SQLite:
                        m_sqlitesda.Update(dt);
                        m_ds.Tables[0].AcceptChanges();
                        break;

                    case SqlType.SqlServerCe:
                        break;

                    case SqlType.PostgreSql:
                        break;

                    case SqlType.Db2:
                        break;

                    case SqlType.Accesss:
                        break;

                    default:
                        break;
                }
                BindGrid(m_strTableName);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}