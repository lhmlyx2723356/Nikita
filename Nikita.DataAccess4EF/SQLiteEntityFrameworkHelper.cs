using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqKit;

namespace Nikita.DataAccess4EF
{
    public class SQLiteEntityFrameworkHelper : IBseDbHelper
    {

        string strConn = "";
        public SQLiteEntityFrameworkHelper(string connString)
        {
            strConn = connString;
        }

        #region 通用增删改查
        #region 非原始sql语句方式

        /// <summary>新增
        /// 新增
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>返回受影响行数</returns> 
        public bool Add<T>(T entity) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                db.Entry<T>(entity).State = EntityState.Added;
                return db.SaveChanges() > 0;
            }
        }

        /// <summary> 修改
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>返回受影响行数</returns>
        public bool Update<T>(T entity) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                db.Set<T>().Attach(entity);
                db.Entry<T>(entity).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>删除
        /// 删除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>返回受影响行数</returns>
        public bool Delete<T>(T entity) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                db.Set<T>().Attach(entity);
                db.Entry<T>(entity).State = EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>根据条件删除
        /// 根据条件删除
        /// </summary>
        /// <param name="deleWhere">删除条件</param>
        /// <returns>返回受影响行数</returns>
        public bool DeleteByConditon<T>(Expression<Func<T, bool>> deleWhere) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                List<T> entitys = db.Set<T>().Where(deleWhere).ToList();
                entitys.ForEach(m => db.Entry<T>(m).State = EntityState.Deleted);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary> 查找单个
        /// 查找单个
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public T GetSingleById<T>(int id) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                return db.Set<T>().Find(id);
            }
        }

        /// <summary>查找单个
        /// 查找单个
        /// </summary>
        /// <param name="seleWhere">查询条件</param>
        /// <returns></returns>
        public T GetSingle<T>(Expression<Func<T, bool>> seleWhere) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                return db.Set<T>().AsExpandable().FirstOrDefault(seleWhere);
            }
        }

        /// <summary>获取所有实体集合
        /// 获取所有实体集合
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll<T>() where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                return db.Set<T>().AsExpandable().ToList<T>();
            }
        }

        /// <summary>获取所有实体集合AsNoTracking
        /// 获取所有实体集合AsNoTracking
        /// </summary>
        /// <returns></returns>
        public List<T> GetAllAsNoTracking<T>() where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                return db.Set<T>().AsExpandable().AsNoTracking().ToList<T>();
            }
        }
         
        /// <summary> 获取所有实体集合(单个排序)
        /// 获取所有实体集合(单个排序)
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll<T, Tkey>(Expression<Func<T, Tkey>> orderWhere, bool isDesc) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                return CommonSort(db.Set<T>().AsExpandable(), orderWhere, isDesc).ToList<T>();
            }
        }
        /// <summary> 获取所有实体集合(单个排序)AsNoTracking
        /// 获取所有实体集合(单个排序)AsNoTracking
        /// </summary>
        /// <returns></returns>
        public List<T> GetAllAsNoTracking<T, Tkey>(Expression<Func<T, Tkey>> orderWhere, bool isDesc) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                return CommonSort(db.Set<T>().AsExpandable().AsNoTracking(), orderWhere, isDesc).ToList<T>();
            }
        }

        /// <summary>获取所有实体集合(多个排序)
        /// 获取所有实体集合(多个排序)
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll<T>(params OrderModelField[] orderByExpression) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                return CommonSort(db.Set<T>().AsExpandable(), orderByExpression).ToList();
            }
        }

        /// <summary>获取所有实体集合(多个排序)AsNoTracking
        /// 获取所有实体集合(多个排序)AsNoTracking
        /// </summary>
        /// <returns></returns>
        public List<T> GetAllAsNoTracking<T>(params OrderModelField[] orderByExpression) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                return CommonSort(db.Set<T>().AsExpandable().AsNoTracking(), orderByExpression).ToList();
            }
        }
         
        /// <summary>单个排序通用方法
        /// 单个排序通用方法
        /// </summary>
        /// <typeparam name="Tkey">排序字段</typeparam>
        /// <param name="data">要排序的数据</param>
        /// <param name="orderWhere">排序条件</param>
        /// <param name="isDesc">是否倒序</param>
        /// <returns>排序后的集合</returns>
        public IQueryable<T> CommonSort<T, Tkey>(IQueryable<T> data, Expression<Func<T, Tkey>> orderWhere, bool isDesc) where T : class
        {
            if (isDesc)
            {
                return data.OrderByDescending(orderWhere);
            }
            else
            {
                return data.OrderBy(orderWhere);
            }
        }

        /// <summary>/ 多个排序通用方法
        /// 多个排序通用方法
        /// </summary>
        /// <typeparam name="Tkey">排序字段</typeparam>
        /// <param name="data">要排序的数据</param>
        /// <param name="orderWhereAndIsDesc">字典集合(排序条件,是否倒序)</param>
        /// <returns>排序后的集合</returns>
        public IQueryable<T> CommonSort<T>(IQueryable<T> data, params OrderModelField[] orderByExpression) where T : class
        {
            //创建表达式变量参数
            var parameter = Expression.Parameter(typeof(T), "o");

            if (orderByExpression != null && orderByExpression.Length > 0)
            {
                for (int i = 0; i < orderByExpression.Length; i++)
                {
                    //根据属性名获取属性
                    var property = typeof(T).GetProperty(orderByExpression[i].PropertyName);
                    //创建一个访问属性的表达式
                    var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                    var orderByExp = Expression.Lambda(propertyAccess, parameter);

                    string OrderName = "";
                    if (i > 0)
                    {
                        OrderName = orderByExpression[i].IsDESC ? "ThenByDescending" : "ThenBy";
                    }
                    else
                        OrderName = orderByExpression[i].IsDESC ? "OrderByDescending" : "OrderBy";

                    MethodCallExpression resultExp = Expression.Call(typeof(Queryable), OrderName, new Type[] { typeof(T), property.PropertyType },
                        data.Expression, Expression.Quote(orderByExp));

                    data = data.Provider.CreateQuery<T>(resultExp);
                }
            }
            return data;
        }

        /// <summary>/ 根据条件查询实体集合
        /// 根据条件查询实体集合
        /// </summary>
        /// <param name="seleWhere">查询条件 lambel表达式</param>
        /// <returns></returns>
        public List<T> GetList<T>(Expression<Func<T, bool>> seleWhere) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                return db.Set<T>().AsExpandable().Where(seleWhere).ToList();
            }
        }

        /// <summary>根据条件查询实体集合
        /// 根据条件查询实体集合
        /// </summary>
        /// <param name="seleWhere">查询条件 lambel表达式</param>
        /// <returns></returns>
        public List<T> GetList<T, TValue>(Expression<Func<T, TValue>> seleWhere, IEnumerable<TValue> conditions) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {

                return db.Set<T>().AsExpandable().WhereIn<T, TValue>(seleWhere, conditions).ToList();
            }
        }

        /// <summary>根据条件查询实体集合(单个字段排序)
        /// 根据条件查询实体集合(单个字段排序)
        /// </summary>
        /// <param name="seleWhere">查询条件 lambel表达式</param>
        /// <returns></returns>
        public List<T> GetList<T, Tkey>(Expression<Func<T, bool>> seleWhere, Expression<Func<T, Tkey>> orderWhere, bool isDesc) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                return CommonSort(db.Set<T>().AsExpandable().Where(seleWhere), orderWhere, isDesc).ToList();
            }
        }

        /// <summary>根据条件查询实体集合(多个字段排序)
        /// 根据条件查询实体集合(多个字段排序)
        /// </summary>
        /// <param name="seleWhere">查询条件 lambel表达式</param>
        /// <returns></returns>
        public List<T> GetList<T>(Expression<Func<T, bool>> seleWhere, params OrderModelField[] orderByExpression) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                return CommonSort(db.Set<T>().AsExpandable().Where(seleWhere), orderByExpression).ToList();
            }
        }

        /// <summary>获取分页集合(无条件无排序)
        /// 获取分页集合(无条件无排序)
        /// </summary>
        /// <returns></returns>
        public List<T> GetListPaged<T, Tkey>(int pageIndex, int pageSize, out int totalcount) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                totalcount = db.Set<T>().AsExpandable().Count();//获取总数
                //需要增加AsExpandable(),否则查询的是所有数据到内存，然后再排序  AsExpandable是linqkit.dll中的方法
                return db.Set<T>().AsExpandable().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }


        /// <summary>获取分页集合(无条件单个排序)
        /// 获取分页集合(无条件单个排序)
        /// </summary>
        /// <returns></returns>
        public List<T> GetListPaged<T, Tkey>(int pageIndex, int pageSize, Expression<Func<T, Tkey>> orderWhere, bool isDesc, out int totalcount) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                totalcount = db.Set<T>().AsExpandable().Count();//获取总数
                //需要增加AsExpandable(),否则查询的是所有数据到内存，然后再排序  AsExpandable是linqkit.dll中的方法
                return CommonSort(db.Set<T>().AsExpandable(), orderWhere, isDesc).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        /// <summary>获取分页集合(无条件多字段排序)
        /// 获取分页集合(无条件多字段排序)
        /// </summary>
        /// <returns></returns>
        public List<T> GetListPaged<T>(int pageIndex, int pageSize, out int totalcount, params OrderModelField[] orderByExpression) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                totalcount = db.Set<T>().AsExpandable().Count();//获取总数
                //需要增加AsExpandable(),否则查询的是所有数据到内存，然后再排序  AsExpandable是linqkit.dll中的方法
                return CommonSort(db.Set<T>().AsExpandable(), orderByExpression).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        /// <summary>获取分页集合(有条件无排序)
        /// 获取分页集合(有条件无排序)
        /// </summary>
        /// <returns></returns>
        public List<T> GetListPaged<T, Tkey>(int pageIndex, int pageSize, Expression<Func<T, bool>> seleWhere, out int totalcount) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                totalcount = db.Set<T>().AsExpandable().Where(seleWhere).Count();//获取总数
                //需要增加AsExpandable(),否则查询的是所有数据到内存，然后再排序  AsExpandable是linqkit.dll中的方法
                return db.Set<T>().AsExpandable().Where(seleWhere).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        /// <summary>获取分页集合(有条件单个排序)
        /// 获取分页集合(有条件单个排序)
        /// </summary>
        /// <returns></returns>
        public List<T> GetListPaged<T, Tkey>(int pageIndex, int pageSize, Expression<Func<T, bool>> seleWhere,
            Expression<Func<T, Tkey>> orderWhere, bool isDesc, out int totalcount) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                totalcount = db.Set<T>().AsExpandable().Where(seleWhere).Count();//获取总数
                //需要增加AsExpandable(),否则查询的是所有数据到内存，然后再排序  AsExpandable是linqkit.dll中的方法
                return CommonSort(db.Set<T>().AsExpandable().Where(seleWhere), orderWhere, isDesc).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        /// <summary>获取分页集合(有条件多字段排序)
        /// 获取分页集合(有条件多字段排序)
        /// </summary>
        /// <returns></returns>
        public List<T> GetListPaged<T>(int pageIndex, int pageSize, Expression<Func<T, bool>> seleWhere,
            out int totalcount, params OrderModelField[] orderModelFiled) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                totalcount = db.Set<T>().AsExpandable().Where(seleWhere).Count();//获取总数
                //需要增加AsExpandable(),否则查询的是所有数据到内存，然后再排序  AsExpandable是linqkit.dll中的方法
                return CommonSort(db.Set<T>().AsExpandable().Where(seleWhere), orderModelFiled).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }
        #endregion

        #region 原始sql操作
        /// <summary>执行操作
        /// 执行操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        public void ExecuteSql(string sql, params object[] paras)
        {
            using (SysDb db = new SysDb(strConn))
            {
                db.Database.ExecuteSqlCommand(sql, paras);
            }
        }

        /// <summary> 查询列表
        /// 查询列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public List<T> QueryList<T>(string sql, params object[] paras) where T : class
        {
            using (SysDb db = new SysDb(strConn))
            {
                return db.Database.SqlQuery<T>(sql, paras).ToList();
            }
        }

        /// <summary>查询单个
        /// 查询单个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public T QuerySingle<T>(string sql, params object[] paras) where T : class
        {
            using (SysDb<T> db = new SysDb<T>(strConn))
            {
                return db.Database.SqlQuery<T>(sql, paras).FirstOrDefault();
            }
        }

        /// <summary> 执行事务https://msdn.microsoft.com/en-us/data/dn456843
        /// 执行事务
        /// </summary>
        /// <param name="lsSql"></param>
        /// <param name="lsParas"></param>
        public void ExecuteTransaction(List<String> lsSql, List<Object[]> lsParas)
        {
            using (SysDb db = new SysDb(strConn))
            {
                using (var tran = db.Database.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < lsSql.Count; i++)
                        {
                            if (lsParas != null && lsParas.Count > 0)
                            {
                                db.Database.ExecuteSqlCommand(lsSql[i], lsParas[i]);
                            }
                        }
                        foreach (String item in lsSql)
                        {
                            db.Database.ExecuteSqlCommand(item);
                        }

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                }
            }
        }
        #endregion
        #endregion

        #region 通用属性
        /// <summary>获取数据库服务器当前时间。
        /// 获取数据库服务器当前时间。
        /// </summary>
        public DateTime ServerTime
        {
            get
            {
                using (SysDb db = new SysDb(strConn))
                {
                    String sql = "SELECT GETDATE()";
                    Object objServerTime = db.Database.SqlQuery<Object>(sql);
                    return Convert.ToDateTime(objServerTime);
                }
            }
        }

        /// <summary>获取数据库版本。
        /// 获取数据库版本。
        /// </summary>
        public String DatabaseVersion
        {
            get
            {
                using (SysDb db = new SysDb(strConn))
                {
                    try
                    {
                        String sql = "SELECT Version FROM Sys_Version";
                        Object objServerTime = db.Database.SqlQuery<Object>(sql);
                        return Convert.ToString(objServerTime);
                    }
                    catch
                    {
                    }
                    return String.Empty;
                }
            }
        }
        #endregion 

    }


}
