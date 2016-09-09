using Nikita.Base.DbSchemaReader;
using Nikita.Base.DbSchemaReader.DataSchema;
using Nikita.Base.DbSchemaReader.SqlGen;
using Nikita.Assist.DBManager.DAL;
using Nikita.Assist.DBManager.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;
using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Assist.DBManager
{
    public partial class FrmTableNew : DockContentEx
    {
        #region 成员变量

        /// <summary> 新增/设计模式
        /// 新增/设计模式
        /// </summary>
        private bool m_blnNew;

        private Bse_DataDictionaryDAL m_dal;

        /// <summary> Schema
        /// Schema
        /// </summary>
        private DatabaseSchema m_databaseSchema;

        /// <summary>数据库访问
        /// 数据库访问
        /// </summary>
        private IDBHelper m_dbHelper;

        /// <summary> 数据库类型
        /// 数据库类型
        /// </summary>
        private SqlType m_dbType;

        private SqlDataAdapter m_sda;

        /// <summary> Sql执行类
        /// Sql执行类
        /// </summary>
        private SqlTasks m_sqlTasks;

        /// <summary> 数据库名称
        /// 数据库名称
        /// </summary>
        private string m_strDbName;

        /// <summary>服务器名称
        /// 服务器名称
        /// </summary>
        private string m_strServer;

        /// <summary>表名称
        /// 表名称
        /// </summary>
        private string m_strTableName;

        /// <summary>编辑模式==》IsNew=true 属于新增表模式 ，IsNew=false 属于设计表模式
        /// 编辑模式==》IsNew=true 属于新增表模式 ，IsNew=false 属于设计表模式
        /// </summary>
        private bool IsNew
        {
            get
            {
                return m_blnNew;
            }
            set
            {
                //编辑模式
                if (value == false)
                {
                    lblTableDescription.Visible = false;
                    lblTableHistoryName.Visible = false;
                    txtTableHistoryName.Visible = false;
                    txtTableDescription.Visible = false;
                    txtTableName.ReadOnly = true;
                    splitContainer1.Panel2Collapsed = true;
                    m_blnNew = false;
                    this.Text = "设计表" + "_" + m_strServer + "_" + m_strDbName + "_" + m_strTableName;
                    txtTableName.Text = m_strTableName;
                    DatabaseTable table = m_databaseSchema.FindTableByName(m_strTableName);
                    grdTable.DataSource = null;
                    grdTable.DataSource = m_sqlTasks.GenDataTable(table, m_strServer, m_strDbName, txtTableHistoryName.Text.Trim(), txtTableDescription.Text.Trim());
                    (grdTable.DataSource as DataTable).AcceptChanges();
                    for (int i = 0; i < grdTable.Rows.Count; i++)
                    {
                        if (grdTable.Rows[i].Cells[0].Value != null)
                        {
                            grdTable.Rows[i].Tag = table.Columns[i];
                        }
                    }
                }
                else
                {
                    m_blnNew = value;
                }
            }
        }

        #endregion 成员变量

        /// <summary>
        /// 构造函数 构造函数
        /// </summary>
        /// <param name="strServer">服务器名称</param>
        /// <param name="strDbName">数据库名称</param>
        /// <param name="strTableName">数据库表名</param>
        /// <param name="dbType">类型</param>
        /// <param name="blnNew">是否新增表，true 新增表，false，设计表</param>
        public FrmTableNew(ServerTag serverTag, string strDbName, string strTableName, SqlType dbType, bool blnNew)
        {
            InitializeComponent();
            m_dal = new Bse_DataDictionaryDAL();
            m_strTableName = strTableName;
            m_strServer = serverTag.Server;
            m_strDbName = strDbName;
            m_dbType = dbType;
            grdTable.EditMode = DataGridViewEditMode.EditOnEnter;
            grdTable.AutoGenerateColumns = false;
            m_databaseSchema = GlobalHelp.GetDatabaseSchema(serverTag.DBType, serverTag.Server, strDbName);
            m_dbHelper = DataBaseManager.GetDbHelper(m_dbType, m_databaseSchema.ConnectionString);
            m_sqlTasks = new SqlTasks(m_dbType);
            m_blnNew = blnNew;
        }

        #region 基础事件

        /// <summary>执行
        /// 执行
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                return;
            }
            if (CheckDesignTable() == false)
            {
                return;
            }
            DataTable dtSource = (grdTable.DataSource as DataTable);
            if (dtSource == null)
            {
                return;
            }
            DataTable dtChanges = dtSource.GetChanges();
            if (dtChanges == null)
            {
                return;
            }
            try
            {
                if (IsNew)
                {
                    //第一次执行生成表名
                    string strSqlAddTable = AddTableScript(m_databaseSchema).Replace("GO", "");
                    m_dbHelper.CreateCommand(strSqlAddTable + " ; SELECT 'OK'");
                    DataTable dtResult = m_dbHelper.ExecuteQuery();
                    if (dtResult != null && dtResult.Rows.Count != 1)
                    {
                        MessageBox.Show("新建失败");
                        return;
                    }
                    else
                    {
                        m_sda.Update(dtChanges);
                        dtSource.AcceptChanges();
                        m_strTableName = txtTableName.Text.Trim();
                        //切换成编辑模式
                        IsNew = false;
                        DatabaseTable databaseTable = m_databaseSchema.Tables.Where(t => t.Name == m_strTableName).FirstOrDefault();
                        TreeNode tableRoot = TreeViewHelper.FindTableNode(GlobalHelp.TreeView.Nodes, m_strServer, m_strDbName, "表");
                        if (tableRoot != null)
                        {
                            //及时刷新TreeView
                            SchemaToTreeview.FillOneTable(databaseTable, tableRoot, 2);
                        }
                        MessageBox.Show("新建成功！");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>查看脚本
        /// 查看脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScript_Click(object sender, EventArgs e)
        {
            txtSql.Text = AddTableScript(m_databaseSchema);
        }

        /// <summary>窗体第一次显示
        /// 窗体第一次显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTableNew_Shown(object sender, EventArgs e)
        {
            BindDataTypes();
            if (m_blnNew == false)
            {
                IsNew = false;
            }
            else
            {
                BindGrid(txtTableName.Text.Trim());
                if (txtTableName.Text.Trim() == string.Empty)
                {
                    txtTableName.Select();
                }
            }
        }

        /// <summary>删除列
        /// 删除列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (grdTable.SelectedRows.Count == 0)
            {
                return;
            }
            int intIndex = grdTable.SelectedRows[0].Index;
            DatabaseTable dt = m_databaseSchema.FindTableByName(m_strTableName);
            DatabaseColumn databaseColumn = GenDatabaseColumn(grdTable.SelectedRows[0], dt);
            var migration = new DdlGeneratorFactory(m_dbType).MigrationGenerator();
            string strSqlColumn = migration.DropColumn(dt, databaseColumn);
            string strSql = strSqlColumn + " ; SELECT 'OK'";
            bool blnFlag = RunSql(DataRowState.Deleted, strSql, (grdTable.DataSource as DataTable), grdTable.SelectedRows[0], databaseColumn);

            if (blnFlag)
            {
                TreeNode tableRoot = TreeViewHelper.FindTableNode(GlobalHelp.TreeView.Nodes, m_strServer, m_strDbName, "表");
                TreeNode node = TreeViewHelper.FindNodeByName(tableRoot.Nodes, databaseColumn.Table.Name);
                TreeNode nodeColumn = TreeViewHelper.FindColumnNodeByName(node.Nodes, grdTable.Rows[intIndex].Cells[colColumnName.Name].Value.ToString());
                AddLog((grdTable.DataSource as DataTable).Rows[intIndex], "删除列");
                tableRoot.Nodes.Remove(nodeColumn);
                dt.Columns.RemoveAt(intIndex);
                grdTable.Rows.RemoveAt(intIndex);
                //重新设置Tag
                ResetTag(databaseColumn.Table);
            }
        }

        /// <summary>插入列
        /// 插入列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (grdTable.SelectedRows.Count == 0)
            {
                return;
            }
            DataRow dr = ((DataTable)grdTable.DataSource).NewRow();
            ((DataTable)grdTable.DataSource).Rows.InsertAt(dr, grdTable.SelectedRows[0].Index);
            grdTable.SelectedRows[0].Selected = true;
        }

        /// <summary>判断表是否存在
        /// 判断表是否存在
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTableName_Leave(object sender, EventArgs e)
        {
            if (!m_blnNew)
            {
                return;
            }
            if (!string.IsNullOrEmpty(txtTableName.Text.Trim()))
            {
                DatabaseReader reader = new DatabaseReader(m_databaseSchema);
                if (reader.TableExists(txtTableName.Text.Trim()))
                {
                    MessageBox.Show("该表已经存在");
                    txtTableName.Select();
                    return;
                }
            }
        }

        #endregion 基础事件

        #region grdTable事件

        private void grdTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (grdTable.Rows[e.RowIndex].Cells[colColumnName.Name].Value == null)
            {
                return;
            }
            if (IsNew)
            {
                return;
            }
            DataTable dtSource = (grdTable.DataSource as DataTable);
            if (dtSource == null)
            {
                return;
            }
            DataTable dtChanges = dtSource.GetChanges();
            if (dtChanges == null)
            {
                return;
            }
            if (CheckDesignTable() == false)
            {
                return;
            }
            try
            {
                StringBuilder sb = new StringBuilder();
                bool blnFlag = false;
                foreach (DataRow dr in dtChanges.Rows)
                {
                    #region 修改列

                    if (dr.RowState == DataRowState.Modified)
                    {
                        DatabaseColumn originalColumn = grdTable.Rows[e.RowIndex].Tag as DatabaseColumn;
                        if (originalColumn != null)
                        {
                            DatabaseColumn databaseColumn = GenDatabaseColumn(grdTable.Rows[e.RowIndex], originalColumn.Table);
                            //修改类名
                            if (databaseColumn.Name != originalColumn.Name)
                            {
                                sb.AppendLine(m_sqlTasks.RenameColumn(originalColumn.Table, databaseColumn, originalColumn));
                            }
                            if (databaseColumn.DbDataType.ToLower() != originalColumn.DbDataType.ToLower())
                            {
                                //修改类型、默认值等
                                sb.AppendLine(m_sqlTasks.AlterColumn(originalColumn.Table, databaseColumn, originalColumn));
                            }
                            //修改主键
                            if (originalColumn.IsPrimaryKey != databaseColumn.IsPrimaryKey)
                            {
                                if (originalColumn.IsPrimaryKey)
                                {
                                    //删除主键
                                    sb.AppendLine(" ALTER TABLE  " + databaseColumn.Table.Name + "   DROP CONSTRAINT  " + databaseColumn.Table.Name + "  ;");
                                }
                                else
                                {
                                    sb.AppendLine(" ALTER TABLE  " + databaseColumn.Table.Name + "   ALTER COLUMN   " + databaseColumn.Name + " " + databaseColumn.DbDataType + " NOT NULL ;");
                                    sb.AppendLine(" ALTER TABLE  " + databaseColumn.Table.Name + "    ADD CONSTRAINT PK_" + databaseColumn.Table.Name + " PRIMARY KEY(" + databaseColumn.Name + ") ;");
                                }
                            }
                            //修改自增长
                            if (originalColumn.IsAutoNumber != databaseColumn.IsAutoNumber)
                            {
                                if (originalColumn.IsAutoNumber)
                                {
                                    //删除自增长
                                    sb.AppendLine(" ALTER TABLE  " + databaseColumn.Table.Name + "  ADD " + databaseColumn.Name + "1" + databaseColumn.DbDataType);
                                    sb.AppendLine(" UPDATE  " + databaseColumn.Table.Name + " SET " + databaseColumn.Name + "1= " + databaseColumn.Name);
                                    sb.AppendLine(" ALTER TABLE  " + databaseColumn.Table.Name + " DROP COLUMN " + databaseColumn.Name);
                                    sb.AppendLine(" EXEC sp_rename  '" + databaseColumn.Name + "1','" + databaseColumn.Name + "', 'COLUMN'");
                                }
                                else
                                {
                                    sb.AppendLine("   ALTER TABLE " + databaseColumn.Table.Name + "   DROP  COLUMN " + databaseColumn.Name);
                                    sb.AppendLine("   ALTER TABLE " + databaseColumn.Table.Name + " ADD " + databaseColumn.Name + " " + databaseColumn.DbDataType + " IDENTITY(1,1) NOT NULL");
                                }
                            }
                            if (sb.ToString() != string.Empty)
                            {
                                string strSql = sb.AppendLine(" ; SELECT 'OK'").ToString();
                                blnFlag = RunSql(DataRowState.Modified, strSql, dtSource, grdTable.Rows[e.RowIndex], databaseColumn);
                                if (blnFlag)
                                {
                                    grdTable.Rows[e.RowIndex].Tag = databaseColumn;
                                    originalColumn.Table.Columns.Add(databaseColumn);
                                    DatabaseTable databaseTable = m_databaseSchema.Tables.Where(t => t.Name == m_strTableName).FirstOrDefault();
                                    TreeNode tableRoot = TreeViewHelper.FindTableNode(GlobalHelp.TreeView.Nodes, m_strServer, m_strDbName, "表");
                                    if (tableRoot != null && tableRoot.Nodes.Count > 0)
                                    {
                                        TreeNode treeNode = TreeViewHelper.FindNodeByName(tableRoot.Nodes, m_strTableName);
                                        if (treeNode != null)
                                        {
                                            TreeNode nodeColumn = TreeViewHelper.FindColumnNodeByName(treeNode.Nodes, originalColumn.Name);
                                            int intIndex = nodeColumn.Index;
                                            originalColumn.Table.Columns.Remove(originalColumn);
                                            SchemaToTreeview.FillColumn(treeNode, databaseColumn, 3, intIndex);
                                            treeNode.Nodes.Remove(nodeColumn);
                                        }
                                    }
                                    AddLog(dr, "修改列");
                                }
                                //重新设置Tag
                                ResetTag(databaseColumn.Table);
                            }
                        }
                    }

                    #endregion 修改列

                    #region 新增列

                    else if (dr.RowState == DataRowState.Added)
                    {
                        DatabaseTable dt = m_databaseSchema.FindTableByName(m_strTableName);
                        DatabaseColumn databaseColumn = GenDatabaseColumn(grdTable.Rows[e.RowIndex], dt);
                        var migration = new DdlGeneratorFactory(m_dbType).MigrationGenerator();
                        string strSql = migration.AddColumn(dt, databaseColumn);
                        strSql += " ; SELECT 'OK'";

                        #region 获取要插入的列位置

                        //int intIndex = 0;
                        //DatabaseTable databaseTable = m_databaseSchema.Tables.Where(t => t.Name == m_strTableName).FirstOrDefault();
                        //TreeNode tableRoot = TreeViewHelper.FindTableNode(GlobalHelp.TreeView.Nodes, m_strServer, m_strDbName, "表");
                        //if (tableRoot != null && tableRoot.Nodes.Count > 0)
                        //{
                        //    TreeNode treeNode = TreeViewHelper.FindNodeByName(tableRoot.Nodes, m_strTableName);
                        //    if (treeNode != null)
                        //    {
                        //        if (e.RowIndex > 0)
                        //        {
                        //            DatabaseColumn preColumn = grdTable.Rows[e.RowIndex - 1].Tag as DatabaseColumn;
                        //            if (preColumn != null)
                        //            {
                        //                string strNodeName = SchemaToTreeview.GetColumnName(preColumn);
                        //                TreeNode nodeColumn = TreeViewHelper.FindNodeByName(treeNode.Nodes, strNodeName);
                        //                intIndex = nodeColumn.Index;
                        //            }
                        //        }
                        //    }
                        //}

                        #endregion 获取要插入的列位置

                        blnFlag = RunSql(DataRowState.Added, strSql, dtSource, grdTable.Rows[e.RowIndex], databaseColumn);
                        if (blnFlag)
                        {
                            databaseColumn.Table.Columns.Add(databaseColumn);
                            TreeNode tableRoot = TreeViewHelper.FindTableNode(GlobalHelp.TreeView.Nodes, m_strServer, m_strDbName, "表");
                            TreeNode treeNode = TreeViewHelper.FindNodeByName(tableRoot.Nodes, m_strTableName);
                            SchemaToTreeview.FillColumn(treeNode, databaseColumn, 3, e.RowIndex);

                            AddLog(dr, "新增列");
                            //重新设置Tag
                            ResetTag(databaseColumn.Table);
                        }
                    }

                    #endregion 新增列
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void grdTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == colColumnType.Index)
            {
                if (grdTable.Rows[e.RowIndex].Cells[colColumnType.Name].Value == null)
                {
                    return;
                }
                string strVal = grdTable.Rows[e.RowIndex].Cells[colColumnType.Name].Value.ToString();
                if (!strVal.Contains("decimal") && !strVal.Contains("numberic"))
                {
                    grdTable.Rows[e.RowIndex].Cells[colColumnScale.Name].ReadOnly = true;
                }
                else
                {
                    grdTable.Rows[e.RowIndex].Cells[colColumnType.Name].ReadOnly = false;
                }
            }

            //字段长度
            if (e.ColumnIndex == colColumnLength.Index)
            {
                if (grdTable.Rows[e.RowIndex].Cells[colColumnLength.Name].Value != null && grdTable.Rows[e.RowIndex].Cells[colColumnLength.Name].Value.ToString() != string.Empty)
                {
                    int intOutLength;
                    if (!int.TryParse(grdTable.Rows[e.RowIndex].Cells[colColumnLength.Name].Value.ToString(), out intOutLength))
                    {
                        grdTable.Rows[e.RowIndex].Cells[colColumnLength.Name].Value = string.Empty;
                    }
                }
            }

            //字段精度
            if (e.ColumnIndex == colColumnScale.Index)
            {
                if (grdTable.Rows[e.RowIndex].Cells[colColumnScale.Name].Value != null)
                {
                    int intOutLength;
                    if (!int.TryParse(grdTable.Rows[e.RowIndex].Cells[colColumnScale.Name].Value.ToString(), out intOutLength))
                    {
                        grdTable.Rows[e.RowIndex].Cells[colColumnScale.Name].Value = null;
                    }
                }
            }
            //主键
            if (e.ColumnIndex == colColumnPK.Index)
            {
                if (grdTable.Rows[e.RowIndex].Cells[colColumnPK.Name].Value == null)
                {
                    return;
                }
                string strVal = grdTable.Rows[e.RowIndex].Cells[colColumnPK.Name].Value.ToString();
                if (strVal.ToUpper() == "TRUE")
                {
                    grdTable.Rows[e.RowIndex].Cells[colColumnAllowNull.Name].Value = false;
                }
            }
        }

        private void grdTable_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        /// <summary>Cell默认值
        /// Cell默认值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdTable_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (CheckInput())
            {
                return;
            }
            e.Row.Cells[colTableName.Name].Value = txtTableName.Text.Trim();
            e.Row.Cells[ColTableHistoryName.Name].Value = txtTableName.Text.Trim();
            e.Row.Cells[colTableDescription.Name].Value = txtTableDescription.Text.Trim();
            e.Row.Cells[colServerName.Name].Value = m_strServer;
            e.Row.Cells[colDatabaseName.Name].Value = m_strDbName;
            e.Row.Cells[colDbType.Name].Value = m_dbType;
            e.Row.Cells[colOperationType.Name].Value = "新增";
        }

        #endregion grdTable事件

        #region 方法

        /// <summary>根据DataGridViewRow 生成DatabaseColumn
        /// 根据DataGridViewRow 生成DatabaseColumn
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="databaseTable"></param>
        /// <returns></returns>
        public DatabaseColumn GenDatabaseColumn(DataGridViewRow dr, DatabaseTable databaseTable)
        {
            DatabaseColumn databaseColumn = new DatabaseColumn();
            databaseColumn.Table = databaseTable;
            //数据类型
            string strColumnLength = dr.Cells[colColumnLength.Name].Value == null ? string.Empty : dr.Cells[colColumnLength.Name].Value.ToString();
            string strColumnType = dr.Cells[colColumnType.Name].Value == null ? string.Empty : dr.Cells[colColumnType.Name].Value.ToString();
            string strDataType = string.IsNullOrEmpty(strColumnLength) ? strColumnType : strColumnType.Split('(')[0] + "(" + strColumnLength + ")";
            string strColumnName = dr.Cells[colColumnName.Name].Value == null ? string.Empty : dr.Cells[colColumnName.Name].Value.ToString();
            string strColumnScale = dr.Cells[colColumnScale.Name].Value == null ? string.Empty : dr.Cells[colColumnScale.Name].Value.ToString();
            bool blnPK = true;
            string strColumnPK = dr.Cells[colColumnPK.Name].Value == null ? string.Empty : dr.Cells[colColumnPK.Name].Value.ToString();
            if (strColumnPK == string.Empty || strColumnPK.ToUpper() == "FALSE")
            {
                blnPK = false;
            }
            bool blnIdentity = true;
            string strColumnIdentity = dr.Cells[colColumnIdentity.Name].Value == null ? string.Empty : dr.Cells[colColumnIdentity.Name].Value.ToString();
            if (strColumnIdentity == string.Empty || strColumnIdentity.ToUpper() == "FALSE")
            {
                blnIdentity = false;
            }
            bool blnAllow = true;
            string strColumnAllowNull = dr.Cells[colColumnAllowNull.Name].Value == null ? string.Empty : dr.Cells[colColumnAllowNull.Name].Value.ToString();
            if (strColumnAllowNull == string.Empty || strColumnAllowNull.ToUpper() == "FALSE")
            {
                blnAllow = false;
            }
            string strColumnRemark = dr.Cells[colColumnRemark.Name].Value == null ? string.Empty : dr.Cells[colColumnRemark.Name].Value.ToString();
            string strColumnDefaultValue = dr.Cells[colColumnDefaultValue.Name].Value == null ? string.Empty : dr.Cells[colColumnDefaultValue.Name].Value.ToString();
            databaseColumn.Name = strColumnName;
            databaseColumn.DbDataType = strDataType.Split('(')[0].ToUpper();
            DatabaseReader reader = new DatabaseReader(databaseTable.DatabaseSchema);
            databaseColumn.DataType = reader.DataTypes().Where(t => t.TypeName.ToLower() == databaseColumn.DbDataType.ToLower()).FirstOrDefault();
            if (!string.IsNullOrEmpty(strColumnLength))
            {
                databaseColumn.Length = int.Parse(strColumnLength);
            }
            else
            {
                if (strColumnType.Contains('('))
                {
                    if (strColumnType.ToUpper().Contains("MAX"))
                    {
                        databaseColumn.Length = -1;
                    }
                    else
                    {
                        databaseColumn.Length = int.Parse(strColumnType.Replace(")", "").Split('(')[1].Split(',')[0]);
                    }
                }
            }

            if (blnPK)
            {
                databaseColumn.AddPrimaryKey();
            }
            if (blnIdentity)
            {
                databaseColumn.AddIdentity();
            }
            if (blnAllow)
            {
                databaseColumn.AddNullable();
            }
            if (strColumnRemark != string.Empty)
            {
                databaseColumn.Description = strColumnRemark;
            }
            if (strColumnDefaultValue != string.Empty)
            {
                databaseColumn.DefaultValue = strColumnDefaultValue;
            }
            if (strColumnScale != string.Empty)
            {
                databaseColumn.Scale = int.Parse(strColumnScale);
            }
            return databaseColumn;
        }

        private bool AddLog(DataRow dr, string strOperationType)
        {
            bool blnLogFlag = false;
            Bse_DataDictionary model = new Bse_DataDictionary();
            model.ColumnAllowNull = dr["ColumnAllowNull"].ToString();
            model.ColumnDefaultValue = dr["ColumnDefaultValue"].ToString();
            model.ColumnHistory = dr["ColumnHistory"].ToString();
            model.ColumnIdentity = dr["ColumnIdentity"].ToString();
            model.ColumnLength = dr["ColumnLength"].ToString();
            model.ColumnName = dr["ColumnName"].ToString();
            model.ColumnPK = dr["ColumnPK"].ToString();
            model.ColumnRemark = dr["ColumnRemark"].ToString();
            model.ColumnScale = dr["ColumnScale"].ToString();
            model.ColumnSpace = dr["ColumnSpace"].ToString();
            model.ColumnType = dr["ColumnType"].ToString();
            model.DatabaseName = dr["DatabaseName"].ToString();
            model.DbType = m_dbType.ToString();
            model.OperationType = strOperationType;
            model.ServerName = dr["ServerName"].ToString();
            model.TableHistoryName = dr["TableHistoryName"].ToString();
            model.TableName = dr["TableName"].ToString();
            model.TableRemark = dr["TableRemark"].ToString();
            blnLogFlag = m_dal.Add(model) > 0;
            return blnLogFlag;
        }

        /// <summary>生成建表脚本
        /// 生成建表脚本
        /// </summary>
        /// <param name="databaseSchema"></param>
        /// <returns></returns>
        private string AddTableScript(DatabaseSchema databaseSchema)
        {
            DatabaseTable table = databaseSchema.AddTable(txtTableName.Text.Trim());
            table.Description = txtTableDescription.Text.Trim();
            foreach (DataGridViewRow dr in grdTable.Rows)
            {
                if (dr.Cells[colColumnName.Name].Value == null)
                {
                    continue;
                }
                DatabaseColumn databaseColumn = GenDatabaseColumn(dr, table);
                table.AddColumn(databaseColumn);
            }
            var migration = new DdlGeneratorFactory(m_dbType).MigrationGenerator();
            return migration.AddTable(table);
        }

        /// <summary>绑定数据类型
        /// 绑定数据类型
        /// </summary>
        private void BindDataTypes()
        {
            DataTable dtDataTypes = m_sqlTasks.InitDataTypeDataTable();
            colColumnType.DataSource = dtDataTypes;
            colColumnType.DisplayMember = "TypeName";
            colColumnType.ValueMember = "TypeName";
            colColumnType.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            colColumnType.AutoComplete = true;
        }

        /// <summary>绑定列表
        /// 绑定列表
        /// </summary>
        /// <param name="strTableName"></param>
        private void BindGrid(string strTableName)
        {
            string strSql = "SELECT * FROM Bse_DataDictionary WHERE  1=2 ";
            SqlConnection conn = new SqlConnection(GlobalHelp.ConfigConn);
            SqlCommand cmd = new SqlCommand(strSql, conn);
            m_sda = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(m_sda);
            DataSet ds = new DataSet();
            m_sda.Fill(ds, "DataDictionary");
            grdTable.DataSource = ds.Tables["DataDictionary"];
        }

        /// <summary>检查设计表是否符合规范
        /// 检查设计表是否符合规范
        /// </summary>
        /// <returns></returns>
        private bool CheckDesignTable()
        {
            bool blnFlag = true;
            int intCheckPK = 0;
            List<string> lstName = new List<string>();
            for (int i = 0; i < grdTable.Rows.Count; i++)
            {
                if (grdTable.Rows[i].Cells[0].Value == null)
                {
                    continue;
                }

                string strColumnName = grdTable.Rows[i].Cells[colColumnName.Name].Value.ToString();
                if (!lstName.Contains(strColumnName))
                {
                    lstName.Add(strColumnName);
                }
                else
                {
                    MessageBox.Show("存在相同的列名");
                    blnFlag = false;
                    break;
                }
                string strPK = grdTable.Rows[i].Cells[colColumnPK.Name].Value.ToString();
                string strAllowNull = grdTable.Rows[i].Cells[colColumnAllowNull.Name].Value.ToString();
                if (string.IsNullOrEmpty(strPK) == false && strPK.ToUpper() == "TRUE")
                {
                    intCheckPK++;
                    if (intCheckPK > 1)
                    {
                        MessageBox.Show("不能存在两个主键");
                        blnFlag = false;
                        break;
                    }
                }
            }
            return blnFlag;
        }

        /// <summary>检查输入是否符合规范
        /// 检查输入是否符合规范
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            bool blnFlag = false;
            if (txtTableName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请先输入表名！");
                txtTableName.Select();
                blnFlag = true;
            }
            else if (txtTableDescription.Text.Trim() == string.Empty && m_blnNew)
            {
                MessageBox.Show("请输入表说明！");
                txtTableDescription.Select();
                blnFlag = true;
            }
            return blnFlag;
        }

        /// <summary>重新设置Tag
        /// 重新设置Tag
        /// </summary>
        private void ResetTag(DatabaseTable databaseTable)
        {
            //重新设置Tag
            grdTable.DataSource = m_sqlTasks.GenDataTable(databaseTable, m_strServer, m_strDbName, txtTableHistoryName.Text.Trim(), txtTableDescription.Text.Trim());
            (grdTable.DataSource as DataTable).AcceptChanges();
            for (int i = 0; i < grdTable.Rows.Count; i++)
            {
                if (grdTable.Rows[i].Cells[0].Value != null)
                {
                    grdTable.Rows[i].Tag = databaseTable.Columns[i];
                }
            }
        }

        /// <summary> 执行SQL
        /// 执行SQL
        /// </summary>
        /// <param name="rowState"></param>
        /// <param name="strSql"></param>
        /// <param name="dtSource"></param>
        /// <param name="dr"></param>
        /// <param name="databaseColumn"></param>
        /// <returns></returns>
        private bool RunSql(DataRowState rowState, string strSql, DataTable dtSource, DataGridViewRow dr, DatabaseColumn databaseColumn)
        {
            bool blnRunFlag = false;
            m_dbHelper.CreateCommand(strSql);
            DataTable dtResult = m_dbHelper.ExecuteQuery();
            if (dtResult != null && dtResult.Rows.Count == 1)
            {
                dtSource.AcceptChanges();
                dr.Tag = databaseColumn;
                blnRunFlag = true;
            }
            else
            {
                switch (rowState)
                {
                    case DataRowState.Added:
                        MessageBox.Show("新增列失败");
                        break;

                    case DataRowState.Deleted:
                        MessageBox.Show("删除列失败");
                        break;

                    case DataRowState.Detached:
                        break;

                    case DataRowState.Modified:
                        MessageBox.Show("修改列失败");
                        break;

                    case DataRowState.Unchanged:
                        break;

                    default:
                        break;
                }
                blnRunFlag = false;
            }
            return blnRunFlag;
        }

        #endregion 方法
    }
}