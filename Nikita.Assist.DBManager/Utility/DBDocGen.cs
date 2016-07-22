using Nikita.Base.DbSchemaReader.DataSchema;
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

namespace Nikita.Assist.DBManager
{
    /// <summary>数据库文档生成类
    ///
    /// </summary>
    public class DbDocGen
    {
        /// <summary>生成文档
        ///
        /// </summary>
        /// <param name="dbType">数据库类型：access,sqlite,mysql,sqlserver</param>
        /// <param name="strConn">链接字符串</param>
        /// <param name="lstTableName">表集合</param>
        /// <returns></returns>
        public static string GenDoc(SqlType dbType, string strConn, List<string> lstTableName)
        {
            string str = "";
            switch (dbType)
            {
                case SqlType.SqlServer:
                    str = SqlServerGenDoc(strConn, lstTableName);
                    break;

                case SqlType.Oracle:
                    break;

                case SqlType.MySql:
                    str = MySqlGenDoc(strConn, lstTableName);
                    break;

                case SqlType.SQLite:
                    str = SQLiteGenDoc(strConn, lstTableName);
                    break;

                case SqlType.SqlServerCe:
                    break;

                case SqlType.PostgreSql:
                    break;

                case SqlType.Db2:
                    break;

                case SqlType.Accesss:
                    str = AccessGenDoc(strConn, lstTableName);
                    break;
            }
            return str;
        }

        /// <summary>access数据库文档生成
        ///
        /// </summary>
        /// <param name="strConn">连接字符串</param>
        /// <param name="lstTableName">表集合</param>
        /// <returns></returns>
        private static string AccessGenDoc(string strConn, List<string> lstTableName)
        {
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            var strdbName = conn.Database;
            StringBuilder sbTab = new StringBuilder(); // 表循环HTML
            DataTable dtAll = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);
            foreach (string tabname in lstTableName)
            {
                if (dtAll != null)
                {
                    var tabname1 = tabname;
                    var q = from a in dtAll.AsEnumerable()
                        where a.Field<string>("TABLE_NAME") == tabname1
                        orderby a.Field<Int64>("ORDINAL_POSITION")
                        select new
                        {
                            字段名 = a.Field<string>("COLUMN_NAME"),
                            类型 = a.Field<int>("DATA_TYPE"),
                            字段说明 = a.Field<string>("DESCRIPTION"),
                            默认值 = a.Field<string>("COLUMN_DEFAULT"),
                        };

                    sbTab.Append("<h3>表名：" + tabname + "</h3>\n");

                    #region 输出Table

                    sbTab.Append("<table class='niunantab'>\n");
                    sbTab.Append("<tr>\n");
                    sbTab.Append("<th>\n");
                    sbTab.Append("    序号\n");
                    sbTab.Append("</th>\n");
                    sbTab.Append("<th>\n");
                    sbTab.Append("    列名\n");
                    sbTab.Append("</th>\n");
                    sbTab.Append("<th>\n");
                    sbTab.Append("    数据类型\n");
                    sbTab.Append("</th>\n");
                    sbTab.Append("<th>\n");
                    sbTab.Append("    默认值\n");
                    sbTab.Append("</th>\n");
                    sbTab.Append("<th>\n");
                    sbTab.Append("    说明\n");
                    sbTab.Append("</th>\n");
                    sbTab.Append("</tr>\n");
                    for (int i = 0; i < q.Count(); i++)
                    {
                        #region 输出tr

                        var row = q.ElementAt(i);

                        sbTab.Append("<tr>\n");
                        sbTab.Append("<td>\n");
                        sbTab.Append((i + 1) + "    &nbsp;\n");
                        sbTab.Append("</td>\n");
                        sbTab.Append("<td>\n");
                        sbTab.Append(row.字段名 + "    &nbsp;\n");
                        sbTab.Append("</td>\n");
                        sbTab.Append("<td>\n");
                        sbTab.Append(row.类型 + "    &nbsp;\n");
                        sbTab.Append("</td>\n");
                        sbTab.Append("<td>\n");
                        sbTab.Append(row.默认值 + "    &nbsp;\n");
                        sbTab.Append("</td>\n");
                        sbTab.Append("<td>\n");
                        sbTab.Append(row.字段说明 + "    &nbsp;\n");
                        sbTab.Append("</td>\n");
                        sbTab.Append("</tr>\n");

                        #endregion 输出tr
                    }
                }
                sbTab.Append("</table>\n");

                #endregion 输出Table
            }

            conn.Close();
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(Environment.CurrentDirectory + @"\classtemp\DBTemp.html");
            sb.Append(sr.ReadToEnd());
            sb = sb.Replace("@dbname@", strdbName);
            sb = sb.Replace("@tables@", sbTab.ToString());
            return sb.ToString();
        }

        /// <summary>mysql数据库文档生成
        ///
        /// </summary>
        /// <param name="strConn"></param>
        /// <param name="lstTableName"></param>
        /// <returns></returns>
        private static string MySqlGenDoc(string strConn, List<string> lstTableName)
        {
            MySqlConnection conn = new MySqlConnection(strConn);
            conn.Open();
            var strdbName = conn.Database;
            StringBuilder sbTab = new StringBuilder(); // 表循环HTML
            foreach (string tabname in lstTableName)
            {
                MySqlCommand cmd = new MySqlCommand("use information_schema; select * from columns where table_name='" + tabname + "'", conn);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                var tabname1 = tabname;
                var q = from a in dt.AsEnumerable()
                        where a.Field<string>("TABLE_NAME") == tabname1
                        orderby a.Field<UInt64>("ORDINAL_POSITION")
                        select new
                        {
                            字段名 = a.Field<string>("COLUMN_NAME"),
                            类型 = a.Field<string>("DATA_TYPE"),
                            字段说明 = a.Field<string>("COLUMN_COMMENT"),
                            默认值 = a.Field<string>("COLUMN_DEFAULT"),
                        };

                sbTab.Append("<h3>表名：" + tabname + "</h3>\n");

                #region 输出Table

                sbTab.Append("<table class='niunantab'>\n");
                sbTab.Append("<tr>\n");
                sbTab.Append("<th>\n");
                sbTab.Append("    序号\n");
                sbTab.Append("</th>\n");
                sbTab.Append("<th>\n");
                sbTab.Append("    列名\n");
                sbTab.Append("</th>\n");
                sbTab.Append("<th>\n");
                sbTab.Append("    数据类型\n");
                sbTab.Append("</th>\n");
                sbTab.Append("<th>\n");
                sbTab.Append("    默认值\n");
                sbTab.Append("</th>\n");
                sbTab.Append("<th>\n");
                sbTab.Append("    说明\n");
                sbTab.Append("</th>\n");
                sbTab.Append("</tr>\n");
                for (int i = 0; i < q.Count(); i++)
                {
                    #region 输出tr

                    var row = q.ElementAt(i);

                    sbTab.Append("<tr>\n");
                    sbTab.Append("<td>\n");
                    sbTab.Append((i + 1) + "    &nbsp;\n");
                    sbTab.Append("</td>\n");
                    sbTab.Append("<td>\n");
                    sbTab.Append(row.字段名 + "    &nbsp;\n");
                    sbTab.Append("</td>\n");
                    sbTab.Append("<td>\n");
                    sbTab.Append(row.类型 + "    &nbsp;\n");
                    sbTab.Append("</td>\n");
                    sbTab.Append("<td>\n");
                    sbTab.Append(row.默认值 + "    &nbsp;\n");
                    sbTab.Append("</td>\n");
                    sbTab.Append("<td>\n");
                    sbTab.Append(row.字段说明 + "    &nbsp;\n");
                    sbTab.Append("</td>\n");
                    sbTab.Append("</tr>\n");

                    #endregion 输出tr
                }
                sbTab.Append("</table>\n");

                #endregion 输出Table
            }

            conn.Close();
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(Environment.CurrentDirectory + @"\classtemp\DBTemp.html");
            sb.Append(sr.ReadToEnd());
            sb = sb.Replace("@dbname@", strdbName);
            sb = sb.Replace("@tables@", sbTab.ToString());
            return sb.ToString();
        }

        /// <summary>sqlite数据库文档生成
        ///
        /// </summary>
        /// <param name="strConn">连接字符串</param>
        /// <param name="lstTableName">表集合</param>
        /// <returns></returns>
        private static string SQLiteGenDoc(string strConn, List<string> lstTableName)
        {
            SQLiteConnection conn = new SQLiteConnection(strConn);
            conn.Open();
            var strdbName = conn.Database;
            StringBuilder sbTab = new StringBuilder(); // 表循环HTML

            foreach (string tabname in lstTableName)
            {
                string sql = "select * from " + tabname + " limit 1";
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

                sbTab.Append("<h3>表名：" + tabname + "</h3>\n");

                #region 输出Table

                sbTab.Append("<table class='niunantab'>\n");
                sbTab.Append("<tr>\n");
                sbTab.Append("<th>\n");
                sbTab.Append("    序号\n");
                sbTab.Append("</th>\n");
                sbTab.Append("<th>\n");
                sbTab.Append("    列名\n");
                sbTab.Append("</th>\n");
                sbTab.Append("<th>\n");
                sbTab.Append("    数据类型\n");
                sbTab.Append("</th>\n");
                sbTab.Append("</tr>\n");
                for (int i = 0; i < dtC.Rows.Count; i++)
                {
                    #region 输出tr

                    DataRow row = dtC.Rows[i];
                    sbTab.Append("<tr>\n");
                    sbTab.Append("<td>\n");
                    sbTab.Append((i + 1) + "    &nbsp;\n");
                    sbTab.Append("</td>\n");
                    sbTab.Append("<td>\n");
                    sbTab.Append(row["字段名"] + "    &nbsp;\n");
                    sbTab.Append("</td>\n");
                    sbTab.Append("<td>\n");
                    sbTab.Append(row["类型"] + "    &nbsp;\n");
                    sbTab.Append("</td>\n");
                    sbTab.Append("</tr>\n");

                    #endregion 输出tr
                }
                sbTab.Append("</table>\n");

                #endregion 输出Table
            }

            conn.Close();
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(Environment.CurrentDirectory + @"\classtemp\DBTemp.html");
            sb.Append(sr.ReadToEnd());
            sb = sb.Replace("@dbname@", strdbName);
            sb = sb.Replace("@tables@", sbTab.ToString());
            return sb.ToString();
        }

        /// <summary>sqlserver数据库文档生成
        ///
        /// </summary>
        /// <param name="strConn">连接字符串</param>
        /// <param name="lstTableName">表集合</param>
        /// <returns></returns>
        private static string SqlServerGenDoc(string strConn, List<string> lstTableName)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            var strdbName = conn.Database;
            StringBuilder sbTab = new StringBuilder(); // 表循环HTML
            foreach (string tabname in lstTableName)
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
                sbTab.Append("<h3>表名：" + tabname + "</h3>\n");

                #region 输出Table

                sbTab.Append("<table class='niunantab'>\n");
                sbTab.Append("<tr>\n");
                sbTab.Append("<th>\n");
                sbTab.Append("    序号\n");
                sbTab.Append("</th>\n");
                sbTab.Append("<th>\n");
                sbTab.Append("    列名\n");
                sbTab.Append("</th>\n");
                sbTab.Append("<th>\n");
                sbTab.Append("    数据类型\n");
                sbTab.Append("</th>\n");
                sbTab.Append("<th>\n");
                sbTab.Append("    长度\n");
                sbTab.Append("</th>\n");
                sbTab.Append("<th>\n");
                sbTab.Append("    小数位\n");
                sbTab.Append("</th>\n");
                sbTab.Append("<th>\n");
                sbTab.Append("    允许空\n");
                sbTab.Append("</th>\n");
                sbTab.Append("<th>\n");
                sbTab.Append("    默认值\n");
                sbTab.Append("</th>\n");
                sbTab.Append("<th>\n");
                sbTab.Append("    说明\n");
                sbTab.Append("</th>\n");
                sbTab.Append("</tr>\n");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    #region 输出tr

                    DataRow row = dt.Rows[i];

                    sbTab.Append("<tr>\n");
                    sbTab.Append("<td>\n");
                    sbTab.Append((i + 1) + "    &nbsp;\n");
                    sbTab.Append("</td>\n");
                    sbTab.Append("<td>\n");
                    sbTab.Append(row["字段名"] + "    &nbsp;\n");
                    sbTab.Append("</td>\n");
                    sbTab.Append("<td>\n");
                    sbTab.Append(row["类型"] + "    &nbsp;\n");
                    sbTab.Append("</td>\n");
                    sbTab.Append("<td>\n");
                    sbTab.Append(row["长度"] + "    &nbsp;\n");
                    sbTab.Append("</td>\n");
                    sbTab.Append("<td>\n");
                    sbTab.Append(row["小数位数"] + "    &nbsp;\n");
                    sbTab.Append("</td>\n");
                    sbTab.Append("<td>\n");
                    sbTab.Append(row["是否为空"].ToString() == "0" ? "否" : "是" + "    &nbsp;\n");
                    sbTab.Append("</td>\n");
                    sbTab.Append("<td>\n");
                    sbTab.Append(row["默认值"] + "    &nbsp;\n");
                    sbTab.Append("</td>\n");
                    sbTab.Append("<td>\n");
                    sbTab.Append(row["字段说明"] + "    &nbsp;\n");
                    sbTab.Append("</td>\n");
                    sbTab.Append("</tr>\n");

                    #endregion 输出tr
                }
                sbTab.Append("</table>\n");

                #endregion 输出Table
            }

            conn.Close();

            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(Environment.CurrentDirectory + @"\DBTemp.html");
            sb.Append(sr.ReadToEnd());
            sb = sb.Replace("@dbname@", strdbName);
            sb = sb.Replace("@tables@", sbTab.ToString());
            return sb.ToString();
        }
    }
}