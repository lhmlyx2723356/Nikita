/// <summary>说明:FrmBseProjectSimpleDialog文件
/// 作者:卢华明
/// 创建时间:2016-05-28 17:29:10
/// </summary>
using System;
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
    /// <summary>说明:FrmBseProjectSimpleDialog
    /// 作者:Luhm
    /// 最后修改人:
    /// 最后修改时间:
    /// 创建时间:2016-05-28 17:29:10
    /// </summary>
    public partial class FrmBseProjectSimpleDialog : Form
    {
        #region 常量、变量
        /// <summary>DataGridView下拉框绑定数据源
        /// 
        /// </summary>
        private DataSet m_dsGridSource;
        /// <summary>操作类
        /// 
        /// </summary>
        private IBseDAL<BseProject> m_BseProjectDAL;
        /// <summary>索引号
        /// 
        /// </summary>
        private string m_strIndex;
        /// <summary>当前对象
        /// 
        /// </summary>
        private BseProject m_BseProject;
        /// <summary>当前对象集合
        /// 
        /// </summary>
        private List<BseProject> m_lstBseProject;
        /// <summary>返回对象集合
        /// 
        /// </summary>
        public List<BseProject> ListBseProject { get; private set; }
        #endregion

        #region 构造函数
        /// <summary>构造函数
        /// 
        /// </summary>
        /// <param name=model" BseProject">对象</param>
        /// <param name="lstBseProject">对象集合</param>
        public FrmBseProjectSimpleDialog(BseProject modelBseProject, List<BseProject> lstBseProject)
        {
            InitializeComponent();
            DoInitData();
            m_lstBseProject = lstBseProject ?? new List<BseProject>();
            m_BseProjectDAL = GlobalHelp.GetResolve<IBseDAL<BseProject>>();
            this.dataNavigator.Visible = false;
            if (modelBseProject != null)
            {
                this.dataNavigator.Visible = true;
                m_BseProject = modelBseProject;
                this.dataNavigator.ListInfo = lstBseProject.Select(t => t.ProjectID.ToString()).ToList();
                m_strIndex = lstBseProject.FindIndex(t => t.ProjectID == m_BseProject.ProjectID).ToString();
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
            if (m_BseProject == null)
            {
                string strNameValue = txtEditName.Text.Trim()
         ;
                if (m_BseProjectDAL.CalcCount("Name='" + strNameValue + "'") > 0)
                {
                    MessageBox.Show(@"项目名称已经存在");
                    return;
                }

                BseProject model = EntityOperateManager.AddEntity<BseProject>(this.tabPage);
                int intReturn = m_BseProjectDAL.Add(model);
                if (intReturn > 0)
                {
                    MessageBox.Show(@"添加成功");
                    model.ProjectID = intReturn;
                    m_lstBseProject.Add(model);
                    ListBseProject = m_lstBseProject;
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
                string strNameValue = txtEditName.Text.Trim()
         ;
                if (m_BseProjectDAL.CalcCount(" ProjectID !=" + m_BseProject.ProjectID + "   and  Name='" + strNameValue + "'") > 0)
                {
                    MessageBox.Show(@"项目名称已经存在");
                    return;
                }

                m_BseProject = EntityOperateManager.EditEntity(this.tabPage, m_BseProject);
                bool blnReturn = m_BseProjectDAL.Update(m_BseProject);
                if (blnReturn)
                {
                    MessageBox.Show(@"修改成功");
                    ListBseProject = m_lstBseProject;
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
            m_BseProject = m_lstBseProject[this.dataNavigator.CurrentIndex];
            DisplayData(m_BseProject);
        }
        #endregion

        #region 基本方法
        /// <summary>初始化绑定
        /// 
        /// </summary>
        private void DoInitData()
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
        /// <summary>实体对象值显示至控件
        /// 
        /// </summary>
        /// <param name="model">model</param>
        private void DisplayData(BseProject model)
        {
            EntityOperateManager.BindAll(this.tabPage, model);
        }
        /// <summary>检查输入合法性
        /// 
        /// </summary>
        private string CheckInput()
        {
            if (cboEditCategory.Text.Trim() == string.Empty)
            {
                cboEditCategory.Select();
                return "请选择项目类型";
            }

            if (cboEditOnLevel.Text.Trim() == string.Empty)
            {
                cboEditOnLevel.Select();
                return "请选择项目等级";
            }

            if (txtEditSort.Text.Trim() == string.Empty)
            {
                txtEditSort.Select();
                return "排序不能为空";
            }

            if (txtEditName.Text.Trim() == string.Empty)
            {
                txtEditName.Select();
                return "项目名称不能为空";
            }

            return string.Empty;
        }
        #endregion
    }
}
