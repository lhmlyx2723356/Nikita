using Nikita.DataAccess4DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Base.IDAL
{
    public class BindSourceHelper
    {
        public static DataSet GetBindSourceDataSet(BindClass bindClass,string strConn)
        {
            bindClass.Connections = strConn;
            IDbHelper helper = DbHelper.GetDbHelper(bindClass.SqlType, bindClass.Connections);
            helper.CreateCommand(bindClass.BindSql);
            DataSet ds = helper.ExecuteQueryDataSet();
            for (int i = 0; i < ds.Tables.Count - 1; i++)
            {
                ds.Tables[i].TableName = ds.Tables[ds.Tables.Count - 1].Rows[0][i].ToString().Trim();
            }
            return ds;
        }
    }
}
