/// <summary>说明:FrmBseProjectModuleMasterDetailDialog文件
/// 作者:卢华明
/// 创建时间:2016/6/5 18:22:40
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
using Nikita.Base.Define;
using Nikita.Base.IDAL;
using Nikita.Core.WinForm; 
using Nikita.Platform.BugClose.Model;
namespace Nikita.Platform.BugClose
{
    /// <summary>说明:FrmBseProjectModuleMasterDetailDialog
    /// 作者:Luhm
    /// 最后修改人:
    /// 最后修改时间:
    /// 创建时间:2016/6/5 18:22:40
    /// </summary>
    public partial class FrmBseProjectModuleMasterDetailDialog : Form
    {
        #region 常量、变量
        /// <summary>主表对象
        /// 
        /// </summary>
        private BseProject m_BseProject;
        /// <summary>主表集合
        /// 
        /// </summary>
        private List<BseProject> m_lstBseProject;
        /// <summary>明细集合
        /// 
        /// </summary>
        private List<BseModule> m_lstBseModule;
        /// <summary>主表操作类
        /// 
        /// </summary>
        private IBseDAL<BseProject> m_BseProjectDAL;
        /// <summary>子表操作类
        /// 
        /// </summary>
        private IBseDAL<BseModule> m_BseModuleDAL;
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
        public List<BseProject> ListBseProject { get; private set; }
        /// <summary>返回子表对象集合
        /// 
        /// </summary> 
        public List<BseModule> ListBseModule { get; private set; }
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
        /// <param name="lstBseProject">lstBseProject</param>
        /// <param name="lstBseModule">lstBseModule</param>
        public FrmBseProjectModuleMasterDetailDialog(BseProject modelMaster,
                                                                          List<BseProject> lstBseProject,
                                                                          List<BseModule> lstBseModule,
                                                                          DataSet dsDetailGridSource)
        {
            InitializeComponent();
            DoInitMasterData();
            DoInitDetailData();
            #region 明细表列表绑定字段
            this.gridDetailmrzModuleID.AspectGetter = x => ((BseModule)x).ModuleID;
            this.gridDetailmrzProjectID.AspectGetter = delegate (object x) { return GetDetailProjectID(((BseModule)x).ProjectID); };
            this.gridDetailmrzName.AspectGetter = x => ((BseModule)x).Name;
            this.gridDetailmrzStatus.AspectGetter = x => ((BseModule)x).Status;
            this.gridDetailmrzRemark.AspectGetter = x => ((BseModule)x).Remark;
            this.gridDetailmrzSort.AspectGetter = x => ((BseModule)x).Sort;
            this.gridDetailmrzDeptId.AspectGetter = x => ((BseModule)x).DeptId;
            this.gridDetailmrzCompanyID.AspectGetter = x => ((BseModule)x).CompanyID;
            this.gridDetailmrzCreateDate.AspectGetter = x => ((BseModule)x).CreateDate;
            this.gridDetailmrzCreateUser.AspectGetter = x => ((BseModule)x).CreateUser;
            this.gridDetailmrzEditDate.AspectGetter = x => ((BseModule)x).EditDate;
            this.gridDetailmrzEditUser.AspectGetter = x => ((BseModule)x).EditUser;
            #endregion

            this.m_BseProjectDAL = GlobalHelp.GetResolve<IBseDAL<BseProject>>();
            this.m_BseModuleDAL = GlobalHelp.GetResolve<IBseDAL<BseModule>>();
            this.m_BseProject = modelMaster;
            this.m_lstBseProject = lstBseProject ?? new List<BseProject>();
            this.m_lstBseModule = lstBseModule ?? new List<BseModule>();
            this.m_dsDetailGridSource = dsDetailGridSource;
            //修改
            if (modelMaster != null)
            {
                m_BseProject = modelMaster;
                DisplayData(m_BseProject);
                if (m_lstBseModule != null && m_lstBseModule.Count > 0)
                {
                    objListViewDetail.SetObjects(m_lstBseModule);
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
            BseModule model = objListViewDetail.SelectedObjects[0] as BseModule;
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
            string strMsg = DoCheckMaster();
            if (strMsg != string.Empty)
            {
                MessageBox.Show(strMsg);
                return;
            }
            switch (m_masterStatus)
            {
                case EntityOperationType.新增:
                    string strNameValueNew = txtEditName.Text.Trim();
                    if (m_BseProjectDAL.CalcCount("Name='" + strNameValueNew + "'") > 0)
                    {
                        MessageBox.Show(@"名称已经存在");
                        return;
                    }

                    BseProject model = EntityOperateManager.AddEntity<BseProject>(this.grpMaster);
                    int intReturn = m_BseProjectDAL.Add(model);
                    if (intReturn > 0)
                    {
                        m_BseProject = model;
                        model.ProjectID = intReturn;
                        m_lstBseProject.Add(model);
                        ListBseProject = m_lstBseProject;
                        //清空明细列表
                        m_lstBseModule.Clear();
                        objListViewDetail.SetObjects(m_lstBseModule);
                        objListViewDetail.Refresh();
                    }
                    break;
                case EntityOperationType.修改:
                    string strNameValueEdit = txtEditName.Text.Trim();
                    if (m_BseProjectDAL.CalcCount(" ProjectID !=" + m_BseProject.ProjectID + "   and  Name='" + strNameValueEdit + "'") > 0)
                    {
                        MessageBox.Show(@"名称已经存在");
                        return;
                    }

                    m_BseProject = EntityOperateManager.EditEntity(this.grpMaster, m_BseProject);
                    bool blnReturn = m_BseProjectDAL.Update(m_BseProject);
                    if (blnReturn)
                    {
                        ListBseProject = m_lstBseProject;
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
            m_BseModuleDAL.DeleteByCond("ProjectID=" + m_BseProject.ProjectID + "");
            m_BseProjectDAL.Delete(m_BseProject.ProjectID);
            m_lstBseProject.Remove(m_BseProject);
            m_BseProject = null;
            if (m_lstBseModule != null)
            {
                m_lstBseModule.Clear();
                objListViewDetail.SetObjects(m_lstBseModule);
                objListViewDetail.Refresh();
            }
            SetMode(EntityOperationType.只读);
        }
        /// <summary>撤销操作
        /// 
        /// </summary> 
        private void DoCancel()
        {
            if (m_BseProject != null)
            {
                DisplayData(m_BseProject);
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
            string strMsg = DoCheckDetail(operationType);
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
            string strMsg = DoCheckDetail(EntityOperationType.只读明细);
            if (strMsg != string.Empty)
            {
                MessageBox.Show(strMsg);
                return;
            }
            switch (m_detailStatus)
            {
                case EntityOperationType.新增明细:
                    BseModule model = EntityOperateManager.AddEntity<BseModule>(this.grpDetail);
                    model.ProjectID = m_BseProject.ProjectID;
                    int intReturn = m_BseModuleDAL.Add(model);
                    if (intReturn > 0)
                    {
                        model.ModuleID = intReturn;
                        m_lstBseModule.Add(model);
                        ListBseModule = m_lstBseModule;
                        objListViewDetail.SetObjects(m_lstBseModule);
                        objListViewDetail.Refresh();
                        objListViewDetail.SelectedIndex = m_lstBseModule.Count - 1;
                    }
                    break;
                case EntityOperationType.修改明细:
                    BseModule modelDetail = this.objListViewDetail.SelectedObjects[0] as BseModule;
                    EntityOperateManager.EditEntity(this.grpDetail, modelDetail);
                    bool blnReturn = m_BseModuleDAL.Update(modelDetail);
                    if (blnReturn)
                    {
                        ListBseModule = m_lstBseModule;
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
            if (m_lstBseModule != null && this.objListViewDetail.SelectedObjects.Count > 0)
            {
                IList listObjects = this.objListViewDetail.SelectedObjects;
                string strIds = listObjects.Cast<BseModule>().Aggregate(string.Empty, (current, modelDetail) => current + modelDetail.ModuleID + ",");
                strIds = strIds.TrimEnd(',');
                if (strIds.Length > 0)
                {
                    m_BseModuleDAL.DeleteByCond("ModuleID in(" + strIds + ")");
                    m_lstBseModule.RemoveAll(t => strIds.Split(',').Contains(t.ModuleID.ToString()));
                    ListBseModule = m_lstBseModule;
                    objListViewDetail.SetObjects(m_lstBseModule);
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
        /// <returns>错误信息</returns>
        private string DoCheckDetail(EntityOperationType operationType)
        {
            string strMsg = string.Empty;
            if (m_BseProject == null || m_masterStatus != EntityOperationType.只读)
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
            if (operationType == EntityOperationType.只读明细)
            {
                if (cboDetailEditProjectID.Text.Trim() == string.Empty)
                {
                    cboDetailEditProjectID.Select();
                    return "请选择所属项目";
                }

                if (txtDetailEditName.Text.Trim() == string.Empty)
                {
                    txtDetailEditName.Select();
                    return "模块名称不能为空";
                }

                if (txtDetailEditSort.Text.Trim() == string.Empty)
                {
                    txtDetailEditSort.Select();
                    return "排序不能为空";
                }

            }
            return strMsg;
        }
        /// <summary>检查合法性
        /// 
        /// </summary>
        /// <returns>错误信息</returns>
        private string DoCheckMaster()
        {
            string strMsg = string.Empty;
            if (cboEditCategory.Text.Trim() == string.Empty)
            {
                cboEditCategory.Select();
                return "请选择分类";
            }

            if (txtEditName.Text.Trim() == string.Empty)
            {
                txtEditName.Select();
                return "名称不能为空";
            }

            if (cboEditOnLevel.Text.Trim() == string.Empty)
            {
                cboEditOnLevel.Select();
                return "请选择等级";
            }

            if (txtEditSort.Text.Trim() == string.Empty)
            {
                txtEditSort.Select();
                return "排序不能为空";
            }

            return strMsg;
        }
        /// <summary>实体对象值显示至控件
        /// 
        /// </summary>
        /// <param name="model">model</param>
        private void DisplayData(BseProject model)
        {
            EntityOperateManager.BindAll(this.grpMaster, model);
        }
        /// <summary>初始化Master绑定
        /// 
        /// </summary>
        private void DoInitMasterData()
        {
            const string strBindEditSql = "SELECT   Name,value FROM [BseDictionary] WHERE ParentID=19;SELECT   Name,value FROM [BseDictionary] WHERE ParentID=22;SELECT 'cboEditCategory ','cboEditOnLevel '";
            BindClass bindClass = new BindClass()
            {
                SqlType = SqlType.SqlServer,
                BindSql = strBindEditSql
            };
            DataSet ds = BindSourceHelper.GetBindSourceDataSet(bindClass, GlobalHelp.Conn);
            ComboBoxHelper.BindComboBox(cboEditCategory, ds.Tables["cboEditCategory"], "Name", "Value");
            ComboBoxHelper.BindComboBox(cboEditOnLevel, ds.Tables["cboEditOnLevel"], "Name", "Value");

        }
        /// <summary>初始化Detail绑定
        /// 
        /// </summary>
        private void DoInitDetailData()
        {
            const string strBindEditSql = "SELECT ProjectID,Name From BseProject;SELECT 'cboDetailEditProjectID '";
            BindClass bindClass = new BindClass()
            {
                SqlType = SqlType.SqlServer,
                BindSql = strBindEditSql
            };
            DataSet ds = BindSourceHelper.GetBindSourceDataSet(bindClass, GlobalHelp.Conn);
            ComboBoxHelper.BindComboBox(cboDetailEditProjectID, ds.Tables["cboDetailEditProjectID"], "Name", "ProjectID");

        }
        #region 明细绑定方法
        private string GetDetailProjectID(object objProjectID)
        {
            return m_dsDetailGridSource.Tables["gridDetailmrzProjectID"].Select("ProjectID = '" + objProjectID + "'")[0]["Name"].ToString();
        }
        #endregion 
        #endregion
    }
}
