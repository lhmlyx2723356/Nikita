/*
 * 作者: luhm
 * 创建时间: 2010-1-20 10:43:14
 * Email: 871939149@qq.com
 * 说明: 对SQLite数据库的增删查改操作的封装类
 */

using System;
using System.Data;
using System.Data.SQLite;
using System.Web;
using System.Windows.Forms;

namespace FrmEmailSend.DAL
{
    public class SQLiteHelper
    {
        private readonly SQLiteConnection _conn;
        private SQLiteCommand _cmd;
        private SQLiteDataReader _sdr;

        public SQLiteHelper()
        {
            string strApplicationStart = Application.StartupPath;
            string connStr = "Data Source=" + strApplicationStart + "\\EmailLocalDB.db";
            _conn = new SQLiteConnection(connStr);
        }

        /// <summary>添加参数
        ///
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="value">值</param>
        public void AddParameter(string paramName, object value)
        {
            _cmd.Parameters.Add(new SQLiteParameter(paramName, value));
        }

        /// <summary>关闭数据库
        ///
        /// </summary>
        public void CloseConn()
        {
            if (_conn.State == ConnectionState.Open)
            {
                _conn.Close();
            }
        }

        /// <summary>创建Command对象
        ///
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public void CreateCommand(string sql)
        {
            _conn.Open();
            _cmd = new SQLiteCommand(sql, _conn);
        }

        /// <summary>执行不带参数的增删改SQL语句
        ///
        /// </summary>
        /// <returns></returns>
        public bool ExecuteNonQuery()
        {
            try
            {
                var res = _cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    return true;
                }
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return false;
        }

        /// <summary>执行查询SQL语句
        ///
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteQuery()
        {
            DataTable dt = new DataTable();
            using (_sdr = _cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(_sdr);
            }
            return dt;
        }

        /// <summary>返回IDataReader
        ///
        /// </summary>
        /// <returns></returns>
        public IDataReader ExecuteReader()
        {
            return _cmd.ExecuteReader();
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
                object obj = _cmd.ExecuteScalar();
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
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return res;
        }

        /// <summary>分页
        ///
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="fldName">字段名</param>
        /// <param name="strOrderfldName">排序字段名</param>
        /// <param name="strOrderType">排序方式：asc或者desc</param>
        /// <param name="strWhere">条件，不用加where</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="intPageIndex">页索引</param>
        /// <returns></returns>
        public DataTable FengYe(string tblName, string fldName, string strOrderfldName, string strOrderType, string strWhere, int intPageSize, int intPageIndex)
        {
            int start = (intPageIndex - 1) * intPageSize;
            string sql;
            if (!string.IsNullOrEmpty(strWhere))
            {
                // 条件不为空
                sql = string.Format("select {0} from {1} where {2} order by {3} {4} limit {5},{6}", fldName,
                    tblName, strWhere, strOrderfldName, strOrderType, start, intPageSize);
            }
            else
            {
                // 条件为空
                sql = string.Format("select {0} from {1} order by {2} {3} limit {4},{5}", fldName,
                    tblName, strOrderfldName, strOrderType, start, intPageSize);
            }
            CreateCommand(sql);
            var dt = ExecuteQuery();
            return dt;
        }
    }
}