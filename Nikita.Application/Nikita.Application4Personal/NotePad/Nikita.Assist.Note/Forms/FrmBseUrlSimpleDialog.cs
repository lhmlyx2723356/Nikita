/// <summary>说明:FrmBseUrlSimpleDialog文件
/// 作者:卢华明
/// 创建时间:2016/6/19 11:46:20
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
using Nikita.Core;
using Nikita.Core.WinForm;
using Nikita.Base.IDAL;
using Nikita.Assist.Note.Model;

namespace Nikita.Assist.Note
{
    /// <summary>说明:FrmBseUrlSimpleDialog
    /// 作者:Luhm
    /// 最后修改人:
    /// 最后修改时间:
    /// 创建时间:2016/6/19 11:46:20
    /// </summary>
    public partial class FrmBseUrlSimpleDialog : Form
    {
        #region 常量、变量
        /// <summary>DataGridView下拉框绑定数据源
        /// 
        /// </summary>
        private DataSet m_dsGridSource;
        /// <summary>操作类
        /// 
        /// </summary>
        private IBseDAL<BseUrl> m_BseUrlDAL;
        /// <summary>索引号
        /// 
        /// </summary>
        private string m_strIndex;
        /// <summary>当前对象
        /// 
        /// </summary>
        private BseUrl m_BseUrl;
        /// <summary>当前对象集合
        /// 
        /// </summary>
        private List<BseUrl> m_lstBseUrl;
        /// <summary>返回对象集合
        /// 
        /// </summary>
        public List<BseUrl> ListBseUrl { get; private set; }
        #endregion

        #region 构造函数
        /// <summary>构造函数
        /// 
        /// </summary>
        /// <param name=model" BseUrl">对象</param>
        /// <param name="lstBseUrl">对象集合</param>
        public FrmBseUrlSimpleDialog(BseUrl modelBseUrl, List<BseUrl> lstBseUrl)
        {
            InitializeComponent();
            DoInitData();
            m_lstBseUrl = lstBseUrl ?? new List<BseUrl>(); 
            m_BseUrlDAL = GlobalHelp.GetResolve<IBseDAL<BseUrl>>();
            this.dataNavigator.Visible = false;
            if (modelBseUrl != null)
            {
                this.dataNavigator.Visible = true;
                m_BseUrl = modelBseUrl;
                this.dataNavigator.ListInfo = lstBseUrl.Select(t => t.Id.ToString()).ToList();
                m_strIndex = lstBseUrl.FindIndex(t => t.Id == m_BseUrl.Id).ToString();
                this.dataNavigator.CurrentIndex = int.Parse(m_strIndex);
            }
            cboEditType.SelectedIndex = 0;
            this.BringToFront();
            txtEditUrlTitle.Select();
            if (modelBseUrl == null)
            {
                string strClipboardTxt = Clipboard.GetText();
                if (strClipboardTxt != string.Empty)
                {
                    txtEditUrlContent.Text = strClipboardTxt;
                }
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
            if (m_BseUrl == null)
            {
                BseUrl model = EntityOperateManager.AddEntity<BseUrl>(this.tabPage);
                int intReturn = m_BseUrlDAL.Add(model);
                if (intReturn > 0)
                {
                    MessageBox.Show(@"添加成功");
                    model.Id = intReturn;
                    m_lstBseUrl.Add(model);
                    ListBseUrl = m_lstBseUrl;
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
                m_BseUrl = EntityOperateManager.EditEntity(this.tabPage, m_BseUrl);
                bool blnReturn = m_BseUrlDAL.Update(m_BseUrl);
                if (blnReturn)
                {
                    MessageBox.Show(@"修改成功");
                    ListBseUrl = m_lstBseUrl;
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
            m_BseUrl = m_lstBseUrl[this.dataNavigator.CurrentIndex];
            DisplayData(m_BseUrl);
        }
        #endregion

        #region 基本方法
        /// <summary>初始化绑定
        /// 
        /// </summary>
        private void DoInitData()
        {
            const string strBindSql = "select '学习记录' as Name  union all  select '其它记录' as Name ;SELECT 'cboEditType '";
            BindClass bindClass = new  BindClass()
            {
                SqlType = SqlType.SqlServer,
                BindSql = strBindSql
            };
            DataSet ds = BindSourceHelper.GetBindSourceDataSet(bindClass, GlobalHelp.Conn);
            ComboBoxHelper.BindComboBox(cboEditType, ds.Tables["cboEditType"], "Name", "Name");
        }
        /// <summary>实体对象值显示至控件
        /// 
        /// </summary>
        /// <param name="model">model</param>
        private void DisplayData(BseUrl model)
        {
            EntityOperateManager.BindAll(this.tabPage, model);
        }
        /// <summary>检查输入合法性
        /// 
        /// </summary>
        private string CheckInput()
        {
            if (cboEditType.Text.Trim() == string.Empty)
            {
                cboEditType.Select();
                return "类别不能为空";
            }

            if (txtEditUrlContent.Text.Trim() == string.Empty)
            {
                txtEditUrlContent.Select();
                return "网址内容不能为空";
            }

            return string.Empty;
        }
        #endregion
    }
}
