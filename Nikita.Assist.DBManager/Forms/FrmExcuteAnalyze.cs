using Nikita.Base.DbSchemaReader.DataSchema;
 
using Nikita.Assist.DBManager.DAL;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;

namespace Nikita.Assist.DBManager
{
    public partial class FrmExcuteAnalyze : DockContentEx
    {
        private Bse_ExcuteAnalyzeDAL m_dal = new Bse_ExcuteAnalyzeDAL();
        private TreeNodeCollection m_treeNodes;

        public FrmExcuteAnalyze(TreeNodeCollection treeNodes)
        {
            InitializeComponent();

            #region 设置高亮显示TSQL属性

            txtSql.ShowEOLMarkers = false;
            txtSql.ShowHRuler = false;
            txtSql.ShowInvalidLines = false;
            txtSql.ShowMatchingBracket = true;
            txtSql.ShowSpaces = false;
            txtSql.ShowTabs = false;
            txtSql.ShowVRuler = false;
            txtSql.AllowCaretBeyondEOL = false;
            txtSql.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
            txtSql.Encoding = Encoding.GetEncoding("GB2312");

            #endregion 设置高亮显示TSQL属性

            m_treeNodes = treeNodes;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FrmExcuteAnalyzeEdit frmEdit = new FrmExcuteAnalyzeEdit();
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                FrmExcuteAnalyze_Load(null, null);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (cboServer.Text == string.Empty)
            {
                MessageBox.Show("请选择要执行的服务器");
                return;
            }
            if (txtSql.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请选择要执行的语句");
                return;
            }
            TreeNode treeNode = tvwAnalyze.SelectedNode;
            DataRow dr = treeNode.Tag as DataRow;
            if (dr != null)
            {
                string strDbType = dr["DbType"].ToString();
                string strExcuteType = dr["ExcuteType"].ToString();
                TreeNode treeNodeFind = FindTreeNodeByName(cboServer.Text.Trim());
                ServerTag serverTag = treeNodeFind.Tag as ServerTag;
                if (serverTag != null)
                {
                    SqlType dbType = GetSqlType(strDbType);
                    if (serverTag.DBType != dbType)
                    {
                        MessageBox.Show("选中的语句不支持在" + serverTag.DBType + "服务器下执行");
                        return;
                    }
                    IDBHelper dbHelper = DataBaseManager.GetDbHelper(dbType, serverTag.MasterConn);
                    switch (strExcuteType)
                    {
                        case "SQL语句":
                            dbHelper.CreateCommand(txtSql.Text.Trim());
                            break;

                        case "存储过程":
                            dbHelper.CreateStoredCommand(txtSql.Text.Trim());
                            break;
                    }
                    DataSet ds = dbHelper.ExecuteQueryDataSet();
                    if (ds.Tables.Count > 0)
                    {
                        grdResult.DataSource = ds.Tables[0];
                    }
                }
            }
        }

        private TreeNode FindTreeNodeByName(string strTreeNodeName)
        {
            TreeNode treeNode = null;
            foreach (TreeNode node in m_treeNodes)
            {
                if (node.Text == strTreeNodeName)
                {
                    treeNode = node;
                    break;
                }
            }
            return treeNode;
        }

        private void FrmExcuteAnalyze_Load(object sender, EventArgs e)
        {
            tvwAnalyze.Nodes.Clear();
            DataTable dtAnalyze = m_dal.GetList("").Tables[0];
            foreach (var item in Enum.GetValues(typeof(SqlType)))
            {
                TreeNode treeNode = tvwAnalyze.Nodes.Add(item.ToString());
                DataRow[] drs = dtAnalyze.Select("DbType='" + item.ToString() + "'");
                if (drs.Length > 0)
                {
                    foreach (DataRow drRow in drs)
                    {
                        TreeNode treeNodeChild = treeNode.Nodes.Add(drRow["ExcuteName"].ToString());
                        treeNodeChild.Tag = drRow;
                    }
                }
            }
            tvwAnalyze.ExpandAll();
            foreach (TreeNode item in m_treeNodes)
            {
                int intIndex = cboServer.Items.Add(item.Text);
            }
            if (cboServer.Items.Count > 0)
            {
                cboServer.SelectedIndex = 0;
            }
        }

        /// <summary>获取数据库类型
        /// 获取数据库类型
        /// </summary>
        /// <param name="strDbType">strDbType</param>
        /// <returns></returns>
        private SqlType GetSqlType(string strDbType)
        {
            SqlType sqlType = SqlType.SqlServer;
            foreach (SqlType item in Enum.GetValues(typeof(SqlType)))
            {
                if (item.ToString() == strDbType)
                {
                    sqlType = item;
                    break;
                }
            }
            return sqlType;
        }

        private void tvwAnalyze_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvwAnalyze.SelectedNode == null)
            {
                return;
            }
            TreeNode treeNode = tvwAnalyze.SelectedNode;
            DataRow dr = treeNode.Tag as DataRow;
            if (dr != null)
            {
                txtSql.Text = dr["ExcuteSql"].ToString();
            }
        }
    }
}