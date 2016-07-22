using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;
using System.Data;

namespace Nikita.Assist.SimpleCodeMaker
{
    /// <summary>生成sqlite数据库DAL代码的类
    /// 
    /// </summary>
    public class GenDAL_SQLite_Wcf
    {
        /// <summary>生成DAL代码
        /// 基于UsTeam数据库操作类
        /// </summary>
        /// <param name="ns">命名空间</param>
        /// <param name="tabname">表名</param>
        /// <param name="classname">类名</param>
        /// <param name="connstr">数据库连接字符串</param>
        /// <returns></returns>
        public static string GenAllCode(string ns, string tabname, string classname, string connstr)
        {
            StringBuilder sb = new StringBuilder();
             
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


            string insertfields = ""; // 字段1,字段2,字段3,....
            string insertvalues = ""; // @字段1,@字段2,@字段3,....
            StringBuilder insertparam = new StringBuilder(); //Add方法的参数添加

            string updatefields = ""; // 字段1=@字段1, 字段2=@字段2, .....
            StringBuilder updateparam = new StringBuilder(); // Update方法的参数添加

            StringBuilder GetListArrayParam = new StringBuilder();

            StringBuilder ReaderBindParam = new StringBuilder();
            string tmp_id = ""; // 存储ID字段名
            for (int i = 0; i < dt_c.Rows.Count; i++)
            {
                DataRow row = dt_c.Rows[i];
                string leixin = Tools.DbTypeToCSharpType_SQLite(row["类型"].ToString());


                if (row["字段名"].ToString().ToLower() != "id")
                {
                    if (i == dt_c.Rows.Count - 1)
                    {
                        insertfields += row["字段名"] + " ";
                        insertvalues += "@" + row["字段名"] + " ";
                        updatefields += row["字段名"] + "=@" + row["字段名"] + " ";

                    }
                    else
                    {
                        insertfields += row["字段名"] + ", ";
                        insertvalues += "@" + row["字段名"] + ", ";
                        updatefields += row["字段名"] + "=@" + row["字段名"] + ", ";
                    }



                    insertparam.Append("if (model." + row["字段名"] + " == null)\r\n");
                    insertparam.Append("            {\r\n");
                    insertparam.Append("                 h.AddParameter(\"@" + row["字段名"] + "\", DBNull.Value);\r\n");
                    insertparam.Append("            }\r\n");
                    insertparam.Append("            else\r\n");
                    insertparam.Append("            {\r\n");
                    if (leixin.ToLower() != "datetime")
                    {
                        insertparam.Append("                 h.AddParameter(\"@" + row["字段名"] + "\", model." + row["字段名"] + ");\r\n");
                    }
                    else
                    {
                        insertparam.Append("                 h.AddParameter(\"@" + row["字段名"] + "\", model." + row["字段名"] + ".ToString(\"s\"));\r\n");
                    }
                    insertparam.Append("            }\r\n");


                    updateparam.Append("            if (model." + row["字段名"] + " == null)\r\n");
                    updateparam.Append("            {\r\n");
                    updateparam.Append("                 h.AddParameter(\"@" + row["字段名"] + "\", DBNull.Value);\r\n");
                    updateparam.Append("            }\r\n");
                    updateparam.Append("            else\r\n");
                    updateparam.Append("            {\r\n");
                    if (leixin.ToLower() != "datetime")
                    {
                        updateparam.Append("                 h.AddParameter(\"@" + row["字段名"] + "\", model." + row["字段名"] + ");\r\n");
                    }
                    else
                    {
                        updateparam.Append("                 h.AddParameter(\"@" + row["字段名"] + "\", model." + row["字段名"] + ".ToString(\"s\"));\r\n");
                    }
                    updateparam.Append("            }\r\n");

                }
                else
                {
                    tmp_id = row["字段名"].ToString();
                }


                string tmp = "";
                if (leixin.ToLower() == "string")
                {
                    tmp = "row[\"" + row["字段名"] + "\"].ToString(),";
                }
                else
                {
                    tmp = leixin + ".Parse(row[\"" + row["字段名"] + "\"].ToString()),";
                }
                GetListArrayParam.Append(row["字段名"] + " = " + tmp);

                if (leixin.ToLower() == "string")
                {
                    ReaderBindParam.Append("            model." + row["字段名"] + " = dataReader[\"" + row["字段名"] + "\"].ToString();\r\n");
                }
                else
                {
                    ReaderBindParam.Append("            ojb = dataReader[\"" + row["字段名"] + "\"];\r\n");
                    ReaderBindParam.Append("            if (ojb != null && ojb != DBNull.Value)\r\n");
                    ReaderBindParam.Append("            {\r\n");
                    ReaderBindParam.Append("                model." + row["字段名"] + " = " + leixin + ".Parse(ojb.ToString());\r\n");
                    ReaderBindParam.Append("            }\r\n");
                }
            }
            updateparam.Append("            h.AddParameter(\"@id\", model." + tmp_id + ");\r\n");


            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + @"\classtemp\SQLiteDALTempWcf.txt");
            sb.Append(sr.ReadToEnd());
            sb = sb.Replace("@namespace@", ns);
            sb = sb.Replace("@tabname@", tabname);
            sb = sb.Replace("@createdate@", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb = sb.Replace("@classname@", classname);

            sb = sb.Replace("@insertfields@", insertfields);
            sb = sb.Replace("@insertvalues@", insertvalues);
            sb = sb.Replace("@insertparam@", insertparam.ToString());

            sb = sb.Replace("@updatefields@", updatefields);
            sb = sb.Replace("@updateparam@", updateparam.ToString());

            sb = sb.Replace("@GetListArrayParam@", GetListArrayParam.ToString());

            sb = sb.Replace("@ReaderBindParam@", ReaderBindParam.ToString());

            return sb.ToString();
        }

        /// <summary>生成 SQLiteHelper
        /// 
        /// </summary>
        /// <param name="ns"></param>
        /// <param name="connstr"></param>
        /// <returns></returns>
        internal static string GenSQLiteHelper(string ns, string connstr)
        {
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + @"\classtemp\SQLiteHelperTemp.txt");
            sb.Append(sr.ReadToEnd());
            sb.Replace("@namespace@", ns);
            sb.Replace("@connstr@", connstr);
            return sb.ToString();
        }
    }
}
