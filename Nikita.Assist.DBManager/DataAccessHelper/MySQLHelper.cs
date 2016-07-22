using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nikita.Assist.DBManager.DAL
{
    /// <summary>对MYSQL数据库的操作类
    ///
    /// </summary>
    public class MySQLHelper : IDBHelper
    {
        private MySqlCommand cmd = null;
        private MySqlConnection conn = null;
        private MySqlDataAdapter sda = null;
        private MySqlDataReader sdr = null;

        public MySQLHelper(string strConn)
        {
            conn = new MySqlConnection(strConn);
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
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                transcation = conn.BeginTransaction();
                using (var command = new MySqlCommand())
                {
                    if (command == null)
                    {
                        throw new ArgumentException("command");
                    }
                    command.Connection = conn;
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

                    for (int i = 0; i < lstAutoName.Count; i++)
                    {
                        dataTable.Columns.Remove(lstAutoName[i]);
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
                        for (int j = 0; j < paras.Length; j++)
                        {
                            paras[j].Value = dataTable.Rows[i][paras[j].ParameterName].ToString();
                        }
                        command.ExecuteNonQuery();
                    }
                    transcation.Commit();
                }
            }
            catch (Exception exp)
            {
                if (transcation != null)
                {
                    transcation.Rollback();
                }

                throw exp;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
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

        /// <summary>创建Command对象
        ///
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public void CreateCommand(string sql)
        {
            conn.Open();
            cmd = new MySqlCommand(sql, conn);
        }

        /// <summary>创建Command对象
        ///
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public void CreateStoredCommand(string sql)
        {
            conn.Open();
            cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
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

        /// <summary>执行查询SQL语句或存储过程返回DataSet
        ///
        /// </summary>
        /// <returns></returns>
        public DataSet ExecuteQueryDataSet()
        {
            DataSet ds = new DataSet();
            try
            {
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                if (!ex.ToString().Contains("操作已被用户取消"))
                {
                    throw ex;
                }
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        /// <summary>返回IDataReader
        ///
        /// </summary>
        /// <returns></returns>
        public IDataReader ExecuteReader()
        {
            return cmd.ExecuteReader();
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

        public string ReturnRunMessage()
        {
            return "MySQL不返回执行信息";
        }

        public void StopRunSql()
        {
            if (cmd != null)
            {
                cmd.Cancel();
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
                if (dt.Columns[i].AutoIncrement == true)
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
                if (dt.Columns[i].AutoIncrement == true)
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