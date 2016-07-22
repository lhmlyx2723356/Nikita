using Nikita.Base.DbSchemaReader.DataSchema;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Nikita.Assist.DBManager
{
    public class TreeViewHelper
    {
        public static TreeNode FindColumnNodeByName(TreeNodeCollection nodes, string strName)
        {
            TreeNode node = null;
            foreach (TreeNode iNode in nodes)
            {
                var databaseColumn = iNode.Tag as DatabaseColumn;
                if (databaseColumn != null && strName.ToLower() == databaseColumn.Name.ToLower())
                {
                    node = iNode;
                    break;
                }
            }
            return node;
        }

        public static TreeNode FindNodeByName(TreeNodeCollection nodes, string strName)
        {
            TreeNode node = null;
            foreach (TreeNode iNode in nodes)
            {
                if (strName.ToLower() == iNode.Text.ToLower())
                {
                    node = iNode;
                    break;
                }
            }
            return node;
        }

        public static TreeNode FindTableNode(TreeNodeCollection treeColl, string strServer, string strDataBase, string strTable)
        { 
            foreach (TreeNode item in treeColl)
            {
                if (item.Text == strServer)
                {
                    foreach (TreeNode itemChild in item.Nodes[0].Nodes)
                    {
                        if (itemChild.Text == strDataBase)
                        {
                            foreach (TreeNode itemChildTable in itemChild.Nodes)
                            {
                                if (itemChildTable.Text == strTable)
                                {
                                    return  itemChildTable;  
                                }
                            }
                        } 
                    }
                } 
            }
            return null;
        }


        /// <summary>选中的TreeNode
        /// 
        /// </summary>
        static List<TreeNode> _lstCheckTreeNodes;


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


        /// <summary>
        /// 系列节点 Checked 属性控制
        /// </summary>
        /// <param name="e"></param>
        public static void CheckControl(TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node != null && !Convert.IsDBNull(e.Node))
                {
                    CheckParentNode(e.Node);
                    if (e.Node.Nodes.Count > 0)
                    {
                        CheckAllChildNodes(e.Node, e.Node.Checked);
                    }
                }
            }
        }

        #region 私有方法

        //改变所有子节点的状态
        private static void CheckAllChildNodes(TreeNode pn, bool blnIsChecked)
        {
            foreach (TreeNode tn in pn.Nodes)
            {
                tn.Checked = blnIsChecked;

                if (tn.Nodes.Count > 0)
                {
                    CheckAllChildNodes(tn, blnIsChecked);
                }
            }
        }

        //改变父节点的选中状态，此处为所有子节点不选中时才取消父节点选中，可以根据需要修改
        private static void CheckParentNode(TreeNode curNode)
        {
            bool bChecked = false;

            if (curNode.Parent != null)
            {
                foreach (TreeNode node in curNode.Parent.Nodes)
                {
                    if (node.Checked)
                    {
                        bChecked = true;
                        break;
                    }
                }

                if (bChecked)
                {
                    curNode.Parent.Checked = true;
                    CheckParentNode(curNode.Parent);
                }
                else
                {
                    curNode.Parent.Checked = false;
                    CheckParentNode(curNode.Parent);
                }
            }
        }  
        #endregion


        #endregion
    }
}