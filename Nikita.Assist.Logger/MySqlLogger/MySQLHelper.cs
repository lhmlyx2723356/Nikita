using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Nikita.Assist.Logger.DAL
{
    /// <summary>对MYSQL数据库的操作类
    /// 
    /// </summary>
    public class MySQLHelper :IDBHelper
    {
        private MySqlConnection conn = null;
        private MySqlCommand cmd = null;
        private MySqlDataReader sdr = null;


        public MySQLHelper()
        {
            string connStr =LoggerHelper.GetConn();
            conn = new MySqlConnection(connStr);
        }

        public MySQLHelper(string strConn)
        {
            conn = new MySqlConnection(strConn);
        }

  

        /// <summary>创建Command对象
        /// 
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public void CreateCommand(string sql)
        {
            conn.Open();
            cmd = new MySqlCommand(sql, conn);
        }


        /// <summary>添加参数
        /// 
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="value">值</param>
        public void AddParameter(string paramName, object value)
        {
            cmd.Parameters.Add(new MySqlParameter(paramName, value));
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

        /// <summary>关闭数据库连接
        /// 
        /// </summary>
        public void CloseConn()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        /// <summary>分页
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="fileds"></param>
        /// <param name="order"></param>
        /// <param name="ordertype"></param>
        /// <param name="strWhere"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public DataTable FengYe(string tabname, string fileds, string order, string ordertype, string strWhere, int PageSize, int PageIndex)
        {
            int xb = PageSize * (PageIndex - 1);
            string sql = "SELECT " + fileds + " FROM `" + tabname + "`";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql += " where " + strWhere;
            }
            sql += " order by " + order + " " + ordertype + " limit " + xb + "," + PageSize;
            CreateCommand(sql);
            return ExecuteQuery();
        }

        public bool TestConn()
        {
            bool blnIsConnect = false;
             CreateCommand("select 1");
            if (ExecuteQuery().Rows.Count > 0)
            {
                blnIsConnect = true;
            }
            return blnIsConnect;
        }
    }

}
