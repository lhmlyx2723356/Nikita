using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Nikita.Assist.CodeMaker.CodeMakerDemoForm;
using Nikita.Assist.CodeMaker.DAL;
using Nikita.Assist.CodeMaker.Model;
using Nikita.DataAccess4DBHelper;
using Nikita.Base.Define;

namespace Nikita.Assist.CodeMaker
{
    public class BindSourceHelper
    {
        public class BindClass
        {
            public SqlType SqlType { get; set; }
            public string Connections { get; set; }
            public string BindSql { get; set; }
        }
         
        public static DataSet GetBindSourceDataSet(BindClass bindClass)
        {
            bindClass.Connections = GlobalHelpDemoForm.DemoConn1;
            IDbHelper helper = DbHelper.GetDbHelper(bindClass.SqlType, bindClass.Connections);
            helper.CreateCommand(bindClass.BindSql);
            DataSet ds = helper.ExecuteQueryDataSet();
            for (int i = 0; i < ds.Tables.Count - 1; i++)
            {
                ds.Tables[i].TableName = ds.Tables[ds.Tables.Count - 1].Rows[0][0].ToString().Trim().Split(',')[i];
            }
            return ds;
        }
    }
}
