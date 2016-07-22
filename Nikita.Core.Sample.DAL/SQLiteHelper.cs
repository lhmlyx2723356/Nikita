/*
 * 作者: UsTeam
 * 创建时间: 2010-1-20 10:43:14
 * Email: 871939149@qq.com
 * 说明: 对SQLite数据库的增删查改操作的封装类
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace Nikita.Core.Sample.DAL
{
    public partial class SQLiteHelper
    {
        private SQLiteConnection conn = null;
        private SQLiteCommand cmd = null;
        private SQLiteDataReader sdr = null;


        public SQLiteHelper()
        {
            string connStr = "Data Source=" + Application.StartupPath + "\\SQLiteDB\\" + GetConfigKeyValue("Source"); 
            conn = new SQLiteConnection(connStr);
        }


        /// <summary>创建Command对象
        /// 
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public void CreateCommand(string sql)
        {
            conn.Open();
            cmd = new SQLiteCommand(sql, conn);
        }

        /// <summary>获取当前运行项目所对应的config里的Setting里Key为'SetKey'
        /// 所对应的value值 
        /// </summary>
        /// <param name="SetKey">App.config里设置的key值</param>
        /// <returns></returns>
        public static string GetConfigKeyValue(string SetKey)
        {
            string val = string.Empty;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(SetKey))
            {
                val = ConfigurationManager.AppSettings[SetKey];
            }
            return val;
            //方法二
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //return config.AppSettings.Settings[SetKey].Value.ToString();
        }

        /// <summary>添加参数
        /// 
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="value">值</param>
        public void AddParameter(string paramName, object value)
        {
            cmd.Parameters.Add(new SQLiteParameter(paramName, value));
        }


        /// <summary>执行不带参数的增删改SQL语句
        ///  
        /// </summary>
        /// <param name="cmdText">增删改SQL语句</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public bool ExecuteNonQuery()
        {
            int res;
            try
            {
                res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return false;
        }


        /// <summary>执行查询SQL语句
        ///  
        /// </summary>
        /// <param name="cmdText">查询SQL语句</param>
        /// <returns></returns>
        public DataTable ExecuteQuery()
        {
            DataTable dt = new DataTable();
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }


        /// <summary>分页  
        ///   
        /// </summary>  
        /// <param name="tblName">表名</param>  
        /// <param name="fldName">字段名</param>  
        /// <param name="OrderfldName">排序字段名</param>  
        /// <param name="OrderType">排序方式：asc或者desc</param>  
        /// <param name="strWhere">条件，不用加where</param>  
        /// <param name="PageSize">页大小</param>  
        /// <param name="PageIndex">页索引</param>  
        /// <returns></returns> 
        public DataTable FengYe(string tblName, string fldName, string OrderfldName, string OrderType, string strWhere, int PageSize, int PageIndex)
        {
            DataTable dt = new DataTable();
            int start = (PageIndex - 1) * PageSize;
            string sql = "";
            if (!string.IsNullOrEmpty(strWhere))
            {
                // 条件不为空
                sql = string.Format("select {0} from {1} where {2} order by {3} {4} limit {5},{6}", fldName,
                    tblName, strWhere, OrderfldName, OrderType, start, PageSize);
            }
            else
            {
                // 条件为空
                sql = string.Format("select {0} from {1} order by {2} {3} limit {4},{5}", fldName,
                    tblName, OrderfldName, OrderType, start, PageSize);
            }
            CreateCommand(sql);
            dt = ExecuteQuery();
            return dt;
        }


        /// <summary>返回查询SQL语句查询出的结果的第一行第一列的值
        /// 
        /// </summary>
        /// <returns></returns>
        public string ExecuteScalar()
        {
            string res = "";
            try
            {
                object obj = cmd.ExecuteScalar();
                if (obj != null)
                {
                    res = obj.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return res;
        }


        /// <summary>返回IDataReader
        /// 
        /// </summary>
        /// <returns></returns>
        public IDataReader ExecuteReader()
        {
            return cmd.ExecuteReader();
        }

        /// <summary>关闭数据库
        /// 
        /// </summary>
        public void CloseConn()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}


