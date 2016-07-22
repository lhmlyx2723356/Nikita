using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Nikita.Assist.SimpleCodeMaker
{
    public class GenExtendClass
    {
        /// <summary>生成DAL代码
        /// 基于UsTeam数据库操作类
        /// </summary>
        /// <param name="ns">命名空间</param>
        /// <param name="tabname">表名</param>
        /// <param name="classname">类名</param>
        /// <param name="connstr">数据库连接字符串</param>
        /// <returns></returns>
        public static string GenMssqlExtend(string ns, string tabname, string classname, string connstr)
        {
            #region 生成DAL代码
            
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + @"\classtemp\MSSQLDALTempExtend.txt");
            sb.Append(sr.ReadToEnd());
            sb = sb.Replace("@namespace@", ns);
            sb = sb.Replace("@tabname@", tabname);
            sb = sb.Replace("@createdate@", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb = sb.Replace("@classname@", classname);
             
            return sb.ToString();
            #endregion
        }



        public static string GenMysqlExtend(string ns, string tabname, string classname, string connstr)
        {
            #region 生成DAL代码

            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + @"\classtemp\MySQLDALTempExtend.txt");
            sb.Append(sr.ReadToEnd());
            sb = sb.Replace("@namespace@", ns);
            sb = sb.Replace("@tabname@", tabname);
            sb = sb.Replace("@createdate@", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb = sb.Replace("@classname@", classname);

            return sb.ToString();
            #endregion
        }



        public static string GenSqliteExtend(string ns, string tabname, string classname, string connstr)
        {
            #region 生成DAL代码

            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + @"\classtemp\SQLiteDALTempExtend.txt");
            sb.Append(sr.ReadToEnd());
            sb = sb.Replace("@namespace@", ns);
            sb = sb.Replace("@tabname@", tabname);
            sb = sb.Replace("@createdate@", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb = sb.Replace("@classname@", classname);

            return sb.ToString();
            #endregion
        }


        public static string GenAccessExtend(string ns, string tabname, string classname, string connstr)
        {
            #region 生成DAL代码

            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + @"\classtemp\AccessDALTempExtend.txt");
            sb.Append(sr.ReadToEnd());
            sb = sb.Replace("@namespace@", ns);
            sb = sb.Replace("@tabname@", tabname);
            sb = sb.Replace("@createdate@", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb = sb.Replace("@classname@", classname);

            return sb.ToString();
            #endregion
        }
    }
}
