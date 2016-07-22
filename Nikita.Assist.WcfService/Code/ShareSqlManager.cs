using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Nikita.Assist.WcfService
{
    public enum RetType
    {
        String,
        Table,
        DataSet,
        SimpDEs
    }

    public class ShareSqlManager
    {
        /// <summary>通用存储过程执行
        ///
        /// </summary>
        /// <param name="storedProcedure">存储过程的名字</param>
        /// <param name="paramKeys">参数列表，,隔开</param>
        /// <param name="paramVals">参数值数组</param>
        /// <param name="dbConName"></param>
        /// <param name="strRetType">Table返回DataTable；String时返回string；Int时返回int</param>
        /// <returns></returns>
        public object ExecStoredProc(string storedProcedure, string[] paramKeys, object[] paramVals, string dbConName, RetType strRetType)
        {
            SimpDataDBHelper dbComObj = new SimpDataDBHelper(dbConName);

            using (DbCommand cmd = dbComObj.GetStoredProcCommond(storedProcedure))
            {
                if (paramKeys != null && paramVals != null && paramKeys.Length != 0 && paramVals.Length != 0)
                {
                    for (int i = 0, iCnt = paramKeys.Length; i < iCnt; i++)
                    {
                        dbComObj.AddInParameter(cmd, "@" + paramKeys[i], DbType.String, paramVals[i].ToString());
                    }
                }
                switch (strRetType)
                {
                    case RetType.String:
                        return dbComObj.ExecuteScalar(cmd);

                    case RetType.Table:
                        return dbComObj.ExecuteDataTable(cmd);

                    case RetType.DataSet:
                        return dbComObj.ExecuteDataSet(cmd);

                    case RetType.SimpDEs:
                        return dbComObj.ExecuteSimpData(cmd);
                }
                return null;
            }
        }
    }
}