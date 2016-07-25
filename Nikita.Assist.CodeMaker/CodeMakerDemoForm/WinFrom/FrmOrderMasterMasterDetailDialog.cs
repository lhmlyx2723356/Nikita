/// <summary>说明:FrmOrderMasterMasterDetailDialog文件
/// 作者:卢华明
/// 创建时间:2016-05-19 22:21:19
/// </summary>
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.Core.Literacy;
using Nikita.Core;
using Nikita.Core.WinForm;
using Nikita.Assist.CodeMaker.DAL;
using Nikita.Assist.CodeMaker.Model;
using Nikita.Base.Define;

namespace Nikita.Assist.CodeMaker
{
    /// <summary>说明:FrmOrderMasterMasterDetailDialog
    /// 作者:Luhm
    /// 最后修改人:
    /// 最后修改时间:
    /// 创建时间:2016-05-19 22:21:19
    /// </summary>
    public partial class FrmOrderMasterMasterDetailDialog : Form
    {
        #region 常量、变量
        /// <summary>主表对象
        /// 
        /// </summary>
        private OrderMaster m_OrderMaster;
        /// <summary>主表集合
        /// 
        /// </summary>
        private List<OrderMaster> m_lstOrderMaster;
        /// <summary>明细集合
        /// 
        /// </summary>
        private List<OrderDetail> m_lstOrderDetail;
        /// <summary>主表操作类
        /// 
        /// </summary>
        private OrderMasterDAL m_OrderMasterDAL;
        /// <summary>子表操作类
        /// 
        /// </summary>
        private OrderDetailDAL m_OrderDetailDAL;
        /// <summary>主表编辑状态
        /// 
        /// </summary> 
        private EntityOperationType m_masterStatus;
        /// <summary>明细编辑状态
        /// 
        /// </summary> 
        private EntityOperationType m_detailStatus;
        /// <summary>返回主表对象集合
        /// 
        /// </summary> 
        public List<OrderMaster> ListOrderMaster { get; private set; }
        /// <summary>返回子表对象集合
        /// 
        /// </summary> 
        public List<OrderDetail> ListOrderDetail { get; private set; }
        /// <summary>Detail列表下拉框绑定数据源
        /// 
        /// </summary>
        private DataSet m_dsDetailGridSource;
        #endregion

        #region 构造函数
        /// <summary>构造函数
        /// 
        /// </summary>
        /// <param name="modelMaster">modelMaster</param>
        /// <param name="lstOrderMaster">lstOrderMaster</param>
        /// <param name="lstOrderDetail">lstOrderDetail</param>
        public FrmOrderMasterMasterDetailDialog(OrderMaster modelMaster,
                                                                          List<OrderMaster> lstOrderMaster,
                                                                          List<OrderDetail> lstOrderDetail,
                                                                          DataSet dsDetailGridSource)
        {
            InitializeComponent();
            DoInitMasterData();
            DoInitDetailData();
            #region 明细表列表绑定字段
            this.gridDetailmrzDetailId.AspectGetter = x => ((OrderDetail)x).DetailId;
            this.gridDetailmrzOrderId.AspectGetter = x => ((OrderDetail)x).OrderId;
            this.gridDetailmrzCustomer.AspectGetter = x => ((OrderDetail)x).Customer;
            this.gridDetailmrzProductName.AspectGetter = x => ((OrderDetail)x).ProductName;
            this.gridDetailmrzAmount.AspectGetter = x => ((OrderDetail)x).Amount;
            this.gridDetailmrzSumMoney.AspectGetter = x => ((OrderDetail)x).SumMoney;
            this.gridDetailmrzStatus.AspectGetter = delegate(object x) { return GetDetailStatus(((OrderDetail)x).Status); };
            #endregion
            this.m_OrderMasterDAL = new OrderMasterDAL();
            this.m_OrderDetailDAL = new OrderDetailDAL();
            this.m_OrderMaster = modelMaster;
            this.m_lstOrderMaster = lstOrderMaster;
            this.m_lstOrderDetail = lstOrderDetail;
            this.m_dsDetailGridSource = dsDetailGridSource;
            //修改
            if (modelMaster != null)
            {
                m_OrderMaster = modelMaster;
                DisplayData(m_OrderMaster);
                if (m_lstOrderDetail != null && m_lstOrderDetail.Count > 0)
                {
                    objListViewDetail.SetObjects(m_lstOrderDetail);
                    objListViewDetail.Refresh();
                    objListViewDetail.SelectedIndex = 0;
                }
            }
            Command_Click(modelMaster == null ? cmdNew : cmdEdit, null);
        }
        #endregion
        #region 基础事件
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
                    case "cmdNew":
                        DoNewOrEdit(EntityOperationType.新增);
                        break;
                    case "cmdEdit":
                        DoNewOrEdit(EntityOperationType.修改);
                        break;
                    case "cmdDelete":
                        DoDelete();
                        break;
                    case "cmdSave":
                        DoSave();
                        break;
                    case "cmdCancel":
                        DoCancel();
                        break;
                    case "cmdNewDetail":
                        DoNewOrEditDetail(EntityOperationType.新增明细);
                        break;
                    case "cmdEditDetail":
                        DoNewOrEditDetail(EntityOperationType.修改明细);
                        break;
                    case "cmdDeleteDetail":
                        DoDeleteDetail();
                        break;
                    case "cmdSaveDetail":
                        DoSaveDetail();
                        break;
                    case "cmdCancelDetail":
                        DoCancelDetail();
                        break;
                }
            }
        }
        /// <summary>明细表行变化事件
        /// 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void objListViewDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (objListViewDetail.SelectedObjects.Count == 0)
            {
                return;
            }
            OrderDetail model = objListViewDetail.SelectedObjects[0] as OrderDetail;
            if (model != null)
            {
                EntityOperateManager.BindAll(this.grpDetail, model);
            }
        }
        #endregion

        #region 基本方法
        #region 主表操作
        /// <summary>新增或者修改主表
        /// 
        /// </summary>
        /// <param name="operationType">操作类型</param>
        private void DoNewOrEdit(EntityOperationType operationType)
        {
            SetMode(operationType);
        }
        /// <summary>保存主表
        /// 
        /// </summary>
        private void DoSave()
        {
            switch (m_masterStatus)
            {
                case EntityOperationType.新增:
                    string strOrderNumberValueNew = txtEditOrderNumber.Text.Trim();
                    if (m_OrderMasterDAL.CalcCount("OrderNumber='" + strOrderNumberValueNew + "'") > 0)
                    {
                        MessageBox.Show(@"单号已经存在");
                        return;
                    }

                    OrderMaster model = EntityOperateManager.AddEntity<OrderMaster>(this.grpMaster);
                    int intReturn = m_OrderMasterDAL.Add(model);
                    if (intReturn > 0)
                    {
                        m_OrderMaster = model;
                        model.OrderId = intReturn;
                        m_lstOrderMaster.Add(model);
                        ListOrderMaster = m_lstOrderMaster;
                        //清空明细列表
                        m_lstOrderDetail.Clear();
                        objListViewDetail.SetObjects(m_lstOrderDetail);
                        objListViewDetail.Refresh();
                    }
                    break;
                case EntityOperationType.修改:
                    string strOrderNumberValue = txtEditOrderNumber.Text.Trim()
             ;
                    if (m_OrderMasterDAL.CalcCount(" OrderId !=" + m_OrderMaster.OrderId + "   and  OrderNumber='" + strOrderNumberValue + "'") > 0)
                    {
                        MessageBox.Show(@"单号已经存在");
                        return;
                    }

                    m_OrderMaster = EntityOperateManager.EditEntity(this.grpMaster, m_OrderMaster);
                    bool blnReturn = m_OrderMasterDAL.Update(m_OrderMaster);
                    if (blnReturn)
                    {
                        ListOrderMaster = m_lstOrderMaster;
                    }
                    break;
            }
            SetMode(EntityOperationType.只读);
        }
        /// <summary>删除主表，连同明细一起删除
        /// 
        /// </summary> 
        private void DoDelete()
        {
            m_OrderDetailDAL.DeleteByCond("OrderId=" + m_OrderMaster.OrderId + "");
            m_OrderMasterDAL.Delete(m_OrderMaster.OrderId);
            m_lstOrderMaster.Remove(m_OrderMaster);
            m_OrderMaster = null;
            if (m_lstOrderDetail != null)
            {
                m_lstOrderDetail.Clear();
                objListViewDetail.SetObjects(m_lstOrderDetail);
                objListViewDetail.Refresh();
            }
            SetMode(EntityOperationType.只读);
        }
        /// <summary>撤销操作
        /// 
        /// </summary> 
        private void DoCancel()
        {
            if (m_OrderMaster != null)
            {
                DisplayData(m_OrderMaster);
                SetMode(EntityOperationType.只读);
            }
        }
        #endregion
        #region 明细表操作
        /// <summary>新增或者修改明细表
        /// 
        /// </summary>
        /// <param name="operationType">操作类型</param>
        private void DoNewOrEditDetail(EntityOperationType operationType)
        {
            string strMsg = DoCheck(operationType);
            if (strMsg != string.Empty)
            {
                MessageBox.Show(strMsg);
                return;
            }
            SetMode(operationType);
        }
        /// <summary>保存明细表
        /// 
        /// </summary>
        private void DoSaveDetail()
        {
            switch (m_detailStatus)
            {
                case EntityOperationType.新增明细:
                    OrderDetail model = EntityOperateManager.AddEntity<OrderDetail>(this.grpDetail);
                    model.OrderId = m_OrderMaster.OrderId;
                    int intReturn = m_OrderDetailDAL.Add(model);
                    if (intReturn > 0)
                    {
                        model.DetailId = intReturn;
                        m_lstOrderDetail.Add(model);
                        ListOrderDetail = m_lstOrderDetail;
                        objListViewDetail.SetObjects(m_lstOrderDetail);
                        objListViewDetail.Refresh();
                        objListViewDetail.SelectedIndex = m_lstOrderDetail.Count - 1;
                    }
                    break;
                case EntityOperationType.修改明细:
                    OrderDetail modelDetail = this.objListViewDetail.SelectedObjects[0] as OrderDetail;
                    EntityOperateManager.EditEntity(this.grpDetail, modelDetail);
                    bool blnReturn = m_OrderDetailDAL.Update(modelDetail);
                    if (blnReturn)
                    {
                        ListOrderDetail = m_lstOrderDetail;
                    }
                    break;
            }
            SetMode(EntityOperationType.只读明细);
        }
        /// <summary>删除明细表，允许选中多个进行删除
        /// 
        /// </summary>
        private void DoDeleteDetail()
        {
            if (m_lstOrderDetail != null && this.objListViewDetail.SelectedObjects.Count > 0)
            {
                IList listObjects = this.objListViewDetail.SelectedObjects;
                string strIds = listObjects.Cast<OrderDetail>().Aggregate(string.Empty, (current, modelDetail) => current + modelDetail.DetailId + ",");
                strIds = strIds.TrimEnd(',');
                if (strIds.Length > 0)
                {
                    m_OrderDetailDAL.DeleteByCond("DetailId in(" + strIds + ")");
                    m_lstOrderDetail.RemoveAll(t => strIds.Split(',').Contains(t.DetailId.ToString()));
                    ListOrderDetail = m_lstOrderDetail;
                    objListViewDetail.SetObjects(m_lstOrderDetail);
                    objListViewDetail.Refresh();
                }
            }
            SetMode(EntityOperationType.只读明细);
        }
        /// <summary>撤销明细表操作
        /// 
        /// </summary>
        private void DoCancelDetail()
        {
            objListViewDetail_SelectedIndexChanged(null, null);
            SetMode(EntityOperationType.只读明细);
        }
        #endregion
        /// <summary>设置按钮跟面板控件的可用性
        /// 
        /// </summary>
        /// <param name="operationType">操作类型</param>
        public void SetMode(EntityOperationType operationType)
        {
            switch (operationType)
            {
                case EntityOperationType.新增:
                case EntityOperationType.修改:
                    m_masterStatus = operationType;
                    if (operationType == EntityOperationType.新增)
                    {
                        ControlManager.ClearAll(grpMaster);
                    }
                    ControlManager.SetControlEnabled(grpMaster, false);
                    ControlManager.SetBtnEnabled(new Component[] { cmdSave, cmdCancel }, true);
                    ControlManager.SetBtnEnabled(new Component[] { cmdNew, cmdDelete, cmdEdit }, false);
                    ControlManager.SetControlEnabled(grpMaster, true);
                    //新增或者修改主表是，明细不可用，只有保存完主表信息才能操作明细信息
                    ControlManager.SetControlEnabled(grpDetail, false);
                    ControlManager.SetBtnEnabled(new Component[] { cmdSaveDetail, cmdCancelDetail, cmdNewDetail, cmdDeleteDetail, cmdEditDetail }, false);
                    break;
                case EntityOperationType.只读:
                    m_masterStatus = operationType;
                    ControlManager.SetControlEnabled(grpMaster, false);
                    ControlManager.SetBtnEnabled(new Component[] { cmdSave, cmdCancel }, false);
                    ControlManager.SetBtnEnabled(new Component[] { cmdNew, cmdDelete, cmdEdit }, true);
                    SetMode(EntityOperationType.只读明细);
                    break;
                case EntityOperationType.新增明细:
                case EntityOperationType.修改明细:
                    m_detailStatus = operationType;
                    if (operationType == EntityOperationType.新增明细)
                    {
                        ControlManager.ClearAll(grpDetail);
                    }
                    ControlManager.SetControlEnabled(grpDetail, false);
                    ControlManager.SetBtnEnabled(new Component[] { cmdSaveDetail, cmdCancelDetail }, true);
                    ControlManager.SetBtnEnabled(new Component[] { cmdNewDetail, cmdDeleteDetail, cmdEditDetail }, false);
                    ControlManager.SetControlEnabled(grpDetail, true);
                    break;
                case EntityOperationType.只读明细:
                    m_detailStatus = operationType;
                    ControlManager.SetControlEnabled(grpDetail, false);
                    ControlManager.SetBtnEnabled(new Component[] { cmdSaveDetail, cmdCancelDetail }, false);
                    ControlManager.SetBtnEnabled(new Component[] { cmdNewDetail, cmdDeleteDetail, cmdEditDetail }, true);
                    break;
            }
        }
        /// <summary>检查合法性
        /// 
        /// </summary>
        /// <param name="operationType">操作类型</param>
        /// <returns></returns>
        private string DoCheck(EntityOperationType operationType)
        {
            string strMsg = string.Empty;
            if (m_OrderMaster == null || m_masterStatus != EntityOperationType.只读)
            {
                return "请先保存主表信息";
            }
            if (operationType == EntityOperationType.修改明细)
            {
                if (this.objListViewDetail.SelectedObjects.Count == 0)
                {
                    return @"请先选择要修改的明细";
                }
            }
            if (txtDetailEditCustomer.Text.Trim() == string.Empty)
            {
                txtDetailEditCustomer.Select();
                return "客户不能为空";
            }

            return strMsg;
        }
        /// <summary>实体对象值显示至控件
        /// 
        /// </summary>
        /// <param name="model">model</param>
        private void DisplayData(OrderMaster model)
        {
            EntityOperateManager.BindAll(this.grpMaster, model);
        }
        /// <summary>初始化Master绑定
        /// 
        /// </summary>
        private void DoInitMasterData()
        {
        }
        /// <summary>初始化Detail绑定
        /// 
        /// </summary>
        private void DoInitDetailData()
        {
        }
        #region 明细绑定方法
        private string GetDetailDetailId(object objDetailId)
        {
            return m_dsDetailGridSource.Tables["gridDetailmrzDetailId"].Select(" = '" + objDetailId + "'")[0][" "].ToString();
        }
        private string GetDetailOrderId(object objOrderId)
        {
            return m_dsDetailGridSource.Tables["gridDetailmrzOrderId"].Select(" = '" + objOrderId + "'")[0][" "].ToString();
        }
        private string GetDetailCustomer(object objCustomer)
        {
            return m_dsDetailGridSource.Tables["gridDetailmrzCustomer"].Select(" = '" + objCustomer + "'")[0][" "].ToString();
        }
        private string GetDetailProductName(object objProductName)
        {
            return m_dsDetailGridSource.Tables["gridDetailmrzProductName"].Select(" = '" + objProductName + "'")[0][" "].ToString();
        }
        private string GetDetailAmount(object objAmount)
        {
            return m_dsDetailGridSource.Tables["gridDetailmrzAmount"].Select(" = '" + objAmount + "'")[0][" "].ToString();
        }
        private string GetDetailSumMoney(object objSumMoney)
        {
            return m_dsDetailGridSource.Tables["gridDetailmrzSumMoney"].Select(" = '" + objSumMoney + "'")[0][" "].ToString();
        }
        private string GetDetailStatus(object objStatus)
        {
            return m_dsDetailGridSource.Tables["gridDetailmrzStatus"].Select("value = '" + objStatus + "'")[0]["name "].ToString();
        }
        #endregion
        #endregion
    }
}
