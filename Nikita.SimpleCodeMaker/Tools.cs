using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace Nikita.Assist.SimpleCodeMaker
{
    public class Tools
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
            string pat = @"\(\((\d+)\)\)";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(p);
            int matchCount = 0;
            if (m.Success)
            {
                ++matchCount;
                Group g = m.Groups[1];
                str = " = " + g.Value;
            }

            pat = @"\(N?'(.+)'\)";
            r = new Regex(pat, RegexOptions.IgnoreCase);
            m = r.Match(p);
            matchCount = 0;
            if (m.Success)
            {
                ++matchCount;
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
            string pat = @"\(\((\d+)\)\)";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(val);
            int matchCount = 0;
            if (m.Success)
            {
                ++matchCount;
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

            pat = @"\(N?'(.+)'\)";
            r = new Regex(pat, RegexOptions.IgnoreCase);
            m = r.Match(val);
            matchCount = 0;
            if (m.Success)
            {
                ++matchCount;
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
         

        /// <summary>数据库类型转换为C#的类型
        /// 
        /// </summary>
        /// <param name="p">数据库中的类型</param>
        /// <param name="isnull">是否可为空，0否1是</param>
        /// <returns></returns>
        public static string DbTypeToCSharpType(string p, string isnull)
        {
            string str = "";
            if (p.Contains("int"))
            {

                str = isnull == "0" ? "int" : "int?";

            }
            else if (p.Contains("bit"))
            {
                str = isnull == "0" ? "bool" : "bool?";
            }
            else if (p.Contains("datetime"))
            {
                str = isnull == "0" ? "DateTime" : "DateTime?";
            }
            else if (p.Contains("float"))
            {
                str = isnull == "0" ? "float" : "float?";
            }
            else if (p.Contains("decimal"))
            {
                str = isnull == "0" ? "double" : "double?";
            }
            else
            {
                str = "string";
            }
            return str;
        }
         
        /// <summary>数据库中的类型转为C#中的DbType.后面的值
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string DbTypeToCSharpDbType(string p)
        {

            {
                string str = "";
                switch (p)
                {
                    case "int":
                        str = "Int32";
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


        /// <summary>MSSQL中根据表名和连接字符串获取该表的主键
        /// 
        /// </summary>
        /// <param name="tabname"></param>
        /// <param name="connstr"></param>
        /// <returns></returns>
        public static string GetPKey_MSSQL(string tabname, string connstr)
        {
            string tmp = "id";
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_pkeys", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@table_name", tabname);
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


        /// <summary>取数据库名称
        /// 
        /// </summary>
        /// <param name="dbtype">数据库类型</param>
        /// <param name="connstr">连接字符串</param>
        /// <returns></returns>
        public static string GetDBName(string dbtype, string connstr)
        {
            string dbname = "";
            string tmp = "";
            dbtype = dbtype.ToLower().Replace(" ", "");
            switch (dbtype)
            {
                case "sqlserver":
                    SqlConnection conn = new SqlConnection(connstr);
                    conn.Open();
                    dbname = conn.Database;
                    conn.Close();
                    break;
                case "access":
                    OleDbConnection conn_acc = new OleDbConnection(connstr);
                    conn_acc.Open();
                    tmp = conn_acc.DataSource; // d:\xxxx\xxxx\data.mdb
                    if (tmp.Contains(@"\"))
                    {
                        dbname = tmp.Substring(tmp.LastIndexOf('\\') + 1);
                    }
                    conn_acc.Close();
                    break;
                case "sqlite":
                    SQLiteConnection conn_sqlite = new SQLiteConnection(connstr);
                    conn_sqlite.Open();
                    dbname = conn_sqlite.DataSource; // d:\xxxx\xxxx\data.mdb
                    conn_sqlite.Close();
                    break;
                case "mysql":
                    MySqlConnection conn_my = new MySqlConnection(connstr);
                    conn_my.Open();
                    dbname = conn_my.Database;
                    conn_my.Close();
                    break;
                default:
                    break;
            }
            return dbname;
        }
         
        /// <summary>根据Access中的类型生成对应的C#类型
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal static string DbTypeToCSharpType_Access(int p)
        {
            string str = "";
            switch (p)
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
                default:
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
            int matchCount = 0;
            if (m.Success)
            {
                ++matchCount;
                Group g = m.Groups[1];
                str = " = " + g.Value;
            }

            pat = "\"(.+?)\"";
            r = new Regex(pat, RegexOptions.IgnoreCase);
            m = r.Match(p);
            matchCount = 0;
            if (m.Success)
            {
                ++matchCount;
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
            string str = "";
            if (p.Contains("CURRENT_TIMESTAMP"))
            {
                str = "= DateTime.Now";
            }
            else
            {
                string pat = @"^(\d+(\.\d+)?)$";
                Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                Match m = r.Match(p);
                int matchCount = 0;
                if (m.Success)
                {
                    ++matchCount;
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
    }
}
