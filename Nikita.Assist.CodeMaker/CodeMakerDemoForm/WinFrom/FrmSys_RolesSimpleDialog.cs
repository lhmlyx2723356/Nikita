/// <summary>说明:FrmSys_RolesSimpleDialog文件
/// 作者:卢华明
/// 创建时间:2016-04-30 23:24:43
/// </summary>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.Base.Literacy;
using Nikita.Core;
using Nikita.Assist.CodeMaker.DAL;
using Nikita.Assist.CodeMaker.Model;
namespace Nikita.Assist.CodeMaker
{
    /// <summary>说明:FrmSys_RolesSimpleDialog
    /// 作者:Luhm
    /// 最后修改人:
    /// 最后修改时间:
    /// 创建时间:2016-04-30 23:24:43
    /// </summary>
    public partial class FrmSys_RolesSimpleDialog : Form
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
        /// <summary>索引号
        /// 
        /// </summary>
        private string m_strIndex;
        /// <summary>当前对象
        /// 
        /// </summary>
        private Sys_Roles m_Sys_Roles;
        /// <summary>当前对象集合
        /// 
        /// </summary>
        private List<Sys_Roles> m_lstSys_Roles;
        /// <summary>对象操作类
        /// 
        /// </summary>
        private Sys_RolesDAL m_sysRolesDAL;
        /// <summary>返回对象集合
        /// 
        /// </summary>
        public List<Sys_Roles> ListSys_Roles { get; private set; }
        #endregion

        #region 构造函数
        /// <summary>构造函数
        /// 
        /// </summary>
        /// <param name=model" Sys_Roles">对象</param>
        /// <param name="lstSys_Roles">对象集合</param>
        public FrmSys_RolesSimpleDialog(Sys_Roles modelSys_Roles, List<Sys_Roles> lstSys_Roles)
        {
            InitializeComponent();
            DoInitData();
            m_lstSys_Roles = lstSys_Roles;
            m_Sys_RolesDAL = new Sys_RolesDAL();
            this.dataNavigator.Visible = false;
            if (modelSys_Roles != null)
            {
                this.dataNavigator.Visible = true;
                m_Sys_Roles = modelSys_Roles;
                this.dataNavigator.ListInfo = lstSys_Roles.Select(t => t.KeyId.ToString()).ToList();
                m_strIndex = lstSys_Roles.FindIndex(t => t.KeyId == m_Sys_Roles.KeyId).ToString();
                this.dataNavigator.CurrentIndex = int.Parse(m_strIndex);
            }
        }
        #endregion

        #region 基础事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strReturnMsg = CheckInput();
            if (strReturnMsg != string.Empty)
            {
                MessageBox.Show(strReturnMsg);
                return;
            }
            //新增
            if (m_Sys_Roles == null)
            {
                Sys_Roles model = EntityOperateManager.AddEntity<Sys_Roles>(this.tabPage);
                int intReturn = m_Sys_RolesDAL.Add(model);
                if (intReturn > 0)
                {
                    MessageBox.Show(@"添加成功");
                    model.KeyId = intReturn;
                    m_lstSys_Roles.Add(model);
                    ListSys_Roles = m_lstSys_Roles;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(@"添加失败");
                }
            }
            //修改
            else
            {
                m_Sys_Roles = EntityOperateManager.EditEntity(this.tabPage, m_Sys_Roles);
                bool blnReturn = m_Sys_RolesDAL.Update(m_Sys_Roles);
                if (blnReturn)
                {
                    MessageBox.Show(@"修改成功");
                    ListSys_Roles = m_lstSys_Roles;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(@"修改失败");
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ControlManager.ClearAll(this.tabPage);
        }
        private void dataNavigator_PositionChanged(object sender, EventArgs e)
        {
            if (dataNavigator.ListInfo == null)
            {
                return;
            }
            m_Sys_Roles = m_lstSys_Roles[this.dataNavigator.CurrentIndex];
            DisplayData(m_Sys_Roles);
        }
        #endregion

        #region 基本方法
        /// <summary>初始化绑定
        /// 
        /// </summary>
        private void DoInitData()
        {
        }
        /// <summary>实体对象值显示至控件
        /// 
        /// </summary>
        /// <param name="model">model</param>
        private void DisplayData(Sys_Roles model)
        {
            EntityOperateManager.BindAll(this.tabPage, model);
        }
        /// <summary>检查输入合法性
        /// 
        /// </summary>
        private string CheckInput()
        {
            if (txtEditRoleName.Text.Trim() == string.Empty)
            {
                txtEditRoleName.Select();
                return "角色不能为空";
            }

            if (numEditSortnum.Text.Trim() == string.Empty)
            {
                numEditSortnum.Select();
                return "请输入排序";
            }

            if (txtEditRemark.Text.Trim() == string.Empty)
            {
                txtEditRemark.Select();
                return "备注不能为空";
            }

            return string.Empty;
        }
        #endregion
    }
}
