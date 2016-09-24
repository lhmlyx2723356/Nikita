using Nikita.Base.DbSchemaReader.DataSchema;
 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using ICSharpCode.TextEditor.Document;


namespace Nikita.Assist.DBManager
{
    public partial class FrmDataBaseQueryBatch : Form
    {
        private IDBHelper m_dbHelper;
        private DataSet m_ds;
        private List<ServerTag> m_lstServerTag;

        public FrmDataBaseQueryBatch(List<ServerTag> lstServerTag)
        {
            InitializeComponent();
            txtSql.ShowEOLMarkers = false;
            txtSql.ShowHRuler = false;
            txtSql.ShowInvalidLines = false;
            txtSql.ShowMatchingBracket = true;
            txtSql.ShowSpaces = false;
            txtSql.ShowTabs = false;
            txtSql.ShowVRuler = false;
            txtSql.AllowCaretBeyondEOL = false;
            txtSql.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("SQL");
            txtSql.Encoding = Encoding.GetEncoding("GB2312");

            bckWorker.WorkerReportsProgress = true;
            this.m_lstServerTag = lstServerTag;

            #region 绑定TreeView
            tvwDBList.Nodes.Clear();
            foreach (var sqlType in Enum.GetNames(typeof(SqlType)))
            {
                TreeNode treeNode = tvwDBList.Nodes.Add(sqlType);

                List<ServerTag> lstServerTagTmp = lstServerTag.Where(t => t.DBType.ToString() == sqlType.ToString()).ToList();
                if (lstServerTagTmp.Count > 0)
                {
                    foreach (ServerTag item in lstServerTagTmp)
                    {
                        TreeNode treeNodeServer = treeNode.Nodes.Add(item.Server);
                        treeNodeServer.Tag = item;
                        foreach (DataRow dr in item.ServerDBNames.Rows)
                        {
                            TreeNode treeDb = treeNodeServer.Nodes.Add(dr[0].ToString());
                            treeDb.Tag = item.AllDatabaseSchema.FirstOrDefault(t => t.Key == dr[0].ToString()).Value.ConnectionString;
                        }
                    }
                }
            }
            tvwDBList.ExpandAll();
            #endregion
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] obj = e.Argument as object[];
            if (obj != null)
            {
                List<TreeNode> lstTreeNodeDb = obj[0] as List<TreeNode>;
                string strSql = obj[1].ToString();
                e.Result = Run(lstTreeNodeDb, strSql);
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataSet ds = e.Result as DataSet;
            txtRunMessage.Text = m_dbHelper.ReturnRunMessage();
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataTable dt in ds.Tables)
                {
                    TabPage tabPage = TabControlHelper.AddTabPage(tabResult);
                    DataGridView datagridview = TabControlHelper.AddDataGridViewToTabPage(tabPage);
                    datagridview.RowPostPaint += dgv_RowPostPaint;
                    datagridview.DataSource = dt;
                }
            }
            if (tabResult.TabPages.Count > 1)
            {
                tabResult.SelectedTab = tabResult.TabPages[1];
            }
            cmdRun.Enabled = true;
            toolStripProgressBar1.Visible = false;
        }

        /// <summary>执行
        /// 执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRun_Click(object sender, EventArgs e)
        {
            m_ds = new DataSet();
            List<TreeNode> lstTreeNodeCheck = TreeViewHelper.GetAllCheckNodes(this.tvwDBList);
            List<TreeNode> lstTreeNodeDb = new List<TreeNode>();
            foreach (TreeNode item in lstTreeNodeCheck)
            {
                if (item.Tag != null && (item.Tag as ServerTag) == null)
                {
                    lstTreeNodeDb.Add(item);
                }
            }
            if (lstTreeNodeDb.Count == 0)
            {
                MessageBox.Show(@"请勾选要执行的数据库");
                return;
            }

            if (txtSql.Text.Trim().Length == 0)
            {
                MessageBox.Show(@"请输入要执行的脚本语句");
                txtSql.Select();
                return;
            }

            foreach (TabPage item in tabResult.TabPages)
            {
                if (item.Name != "tabPage1")
                {
                    tabResult.TabPages.Remove(item);
                }
            }
            cmdRun.Enabled = false;
            //DatabaseSchema dbSchema = GlobalHelp.GetDatabaseSchema(m_serverTag.DBType, m_serverTag.Server, cboDbName.Text.Trim());
            var serverTag = lstTreeNodeDb[0].Parent.Tag as ServerTag;
            if (serverTag != null)
                switch (serverTag.DBType)
                {
                    case SqlType.SqlServer:
                    case SqlType.MySql:
                    case SqlType.SQLite:
                        toolStripProgressBar1.Visible = true;
                        object[] objArgument = new object[] { lstTreeNodeDb, txtSql.Text };
                        bckWorker.RunWorkerAsync(objArgument);
                        break;

                    case SqlType.Oracle:
                        break;

                    case SqlType.SqlServerCe:
                        break;

                    case SqlType.PostgreSql:
                        break;

                    case SqlType.Db2:
                        break;
                }
        }

        private DataSet Run(List<TreeNode> lstTreeNodeDb, string strSql)
        {
            foreach (TreeNode item in lstTreeNodeDb)
            {
                string strConn = item.Tag.ToString();
                var serverTag = item.Parent.Tag as ServerTag;
                if (serverTag != null)
                    m_dbHelper = DataBaseManager.GetDbHelper(serverTag.DBType, strConn);
                m_dbHelper.CreateCommand(strSql);
                DataSet ds = m_dbHelper.ExecuteQueryDataSet();
                foreach (DataTable dt in ds.Tables)
                {
                    if (dt != null)
                    {
                        DataTable dtNew = dt.Copy();
                        dtNew.TableName = Guid.NewGuid().ToString();
                        m_ds.Tables.Add(dtNew);
                    }
                }
            }
            return m_ds;
        }
        /// <summary>导出
        /// 导出
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdTable_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {Filter = @"(sql文件)|*.sql", Title = @"请选择要载入的文件"};
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName.EndsWith(".sql") == false || dialog.FileName.EndsWith(".txt") == false)
                {
                    MessageBox.Show(@"选择的文件不符合要求，请重新选择");
                    return;
                }
                StreamReader sr = new StreamReader(dialog.FileName, Encoding.Default);
                StringBuilder sb = new StringBuilder();
                string strline;
                while ((strline = sr.ReadLine()) != null)
                {
                    sb.AppendLine(strline);
                }
                sr.Close();
                sr.Dispose();
                txtSql.Text = sb.ToString();
            }
        }

        /// <summary>保存
        /// 保存
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void cmdView_Click(object sender, EventArgs e)
        {
            if (txtSql.Text.Trim() == string.Empty)
            {
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog {Filter = @"(sql文件)|*.sql", Title = @"请输入要载入的文件"};
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(dialog.FileName + ".sql");
                sw.WriteLine(txtSql.Text);
                sw.Close();
                sw.Dispose();
            }
        }
        /// <summary>列表转逗号
        /// 列表转逗号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdListSplit_Click(object sender, EventArgs e)
        {
            string strOri = txtSql.ActiveTextAreaControl.SelectionManager.SelectedText;
            if (strOri.Length > 0)
            {
                string strResult = strOri.Replace("\r\n", ",");
                txtSql.Text = @"(" + txtSql.Text.Replace(txtSql.ActiveTextAreaControl.SelectionManager.SelectedText, strResult) + @")";
                txtSql.Refresh();
            }
            else
            {
                txtSql.Text = @"(" + txtSql.Text.Replace("\r\n", ",") + @")";
                txtSql.Refresh();
            }
        }

        /// <summary>停止执行
        /// 停止执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdNewQuery_Click(object sender, EventArgs e)
        {
            cmdRun.Enabled = true;
            toolStripProgressBar1.Visible = false;
            bckWorker.CancelAsync();
            m_dbHelper.StopRunSql();
        }
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView != null)
            {
                SolidBrush b = new SolidBrush(dataGridView.RowHeadersDefaultCellStyle.ForeColor);
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), dataGridView.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }


        /// <summary>
        /// 导出结果到Excel
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void 导出结果ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_ds == null || m_ds.Tables.Count == 0)
            {
                MessageBox.Show(@"没有可导出的结果集");
                return;
            }
            string strPath = NPOIHelper.ExportToExcel(m_ds);
            if (strPath == null)
            {
                return;
            }
            DialogResult diaResult = MessageBox.Show(string.Format("导出至{0},是否打开？", strPath), @"提示", MessageBoxButtons.YesNo);
            if (diaResult == DialogResult.Yes)
            {
                Process.Start(strPath);
            }
        }

        private void tvwDBList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeViewHelper.CheckControl(e);
        }
    }
}