/*
 * 说明: 对SQLite数据库的增删查改操作的封装类
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Text;

namespace Nikita.Assist.WcfConfiguration
{
    public partial class SQLiteHelper : IDBHelper
    {
        private SQLiteCommand cmd = null;
        private SQLiteConnection conn = null;
        private SQLiteDataAdapter sda = null;
        private SQLiteDataReader sdr = null;

        public SQLiteHelper(string connStr)
        {
            conn = new SQLiteConnection(connStr);
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

            DbTransaction transcation = null;
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                transcation = conn.BeginTransaction();
                using (var command = new SQLiteCommand())
                {
                    if (command == null)
                    {
                        throw new ArgumentException("command");
                    }
                    command.Connection = conn;
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

                    SQLiteParameter[] paras = new SQLiteParameter[lstName.Count];
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
                            paras[j].Value = dataTable.Rows[i][paras[j].ParameterName];
                        }
                        command.ExecuteNonQuery();
                    }
                }
                transcation.Commit();
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
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

        /// <summary>创建Command对象
        ///
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public void CreateCommand(string sql)
        {
            conn.Open();
            cmd = new SQLiteCommand(sql, conn);
        }

        /// <summary>创建Command对象
        ///
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public void CreateStoredCommand(string sql)
        {
            throw new Exception("SQLite不支持存储过程");
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
                sda = new SQLiteDataAdapter(cmd);
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

        public string ReturnRunMessage()
        {
            return "SQLite不返回执行信息";
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