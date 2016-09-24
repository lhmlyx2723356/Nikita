using Nikita.Base.Define;
using Nikita.Base.IDAL;
using Nikita.Core.WinForm;
using Nikita.Platform.BugClose.Model;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nikita.Platform.BugClose
{
    /// <summary>说明:FrmBseProjectMasterDetailDialog
    /// 作者:Luhm
    /// 最后修改人:
    /// 最后修改时间:
    /// 创建时间:2016/6/4 18:09:29
    /// </summary>
    public partial class FrmBseProjectMasterDetailDialog : Form
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
        private List<BseProjectVersion> m_lstBseProjectVersion;

        /// <summary>主表操作类
        ///
        /// </summary>
        private IBseDAL<BseProject> m_BseProjectDAL;

        /// <summary>子表操作类
        ///
        /// </summary>
        private IBseDAL<BseProjectVersion> m_BseProjectVersionDAL;

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
        public List<BseProjectVersion> ListBseProjectVersion { get; private set; }

        /// <summary>Detail列表下拉框绑定数据源
        ///
        /// </summary>
        private DataSet m_dsDetailGridSource;

        #endregion 常量、变量

        #region 构造函数

        /// <summary>构造函数
        ///
        /// </summary>
        /// <param name="modelMaster">modelMaster</param>
        /// <param name="lstBseProject">lstBseProject</param>
        /// <param name="lstBseProjectVersion">lstBseProjectVersion</param>
        public FrmBseProjectMasterDetailDialog(BseProject modelMaster,
                                                                          List<BseProject> lstBseProject,
                                                                          List<BseProjectVersion> lstBseProjectVersion,
                                                                          DataSet dsDetailGridSource)
        {
            InitializeComponent();
            DoInitMasterData();
            DoInitDetailData();

            #region 明细表列表绑定字段

            this.gridDetailmrzVersionID.AspectGetter = x => ((BseProjectVersion)x).VersionID;
            this.gridDetailmrzProjectID.AspectGetter = delegate (object x) { return GetDetailProjectID(((BseProjectVersion)x).ProjectID); };
            this.gridDetailmrzName.AspectGetter = x => ((BseProjectVersion)x).Name;
            this.gridDetailmrzStatus.AspectGetter = x => ((BseProjectVersion)x).Status;
            this.gridDetailmrzRemark.AspectGetter = x => ((BseProjectVersion)x).Remark;
            this.gridDetailmrzSort.AspectGetter = x => ((BseProjectVersion)x).Sort;
            this.gridDetailmrzDeptId.AspectGetter = x => ((BseProjectVersion)x).DeptId;
            this.gridDetailmrzCompanyID.AspectGetter = x => ((BseProjectVersion)x).CompanyID;
            this.gridDetailmrzCreateDate.AspectGetter = x => ((BseProjectVersion)x).CreateDate;
            this.gridDetailmrzCreateUser.AspectGetter = x => ((BseProjectVersion)x).CreateUser;
            this.gridDetailmrzEditDate.AspectGetter = x => ((BseProjectVersion)x).EditDate;
            this.gridDetailmrzEditUser.AspectGetter = x => ((BseProjectVersion)x).EditUser;

            #endregion 明细表列表绑定字段

            this.m_BseProjectDAL = GlobalHelp.GetResolve<IBseDAL<BseProject>>();
            this.m_BseProjectVersionDAL = GlobalHelp.GetResolve<IBseDAL<BseProjectVersion>>();
            this.m_BseProject = modelMaster;
            this.m_lstBseProject = lstBseProject ?? new List<BseProject>();
            this.m_lstBseProjectVersion = lstBseProjectVersion ?? new List<BseProjectVersion>();
            this.m_dsDetailGridSource = dsDetailGridSource;
            //修改
            if (modelMaster != null)
            {
                m_BseProject = modelMaster;
                DisplayData(m_BseProject);
                if (m_lstBseProjectVersion != null && m_lstBseProjectVersion.Count > 0)
                {
                    objListViewDetail.SetObjects(m_lstBseProjectVersion);
                    objListViewDetail.Refresh();
                    objListViewDetail.SelectedIndex = 0;
                }
            }
            Command_Click(modelMaster == null ? cmdNew : cmdEdit, null);
        }

        #endregion 构造函数

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
            BseProjectVersion model = objListViewDetail.SelectedObjects[0] as BseProjectVersion;
            if (model != null)
            {
                EntityOperateManager.BindAll(this.grpDetail, model);
            }
        }

        #endregion 基础事件

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
                        m_lstBseProjectVersion.Clear();
                        objListViewDetail.SetObjects(m_lstBseProjectVersion);
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
            m_BseProjectVersionDAL.DeleteByCond("ProjectID=" + m_BseProject.ProjectID + "");
            m_BseProjectDAL.Delete(m_BseProject.ProjectID);
            m_lstBseProject.Remove(m_BseProject);
            m_BseProject = null;
            if (m_lstBseProjectVersion != null)
            {
                m_lstBseProjectVersion.Clear();
                objListViewDetail.SetObjects(m_lstBseProjectVersion);
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

        #endregion 主表操作

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
                    BseProjectVersion model = EntityOperateManager.AddEntity<BseProjectVersion>(this.grpDetail);
                    model.ProjectID = m_BseProject.ProjectID;
                    int intReturn = m_BseProjectVersionDAL.Add(model);
                    if (intReturn > 0)
                    {
                        model.VersionID = intReturn;
                        m_lstBseProjectVersion.Add(model);
                        ListBseProjectVersion = m_lstBseProjectVersion;
                        objListViewDetail.SetObjects(m_lstBseProjectVersion);
                        objListViewDetail.Refresh();
                        objListViewDetail.SelectedIndex = m_lstBseProjectVersion.Count - 1;
                    }
                    break;

                case EntityOperationType.修改明细:
                    BseProjectVersion modelDetail = this.objListViewDetail.SelectedObjects[0] as BseProjectVersion;
                    EntityOperateManager.EditEntity(this.grpDetail, modelDetail);
                    bool blnReturn = m_BseProjectVersionDAL.Update(modelDetail);
                    if (blnReturn)
                    {
                        ListBseProjectVersion = m_lstBseProjectVersion;
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
            if (m_lstBseProjectVersion != null && this.objListViewDetail.SelectedObjects.Count > 0)
            {
                IList listObjects = this.objListViewDetail.SelectedObjects;
                string strIds = listObjects.Cast<BseProjectVersion>().Aggregate(string.Empty, (current, modelDetail) => current + modelDetail.VersionID + ",");
                strIds = strIds.TrimEnd(',');
                if (strIds.Length > 0)
                {
                    m_BseProjectVersionDAL.DeleteByCond("VersionID in(" + strIds + ")");
                    m_lstBseProjectVersion.RemoveAll(t => strIds.Split(',').Contains(t.VersionID.ToString()));
                    ListBseProjectVersion = m_lstBseProjectVersion;
                    objListViewDetail.SetObjects(m_lstBseProjectVersion);
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

        #endregion 明细表操作

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
                    return "版本名称不能为空";
                }

                if (txtDetailEditSort.Text.Trim() == string.Empty)
                {
                    txtDetailEditSort.Select();
                    return "排序不能为空";
                }
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

        #endregion 明细绑定方法

        #endregion 基本方法
    }
}