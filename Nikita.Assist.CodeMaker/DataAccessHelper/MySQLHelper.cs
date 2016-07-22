using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nikita.Assist.CodeMaker.DAL
{
    /// <summary>对MYSQL数据库的操作类
    ///
    /// </summary>
    public class MySQLHelper : IDbHelper
    {
        private readonly MySqlConnection _conn;
        private MySqlCommand _cmd;
        private MySqlDataAdapter _sda;
        private MySqlDataReader _sdr;

        public MySQLHelper(string strConn)
        {
            _conn = new MySqlConnection(strConn);
        }

        /// <summary>添加参数
        ///
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="value">值</param>
        public void AddParameter(string paramName, object value)
        {
            _cmd.Parameters.Add(new MySqlParameter(paramName, value));
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
            MySqlTransaction transcation = null;
            try
            {
                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                }

                transcation = _conn.BeginTransaction();
                using (var command = new MySqlCommand())
                {
                    command.Connection = _conn;
                    command.Transaction = transcation;
                    command.CommandText = GenerateInserSql(dataTable);
                    if (command.CommandText == string.Empty)
                    {
                        return;
                    }
                    List<string> lstName = new List<string>();
                    List<string> lstAutoName = new List<string>();
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        if (dataTable.Columns[i].AutoIncrement)
                        {
                            lstAutoName.Add(dataTable.Columns[i].ToString());
                        }
                        else
                        {
                            lstName.Add(dataTable.Columns[i].ColumnName);
                        }
                    }

                    foreach (string t in lstAutoName)
                    {
                        dataTable.Columns.Remove(t);
                    }

                    MySqlParameter[] paras = new MySqlParameter[lstName.Count];
                    for (int i = 0; i < paras.Length; i++)
                    {
                        paras[i] = command.CreateParameter();
                        paras[i].ParameterName = lstName[i];
                    }
                    command.Parameters.AddRange(paras);
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        foreach (MySqlParameter t in paras)
                        {
                            t.Value = dataTable.Rows[i][t.ParameterName].ToString();
                        }
                        command.ExecuteNonQuery();
                    }
                    transcation.Commit();
                }
            }
            catch (Exception)
            {
                if (transcation != null)
                {
                    transcation.Rollback();
                }

                throw;
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
            _cmd = new MySqlCommand(sql, _conn);
        }

        /// <summary>创建Command对象
        ///
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public void CreateStoredCommand(string sql)
        {
            _conn.Open();
            _cmd = new MySqlCommand(sql, _conn) { CommandType = CommandType.StoredProcedure };
        }

        ///  <summary>执行不带参数的增删改SQL语句
        ///
        ///  </summary>
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

        ///  <summary>执行查询SQL语句
        ///
        ///  </summary>
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
                _sda = new MySqlDataAdapter(_cmd);
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
        /// <param name="strTabName"></param>
        /// <param name="strFileds"></param>
        /// <param name="strOrder"></param>
        /// <param name="strOrderType"></param>
        /// <param name="strWhere"></param>
        /// <param name="intPageSize"></param>
        /// <param name="intPageIndex"></param>
        /// <returns></returns>
        public DataTable FengYe(string strTabName, string strFileds, string strOrder, string strOrderType, string strWhere, int intPageSize, int intPageIndex)
        {
            int xb = intPageSize * (intPageIndex - 1);
            string sql = "SELECT " + strFileds + " FROM `" + strTabName + "`";
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql += " where " + strWhere;
            }
            sql += " order by " + strOrder + " " + strOrderType + " limit " + xb + "," + intPageSize;
            CreateCommand(sql);
            return ExecuteQuery();
        }

        public string ReturnRunMessage()
        {
            return "MySQL不返回执行信息";
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

        private string GenerateInserSql(DataTable dt)
        {
            StringBuilder strInsert = new StringBuilder();
            strInsert.Append("INSERT INTO ");
            strInsert.Append(dt.TableName);
            strInsert.Append("  (");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].AutoIncrement)
                {
                    continue;
                }
                if (i == dt.Columns.Count - 1)
                {
                    strInsert.Append(dt.Columns[i].ColumnName);
                }
                else
                {
                    strInsert.Append(dt.Columns[i].ColumnName + ",");
                }
            }
            strInsert.Append(" )");
            strInsert.Append(" VALUES (");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].AutoIncrement)
                {
                    continue;
                }
                if (i == dt.Columns.Count - 1)
                {
                    strInsert.Append("@" + dt.Columns[i].ColumnName);
                }
                else
                {
                    strInsert.Append("@" + dt.Columns[i].ColumnName + ",");
                }
            }
            strInsert.Append("   ) ");
            return strInsert.ToString();
        }
    }
}