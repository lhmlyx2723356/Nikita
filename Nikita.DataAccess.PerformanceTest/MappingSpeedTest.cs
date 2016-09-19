using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Nikita.Base.Define;
using Nikita.Base.ConnectionManager;
using Nikita.DataAccess.Expression2Sql;

namespace Nikita.DataAccess.PerformanceTest
{
    public static class MappingSpeedTest
    {
        static int takeCount = 50 * 10000 + 1;
        public static readonly string ConnectionString = ConfigConnection.ORMPerformanceTestConnection;
        public static void SpeedTest()
        {
            long useTime = 0;

            //预热
            QueryTest(2);

            useTime = SW.Do(() =>
            {
                QueryTest(takeCount);
            });

            Console.WriteLine("QueryTest 一次查询{0}条数据总用时：{1}ms", takeCount, useTime);
            GC.Collect();

            //useTime = SW.Do(() =>
            //{
            //    SqlQueryTest(takeCount);
            //});

            //Console.WriteLine("SqlQueryTest 一次查询{0}条数据总用时：{1}ms", takeCount, useTime);
            //GC.Collect();


            Console.WriteLine("GAME OVER");
            Console.ReadKey();
        }
        static void QueryTest(int takeCount)
        {

            DbContext context = new DbContext(SqlType.SqlServer, ConnectionString);
            var result5 = context.ExpressionToSql.Select<TestEntity>().Where(t => t.Id > 1 && t.F_String.EndsWith("Chloe5"));
            var result4 = context.ExpressionToSql.Select<TestEntity>().Where(t => t.Id > 1 && t.F_String.EndsWith("Chloe5")).ToList(); 
            //var result = context.ExpressionToSql.Select<TestEntity>().Where(t => t.Id > takeCount2( takeCount )+ 1 && t.Id < takeCount + 100);
            //var result2 = context.ExpressionToSql.Select<TestEntity>().Where(t => t.Id > takeCount + 1 && t.Id < takeCount + 100).ToList();

        }

        public static int takeCount2(int takeCount)
        {
            return takeCount + 10;
        }
    }
}
