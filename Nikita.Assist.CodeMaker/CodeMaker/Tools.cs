using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Nikita.Assist.CodeMaker
{
    internal class Tools
    {
        /// <summary>数据库默认值转C#代码
        ///
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string DbDefaultToCSharp(string p)
        {
            string str = "";
            if (p.Contains("getdate()"))
            {
                str = "= DateTime.Now";
            }
            string strPat = @"\(\((\d+)\)\)";
            Regex r = new Regex(strPat, RegexOptions.IgnoreCase);
            Match m = r.Match(p);
            int intMatchCount = 0;
            if (m.Success)
            {
                ++intMatchCount;
                Group g = m.Groups[1];
                str = " = " + g.Value;
            }

            strPat = @"\(N?'(.+)'\)";
            r = new Regex(strPat, RegexOptions.IgnoreCase);
            m = r.Match(p);
            intMatchCount = 0;
            if (m.Success)
            {
                ++intMatchCount;
                Group g = m.Groups[1];
                str = " = \"" + g.Value + "\"";
            }
            return str;
        }

        /// <summary>MSSQL数据库默认值转C#代码
        ///
        /// </summary>
        /// <param name="val">数据库中的默认值</param>
        /// <param name="type">数据库中类型</param>
        /// <returns></returns>
        public static string DbDefaultToCSharp(string val, string type)
        {
            string str = "";
            if (val.Contains("getdate()"))
            {
                str = "= DateTime.Now";
            }
            string strPat = @"\(\((\d+)\)\)";
            Regex r = new Regex(strPat, RegexOptions.IgnoreCase);
            Match m = r.Match(val);
            int intMatchCount = 0;
            if (m.Success)
            {
                ++intMatchCount;
                Group g = m.Groups[1];
                if (type.Contains("char"))
                {
                    str = " = \"" + g.Value + "\"";
                }
                else
                {
                    str = " = " + g.Value;
                }
            }

            strPat = @"\(N?'(.+)'\)";
            r = new Regex(strPat, RegexOptions.IgnoreCase);
            m = r.Match(val);
            intMatchCount = 0;
            if (m.Success)
            {
                ++intMatchCount;
                Group g = m.Groups[1];
                str = " = \"" + g.Value + "\"";
            }

            if (type == "bit")
            {
                if (val.Contains("0"))
                {
                    str = " = false";
                }
                else if (val.Contains("1"))
                {
                    str = " = true";
                }
            }
            return str;
        }

        /// <summary>数据库中的类型转为C#中的DbType.后面的值
        ///
        /// </summary>
        /// <param name="strDbType"></param>
        /// <returns></returns>
        public static string DbTypeToCSharpDbType(string strDbType)
        {
            {
                string str;
                switch (strDbType)
                {
                    case "int":
                        str = "Int32";
                        break;

                    case "bigint":
                        str = "Int64";
                        break;

                    case "datetime":
                        str = "DateTime";
                        break;

                    case "nvarchar":
                        str = "String";
                        break;

                    case "varchar":
                        str = "String";
                        break;

                    case "float":
                        str = "Double";
                        break;

                    case "decimal":
                        str = "Double";
                        break;

                    default:
                        str = "String";
                        break;
                }
                return str;
            }
        }

        /// <summary>数据库类型转换为C#的类型
        ///
        /// </summary>
        /// <param name="strType">数据库中的类型</param>
        /// <param name="strIsNull">是否可为空，0否1是</param>
        /// <returns></returns>
        public static string DbTypeToCSharpType(string strType, string strIsNull)
        {
            string str;
            if (strType.Contains("bigint"))
            {
                str = strIsNull == "0" ? "long" : "long?";
            }
            else if (strType.Contains("int"))
            {
                str = strIsNull == "0" ? "int" : "int?";
            }
            else if (strType.Contains("bit"))
            {
                str = strIsNull == "0" ? "bool" : "bool?";
            }
            else if (strType.Contains("datetime"))
            {
                str = strIsNull == "0" ? "DateTime" : "DateTime?";
            }
            else if (strType.Contains("float"))
            {
                str = strIsNull == "0" ? "float" : "float?";
            }
            else if (strType.Contains("decimal"))
            {
                str = strIsNull == "0" ? "double" : "double?";
            }
            else
            {
                str = "string";
            }
            return str;
        }

        /// <summary>取数据库名称
        ///
        /// </summary>
        /// <param name="strDbType">数据库类型</param>
        /// <param name="strConn">连接字符串</param>
        /// <returns></returns>
        public static string GetDbName(string strDbType, string strConn)
        {
            string strDbName = "";
            strDbType = strDbType.ToLower().Replace(" ", "");
            switch (strDbType)
            {
                case "sqlserver":
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();
                    strDbName = conn.Database;
                    conn.Close();
                    break;

                case "access":
                    OleDbConnection connAcc = new OleDbConnection(strConn);
                    connAcc.Open();
                    var strTmp = connAcc.DataSource;
                    if (strTmp != null && strTmp.Contains(@"\"))
                    {
                        strDbName = strTmp.Substring(strTmp.LastIndexOf('\\') + 1);
                    }
                    connAcc.Close();
                    break;

                case "sqlite":
                    SQLiteConnection connSqlite = new SQLiteConnection(strConn);
                    connSqlite.Open();
                    strDbName = connSqlite.DataSource; // d:\xxxx\xxxx\data.mdb
                    connSqlite.Close();
                    break;

                case "mysql":
                    MySqlConnection connMy = new MySqlConnection(strConn);
                    connMy.Open();
                    strDbName = connMy.Database;
                    connMy.Close();
                    break;
            }
            return strDbName;
        }

        /// <summary>MSSQL中根据表名和连接字符串获取该表的主键
        ///
        /// </summary>
        /// <param name="strTableName"></param>
        /// <param name="strConn"></param>
        /// <returns></returns>
        public static string GetPKey_MSSQL(string strTableName, string strConn)
        {
            string tmp = "id";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_pkeys", conn) { CommandType = CommandType.StoredProcedure };
            SqlParameter p = new SqlParameter("@table_name", strTableName);
            cmd.Parameters.Add(p);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                tmp = dt.Rows[0]["COLUMN_NAME"].ToString();
            }
            return tmp;
        }

        /// <summary>access数据库中的默认值转为C#代码
        ///
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal static string DbDefaultToCSharp_Access(string p)
        {
            if (string.IsNullOrEmpty(p))
            {
                return "";
            }
            string str = "";
            if (p.Contains("Now()"))
            {
                str = "= DateTime.Now";
            }
            string pat = @"(\d+(\.\d+)?)";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(p);
            int intMatchCount = 0;
            if (m.Success)
            {
                ++intMatchCount;
                Group g = m.Groups[1];
                str = " = " + g.Value;
            }

            pat = "\"(.+?)\"";
            r = new Regex(pat, RegexOptions.IgnoreCase);
            m = r.Match(p);
            intMatchCount = 0;
            if (m.Success)
            {
                ++intMatchCount;
                Group g = m.Groups[1];
                str = " = \"" + g.Value + "\"";
            }
            return str;
        }

        /// <summary>mysql数据库中的默认值转为C#代码
        ///
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal static string DbDefaultToCSharp_MySQL(string p)
        {
            if (string.IsNullOrEmpty(p))
            {
                return "";
            }
            string str;
            if (p.Contains("CURRENT_TIMESTAMP"))
            {
                str = "= DateTime.Now";
            }
            else
            {
                const string strPat = @"^(\d+(\.\d+)?)$";
                Regex r = new Regex(strPat, RegexOptions.IgnoreCase);
                Match m = r.Match(p);
                int intMatchCount = 0;
                if (m.Success)
                {
                    ++intMatchCount;
                    Group g = m.Groups[1];
                    str = " = " + g.Value;
                }
                else
                {
                    str = " = \"" + p + "\"";
                }
            }

            return str;
        }

        /// <summary>根据类型生成SQLite的默认值
        ///
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal static string DbDefaultToCSharp_SQLite(string p)
        {
            if (p.ToLower().Contains("int"))
            {
                return " = 0";
            }
            else if (p.ToLower().Contains("datetime"))
            {
                return " = DateTime.Now";
            }
            else if (p.ToLower().Contains("float"))
            {
                return " = 0";
            }
            else if (p.ToLower().Contains("double"))
            {
                return " = 0";
            }
            else
            {
                return "";
            }
        }

        /// <summary>根据Access中的类型生成对应的C#类型
        ///
        /// </summary>
        /// <param name="intDbType"></param>
        /// <returns></returns>
        internal static string DbTypeToCSharpType_Access(int intDbType)
        {
            string str;
            switch (intDbType)
            {
                case 2: str = "int"; break;
                case 3: str = "int"; break;
                case 4: str = "Single"; break;
                case 5: str = "double"; break;
                case 6: str = "double"; break;
                case 7: str = "DateTime"; break;
                case 11: str = "bool"; break;
                case 17: str = "byte"; break;
                case 72: str = "string"; break;
                case 130: str = "string"; break;
                case 131: str = "double"; break;
                case 128: str = "string"; break;
                default: str = "string"; break;
            }
            return str;
        }

        /// <summary>根据mysql中的类型生成对应的C#类型
        ///
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal static string DbTypeToCSharpType_MySQL(string p)
        {
            string str = "string";
            switch (p.ToLower())
            {
                case "varchar":
                    str = "string";
                    break;

                case "text":
                    str = "string";
                    break;

                case "char":
                    str = "string";
                    break;

                case "decimal":
                    str = "double";
                    break;

                case "float":
                    str = "double";
                    break;

                case "double":
                    str = "double";
                    break;

                case "int":
                    str = "int";
                    break;

                case "datetime":
                    str = "DateTime";
                    break;

                case "timestamp":
                    str = "DateTime";
                    break;
            }
            return str;
        }

        /// <summary>根据 SQLITE中对应的类型生成相应的C#类型
        ///
        ///
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal static string DbTypeToCSharpType_SQLite(string p)
        {
            if (p.ToLower().Contains("int"))
            {
                return "int";
            }
            else if (p.ToLower().Contains("datetime"))
            {
                return "DateTime";
            }
            else if (p.ToLower().Contains("float"))
            {
                return "double";
            }
            else if (p.ToLower().Contains("double"))
            {
                return "double";
            }
            else
            {
                return "string";
            }
        }
    }
}