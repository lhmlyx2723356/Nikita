using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace NiKita.Core.Sample.Support
{
    public class DataTableSupport
    {
        /// <summary>生成N列N行表格
        /// 
        /// </summary>
        /// <param name="intColumn"></param>
        /// <param name="intRow"></param>
        /// <returns></returns>
        public static DataTable InitDataTable(int intColumn, int intRow)
        {
            DataTable dt = new DataTable("dtSupport");
            for (int i = 0; i < intColumn; i++)
            {
                dt.Columns.Add("Column" + i, typeof(string));
            }

            for (int k = 0; k < intRow; k++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < intColumn; j++)
                {
                    dr["Column" + j] = "Value" + j;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

    }
}
