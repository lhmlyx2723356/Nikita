using Nikita.Base.Define;
using System;
using System.Linq.Expressions;

namespace Nikita.DataAccess.Expression2Sql
{
    public class ExpressionToSqlSQLServer : IExpressionToSql
    {
        private DbContext dbContext;

        public ExpressionToSqlSQLServer(DbContext dbContext = null)
        {
            this.dbContext = dbContext;
        }

        public ExpressionToSql<T> Avg<T>(Expression<Func<T, object>> expression)
        {
            return CreateExpressionToSql<T>().Avg(expression);
        }

        public ExpressionToSql<T> Count<T>(Expression<Func<T, object>> expression = null)
        {
            return CreateExpressionToSql<T>().Count(expression);
        }

        public ExpressionToSql<T> Delete<T>()
        {
            return CreateExpressionToSql<T>().Delete();
        }

        public ExpressionToSql<T> Insert<T>(Expression<Func<object>> expression)
        {
            return CreateExpressionToSql<T>().Insert(expression);
        }

        public ExpressionToSql<T> Insert<T>(T t)
        {
            return CreateExpressionToSql<T>().Insert(t);
        }

        public ExpressionToSql<T> Max<T>(Expression<Func<T, object>> expression)
        {
            return CreateExpressionToSql<T>().Max(expression);
        }

        public ExpressionToSql<T> Min<T>(Expression<Func<T, object>> expression)
        {
            return CreateExpressionToSql<T>().Min(expression);
        }

        public ExpressionToSql<T> Select<T>(Expression<Func<T, object>> expression = null, bool blnWithNoLock = false)
        {
            return CreateExpressionToSql<T>().Select(expression, blnWithNoLock);
        }

        public ExpressionToSql<T> Select<T, T2>(Expression<Func<T, T2, object>> expression = null, bool blnWithNoLock = false)
        {
            return CreateExpressionToSql<T>().Select(expression, blnWithNoLock);
        }

        public ExpressionToSql<T> Select<T, T2, T3>(Expression<Func<T, T2, T3, object>> expression = null, bool blnWithNoLock = false)
        {
            return CreateExpressionToSql<T>().Select(expression, blnWithNoLock);
        }

        public ExpressionToSql<T> Select<T, T2, T3, T4>(Expression<Func<T, T2, T3, T4, object>> expression = null, bool blnWithNoLock = false)
        {
            return CreateExpressionToSql<T>().Select(expression, blnWithNoLock);
        }

        public ExpressionToSql<T> Select<T, T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, object>> expression = null, bool blnWithNoLock = false)
        {
            return CreateExpressionToSql<T>().Select(expression, blnWithNoLock);
        }

        public ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, object>> expression = null, bool blnWithNoLock = false)
        {
            return CreateExpressionToSql<T>().Select(expression, blnWithNoLock);
        }

        public ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6, T7>(Expression<Func<T, T2, T3, T4, T5, T6, T7, object>> expression = null, bool blnWithNoLock = false)
        {
            return CreateExpressionToSql<T>().Select(expression, blnWithNoLock);
        }

        public ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, object>> expression = null, bool blnWithNoLock = false)
        {
            return CreateExpressionToSql<T>().Select(expression, blnWithNoLock);
        }

        public ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, object>> expression = null, bool blnWithNoLock = false)
        {
            return CreateExpressionToSql<T>().Select(expression, blnWithNoLock);
        }

        public ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> expression = null, bool blnWithNoLock = false)
        {
            return CreateExpressionToSql<T>().Select(expression, blnWithNoLock);
        }

        public ExpressionToSql<T> SelectTest<T>(Expression<Func<T>> expression = null)
        {
            return null;
        }

        public ExpressionToSql<T> Sum<T>(Expression<Func<T, object>> expression)
        {
            return CreateExpressionToSql<T>().Sum(expression);
        }

        public ExpressionToSql<T> Update<T>(Expression<Func<object>> expression)
        {
            return CreateExpressionToSql<T>().Update(expression);
        }

        public ExpressionToSql<T> Update<T>(T t)
        {
            return CreateExpressionToSql<T>().Update(t);
        }

        private ExpressionToSql<T> CreateExpressionToSql<T>()
        {
            return new ExpressionToSql<T>(SqlType.SqlServer, dbContext.ConnectionString);
        }
    }
}