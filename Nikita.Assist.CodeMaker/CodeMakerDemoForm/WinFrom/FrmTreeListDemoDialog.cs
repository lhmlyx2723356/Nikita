/// <summary>说明:FrmTreeListDemoSimpleDialog文件
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
using Nikita.Core.Literacy;
using Nikita.Core.WinForm;
using Nikita.Assist.CodeMaker.DAL;
using Nikita.Assist.CodeMaker.Model;
namespace Nikita.Assist.CodeMaker
{
    /// <summary>说明:FrmTreeListDemoSimpleDialog
    /// 作者:Luhm
    /// 最后修改人:
    /// 最后修改时间:
    /// 创建时间:2016-04-30 23:24:43
    /// </summary>
    public partial class FrmTreeListDemoDialog : Form
    {
        #region 常量、变量
        /// <summary>DataGridView下拉框绑定数据源
        /// 
        /// </summary>
        private DataSet m_dsGridSource;
        /// <summary>操作类
        /// 
        /// </summary>
        private TreeListDemoDAL m_TreeListDemoDAL;
        /// <summary>索引号
        /// 
        /// </summary>
        private string m_strIndex;
        /// <summary>当前对象
        /// 
        /// </summary>
        private TreeListDemo m_TreeListDemo;
        /// <summary>当前对象集合
        /// 
        /// </summary>
        private List<TreeListDemo> m_lstTreeListDemo;
        /// <summary>对象操作类
        /// 
        /// </summary>
        private TreeListDemoDAL m_sysRolesDAL;
        /// <summary>返回对象集合
        /// 
        /// </summary>
        public List<TreeListDemo> ListTreeListDemo { get; private set; }
        /// <summary>父级ID
        /// 
        /// </summary>
        private int m_intParentId;
        #endregion

        #region 构造函数

        /// <summary>构造函数
        /// 
        /// </summary> 
        /// <param name="model">对象</param>
        /// <param name="intParentId">父级ID</param>
        /// <param name="lstTreeListDemo">对象集合</param>
        public FrmTreeListDemoDialog(TreeListDemo model, int intParentId, List<TreeListDemo> lstTreeListDemo)
        {
            InitializeComponent();
            DoInitData();
            m_lstTreeListDemo = lstTreeListDemo;
            m_intParentId = intParentId;
            m_TreeListDemoDAL = new TreeListDemoDAL();
            this.dataNavigator.Visible = false;
            if (model != null)
            {
                this.dataNavigator.Visible = true;
                m_TreeListDemo = model;
                this.dataNavigator.ListInfo = lstTreeListDemo.Select(t => t.Id.ToString()).ToList();
                m_strIndex = lstTreeListDemo.FindIndex(t => t.Id == m_TreeListDemo.Id).ToString();
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
            if (m_TreeListDemo == null)
            {
                TreeListDemo model = EntityOperateManager.AddEntity<TreeListDemo>(this.tabPage);
                model.ParentId = m_intParentId;
                int intReturn = m_TreeListDemoDAL.Add(model);
                if (intReturn > 0)
                {
                    MessageBox.Show(@"添加成功");
                    model.Id = intReturn;
                    m_lstTreeListDemo.Add(model);
                    ListTreeListDemo = m_lstTreeListDemo;
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
                m_TreeListDemo = EntityOperateManager.EditEntity(this.tabPage, m_TreeListDemo);
                bool blnReturn = m_TreeListDemoDAL.Update(m_TreeListDemo);
                if (blnReturn)
                {
                    MessageBox.Show(@"修改成功");
                    ListTreeListDemo = m_lstTreeListDemo;
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
            m_TreeListDemo = m_lstTreeListDemo[this.dataNavigator.CurrentIndex];
            DisplayData(m_TreeListDemo);
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
        private void DisplayData(TreeListDemo model)
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
