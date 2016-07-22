using System.Data;

namespace Nikita.DataAccess4DBHelper
{
    public interface IDbHelper
    {
        /// <summary>添加参数
        ///
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="value">值</param>
        void AddParameter(string paramName, object value);

        /// <summary>
        /// 将DataTable的数据批量插入到数据库中。
        /// </summary>
        /// <param name="dataTable">要批量插入的 <see cref="DataTable"/>。</param>
        /// <param name="batchSize">每批次写入的数据量。</param>
        void BatchInsert(DataTable dataTable, int batchSize = 10000);

        /// <summary>关闭数据库连接
        ///
        /// </summary>
        void CloseConn();

        /// <summary>创建Command对象
        ///
        /// </summary>
        /// <param name="sql">SQL语句</param>
        void CreateCommand(string sql);

        /// <summary>创建Command对象
        ///
        /// </summary>
        /// <param name="sql">SQL语句</param>
        void CreateStoredCommand(string sql);

        ///  <summary>执行不带参数的增删改SQL语句
        ///
        ///  </summary>
        /// <returns></returns>
        bool ExecuteNonQuery();

        ///  <summary>执行查询SQL语句
        ///
        ///  </summary>
        /// <returns></returns>
        DataTable ExecuteQuery();

        /// <summary>返回DataSet
        ///
        /// </summary>
        DataSet ExecuteQueryDataSet();

        /// <summary>返回IDataReader
        ///
        /// </summary>
        /// <returns></returns>
        IDataReader ExecuteReader();

        /// <summary>返回查询SQL语句查询出的结果的第一行第一列的值
        ///
        /// </summary>
        /// <returns></returns>
        string ExecuteScalar();

        string ReturnRunMessage();

        void StopRunSql();

        /// <summary>测试连接
        ///
        /// </summary>
        bool TestConn();
    }
}