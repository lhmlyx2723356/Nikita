using System;
using System.Linq.Expressions;

namespace Nikita.DataAccess.Expression2Sql
{
    internal class Expression2SqlProvider
    {
        public static void Avg(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Avg(expression, sqlBuilder);
        }

        public static void Count(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Count(expression, sqlBuilder);
        }

        public static void GroupBy(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).GroupBy(expression, sqlBuilder);
        }

        public static void In(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).In(expression, sqlBuilder);
        }

        public static void Insert(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Insert(expression, sqlBuilder);
        }

        public static void Join(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Join(expression, sqlBuilder);
        }

        public static void Max(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Max(expression, sqlBuilder);
        }

        public static void Min(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Min(expression, sqlBuilder);
        }

        public static void OrderBy(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).OrderBy(expression, sqlBuilder);
        }

        public static void OrderByDesc(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).OrderByDesc(expression, sqlBuilder);
        }
        public static void ThenBy (Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).ThenBy(expression, sqlBuilder);
        }
        public static void ThenByDesc(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).ThenByDesc(expression, sqlBuilder);
        }

        public static void Select(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Select(expression, sqlBuilder);
        }

        public static void Sum(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Sum(expression, sqlBuilder);
        }

        public static void Update(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Update(expression, sqlBuilder);
        }

        public static void Where(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).Where(expression, sqlBuilder);
        }
        //public static void Take(Expression expression, SqlBuilder sqlBuilder)
        //{
        //    GetExpression2Sql(expression).Take(expression, sqlBuilder);
        //}
        public static void First(Expression expression, SqlBuilder sqlBuilder)
        {
            GetExpression2Sql(expression).First(expression, sqlBuilder);
        }

        private static IExpression2Sql GetExpression2Sql(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression", "Cannot be null");
            }

            if (expression is BinaryExpression)
            {
                return new BinaryExpression2Sql();
            }
            if (expression is BlockExpression)
            {
                throw new NotImplementedException("Unimplemented BlockNikita.DataAccess.Expression2Sql");
            }
            if (expression is ConditionalExpression)
            {
                throw new NotImplementedException("Unimplemented ConditionalNikita.DataAccess.Expression2Sql");
            }
            if (expression is ConstantExpression)
            {
                return new ConstantExpression2Sql();
            }
            if (expression is DebugInfoExpression)
            {
                throw new NotImplementedException("Unimplemented DebugInfoNikita.DataAccess.Expression2Sql");
            }
            if (expression is DefaultExpression)
            {
                throw new NotImplementedException("Unimplemented DefaultNikita.DataAccess.Expression2Sql");
            }
            if (expression is DynamicExpression)
            {
                throw new NotImplementedException("Unimplemented DynamicNikita.DataAccess.Expression2Sql");
            }
            if (expression is GotoExpression)
            {
                throw new NotImplementedException("Unimplemented GotoNikita.DataAccess.Expression2Sql");
            }
            if (expression is IndexExpression)
            {
                throw new NotImplementedException("Unimplemented IndexNikita.DataAccess.Expression2Sql");
            }
            if (expression is InvocationExpression)
            {
                throw new NotImplementedException("Unimplemented InvocationNikita.DataAccess.Expression2Sql");
            }
            if (expression is LabelExpression)
            {
                throw new NotImplementedException("Unimplemented LabelNikita.DataAccess.Expression2Sql");
            }
            if (expression is LambdaExpression)
            {
                throw new NotImplementedException("Unimplemented LambdaNikita.DataAccess.Expression2Sql");
            }
            if (expression is ListInitExpression)
            {
                throw new NotImplementedException("Unimplemented ListInitNikita.DataAccess.Expression2Sql");
            }
            if (expression is LoopExpression)
            {
                throw new NotImplementedException("Unimplemented LoopNikita.DataAccess.Expression2Sql");
            }
            if (expression is MemberExpression)
            {
                return new MemberExpression2Sql();
            }
            if (expression is MemberInitExpression)
            {
                throw new NotImplementedException("Unimplemented MemberInitNikita.DataAccess.Expression2Sql");
            }
            if (expression is MethodCallExpression)
            {
                return new MethodCallExpression2Sql();
            }
            if (expression is NewArrayExpression)
            {
                return new NewArrayExpression2Sql();
            }
            if (expression is NewExpression)
            {
                return new NewExpression2Sql();
            }
            if (expression is ParameterExpression)
            {
                return new ParameterExpression2Sql();
            }
            if (expression is RuntimeVariablesExpression)
            {
                throw new NotImplementedException("Unimplemented RuntimeVariablesNikita.DataAccess.Expression2Sql");
            }
            if (expression is SwitchExpression)
            {
                throw new NotImplementedException("Unimplemented SwitchNikita.DataAccess.Expression2Sql");
            }
            if (expression is TryExpression)
            {
                throw new NotImplementedException("Unimplemented TryNikita.DataAccess.Expression2Sql");
            }
            if (expression is TypeBinaryExpression)
            {
                throw new NotImplementedException("Unimplemented TypeBinaryExpression2Sql");
            }
            if (expression is UnaryExpression)
            {
                return new UnaryExpression2Sql();
            }

            throw new NotImplementedException("Unimplemented Nikita.DataAccess.Expression2Sql");
        }
    }
}