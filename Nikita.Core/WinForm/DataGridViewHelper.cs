using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Core.WinForm
{
    /// <summary>
    /// WinForm  DataGridView帮助类
    /// </summary>
    public class DataGridViewHelper
    {
        /// <summary>绑定DataGridView
        ///
        /// </summary>
        /// <param name="gridView">DataGridView控件</param>
        /// <param name="objDataSource">objDataSource数据源</param>
        public static void BindDataGridView(DataGridView gridView, object objDataSource)
        {
            if (objDataSource == null)
            {
                return;
            }
            gridView.AutoGenerateColumns = false;
            string strType = objDataSource.GetType().ToString();
            if (strType == "System.Data.DataTable")
            {
                BindDataGridView(gridView, objDataSource as DataTable);
            }
            else if (strType == "System.Data.DataSet")
            {
                var dataSet = objDataSource as DataSet;
                if (dataSet != null) BindDataGridView(gridView, dataSet.Tables[0]);
            }
        }

        /// <summary>获取选中行某列的值，用逗号拼接
        /// 
        /// </summary>
        /// <param name="grdCollection">选中行</param>
        /// <param name="strColumnName">列名</param>
        /// <returns></returns>
        public static string GetColumnValuesBySelectRows(DataGridViewSelectedRowCollection grdCollection, string strColumnName)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in grdCollection)
            {
                sb.Append(row.Cells[strColumnName].Value);
                sb.Append(",");
            }
            return sb.ToString().TrimEnd(',');
        }

        public static string GetDataRowInfo(DataGridView gridView, DataGridViewRow row)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                if (!gridView.Columns[i].Visible)
                {
                    continue;
                }
                sb.Append(gridView.Columns[i].HeaderText);
                sb.Append(":");
                if (i != gridView.Columns.Count - 1)
                {
                    object objValue = row.Cells[gridView.Columns[i].Name].Value;
                    sb.AppendLine(objValue == null ? string.Empty : objValue.ToString());
                }
                else
                {
                    sb.Append(row.Cells[gridView.Columns[i].Name].Value);
                }
            }
            return sb.ToString();
        }
    }
}