using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
    /// <summary>生成mysql的实体类的类
    ///
    /// </summary>
    internal class GenModelMySql : IModelMaker
    {
        ///  <summary>生成Model代码
        ///
        ///  </summary>
        ///  <param name="strNameSpace">命名空间</param>
        ///  <param name="strTableName">表名</param>
        ///  <param name="strClassName">类名</param>
        ///  <param name="strConn">数据库连接字符串</param>
        /// <param name="strAnthor">作者</param>
        /// <returns>model代码</returns>
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

            MySqlConnection conn = new MySqlConnection(strConn);
            conn.Open();
            string db = string.Empty;
            string[] strdb = strConn.Split(';');
            foreach (string t in strdb)
            {
                if (t.ToLower().Contains("database"))
                {
                    db = t.Split('=')[1].Trim();
                }
            }

            MySqlCommand cmd = new MySqlCommand("use information_schema; select * from columns where TABLE_SCHEMA='" + db + "' and table_name='" + strTableName + "'", conn);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            var q = from a in dt.AsEnumerable()
                    where a.Field<string>("TABLE_NAME") == strTableName
                    orderby a.Field<UInt64>("ORDINAL_POSITION")
                    select new
                    {
                        字段名 = a.Field<string>("COLUMN_NAME"),
                        类型 = a.Field<string>("DATA_TYPE"),
                        字段说明 = a.Field<string>("COLUMN_COMMENT"),
                        默认值 = a.Field<string>("COLUMN_DEFAULT"),
                    };

            for (int i = 0; i < q.Count(); i++)
            {
                var row = q.ElementAt(i);
                sb.Append("		private " + Tools.DbTypeToCSharpType_MySQL(row.类型) + " _" + row.字段名 + " " + Tools.DbDefaultToCSharp_MySQL(row.默认值) + ";\r\n");
                sb.Append("		/// <summary>" + row.字段说明 + "\r\n");
                sb.Append("		/// \r\n");
                sb.Append("		/// </summary>\r\n");
                sb.Append("		public " + Tools.DbTypeToCSharpType_MySQL(row.类型) + " " + row.字段名 + "\r\n");
                sb.Append("		{\r\n");
                sb.Append("			set{ _" + row.字段名 + "=value;}\r\n");
                sb.Append("			get{return _" + row.字段名 + ";}\r\n");
                sb.Append("		}\r\n");
            }

            conn.Close();

            sb.Append("	}\r\n");
            sb.Append("}\r\n");

            return sb.ToString();
        }
    }
}