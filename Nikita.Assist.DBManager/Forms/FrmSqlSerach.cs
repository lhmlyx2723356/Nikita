using Nikita.Base.DbSchemaReader.DataSchema;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using Nikita.WinForm.ExtendControl;

using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Assist.DBManager
{
    public partial class FrmSqlSerach : DockContentEx
    {
        SqlTasks m_task = new SqlTasks(SqlType.SqlServer);
        public FrmSqlSerach()
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
        }

        private readonly string[] LoadTypeAry = { "表", "视图", "存储过程", "函数" };

        private void FrmSqlSerach_Load(object sender, EventArgs e)
        {

            #region 绑定服务器，已加载数据库
            if (GlobalHelp.DicSqlServerDatabaseSchema.Count > 0)
            {
                chkDB.DisplayMember = "Name";
                chkDB.ValueSeparator = ",";
                foreach (KeyValuePair<string, Dictionary<string, DatabaseSchema>> item in GlobalHelp.DicSqlServerDatabaseSchema)
                {
                    cboServer.Items.Add(item.Key);
                    foreach (KeyValuePair<string, DatabaseSchema> itemDB in item.Value)
                    {
                        CCBoxItem itemInfo = new CCBoxItem(itemDB.Key, itemDB.Key);
                        chkDB.Items.Add(itemInfo);
                    }
                }
                chkDB.MaxDropDownItems = chkDB.Items.Count;
                for (int i = 0; i < chkDB.Items.Count; i++)
                {
                    chkDB.SetItemChecked(i, true);
                }
                cboServer.SelectedIndex = 0;
            }
            #endregion


            #region 绑定类型
            chkType.MaxDropDownItems = 4;
            chkType.DisplayMember = "Name";
            chkType.ValueSeparator = ",";
            for (int i = 0; i < LoadTypeAry.Length; i++)
            {
                CCBoxItem item = new CCBoxItem(LoadTypeAry[i], i);
                chkType.Items.Add(item);
                chkType.SetItemChecked(i, true);
            }
            #endregion

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Trim() == string.Empty || chkType.Text.Trim() == string.Empty || chkDB.Text.Trim() == string.Empty || cboServer.Text.Trim() == string.Empty)
            {
                return;
            }
            string strKey = txtInput.Text.Trim();
            string[] strAryType = chkType.Text.Trim().Split(',');
            string[] strAryDB = chkDB.Text.Trim().Split(',');
            DataTable dt = GenDataTable();
            foreach (KeyValuePair<string, Dictionary<string, DatabaseSchema>> item in GlobalHelp.DicSqlServerDatabaseSchema.Where(t => t.Key == cboServer.Text.Trim()))
            {
                foreach (KeyValuePair<string, DatabaseSchema> itemDB in item.Value)
                {
                    if (!strAryDB.Contains(itemDB.Key))
                    {
                        continue;
                    }
                    DatabaseSchema dbSchema = itemDB.Value;
                    foreach (string strMachType in strAryType)
                    {
                        MachOn(dt, dbSchema, strKey, itemDB.Key, strMachType);
                    }
                }
            }
            dataGridView1.DataSource = dt;
        }

        private DataTable GenDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ObjectName", typeof(string));
            dt.Columns.Add("Schema", typeof(string));
            dt.Columns.Add("Database", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Detail", typeof(string));
            return dt;
        }

        private void MachOn(DataTable dt, DatabaseSchema dbSchema, string strKey, string strDatabase, string strType)
        {
            if (strType == "表")
            {
                List<DatabaseTable> lstTables = dbSchema.Tables;
                foreach (DatabaseTable databaseTable in lstTables)
                {
                    string strDatabaseTable = m_task.BuildTableDdl(databaseTable);
                    if (strDatabaseTable.ToLower().Contains(strKey.ToLower()))
                    {
                        DataRow drNew = dt.NewRow();
                        drNew["ObjectName"] = databaseTable.Name;
                        drNew["Schema"] = databaseTable.SchemaOwner;
                        drNew["Database"] = strDatabase;
                        drNew["Type"] = "表";
                        drNew["Detail"] = strDatabaseTable;
                        dt.Rows.Add(drNew);
                    }
                }
            }

            else if (strType == "视图")
            {
                List<DatabaseView> lstViews = dbSchema.Views;
                foreach (DatabaseView databaseView in lstViews)
                {
                    string strDatabaseView = m_task.BuildView(databaseView);
                    if (strDatabaseView.ToLower().Contains(strKey.ToLower()))
                    {
                        DataRow drNew = dt.NewRow();
                        drNew["ObjectName"] = databaseView.Name;
                        drNew["Schema"] = databaseView.SchemaOwner;
                        drNew["Database"] = strDatabase;
                        drNew["Type"] = "视图";
                        drNew["Detail"] = strDatabaseView;
                        dt.Rows.Add(drNew);
                    }
                }
            }
            else if (strType == "存储过程")
            {
                List<DatabaseStoredProcedure> lstProcedures = dbSchema.StoredProcedures;
                foreach (DatabaseStoredProcedure databaseProcedures in lstProcedures)
                {
                    string strDatabaseProcedures = m_task.BuildProcedure(databaseProcedures);
                    if (strDatabaseProcedures.ToLower().Contains(strKey.ToLower()))
                    {
                        DataRow drNew = dt.NewRow();
                        drNew["ObjectName"] = databaseProcedures.Name;
                        drNew["Schema"] = databaseProcedures.SchemaOwner;
                        drNew["Database"] = strDatabase;
                        drNew["Type"] = "存储过程";
                        drNew["Detail"] = strDatabaseProcedures;
                        dt.Rows.Add(drNew);
                    }
                }
            }
            else if (strType == "函数")
            {
                List<DatabaseFunction> lstFunctions = dbSchema.Functions;
                foreach (DatabaseFunction databaseFunction in lstFunctions)
                {
                    string strDatabaseFunction = m_task.BuildFunction(databaseFunction);
                    if (strDatabaseFunction.ToLower().Contains(strKey.ToLower()))
                    {
                        DataRow drNew = dt.NewRow();
                        drNew["ObjectName"] = databaseFunction.Name;
                        drNew["Schema"] = databaseFunction.SchemaOwner;
                        drNew["Database"] = strDatabase;
                        drNew["Type"] = "函数";
                        drNew["Detail"] = strDatabaseFunction;
                        dt.Rows.Add(drNew);
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= 0)
            {
                return;
            }
            //txtSql.Document.MarkerStrategy.RemoveAll(t => true);
            //txtSql.Text = string.Empty;
            txtSql.Text = dataGridView1.Rows[e.RowIndex].Cells["Detail"].Value.ToString();
            //txtSql.ActiveTextAreaControl.SelectionManager.ClearSelection();
            List<int> lstStart = new List<int>();
            int intContentLength = txtSql.Document.TextContent.Length;
            int intOffsetTemp = 0;
            while (true)
            {
                int intTemp = txtSql.Document.TextContent.ToLower().IndexOf(txtInput.Text.ToLower(), intOffsetTemp, StringComparison.Ordinal);
                if (intTemp > 0)
                {
                    lstStart.Add(intTemp);
                    intOffsetTemp = intTemp + 1;
                }
                else
                {
                    break;
                }
            }
            if (lstStart.Count > 0)
            {
                TextLocation start = txtSql.Document.OffsetToPosition(lstStart[0]);
                for (int i = lstStart.Count - 1; i >= 0; i--)
                {
                    //设置选择的文本。
                    int intLength = txtInput.Text.Length;
                    //Point end = txtSql.Document.OffsetToPosition(lstStart[i] + intLength);
                    //txtSql.ActiveTextAreaControl.SelectionManager.SetSelection(new DefaultSelection(this.txtSql.Document, start, end));
                    TextMarker marker = new TextMarker(lstStart[i], intLength, TextMarkerType.SolidBlock, Color.Yellow, Color.Red);
                    txtSql.Document.MarkerStrategy.AddMarker(marker);
                    //txtSql.Document.MarkerStrategy.Document.CommitUpdate();
                }
                //移动到第一个的位置 
                txtSql.ActiveTextAreaControl.Caret.Position = start;
                txtSql.ActiveTextAreaControl.TextArea.ScrollToCaret();
                txtSql.Refresh();
            }

        }



    }
}
