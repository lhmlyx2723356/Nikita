using Nikita.Assist.Logger.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.Base.Define;
using Nikita.DataAccess4DBHelper;

namespace Nikita.Assist.Logger
{
    public class LoggerHelper
    {
       /// <summary>获取日志操作对象
       /// 
       /// </summary>
       /// <returns></returns>
        public static ILog GetLogger()
        {
            string LogType = GetLogType();
            if (LogType == string.Empty)
            {
                return null;
            }
            ILog logger = null;
            switch (LogType.ToLower())
            {
                case "sqlitelog":
                    logger = new Nikita.Assist.Logger.DAL.LocalLogDAL();
                    break;
                case "sqlserverlog":
                    logger = new Nikita.Assist.Logger.DAL.SqlserverLogDAL();
                    break;
                case "mysqllog":
                    logger = new Nikita.Assist.Logger.DAL.MysqllogDAL();
                    break;
                case "oraclelog":
                    break;
                default:
                    break;
            }
            return logger;
        }

        /// <summary>获取数据库帮助类
        /// 
        /// </summary>
        /// <param name="strDBType">数据库类型</param>
        /// <param name="strConn">数据库连接字符串</param>
        /// <returns>数据库帮助类</returns>
        public static IDbHelper GetDBHelper(SqlType strDBType, string strConn)
        { 
            IDbHelper dbHelper = null;
            switch (strDBType)
            {
                case SqlType.SqlServer:
                    dbHelper = new MSSQLHelper(strConn);
                    break;
                case SqlType.MySql:
                    dbHelper = new MySQLHelper(strConn);
                    break;
                case SqlType.Oracle:
                    break; 
            }
            return dbHelper;
        }

        /// <summary>获取日志存储库连接字符串
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetConn()
        {
            string conn = string.Empty;
            if (!string.IsNullOrEmpty(StaticInfoHelper.ConnString))
            {
                conn = StaticInfoHelper.ConnString;
            }
            else
            {
                string strFilePath = Application.StartupPath + "\\log.ini";
                if (File.Exists(strFilePath))
                {
                    conn = INIOperationHelper.INIGetStringValue(strFilePath, "LogConnection", "Connection", null);
                    conn = DESEncryptHelper.Decrypt(conn, "test332211");
                    StaticInfoHelper.ConnString = conn;
                }
            }

            return conn;
        }

        /// <summary>获取日志存储类型
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetLogType()
        {
            //string val = ConfigurationManager.ConnectionStrings["LogConnection"].ProviderName; 
            //return val;
            string val = string.Empty;
            if (!string.IsNullOrEmpty(StaticInfoHelper.LogType))
            {
                val = StaticInfoHelper.LogType;
            }
            else
            {
                string strFilePath = Application.StartupPath + "\\log.ini";
                if (File.Exists(strFilePath))
                {
                    val = INIOperationHelper.INIGetStringValue(strFilePath, "LogType", "Type", null);
                    StaticInfoHelper.LogType = val;
                }
            }
            return val;
        }

        /// <summary>获取日志信息
        /// 
        /// </summary>
        /// <param name="strWhere">过滤条件</param>
        /// <returns></returns>
        public static DataSet GetLogInfo(string strWhere)
        {
            string LogType = GetLogType();
            if (LogType == string.Empty)
            {
                return null;
            }
            DataSet ds = new DataSet();
            switch (LogType.ToLower())
            {
                case "sqlitelog":
                    ds = new Nikita.Assist.Logger.DAL.LocalLogDAL().GetList(strWhere);
                    break;
                case "sqlserverlog":
                    ds = new Nikita.Assist.Logger.DAL.SqlserverLogDAL().GetList(strWhere);
                    break;
                case "mysqllog":
                    ds = new Nikita.Assist.Logger.DAL.MysqllogDAL().GetList(strWhere);
                    break;
                case "oraclelog":
                    break;
                default:
                    break;
            }
            return ds;
        }


    }
}
