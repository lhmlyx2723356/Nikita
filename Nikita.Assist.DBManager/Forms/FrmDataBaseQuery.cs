using Nikita.Base.DbSchemaReader.DataSchema;
 
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.Document;
using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Assist.DBManager
{
    public partial class FrmDataBaseQuery : DockContentEx
    {
        private IDBHelper m_dbHelper;
        private DataSet m_ds;
        private DataTable m_dtDbName;
        private ServerTag m_serverTag;
        private string m_strDbName;
        private string m_strServer;

        public FrmDataBaseQuery(ServerTag serverTag, string strDbName, string strDefaultSql, bool blnAutoRun)
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

            bckWorker.WorkerReportsProgress = true;
            this.m_dtDbName = serverTag.ServerDBNames;
            this.m_strServer = serverTag.Server;
            this.m_strDbName = strDbName;
            this.m_serverTag = serverTag;
            this.Text = m_strDbName + @"查询";
            ComboboxHelper.BindCombobox(cboDbName, serverTag.ServerDBNames, "name", "name", false);
            this.cboDbName.Text = m_strDbName;
            cboDbName.SelectedIndexChanged += cboDbName_SelectedIndexChanged;
            if (strDefaultSql != string.Empty)
            {
                txtSql.Text = strDefaultSql;
                if (blnAutoRun)
                {
                    cmdRun_Click(null, null);
                }
            }
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] obj = e.Argument as object[];
            if (obj != null)
            {
                DatabaseSchema dbSchema = obj[0] as DatabaseSchema;
                string strSql = obj[1].ToString();
                e.Result = Run(dbSchema, strSql);
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

        private void cboDbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDbName.ComboBox != null)
                GlobalHelp.DockPanel.ActiveContent.DockHandler.TabText = cboDbName.ComboBox.Text + @"查询";
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

        private void cmdNewQuery_Click(object sender, EventArgs e)
        {
            cmdRun.Enabled = true;
            toolStripProgressBar1.Visible = false;
            bckWorker.CancelAsync();
            m_dbHelper.StopRunSql();
        }

        /// <summary>执行
        /// 执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRun_Click(object sender, EventArgs e)
        {
            if (cboDbName.Text.Trim().Length == 0)
            {
                MessageBox.Show(@"请选择要执行的数据库");
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
            DatabaseSchema dbSchema = GlobalHelp.GetDatabaseSchema(m_serverTag.DBType, m_serverTag.Server, cboDbName.Text.Trim());
            switch (m_serverTag.DBType)
            {
                case SqlType.SqlServer:
                case SqlType.MySql:
                case SqlType.SQLite:
                    toolStripProgressBar1.Visible = true;
                    object[] objArgument = new object[] { dbSchema, txtSql.Text };
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

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView != null)
            {
                SolidBrush b = new SolidBrush(dataGridView.RowHeadersDefaultCellStyle.ForeColor);
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), dataGridView.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private DataSet Run(DatabaseSchema dbSchema, string strSql)
        {
            string strConn = dbSchema.ConnectionString;
            m_dbHelper = DataBaseManager.GetDbHelper(m_serverTag.DBType, strConn);
            m_dbHelper.CreateCommand(strSql);
            DataSet ds = m_ds = m_dbHelper.ExecuteQueryDataSet();
            return ds;
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

 
    }
}