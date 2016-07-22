using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;

namespace Nikita.Assist.WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IMsSqlDataAccessService”。
    [ServiceContract]
    public interface IMsSqlDataAccessService
    {

        [OperationContract]
        [ServiceKnownType(typeof(System.DBNull))]
        void AddOutputParameter(string paramName);

        [OperationContract]
        [ServiceKnownType(typeof(System.DBNull))]
        void AddParameter(string paramName, object value);

        [OperationContract]
        void CloseConn();

        [OperationContract] 
        [ServiceKnownType(typeof(System.DBNull))]
        void CreateCommand(string sql);


        [OperationContract]
        void CreateStoredCommand(string procName);
        [OperationContract]
        void ExecuteBulkToDb(DataTable dt, string tableName);

        [OperationContract]
        DataTable ExecuteDeleteBatchData(string tableName, string filter);

        [OperationContract]
        DataTable ExecuteGetBatchData(string tableName, string filter, string columnNames);

        [OperationContract]
        bool ExecuteNonQuery();

        [OperationContract]
        DataTable ExecuteQuery();

        [OperationContract]
        DataSet ExecuteQueryDataSet();

        [OperationContract]
        DataTable ExecuteQueryDataTable();

        [OperationContract]
        string ExecuteScalar();

        [OperationContract]
        DataTable ExecuteUpdateBatchData(string tableName, string filter, string setValues);

        [OperationContract]
        void ExecuteWithTran(string cmdText);

        [OperationContract]
        [ServiceKnownType(typeof(System.DBNull))]
        string GetOutputParameter(string paramName);
    }
}
