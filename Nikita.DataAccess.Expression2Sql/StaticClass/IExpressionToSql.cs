using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Nikita.DataAccess.Expression2Sql
{
    public interface IExpressionToSql
    {
        ExpressionToSql<T> Avg<T>(Expression<Func<T, object>> expression);


        ExpressionToSql<T> Count<T>(Expression<Func<T, object>> expression = null);


        ExpressionToSql<T> Delete<T>();


        ExpressionToSql<T> Insert<T>(Expression<Func<object>> expression);


        ExpressionToSql<T> Max<T>(Expression<Func<T, object>> expression);


        ExpressionToSql<T> Min<T>(Expression<Func<T, object>> expression);


        ExpressionToSql<T> Select<T>(Expression<Func<T, object>> expression = null,bool blnWithNoLock=false);


        ExpressionToSql<T> Select<T, T2>(Expression<Func<T, T2, object>> expression = null, bool blnWithNoLock = false);


        ExpressionToSql<T> Select<T, T2, T3>(Expression<Func<T, T2, T3, object>> expression = null, bool blnWithNoLock = false);

        ExpressionToSql<T> Select<T, T2, T3, T4>(Expression<Func<T, T2, T3, T4, object>> expression = null, bool blnWithNoLock = false);


        ExpressionToSql<T> Select<T, T2, T3, T4, T5>(Expression<Func<T, T2, T3, T4, T5, object>> expression = null, bool blnWithNoLock = false);


        ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6>(Expression<Func<T, T2, T3, T4, T5, T6, object>> expression = null, bool blnWithNoLock = false);


        ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6, T7>(Expression<Func<T, T2, T3, T4, T5, T6, T7, object>> expression = null, bool blnWithNoLock = false);


        ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, object>> expression = null, bool blnWithNoLock = false);


        ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, object>> expression = null, bool blnWithNoLock = false);


        ExpressionToSql<T> Select<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> expression = null, bool blnWithNoLock = false);


        //ExpressionToSql<T> SelectTest<T>(Expression<Func<T>> expression = null);


        ExpressionToSql<T> Sum<T>(Expression<Func<T, object>> expression);


        ExpressionToSql<T> Update<T>(Expression<Func<object>> expression);
         

    }
}
