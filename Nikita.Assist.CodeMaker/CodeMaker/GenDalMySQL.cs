using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
    /// <summary>生成mysql数据库DAL的类
    ///
    /// </summary>
    internal class GenDalMySQL : IDalMaker
    {
        /// <summary>生成DAL代码
        ///
        /// </summary>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="strTableName">表名</param>
        /// <param name="strClassName">类名</param>
        /// <param name="strConn">数据库连接字符串</param>
        /// <returns></returns>
        public string GenDalCode(string strNameSpace, string strTableName, string strClassName, string strConn)
        {
            StringBuilder sb = new StringBuilder();

            MySqlConnection conn = new MySqlConnection(strConn);
            conn.Open();
            string db = string.Empty;
            string[] strdb = strConn.Split(';');
            foreach (string dbItem in strdb)
            {
                if (dbItem.ToLower().Contains("database"))
                {
                    db = dbItem.Split('=')[1].Trim();
                }
            }

            MySqlCommand cmd = new MySqlCommand("use information_schema; select * from columns where TABLE_SCHEMA='" + db + "' and table_name='" + strTableName + "'", conn);

            //MySqlCommand cmd = new MySqlCommand("use information_schema; select * from columns where table_name='" + tabname + "'", conn);

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

            string insertfields = ""; // 字段1,字段2,字段3,....
            string insertvalues = ""; // @字段1,@字段2,@字段3,....
            StringBuilder insertparam = new StringBuilder(); //Add方法的参数添加

            string updatefields = ""; // 字段1=@字段1, 字段2=@字段2, .....
            StringBuilder updateparam = new StringBuilder(); // Update方法的参数添加

            StringBuilder getListArrayParam = new StringBuilder();

            StringBuilder readerBindParam = new StringBuilder();
            string tmpId = ""; // 存储ID字段名
            for (int i = 0; i < q.Count(); i++)
            {
                var row = q.ElementAt(i);
                string leixin = Tools.DbTypeToCSharpType_MySQL(row.类型);

                if (row.字段名.ToLower() != "id")
                {
                    if (i == q.Count() - 1)
                    {
                        insertfields += row.字段名 + " ";
                        insertvalues += "@" + row.字段名 + " ";
                        updatefields += row.字段名 + "=@" + row.字段名 + " ";
                    }
                    else
                    {
                        insertfields += row.字段名 + ", ";
                        insertvalues += "@" + row.字段名 + ", ";
                        updatefields += row.字段名 + "=@" + row.字段名 + ", ";
                    }

                    insertparam.Append("            if (model." + row.字段名 + " == null)\r\n");
                    insertparam.Append("            {\r\n");
                    insertparam.Append("                 h.AddParameter(\"@" + row.字段名 + "\", DBNull.Value);\r\n");
                    insertparam.Append("            }\r\n");
                    insertparam.Append("            else\r\n");
                    insertparam.Append("            {\r\n");
                    if (leixin.ToLower() != "datetime")
                    {
                        insertparam.Append("                 h.AddParameter(\"@" + row.字段名 + "\", model." + row.字段名 + ");\r\n");
                    }
                    else
                    {
                        insertparam.Append("                 h.AddParameter(\"@" + row.字段名 + "\", model." + row.字段名 + ".ToString());\r\n");
                    }
                    insertparam.Append("            }\r\n");

                    updateparam.Append("            if (model." + row.字段名 + " == null)\r\n");
                    updateparam.Append("            {\r\n");
                    updateparam.Append("                 h.AddParameter(\"@" + row.字段名 + "\", DBNull.Value);\r\n");
                    updateparam.Append("            }\r\n");
                    updateparam.Append("            else\r\n");
                    updateparam.Append("            {\r\n");
                    if (leixin.ToLower() != "datetime")
                    {
                        updateparam.Append("                 h.AddParameter(\"@" + row.字段名 + "\", model." + row.字段名 + ");\r\n");
                    }
                    else
                    {
                        updateparam.Append("                 h.AddParameter(\"@" + row.字段名 + "\", model." + row.字段名 + ".ToString());\r\n");
                    }
                    updateparam.Append("            }\r\n");
                }
                else
                {
                    tmpId = row.字段名;
                }

                string tmp;
                if (leixin.ToLower() == "string")
                {
                    tmp = "row[\"" + row.字段名 + "\"].ToString(),";
                }
                else
                {
                    tmp = leixin + ".Parse(row[\"" + row.字段名 + "\"].ToString()),";
                }
                getListArrayParam.Append(row.字段名 + " = " + tmp);

                if (leixin.ToLower() == "string")
                {
                    readerBindParam.Append("            model." + row.字段名 + " = dataReader[\"" + row.字段名 + "\"].ToString();\r\n");
                }
                else
                {
                    readerBindParam.Append("            ojb = dataReader[\"" + row.字段名 + "\"];\r\n");
                    readerBindParam.Append("            if (ojb != null && ojb != DBNull.Value)\r\n");
                    readerBindParam.Append("            {\r\n");
                    readerBindParam.Append("                model." + row.字段名 + " = " + leixin + ".Parse(ojb.ToString());\r\n");
                    readerBindParam.Append("            }\r\n");
                }
            }
            updateparam.Append("            h.AddParameter(\"@id\", model." + tmpId + ");\r\n");

            StreamReader sr = new StreamReader(Environment.CurrentDirectory + @"\Template\MySQLDALTemp.txt");
            sb.Append(sr.ReadToEnd());
            sb = sb.Replace("@namespace@", strNameSpace);
            sb = sb.Replace("@tabname@", strTableName);
            sb = sb.Replace("@createdate@", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb = sb.Replace("@classname@", strClassName);

            sb = sb.Replace("@insertfields@", insertfields);
            sb = sb.Replace("@insertvalues@", insertvalues);
            sb = sb.Replace("@insertparam@", insertparam.ToString());

            sb = sb.Replace("@updatefields@", updatefields);
            sb = sb.Replace("@updateparam@", updateparam.ToString());

            sb = sb.Replace("@GetListArrayParam@", getListArrayParam.ToString());

            sb = sb.Replace("@ReaderBindParam@", readerBindParam.ToString());

            return sb.ToString();
        }

        ///// <summary>生成 MySQLHelper
        /////
        ///// </summary>
        ///// <param name="strNameSpace"></param>
        ///// <param name="strConn"></param>
        ///// <returns></returns>
        //internal static string GenMySQLHelper(string strNameSpace, string strConn)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + @"\Template\MySQLHelperTemp.txt");
        //    sb.Append(sr.ReadToEnd());
        //    sb.Replace("@namespace@", strNameSpace);
        //    sb.Replace("@connstr@", strConn);
        //    return sb.ToString();
        //}
    }
}