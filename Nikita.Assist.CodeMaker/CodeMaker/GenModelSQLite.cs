using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
    /// <summary> 创建sqlite数据库的模型实体类
    ///
    /// </summary>
    internal class GenModelSqLite : IModelMaker
    {
        ///  <summary>生成Model代码
        ///
        ///  </summary>
        ///  <param name="strNameSpace">命名空间</param>
        ///  <param name="strTableName">表名</param>
        ///  <param name="strClassName">类名</param>
        ///  <param name="strConn">数据库连接字符串</param>
        /// <param name="strAnthor">作者</param>
        /// <returns></returns>
        public string GenModelCode(string strNameSpace, string strTableName, string strClassName, string strConn, string strAnthor)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("using System;\r\n");
            sb.Append("namespace " + strNameSpace + ".Model\r\n");
            sb.Append("{\r\n");
            sb.Append("	/// <summary>" + strTableName + "表实体类\r\n");
            sb.Append("	/// 作者:" + strAnthor + "\r\n");
            sb.Append("	/// 创建时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
            sb.Append("	/// </summary>\r\n");
            sb.Append("	[Serializable]\r\n");
            sb.Append("	public class " + strClassName + "\r\n");
            sb.Append("	{\r\n");
            sb.Append("		public " + strClassName + "()\r\n");
            sb.Append("		{}\r\n");

            SQLiteConnection conn = new SQLiteConnection(strConn);
            conn.Open();

            string sql = "select * from " + strTableName + " limit 1";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            DataTable dtC = new DataTable();
            dtC.Columns.Add("字段名");
            dtC.Columns.Add("类型");

            foreach (DataColumn item in dt.Columns)
            {
                DataRow r = dtC.NewRow();
                r["字段名"] = item.ColumnName;
                r["类型"] = item.DataType.Name;
                dtC.Rows.Add(r);
            }

            for (int i = 0; i < dtC.Rows.Count; i++)
            {
                DataRow row = dtC.Rows[i];
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