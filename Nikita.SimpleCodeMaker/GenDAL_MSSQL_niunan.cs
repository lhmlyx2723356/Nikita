using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Nikita.Assist.SimpleCodeMaker
{
    public class GenDAL_MSSQL_niunan
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
            #region 生成DAL代码
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string sql = "";
            sql += "SELECT a.[name] as '字段名',c.[name] '类型',e.value as '字段说明',sm.text as '默认值',a.isnullable as '是否为空' FROM syscolumns  a  ";
            sql += "left   join    systypes    b   on      a.xusertype=b.xusertype ";
            sql += "left 	join 	systypes 	c 	on  	a.xtype = c.xusertype ";
            sql += "inner   join   sysobjects  d   on      a.id=d.id     and   d.xtype='U' ";
            sql += "left join syscomments sm on a.cdefault=sm.id ";
            sql += "left join sys.extended_properties e on a.id = e.major_id and a.colid = e.minor_id and ";
            sql += "e.name='MS_Description' where d.name='" + tabname + "' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            conn.Close();

            string pkey = Tools.GetPKey_MSSQL(tabname, connstr);

            StringBuilder insertparam = new StringBuilder(); //Add方法的参数添加

            StringBuilder updateparam = new StringBuilder(); // Update方法的参数添加

            StringBuilder ReaderBindParam = new StringBuilder();
            string insertfields = ""; // 字段1,字段2,字段3,....
            string insertvalues = ""; // @字段1,@字段2,@字段3,....
            string updatefields = ""; // 字段1=@字段1, 字段2=@字段2, .....
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];

                if (row["类型"].ToString().Contains("char") || row["类型"].ToString().Contains("text"))
                {
                    ReaderBindParam.Append("            model." + row["字段名"] + " = dataReader[\"" + row["字段名"] + "\"].ToString();\r\n");
                }
                else
                {
                    ReaderBindParam.Append("            ojb = dataReader[\"" + row["字段名"] + "\"];\r\n");
                    ReaderBindParam.Append("            if (ojb != null && ojb != DBNull.Value)\r\n");
                    ReaderBindParam.Append("            {\r\n");
                    ReaderBindParam.Append("                model." + row["字段名"] + " = " + Tools.DbTypeToCSharpType(row["类型"].ToString(),"0") + ".Parse(ojb.ToString());\r\n");
                    ReaderBindParam.Append("            }\r\n");
                }
               

                updateparam.Append("            if (model." + row["字段名"] + " == null)\r\n");
                updateparam.Append("            {\r\n");
                updateparam.Append("                 h.AddParameter(\"@" + row["字段名"] + "\", DBNull.Value);\r\n");
                updateparam.Append("            }\r\n");
                updateparam.Append("            else\r\n");
                updateparam.Append("            {\r\n");
                updateparam.Append("                 h.AddParameter(\"@" + row["字段名"] + "\", model." + row["字段名"] + ");\r\n");
                updateparam.Append("            }\r\n");

                if (row["字段名"].ToString() == pkey)
                {
                    continue;
                }
                if (i == dt.Rows.Count - 1)
                {
                    insertfields += row["字段名"].ToString() + " ";
                    insertvalues += "@" + row["字段名"].ToString() + " ";
                    updatefields += row["字段名"].ToString() + "=@" + row["字段名"].ToString() + " ";
                }
                else
                {
                    insertfields += row["字段名"].ToString() + ", ";
                    insertvalues += "@" + row["字段名"].ToString() + ", ";
                    updatefields += row["字段名"].ToString() + "=@" + row["字段名"].ToString() + ", ";
                }


                insertparam.Append("            if (model." + row["字段名"] + " == null)\r\n");
                insertparam.Append("            {\r\n");
                insertparam.Append("                 h.AddParameter(\"@" + row["字段名"] + "\", DBNull.Value);\r\n");
                insertparam.Append("            }\r\n");
                insertparam.Append("            else\r\n");
                insertparam.Append("            {\r\n");
                insertparam.Append("                 h.AddParameter(\"@" + row["字段名"] + "\", model." + row["字段名"] + ");\r\n");
                insertparam.Append("            }\r\n");




               
            }

            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + @"\classtemp\MSSQLDALTemp.txt");
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


            sb = sb.Replace("@ReaderBindParam@", ReaderBindParam.ToString());

            sb = sb.Replace("@pkey@", pkey);

            return sb.ToString();
            #endregion
        }

        /// <summary>生成MSSQLHelper.cs
        /// 
        /// </summary>
        /// <param name="ns">命名空间</param>
        /// <param name="connstr">数据库连接字符串</param>
        /// <returns></returns>
        public static string GenMSSQLHelper(string ns, string connstr)
        {
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + @"\classtemp\MSSQLHelperTemp.txt");
            sb.Append(sr.ReadToEnd());
            sb.Replace("@namespace@", ns);
            sb.Replace("@connstr@", connstr);
            return sb.ToString();
        }
    }
}
