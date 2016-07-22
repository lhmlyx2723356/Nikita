/// <summary>说明:FrmOrderMasterMasterDetailQuery文件
/// 作者:卢华明
/// 创建时间:2016-05-19 22:21:20
/// </summary>
using Nikita.Assist.CodeMaker.DAL;
using Nikita.Assist.CodeMaker.Model;
using Nikita.Core;
using Nikita.WinForm.ExtendControl;
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
using Nikita.Assist.CodeMaker.CodeMakerDemoForm;
using Nikita.Base.Define;
namespace Nikita.Assist.CodeMaker
{
    /// <summary>说明:FrmOrderMasterMasterDetailQuery
    /// 作者:Luhm
    /// 最后修改人:
    /// 最后修改时间:
    /// 创建时间:2016-05-19 22:21:20
    /// </summary>
    public partial class FrmOrderMasterMasterDetailQuery : Form
    {
        #region 常量、变量
      /// <summary>主表操作类
        /// 
        /// </summary>
        private OrderMasterDAL m_OrderMasterDAL;
        /// <summary>子表操作类
        /// 
        /// </summary>
        private OrderDetailDAL  m_OrderDetailDAL;
        /// <summary>主表绑定集合
        /// 
        /// </summary>
        private List<OrderMaster>  m_lstOrderMaster;
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
        public FrmOrderMasterMasterDetailQuery()
        {
            InitializeComponent();
            cboFilterType.SelectedIndex = 2;
            m_OrderMasterDAL = new OrderMasterDAL();
            m_OrderDetailDAL  = new OrderDetailDAL ();
            m_lstOrderMaster = new List<OrderMaster>();
            DoInitData();
            DoInitMasterGridSource();
            DoInitDetailGridSource();
            #region 主表列表绑定字段
              this.gridmrzOrderId.AspectGetter = x => ((OrderMaster)x).OrderId;
              this.gridmrzOrderNumber.AspectGetter = x => ((OrderMaster)x).OrderNumber;
            this.gridmrzStatus.AspectGetter = delegate(object x) { return GetMasterStatus(((OrderMaster)x).Status); };
              this.gridmrzCreateDate.AspectGetter = x => ((OrderMaster)x).CreateDate;
            #endregion
            #region 明细表列表绑定字段
              this.gridDetailmrzDetailId.AspectGetter = x => ((OrderDetail)x).DetailId;
              this.gridDetailmrzOrderId.AspectGetter = x => ((OrderDetail)x).OrderId;
              this.gridDetailmrzCustomer.AspectGetter = x => ((OrderDetail)x).Customer;
              this.gridDetailmrzProductName.AspectGetter = x => ((OrderDetail)x).ProductName;
              this.gridDetailmrzAmount.AspectGetter = x => ((OrderDetail)x).Amount;
              this.gridDetailmrzSumMoney.AspectGetter = x => ((OrderDetail)x).SumMoney;
            this.gridDetailmrzStatus.AspectGetter = delegate(object x) { return GetDetailStatus(((OrderDetail)x).Status); };
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
                    case "cmdRefresh ":
                        DoQueryData();
                        break;
                    case  "cmdNew ":
                        DoNew();
                        break;
                    case  "cmdEdit ":
                        DoEdit();
                        break;
                    case  "cmdDelete ":
                        DoDeleteOrCancel(EntityOperationType.删除);
                        break;
                    case  "cmdCancel ":
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
            OrderMaster model = objListViewMaster.SelectedObjects[0] as  OrderMaster;
            if (model != null)
            {
                 m_lstOrderDetail = m_OrderDetailDAL.GetListArray("OrderId=" + model.OrderId + "");
                objListViewDetail.SetObjects( m_lstOrderDetail );
                objListViewDetail.Refresh();
            }
        }
        /// <summary>通用查询
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
                m_lstOrderMaster = m_OrderMasterDAL.GetListArray("*", "OrderId", "ASC", Pager.PageSize, Pager.PageIndex, strWhere);
                Pager.RecordCount = m_OrderMasterDAL.CalcCount(strWhere);
                Pager.InitPageInfo();
                objListViewMaster.SetObjects(  m_lstOrderMaster );
                if (  m_lstOrderMaster .Count > 0)
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
                ? m_OrderMasterDAL.DeleteByCond("OrderId in (" + strIds + ")")
                : m_OrderMasterDAL.Update("Status =0", "OrderId in (" + strIds + ")");
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
                FrmOrderMasterMasterDetailDialog frmDialog = new  FrmOrderMasterMasterDetailDialog(model, m_lstOrderMaster, m_lstOrderDetail,m_dsDetailGridSource);
                if (frmDialog.ShowDialog() == DialogResult.OK)
                {
                    m_lstOrderMaster = frmDialog.ListOrderMaster ;
                    m_lstOrderDetail = frmDialog.ListOrderDetail ;
                    if ( m_lstOrderMaster != null)
                    {
                        objListViewMaster.SetObjects( m_lstOrderMaster);
                        objListViewMaster.Refresh();
                    }
                    if (  m_lstOrderDetail != null)
                    {
                        objListViewDetail.SetObjects(  m_lstOrderDetail);
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
   FrmOrderMasterMasterDetailDialog frmDialog = new FrmOrderMasterMasterDetailDialog (null, m_lstOrderMaster, m_lstOrderDetail,m_dsDetailGridSource);
            if (frmDialog.ShowDialog() == DialogResult.OK)
            {
                m_lstOrderMaster = frmDialog.ListOrderMaster ;
                m_lstOrderDetail = frmDialog.ListOrderDetail ;
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
        }
        /// <summary>初始主表数据源
        ///
        /// </summary>
        private void DoInitMasterGridSource()
        {
 const string strBindSql="SELECT  'True' AS value ,'有效' AS name  UNION  ALL SELECT 'False' AS value ,'无效' AS name ;SELECT 'gridmrzStatus '";
  BindSourceHelper.BindClass bindClass = new BindSourceHelper.BindClass()
  {
     SqlType =  SqlType.SqlServer,
      BindSql =strBindSql
   }; 
            m_dsMasterGridSource = BindSourceHelper.GetBindSourceDataSet(bindClass);
        }
        #endregion
/// <summary>初始化明细数据源
        ///
        /// </summary>
        private void DoInitDetailGridSource()
        {
 const string strBindSql="SELECT  'True' AS value ,'有效' AS name  UNION  ALL SELECT 'False' AS value ,'无效' AS name ;SELECT 'gridDetailmrzStatus '";
  BindSourceHelper.BindClass bindClass = new BindSourceHelper.BindClass()
  {
     SqlType = SqlType.SqlServer,
      BindSql =strBindSql
   }; 
            m_dsDetailGridSource = BindSourceHelper.GetBindSourceDataSet(bindClass);
        }
     #region 主表绑定方法
        private string GetMasterStatus(object objStatus)
        {
            return m_dsMasterGridSource.Tables["gridmrzStatus"].Select("value = '" + objStatus + "'")[0]["name "].ToString();
        }
        #endregion
#region 明细绑定方法
        private string GetDetailStatus(object objStatus)
        {
            return m_dsDetailGridSource.Tables["gridDetailmrzStatus"].Select("value = '" + objStatus + "'")[0]["name "].ToString();
        }
        #endregion 
    }
}
