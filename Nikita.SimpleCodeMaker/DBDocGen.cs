using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

namespace Nikita.Assist.SimpleCodeMaker
{
    /// <summary>数据库文档生成类
    ///
    /// </summary>
    public class DBDocGen
    {
        /// <summary>生成文档
        ///
        /// </summary>
        /// <param name="dbtype">数据库类型：access,sqlite,mysql,sqlserver</param>
        /// <param name="connstr">链接字符串</param>
        /// <param name="list_tabname">表集合</param>
        /// <returns></returns>
        public static string GenDoc(string dbtype, string connstr, List<string> list_tabname)
        {
            string str = "";
            dbtype = dbtype.ToLower().Replace(" ", "");
            switch (dbtype)
            {
                case "sqlserver":
                    str = SQLServerGenDoc(connstr, list_tabname);
                    break;

                case "access":
                    str = AccessGenDoc(connstr, list_tabname);
                    break;

                case "sqlite":
                    str = SQLiteGenDoc(connstr, list_tabname);
                    break;

                case "mysql":
                    str = MySQLGenDoc(connstr, list_tabname);
                    break;

                default:
                    break;
            }
            return str;
        }

        /// <summary>access数据库文档生成
        ///
        /// </summary>
        /// <param name="connstr">连接字符串</param>
        /// <param name="list_tabname">表集合</param>
        /// <returns></returns>
        private static string AccessGenDoc(string connstr, List<string> list_tabname)
        {
            string dbname = "";
            OleDbConnection conn = new OleDbConnection(connstr);
            conn.Open();
            dbname = conn.Database;
            StringBuilder sb_tab = new StringBuilder(); // 表循环HTML
            DataTable dt_all = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);
            foreach (string tabname in list_tabname)
            {
                var q = from a in dt_all.AsEnumerable()
                        where a.Field<string>("TABLE_NAME") == tabname
                        orderby a.Field<Int64>("ORDINAL_POSITION")
                        select new
                        {
                            字段名 = a.Field<string>("COLUMN_NAME"),
                            类型 = a.Field<int>("DATA_TYPE"),
                            字段说明 = a.Field<string>("DESCRIPTION"),
                            默认值 = a.Field<string>("COLUMN_DEFAULT"),
                        };

                sb_tab.Append("<h3>表名：" + tabname + "</h3>\n");

                #region 输出Table

                sb_tab.Append("<table class='niunantab'>\n");
                sb_tab.Append("<tr>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    序号\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    列名\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    数据类型\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    默认值\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    说明\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("</tr>\n");
                for (int i = 0; i < q.Count(); i++)
                {
                    #region 输出tr

                    var row = q.ElementAt(i);

                    sb_tab.Append("<tr>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append((i + 1) + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row.字段名 + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row.类型 + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row.默认值 + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row.字段说明 + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("</tr>\n");

                    #endregion 输出tr
                }
                sb_tab.Append("</table>\n");

                #endregion 输出Table
            }

            conn.Close();
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + @"\classtemp\DBTemp.html");
            sb.Append(sr.ReadToEnd());
            sb = sb.Replace("@dbname@", dbname);
            sb = sb.Replace("@tables@", sb_tab.ToString());
            return sb.ToString();
        }

        /// <summary>mysql数据库文档生成
        ///
        /// </summary>
        /// <param name="connstr"></param>
        /// <param name="list_tabname"></param>
        /// <returns></returns>
        private static string MySQLGenDoc(string connstr, List<string> list_tabname)
        {
            string dbname = "";
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            dbname = conn.Database;
            StringBuilder sb_tab = new StringBuilder(); // 表循环HTML
            foreach (string tabname in list_tabname)
            {
                MySqlCommand cmd = new MySqlCommand("use information_schema; select * from columns where table_name='" + tabname + "'", conn);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                var q = from a in dt.AsEnumerable()
                        where a.Field<string>("TABLE_NAME") == tabname
                        orderby a.Field<UInt64>("ORDINAL_POSITION")
                        select new
                        {
                            字段名 = a.Field<string>("COLUMN_NAME"),
                            类型 = a.Field<string>("DATA_TYPE"),
                            字段说明 = a.Field<string>("COLUMN_COMMENT"),
                            默认值 = a.Field<string>("COLUMN_DEFAULT"),
                        };

                sb_tab.Append("<h3>表名：" + tabname + "</h3>\n");

                #region 输出Table

                sb_tab.Append("<table class='niunantab'>\n");
                sb_tab.Append("<tr>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    序号\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    列名\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    数据类型\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    默认值\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    说明\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("</tr>\n");
                for (int i = 0; i < q.Count(); i++)
                {
                    #region 输出tr

                    var row = q.ElementAt(i);

                    sb_tab.Append("<tr>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append((i + 1) + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row.字段名 + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row.类型 + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row.默认值 + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row.字段说明 + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("</tr>\n");

                    #endregion 输出tr
                }
                sb_tab.Append("</table>\n");

                #endregion 输出Table
            }

            conn.Close();
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + @"\classtemp\DBTemp.html");
            sb.Append(sr.ReadToEnd());
            sb = sb.Replace("@dbname@", dbname);
            sb = sb.Replace("@tables@", sb_tab.ToString());
            return sb.ToString();
        }

        /// <summary>sqlite数据库文档生成
        ///
        /// </summary>
        /// <param name="connstr">连接字符串</param>
        /// <param name="list_tabname">表集合</param>
        /// <returns></returns>
        private static string SQLiteGenDoc(string connstr, List<string> list_tabname)
        {
            string dbname = "";
            SQLiteConnection conn = new SQLiteConnection(connstr);
            conn.Open();
            dbname = conn.Database;
            StringBuilder sb_tab = new StringBuilder(); // 表循环HTML

            foreach (string tabname in list_tabname)
            {
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

                sb_tab.Append("<h3>表名：" + tabname + "</h3>\n");

                #region 输出Table

                sb_tab.Append("<table class='niunantab'>\n");
                sb_tab.Append("<tr>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    序号\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    列名\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    数据类型\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("</tr>\n");
                for (int i = 0; i < dt_c.Rows.Count; i++)
                {
                    #region 输出tr

                    DataRow row = dt_c.Rows[i];
                    sb_tab.Append("<tr>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append((i + 1) + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row["字段名"] + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row["类型"] + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("</tr>\n");

                    #endregion 输出tr
                }
                sb_tab.Append("</table>\n");

                #endregion 输出Table
            }

            conn.Close();
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + @"\classtemp\DBTemp.html");
            sb.Append(sr.ReadToEnd());
            sb = sb.Replace("@dbname@", dbname);
            sb = sb.Replace("@tables@", sb_tab.ToString());
            return sb.ToString();
        }

        /// <summary>sqlserver数据库文档生成
        ///
        /// </summary>
        /// <param name="connstr">连接字符串</param>
        /// <param name="list_tabname">表集合</param>
        /// <returns></returns>
        private static string SQLServerGenDoc(string connstr, List<string> list_tabname)
        {
            string dbname = "";
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            dbname = conn.Database;
            StringBuilder sb_tab = new StringBuilder(); // 表循环HTML
            foreach (string tabname in list_tabname)
            {
                string sql = "";
                sql += "SELECT a.[name] as '字段名',c.[name] '类型',e.value as '字段说明',sm.text as '默认值',a.isnullable as '是否为空',a.length as '长度', a.xscale as '小数位数' FROM syscolumns  a  ";
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
                sb_tab.Append("<h3>表名：" + tabname + "</h3>\n");

                #region 输出Table

                sb_tab.Append("<table class='niunantab'>\n");
                sb_tab.Append("<tr>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    序号\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    列名\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    数据类型\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    长度\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    小数位\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    允许空\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    默认值\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("<th>\n");
                sb_tab.Append("    说明\n");
                sb_tab.Append("</th>\n");
                sb_tab.Append("</tr>\n");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    #region 输出tr

                    DataRow row = dt.Rows[i];

                    sb_tab.Append("<tr>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append((i + 1) + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row["字段名"] + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row["类型"] + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row["长度"] + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row["小数位数"] + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row["是否为空"].ToString() == "0" ? "否" : "是" + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row["默认值"] + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("<td>\n");
                    sb_tab.Append(row["字段说明"] + "    &nbsp;\n");
                    sb_tab.Append("</td>\n");
                    sb_tab.Append("</tr>\n");

                    #endregion 输出tr
                }
                sb_tab.Append("</table>\n");

                #endregion 输出Table
            }

            conn.Close();

            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + @"\classtemp\DBTemp.html");
            sb.Append(sr.ReadToEnd());
            sb = sb.Replace("@dbname@", dbname);
            sb = sb.Replace("@tables@", sb_tab.ToString());
            return sb.ToString();
        }
    }
}