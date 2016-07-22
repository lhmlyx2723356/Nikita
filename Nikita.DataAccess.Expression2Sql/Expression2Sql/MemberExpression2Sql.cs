using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Nikita.DataAccess.Expression2Sql
{
    internal class MemberExpression2Sql : BaseExpression2Sql<MemberExpression>
    {
        protected override SqlBuilder Avg(MemberExpression expression, SqlBuilder sqlBuilder)
        {
            return AggregateFunctionParser(expression, sqlBuilder);
        }

        protected override SqlBuilder Count(MemberExpression expression, SqlBuilder sqlBuilder)
        {
            return AggregateFunctionParser(expression, sqlBuilder);
        }

        protected override SqlBuilder GroupBy(MemberExpression expression, SqlBuilder sqlBuilder)
        {
            sqlBuilder.SetTableAlias(expression.Member.DeclaringType.Name);
            sqlBuilder += sqlBuilder.GetTableAlias(expression.Member.DeclaringType.Name) + "." + expression.Member.Name;
            return sqlBuilder;
        }

        protected override SqlBuilder In(MemberExpression expression, SqlBuilder sqlBuilder)
        {
            var field = expression.Member as FieldInfo;
            if (field != null)
            {
                object val = field.GetValue(((ConstantExpression)expression.Expression).Value);

                if (val != null)
                {
                    string itemJoinStr = "";
                    IEnumerable array = val as IEnumerable;
                    foreach (var item in array)
                    {
                        if (field.FieldType.Name == "String[]")
                        {
                            itemJoinStr += string.Format(",'{0}'", item);
                        }
                        else
                        {
                            itemJoinStr += string.Format(",{0}", item);
                        }
                    }

                    if (itemJoinStr.Length > 0)
                    {
                        itemJoinStr = itemJoinStr.Remove(0, 1);
                        itemJoinStr = string.Format("({0})", itemJoinStr);
                        sqlBuilder += itemJoinStr;
                    }
                }
            }

            return sqlBuilder;
        }

        protected override SqlBuilder Join(MemberExpression expression, SqlBuilder sqlBuilder)
        {
            if (sqlBuilder.JoinTables.Count(t => t.Value.Equals(expression.Member.DeclaringType.Name)) < 2)
            {
                sqlBuilder.SetTableAlias(expression.Member.DeclaringType.Name);
                string tableAlias = sqlBuilder.GetTableAlias(expression.Member.DeclaringType.Name);
                if (!string.IsNullOrWhiteSpace(tableAlias))
                {
                    tableAlias += ".";
                }
                sqlBuilder += " " + tableAlias + expression.Member.Name;
            }
            else
            {
                string tableAlias = sqlBuilder.JoinTables.Last(t => t.Value.Equals(expression.Member.DeclaringType.Name)).Key;
                if (!string.IsNullOrWhiteSpace(tableAlias))
                {
                    tableAlias += ".";
                }
                sqlBuilder += " " + tableAlias + expression.Member.Name;
            }

            return sqlBuilder;
        }

        protected override SqlBuilder Max(MemberExpression expression, SqlBuilder sqlBuilder)
        {
            return AggregateFunctionParser(expression, sqlBuilder);
        }

        protected override SqlBuilder Min(MemberExpression expression, SqlBuilder sqlBuilder)
        {
            return AggregateFunctionParser(expression, sqlBuilder);
        }

        protected override SqlBuilder OrderBy(MemberExpression expression, SqlBuilder sqlBuilder)
        {
            sqlBuilder.SetTableAlias(expression.Member.DeclaringType.Name);
            sqlBuilder += sqlBuilder.GetTableAlias(expression.Member.DeclaringType.Name) + "." + expression.Member.Name;
            return sqlBuilder;
        }

        protected override SqlBuilder Select(MemberExpression expression, SqlBuilder sqlBuilder)
        {
            sqlBuilder.SetTableAlias(expression.Member.DeclaringType.Name);
            string tableAlias = sqlBuilder.GetTableAlias(expression.Member.DeclaringType.Name);
            if (!string.IsNullOrWhiteSpace(tableAlias))
            {
                tableAlias += ".";
            }
            sqlBuilder.SelectFields.Add(tableAlias + expression.Member.Name);
            return sqlBuilder;
        }

        protected override SqlBuilder Sum(MemberExpression expression, SqlBuilder sqlBuilder)
        {
            return AggregateFunctionParser(expression, sqlBuilder);
        }

        protected override SqlBuilder Where(MemberExpression expression, SqlBuilder sqlBuilder)
        {
            if (expression.Expression.NodeType == ExpressionType.Constant)
            {
                object value = GetValue(expression);
                sqlBuilder.AddDbParameter(value);
            }
            else if (expression.Expression.NodeType == ExpressionType.Parameter)
            {
                sqlBuilder.SetTableAlias(expression.Member.DeclaringType.Name);
                string tableAlias = sqlBuilder.GetTableAlias(expression.Member.DeclaringType.Name);
                if (!string.IsNullOrWhiteSpace(tableAlias))
                {
                    tableAlias += ".";
                }
                sqlBuilder += " " + tableAlias + expression.Member.Name;
            }

            return sqlBuilder;
        }

        private static object GetValue(MemberExpression expr)
        {
            object value;
            var field = expr.Member as FieldInfo;
            if (field != null)
            {
                value = field.GetValue(((ConstantExpression)expr.Expression).Value);
            }
            else
            {
                value = ((PropertyInfo)expr.Member).GetValue(((ConstantExpression)expr.Expression).Value, null);
            }
            return value;
        }

        private SqlBuilder AggregateFunctionParser(MemberExpression expression, SqlBuilder sqlBuilder)
        {
            string aggregateFunctionName = new StackTrace(true).GetFrame(1).GetMethod().Name.ToLower();

            string tableName = expression.Member.DeclaringType.Name;
            string columnName = expression.Member.Name;

            sqlBuilder.SetTableAlias(tableName);
            string tableAlias = sqlBuilder.GetTableAlias(tableName);

            if (!string.IsNullOrWhiteSpace(tableAlias))
            {
                tableName += " " + tableAlias;
                columnName = tableAlias + "." + columnName;
            }
            sqlBuilder.AppendFormat("select {0}({1}) from {2}", aggregateFunctionName, columnName, tableName);
            return sqlBuilder;
        }
    }
}