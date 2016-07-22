using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;

namespace Nikita.Assist.WcfService
{
    /// <summary>
    /// DbHelper 的摘要说明
    /// </summary>
    ///

    public class MyTransaction
    {
        private readonly DbCommand _command;
        private readonly DbTransaction _transaction;

        private MyTransaction(DbCommand cmd)
        {
            cmd.CommandTimeout = 100;
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            cmd.Transaction = cmd.Connection.BeginTransaction();
            _transaction = cmd.Transaction;
            _command = cmd;
        }

        public static MyTransaction BeginTransaction(DbCommand cmd)
        {
            return new MyTransaction(cmd);
        }

        public void Commit()
        {
            if (_transaction.Connection != null)
            {
                _transaction.Commit();
            }
            Close();
        }

        public void Rollback()
        {
            if (_transaction.Connection != null)
            {
                _transaction.Rollback();
            }
            Close();
        }

        private void Close()
        {
            if (_transaction.Connection != null)
            {
                _transaction.Connection.Close();
                _transaction.Connection.Dispose();
            }
            if (_command.Connection != null && _command.Connection.State == ConnectionState.Open)
            {
                _command.Connection.Close();
                _command.Connection.Dispose();
            }
            if (_command != null)
            {
                _command.Dispose();
            }
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
        }
    }

    public class SimpDataDBHelper
    {
        //数据库连接字串
        private const string DbConnectionString = "";

        //数据类型
        private const string DbProviderName = "System.Data.SqlClient";

        private readonly DbConnection _connection;

        //构造函数
        public SimpDataDBHelper()
        {
            _connection = CreateConnection(DbConnectionString);
        }

        public SimpDataDBHelper(string connectionString)
        {
            _connection = CreateConnection(connectionString);
        }

        public SimpDataDBHelper(string dbServer, string dbCatalog, string dbUid, string dbPwd)
        {
            _connection = CreateConnection("server=" + dbServer + ";database=" + dbCatalog + ";uid=" + dbUid + ";pwd=" + dbPwd);
        }

        public static DbConnection CreateConnection()
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DbProviderName);
            DbConnection dbconn = dbfactory.CreateConnection();
            if (dbconn != null)
            {
                dbconn.ConnectionString = DbConnectionString;
            }
            return dbconn;
        }

        public static DbConnection CreateConnection(string connectionString)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DbProviderName);
            DbConnection dbconn = dbfactory.CreateConnection();
            if (dbconn != null)
            {
                dbconn.ConnectionString = connectionString;
            }
            return dbconn;
        }

        /// <summary>
        /// 直接执行sql语句,适应于数据表的增,删,改操作
        /// </summary>
        /// <param name="sqlQuery">SQL语句</param>
        /// <returns>返回dbCommand对象</returns>
        public DbCommand GetSqlStringCommond(string sqlQuery)
        {
            DbCommand dbCommand = _connection.CreateCommand();
            dbCommand.CommandText = sqlQuery;
            dbCommand.CommandType = CommandType.Text;
            return dbCommand;
        }

        /// <summary>
        /// 直接执行存储过程
        /// </summary>
        /// <param name="storedProcedure">存储过程名称</param>
        /// <returns>返回dbCommand对象</returns>
        public DbCommand GetStoredProcCommond(string storedProcedure)
        {
            DbCommand dbCommand = _connection.CreateCommand();
            dbCommand.CommandText = storedProcedure;
            dbCommand.CommandType = CommandType.StoredProcedure;
            return dbCommand;
        }

        #region 错误信息表

        private static readonly object Syn = new object();

        private static DataTable _errorTable;

        private static DataTable ErrorTable
        {
            get
            {
                if (_errorTable == null)
                {
                    lock (Syn)
                    {
                        if (_errorTable == null)
                        {
                            _errorTable = new DataTable();
                            _errorTable.Columns.Add("ERROR", typeof(String));
                            _errorTable.Rows.Add(_errorTable.NewRow());
                        }
                    }
                }
                return _errorTable.Copy();
            }
        }

        private static SimpDataEntery CreateErrorSimpDataEntery(string erroeMsg)
        {
            return new SimpDataEntery()
            {
                Cols = new[] { new SimpDataColInf() { Name = "ERROR", Type = DotNetType.String } },
                Rows = new List<object[]>() { new object[] { erroeMsg } }
            };
        }

        private static DataTable CreateErrorTable(string erroeMsg)
        {
            DataTable erroDt = ErrorTable;
            erroDt.Rows[0]["ERROR"] = erroeMsg;
            return erroDt;
        }

        #endregion 错误信息表

        #region 增加参数

        /// <summary>
        /// 存储过程添加输入参数
        /// </summary>
        /// <param name="cmd">DbCommand对象</param>
        /// <param name="parameterName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="value">参数值</param>
        /// <returns>无返回结果</returns>
        public void AddInParameter(DbCommand cmd, string parameterName, DbType dbType, object value)
        {
            DbParameter dbParameter = cmd.CreateParameter();
            dbParameter.DbType = dbType;
            dbParameter.ParameterName = parameterName;
            dbParameter.Value = value;
            dbParameter.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(dbParameter);
        }

        /// <summary>
        /// 存储过程添加输出参数
        /// </summary>
        /// <param name="cmd">DbCommand对象</param>
        /// <param name="parameterName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="size">参数大小</param>
        /// <returns>无返回结果</returns>
        public void AddOutParameter(DbCommand cmd, string parameterName, DbType dbType, int size)
        {
            DbParameter dbParameter = cmd.CreateParameter();
            dbParameter.DbType = dbType;
            dbParameter.ParameterName = parameterName;
            dbParameter.Size = size;
            dbParameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(dbParameter);
        }

        public void AddParameterCollection(DbCommand cmd, DbParameterCollection dbParameterCollection)
        {
            foreach (DbParameter dbParameter in dbParameterCollection)
            {
                cmd.Parameters.Add(dbParameter);
            }
        }

        /// <summary>
        /// 存储过程添加返回参数
        /// </summary>
        /// <param name="cmd">DbCommand对象</param>
        /// <param name="parameterName">参数名称</param>
        /// <param name="dbType">参数类型</param>
        /// <returns>无返回结果</returns>
        public void AddReturnParameter(DbCommand cmd, string parameterName, DbType dbType)
        {
            DbParameter dbParameter = cmd.CreateParameter();
            dbParameter.DbType = dbType;
            dbParameter.ParameterName = parameterName;
            dbParameter.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(dbParameter);
        }

        /// <summary>
        /// 存储过程添加获得参数
        /// </summary>
        /// <param name="cmd">DbCommand对象</param>
        /// <param name="parameterName">参数名称</param>
        /// <returns>返回参数对象值</returns>
        public DbParameter GetParameter(DbCommand cmd, string parameterName)
        {
            return cmd.Parameters[parameterName];
        }

        #endregion 增加参数

        #region 执行

        //返回DataSet对象
        public DataSet ExecuteDataSet(DbCommand cmd)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DbProviderName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            DataSet ds = new DataSet();
            MyTransaction tran = MyTransaction.BeginTransaction(cmd);
            if (dbDataAdapter != null)
            {
                dbDataAdapter.SelectCommand = cmd;
                try
                {
                    dbDataAdapter.Fill(ds);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    ds.Tables.Add(CreateErrorTable(e.ToString()));
                }
            }
            return ds;
        }

        //返回DataTable对象
        public DataTable ExecuteDataTable(DbCommand cmd)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DbProviderName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            DataTable dataTable = new DataTable("WcfDataTable");
            MyTransaction tran = MyTransaction.BeginTransaction(cmd);
            if (dbDataAdapter != null)
            {
                dbDataAdapter.SelectCommand = cmd;
                try
                {
                    //dataTable = new DataTable();
                    dbDataAdapter.Fill(dataTable);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    dataTable = CreateErrorTable(e.ToString());
                }
            }
            return dataTable;
        }

        //无结果SQL操作,适用于数据表的增,删,改,存储过程操作
        public int ExecuteNonQuery(DbCommand cmd)
        {
            cmd.CommandTimeout = 100;
            cmd.Connection.Open();
            int ret = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return ret;
        }

        //返回DataReader对象
        public DbDataReader ExecuteReader(DbCommand cmd)
        {
            cmd.CommandTimeout = 100;
            cmd.Connection.Open();
            DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        //返回SQL影响的行数
        public object ExecuteScalar(DbCommand cmd)
        {
            MyTransaction tran = MyTransaction.BeginTransaction(cmd);
            object ret;
            try
            {
                ret = cmd.ExecuteScalar();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                return e.ToString();
            }
            return ret;
        }

        public List<SimpDataEntery> ExecuteSimpData(DbCommand cmd)
        {
            MyTransaction tran = MyTransaction.BeginTransaction(cmd);
            List<SimpDataEntery> simpDbEnterys = new List<SimpDataEntery>();
            try
            {
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    do
                    {
                        var simpCols = new SimpDataColInf[reader.FieldCount];
                        for (int i = 0, iCnt = reader.FieldCount; i < iCnt; i++)
                        {
                            simpCols[i].Name = reader.GetName(i);
                            var fieldType = reader.GetFieldType(i);
                            if (fieldType != null)
                                simpCols[i].Type = (DotNetType)Enum.Parse(typeof(DotNetType), fieldType.Name);
                        }
                        var simpRows = new List<object[]>();
                        while (reader.Read())
                        {
                            object[] objs = new object[reader.FieldCount];

                            for (int i = 0, iCnt = reader.FieldCount; i < iCnt; i++)
                            {
                                if ((objs[i] = reader.GetValue(i)).Equals(DBNull.Value))
                                {
                                    objs[i] = null;
                                }
                                if (objs[i] is DateTime)
                                {
                                    objs[i] = ((DateTime)objs[i]).ToString(CultureInfo.InvariantCulture);
                                }
                            }
                            //_reader.GetValues(_objs);
                            simpRows.Add(objs);
                        }
                        simpDbEnterys.Add(new SimpDataEntery() { Cols = simpCols, Rows = simpRows, Val = DateTime.Now.Ticks });
                    } while (reader.NextResult());
                    reader.Close();
                    tran.Commit();
                }
            }
            catch (Exception e)
            {
                tran.Rollback();
                simpDbEnterys.Add(CreateErrorSimpDataEntery(e.ToString()));
            }
            return simpDbEnterys;
        }

        #endregion 执行
    }
}