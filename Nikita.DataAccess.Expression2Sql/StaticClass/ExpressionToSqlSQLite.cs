using System;
using System.Linq.Expressions;
using Nikita.Base.Define;

namespace Nikita.DataAccess.Expression2Sql
{
    public  class ExpressionToSqlSQLite : IExpressionToSql
    {
        private DbContext dbContext;
        public ExpressionToSqlSQLite(DbContext dbContext = null)
        {
            this.dbContext = dbContext;
        }

        public ExpressionToSql<T> Avg<T>(Expression<Func<T, object>> expression)
        {
            return CreateExpressionToSql<T>().Avg(expression);
        }

        public  ExpressionToSql<T> Count<T>(Expression<Func<T, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Count(expression);
        }

        public  ExpressionToSql<T> Delete<T>()
        {
            return CreateExpressionToSql<T>().Delete();
        }

        public  ExpressionToSql<T> Insert<T>(Expression<Func<object>> expression)
        {
            return CreateExpressionToSql<T>().Insert(expression);
        }

        public  ExpressionToSql<T> Max<T>(Expression<Func<T, object>> expression)
        {
            return CreateExpressionToSql<T>().Max(expression);
        }

        public  ExpressionToSql<T> Min<T>(Expression<Func<T, object>> expression)
        {
            return CreateExpressionToSql<T>().Min(expression);
        }

        public  ExpressionToSql<T> Select<T>(Expression<Func<T, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }

        public  ExpressionToSql<T> Select<T, T2>(Expression<Func<T, T2, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }

        public  ExpressionToSql<T> Select<T, T2, T3>(Expression<Func<T, T2, T3, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }

        public  ExpressionToSql<T> Select<T, T2, T3, T4>(Expression<Func<T, T2, T3, T4, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }

        public  ExpressionToSql<T> Select<T, T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }

        public  ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }

        public  ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6, T7>(Expression<Func<T, T2, T3, T4, T5, T6, T7, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }

        public  ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }

        public  ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }

        public  ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Select(expression);
        }

        public  ExpressionToSql<T> Sum<T>(Expression<Func<T, object>> expression)
        {
            return CreateExpressionToSql<T>().Sum(expression);
        }

        public  ExpressionToSql<T> Update<T>(Expression<Func<object>> expression)
        {
            return CreateExpressionToSql<T>().Update(expression);
        }

        private  ExpressionToSql<T> CreateExpressionToSql<T>()
        {
            return new ExpressionToSql<T>(SqlType.SQLite, dbContext.ConnectionString);
        }
    }
}