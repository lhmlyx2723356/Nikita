/// <summary>说明:FrmSys_RolesSimpleQuery文件
/// 作者:卢华明
/// 创建时间:2016-04-30 22:22:38
/// </summary>
using Nikita.Assist.CodeMaker.DAL;
using Nikita.Assist.CodeMaker.Model;
using Nikita.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.Base.Define;
using Nikita.Core.NPOIs;
using Nikita.Core.WinForm;
namespace Nikita.Assist.CodeMaker
{
    /// <summary>说明:FrmSys_RolesSimpleQuery
    /// 作者:Luhm
    /// 最后修改人:
    /// 最后修改时间:
    /// 创建时间:2016-04-30 22:22:38
    /// </summary>
    public partial class FrmSys_RolesSimpleQuery : Form
    {
        #region 常量、变量
        /// <summary>DataGridView下拉框绑定数据源
        /// 
        /// </summary>
        private DataSet m_dsGridSource;
        /// <summary>操作类
        /// 
        /// </summary>
        private Sys_RolesDAL m_Sys_RolesDAL;
        /// <summary>结果集合
        /// 
        /// </summary>
        private List<Sys_Roles> m_lstSysRoles;
        #endregion

        #region 构造函数
        /// <summary>构造函数
        ///
        /// </summary>
        public FrmSys_RolesSimpleQuery()
        {
            InitializeComponent();
            grdData.ShowCellToolTips = false;
            grdData.AutoGenerateColumns = false;
            m_Sys_RolesDAL = new Sys_RolesDAL();
            grdData.RowsAdded += this.grdData_RowsAdded;
            grdData.RowPostPaint += grdData_RowPostPaint;
            grdData.CellMouseEnter += this.grdData_CellMouseEnter;
            grdData.CellMouseLeave += this.grdData_CellMouseLeave;
            toolTip.Draw += this.toolTip_Draw;
            DoInitData();
        }
        #endregion

        #region 基础事件
        /// <summary>查询
        ///
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            DoQueryData();
        }
        /// <summary>执行命令
        /// 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void Command_Click(object sender, EventArgs e)
        {
            ToolStripItem cmdItem = sender as ToolStripItem;
            if (cmdItem != null)
            {
                switch (cmdItem.Name.Trim())
                {
                    case "cmdFirst":
                    case "cmdPre":
                    case "cmdNext":
                    case "cmdLast":
                        DoGo(cmdItem.Name.Trim());
                        break;
                    case "cmdImportExcel":
                        DoImportExcel();
                        break;
                    case "cmdRefresh":
                        DoQueryData();
                        break;
                    case "cmdNew ":
                        DoNew();
                        break;
                    case "cmdEdit ":
                        DoEdit();
                        break;
                    case "cmdDelete ":
                        DoDeleteOrCancel("删除 ");
                        break;
                    case "cmdCancel ":
                        DoDeleteOrCancel("作废 ");
                        break;
                }
            }
        }

        /// <summary>生成列序号
        ///
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void grdData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView != null)
            {
                SolidBrush b = new SolidBrush(dataGridView.RowHeadersDefaultCellStyle.ForeColor);
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), dataGridView.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }
        private void grdData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (m_dsGridSource == null)
            {
                const string strBindGridSql = "SELECT 1 AS  value , '排序1' AS  Name UNION ALL  SELECT 2 AS  value , '排序2' AS  NAME UNION ALL  SELECT 3 AS  value , '排序3' AS  NAME UNION ALL  SELECT 9 AS  value , '排序9' AS  NAME;SELECT 'gridcboSortnum '";
                BindSourceHelper.BindClass bindClass = new BindSourceHelper.BindClass()
                {
                    SqlType =  SqlType.SqlServer,
                    BindSql = strBindGridSql
                };
                m_dsGridSource = BindSourceHelper.GetBindSourceDataSet(bindClass);
            }
            DataGridViewComboBoxCell gridcboSortnumCell = this.grdData.Rows[e.RowIndex].Cells[gridcboSortnum.Name] as DataGridViewComboBoxCell;
            ComboBoxHelper.BindDataGridViewComboBoxCell(gridcboSortnumCell, m_dsGridSource.Tables["gridcboSortnum"], "Name", "value");

        }

        private void grdData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Command_Click(cmdEdit, null);
        }

        /// <summary>分页事件
        ///
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void Pager_PageChanged(object sender, EventArgs e)
        {
            DoQueryData();
        }

        private void grdData_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            this.toolTip.Hide(this.grdData);
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewRow row = grdData.Rows[e.RowIndex];
                string strCellToolTipText = DataGridViewHelper.GetDataRowInfo(grdData, row); 
                this.toolTip.Show(strCellToolTipText, this.grdData);
            }
        }

        private void grdData_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.toolTip.Hide(this.grdData);
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds);
            e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1));
            e.Graphics.DrawString(this.toolTip.ToolTipTitle + e.ToolTipText, e.Font, Brushes.Blue, e.Bounds);
        }
        #endregion

        #region 基础方法
        /// <summary>上一条、下一条、第一条、最后一条记录
        ///
        /// </summary>
        /// <param name="cmdfirst">执行命令</param>
        private void DoGo(string cmdfirst)
        {
            switch (cmdfirst)
            {
                case "cmdFirst":
                    if (grdData.Rows.Count > 0)
                    {
                        grdData.ClearSelection();
                        grdData.Rows[0].Selected = true;
                        grdData.FirstDisplayedScrollingRowIndex = 0;
                    }
                    break;
                case "cmdPre":
                    if (grdData.SelectedRows.Count > 0)
                    {
                        int intSelectIndex = grdData.SelectedRows[0].Index;
                        if (intSelectIndex > 0)
                        {
                            grdData.Rows[intSelectIndex - 1].Selected = true;
                            grdData.Rows[intSelectIndex].Selected = false;
                            grdData.FirstDisplayedScrollingRowIndex = intSelectIndex;
                        }
                    }
                    break;
                case "cmdNext":
                    if (grdData.SelectedRows.Count > 0)
                    {
                        int intSelectIndex = grdData.SelectedRows[0].Index;
                        if (intSelectIndex + 1 < grdData.Rows.Count)
                        {
                            grdData.Rows[intSelectIndex + 1].Selected = true;
                            grdData.Rows[intSelectIndex].Selected = false;
                            grdData.FirstDisplayedScrollingRowIndex = intSelectIndex;
                        }
                    }
                    break;
                case "cmdLast":
                    if (grdData.Rows.Count > 0)
                    {
                        grdData.ClearSelection();
                        grdData.Rows[grdData.Rows.Count - 1].Selected = true;
                        grdData.FirstDisplayedScrollingRowIndex = grdData.Rows.Count - 1;
                    }
                    break;
            }
        }
        /// <summary>导出Excel
        ///
        /// </summary>
        private void DoImportExcel()
        {
            string strResult = NPOIHelper.ExportToExcel(grdData, "导出结果");
            if (!string.IsNullOrEmpty(strResult))
            {
                if (MessageBox.Show(@"导出成功,是否打开？", @"提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process.Start(strResult);
                }
            }
            else
            {
                MessageBox.Show(@"导出失败");
            }
        }

        /// <summary>初始化绑定下拉框等
        ///
        /// </summary>
        private void DoInitData()
        {
            const string strBindSql = "SELECT 2 AS  value , '管理员' AS  Name UNION ALL  SELECT 3 AS  value , '功城队' AS  NAME;SELECT 'cbkQueryRemark '";
            BindSourceHelper.BindClass bindClass = new BindSourceHelper.BindClass()
            {
                SqlType = SqlType.SqlServer,
                BindSql = strBindSql
            };
            DataSet ds = BindSourceHelper.GetBindSourceDataSet(bindClass);
            CheckedComboBoxHelper.BindCheckedComboBox(cbkQueryRemark, ds.Tables["cbkQueryRemark"], "Name", "value");

        }
        /// <summary>执行查询
        ///
        /// </summary>
        private void DoQueryData()
        {
            try
            {
                btnQuery.Enabled = false;
                string strWhere = GetSearchSql();
                m_lstSysRoles = m_Sys_RolesDAL.GetListArray("*", "KeyId", "ASC", Pager.PageSize, Pager.PageIndex, strWhere);
                Pager.RecordCount = m_Sys_RolesDAL.CalcCount(strWhere);
                Pager.InitPageInfo();
                grdData.DataSource = m_lstSysRoles;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                btnQuery.Enabled = true;
            }
        }
        /// <summary>根据查询条件构造查询语句
        ///
        /// </summary>
        /// <returns>查询条件</returns>
        private string GetSearchSql()
        {
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("RoleName", this.txtQueryRoleName.Text, SqlOperator.Like);
            condition.AddCondition("Sortnum", this.txtQuerySortnum.Text, SqlOperator.Like);
            condition.AddCondition("Remark", this.cbkQueryRemark.CheckedItemValues.Trim(), SqlOperator.In);
            return condition.BuildConditionSql().Replace("Where", "");

        }
        /// <summary>删除/作废
        /// 
        /// </summary>
        /// <param name="strOperation">操作类型</param>
        private void DoDeleteOrCancel(string strOperation)
        {
            string strMsg = CheckSelect(strOperation);
            if (strMsg != string.Empty)
            {
                MessageBox.Show(strMsg);
                return;
            }
            string strIds = DataGridViewHelper.GetColumnValuesBySelectRows(grdData.SelectedRows, gridmrzKeyId.Name);
            var blnReturn = strOperation == "删除" ? m_Sys_RolesDAL.DeleteByCond("KeyId in (" + strIds + ")") : m_Sys_RolesDAL.Update("isDefault =1", "KeyId in (" + strIds + ")");
            if (blnReturn)
            {
                MessageBox.Show(string.Format("{0}成功", strOperation));
                DoQueryData();
            }
            else
            {
                MessageBox.Show(string.Format("{0}失败", strOperation));
            }
        }
        /// <summary>编辑
        ///
        /// </summary>
        private void DoEdit()
        {
            string strMsg = CheckSelect("修改");
            if (strMsg != string.Empty)
            {
                MessageBox.Show(strMsg);
                return;
            }
            DataGridViewRow drRowEdit = grdData.SelectedRows[0];
            Sys_Roles model = drRowEdit.Tag as Sys_Roles;
            if (model == null)
            {
                int intKeyID = int.Parse(drRowEdit.Cells[gridmrzKeyId.Name].Value.ToString());
                model = m_Sys_RolesDAL.GetModel(intKeyID);
            }
            if (model != null)
            {
                FrmSys_RolesSimpleDialog frmDialog = new FrmSys_RolesSimpleDialog(model, m_lstSysRoles);
                if (frmDialog.ShowDialog() == DialogResult.OK)
                {
                    m_lstSysRoles = frmDialog.ListSys_Roles;
                    grdData.DataSource = m_lstSysRoles;
                    grdData.Refresh();
                }
            }
        }
        /// <summary>新增
        ///
        /// </summary>
        private void DoNew()
        {
            FrmSys_RolesSimpleDialog frmDialog = new FrmSys_RolesSimpleDialog(null, m_lstSysRoles);
            if (frmDialog.ShowDialog() == DialogResult.OK)
            {
                m_lstSysRoles = frmDialog.ListSys_Roles;
                grdData.DataSource = null;
                grdData.DataSource = m_lstSysRoles;
                grdData.Refresh();
            }
        }

        /// <summary>检查选择
        /// 
        /// </summary>
        /// <param name="strOperation">操作说明</param>
        /// <returns>返回提示信息</returns>
        private string CheckSelect(string strOperation)
        {
            string strMsg = string.Empty;
            if (grdData.SelectedRows.Count == 0)
            {
                strMsg = string.Format("请选择要{0}的列", strOperation);
            }
            return strMsg;
        }
        #endregion



    }
}
