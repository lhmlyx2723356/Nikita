/// <summary>说明:FrmBseUrlSimpleQuery文件
/// 作者:卢华明
/// 创建时间:2016/6/19 11:46:20
/// </summary>

using Nikita.Assist.Note.Model;
using Nikita.Core;
using Nikita.Core.WinForm;
using Nikita.WinForm.ExtendControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Nikita.Base.Define;
using Nikita.Base.IDAL;
using Nikita.Core.NPOIs;

namespace Nikita.Assist.Note
{
    /// <summary>说明:FrmBseUrlSimpleQuery
    /// 作者:Luhm
    /// 最后修改人:
    /// 最后修改时间:
    /// 创建时间:2016/6/19 11:46:20
    /// </summary>
    public partial class FrmBseUrlSimpleQuery : Form
    {
        #region 常量、变量
        /// <summary>DataGridView下拉框绑定数据源
        /// 
        /// </summary>
        private DataSet m_dsGridSource;
        /// <summary>操作类
        /// 
        /// </summary>
        //private BseUrlDAL m_BseUrlDAL;
        private IBseDAL<BseUrl> m_BseUrlDAL;
        /// <summary>结果集合
        /// 
        /// </summary>
        private List<BseUrl> m_lstBseUrl;
        #endregion

        #region 构造函数
        /// <summary>构造函数
        ///
        /// </summary>
        public FrmBseUrlSimpleQuery()
        {
            InitializeComponent();
            grdData.ShowCellToolTips = false;
            grdData.AutoGenerateColumns = false;
            //m_BseUrlDAL = new BseUrlDAL(); 
            //m_BseUrlDAL= GlobalHelp.GetResolve<IDAL<BseUrl>, BseUrlDAL>(); 
            //var basetype = typeof(IDAL<>);
            //var builder = new ContainerBuilder();
            //var assembly = Assembly.GetAssembly(basetype);
            //builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            //var container = builder.Build();
            //m_BseUrlDAL = container.Resolve<IDAL<BseUrl>>();
            m_BseUrlDAL = GlobalHelp.GetResolve<IBseDAL<BseUrl>>();
            IBseDAL<BseUrl2> m_BseUrlDAL2 = GlobalHelp.GetResolve<IBseDAL<BseUrl2>>();
            grdData.RowsAdded += this.grdData_RowsAdded;
            grdData.RowPostPaint += grdData_RowPostPaint;
            grdData.CellMouseEnter += this.grdData_CellMouseEnter;
            grdData.CellMouseLeave += this.grdData_CellMouseLeave;
            grdData.CellDoubleClick += this.grdData_CellDoubleClick;
            toolTip.Draw += this.toolTip_Draw;
            DoInitData();

            //注册热键 (窗体句柄,热键ID,辅助键,实键) 
            //辅助键说明: None = 0,   Alt = 1,  crtl= 2,  Shift = 4,   Windows = 8
            //如果有多个辅助键则,例如 alt+crtl是3 直接相加就可以了
            HotKey.RegisterHotKey(this.Handle, 123, HotKey.KeyModifiers.Ctrl, Keys.Q);
            HotKey.RegisterHotKey(this.Handle, 456, HotKey.KeyModifiers.Ctrl, Keys.W);
            btnQuery_Click(null, null);
            DoNew();
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
                    case "cmdNew":
                        DoNew();
                        break;
                    case "cmdEdit":
                        DoEdit();
                        break;
                    case "cmdDelete":
                        DoDeleteOrCancel("删除 ");
                        break;
                    case "cmdCancel":
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
            }

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
            const string strBindSql = "select '学习记录' as Name  union all  select '其它记录' as Name ;SELECT 'cboQueryType '";
             BindClass bindClass = new  BindClass()
            {
                SqlType = SqlType.SqlServer,
                BindSql = strBindSql
            };
            DataSet ds = BindSourceHelper.GetBindSourceDataSet(bindClass, GlobalHelp.Conn);
            ComboBoxHelper.BindComboBox(cboQueryType, ds.Tables["cboQueryType"], "Name", "Name");

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
                m_lstBseUrl = m_BseUrlDAL.GetListArray("*", "Id", "Desc", Pager.PageSize, Pager.PageIndex, strWhere);
                Pager.RecordCount = m_BseUrlDAL.CalcCount(strWhere);
                Pager.InitPageInfo();
                grdData.DataSource = m_lstBseUrl;

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
            condition.AddCondition("UrlContent", this.txtQueryUrlContent.Text, SqlOperator.Like);
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
            string strIds = DataGridViewHelper.GetColumnValuesBySelectRows(grdData.SelectedRows, gridmrzId.Name);
            var blnReturn = strOperation.Trim() == "删除" ? m_BseUrlDAL.DeleteByCond(" Id in (" + strIds + ")") : m_BseUrlDAL.Update("Status =0", " Id in (" + strIds + ")");
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
            BseUrl model = drRowEdit.Tag as BseUrl;
            if (model == null)
            {
                int intKeyID = int.Parse(drRowEdit.Cells[gridmrzId.Name].Value.ToString());
                model = m_BseUrlDAL.GetModel(intKeyID);
            }
            if (model != null)
            {
                FrmBseUrlSimpleDialog frmDialog = new FrmBseUrlSimpleDialog(model, m_lstBseUrl);
                if (frmDialog.ShowDialog() == DialogResult.OK)
                {
                    m_lstBseUrl = frmDialog.ListBseUrl;
                    grdData.DataSource = m_lstBseUrl;
                    grdData.Refresh();
                }
            }
        }
        /// <summary>新增
        ///
        /// </summary>
        private void DoNew()
        {
            FrmBseUrlSimpleDialog frmDialog = new FrmBseUrlSimpleDialog(null, m_lstBseUrl);
            if (frmDialog.ShowDialog() == DialogResult.OK)
            {
                m_lstBseUrl = frmDialog.ListBseUrl;
                if (grdData.DataSource != null)
                {
                    this.BindingContext[grdData.DataSource].SuspendBinding();
                }
                grdData.DataSource = null;
                grdData.DataSource = m_lstBseUrl;
                this.BindingContext[grdData.DataSource].ResumeBinding();

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
                strMsg = string.Format("请选择要{0}的行数据", strOperation);
            }
            return strMsg;
        }
        #endregion

        private void FrmBseUrlSimpleQuery_FormClosed(object sender, FormClosedEventArgs e)
        {

            HotKey.UnregisterHotKey(this.Handle, 123);
            HotKey.UnregisterHotKey(this.Handle, 456);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0312:  //这个是window消息定义的注册的热键消息  
                    if (m.WParam.ToString() == "123")   // 按下CTRL+Q隐藏  
                    {
                        this.Hide();
                    }
                    else if (m.WParam.ToString() == "456") // 按下CTRL+W显示
                    {
                        this.Visible = true;
                        //this.TopMost = true;
                        this.WindowState = FormWindowState.Normal;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
    }
}
