using Nikita.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Nikita.Assist.CodeMaker.Model;
using Nikita.Base.Define;

namespace Nikita.Assist.CodeMaker.Template.ClassTemplate
{
    public class TemplateWinFormSimpleQuery : CodeMakeBulider
    {
        public static int SumWidth = 1000;
        public static int BeginWidth = 15;
        public static int LocationX = 15;
        public static int CtlSpace = 11;
        public static int LocationY = 15;
        public static int HighSeed = 30;

        public static int SumWidthEdit = 1000;
        public static int BeginWidthEdit = 15;
        public static int LocationXEdit = 15;
        public static int LocationYEdit = 15;
        public static int HighSeedEdit = 25;

        public static int QueryHeight = 1;
        public static int EditHeight = 1;
        public override string GenWinFormCS(BasicParameter parameter, BaseParameter baseParameter)
        {
            string strFrmClassName = "Frm" + parameter.ClassName + "SimpleQuery";
            string strFrmDialogClassName = "Frm" + parameter.ClassName + "SimpleDialog";
            string strDalName = parameter.TableName + "DAL";
            string strModelName = parameter.TableName;
            string strKeyId = Tools.GetPKey_MSSQL(parameter.TableName, parameter.Conn);
            string strRetrunList = "List" + strModelName + " ";
            string strGlobalList = "m_lst" + strModelName.Replace("_", "");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("/// <summary>说明:" + strFrmClassName + "文件");
            sb.AppendLine("/// 作者:" + parameter.Author + "");
            sb.AppendLine("/// 创建时间:" + DateTime.Now + "");
            sb.AppendLine("/// </summary>");
            sb.AppendLine("using " + parameter.NameSpace + ".DAL;");
            sb.AppendLine("using " + parameter.NameSpace + ".Model;");
            sb.AppendLine("using Nikita.Core;");
            sb.AppendLine("using Nikita.WinForm.ExtendControl;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.ComponentModel;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Diagnostics;");
            sb.AppendLine("using System.Drawing;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Windows.Forms;");
            sb.AppendLine("using Nikita.Base.Define;");
            sb.AppendLine("using Nikita.Base.IDAL;");

            sb.AppendLine("namespace " + parameter.NameSpace + "");
            sb.AppendLine("{");
            sb.AppendLine("    /// <summary>说明:" + strFrmClassName + "");
            sb.AppendLine("    /// 作者:Luhm");
            sb.AppendLine("    /// 最后修改人:");
            sb.AppendLine("    /// 最后修改时间:");
            sb.AppendLine("    /// 创建时间:" + DateTime.Now + "");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public partial class " + strFrmClassName + " : Form");
            sb.AppendLine("    {");

            #region 常量、变量
            sb.AppendLine("        #region 常量、变量");
            sb.AppendLine("  /// <summary>DataGridView下拉框绑定数据源");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private DataSet m_dsGridSource;");
            sb.AppendLine("        /// <summary>操作类");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            //sb.AppendLine("        private "+ strDalName + " m_" + strDalName + "; ");
            sb.AppendLine("        private IBseDAL<" + strModelName + "> m_" + strDalName + "; ");

            sb.AppendLine("        /// <summary>结果集合");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private List<" + strModelName + ">  " + strGlobalList + "  ;");
            sb.AppendLine("        #endregion");
            sb.AppendLine("          ");
            #endregion

            #region 构造函数
            sb.AppendLine("        #region 构造函数");
            sb.AppendLine("        /// <summary>构造函数");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public " + strFrmClassName + "()");
            sb.AppendLine("        {");

            sb.AppendLine("            InitializeComponent(); ");
            sb.AppendLine("            grdData.ShowCellToolTips = false;");
            sb.AppendLine("            grdData.AutoGenerateColumns = false;");
            //sb.AppendLine("            m_" + strDalName + "= new  " + strDalName + "();");
            sb.AppendLine(" m_" + strDalName + " = GlobalHelp.GetResolve<IBseDAL<" + strModelName + ">>();");
            //sb.AppendLine("            m_Sys_RolesDAL = new Sys_RolesDAL(); ");
            sb.AppendLine("            grdData.RowsAdded += this.grdData_RowsAdded;");
            sb.AppendLine("            grdData.RowPostPaint += grdData_RowPostPaint;");
            sb.AppendLine("            grdData.CellMouseEnter += this.grdData_CellMouseEnter;");
            sb.AppendLine("            grdData.CellMouseLeave += this.grdData_CellMouseLeave;");
            sb.AppendLine("            grdData.CellDoubleClick += this.grdData_CellDoubleClick;");
            sb.AppendLine("            toolTip.Draw += this.toolTip_Draw;");
            sb.AppendLine("            DoInitData();");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");
            #endregion

            #region 基础事件
            sb.AppendLine("          ");
            sb.AppendLine("        #region 基础事件");
            #region btnQuery_Click
            sb.AppendLine("        /// <summary>查询");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\">sender</param>");
            sb.AppendLine("        /// <param name=\"e\">e</param>");
            sb.AppendLine("        private void btnQuery_Click(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            DoQueryData();");
            sb.AppendLine("        }");
            #endregion
            #region Command_Click
            sb.AppendLine("        /// <summary>执行命令");
            sb.AppendLine("        /// ");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\">sender</param>");
            sb.AppendLine("        /// <param name=\"e\">e</param>");
            sb.AppendLine("        private void Command_Click(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            ToolStripItem cmdItem = sender as ToolStripItem;");
            sb.AppendLine("            if (cmdItem != null)");
            sb.AppendLine("            {");
            sb.AppendLine("                switch (cmdItem.Name.Trim())");
            sb.AppendLine("                {");
            sb.AppendLine("                    case \"cmdFirst\":");
            sb.AppendLine("                    case \"cmdPre\":");
            sb.AppendLine("                    case \"cmdNext\":");
            sb.AppendLine("                    case \"cmdLast\":");
            sb.AppendLine("                        DoGo(cmdItem.Name.Trim());");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case \"cmdImportExcel\":");
            sb.AppendLine("                        DoImportExcel();");
            sb.AppendLine("                        break;");
            sb.AppendLine("                    case \"cmdRefresh\":");
            sb.AppendLine("                        DoQueryData();");
            sb.AppendLine("                        break;");
            if (baseParameter.CodeGenType == CodeGenType.WinFromEditWithDialog)
            {
                sb.AppendLine("                     case  \"cmdNew\":");
                sb.AppendLine("                        DoNew();");
                sb.AppendLine("                        break;");
                sb.AppendLine("                    case  \"cmdEdit\":");
                sb.AppendLine("                        DoEdit();");
                sb.AppendLine("                        break;");
                sb.AppendLine("                    case  \"cmdDelete\":");
                sb.AppendLine("                        DoDeleteOrCancel( \"删除 \");");
                sb.AppendLine("                        break;");
                sb.AppendLine("                    case  \"cmdCancel\":");
                sb.AppendLine("                        DoDeleteOrCancel( \"作废 \");");
                sb.AppendLine("                        break;");
            }
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("         ");
            #endregion
            #region grdData_RowPostPaint
            sb.AppendLine("        /// <summary>生成列序号");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\">sender</param>");
            sb.AppendLine("        /// <param name=\"e\">e</param>");
            sb.AppendLine("        private void grdData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            var dataGridView = sender as DataGridView;");
            sb.AppendLine("            if (dataGridView != null)");
            sb.AppendLine("            {");
            sb.AppendLine("                SolidBrush b = new SolidBrush(dataGridView.RowHeadersDefaultCellStyle.ForeColor);");
            sb.AppendLine("                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), dataGridView.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            #endregion
            #region grdData_RowsAdded
            sb.AppendLine("        private void grdData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (m_dsGridSource == null)");
            sb.AppendLine("            {");
            string strBindGridSql = GenControlHelper.GetBindSourceSqlByTableNameForGrid(parameter.TableName);
            if (!string.IsNullOrEmpty(strBindGridSql))
            {
                sb.AppendLine("const string strBindGridSql=\"" + strBindGridSql + "\";");
                sb.AppendLine("  BindClass bindClass = new BindClass()");
                sb.AppendLine("  {");
                sb.AppendLine("     SqlType = SqlType.SqlServer,");
                sb.AppendLine("      BindSql =strBindGridSql");
                sb.AppendLine("   }; ");
                sb.AppendLine("m_dsGridSource =BindSourceHelper.GetBindSourceDataSet(bindClass,GlobalHelp.Conn); ");
            }
            //sb.AppendLine("                m_dsGridSource = new DataSet();");
            //sb.AppendLine("                DataTable dt = new DataTable();");
            //sb.AppendLine("                dt.Columns.Add("Name", typeof(string));");
            //sb.AppendLine("                dt.Columns.Add("Value", typeof(int));");
            //sb.AppendLine("                DataRow dr = dt.NewRow();");
            //sb.AppendLine("                dr[0] = "排序1";");
            //sb.AppendLine("                dr[1] = 1;");

            //sb.AppendLine("                DataRow dr1 = dt.NewRow();");
            //sb.AppendLine("                dr1[0] = "排序2";");
            //sb.AppendLine("                dr1[1] = 2;");
            //sb.AppendLine("                DataRow dr2 = dt.NewRow();");
            //sb.AppendLine("                dr2[0] = "排序3";");
            //sb.AppendLine("                dr2[1] = 3;");

            //sb.AppendLine("                DataRow dr3 = dt.NewRow();");
            //sb.AppendLine("                dr3[0] = "排序9";");
            //sb.AppendLine("                dr3[1] = 9;");
            //sb.AppendLine("                dt.Rows.Add(dr);");
            //sb.AppendLine("                dt.Rows.Add(dr1);");
            //sb.AppendLine("                dt.Rows.Add(dr2);");
            //sb.AppendLine("                dt.Rows.Add(dr3);");
            //sb.AppendLine("                dt.TableName = "gridmrzSortnum";");
            //sb.AppendLine("                m_dsGridSource.Tables.Add(dt);");
            sb.AppendLine("            } ");
            sb.AppendLine(GenControlHelper.GenBindDataSouceForGrid(parameter.TableName));
            //sb.AppendLine("            DataGridViewComboBoxCell DgvCell = this.grdData.Rows[e.RowIndex].Cells[gridmrzSortnum.Name] as DataGridViewComboBoxCell; ");
            //sb.AppendLine("            ComboBoxHelper.BindDataGridViewComboBoxCell(DgvCell, m_dsGridSource.Tables["gridmrzSortnum"], "Name", "Value");");
            sb.AppendLine("        }");
            sb.AppendLine("        ");
            #endregion
            #region  grdData_CellDoubleClick
            if (baseParameter.CodeGenType == CodeGenType.WinFromEditWithDialog)
            {
                sb.AppendLine("  private void grdData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)");
                sb.AppendLine("        {");
                sb.AppendLine("            Command_Click(cmdEdit, null);");
                sb.AppendLine("        }");
                sb.AppendLine("        ");
            }
            #endregion
            #region  Pager_PageChanged
            sb.AppendLine("        /// <summary>分页事件");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"sender\">sender</param>");
            sb.AppendLine("        /// <param name=\"e\">e</param>");
            sb.AppendLine("        private void Pager_PageChanged(object sender, EventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            DoQueryData();");
            sb.AppendLine("        }");
            #endregion

            #region ToolTip
            sb.AppendLine("        private void grdData_CellMouseEnter(object sender, DataGridViewCellEventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (e.RowIndex < 0 || e.ColumnIndex < 0)");
            sb.AppendLine("            {");
            sb.AppendLine("                return;");
            sb.AppendLine("            }");
            sb.AppendLine("            this.toolTip.Hide(this.grdData);");
            sb.AppendLine("            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)");
            sb.AppendLine("            {");
            sb.AppendLine("                DataGridViewRow row = grdData.Rows[e.RowIndex];");
            sb.AppendLine("                string strCellToolTipText = DataGridViewHelper.GetDataRowInfo(grdData, row);");
            sb.AppendLine("                this.toolTip.Show(strCellToolTipText, this.grdData);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");

            sb.AppendLine("        private void grdData_CellMouseLeave(object sender, DataGridViewCellEventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            this.toolTip.Hide(this.grdData);");
            sb.AppendLine("        }");

            sb.AppendLine("        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)");
            sb.AppendLine("        {");
            sb.AppendLine("            e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds);");
            sb.AppendLine("            e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1));");
            sb.AppendLine("            e.Graphics.DrawString(this.toolTip.ToolTipTitle + e.ToolTipText, e.Font, Brushes.Blue, e.Bounds);");
            sb.AppendLine("        }");
            #endregion 
            sb.AppendLine("        #endregion");
            #endregion

            #region 基础方法
            sb.AppendLine("          ");
            sb.AppendLine("        #region 基础方法");
            #region DoGo
            sb.AppendLine("        /// <summary>上一条、下一条、第一条、最后一条记录");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"cmdfirst\">执行命令</param>");
            sb.AppendLine("        private void DoGo(string cmdfirst)");
            sb.AppendLine("        {");
            sb.AppendLine("            switch (cmdfirst)");
            sb.AppendLine("            {");
            sb.AppendLine("                case \"cmdFirst\":");
            sb.AppendLine("                    if (grdData.Rows.Count > 0)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        grdData.ClearSelection();");
            sb.AppendLine("                        grdData.Rows[0].Selected = true;");
            sb.AppendLine("                        grdData.FirstDisplayedScrollingRowIndex = 0;");
            sb.AppendLine("                    }");
            sb.AppendLine("                    break;");

            sb.AppendLine("                case \"cmdPre\":");

            sb.AppendLine("                    if (grdData.SelectedRows.Count > 0)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        int intSelectIndex = grdData.SelectedRows[0].Index;");
            sb.AppendLine("                        if (intSelectIndex > 0)");
            sb.AppendLine("                        {");
            sb.AppendLine("                            grdData.Rows[intSelectIndex - 1].Selected = true;");
            sb.AppendLine("                            grdData.Rows[intSelectIndex].Selected = false;");
            sb.AppendLine("                            grdData.FirstDisplayedScrollingRowIndex = intSelectIndex;");
            sb.AppendLine("                        }");
            sb.AppendLine("                    }");
            sb.AppendLine("                    break;");

            sb.AppendLine("                case \"cmdNext\":");
            sb.AppendLine("                    if (grdData.SelectedRows.Count > 0)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        int intSelectIndex = grdData.SelectedRows[0].Index;");
            sb.AppendLine("                        if (intSelectIndex + 1 < grdData.Rows.Count  )");
            sb.AppendLine("                        {");
            sb.AppendLine("                            grdData.Rows[intSelectIndex + 1].Selected = true;");
            sb.AppendLine("                            grdData.Rows[intSelectIndex].Selected = false;");
            sb.AppendLine("                            grdData.FirstDisplayedScrollingRowIndex = intSelectIndex;");
            sb.AppendLine("                        }");
            sb.AppendLine("                    }");
            sb.AppendLine("                    break;");

            sb.AppendLine("                case \"cmdLast\":");
            sb.AppendLine("                    if (grdData.Rows.Count > 0)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        grdData.ClearSelection();");
            sb.AppendLine("                        grdData.Rows[grdData.Rows.Count - 1].Selected = true;");
            sb.AppendLine("                        grdData.FirstDisplayedScrollingRowIndex = grdData.Rows.Count - 1;");
            sb.AppendLine("                    }");
            sb.AppendLine("                    break;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            #endregion
            #region DoImportExcel
            sb.AppendLine("        /// <summary>导出Excel");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void DoImportExcel()");
            sb.AppendLine("        {");
            sb.AppendLine("            string strResult = NPOIHelper.ExportToExcel(grdData, \"导出结果\");");
            sb.AppendLine("            if (!string.IsNullOrEmpty(strResult))");
            sb.AppendLine("            {");
            sb.AppendLine("                if (MessageBox.Show(@\"导出成功,是否打开？\", @\"提示\", MessageBoxButtons.YesNo) == DialogResult.Yes)");
            sb.AppendLine("                {");
            sb.AppendLine("                    Process.Start(strResult);");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            else");
            sb.AppendLine("            {");
            sb.AppendLine("                MessageBox.Show(@\"导出失败\");");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        ");
            #endregion
            #region DoInitData
            sb.AppendLine("        /// <summary>初始化绑定下拉框等");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void DoInitData()");
            sb.AppendLine("        { ");
            string strBindSql = GenControlHelper.GetBindSourceSqlByTableName(parameter.TableName);
            if (!string.IsNullOrEmpty(strBindSql))
            {
                sb.AppendLine(" const string strBindSql=\"" + strBindSql + "\";");
                sb.AppendLine("  BindClass bindClass = new BindClass()");
                sb.AppendLine("  {");
                sb.AppendLine("     SqlType = SqlType.SqlServer,");
                sb.AppendLine("      BindSql =strBindSql");
                sb.AppendLine("   }; ");
                sb.AppendLine("DataSet ds =BindSourceHelper.GetBindSourceDataSet(bindClass,GlobalHelp.Conn); ");
                sb.AppendLine(GenControlHelper.GenBindDataSouce(parameter.TableName, PanelType.查询面板));
            }
            //sb.AppendLine("            DataTable dt=new DataTable();");
            //sb.AppendLine("            dt.Columns.Add(\"Name\", typeof(string));");
            //sb.AppendLine("            dt.Columns.Add(\"Value\", typeof(string));");
            //sb.AppendLine("            foreach (string strItem in LoadTypeAry)");
            //sb.AppendLine("            {");
            //sb.AppendLine("                DataRow dr = dt.NewRow();");
            //sb.AppendLine("                dr[0] = strItem;");
            //sb.AppendLine("                dr[1] = strItem;");
            //sb.AppendLine("                dt.Rows.Add(dr);");
            //sb.AppendLine("            }");
            //sb.AppendLine("            CheckedComboBoxHelper.BindCheckedComboBox(cbkID, dt, \"Name\", \"Value\");");
            sb.AppendLine("        }");
            #endregion
            #region DoQueryData
            sb.AppendLine("        /// <summary>执行查询");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void DoQueryData()");
            sb.AppendLine("        {");
            sb.AppendLine("    try");
            sb.AppendLine("            {");
            sb.AppendLine("                btnQuery.Enabled = false;");
            sb.AppendLine("            string strWhere = GetSearchSql();");
            sb.AppendLine("        " + strGlobalList + " =   m_" + strDalName + ".GetListArray(\"*\", \"" + strKeyId + "\", \"ASC\", Pager.PageSize, Pager.PageIndex, strWhere);");
            sb.AppendLine("            Pager.RecordCount = m_" + strDalName + ".CalcCount(strWhere);");
            sb.AppendLine("            Pager.InitPageInfo();");
            sb.AppendLine("            grdData.DataSource =    " + strGlobalList + ";");
            sb.AppendLine("            }");
            sb.AppendLine("       catch (Exception)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw;");
            sb.AppendLine("            }");
            sb.AppendLine("            finally");
            sb.AppendLine("            { ");
            sb.AppendLine("                btnQuery.Enabled = true;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            #endregion
            #region GetSearchSql
            sb.AppendLine("        /// <summary>根据查询条件构造查询语句");
            sb.AppendLine("        ///");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns>查询条件</returns>");
            sb.AppendLine("        private string GetSearchSql()");
            sb.AppendLine("        {");
            sb.AppendLine(SearchConditionHelper.GetSearchCondition(parameter.TableName));
            //sb.AppendLine("            SearchCondition condition = new SearchCondition();");
            //sb.AppendLine("            condition.AddCondition(\"UserName\", this.txtQueryUserName.Text, SqlOperator.Like)");
            //sb.AppendLine("                .AddCondition(\"TrueName\", cboQueryTrueName.Text, SqlOperator.Like)");
            //sb.AppendLine("                .AddCondition(\"User_Id\",  cbkID.CheckedItemValues.TrimEnd(','), SqlOperator.In);");
            //sb.AppendLine("            return condition.BuildConditionSql().Replace(\"Where\", \"\");");
            sb.AppendLine("        }");
            #endregion

            if (baseParameter.CodeGenType == CodeGenType.WinFromEditWithDialog)
            {
                #region DoDeleteOrCancel
                sb.AppendLine("        /// <summary>删除/作废");
                sb.AppendLine("        /// ");
                sb.AppendLine("        /// </summary>");
                sb.AppendLine("        /// <param name=\"strOperation\">操作类型</param>");
                sb.AppendLine("        private void DoDeleteOrCancel(string strOperation)");
                sb.AppendLine("        {");
                sb.AppendLine("            string strMsg = CheckSelect(strOperation);");
                sb.AppendLine("            if (strMsg != string.Empty)");
                sb.AppendLine("            {");
                sb.AppendLine("                MessageBox.Show(strMsg);");
                sb.AppendLine("                return;");
                sb.AppendLine("            }");
                sb.AppendLine("            string strIds = DataGridViewHelper.GetColumnValuesBySelectRows(grdData.SelectedRows, gridmrz" + strKeyId + ".Name);");
                sb.AppendLine("            var blnReturn = strOperation.Trim() == \"删除\" ?   m_" + strDalName + ".DeleteByCond(\" " + strKeyId + " in (\" + strIds + \")\") :    m_" + strDalName + ".Update(\"Status =0\", \" " + strKeyId + " in (\" + strIds + \")\");");
                sb.AppendLine("            if (blnReturn)");
                sb.AppendLine("            {");
                sb.AppendLine("                MessageBox.Show(string.Format(\"{0}成功\", strOperation)); ");
                sb.AppendLine("                DoQueryData();");
                sb.AppendLine("            }");
                sb.AppendLine("            else");
                sb.AppendLine("            {");
                sb.AppendLine("                MessageBox.Show(string.Format(\"{0}失败\", strOperation));");
                sb.AppendLine("            }");
                sb.AppendLine("        }");
                #endregion
                #region DoEdit
                sb.AppendLine("        /// <summary>编辑");
                sb.AppendLine("        ///");
                sb.AppendLine("        /// </summary>");
                sb.AppendLine("        private void DoEdit()");
                sb.AppendLine("        {");
                sb.AppendLine("            string strMsg = CheckSelect(\"修改\");");
                sb.AppendLine("            if (strMsg != string.Empty)");
                sb.AppendLine("            {");
                sb.AppendLine("                MessageBox.Show(strMsg);");
                sb.AppendLine("                return;");
                sb.AppendLine("            }");
                sb.AppendLine("            DataGridViewRow drRowEdit = grdData.SelectedRows[0];");
                sb.AppendLine("            " + strModelName + " model = drRowEdit.Tag as   " + strModelName + " ;");
                sb.AppendLine("            if (model == null)");
                sb.AppendLine("            {");
                sb.AppendLine("                int intKeyID = int.Parse(drRowEdit.Cells[gridmrz" + strKeyId + ".Name].Value.ToString());");
                sb.AppendLine("                model = m_" + strDalName + ".GetModel(intKeyID);");
                sb.AppendLine("            }");
                sb.AppendLine("            if (model != null)");
                sb.AppendLine("            {");
                sb.AppendLine("                " + strFrmDialogClassName + " frmDialog = new       " + strFrmDialogClassName + "(model,   " + strGlobalList + ");");
                sb.AppendLine("                if (frmDialog.ShowDialog() == DialogResult.OK)");
                sb.AppendLine("                {");
                sb.AppendLine("                        " + strGlobalList + " = frmDialog." + strRetrunList + ";");
                sb.AppendLine("                    grdData.DataSource =   " + strGlobalList + ";");
                sb.AppendLine("                    grdData.Refresh();");
                sb.AppendLine("                }");
                sb.AppendLine("            }");
                sb.AppendLine("        }");
                #endregion
                #region DoNew
                sb.AppendLine("        /// <summary>新增");
                sb.AppendLine("        ///");
                sb.AppendLine("        /// </summary>");
                sb.AppendLine("        private void DoNew()");
                sb.AppendLine("        {");
                sb.AppendLine("              " + strFrmDialogClassName + " frmDialog = new   " + strFrmDialogClassName + "(null,  " + strGlobalList + ");");
                sb.AppendLine("            if (frmDialog.ShowDialog() == DialogResult.OK)");
                sb.AppendLine("            {");
                sb.AppendLine("                " + strGlobalList + " = frmDialog." + strRetrunList + ";");
                sb.AppendLine("    if (grdData.DataSource != null)");
                sb.AppendLine("                {");
                sb.AppendLine("                    this.BindingContext[grdData.DataSource].SuspendBinding();");
                sb.AppendLine("                }");
                sb.AppendLine("                grdData.DataSource = null;");
                sb.AppendLine("                grdData.DataSource =  " + strGlobalList + ";");
                sb.AppendLine("                this.BindingContext[grdData.DataSource].ResumeBinding();");
                sb.AppendLine("            }");
                sb.AppendLine("        }");
                #endregion

                #region CheckSelect
                sb.AppendLine("         ");
                sb.AppendLine("        /// <summary>检查选择");
                sb.AppendLine("        /// ");
                sb.AppendLine("        /// </summary>");
                sb.AppendLine("        /// <param name=\"strOperation\">操作说明</param>");
                sb.AppendLine("        /// <returns>返回提示信息</returns>");
                sb.AppendLine("        private string CheckSelect(string strOperation)");
                sb.AppendLine("        {");
                sb.AppendLine("            string strMsg = string.Empty;");
                sb.AppendLine("            if (grdData.SelectedRows.Count==0)");
                sb.AppendLine("            {");
                sb.AppendLine("                strMsg = string.Format(\"请选择要{0}的行数据\", strOperation);");
                sb.AppendLine("            }");
                sb.AppendLine("            return strMsg;");
                sb.AppendLine("        }");
                #endregion
            }

            sb.AppendLine("        #endregion");
            #endregion
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();
        }

        public override string GenWinFormDesign(BasicParameter parameter, BaseParameter baseParameter)
        {
            string strFrmClassName = "Frm" + parameter.ClassName + "SimpleQuery";
            List<Bse_UI> lstBseUiQuery = BseUIManager.GetListUIQuery(parameter.TableName);
            List<Bse_UI> lstBseUiShow = BseUIManager.GetListUIShow(parameter.TableName);
            int lblWidth = BseUIManager.GetCtlWidth("Label");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("namespace " + parameter.NameSpace + "");
            sb.AppendLine("{");
            sb.AppendLine("    partial class " + strFrmClassName + "");
            sb.AppendLine("    {");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Required designer variable.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private System.ComponentModel.IContainer components = null;");

            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Clean up any resources being used.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine(
                "        /// <param name=\"disposing\">true if managed resources should be disposed; otherwise, false.</param>");
            sb.AppendLine("        protected override void Dispose(bool disposing)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (disposing && (components != null))");
            sb.AppendLine("            {");
            sb.AppendLine("                components.Dispose();");
            sb.AppendLine("            }");
            sb.AppendLine("            base.Dispose(disposing);");
            sb.AppendLine("        }");

            sb.AppendLine("        #region Windows Form Designer generated code");

            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Required method for Designer support - do not modify");
            sb.AppendLine("        /// the contents of this method with the code editor.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        private void InitializeComponent()");
            sb.AppendLine("        {");

            sb.AppendLine("       this.components = new System.ComponentModel.Container();");
            sb.AppendLine(
                "            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(" +
                strFrmClassName + "));");
            sb.AppendLine("            this.sptAll = new System.Windows.Forms.SplitContainer();");
            sb.AppendLine("            this.sptQuery = new System.Windows.Forms.SplitContainer();");
            //sb.AppendLine("            this.label1 = new System.Windows.Forms.Label();");
            //sb.AppendLine("            this.cbkID = new Nikita.WinForm.ExtendControl.CheckedComboBox();");
            //sb.AppendLine("            this.cboQueryTrueName = new System.Windows.Forms.ComboBox();");
            //sb.AppendLine("            this.lblQueryTrueName = new System.Windows.Forms.Label();");
            //sb.AppendLine("            this.txtQueryUserName = new System.Windows.Forms.TextBox();");
            //sb.AppendLine("            this.lblQueryUserName = new System.Windows.Forms.Label();");

            #region 查询面板控件

            foreach (Bse_UI ui in lstBseUiQuery)
            {
                if (ui.IsAddLable == "True")
                {
                    sb.AppendLine("this." + ui.LabelName + " = new System.Windows.Forms.Label();");
                    sb.AppendLine("            this." + ui.ControlName + " = new " + ui.ControlNameSpace + "();");
                }
                else
                {
                    sb.AppendLine("            this." + ui.ControlName + " = new " + ui.ControlNameSpace + "();");
                }
            }

            #endregion

            sb.AppendLine("            this.btnQuery = new System.Windows.Forms.Button();");
            sb.AppendLine("            this.sptView = new System.Windows.Forms.SplitContainer();");
            sb.AppendLine("            this.grdData = new System.Windows.Forms.DataGridView();");

            #region DataGridView显示列

            foreach (Bse_UI ui in lstBseUiShow)
            {
                if (string.IsNullOrEmpty(ui.ControlNameSpace))
                {
                    sb.AppendLine("            this." + ui.ControlName +
                                  " = new System.Windows.Forms.DataGridViewTextBoxColumn();");
                }
                else
                {
                    //Dx控件
                    if (ui.ControlNameSpace.Contains("Devexpress"))
                    {
                        //sb.AppendLine("            this." + ui.ControlName +
                        //              " = newSystem.Windows.Forms.DataGridViewTextBoxColumn();");
                    }
                    sb.AppendLine("            this." + ui.ControlName + " = new " + ui.ControlNameSpace + "();");
                }
            }

            #endregion

            //sb.AppendLine("            this.colUser_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();");
            //sb.AppendLine("            this.colTrueName = new System.Windows.Forms.DataGridViewTextBoxColumn();");
            sb.AppendLine("            this.Pager = new Nikita.WinForm.ExtendControl.Pager();");
            sb.AppendLine("            this.tspCommand = new System.Windows.Forms.ToolStrip();");
            sb.AppendLine("            this.cmdFirst = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdPre = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdNext = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdLast = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdSep1 = new System.Windows.Forms.ToolStripSeparator();");
            sb.AppendLine("            this.cmdRefresh = new System.Windows.Forms.ToolStripButton();");
            sb.AppendLine("            this.cmdImport = new System.Windows.Forms.ToolStripSplitButton();");
            sb.AppendLine("            this.cmdImportExcel = new System.Windows.Forms.ToolStripMenuItem();");
            if (baseParameter.CodeGenType == CodeGenType.WinFromEditWithDialog)
            {
                sb.AppendLine("            this.cmdCancel = new System.Windows.Forms.ToolStripButton();");
                sb.AppendLine("            this.cmdDelete = new System.Windows.Forms.ToolStripButton();");
                sb.AppendLine("            this.cmdEdit = new System.Windows.Forms.ToolStripButton();");
                sb.AppendLine("            this.cmdNew = new System.Windows.Forms.ToolStripButton();");
            }
            sb.AppendLine(" this.toolTip = new System.Windows.Forms.ToolTip(this.components);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptAll)).BeginInit();");
            sb.AppendLine("            this.sptAll.Panel1.SuspendLayout();");
            sb.AppendLine("            this.sptAll.Panel2.SuspendLayout();");
            sb.AppendLine("            this.sptAll.SuspendLayout();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptQuery)).BeginInit();");
            sb.AppendLine("            this.sptQuery.Panel1.SuspendLayout();");
            sb.AppendLine("            this.sptQuery.Panel2.SuspendLayout();");
            sb.AppendLine("            this.sptQuery.SuspendLayout();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptView)).BeginInit();");
            sb.AppendLine("            this.sptView.Panel1.SuspendLayout();");
            sb.AppendLine("            this.sptView.Panel2.SuspendLayout();");
            sb.AppendLine("            this.sptView.SuspendLayout();");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();");
            sb.AppendLine("            this.tspCommand.SuspendLayout();");
            foreach (Bse_UI ui in lstBseUiQuery)
            {
                if (ui.ControlNameSpace == "System.Windows.Forms.NumericUpDown")
                {
                    sb.AppendLine("       ((System.ComponentModel.ISupportInitialize)(this." + ui.ControlName + ")).BeginInit();");
                }
            }
            sb.AppendLine("            this.SuspendLayout();");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptAll");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptAll.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.sptAll.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;");
            sb.AppendLine("            this.sptAll.Location = new System.Drawing.Point(0, 26);");
            sb.AppendLine("            this.sptAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);");
            sb.AppendLine("            this.sptAll.Name = \"sptAll\";");
            sb.AppendLine("            this.sptAll.Orientation = System.Windows.Forms.Orientation.Horizontal;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptAll.Panel1");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptAll.Panel1.Controls.Add(this.sptQuery);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptAll.Panel2");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptAll.Panel2.Controls.Add(this.sptView);");
            sb.AppendLine("            this.sptAll.Size = new System.Drawing.Size(907, 535);");
            sb.AppendLine("            this.sptAll.SplitterDistance = 61;");
            sb.AppendLine("            this.sptAll.SplitterWidth = 6;");
            sb.AppendLine("            this.sptAll.TabIndex = 2;");
            sb.AppendLine("            this.sptAll.Click += new System.EventHandler(this.btnQuery_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptQuery");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;");
            sb.AppendLine("            this.sptQuery.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.sptQuery.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;");
            sb.AppendLine("            this.sptQuery.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.sptQuery.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);");
            sb.AppendLine("            this.sptQuery.Name =  \"sptQuery \";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptQuery.Panel1");
            sb.AppendLine("            // ");

            #region 查询区控件

            foreach (Bse_UI ui in lstBseUiQuery)
            {
                if (ui.IsAddLable == "True")
                {
                    sb.AppendLine("            this.sptQuery.Panel1.Controls.Add(this." + ui.LabelName + ");");
                }
                sb.AppendLine("            this.sptQuery.Panel1.Controls.Add(this." + ui.ControlName + ");");
            }

            #endregion

            //sb.AppendLine("            this.sptQuery.Panel1.Controls.Add(this.label1);");
            //sb.AppendLine("            this.sptQuery.Panel1.Controls.Add(this.cbkID);");
            //sb.AppendLine("            this.sptQuery.Panel1.Controls.Add(this.cboQueryTrueName);");
            //sb.AppendLine("            this.sptQuery.Panel1.Controls.Add(this.lblQueryTrueName);");
            //sb.AppendLine("            this.sptQuery.Panel1.Controls.Add(this.txtQueryUserName);");
            //sb.AppendLine("            this.sptQuery.Panel1.Controls.Add(this.lblQueryUserName);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptQuery.Panel2");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptQuery.Panel2.Controls.Add(this.btnQuery);");
            sb.AppendLine("            this.sptQuery.Size = new System.Drawing.Size(907, 61);");
            sb.AppendLine("            this.sptQuery.SplitterDistance = 783;");
            sb.AppendLine("            this.sptQuery.SplitterWidth = 5;");
            sb.AppendLine("            this.sptQuery.TabIndex = 2;");
            sb.AppendLine("            this.sptQuery.Click += new System.EventHandler(this.btnQuery_Click);");

            #region 查询区控件明细位置

            BeginWidth = 15;
            foreach (Bse_UI ui in lstBseUiQuery)
            {
                int intCurrCtlWidth = BseUIManager.GetCtlWidth(ui.ControlType);
                if (ui.IsAddLable == "True")
                {
                    //控制位置
                    if (BeginWidth + lblWidth + intCurrCtlWidth > SumWidth)
                    {
                        QueryHeight += 1;
                        LocationX = 15;
                        LocationY = LocationY + HighSeed;
                        BeginWidth = 15;
                        BeginWidth += lblWidth + CtlSpace;
                    }
                    else
                    {
                        LocationX = BeginWidth;
                        BeginWidth += lblWidth + CtlSpace;
                    }
                    sb.Append(GenControlHelper.CreateLabelControl(ui.LabelName, ui.LabelText, LocationX, LocationY));
                }

                //控制位置
                if (BeginWidth + intCurrCtlWidth > SumWidth)
                {
                    QueryHeight += 1;
                    LocationX = 15;
                    LocationY = LocationY + HighSeed;
                    BeginWidth = 15;
                    BeginWidth += intCurrCtlWidth + CtlSpace;
                }
                else
                {
                    LocationX = BeginWidth;
                    BeginWidth += intCurrCtlWidth + CtlSpace;
                }
                sb.Append(GenControlHelper.CreateControl(ui.Ctl_Simple, ui.ControlName, LocationX, LocationY,
                    ui.ControlSort));

            }
            int hight = QueryHeight * (HighSeed + 5) + 30;
            if (hight < 87)
            {
                hight = 87;
            }
            sb.Replace("@QueryHeight@", hight.ToString());

            #endregion

            //sb.AppendLine("            // ");
            //sb.AppendLine("            // label1");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.label1.AutoSize = true;");
            //sb.AppendLine("            this.label1.Location = new System.Drawing.Point(445, 21);");
            //sb.AppendLine("            this.label1.Name = \"label1\";");
            //sb.AppendLine("            this.label1.Size = new System.Drawing.Size(32, 17);");
            //sb.AppendLine("            this.label1.TabIndex = 5;");
            //sb.AppendLine("            this.label1.Text =  \"序号 \";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // cbkID");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.cbkID.CheckOnClick = true;");
            //sb.AppendLine("            this.cbkID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;");
            //sb.AppendLine("            this.cbkID.DropDownHeight = 1;");
            //sb.AppendLine("            this.cbkID.FormattingEnabled = true;");
            //sb.AppendLine("            this.cbkID.IntegralHeight = false;");
            //sb.AppendLine("            this.cbkID.Location = new System.Drawing.Point(483, 17);");
            //sb.AppendLine("            this.cbkID.Name =  \"cbkID \";");
            //sb.AppendLine("            this.cbkID.Size = new System.Drawing.Size(121, 24);");
            //sb.AppendLine("            this.cbkID.TabIndex = 4;");
            //sb.AppendLine("            this.cbkID.ValueSeparator =  \",  \";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // cboQueryTrueName");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.cboQueryTrueName.FormattingEnabled = true;");
            //sb.AppendLine("            this.cboQueryTrueName.Location = new System.Drawing.Point(268, 17);");
            //sb.AppendLine("            this.cboQueryTrueName.Name =  \"cboQueryTrueName \";");
            //sb.AppendLine("            this.cboQueryTrueName.Size = new System.Drawing.Size(121, 25);");
            //sb.AppendLine("            this.cboQueryTrueName.TabIndex = 3;");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // lblQueryTrueName");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.lblQueryTrueName.AutoSize = true;");
            //sb.AppendLine("            this.lblQueryTrueName.Location = new System.Drawing.Point(217, 21);");
            //sb.AppendLine("            this.lblQueryTrueName.Name =  \"lblQueryTrueName \";");
            //sb.AppendLine("            this.lblQueryTrueName.Size = new System.Drawing.Size(44, 17);");
            //sb.AppendLine("            this.lblQueryTrueName.TabIndex = 2;");
            //sb.AppendLine("            this.lblQueryTrueName.Text = \"中文名 \";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // txtQueryUserName");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.txtQueryUserName.Location = new System.Drawing.Point(70, 18);");
            //sb.AppendLine("            this.txtQueryUserName.Name = \"txtQueryUserName \";");
            //sb.AppendLine("            this.txtQueryUserName.Size = new System.Drawing.Size(125, 23);");
            //sb.AppendLine("            this.txtQueryUserName.TabIndex = 1;");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // lblQueryUserName");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.lblQueryUserName.AutoSize = true;");
            //sb.AppendLine("            this.lblQueryUserName.Location = new System.Drawing.Point(20, 21);");
            //sb.AppendLine("            this.lblQueryUserName.Name =  \"lblQueryUserName \";");
            //sb.AppendLine("            this.lblQueryUserName.Size = new System.Drawing.Size(44, 17);");
            //sb.AppendLine("            this.lblQueryUserName.TabIndex = 0;");
            //sb.AppendLine("            this.lblQueryUserName.Text =  \"用户名 \";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // btnQuery");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.btnQuery.Location = new System.Drawing.Point(31, 15);");
            sb.AppendLine("            this.btnQuery.Name =  \"btnQuery \";");
            sb.AppendLine("            this.btnQuery.Size = new System.Drawing.Size(54, 31);");
            sb.AppendLine("            this.btnQuery.TabIndex = 0;");
            sb.AppendLine("            this.btnQuery.Text =  \"查询 \";");
            sb.AppendLine("            this.btnQuery.UseVisualStyleBackColor = true;");
            sb.AppendLine("            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptView");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;");
            sb.AppendLine("            this.sptView.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.sptView.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;");
            sb.AppendLine("            this.sptView.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.sptView.Name =  \"sptView \";");
            sb.AppendLine("            this.sptView.Orientation = System.Windows.Forms.Orientation.Horizontal;");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptView.Panel1");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptView.Panel1.Controls.Add(this.grdData);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // sptView.Panel2");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.sptView.Panel2.Controls.Add(this.Pager);");
            sb.AppendLine("            this.sptView.Size = new System.Drawing.Size(907, 468);");
            sb.AppendLine("            this.sptView.SplitterDistance = 424;");
            sb.AppendLine("            this.sptView.TabIndex = 0;");
            sb.AppendLine("            this.sptView.Click += new System.EventHandler(this.btnQuery_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // grdData");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.grdData.AllowUserToAddRows = false;");
            sb.AppendLine("            this.grdData.AllowUserToDeleteRows = false;");
            sb.AppendLine(
                "            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;");
            sb.AppendLine("            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {");
            #region 显示列
            for (int i = 0; i < lstBseUiShow.Count; i++)
            {
                if (i == lstBseUiShow.Count - 1)
                {
                    sb.AppendLine("            this." + lstBseUiShow[i].ControlName + "");
                }
                else
                {
                    sb.AppendLine("            this." + lstBseUiShow[i].ControlName + ",");
                }
            }
            //sb.AppendLine("            this.colUser_Id,");
            //sb.AppendLine("            this.colTrueName");
            #endregion
            sb.AppendLine("    });");
            sb.AppendLine("            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.grdData.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.grdData.Name =  \"grdData \";");
            sb.AppendLine("            this.grdData.RowHeadersWidth = 50;");
            sb.AppendLine("            this.grdData.RowTemplate.Height = 23;");
            sb.AppendLine(
                "            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;");
            sb.AppendLine("            this.grdData.Size = new System.Drawing.Size(905, 422);");
            sb.AppendLine("            this.grdData.TabIndex = 0;");

            #region 显示区列

            foreach (Bse_UI ui in lstBseUiShow)
            {
                sb.Append(GenControlHelper.CreateGridColumn(ui.ControlName, ui.LabelText,
                    ui.ColumnName, ui.ControlSort, ui.ControlNameSpace,
                    ui.Ctl_Simple, ui.GridSpeicalCtlName));
            }

            #endregion

            //sb.AppendLine("            // ");
            //sb.AppendLine("            // colUser_Id");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.colUser_Id.DataPropertyName =  \"User_Id \";");
            //sb.AppendLine("            this.colUser_Id.HeaderText =  \"唯一ID \";");
            //sb.AppendLine("            this.colUser_Id.Name =  \"colUser_Id \";");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            // colTrueName");
            //sb.AppendLine("            // ");
            //sb.AppendLine("            this.colTrueName.DataPropertyName =  \"TrueName \";");
            //sb.AppendLine("            this.colTrueName.HeaderText =  \"中文名 \";");
            //sb.AppendLine("            this.colTrueName.Name =  \"colTrueName \";");
            //sb.AppendLine("            // ");
            sb.AppendLine("            // Pager");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.Pager.Cursor = System.Windows.Forms.Cursors.Hand;");
            sb.AppendLine("            this.Pager.Dock = System.Windows.Forms.DockStyle.Fill;");
            sb.AppendLine("            this.Pager.Font = new System.Drawing.Font( \"微软雅黑 \", 9F);");
            sb.AppendLine("            this.Pager.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.Pager.Name =  \"Pager \";");
            sb.AppendLine("            this.Pager.PageIndex = 1;");
            sb.AppendLine("            this.Pager.RecordCount = 0;");
            sb.AppendLine("            this.Pager.Size = new System.Drawing.Size(905, 38);");
            sb.AppendLine("            this.Pager.TabIndex = 0;");
            sb.AppendLine(
                "            this.Pager.PageChanged += new Nikita.WinForm.ExtendControl.PageChangedEventHandler(this.Pager_PageChanged);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // tspCommand");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.tspCommand.Font = new System.Drawing.Font( \"微软雅黑 \", 9F);");
            sb.AppendLine("     this.tspCommand.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;");
            sb.AppendLine("        this.tspCommand.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;");
            sb.AppendLine("            this.tspCommand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {");
            sb.AppendLine("            this.cmdFirst,");
            sb.AppendLine("            this.cmdPre,");
            sb.AppendLine("            this.cmdNext,");
            sb.AppendLine("            this.cmdLast,");
            sb.AppendLine("            this.cmdSep1,");
            sb.AppendLine("            this.cmdRefresh,");
            sb.AppendLine("            this.cmdImport,");
            if (baseParameter.CodeGenType == CodeGenType.WinFromEditWithDialog)
            {
                sb.AppendLine("            this.cmdCancel,");
                sb.AppendLine("            this.cmdDelete,");
                sb.AppendLine("            this.cmdEdit,");
                sb.AppendLine("            this.cmdNew");
            }
            sb.AppendLine("     });");
            sb.AppendLine("            this.tspCommand.Location = new System.Drawing.Point(0, 0);");
            sb.AppendLine("            this.tspCommand.Name =  \"tspCommand \";");
            sb.AppendLine("            this.tspCommand.Size = new System.Drawing.Size(907, 26);");
            sb.AppendLine("            this.tspCommand.TabIndex = 4;");
            sb.AppendLine("            this.tspCommand.Text =  \"toolStrip1 \";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdFirst");
            sb.AppendLine("            // ");
            sb.AppendLine(
                "            this.cmdFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            //sb.AppendLine(
            //    "            this.cmdFirst.Image = ((System.Drawing.Image)(resources.GetObject( \"cmdFirst.Image \")));");
            sb.AppendLine("            this.cmdFirst.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdFirst.Name =  \"cmdFirst \";");
            sb.AppendLine("            this.cmdFirst.Size = new System.Drawing.Size(52, 23);");
            sb.AppendLine("            this.cmdFirst.Text =  \"第一条 \";");
            sb.AppendLine("            this.cmdFirst.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdPre");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdPre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            //sb.AppendLine(
            //    "            this.cmdPre.Image = ((System.Drawing.Image)(resources.GetObject( \"cmdPre.Image \")));");
            sb.AppendLine("            this.cmdPre.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdPre.Name =  \"cmdPre \";");
            sb.AppendLine("            this.cmdPre.Size = new System.Drawing.Size(52, 23);");
            sb.AppendLine("            this.cmdPre.Text = \"上一条 \";");
            sb.AppendLine("            this.cmdPre.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdNext");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            //sb.AppendLine(
            //    "            this.cmdNext.Image = ((System.Drawing.Image)(resources.GetObject( \"cmdNext.Image \")));");
            sb.AppendLine("            this.cmdNext.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdNext.Name =  \"cmdNext \";");
            sb.AppendLine("            this.cmdNext.Size = new System.Drawing.Size(52, 23);");
            sb.AppendLine("            this.cmdNext.Text =  \"下一条 \";");
            sb.AppendLine("            this.cmdNext.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdLast");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            //sb.AppendLine(
            //    "            this.cmdLast.Image = ((System.Drawing.Image)(resources.GetObject( \"cmdLast.Image \")));");
            sb.AppendLine("            this.cmdLast.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdLast.Name =  \"cmdLast \";");
            sb.AppendLine("            this.cmdLast.Size = new System.Drawing.Size(65, 23);");
            sb.AppendLine("            this.cmdLast.Text =  \"最后一条 \";");
            sb.AppendLine("            this.cmdLast.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdSep1");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdSep1.Name =  \"cmdSep1 \";");
            sb.AppendLine("            this.cmdSep1.Size = new System.Drawing.Size(6, 26);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdRefresh");
            sb.AppendLine("            // ");
            sb.AppendLine(
                "            this.cmdRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdRefresh.Name =  \"cmdRefresh \";");
            sb.AppendLine("            this.cmdRefresh.Size = new System.Drawing.Size(39, 23);");
            sb.AppendLine("            this.cmdRefresh.Text =  \"刷新 \";");
            sb.AppendLine(
                "            this.cmdRefresh.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;");
            sb.AppendLine("            this.cmdRefresh.Click += new System.EventHandler(this.Command_Click);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdImport");
            sb.AppendLine("            // ");
            sb.AppendLine(
                "            this.cmdImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
            sb.AppendLine("            this.cmdImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {");
            sb.AppendLine("            this.cmdImportExcel});");
            //sb.AppendLine(
            //    "            this.cmdImport.Image = ((System.Drawing.Image)(resources.GetObject( \"cmdImport.Image \")));");
            sb.AppendLine("            this.cmdImport.ImageTransparentColor = System.Drawing.Color.Magenta;");
            sb.AppendLine("            this.cmdImport.Name =  \"cmdImport \";");
            sb.AppendLine("            this.cmdImport.Size = new System.Drawing.Size(51, 23);");
            sb.AppendLine("            this.cmdImport.Text =  \"导出 \";");
            sb.AppendLine("            // ");
            sb.AppendLine("            // cmdImportExcel");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.cmdImportExcel.Name =  \"cmdImportExcel \";");
            sb.AppendLine("            this.cmdImportExcel.Size = new System.Drawing.Size(135, 24);");
            sb.AppendLine("            this.cmdImportExcel.Text =  \"导出Excel \";");
            sb.AppendLine("            this.cmdImportExcel.Click += new System.EventHandler(this.Command_Click);");

            if (baseParameter.CodeGenType == CodeGenType.WinFromEditWithDialog)
            {
                sb.AppendLine("  // ");
                sb.AppendLine("            // cmdCancel");
                sb.AppendLine("            // ");
                sb.AppendLine("            this.cmdCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
                sb.AppendLine("            this.cmdCancel.ImageTransparentColor = System.Drawing.Color.Magenta;");
                sb.AppendLine("            this.cmdCancel.Name =  \"cmdCancel \";");
                sb.AppendLine("            this.cmdCancel.Size = new System.Drawing.Size(42, 22);");
                sb.AppendLine("            this.cmdCancel.Text =  \"作废 \";");
                sb.AppendLine("            this.cmdCancel.Click += new System.EventHandler(this.Command_Click);");
                sb.AppendLine("            // ");
                sb.AppendLine("            // cmdDelete");
                sb.AppendLine("            // ");
                sb.AppendLine("            this.cmdDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
                sb.AppendLine("            this.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;");
                sb.AppendLine("            this.cmdDelete.Name =  \"cmdDelete\";");
                sb.AppendLine("            this.cmdDelete.Size = new System.Drawing.Size(42, 22);");
                sb.AppendLine("            this.cmdDelete.Text =  \"删除\";");
                sb.AppendLine("            this.cmdDelete.Click += new System.EventHandler(this.Command_Click);");
                sb.AppendLine("            // ");
                sb.AppendLine("            // cmdEdit");
                sb.AppendLine("            // ");
                sb.AppendLine("            this.cmdEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
                sb.AppendLine("            this.cmdEdit.ImageTransparentColor = System.Drawing.Color.Magenta;");
                sb.AppendLine("            this.cmdEdit.Name =  \"cmdEdit\";");
                sb.AppendLine("            this.cmdEdit.Size = new System.Drawing.Size(42, 22);");
                sb.AppendLine("            this.cmdEdit.Text =  \"修改\";");
                sb.AppendLine("            this.cmdEdit.Click += new System.EventHandler(this.Command_Click);");
                sb.AppendLine("            // ");
                sb.AppendLine("            // cmdNew");
                sb.AppendLine("            // ");
                sb.AppendLine("            this.cmdNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;");
                sb.AppendLine("            this.cmdNew.ImageTransparentColor = System.Drawing.Color.Magenta;");
                sb.AppendLine("            this.cmdNew.Name =  \"cmdNew\";");
                sb.AppendLine("            this.cmdNew.Size = new System.Drawing.Size(42, 22);");
                sb.AppendLine("            this.cmdNew.Text =  \"新增 \";");
                sb.AppendLine("            this.cmdNew.Click += new System.EventHandler(this.Command_Click);");
            }
            sb.AppendLine("   // ");
            sb.AppendLine("            // toolTip");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.toolTip.AutoPopDelay = 0;");
            sb.AppendLine("            this.toolTip.InitialDelay = 500;");
            sb.AppendLine("            this.toolTip.OwnerDraw = true;");
            sb.AppendLine("            this.toolTip.ReshowDelay = 100;");
            sb.AppendLine("            this.toolTip.ShowAlways = true;");
            sb.AppendLine("            this.toolTip.UseAnimation = false;");
            sb.AppendLine("            this.toolTip.UseFading = false;");
            sb.AppendLine("            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);");
            sb.AppendLine("            // ");
            sb.AppendLine("            // " + strFrmClassName + "");
            sb.AppendLine("            // ");
            sb.AppendLine("            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);");
            sb.AppendLine("            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;");
            sb.AppendLine("            this.ClientSize = new System.Drawing.Size(907, 561);");
            sb.AppendLine("            this.Controls.Add(this.sptAll);");
            sb.AppendLine("            this.Controls.Add(this.tspCommand);");
            sb.AppendLine("            this.Font = new System.Drawing.Font( \"微软雅黑 \", 9F);");
            sb.AppendLine("            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;");
            sb.AppendLine("            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);");
            sb.AppendLine("            this.Name =  \"" + strFrmClassName + " \";");
            sb.AppendLine("            this.ShowIcon = false;");
            sb.AppendLine("            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;");
            sb.AppendLine("            this.Text = \"" + strFrmClassName + "\";");
            sb.AppendLine("            this.sptAll.Panel1.ResumeLayout(false);");
            sb.AppendLine("            this.sptAll.Panel2.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptAll)).EndInit();");
            sb.AppendLine("            this.sptAll.ResumeLayout(false);");
            sb.AppendLine("            this.sptQuery.Panel1.ResumeLayout(false);");
            sb.AppendLine("            this.sptQuery.Panel1.PerformLayout();");
            sb.AppendLine("            this.sptQuery.Panel2.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptQuery)).EndInit();");
            sb.AppendLine("            this.sptQuery.ResumeLayout(false);");
            sb.AppendLine("            this.sptView.Panel1.ResumeLayout(false);");
            sb.AppendLine("            this.sptView.Panel2.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.sptView)).EndInit();");
            sb.AppendLine("            this.sptView.ResumeLayout(false);");
            sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();");
            sb.AppendLine("            this.tspCommand.ResumeLayout(false);");
            sb.AppendLine("            this.tspCommand.PerformLayout();");
            foreach (Bse_UI ui in lstBseUiQuery)
            {
                if (ui.ControlNameSpace == "System.Windows.Forms.NumericUpDown")
                {
                    sb.AppendLine("            ((System.ComponentModel.ISupportInitialize)(this." + ui.ControlName + ")).EndInit();");
                }
            }
            sb.AppendLine("            this.ResumeLayout(false);");
            sb.AppendLine("            this.PerformLayout();");

            sb.AppendLine("        }");

            sb.AppendLine("        #endregion");

            sb.AppendLine("        private System.Windows.Forms.SplitContainer sptAll;");
            sb.AppendLine("        private System.Windows.Forms.SplitContainer sptQuery;");
            sb.AppendLine("        private System.Windows.Forms.Button btnQuery;");
            sb.AppendLine("        private System.Windows.Forms.SplitContainer sptView;");
            sb.AppendLine("        private System.Windows.Forms.DataGridView grdData;");
            sb.AppendLine("        private WinForm.ExtendControl.Pager Pager;");
            #region 显示区列
            foreach (Bse_UI ui in lstBseUiShow)
            {
                if (ui.ControlNameSpace == string.Empty)
                {
                    sb.Append("        public System.Windows.Forms.DataGridViewTextBoxColumn  " + ui.ControlName + ";\r\n");
                }
                else
                {
                    if (ui.ControlNameSpace.Contains("Devexpress"))
                    {

                    }
                    else
                    {
                        //sb.Append("        public  System.Windows.Forms.DataGridViewTextBoxColumn   " + ui.ControlName + ";\r\n");
                        sb.Append("        public " + ui.ControlNameSpace + "  " + ui.ControlName + ";\r\n");
                    }
                }
            }
            #endregion
            //sb.AppendLine("        private System.Windows.Forms.DataGridViewTextBoxColumn colUser_Id;");
            //sb.AppendLine("        private System.Windows.Forms.DataGridViewTextBoxColumn colTrueName;");
            sb.AppendLine("        private System.Windows.Forms.ToolStrip tspCommand;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdRefresh;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripSplitButton cmdImport;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripMenuItem cmdImportExcel;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdFirst;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdPre;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdNext;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdLast;");
            sb.AppendLine("        private System.Windows.Forms.ToolStripSeparator cmdSep1;");
            if (baseParameter.CodeGenType == CodeGenType.WinFromEditWithDialog)
            {
                sb.AppendLine("      private System.Windows.Forms.ToolStripButton cmdNew;");
                sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdDelete;");
                sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdEdit;");
                sb.AppendLine("        private System.Windows.Forms.ToolStripButton cmdCancel;");
            }
            sb.AppendLine(" private System.Windows.Forms.ToolTip toolTip;");
            //sb.AppendLine("        private System.Windows.Forms.Label lblQueryUserName;");
            //sb.AppendLine("        private System.Windows.Forms.TextBox txtQueryUserName;");
            //sb.AppendLine("        private System.Windows.Forms.Label lblQueryTrueName;");
            //sb.AppendLine("        private System.Windows.Forms.ComboBox cboQueryTrueName;");
            //sb.AppendLine("        private System.Windows.Forms.Label label1;");
            //sb.AppendLine("        private WinForm.ExtendControl.CheckedComboBox cbkID;");
            #region 查询区控件
            foreach (Bse_UI uiQuery in lstBseUiQuery)
            {
                if (uiQuery.IsAddLable == "True")
                {
                    sb.Append("        public  System.Windows.Forms.Label " + uiQuery.LabelName + ";\r\n");
                }
                sb.Append("        public " + uiQuery.ControlNameSpace + "  " + uiQuery.ControlName + ";\r\n");
            }
            #endregion
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();

        }

    }
}