using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Base.ConnectionManager
{
    public static class ConfigConnection
    {
        public static string NotePadConnection = "server= UKYNDA-001 ;uid=sa;pwd=12345678;database=Note";
        public static string BugCloseConnection = "server= UKYNDA-001 ;uid=sa;pwd=12345678;database=BugClose";
        public static string CodeMgrDemoConnection = "server= UKYNDA-001 ;uid=sa;pwd=12345678;database=CodeMgr";
        public static string BPMDemoConnection = 
        "server= UKYNDA-001 ;uid=sa;pwd=12345678;database=BPM";
        public  static  string TestConnection= "server= UKYNDA-001 ;uid=sa;pwd=12345678;database=master";

        public static string WcfConfigDbConnection = @"server= UKYNDA-001;uid=sa;pwd=12345678;database=WcfConfig";
        public static string CacheStoreConnection = @"server= UKYNDA-001 ;uid=sa;pwd=12345678;database=CacheStore";
        public static string IDBuilderConnection = "Data Source=UKYNDA-001\\SQLSERVER2008;Initial Catalog=IDBuilder;Persist Security Info=True;User ID=sa;Password=12345678";

    }
}
