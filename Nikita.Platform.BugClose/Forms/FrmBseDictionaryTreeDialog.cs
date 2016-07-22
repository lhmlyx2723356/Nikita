/// <summary>说明:FrmBseDictionaryTreeDialog文件
/// 作者:卢华明
/// 创建时间:2016-05-22 23:28:06
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
using Nikita.Core.WinForm; 
using Nikita.Platform.BugClose.Model;
using Nikita.Base.IDAL;
namespace Nikita.Platform.BugClose
{
    /// <summary>说明:FrmBseDictionaryTreeDialog
    /// 作者:Luhm
    /// 最后修改人:
    /// 最后修改时间:
    /// 创建时间:2016-05-22 23:28:06
    /// </summary>
    public partial class FrmBseDictionaryTreeDialog : Form
    {
        #region 常量、变量
        /// <summary>DataGridView下拉框绑定数据源
        /// 
        /// </summary>
        private DataSet m_dsGridSource;
        /// <summary>操作类
        /// 
        /// </summary>
        private IBseDAL<BseDictionary> m_BseDictionaryDAL;
        /// <summary>索引号
        /// 
        /// </summary>
        private string m_strIndex;
        /// <summary>当前对象
        /// 
        /// </summary>
        private BseDictionary m_BseDictionary;
        /// <summary>当前对象集合
        /// 
        /// </summary>
        private List<BseDictionary> m_lstBseDictionary;
        /// <summary>返回对象集合
        /// 
        /// </summary>
        public List<BseDictionary> ListBseDictionary { get; private set; }
        /// <summary>父级ID
        /// 
        /// </summary>
        private int m_intParentId;
        #endregion

        #region 构造函数
        /// <summary>构造函数
        /// 
        /// </summary>
        /// <param name=model" BseDictionary">对象</param>
        /// <param name="lstBseDictionary">对象集合</param>
        public FrmBseDictionaryTreeDialog(BseDictionary model, int intParentId, List<BseDictionary> lstBseDictionary)
        {
            InitializeComponent();
            DoInitData();
            m_lstBseDictionary = lstBseDictionary;
            m_intParentId = intParentId;
            m_BseDictionaryDAL = GlobalHelp.GetResolve<IBseDAL<BseDictionary>>();
            this.dataNavigator.Visible = false;
            if (model != null)
            {
                this.dataNavigator.Visible = true;
                m_BseDictionary = model;
                this.dataNavigator.ListInfo = lstBseDictionary.Select(t => t.Id.ToString()).ToList();
                m_strIndex = lstBseDictionary.FindIndex(t => t.Id == m_BseDictionary.Id).ToString();
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
            if (m_BseDictionary == null)
            {
                BseDictionary model = EntityOperateManager.AddEntity<BseDictionary>(this.tabPage);
                model.ParentID = m_intParentId;
                int intReturn = m_BseDictionaryDAL.Add(model);
                if (intReturn > 0)
                {
                    MessageBox.Show(@"添加成功");
                    model.Id = intReturn;
                    m_lstBseDictionary.Add(model);
                    ListBseDictionary = m_lstBseDictionary;
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
                m_BseDictionary = EntityOperateManager.EditEntity(this.tabPage, m_BseDictionary);
                bool blnReturn = m_BseDictionaryDAL.Update(m_BseDictionary);
                if (blnReturn)
                {
                    MessageBox.Show(@"修改成功");
                    ListBseDictionary = m_lstBseDictionary;
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
            m_BseDictionary = m_lstBseDictionary[this.dataNavigator.CurrentIndex];
            DisplayData(m_BseDictionary);
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
        private void DisplayData(BseDictionary model)
        {
            EntityOperateManager.BindAll(this.tabPage, model);
        }
        /// <summary>检查输入合法性
        /// 
        /// </summary>
        private string CheckInput()
        {
            return string.Empty;
        }
        #endregion
    }
}
