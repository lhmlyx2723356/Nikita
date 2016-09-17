using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Base.ConnectionManager
{
    public static class ConfigConnection
    {
        public static string NotePadConnection = @"server= localhost ;uid=sa;pwd=12345678;database=Note";
        public static string BugCloseConnection = @"server= localhost ;uid=sa;pwd=12345678;database=BugClose";
        public static string CodeMgrDemoConnection = @"server= localhost ;uid=sa;pwd=12345678;database=CodeMgr";
        public static string BPMDemoConnection = @"server= localhost ;uid=sa;pwd=12345678;database=BPM";
        public static string TestConnection = @"server= localhost ;uid=sa;pwd=12345678;database=master";
        public static string WcfConfigDbConnection = @"server= localhost;uid=sa;pwd=12345678;database=WcfConfig";
        public static string CacheStoreConnection = @"server= localhost ;uid=sa;pwd=12345678;database=CacheStore";
        public static string IDBuilderConnection = @"server= localhost ;uid=sa;pwd=12345678;database =IDBuilder";
        public static string ORMPerformanceTestConnection = @"server= localhost ;uid=sa;pwd=12345678;database =Chloe";

    }
}
