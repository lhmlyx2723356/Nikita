using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Core.WinForm
{
    /// <summary>
    /// WinForm TreeView帮助类
    /// </summary>
    public class TreeViewHelper
    {
        /// <summary>选中的TreeNode
        ///
        /// </summary>
        private static List<TreeNode> _lstCheckTreeNodes;

        #region 递归绑定TreeView

        /// <summary>递归绑定TreeView
        ///
        /// </summary>
        /// <param name="tvwData"></param>
        /// <param name="dt"></param>
        /// <param name="intParentId"></param>
        /// <param name="intKeyId"></param>
        /// <param name="strName"></param>
        /// <param name="strText"></param>
        public static void BindTreeView(TreeView tvwData, DataTable dt, string intParentId, string intKeyId, string strName, string strText)
        {
            tvwData.Nodes.Clear();
            string strFilter = intParentId + "=0 ";
            DataRow[] drsParent = dt.Select(strFilter);
            if (drsParent.Length <= 0) return;
            for (int i = 0; i < drsParent.Count(); i++)
            {
                TreeNode parentNode = InitTreeNode(drsParent[i][strName].ToString(), drsParent[i][strText].ToString(),
                    drsParent[i]);
                tvwData.Nodes.Add(parentNode);
                BindChildTreeNode(dt, parentNode, intKeyId, intParentId, strName, strText);
            }
        }

        private static void BindChildTreeNode(DataTable dt, TreeNode parentNode, string intKeyId, string intParentId, string strName, string strText)
        {
            var dataRow = parentNode.Tag as DataRow;
            if (dataRow != null)
            {
                string intChildParentId = dataRow[intKeyId].ToString();

                string strFilter = intParentId + "=" + intChildParentId;
                DataRow[] drsChild = dt.Select(strFilter);
                if (drsChild.Length > 0)
                {
                    for (int i = 0; i < drsChild.Count(); i++)
                    {
                        TreeNode childNode = InitTreeNode(drsChild[i][strName].ToString(), drsChild[i][strText].ToString(), drsChild[i]);
                        parentNode.Nodes.Add(childNode);
                        BindChildTreeNode(dt, childNode, intKeyId, intParentId, strName, strText);
                    }
                }
            }
        }

        #endregion 递归绑定TreeView

        /// <summary>生成一个TreeNode
        ///
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strText"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static TreeNode InitTreeNode(string strName, string strText, DataRow dr)
        {
            TreeNode node = new TreeNode { Name = strName, Text = strText, Tag = dr };
            return node;
        }

        #region 获取勾选的所有TreeNode

        /// <summary>获取勾选的所有TreeNode
        ///
        /// </summary>
        /// <param name="tvwView"></param>
        /// <returns></returns>
        public static List<TreeNode> GetAllCheckNodes(TreeView tvwView)
        {
            _lstCheckTreeNodes = new List<TreeNode>();
            foreach (TreeNode note in tvwView.Nodes)
            {
                if (note.Checked)
                {
                    _lstCheckTreeNodes.Add(note);
                }
                CheckNode(note);
            }
            return _lstCheckTreeNodes;
        }

        private static void CheckNode(TreeNode note1)
        {
            foreach (TreeNode note in note1.Nodes)
            {
                if (note.Checked)
                {
                    _lstCheckTreeNodes.Add(note);
                    CheckNode(note);
                }
            }
        }

        #endregion 获取勾选的所有TreeNode

        /// <summary> 设置TreeView选中节点
        ///
        /// </summary>
        /// <param name="tvwTreeView"></param>
        /// <param name="node"></param>
        public static void SetTreeViewSelectNode(TreeView tvwTreeView, TreeNode node)
        {
            tvwTreeView.Focus();
            if (node != null)
            {
                tvwTreeView.SelectedNode = node;
                node.Checked = true;
                node.Expand();
            }
        }
    }
}