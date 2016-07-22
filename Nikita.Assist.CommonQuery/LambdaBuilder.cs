 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Nikita.WinForm.ExtendControl;

namespace Nikita.Assist.CommonQuery
{
    public partial class LambdaBuilder : UserControl
    {
        private DataTable _dtColumns;

        public LambdaBuilder()
        {
            InitializeComponent();
        }

        #region 初始化

        /// <summary>绑定ComboBox
        ///
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="cbo"></param>
        /// <param name="strValueMember"></param>
        /// <param name="strDisplayMember"></param>
        public void BindCombobox(DataTable dtSource, ComboBox cbo, string strValueMember, string strDisplayMember)
        {
            cbo.DisplayMember = strDisplayMember;
            cbo.ValueMember = strValueMember;
            cbo.DataSource = dtSource;
        }

        /// <summary>获取绑定下拉字段框数据
        ///
        /// </summary>
        /// <param name="grd">DataGridView控件</param>
        /// <returns>列表格</returns>
        public DataTable GetDataTableColumn<T>(DataGridView grd)
        {
            _dtColumns = new DataTable();
            _dtColumns.Columns.Add("ColumnTxt", typeof(string));
            _dtColumns.Columns.Add("ColumnFileName", typeof(string));
            _dtColumns.Columns.Add("ColumnProperty", typeof(string));
            foreach (DataGridViewColumn column in grd.Columns)
            {
                if (!column.Visible)
                {
                    continue;
                }
                DataRow drNew = _dtColumns.NewRow();
                drNew["ColumnTxt"] = column.HeaderText;
                drNew["ColumnFileName"] = column.DataPropertyName;
                drNew["ColumnProperty"] = typeof(T).GetProperty(column.DataPropertyName).PropertyType.ToString();
                _dtColumns.Rows.Add(drNew);
            }
            return _dtColumns;
        }

        /// <summary>获取绑定下拉操作符数据
        ///
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOperation(string strType)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("OperaTxt", typeof(string));
            dt.Columns.Add("OperaValue", typeof(string));

            DataRow drNew0 = dt.NewRow();
            drNew0["OperaValue"] = @"=";
            drNew0["OperaTxt"] = "等于";
            dt.Rows.Add(drNew0);

            DataRow drNew7 = dt.NewRow();
            drNew7["OperaValue"] = @"<>";
            drNew7["OperaTxt"] = "不等于";
            dt.Rows.Add(drNew7);

            if (!strType.Contains("System.String"))
            {
                DataRow drNew1 = dt.NewRow();
                drNew1["OperaValue"] = @">";
                drNew1["OperaTxt"] = "大于";
                dt.Rows.Add(drNew1);

                DataRow drNew8 = dt.NewRow();
                drNew8["OperaValue"] = @">=";
                drNew8["OperaTxt"] = "大于等于";
                dt.Rows.Add(drNew8);

                DataRow drNew2 = dt.NewRow();
                drNew2["OperaValue"] = @"<";
                drNew2["OperaTxt"] = "小于";
                dt.Rows.Add(drNew2);

                DataRow drNew9 = dt.NewRow();
                drNew9["OperaValue"] = @"<=";
                drNew9["OperaTxt"] = "小于等于";
                dt.Rows.Add(drNew9);
            }
            if (strType.Contains("System.String"))
            {
                DataRow drNew4 = dt.NewRow();
                drNew4["OperaValue"] = @"like";
                drNew4["OperaTxt"] = "包含";
                dt.Rows.Add(drNew4);
            }

            DataRow drNew5 = dt.NewRow();
            drNew5["OperaValue"] = @"in";
            drNew5["OperaTxt"] = "在列表中";
            dt.Rows.Add(drNew5);

            DataRow drNew6 = dt.NewRow();
            drNew6["OperaValue"] = @"not in";
            drNew6["OperaTxt"] = "不在列表中";
            dt.Rows.Add(drNew6);

            return dt;
        }

        public void Init<T>(DataGridView grd)
        {
            DataTable dtColumns = GetDataTableColumn<T>(grd);
            BindCombobox(dtColumns, cboFiled, "ColumnFileName", "ColumnTxt");
        }

        #endregion 初始化

        #region 事件

        /// <summary>添加
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string txt1 = tvTaskList.Rows.Count == 0 ? string.Empty : (radAnd.Checked ? radAnd.Text : radOR.Text);
            string txt2 = cboFiled.Text.Trim();
            string txt3 = cboOperation.Text.Trim();
            string txt4 = txtValue.Text.Trim();

            if (txt2 == string.Empty || txt3 == string.Empty || txt4 == string.Empty)
            {
                return;
            }
            tvTaskList.Nodes.Add(txt1, txt2, txt3, txt4);
        }

        private void cboFiled_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFiled.Text.Trim() == string.Empty || cboFiled.SelectedValue == null)
            {
                return;
            }
            string strType = _dtColumns.Select("ColumnFileName ='" + cboFiled.SelectedValue + "'")[0]["ColumnProperty"].ToString();
            DataTable dtOperation = GetDataTableOperation(strType);
            BindCombobox(dtOperation, cboOperation, "OperaValue", "OperaTxt");
        }

        private void 取消优先ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection coll = tvTaskList.SelectedRows;
            if (coll.Count == 0)
            {
                return;
            }
            //是否选中父级
            bool isSelectParent = false;
            TreeGridNode nodeParent = null;
            foreach (DataGridViewRow item in coll)
            {
                TreeGridNode node = tvTaskList.GetNodeForRow(item);
                if (node.Level == 1)
                {
                    //没有子级，则是选中的总行数中包含父级外的Node
                    if (node.Nodes.Count == 0)
                    {
                        return;
                    }
                    else
                    {
                        nodeParent = node;
                        isSelectParent = true;
                    }
                }
            }
            DataGridViewSelectedRowCollection collTemp = tvTaskList.SelectedRows;
            //如果选中的包含父级
            if (isSelectParent)
            {
                //直接删除父级即可
                tvTaskList.Nodes.Remove(nodeParent);
            }
            else
            {
                TreeGridNode parent = tvTaskList.GetNodeForRow(coll[0]).Parent;
                //获取未选中的子级
                List<TreeGridNode> lstNotSelect = (from item in parent.Nodes where item.Selected == false select tvTaskList.GetNodeForRow(item)).ToList();
                //先移除所有
                tvTaskList.Nodes.Remove(parent);
                if (lstNotSelect.Count > 0)
                {
                    //添加父级
                    TreeGridNode nodeParentTemp = tvTaskList.Nodes.Add("优先", "", "", "");
                    //把未选中的子级添加回来
                    foreach (TreeGridNode item in lstNotSelect)
                    {
                        nodeParentTemp.Nodes.Add(item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString(), item.Cells[2].Value.ToString(), item.Cells[3].Value.ToString());
                    }
                    //nodeParentTemp.Nodes[0].Cells[0].Value = string.Empty;
                }
                //把取消优先的添加到父级外
                List<TreeGridNode> lstRemove = (from DataGridViewRow item in collTemp select tvTaskList.Nodes.Add(item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString(), item.Cells[2].Value.ToString(), item.Cells[3].Value.ToString())).ToList();
                if (lstRemove.Count > 0)
                {
                    foreach (DataGridViewRow item in tvTaskList.Rows)
                    {
                        TreeGridNode node = tvTaskList.GetNodeForRow(item);
                        if (node != null)
                        {
                            node.Selected = lstRemove.Contains(node);
                        }
                    }
                }
            }
            Rebuid();
        }

        private void 删除选中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection coll = tvTaskList.SelectedRows;
            if (coll.Count == 0)
            {
                return;
            }
            foreach (DataGridViewRow item in coll)
            {
                TreeGridNode node = tvTaskList.GetNodeForRow(item);
                if (node.Level == 1)
                {
                    tvTaskList.Nodes.Remove(node);
                }
                else if (node.Level == 2)
                {
                    node.Parent.Nodes.Remove(node);
                }
            }
            Rebuid();
        }

        private void 优先ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection coll = tvTaskList.SelectedRows;
            if (coll.Count == 0)
            {
                return;
            }
            foreach (DataGridViewRow item in coll)
            {
                TreeGridNode nodechild = tvTaskList.GetNodeForRow(item);
                if (nodechild.Level != 1)
                {
                    return;
                }

                if (nodechild.Cells[1].Value.ToString() == string.Empty)
                {
                    return;
                }
            }
            //先添加
            TreeGridNode node = tvTaskList.Nodes.Add("优先", "", "", "");
            foreach (DataGridViewRow item in coll)
            {
                node.Nodes.Add(item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString(), item.Cells[2].Value.ToString(), item.Cells[3].Value.ToString());
            }
            //移除
            foreach (DataGridViewRow item in coll)
            {
                tvTaskList.Nodes.Remove(tvTaskList.GetNodeForRow(item));
            }
            //node.Nodes[0].Cells[0].Value = string.Empty;
            Rebuid();
        }

        #endregion 事件

        /// <summary>获取优先级的数据列
        ///
        /// </summary>
        /// <param name="tgv"></param>
        /// <returns></returns>
        public static Dictionary<int, List<TreeGridNode>> GetFirstLevelNodes(TreeGridView tgv)
        {
            Dictionary<int, List<TreeGridNode>> dic = new Dictionary<int, List<TreeGridNode>>();
            int indexKey = 0;
            foreach (DataGridViewRow row in tgv.Rows)
            {
                TreeGridNode node = tgv.GetNodeForRow(row);
                if (node != null)
                {
                    if (node.Cells[0].Value.ToString().Trim().Contains("优先"))
                    {
                        indexKey = indexKey + 1;

                        var nodes = new List<TreeGridNode> { node };
                        nodes.AddRange(node.Nodes);
                        dic.Add(indexKey, nodes);
                    }
                }
            }
            return dic;
        }

        /// <summary>获取非优先级的数据列
        ///
        /// </summary>
        /// <param name="tgv"></param>
        /// <returns></returns>
        public static List<TreeGridNode> GetSendLevelNodes(TreeGridView tgv)
        {
            return (from DataGridViewRow row in tgv.Rows select tgv.GetNodeForRow(row) into node where node != null where !node.Cells[0].Value.ToString().Trim().Contains("优先") && node.Level == 1 select node).ToList();
            //List<TreeGridNode> nodes = new List<TreeGridNode>();
            //foreach (DataGridViewRow row in tgv.Rows)
            //{
            //    TreeGridNode node = tgv.GetNodeForRow(row);
            //    if (node != null)
            //    {
            //        if (!node.Cells[0].Value.ToString().Trim().Contains("优先") && node.Level == 1)
            //        {
            //            nodes.Add(node);
            //        }
            //    }
            //}
            //return nodes;
        }

        /// <summary>生成最终的Lambda表达式
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Expression<Func<T, bool>> BuildLambda<T>()
        {
            DataTable dtFiled = cboFiled.DataSource as DataTable;
            if (dtFiled == null)
            {
                return null;
            }

            DataTable dtOperation = cboOperation.DataSource as DataTable;
                if (dtOperation == null)
                {
                    return null;
                } 
            var param = DynamicLinq.CreateLambdaParam<T>("c");
            Expression body = Expression.Constant(true); //初始默认一个true

            #region 处理优先级

            //获取优先级
            Dictionary<int, List<TreeGridNode>> dicNodes = GetFirstLevelNodes(tvTaskList);
            foreach (KeyValuePair<int, List<TreeGridNode>> item in dicNodes)
            {
                Expression expressAll = ConvertToFirstLevelFiltersByTreeGridView<T>(param, item.Value);
                body = item.Value[0].Cells[0].Value.ToString().Contains("并且") ? body.AndAlso(expressAll) : body.Or(expressAll);
            }

            #endregion 处理优先级

            #region 处理非优先级

            //获取非优先级别的Filter
            List<TreeGridNode> secNodes = GetSendLevelNodes(tvTaskList);
            if (secNodes.Count > 0)
            {
                List<Filter> filters = ConvertFiltersByTreeGridView(tvTaskList, secNodes);
                if (filters.Count > 0)
                {
                    foreach (var filter in filters)
                    {
                        Expression express = param.GenerateBody<T>(filter);
                        if (filter.AndOr == "并且" || filter.AndOr == string.Empty)
                        {
                            body = body.AndAlso(express); //这里可以根据需要自由组合
                        }
                        else if (filter.AndOr == "或者")
                        {
                            body = body.Or(express);
                        }
                    }
                }
            }

            #endregion 处理非优先级

            var lambda = param.GenerateTypeLambda<T>(body); //最终组成lambda
            return lambda;
        }

        /// <summary>转换非优先级的数据--->Filter
        ///
        /// </summary>
        /// <param name="tgv"></param>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public List<Filter> ConvertFiltersByTreeGridView(TreeGridView tgv, List<TreeGridNode> nodes)
        {
            //获取非优先级
            if (nodes.Count == 0)
            {
                return null;
            }

            DataTable dtFiled = cboFiled.DataSource as DataTable;
            if (dtFiled == null)
            {
                return null;
            }
            DataTable dtOperation = cboOperation.DataSource as DataTable;
            //foreach (TreeGridNode node in nodes)
            //{
            //    if (node.Cells[0].Value.ToString().Contains("优先"))
            //    {
            //        continue;
            //    }
            //    string andOr = node.Cells[0].Value.ToString();
            //    string key = ConvertToValue(dtFiled, "ColumnTxt", node.Cells[1].Value.ToString(), "ColumnFileName");
            //    string value = node.Cells[3].Value.ToString();
            //    string contract = ConvertToValue(dtOperation, "OperaTxt", node.Cells[2].Value.ToString(), "OperaValue");
            //    filters.Add(
            //   new Filter { AndOr = andOr, Key = key, Value = value, Contract = contract });
            //}
            //return filters;

            return (from node in nodes where !node.Cells[0].Value.ToString().Contains("优先") let andOr = node.Cells[0].Value.ToString() let key = ConvertToValue(dtFiled, "ColumnTxt", node.Cells[1].Value.ToString(), "ColumnFileName") let value = node.Cells[3].Value.ToString() let contract = ConvertToValue(dtOperation, "OperaTxt", node.Cells[2].Value.ToString(), "OperaValue") select new Filter { AndOr = andOr, Key = key, Value = value, Contract = contract }).ToList();
        }

        /// <summary>处理优先级
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <param name="lstFirstNodes"></param>
        /// <returns></returns>
        public Expression ConvertToFirstLevelFiltersByTreeGridView<T>(ParameterExpression param, List<TreeGridNode> lstFirstNodes)
        {
            Expression expressAll = null;
            List<Filter> filtersFirst = ConvertFiltersByTreeGridView(tvTaskList, lstFirstNodes);
            for (int i = 0; i < filtersFirst.Count; i++)
            {
                Expression express = param.GenerateBody<T>(filtersFirst[i]);
                if (i == 0)
                {
                    expressAll = express;

                    continue;
                }
                if (filtersFirst[i].AndOr == "并且")
                {
                    if (expressAll != null) expressAll = Expression.And(expressAll, express);
                }
                else if (filtersFirst[i].AndOr == "或者")
                {
                    if (expressAll != null) expressAll = Expression.Or(expressAll, express); //这里可以根据需要自由组合
                }
            }
            return expressAll;
        }

        /// <summary> 展开所有节点
        ///
        /// </summary>
        public void ExpendAll()
        {
            foreach (DataGridViewRow item in tvTaskList.Rows)
            {
                TreeGridNode node = tvTaskList.GetNodeForRow(item);
                if (node.Nodes.Count > 0)
                {
                    node.Expand();
                }
            }
        }

        /// <summary>重新修复树关系
        ///
        /// </summary>
        public void Rebuid()
        {
            ExpendAll();
            Dictionary<string, TreeGridNode> lstRow = new Dictionary<string, TreeGridNode>();
            int parentKey = 0;
            foreach (DataGridViewRow item in tvTaskList.Rows)
            {
                TreeGridNode node = tvTaskList.GetNodeForRow(item);
                if (node.Level == 1)
                {
                    lstRow.Add(item.Index.ToString(), node);
                    if (node.Nodes.Count > 0)
                    {
                        parentKey = item.Index;
                    }
                }
                else
                {
                    lstRow.Add(parentKey.ToString() + "-" + item.Index.ToString(), node);
                }
            }
            if (lstRow.Count > 0)
            {
                tvTaskList.Nodes.Clear();
            }

            //需要重新添加才能修复关系
            int index = 0;
            foreach (KeyValuePair<string, TreeGridNode> kv in lstRow)
            {
                TreeGridNode value = kv.Value;
                string strCellValue;
                string strCellValue1;
                string strCellValue2;
                string strCellValue3;
                //如果当前遍历的是第一行
                if (index == 0)
                {
                    //如果包含优先则意味着有下一级，获取下一级别第一个逻辑，如果是空的则默认并且。得到的逻辑结果为：优先[并且] 或者  优先[或者]
                    if (value.Cells[0].Value.ToString().Contains("优先"))
                    {
                        TreeGridNode nodeChild = lstRow[kv.Key + "-" + (int.Parse(kv.Key) + 1)];
                        string strParentOp = nodeChild.Cells[0].Value.ToString() == string.Empty ? "[并且]" : "[" + nodeChild.Cells[0].Value + "]";
                        strCellValue = "优先" + strParentOp;
                        strCellValue1 = value.Cells[1].Value.ToString();
                        strCellValue2 = value.Cells[2].Value.ToString();
                        strCellValue3 = value.Cells[3].Value.ToString();
                    }
                    //如果不包含优先则第一个逻辑应该为空
                    else
                    {
                        strCellValue = string.Empty;
                        strCellValue1 = value.Cells[1].Value.ToString();
                        strCellValue2 = value.Cells[2].Value.ToString();
                        strCellValue3 = value.Cells[3].Value.ToString();
                    }
                    tvTaskList.Nodes.Add(strCellValue, strCellValue1, strCellValue2, strCellValue3);
                    index++;
                }
                //如果当前遍历的不是第一行
                else
                {
                    if (value.Cells[0].Value.ToString().Contains("优先"))
                    {
                        TreeGridNode nodeChild = lstRow[kv.Key + "-" + (int.Parse(kv.Key) + 1)];
                        string strParentOp = nodeChild.Cells[0].Value.ToString() == string.Empty ? "[并且]" : "[" + nodeChild.Cells[0].Value + "]";
                        strCellValue = "优先" + strParentOp;
                        strCellValue1 = value.Cells[1].Value.ToString();
                        strCellValue2 = value.Cells[2].Value.ToString();
                        strCellValue3 = value.Cells[3].Value.ToString();
                        tvTaskList.Nodes.Add(strCellValue, strCellValue1, strCellValue2, strCellValue3);
                    }
                    else
                    {
                        strCellValue = value.Cells[0].Value.ToString();
                        strCellValue1 = value.Cells[1].Value.ToString();
                        strCellValue2 = value.Cells[2].Value.ToString();
                        strCellValue3 = value.Cells[3].Value.ToString();
                        if (kv.Key.Contains("-"))
                        {
                            if (int.Parse(kv.Key.Split('-')[0]) == int.Parse(kv.Key.Split('-')[1]) - 1)
                            {
                                strCellValue = string.Empty;
                            }
                            tvTaskList.Nodes[tvTaskList.Nodes.Count - 1].Nodes.Add(strCellValue, strCellValue1, strCellValue2, strCellValue3);
                        }
                        else
                        {
                            tvTaskList.Nodes.Add(strCellValue, strCellValue1, strCellValue2, strCellValue3);
                        }
                    }
                }
            }
            ExpendAll();
        }

        /// <summary>把文字转换成对应的字段名/操作符
        ///
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strTxtColumn"></param>
        /// <param name="strTxtInfo"></param>
        /// <param name="strValueColumn"></param>
        /// <returns></returns>
        private string ConvertToValue(DataTable dt, string strTxtColumn, string strTxtInfo, string strValueColumn)
        {
            string strValue = string.Empty;
            DataRow[] drs = dt?.Select(strTxtColumn + "='" + strTxtInfo + "'");
            if (drs?.Length > 0)
            {
                strValue = drs[0][strValueColumn].ToString();
            }
            return strValue;
        }
    }
}