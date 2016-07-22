/// <summary>说明:FrmCacheSettingSimpleDialog文件
/// 作者:卢华明
/// 创建时间:2016/6/30 21:55:58
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
using Nikita.Base.CacheStore.DAL;
using Nikita.Base.CacheStore.Model;
using Nikita.Base.IDAL;
using Nikita.Core.WinForm;

namespace Nikita.Base.CacheStore
{
    /// <summary>说明:FrmCacheSettingSimpleDialog
    /// 作者:Luhm
    /// 最后修改人:
    /// 最后修改时间:
    /// 创建时间:2016/6/30 21:55:58
    /// </summary>
    public partial class FrmCacheSettingSimpleDialog : Form
    {
        #region 常量、变量
  /// <summary>DataGridView下拉框绑定数据源
        /// 
        /// </summary>
        private DataSet m_dsGridSource;
        /// <summary>操作类
        /// 
        /// </summary>
        private IBseDAL<CacheSetting> m_CacheSettingDAL; 
        /// <summary>索引号
        /// 
        /// </summary>
        private string m_strIndex;
        /// <summary>当前对象
        /// 
        /// </summary>
        private CacheSetting  m_CacheSetting;
        /// <summary>当前对象集合
        /// 
        /// </summary>
        private List<CacheSetting>  m_lstCacheSetting ;
        /// <summary>返回对象集合
        /// 
        /// </summary>
        public List<CacheSetting> ListCacheSetting  { get; private set; }
        #endregion
          
        #region 构造函数
        /// <summary>构造函数
        /// 
        /// </summary>
        /// <param name=model" CacheSetting">对象</param>
        /// <param name="lstCacheSetting">对象集合</param>
        public FrmCacheSettingSimpleDialog (CacheSetting  modelCacheSetting, List<CacheSetting>   lstCacheSetting)
        {
            InitializeComponent();
            DoInitData();
             m_lstCacheSetting  =     lstCacheSetting?? new List<CacheSetting>() ;
 m_CacheSettingDAL = GlobalHelp.GetResolve<IBseDAL<CacheSetting>>();
            this.dataNavigator.Visible = false;
            if (  modelCacheSetting != null)
            {
                this.dataNavigator.Visible = true;
                m_CacheSetting =   modelCacheSetting;
                this.dataNavigator.ListInfo =  lstCacheSetting.Select(t => t.Id.ToString()).ToList();
                m_strIndex =  lstCacheSetting.FindIndex(t => t.Id ==    m_CacheSetting.Id).ToString();
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
            if (m_CacheSetting == null)
            {
       string strSetKeyValueNew =    txtEditSetKey.Text.Trim()  ; 
                if (m_CacheSettingDAL.CalcCount("SetKey='" + strSetKeyValueNew + "'") > 0)
                {
                    MessageBox.Show(@"设置键已经存在");
                    return;
                }

               CacheSetting model  = EntityOperateManager.AddEntity<  CacheSetting>(this.tabPage);
                int intReturn = m_CacheSettingDAL.Add(model);
                if (intReturn > 0)
                {
                    MessageBox.Show(@"添加成功");
                    model.Id = intReturn;
                     m_lstCacheSetting .Add(model);
                    ListCacheSetting  =    m_lstCacheSetting ;
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
       string strSetKeyValueEdit =    txtEditSetKey.Text.Trim()  ; 
                if (m_CacheSettingDAL.CalcCount(" Id !=" + m_CacheSetting.Id+ "   and  SetKey='" + strSetKeyValueEdit + "'") > 0)
                {
                    MessageBox.Show(@"设置键已经存在");
                    return;
                }

                 m_CacheSetting = EntityOperateManager.EditEntity(this.tabPage, m_CacheSetting);
                bool blnReturn = m_CacheSettingDAL.Update( m_CacheSetting);
                if (blnReturn)
                {
                    MessageBox.Show(@"修改成功");
                    ListCacheSetting  =  m_lstCacheSetting ;
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
            m_CacheSetting =  m_lstCacheSetting [this.dataNavigator.CurrentIndex];
            DisplayData(  m_CacheSetting);
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
        private void DisplayData(CacheSetting  model)
        {
            EntityOperateManager.BindAll(this.tabPage, model);
        }
        /// <summary>检查输入合法性
        /// 
        /// </summary>
        private string CheckInput()
        {
  if ( txtEditSetKey.Text.Trim() == string.Empty)
            {
         txtEditSetKey.Select();
                return "设置键不能为空";
            }

  if ( txtEditSetText.Text.Trim() == string.Empty)
            {
         txtEditSetText.Select();
                return "显示值不能为空";
            }

            return string.Empty;
        }
        #endregion
    }
}
