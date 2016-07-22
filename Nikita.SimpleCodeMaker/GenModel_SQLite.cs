using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace Nikita.Assist.SimpleCodeMaker
{
    /// <summary> 创建sqlite数据库的模型实体类
    /// 
    /// </summary>
    public class GenModel_SQLite
    {
        /// <summary>生成Model代码
        /// 
        /// </summary>
        /// <param name="ns">命名空间</param>
        /// <param name="tabname">表名</param>
        /// <param name="classname">类名</param>
        /// <param name="connstr">数据库连接字符串</param>
        /// <returns></returns>
        public static string GenAllCode(string ns, string tabname, string classname, string connstr)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("using System;\r\n");
            sb.Append("namespace " + ns + ".Model\r\n");
            sb.Append("{\r\n");
            sb.Append("	/// <summary>" + tabname + "表实体类\r\n");
            sb.Append("	/// 作者:\r\n");
            sb.Append("	/// 创建时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
            sb.Append("	/// </summary>\r\n");
            sb.Append("	[Serializable]\r\n");
            sb.Append("	public class " + classname + "\r\n");
            sb.Append("	{\r\n");
            sb.Append("		public " + classname + "()\r\n");
            sb.Append("		{}\r\n");

            SQLiteConnection conn = new SQLiteConnection(connstr);
            conn.Open();

            string sql = "select * from " + tabname + " limit 1";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());


            DataTable dt_c = new DataTable();
            dt_c.Columns.Add("字段名");
            dt_c.Columns.Add("类型");

            foreach (DataColumn item in dt.Columns)
            {
                DataRow r = dt_c.NewRow();
                r["字段名"] = item.ColumnName;
                r["类型"] = item.DataType.Name;
                dt_c.Rows.Add(r);
            }

            for (int i = 0; i < dt_c.Rows.Count; i++)
            {
                DataRow row = dt_c.Rows[i];
                sb.Append("		private " + Tools.DbTypeToCSharpType_SQLite(row["类型"].ToString()) + " _" + row["字段名"] + " " + Tools.DbDefaultToCSharp_SQLite(row["类型"].ToString()) + ";\r\n");
                sb.Append("		/// <summary>" + row["字段名"] + "\r\n");
                sb.Append("		/// \r\n");
                sb.Append("		/// </summary>\r\n");
                sb.Append("		public " + Tools.DbTypeToCSharpType_SQLite(row["类型"].ToString()) + " " + row["字段名"] + "\r\n");
                sb.Append("		{\r\n");
                sb.Append("			set{ _" + row["字段名"] + "=value;}\r\n");
                sb.Append("			get{return _" + row["字段名"] + ";}\r\n");
                sb.Append("		}\r\n");
            }

            conn.Close();

            sb.Append("	}\r\n");
            sb.Append("}\r\n");




            return sb.ToString();
        }
    }
}
