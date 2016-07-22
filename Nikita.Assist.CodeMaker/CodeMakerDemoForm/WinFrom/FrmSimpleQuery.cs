/// <summary>说明:FrmSimpleQuery文件
/// 作者:Luhm
/// 最后修改人:
/// 最后修改时间:
/// 创建时间:2016-01-31 19:08:26
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
using Nikita.DataAccess4DBHelper;
using DbHelper = Nikita.DataAccess4DBHelper.DbHelper;
using Nikita.Base.Define;

namespace Nikita.Assist.CodeMaker.CodeMakerDemoForm.WinFrom
{
    /// <summary>说明:FrmSimpleQuery
    /// 作者:Luhm
    /// 最后修改人:
    /// 最后修改时间:
    /// 创建时间:2016-01-31 19:08:26
    /// </summary>
    public partial class FrmSimpleQuery : Form
    {
        #region 常量、变量
        private string[] LoadTypeAry = { "1", "2", "3" };
        #endregion

        #region 构造函数
        /// <summary>构造函数
        ///
        /// </summary>
        public FrmSimpleQuery()
        {
            InitializeComponent();
            grdData.AutoGenerateColumns = false;
            grdData.RowPostPaint += grdData_RowPostPaint;
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
                switch (cmdItem.Name)
                {
                    case "cmdFirst":
                    case "cmdPre":
                    case "cmdNext":
                    case "cmdLast":
                        DoGo(cmdItem.Name);
                        break;

                    case "cmdImportExcel":
                        DoImportExcel();
                        break;

                    case "cmdRefresh":
                        DoQueryData();
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

        /// <summary>分页事件
        ///
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void Pager_PageChanged(object sender, EventArgs e)
        {
            DoQueryData();
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
                        if (intSelectIndex + 1 < grdData.Rows.Count - 1)
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
            //DataTable dt=new DataTable();
            //dt.Columns.Add("Name", typeof(string));
            //dt.Columns.Add("Value", typeof(string));
            //foreach (string strItem in LoadTypeAry)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr[0] = strItem;
            //    dr[1] = strItem;
            //    dt.Rows.Add(dr);
            //}
            BindSourceHelper.BindClass bindClass = new BindSourceHelper.BindClass
            {
                BindSql = "",
                SqlType = SqlType.SqlServer,
                Connections = string.Empty
            };
            DataSet ds = GetBindSource(bindClass);
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                CheckedComboBoxHelper.BindCheckedComboBox(cbkID, ds.Tables[i], "Name", "Value");
            }
        }

        private DataSet GetBindSource(BindSourceHelper.BindClass bindClass)
        {
            IDbHelper helper = DbHelper.GetDbHelper(bindClass.SqlType, bindClass.Connections);
            helper.CreateCommand(bindClass.BindSql);
            DataSet ds = helper.ExecuteQueryDataSet();
            for (int i = 0; i < ds.Tables.Count; i++)
            { 
                //ds.Tables[i].TableName = lstBseUis[i].ControlName;
            }
            return ds;
        }

        /// <summary>执行查询
        ///
        /// </summary>
        private void DoQueryData()
        {
            string strWhere = GetSearchSql();
            Bse_UserDAL dal = new Bse_UserDAL();
            List<Bse_User> lstBseUser = dal.GetListArray("*", "User_Id", "ASC", Pager.PageSize, Pager.PageIndex, strWhere);
            Pager.RecordCount = dal.CalcCount(strWhere);
            Pager.InitPageInfo();
            grdData.DataSource = lstBseUser;
        }

        /// <summary>根据查询条件构造查询语句
        ///
        /// </summary>
        /// <returns>查询条件</returns>
        private string GetSearchSql()
        {
            string strLoadType = cbkID.CheckedItemValues;
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("UserName", this.txtQueryUserName.Text, SqlOperator.Like);
            condition.AddCondition("TrueName", cboQueryTrueName.Text, SqlOperator.Like);
                condition.AddCondition("User_Id", strLoadType.Trim(','), SqlOperator.In);
            return condition.BuildConditionSql().Replace("Where", "");
        }
        #endregion

        private void grdData_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}