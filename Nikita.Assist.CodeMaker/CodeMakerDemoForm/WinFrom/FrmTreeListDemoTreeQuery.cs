/// <summary>说明:FrmTreeListDemoTreeQuery文件
/// 作者:卢华明
/// 创建时间:2016-05-09 20:15:03
/// </summary>
using Nikita.Assist.CodeMaker.DAL;
using Nikita.Assist.CodeMaker.Model;
using Nikita.Core;
using Nikita.WinForm.ExtendControl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.Assist.CodeMaker.CodeMakerDemoForm;
namespace Nikita.Assist.CodeMaker
{
    /// <summary>说明:FrmTreeListDemoTreeQuery
    /// 作者:Luhm
    /// 最后修改人:
    /// 最后修改时间:
    /// 创建时间:2016-05-09 20:15:03
    /// </summary>
    public partial class FrmTreeListDemoTreeQuery : Form
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
        /// <summary>绑定集合
        /// 
        /// </summary>
        private List<TreeListDemo>  m_lstTreeListDemo  ;
        #endregion
          
        #region 构造函数
        /// <summary>构造函数
        ///
        /// </summary>
        public FrmTreeListDemoTreeQuery()
        {
            InitializeComponent();
            m_TreeListDemoDAL= new  TreeListDemoDAL();
            this.dataTreeListView.RootKeyValue = 0u;
            DoInitData();
        }
        #endregion
          
        #region 基础事件
        /// <summary>查询
        ///
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
       try
            {
                btnQuery.Enabled = false;
                DoQueryData();
            }
            finally
            {
                btnQuery.Enabled = true;
            }
        }
        /// <summary>通用查询
        /// 
        /// </summary>
        /// <param name="sender=">sender</param>
        /// <param name=="e=">e</param>
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            this.dataTreeListView.TimedFilter(txtFilter.Text);
        }
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
                try
                {
                    cmdItem.Enabled = false;
                    switch (cmdItem.Name.Trim())
                    {
                        case "cmdRefresh":
                            DoQueryData();
                            break;
                        case "cmdNewSameLevel":
                        case "cmdNewNextLevel":
                            DoNew(cmdItem.Name.Trim());
                            break;
                        case "cmdEdit":
                            DoEdit();
                            break;
                        case "cmdDelete":
                            DoDeleteOrCancel("删除");
                            break;
                        case "cmdCancel":
                            DoDeleteOrCancel("作废");
                            break;
                    }
                }
                finally
                {
                    cmdItem.Enabled = true;
                }
            }
        } 
        
        /// <summary>分页事件
        ///
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void Pager_PageChanged(object sender, EventArgs e)
        {
            DoQueryData();
        }
        /// <summary>双击修改
        /// 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void dataTreeListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            Command_Click(cmdEdit, null);
        }
        #endregion
          
        #region 基础方法
        /// <summary>初始化绑定下拉框等
        ///
        /// </summary>
        private void DoInitData()
        { 
        }
        /// <summary>执行查询
        ///
        /// </summary>
        private void DoQueryData()
        {
    try
            {
                btnQuery.Enabled = false;
            string strWhere = GetSearchSql();
        m_lstTreeListDemo =   m_TreeListDemoDAL.GetListArray("*", "Id", "ASC", Pager.PageSize, Pager.PageIndex, strWhere);
            Pager.RecordCount = m_TreeListDemoDAL.CalcCount(strWhere);
            Pager.InitPageInfo();
            dataTreeListView.DataSource =    m_lstTreeListDemo;
            }
       catch (Exception)
            {
                throw;
            }
            finally
            { 
                btnQuery.Enabled = true;
            }
        }
        /// <summary>根据查询条件构造查询语句
        ///
        /// </summary>
        /// <returns>查询条件</returns>
        private string GetSearchSql()
        {
            SearchCondition condition = new SearchCondition();
condition.AddCondition("Name", this.txtQueryName.Text, SqlOperator.Like);
            return condition.BuildConditionSql().Replace("Where", "");

        }
        /// <summary>删除/作废
        /// 
        /// </summary>
        /// <param name="strOperation">操作类型</param>
        private void DoDeleteOrCancel(string strOperation)
        {
            string strMsg = CheckSelect(strOperation);
            if (strMsg != string.Empty)
            {
                MessageBox.Show(strMsg);
                return;
            }
     if (MessageBox.Show(string.Format("选中的对象如果存在下级，也会一起{0}，是否继续操作？", strOperation), @"提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            IList objList = this.dataTreeListView.SelectedObjects;
            List<TreeListDemo> lstModels = new List<TreeListDemo>();
            dataTreeListView.GetAllChildrensWithSelfByCollection(objList, ref lstModels);
            string strIds = lstModels.Aggregate(string.Empty, (current, item) => current + item.Id + ";");
            strIds = strIds.TrimEnd(',');
            var blnReturn = strOperation == "删除" ?   m_TreeListDemoDAL.DeleteByCond(" Id in (" + strIds + ")") :    m_TreeListDemoDAL.Update("Status =0", " Id in (" + strIds + ")");
            if (blnReturn)
            {
                MessageBox.Show(string.Format("{0}成功", strOperation)); 
               dataTreeListView.RemoveObjects(objList);
            }
            else
            {
                MessageBox.Show(string.Format("{0}失败", strOperation));
            }
        }
        /// <summary>编辑
        ///
        /// </summary>
        private void DoEdit()
        {
            string strMsg = CheckSelect("修改");
            if (strMsg != string.Empty)
            {
                MessageBox.Show(strMsg);
                return;
            }
    TreeListDemo model = dataTreeListView.SelectedObjects[0] as  TreeListDemo;
            if (model != null)
            {
                FrmTreeListDemoTreeDialog frmDialog = new       FrmTreeListDemoTreeDialog(model, 0,  m_lstTreeListDemo);
                if (frmDialog.ShowDialog() == DialogResult.OK)
                {
                       m_lstTreeListDemo = frmDialog.ListTreeListDemo ;
                    dataTreeListView.DataSource =   m_lstTreeListDemo;
                    dataTreeListView.Refresh();
                }
            }
        }
        /// <summary>新增
        ///
        /// </summary>
        private void DoNew(string strOperation)
        {
    string strMsg = CheckSelect("新增等级");
            if (strMsg != string.Empty)
            {
                MessageBox.Show(strMsg);
                return;
            }
            int intParentId = -1;
             TreeListDemo model = dataTreeListView.SelectedObjects[0] as TreeListDemo;
            if (model != null)
            {
                intParentId = strOperation == "cmdNewSameLevel" ? model.ParentId : model.Id;
            }
              FrmTreeListDemoTreeDialog frmDialog = new   FrmTreeListDemoTreeDialog(null,intParentId,m_lstTreeListDemo);
            if (frmDialog.ShowDialog() == DialogResult.OK)
            {
                m_lstTreeListDemo = frmDialog.ListTreeListDemo ;
                dataTreeListView.DataSource = m_lstTreeListDemo;
                dataTreeListView.Refresh();
            }
        }
         
        /// <summary>检查选择
        /// 
        /// </summary>
        /// <param name="strOperation">操作说明</param>
        /// <returns>返回提示信息</returns>
        private string CheckSelect(string strOperation)
        {
            string strMsg = string.Empty;
        if (dataTreeListView.SelectedObjects.Count == 0)
            {
                strMsg = string.Format("请选择要{0}的行数据", strOperation);
            }
            return strMsg;
        }
        #endregion
    }
}
