using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.Assist.CodeMaker.DAL;
using Nikita.Assist.CodeMaker.Model;
using Nikita.Core;
using Nikita.WinForm.ExtendControl;
using Nikita.Base.Define;

namespace Nikita.Assist.CodeMaker
{
    public partial class FrmMasterDetailDemo : Form
    {
        #region 常量、变量
        /// <summary>主表操作类
        /// 
        /// </summary>
        private OrderMasterDAL m_orderMasterDAL;
        /// <summary>子表操作类
        /// 
        /// </summary>
        private OrderDetailDAL m_orderDetailDAL;
        /// <summary>主表绑定集合
        /// 
        /// </summary>
        private List<OrderMaster> m_lstOrderMaster;
        /// <summary>子表绑定集合
        /// 
        /// </summary>
        private List<OrderDetail> m_lstOrderDetail;
        /// <summary>Master列表下拉框绑定数据源
        /// 
        /// </summary>
        private DataSet m_dsMasterGridSource;
        /// <summary>Detail列表下拉框绑定数据源
        /// 
        /// </summary>
        private DataSet m_dsDetailGridSource;
        #endregion

        #region 构造函数
        /// <summary>构造函数
        /// 
        /// </summary>
        public FrmMasterDetailDemo()
        {
            InitializeComponent();

            cboFilterType.SelectedIndex = 2;
            m_orderMasterDAL = new OrderMasterDAL();
            m_orderDetailDAL = new OrderDetailDAL();
            m_lstOrderMaster = new List<OrderMaster>();

            DoInitData();
            DoInitMasterGridSource();
            DoInitDetailGridSource();

            #region 主表列表绑定字段
            this.olvColumn1.AspectGetter = x => ((OrderMaster) x).OrderId;
            this.olvColumn2.AspectGetter = delegate(object x) { return ((OrderMaster)x).OrderNumber; };
            this.olvColumn3.AspectGetter = delegate(object x) { return GetMasterStatus(((OrderMaster)x).Status); };
            this.olvColumn4.AspectGetter = delegate(object x) { return ((OrderMaster)x).CreateDate; };
            #endregion

            #region 明细表列表绑定字段
            this.olvColumn5.AspectGetter = delegate(object x) { return ((OrderDetail)x).DetailId; };
            this.olvColumn6.AspectGetter = delegate(object x) { return ((OrderDetail)x).OrderId; };
            this.olvColumn7.AspectGetter = delegate(object x) { return ((OrderDetail)x).Customer; };
            this.olvColumn8.AspectGetter = delegate(object x) { return ((OrderDetail)x).ProductName; };
            this.olvColumn9.AspectGetter = delegate(object x) { return ((OrderDetail)x).Amount; };
            this.olvColumn10.AspectGetter = delegate(object x) { return ((OrderDetail)x).SumMoney; };
            this.olvColumn11.AspectGetter = delegate(object x) { return GetDetailStatus(((OrderDetail)x).Status); };
            #endregion
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
                        DoDeleteOrCancel(EntityOperationType.删除);
                        break;
                    case "cmdCancel":
                        DoDeleteOrCancel(EntityOperationType.作废);
                        break;
                }
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

        /// <summary>主表选中事件
        /// 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void objListViewMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (objListViewMaster.SelectedObjects.Count == 0)
            {
                return;
            }
            OrderMaster model = objListViewMaster.SelectedObjects[0] as OrderMaster;
            if (model != null)
            {
                m_lstOrderDetail = m_orderDetailDAL.GetListArray("OrderId=" + model.OrderId + "");
                objListViewDetail.SetObjects(m_lstOrderDetail);
                objListViewDetail.Refresh();
            }
        }

        /// <summary>通用过滤事件
        /// 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            this.objListViewMaster.TimedFilter(txtFilter.Text);
        }

        /// <summary>双击修改
        /// 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void objListViewMaster_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            Command_Click(cmdEdit, null);
        }
        #endregion

        #region 基础方法

        /// <summary>执行查询
        ///
        /// </summary>
        private void DoQueryData()
        {
            try
            {
                btnQuery.Enabled = false;
                string strWhere = GetSearchSql();
                m_lstOrderMaster = m_orderMasterDAL.GetListArray("*", "OrderId", "ASC", Pager.PageSize, Pager.PageIndex, strWhere);
                Pager.RecordCount = m_orderMasterDAL.CalcCount(strWhere);
                Pager.InitPageInfo();
                objListViewMaster.SetObjects(m_lstOrderMaster);
                if (m_lstOrderMaster.Count > 0)
                {
                    objListViewMaster.SelectedIndex = 0;
                }
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
            condition.AddCondition("OrderNumber", this.txtQueryOrderNumber.Text, SqlOperator.Like);
            return condition.BuildConditionSql().Replace("Where", "");
        }

        /// <summary>删除/作废
        /// 
        /// </summary>
        /// <param name="operationType">操作类型</param>
        private void DoDeleteOrCancel(EntityOperationType operationType)
        {
            string strMsg = CheckSelect(operationType);
            if (strMsg != string.Empty)
            {
                MessageBox.Show(strMsg);
                return;
            }
            DialogResult diaComfirmResult = MessageBox.Show(string.Format("{0}主表信息，会连同明细一起{0}", operationType), @"警告",
                MessageBoxButtons.YesNo);
            if (diaComfirmResult != DialogResult.Yes)
            {
                return;
            }

            IList objList = objListViewMaster.SelectedObjects;
            IList lstSelectionIds = objList.Cast<OrderMaster>().Select(t => t.OrderId).ToList();
            string strIds = lstSelectionIds.Cast<string>().Aggregate(string.Empty, (current, strId) => current + (strId + ","));
            strIds = strIds.TrimEnd(',');
            var blnReturn = operationType == EntityOperationType.删除
                ? m_orderMasterDAL.DeleteByCond("OrderId in (" + strIds + ")")
                : m_orderMasterDAL.Update("Status =0", "OrderId in (" + strIds + ")");
            if (blnReturn)
            {
                MessageBox.Show(string.Format("{0}成功", operationType));
                objListViewMaster.RemoveObjects(objList);
            }
            else
            {
                MessageBox.Show(string.Format("{0}失败", operationType));
            }
        }

        /// <summary>编辑
        ///
        /// </summary>
        private void DoEdit()
        {
            string strMsg = CheckSelect(EntityOperationType.修改);
            if (strMsg != string.Empty)
            {
                MessageBox.Show(strMsg);
                return;
            }
            OrderMaster model = objListViewMaster.SelectedObjects[0] as OrderMaster;
            if (model != null)
            {
                FrmMasterDetailDemoDialog frmDialog = new FrmMasterDetailDemoDialog(model, m_lstOrderMaster, m_lstOrderDetail);
                if (frmDialog.ShowDialog() == DialogResult.OK)
                {
                    m_lstOrderMaster = frmDialog.ListOrderMaster;
                    m_lstOrderDetail = frmDialog.ListOrderDetail;
                    if (m_lstOrderMaster != null)
                    {
                        objListViewMaster.SetObjects(m_lstOrderMaster);
                        objListViewMaster.Refresh();
                    }
                    if (m_lstOrderDetail != null)
                    {
                        objListViewDetail.SetObjects(m_lstOrderDetail);
                        objListViewDetail.Refresh();
                    }
                }
            }
        }

        /// <summary>新增
        ///
        /// </summary>
        private void DoNew()
        {
            FrmMasterDetailDemoDialog frmDialog = new FrmMasterDetailDemoDialog(null, m_lstOrderMaster, m_lstOrderDetail);
            if (frmDialog.ShowDialog() == DialogResult.OK)
            {
                m_lstOrderMaster = frmDialog.ListOrderMaster;
                m_lstOrderDetail = frmDialog.ListOrderDetail;
                if (m_lstOrderMaster != null)
                {
                    objListViewMaster.SetObjects(m_lstOrderMaster);
                    objListViewMaster.Refresh();
                }
                if (m_lstOrderDetail != null)
                {
                    objListViewDetail.SetObjects(m_lstOrderDetail);
                    objListViewDetail.Refresh();
                }
            }
        }

        /// <summary>检查选择
        /// 
        /// </summary>
        /// <param name="operationType">操作说明</param>
        /// <returns>返回提示信息</returns>
        private string CheckSelect(EntityOperationType operationType)
        {
            string strMsg = string.Empty;
            if (objListViewMaster.SelectedObjects.Count == 0)
            {
                strMsg = string.Format("请选择要{0}的行数据", operationType);
            }
            return strMsg;
        }

        /// <summary>初始化绑定下拉框等
        ///
        /// </summary>
        private void DoInitData()
        {
            const string strBindSql = "SELECT 2 AS  value , '管理员' AS  Name UNION ALL  SELECT 3 AS  value , '功城队' AS  NAME;SELECT 'cbkQueryRemark '";
            BindSourceHelper.BindClass bindClass = new BindSourceHelper.BindClass()
            {
                SqlType =  SqlType.SqlServer,
                BindSql = strBindSql
            };
            DataSet ds = BindSourceHelper.GetBindSourceDataSet(bindClass);
            //CheckedComboBoxHelper.BindCheckedComboBox(cbkQueryRemark, ds.Tables["cbkQueryRemark"], "Name", "value");
        }

        /// <summary>初始主表数据源
        ///
        /// </summary>
        private void DoInitMasterGridSource()
        {
            const string strBindSql = "SELECT 'true' AS  value , '有效' AS  Name UNION ALL  SELECT 'false' AS  value , '无效' AS  Name ;SELECT 'cbkQueryRemark '";
            BindSourceHelper.BindClass bindClass = new BindSourceHelper.BindClass()
            {
                SqlType = SqlType.SqlServer,
                BindSql = strBindSql
            };
            m_dsMasterGridSource = BindSourceHelper.GetBindSourceDataSet(bindClass);
        }

        /// <summary>初始化明细数据源
        ///
        /// </summary>
        private void DoInitDetailGridSource()
        {
            const string strBindSql = "SELECT 'true' AS  value , '有效' AS  Name UNION ALL  SELECT   'false' AS  value , '无效' AS  Name ;SELECT 'cbkQueryRemark '";
            BindSourceHelper.BindClass bindClass = new BindSourceHelper.BindClass()
            {
                SqlType =  SqlType.SqlServer,
                BindSql = strBindSql
            };
            m_dsDetailGridSource = BindSourceHelper.GetBindSourceDataSet(bindClass);
        }

        #region 主表绑定方法
        private string GetMasterStatus(object objStatus)
        {
            return m_dsMasterGridSource.Tables["cbkQueryRemark"].Select("value = '" + objStatus + "'")[0]["Name"].ToString();
        }

        #endregion

        #region 明细绑定方法
        private string GetDetailStatus(object objStatus)
        { 
            return m_dsDetailGridSource.Tables["cbkQueryRemark"].Select("value = '" + objStatus + "'")[0]["Name"].ToString();
        }
        #endregion 

        #endregion
    }
}
