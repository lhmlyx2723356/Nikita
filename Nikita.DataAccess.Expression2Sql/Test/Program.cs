using Nikita.DataAccess.Expression2Sql;
using System;
using System.Collections.Generic;
using Nikita.Base.Define;

namespace Expression2SqlTest
{
    /// <summary>
    /// Expression2Sql Sample Code
    /// Chinese Technology Blog：http://www.cnblogs.com/strangecity
    /// Expression2Sql Chinese Introduce：http://www.cnblogs.com/StrangeCity/p/4795117.html
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Expression2SqlTest";
            IExpressionToSql ExpressionToSqlSQLServer = new ExpressionToSqlSQLServer();
            IExpressionToSql ExpressionToSqlMySQL = new ExpressionToSqlMySQL();
            IExpressionToSql ExpressionToSqlSQLite = new ExpressionToSqlSQLite();
            IExpressionToSql ExpressionToSqlOracle = new ExpressionToSqlOracle();

            ExpressionToSql<UserInfo> userInfoSql = new ExpressionToSql<UserInfo>(SqlType.MySql,"");
            Printf(
                    userInfoSql.Select().Where(u => u.Id != 1),
                    "Instance class"
            );

            Printf(
               ExpressionToSqlSQLServer.Select<UserInfo>().
                                        Where(u => u.Name == "Jones"),
               "SQLServer static class"
            );
            Printf(
               ExpressionToSqlMySQL.Select<UserInfo>().
                                        Where(u => u.Name == "Tom"),
               "MySQL static class"
            );
            Printf(
               ExpressionToSqlSQLite.Select<UserInfo>().
                                        Where(u => u.Name == "Venus"),
               "SQLite static class"
            );
            Printf(
               ExpressionToSqlOracle.Select<UserInfo>().
                                        Where(u => u.Name == "Lucy"),
               "Oracle static class"
            );

            Printf(
                    ExpressionToSqlSQLServer.Select<UserInfo>(),
                    "Query single table all fields"
            );

            Printf(
                ExpressionToSqlSQLServer.Select<UserInfo>(u => u.Id),
                "Query single table single field"
            );

            Printf(
                ExpressionToSqlSQLServer.Select<UserInfo>(u => new { u.Id, u.Name }),
                "Query single table specified field"
            );

            Printf(
                ExpressionToSqlSQLServer.Select<UserInfo>(u => new { UserId = u.Id, u.Email, UserName = u.Name }),
                "Query single table specified field, take field alias"
            );

            Printf(
               ExpressionToSqlSQLServer.Select<UserInfo>().
                                        Where(u => u.Name == "Alice"),
               "Query single table with multiple conditions"
            );

            string parameterValue = "Jack";
            Printf(
                ExpressionToSqlSQLServer.Select<UserInfo>().
                                         Where(u => u.Name == parameterValue),
                "Query single table with multiple conditions"
            );

            Printf(
                ExpressionToSqlSQLServer.Select<UserInfo>(u => u.Id).
                                         Where(u => u.Name.Like("b")),
                "Query single table with 'like' conditions"
            );

            Printf(
                ExpressionToSqlSQLServer.Select<UserInfo>(u => u.Id).
                                         Where(u => u.Name.LikeLeft("b")),
                "Query single table with 'like left' conditions"
            );

            Printf(
                ExpressionToSqlSQLServer.Select<UserInfo>(u => u.Id).
                                         Where(u => u.Name.LikeRight("b")),
                "Query single table with 'like right' conditions"
            );

            Printf(
                ExpressionToSqlSQLServer.Select<UserInfo>(u => u.Name).
                                         Where(u => u.Id.In(1, 2, 3, 4, 5)),
                "Query single table with 'in' conditions, mode 1"
            );

            int[] aryId = { 1, 2, 3 };
            Printf(
                ExpressionToSqlSQLServer.Select<UserInfo>(u => u.Name).
                                         Where(u => u.Id.In(aryId)),
                "Query single table with 'in' conditions, mode 2"
            );

            Printf(
                ExpressionToSqlSQLServer.Select<UserInfo>(u => u.Name).
                                         Where(u => u.Name.In(new string[] { "a", "b" })),
                "Query single table with 'in' conditions, mode 3"
            );

            Printf(
                ExpressionToSqlSQLServer.Select<UserInfo>(u => u.Id).
                                          Where(
                                                u => u.Name == "b"
                                                  && u.Id > 2
                                                  && u.Name != null
                                                  && u.Id > int.MinValue
                                                  && u.Id < int.MaxValue
                                                  && u.Id.In(1, 2, 3)
                                                  && u.Name.Like("a")
                                                  && u.Name.LikeLeft("b")
                                                  && u.Name.LikeRight("c")
                                                  || u.Id == null
                                                ),
                "Query single table with multiple conditions"
            );

            Printf(
                ExpressionToSqlSQLServer.Select<UserInfo>(u => u.Id).
                                         Where(
                                              u => u.Name == "b"
                                              && (u.Id == 100 || u.Id != null)
                                              && (u.Id == 50 || u.Id == null)
                                              ),
                "Query single table with multiple conditions, parentheses priority"
            );

            Printf(
                 ExpressionToSqlSQLServer.Select<UserInfo, Account>((u, a) => new { u.Id, a.Name }).
                                 Join<Account>((u, a) => u.Id == a.UserId),
                 "Multi-table join query"
            );

            Printf(
                 ExpressionToSqlSQLServer.Select<UserInfo, Account>((u, a) => new { u.Id, a.Name }).
                                          InnerJoin<Account>((u, a) => u.Id == a.UserId),
                 "Multi-table innerJoin query"
            );

            Printf(
           ExpressionToSqlSQLServer.Select<UserInfo, Account>((u, a) => new { u.Id, a.Name }).
                                    InnerJoin<Account>((u, a) => u.Id == a.UserId).FullJoin<Account>((u, c) => u.Id == c.UserId),
           "测试同表"
      );

            Printf(
                 ExpressionToSqlSQLServer.Select<UserInfo, Account>((u, a) => new { u.Id, a.Name }).
                                          LeftJoin<Account>((u, a) => u.Id == a.UserId),
                 "Multi-table leftJoin query"
            );

            Printf(
                 ExpressionToSqlSQLServer.Select<UserInfo, Account>((u, a) => new { u.Id, a.Name }).
                                          RightJoin<Account>((u, a) => u.Id == a.UserId),
                 "Multi-table rightJoin query"
            );

            Printf(
                 ExpressionToSqlSQLServer.Select<UserInfo, Account>((u, a) => new { u.Id, a.Name }).
                                          FullJoin<Account>((u, a) => u.Id == a.UserId),
                 "Multi-table fullJoin query"
            );

            Printf(
                 ExpressionToSqlSQLServer.Select<UserInfo, Account, Student, Class, City, Country>((a, b, c, d, e, f) =>
                                          new { a.Id, b.Name, StudentName = c.Name, ClassName = d.Name, e.CityName, CountryName = f.Name }).
                                          Join<Account>((u, a) => u.Id == a.UserId).
                                          LeftJoin<Account, Student>((a, s) => a.Id == s.AccountId).
                                          RightJoin<Student, Class>((s, c) => s.Id == c.UserId).
                                          InnerJoin<Class, City>((c, d) => c.CityId == d.Id).
                                          FullJoin<City, Country>((c, d) => c.CountryId == d.Id).
                                          Where(u => u.Id != null),
                 "More complex associated query table, the same column name alias"
            );

            Printf(
                 ExpressionToSqlSQLServer.Count<UserInfo>(u => u.Id).
                                          GroupBy(u => u.Name),
                 "GroupBy"
            );

            Printf(
                 ExpressionToSqlSQLServer.Select<UserInfo>().
                                          OrderBy(u => u.Id),
                 "OrderBy"
            );

            Printf(
                 ExpressionToSqlSQLServer.Max<UserInfo>(u => u.Id),
                 "Returns a column of the maximum value, null value is not included in the calculation"
            );

            Printf(
                 ExpressionToSqlSQLServer.Min<UserInfo>(u => u.Id),
                 "Returns a column of the minimum value, null value is not included in the calculation"
            );

            Printf(
                 ExpressionToSqlSQLServer.Avg<UserInfo>(u => u.Id),
                 "Returns the numerical average of the column, null value is not included in the calculation"
            );

            Printf(
                 ExpressionToSqlSQLServer.Count<UserInfo>(),
                 "Returns the record number in the table."
            );

            Printf(
                 ExpressionToSqlSQLServer.Count<UserInfo>(u => u.Id),
                 "Returns the value of the specified column number（null can't be counted）"
            );

            Printf(
                 ExpressionToSqlSQLServer.Sum<UserInfo>(u => u.Id),
                 "Returns the total number of numeric column（total amount）"
            );

            string strName = "Paul";
            Printf(
                 ExpressionToSqlSQLServer.Insert<UserInfo>(() => new { Name = strName, Sex = 1, Email = "123456@qq.com" }),
                 "Insert a record"
            );

            Printf(
                 ExpressionToSqlSQLServer.Delete<UserInfo>(),
                 "A full table delete"
            );

            Printf(
                 ExpressionToSqlSQLServer.Delete<UserInfo>().
                                          Where(u => u.Id == null),
                 "According to the condition delete specified table record"
            );

            Printf(
                 ExpressionToSqlSQLServer.Update<UserInfo>(() => new { Name = "Marilyn", Sex = 1, Email = "123456@qq.com" }),
                 "A full table updates"
            );
            string name = GetName("Susan");
            Printf(
                 ExpressionToSqlSQLServer.Update<UserInfo>(() => new { Name = name, Sex = 1, Email = "123456@qq.com" }).
                                          Where(u => u.Id == 1),
                 "According to the condition update specified table record"
            );

            //to be continued...

            Console.ReadKey();
        }

        private static string GetName(string p)
        {
            return p;
        }

        private static void Printf<T>(ExpressionToSql<T> expression2Sql, string description = "")
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(description);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine(expression2Sql.Sql);
            foreach (KeyValuePair<string, object> item in expression2Sql.DbParams)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}