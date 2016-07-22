using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Nikita.Assist.CodeMaker.DAL
{
    /// <summary>MSSQL数据库操作类
    ///
    /// </summary>
    public class MSSQLHelper : IDbHelper
    {
        private readonly SqlConnection _conn;
        private SqlCommand _cmd;
        private SqlDataAdapter _sda;
        private SqlDataReader _sdr;
        private string strRunMessage;

        public MSSQLHelper(string strConn)
        {
            _conn = new SqlConnection(strConn) { StatisticsEnabled = true, FireInfoMessageEventOnUserErrors = true };
            _conn.InfoMessage += conn_InfoMessage;
        }

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

        /// <summary>
        /// 将 <see cref="DataTable"/> 的数据批量插入到数据库中。
        /// </summary>
        /// <param name="dataTable">要批量插入的 <see cref="DataTable"/>。</param>
        /// <param name="batchSize">每批次写入的数据量。</param>
        public void BatchInsert(DataTable dataTable, int batchSize = 10000)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return;
            }

            try
            {
                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                }
                //给表名加上前后导符
                var tableName = dataTable.TableName;
                using (var bulk = new SqlBulkCopy(_conn, SqlBulkCopyOptions.KeepIdentity, null)
                    {
                        DestinationTableName = tableName,
                        BatchSize = batchSize
                    })
                {
                    //循环所有列，为bulk添加映射
                    foreach (DataColumn item in dataTable.Columns)
                    {
                        if (item.AutoIncrement)
                        {
                            continue;
                        }
                        bulk.ColumnMappings.Add(item.ColumnName, item.ColumnName);
                    }
                    bulk.WriteToServer(dataTable);
                    bulk.Close();
                }
            }
            finally
            {
                if (_conn.State != ConnectionState.Closed)
                {
                    _conn.Close();
                }
            }
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
            _conn.Open();
            _cmd = new SqlCommand(sql, _conn) { CommandTimeout = 600 };
        }

        /// <summary>创建存储过程的Command对象
        ///
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        public void CreateStoredCommand(string procName)
        {
            _conn.Open();
            _cmd = new SqlCommand(procName, _conn) { CommandType = CommandType.StoredProcedure };
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
            DataTable dt = new DataTable();
            using (_sdr = _cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(_sdr);
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
            catch (Exception ex)
            {
                if (!ex.ToString().Contains("操作已被用户取消"))
                {
                    throw;
                }
            }
            finally
            {
                _conn.Close();
            }
            return ds;
        }

        /// <summary>返回IDataReader只读数据流
        ///
        /// </summary>
        /// <returns></returns>
        public IDataReader ExecuteReader()
        {
            _sdr = _cmd.ExecuteReader();
            return _sdr;
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

        /// <summary>获取输出参数的值
        ///
        /// </summary>
        /// <param name="paramName">输出参数名称</param>
        /// <returns></returns>
        public string GetOutputParameter(string paramName)
        {
            return _cmd.Parameters[paramName].Value.ToString();
        }

        public string ReturnRunMessage()
        {
            if (string.IsNullOrEmpty(strRunMessage))
            {
                StringBuilder sb = new StringBuilder();
                foreach (DictionaryEntry de in _conn.RetrieveStatistics())
                {
                    sb.AppendLine(de.Key + ":" + de.Value);
                }
                return sb.ToString();
            }
            return strRunMessage;
        }

        public void StopRunSql()
        {
            if (_cmd != null)
            {
                _cmd.Cancel();
            }
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

        private void conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            strRunMessage = e.Message;
        }
    }
}