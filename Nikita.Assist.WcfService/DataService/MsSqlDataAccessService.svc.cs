using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Nikita.Assist.WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MsSqlDataAccessService”。
    public class MsSqlDataAccessService : IMsSqlDataAccessService
    {
        private readonly string _connStr = ConfigurationManager.ConnectionStrings["Permission"].ToString();
        private SqlCommand _cmd;
        private SqlConnection _conn;
        private SqlDataAdapter _sda;
        private SqlDataReader _sdr;
        /// <summary>添加输出参数
        /// 用于存储过程
        /// </summary>
        /// <param name="paramName">参数名称</param>
        public void AddOutputParameter(string paramName)
        {
            SqlParameter p = new SqlParameter
            {
                ParameterName = paramName,
                Direction = ParameterDirection.Output,
                Size = 20
            };
            _cmd.Parameters.Add(p);
        }

        /// <summary>添加参数
        /// 默认是输入参数
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="value">值</param>
        public void AddParameter(string paramName, object value)
        {
            SqlParameter p = new SqlParameter(paramName, value);
            _cmd.Parameters.Add(p);
        }

        /// <summary>关闭数据库连接
        /// 
        /// </summary>
        public void CloseConn()
        {
            try
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
        }

        /// <summary>创建Command对象
        /// 默认是SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public void CreateCommand(string sql)
        {
            if (_conn == null)
            {
                GetConn();
            }
            if (_conn != null && _conn.State != ConnectionState.Open)
            {
                _conn.Open();
            }
            _cmd = new SqlCommand(sql, _conn);
        }

        /// <summary>创建存储过程的Command对象
        /// 
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        public void CreateStoredCommand(string procName)
        {
            if (_conn == null)
            {
                GetConn();
            }
            if (_conn != null && _conn.State != ConnectionState.Open)
            {
                _conn.Open();
            }
            _cmd = new SqlCommand(procName, _conn) { CommandType = CommandType.StoredProcedure };
        }

        /// <summary>批量插入一张表数据
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tableName"></param>
        public void ExecuteBulkToDb(DataTable dt, string tableName)
        {
            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }
            SqlBulkCopy bulkCopy = new SqlBulkCopy(_conn) { DestinationTableName = tableName, BatchSize = dt.Rows.Count };
            try
            {
                if (dt.Rows.Count != 0)
                    bulkCopy.WriteToServer(dt);
            }
            finally
            {
                _conn.Close();
                bulkCopy.Close();
            }
        }

        /// <summary>批量删除表中条件为Filter的数据 
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="filter"></param>
        public DataTable ExecuteDeleteBatchData(string tableName, string filter)
        {
            CreateStoredCommand("Sp_Execute_Delete_BatchDate");
            AddParameter("@TableName", tableName);
            AddParameter("@Filter", filter);
            DataTable dt = ExecuteQueryDataTable();
            return dt;
        }

        /// <summary>获取表中条件为Filter的数据 (自定义列，当ColumnNames=*表示全部)
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="filter"></param>
        /// <param name="columnNames"></param>
        public DataTable ExecuteGetBatchData(string tableName, string filter, string columnNames)
        {
            CreateStoredCommand("Sp_Execute_Get_BatchDate");
            AddParameter("@TableName", tableName);
            AddParameter("@Filter", filter);
            AddParameter("@ColumnNames", columnNames);
            DataTable dt = ExecuteQueryDataTable();
            return dt;
        }

        /// <summary>执行增删改SQL语句或存储过程
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

        /// <summary>执行查询SQL语句或存储过程
        ///  
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteQuery()
        {
            DataTable dt = new DataTable() { TableName = "WcfDataTable" };
            try
            {
                using (_sdr = _cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    dt.Load(_sdr);
                }

            }
            finally
            {

                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }

            return dt;
        }

        /// <summary>执行查询SQL语句或存储过程返回DataSet
        ///  
        /// </summary>
        /// <returns></returns>
        public DataSet ExecuteQueryDataSet()
        {
            DataSet ds = new DataSet();
            try
            {
                _sda = new SqlDataAdapter(_cmd);
                _sda.Fill(ds);
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return ds;
        }

        /// <summary>执行查询SQL语句或存储过程返回DataTable
        ///  
        /// </summary>
        /// <returns></returns>
        public DataTable ExecuteQueryDataTable()
        {
            DataTable dt = new DataTable() { TableName = "WcfDataTable" };
            try
            {
                using (_sdr = _cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    dt.Load(_sdr);
                }
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return dt;
        }

        /// <summary>返回查询SQL语句或存储过程查询出的结果的第一行第一列的值
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
            finally
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            return res;
        }

        /// <summary>批量更新表中条件为Filter的数据 
        /// 
        /// </summary>
        /// <returns></returns>
        /// <summary>批量更新表中条件为Filter的数据 
        /// 
        /// </summary>
        /// <param name="tableName">
        /// </param>
        /// <param name="filter">
        /// </param>
        /// <param name="setValues">
        /// </param>
        /// <returns></returns>
        public DataTable ExecuteUpdateBatchData(string tableName, string filter, string setValues)
        {
            CreateStoredCommand("Sp_Execute_Update_BatchDate");
            AddParameter("@TableName", tableName);
            AddParameter("@Filter", filter);
            AddParameter("@SetValues", setValues);
            DataTable dt = ExecuteQueryDataTable();
            return dt;
        }

        public void ExecuteWithTran(string cmdText)
        {
            SqlConnection con = GetConn();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlTransaction tran = con.BeginTransaction();
            //先实例SqlTransaction类，使用这个事务使用的是con 这个连接，使用BeginTransaction这个方法来开始执行这个事务 
            SqlCommand cmd = new SqlCommand { Connection = con, Transaction = tran };
            try
            {
                //在try{} 块里执行sqlcommand命令， 
                cmd.CommandText = cmdText;
                tran.Commit(); //如果两个sql命令都执行成功，则执行commit这个方法，执行这些操作   
            }
            catch
            {
                tran.Rollback(); //如何执行不成功，发生异常，则执行rollback方法，回滚到事务操作开始之前； 
            }
            finally
            {
                con.Close();
                tran.Dispose();
                con.Dispose();
            }
        }

        public SqlConnection GetConn()
        {
            _conn = new SqlConnection(_connStr);
            return _conn;
        }
        /// <summary>获取输出参数的值
        /// 
        /// </summary>
        /// <param name="paramName">输出参数名称</param>
        /// <returns></returns>
        public string GetOutputParameter(string paramName)
        {
            return _cmd.Parameters[paramName].Value.ToString();
        }
    }
}
