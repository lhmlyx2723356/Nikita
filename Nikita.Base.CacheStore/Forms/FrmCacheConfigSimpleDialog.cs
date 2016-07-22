/// <summary>说明:FrmCacheConfigSimpleDialog文件
/// 作者:卢华明
/// 创建时间:2016/6/26 10:00:35
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
using Nikita.Core.WinForm;
using Nikita.Base.CacheStore.DAL;
using Nikita.Base.CacheStore.Model;
using Nikita.Base.IDAL;
namespace Nikita.Base.CacheStore
{
    /// <summary>说明:FrmCacheConfigSimpleDialog
    /// 作者:Luhm
    /// 最后修改人:
    /// 最后修改时间:
    /// 创建时间:2016/6/26 10:00:35
    /// </summary>
    public partial class FrmCacheConfigSimpleDialog : Form
    {
        #region 常量、变量
        /// <summary>DataGridView下拉框绑定数据源
        /// 
        /// </summary>
        private DataSet m_dsGridSource;
        /// <summary>操作类
        /// 
        /// </summary>
        private IBseDAL<CacheConfig> m_CacheConfigDAL;
        /// <summary>索引号
        /// 
        /// </summary>
        private string m_strIndex;
        /// <summary>当前对象
        /// 
        /// </summary>
        private CacheConfig m_CacheConfig;
        /// <summary>当前对象集合
        /// 
        /// </summary>
        private List<CacheConfig> m_lstCacheConfig;
        /// <summary>返回对象集合
        /// 
        /// </summary>
        public List<CacheConfig> ListCacheConfig { get; private set; }
        #endregion

        #region 构造函数
        /// <summary>构造函数
        /// 
        /// </summary>
        /// <param name=model" CacheConfig">对象</param>
        /// <param name="lstCacheConfig">对象集合</param>
        public FrmCacheConfigSimpleDialog(CacheConfig modelCacheConfig, List<CacheConfig> lstCacheConfig)
        {
            InitializeComponent();
            DoInitData();
            m_lstCacheConfig = lstCacheConfig ?? new List<CacheConfig>();
            m_CacheConfigDAL = GlobalHelp.GetResolve<IBseDAL<CacheConfig>>();
            this.dataNavigator.Visible = false;
            txtEditCacheTableName.Enabled = false;
            if (modelCacheConfig != null)
            {
                this.dataNavigator.Visible = true;
                m_CacheConfig = modelCacheConfig;
                this.dataNavigator.ListInfo = lstCacheConfig.Select(t => t.Id.ToString()).ToList();
                m_strIndex = lstCacheConfig.FindIndex(t => t.Id == m_CacheConfig.Id).ToString();
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
            if (m_CacheConfig == null)
            {
                string strTableNameValueNew = cboEditTableName.SelectedValue.ToString().Trim();
                if (m_CacheConfigDAL.CalcCount("TableName='" + strTableNameValueNew + "'") > 0)
                {
                    MessageBox.Show(@"表名已经存在");
                    return;
                }

                CacheConfig model = EntityOperateManager.AddEntity<CacheConfig>(this.tabPage);
                model.CacheChekGuid = Guid.NewGuid().ToString();
                model.CacheTableName = Guid.NewGuid().ToString();
                int intReturn = m_CacheConfigDAL.Add(model);
                if (intReturn > 0)
                {
                    MessageBox.Show(@"添加成功");
                    model.Id = intReturn;
                    m_lstCacheConfig.Add(model);
                    ListCacheConfig = m_lstCacheConfig;
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
                string strTableNameValueEdit = cboEditTableName.SelectedValue.ToString().Trim();
                if (m_CacheConfigDAL.CalcCount(" Id !=" + m_CacheConfig.Id + "   and  TableName='" + strTableNameValueEdit + "'") > 0)
                {
                    MessageBox.Show(@"表名已经存在");
                    return;
                }

                m_CacheConfig = EntityOperateManager.EditEntity(this.tabPage, m_CacheConfig);
                bool blnReturn = m_CacheConfigDAL.Update(m_CacheConfig);
                if (blnReturn)
                {
                    MessageBox.Show(@"修改成功");
                    ListCacheConfig = m_lstCacheConfig;
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
            m_CacheConfig = m_lstCacheConfig[this.dataNavigator.CurrentIndex];
            DisplayData(m_CacheConfig);
        }
        #endregion

        #region 基本方法
        /// <summary>初始化绑定
        /// 
        /// </summary>
        private void DoInitData()
        {
            const string strBindEditSql = "select TableName From CacheTables;SELECT 'cboEditTableName '";
            BindClass bindClass = new BindClass()
            {
                SqlType = SqlType.SqlServer,
                BindSql = strBindEditSql
            };
            DataSet ds = BindSourceHelper.GetBindSourceDataSet(bindClass, GlobalHelp.Conn);
            ComboBoxHelper.BindComboBox(cboEditTableName, ds.Tables["cboEditTableName"], "TableName", "TableName");

        }
        /// <summary>实体对象值显示至控件
        /// 
        /// </summary>
        /// <param name="model">model</param>
        private void DisplayData(CacheConfig model)
        {
            EntityOperateManager.BindAll(this.tabPage, model);
        }
        /// <summary>检查输入合法性
        /// 
        /// </summary>
        private string CheckInput()
        {
            if (cboEditTableName.Text.Trim() == string.Empty)
            {
                cboEditTableName.Select();
                return "请选择表名";
            }

            //if (txtEditCacheTableName.Text.Trim() == string.Empty)
            //{
            //    txtEditCacheTableName.Select();
            //    return "本地缓存表名不能为空";
            //}


            return string.Empty;
        }
        #endregion
    }
}
