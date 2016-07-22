/// <summary>说明:FrmCacheTablesSimpleDialog文件
/// 作者:卢华明
/// 创建时间:2016/6/26 9:32:33
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
    /// <summary>说明:FrmCacheTablesSimpleDialog
    /// 作者:Luhm
    /// 最后修改人:
    /// 最后修改时间:
    /// 创建时间:2016/6/26 9:32:33
    /// </summary>
    public partial class FrmCacheTablesSimpleDialog : Form
    {
        #region 常量、变量
  /// <summary>DataGridView下拉框绑定数据源
        /// 
        /// </summary>
        private DataSet m_dsGridSource;
        /// <summary>操作类
        /// 
        /// </summary>
        private IBseDAL<CacheTables> m_CacheTablesDAL; 
        /// <summary>索引号
        /// 
        /// </summary>
        private string m_strIndex;
        /// <summary>当前对象
        /// 
        /// </summary>
        private CacheTables  m_CacheTables;
        /// <summary>当前对象集合
        /// 
        /// </summary>
        private List<CacheTables>  m_lstCacheTables ;
        /// <summary>返回对象集合
        /// 
        /// </summary>
        public List<CacheTables> ListCacheTables  { get; private set; }
        #endregion
          
        #region 构造函数
        /// <summary>构造函数
        /// 
        /// </summary>
        /// <param name=model" CacheTables">对象</param>
        /// <param name="lstCacheTables">对象集合</param>
        public FrmCacheTablesSimpleDialog (CacheTables  modelCacheTables, List<CacheTables>   lstCacheTables)
        {
            InitializeComponent();
            DoInitData();
             m_lstCacheTables  =     lstCacheTables?? new List<CacheTables>() ;
 m_CacheTablesDAL = GlobalHelp.GetResolve<IBseDAL<CacheTables>>();
            this.dataNavigator.Visible = false;
            if (  modelCacheTables != null)
            {
                this.dataNavigator.Visible = true;
                m_CacheTables =   modelCacheTables;
                this.dataNavigator.ListInfo =  lstCacheTables.Select(t => t.Id.ToString()).ToList();
                m_strIndex =  lstCacheTables.FindIndex(t => t.Id ==    m_CacheTables.Id).ToString();
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
            if (m_CacheTables == null)
            {
       string strTableNameValueNew =    txtEditTableName.Text.Trim()  ; 
                if (m_CacheTablesDAL.CalcCount("TableName='" + strTableNameValueNew + "'") > 0)
                {
                    MessageBox.Show(@"表名已经存在");
                    return;
                }

               CacheTables model  = EntityOperateManager.AddEntity<  CacheTables>(this.tabPage);
                int intReturn = m_CacheTablesDAL.Add(model);
                if (intReturn > 0)
                {
                    MessageBox.Show(@"添加成功");
                    model.Id = intReturn;
                     m_lstCacheTables .Add(model);
                    ListCacheTables  =    m_lstCacheTables ;
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
       string strTableNameValueEdit =    txtEditTableName.Text.Trim()  ; 
                if (m_CacheTablesDAL.CalcCount(" Id !=" + m_CacheTables.Id+ "   and  TableName='" + strTableNameValueEdit + "'") > 0)
                {
                    MessageBox.Show(@"表名已经存在");
                    return;
                }

                 m_CacheTables = EntityOperateManager.EditEntity(this.tabPage, m_CacheTables);
                bool blnReturn = m_CacheTablesDAL.Update( m_CacheTables);
                if (blnReturn)
                {
                    MessageBox.Show(@"修改成功");
                    ListCacheTables  =  m_lstCacheTables ;
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
            m_CacheTables =  m_lstCacheTables [this.dataNavigator.CurrentIndex];
            DisplayData(  m_CacheTables);
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
        private void DisplayData(CacheTables  model)
        {
            EntityOperateManager.BindAll(this.tabPage, model);
        }
        /// <summary>检查输入合法性
        /// 
        /// </summary>
        private string CheckInput()
        {
  if ( txtEditTableName.Text.Trim() == string.Empty)
            {
         txtEditTableName.Select();
                return "表名不能为空";
            }

            return string.Empty;
        }
        #endregion
    }
}
