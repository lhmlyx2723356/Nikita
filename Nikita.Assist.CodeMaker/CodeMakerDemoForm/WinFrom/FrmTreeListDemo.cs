using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.DataAccess4DBHelper;
using Nikita.WinForm.ExtendControl;
using Nikita.Assist.CodeMaker.CodeMakerDemoForm;
using Nikita.Assist.CodeMaker.DAL;
using Nikita.Assist.CodeMaker.Model;
using Nikita.Core;

namespace Nikita.Assist.CodeMaker
{
    public partial class FrmTreeListDemo : Form
    {
        #region 常量、变量
        /// <summary>数据库操作类
        /// 
        /// </summary>
        private readonly TreeListDemoDAL m_treeListDemoDal;
        /// <summary>绑定集合
        /// 
        /// </summary>
        private List<TreeListDemo> m_lstTreeListDemo;
        #endregion

        #region 构造函数
        /// <summary>构造函数
        /// 
        /// </summary>
        public FrmTreeListDemo()
        {
            InitializeComponent();
            m_treeListDemoDal = new TreeListDemoDAL();
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
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
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
                            DoDeleteOrCancel("删除 ");
                            break;
                        case "cmdCancel":
                            DoDeleteOrCancel("作废 ");
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
            List<TreeListDemo> lstListDemos = new List<TreeListDemo>();
            dataTreeListView.GetAllChildrensWithSelfByCollection(objList, ref lstListDemos);
            string strIds = lstListDemos.Aggregate(string.Empty, (current, item) => current + item.Id + ";");
            strIds = strIds.TrimEnd(',');
            var blnReturn = strOperation == "删除" ? m_treeListDemoDal.DeleteByCond("Id in (" + strIds + ")")
                : m_treeListDemoDal.Update("Status =0", "Id in (" + strIds + ")");
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
            TreeListDemo model = dataTreeListView.SelectedObjects[0] as TreeListDemo;
            if (model != null)
            {
                FrmTreeListDemoDialog frmDialog = new FrmTreeListDemoDialog(model, 0, m_lstTreeListDemo);
                if (frmDialog.ShowDialog() == DialogResult.OK)
                {
                    m_lstTreeListDemo = frmDialog.ListTreeListDemo;
                    dataTreeListView.DataSource = m_lstTreeListDemo;
                    dataTreeListView.Refresh();
                }
            }
        }

        /// <summary>新增同级/下级
        ///
        /// </summary>
        /// <param name="strOperation">操作类型</param>
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
            FrmTreeListDemoDialog frmDialog = new FrmTreeListDemoDialog(null, intParentId, m_lstTreeListDemo);
            if (frmDialog.ShowDialog() == DialogResult.OK)
            {
                m_lstTreeListDemo = frmDialog.ListTreeListDemo;
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
                strMsg = string.Format("请选择要{0}的列", strOperation);
            }
            return strMsg;
        }

        /// <summary>初始化绑定下拉框等
        ///
        /// </summary>
        private void DoInitData()
        {
            //const string strBindSql = "SELECT 2 AS  value , '管理员' AS  Name UNION ALL  SELECT 3 AS  value , '功城队' AS  NAME;SELECT 'cbkQueryRemark '";
            //BindSourceHelper.BindClass bindClass = new BindSourceHelper.BindClass()
            //{
            //    SqlType = SqlType.SqlServer,
            //    BindSql = strBindSql
            //};
            //DataSet ds = BindSourceHelper.GetBindSourceDataSet(bindClass);
            //CheckedComboBoxHelper.BindCheckedComboBox(cbkQueryRemark, ds.Tables["cbkQueryRemark"], "Name", "value"); 
        }

        /// <summary>查询
        /// 
        /// </summary>
        private void DoQueryData()
        {
            string strWhere = GetSearchSql();
            m_lstTreeListDemo = m_treeListDemoDal.GetListArray("*", "Id", "ASC", Pager.PageSize, Pager.PageIndex, strWhere);
            Pager.RecordCount = m_treeListDemoDal.CalcCount(strWhere);
            Pager.InitPageInfo();
            if (m_lstTreeListDemo != null && m_lstTreeListDemo.Count > 0)
            {
                this.dataTreeListView.DataSource = m_lstTreeListDemo;
            }
        }

        /// <summary>根据查询条件构造查询语句
        ///
        /// </summary>
        /// <returns>查询条件</returns>
        private string GetSearchSql()
        {
            SearchCondition condition = new SearchCondition();
            //condition.AddCondition("RoleName", this.txtQueryRoleName.Text, SqlOperator.Like);
            //condition.AddCondition("Sortnum", this.txtQuerySortnum.Text, SqlOperator.Like);
            //condition.AddCondition("Remark", this.cbkQueryRemark.CheckedItemValues.Trim(), SqlOperator.In);
            return condition.BuildConditionSql().Replace("Where", "");

        }

        #endregion 
    }
}
