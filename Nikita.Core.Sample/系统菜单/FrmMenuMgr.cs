using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Nikita.Core.Sample.DAL;
using Nikita.Core;
using Nikita.WinForm.ExtendControl;

namespace Nikita.Core.Sample
{
    public partial class FrmMenuMgr : DockContentEx
    {
        public FrmMenuMgr()
        {
            InitializeComponent();
        }

        readonly T_Sample_MenuDAL _dal = new T_Sample_MenuDAL();
        private void FrmMenuMgr_Load(object sender, EventArgs e)
        { 
            DataTable dt = _dal.GetList(string.Empty).Tables[0];
           TreeViewHelper.BindTreeView(tvwMenu, dt, "ParentId", "id", "MenuClass", "MenuName");
        } 

        private void BtnClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
                switch (item.Name)
                {
                    case "btnAdd":
                    case "btnAddNext":
                        DoAdd(item.Name);
                        break;
                    case "btnDelete":
                        DoDelete();
                        break;
                    case "btnEdit":
                        DoEdit("btnEdit");
                        break;
                    case "btnRefresh":
                        DoRefresh();
                        break;
                }
        }

        private void DoEdit(string btnName)
        {
            if (tvwMenu.SelectedNode == null)
            {
                MessageBox.Show("请选择要修改的一个节点");
                return;
            } 
            TreeNode node = tvwMenu.SelectedNode;
            FrmMenuMgrEdit frmEdit = new FrmMenuMgrEdit(node, btnName);
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                //不考虑太多直接刷新
                DoRefresh();
            }
        }

        private void DoRefresh()
        {
            FrmMenuMgr_Load(null, null);
        }

        private void DoDelete()
        {
            List<TreeNode> lstCheckTreeNodes =TreeViewHelper.GetAllCheckNodes(tvwMenu);
            if (lstCheckTreeNodes.Count == 0)
            {
                MessageBox.Show("请选择要删除的数据");
                return;
            }
            string strIds = lstCheckTreeNodes.Select(node => node.Tag).OfType<DataRow>().Aggregate(string.Empty, (current, dataRow) => current + (dataRow["id"] + ","));
            bool flag = _dal.DeleteByCond("id in(" + strIds.TrimEnd(',') + ")");
            if (flag)
            {
                MessageBox.Show("删除成功");
                foreach (TreeNode node in lstCheckTreeNodes)
                {
                    tvwMenu.Nodes.Remove(node);
                }
            }
        }


        private void DoAdd(string btnName)
        {
            if (tvwMenu.SelectedNode == null)
            {
                MessageBox.Show("请选择要新增的一个节点");
                return;
            } 
            TreeNode node = tvwMenu.SelectedNode;
            FrmMenuMgrEdit frmEdit = new FrmMenuMgrEdit(node, btnName);
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                //不考虑太多直接刷新
                DoRefresh();
            }
        }
  
    }
}
