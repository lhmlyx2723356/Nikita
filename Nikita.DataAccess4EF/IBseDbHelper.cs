using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nikita.DataAccess4EF
{
   public   interface IBseDbHelper
    { 
        #region 通用增删改查
        #region 非原始sql语句方式

        /// <summary>新增
        /// 新增
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>返回受影响行数</returns> 
         bool Add<T>(T entity) where T : class;

        /// <summary> 修改
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>返回受影响行数</returns>
         bool Update<T>(T entity) where T : class;

        /// <summary>删除
        /// 删除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>返回受影响行数</returns>
         bool Delete<T>(T entity) where T : class;

        /// <summary>根据条件删除
        /// 根据条件删除
        /// </summary>
        /// <param name="deleWhere">删除条件</param>
        /// <returns>返回受影响行数</returns>
         bool DeleteByConditon<T>(Expression<Func<T, bool>> deleWhere) where T : class;

        /// <summary> 查找单个
        /// 查找单个
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
         T GetSingleById<T>(int id) where T : class;

        /// <summary>查找单个
        /// 查找单个
        /// </summary>
        /// <param name="seleWhere">查询条件</param>
        /// <returns></returns>
         T GetSingle<T>(Expression<Func<T, bool>> seleWhere) where T : class;

        /// <summary>获取所有实体集合
        /// 获取所有实体集合
        /// </summary>
        /// <returns></returns>
         List<T> GetAll<T>() where T : class;

        /// <summary>获取所有实体集合AsNoTracking
        /// 获取所有实体集合AsNoTracking
        /// </summary>
        /// <returns></returns>
         List<T> GetAllAsNoTracking<T>() where T : class;

        /// <summary> 获取所有实体集合(单个排序)
        /// 获取所有实体集合(单个排序)
        /// </summary>
        /// <returns></returns>
         List<T> GetAll<T, Tkey>(Expression<Func<T, Tkey>> orderWhere, bool isDesc) where T : class;

        /// <summary> 获取所有实体集合(单个排序)AsNoTracking
        /// 获取所有实体集合(单个排序)AsNoTracking
        /// </summary>
        /// <returns></returns>
         List<T> GetAllAsNoTracking<T, Tkey>(Expression<Func<T, Tkey>> orderWhere, bool isDesc) where T : class;

        /// <summary>获取所有实体集合(多个排序)
        /// 获取所有实体集合(多个排序)
        /// </summary>
        /// <returns></returns>
         List<T> GetAll<T>(params OrderModelField[] orderByExpression) where T : class;

        /// <summary>获取所有实体集合(多个排序)AsNoTracking
        /// 获取所有实体集合(多个排序)AsNoTracking
        /// </summary>
        /// <returns></returns>
         List<T> GetAllAsNoTracking<T>(params OrderModelField[] orderByExpression) where T : class;

        /// <summary>单个排序通用方法
        /// 单个排序通用方法
        /// </summary>
        /// <typeparam name="Tkey">排序字段</typeparam>
        /// <param name="data">要排序的数据</param>
        /// <param name="orderWhere">排序条件</param>
        /// <param name="isDesc">是否倒序</param>
        /// <returns>排序后的集合</returns>
         IQueryable<T> CommonSort<T, Tkey>(IQueryable<T> data, Expression<Func<T, Tkey>> orderWhere, bool isDesc) where T : class;

        /// <summary>/ 多个排序通用方法
        /// 多个排序通用方法
        /// </summary>
        /// <typeparam name="Tkey">排序字段</typeparam>
        /// <param name="data">要排序的数据</param>
        /// <param name="orderWhereAndIsDesc">字典集合(排序条件,是否倒序)</param>
        /// <returns>排序后的集合</returns>
         IQueryable<T> CommonSort<T>(IQueryable<T> data, params OrderModelField[] orderByExpression) where T : class;

        /// <summary>/ 根据条件查询实体集合
        /// 根据条件查询实体集合
        /// </summary>
        /// <param name="seleWhere">查询条件 lambel表达式</param>
        /// <returns></returns>
         List<T> GetList<T>(Expression<Func<T, bool>> seleWhere) where T : class;

        /// <summary>根据条件查询实体集合
        /// 根据条件查询实体集合
        /// </summary>
        /// <param name="seleWhere">查询条件 lambel表达式</param>
        /// <returns></returns>
         List<T> GetList<T, TValue>(Expression<Func<T, TValue>> seleWhere, IEnumerable<TValue> conditions) where T : class;

        /// <summary>根据条件查询实体集合(单个字段排序)
        /// 根据条件查询实体集合(单个字段排序)
        /// </summary>
        /// <param name="seleWhere">查询条件 lambel表达式</param>
        /// <returns></returns>
         List<T> GetList<T, Tkey>(Expression<Func<T, bool>> seleWhere, Expression<Func<T, Tkey>> orderWhere, bool isDesc) where T : class;

        /// <summary>根据条件查询实体集合(多个字段排序)
        /// 根据条件查询实体集合(多个字段排序)
        /// </summary>
        /// <param name="seleWhere">查询条件 lambel表达式</param>
        /// <returns></returns>
         List<T> GetList<T>(Expression<Func<T, bool>> seleWhere, params OrderModelField[] orderByExpression) where T : class
    ;
        /// <summary>获取分页集合(无条件无排序)
        /// 获取分页集合(无条件无排序)
        /// </summary>
        /// <returns></returns>
         List<T> GetListPaged<T, Tkey>(int pageIndex, int pageSize, out int totalcount) where T : class;

        /// <summary>获取分页集合(无条件单个排序)
        /// 获取分页集合(无条件单个排序)
        /// </summary>
        /// <returns></returns>
         List<T> GetListPaged<T, Tkey>(int pageIndex, int pageSize, Expression<Func<T, Tkey>> orderWhere, bool isDesc, out int totalcount) where T : class;

        /// <summary>获取分页集合(无条件多字段排序)
        /// 获取分页集合(无条件多字段排序)
        /// </summary>
        /// <returns></returns>
         List<T> GetListPaged<T>(int pageIndex, int pageSize, out int totalcount, params OrderModelField[] orderByExpression) where T : class;

        /// <summary>获取分页集合(有条件无排序)
        /// 获取分页集合(有条件无排序)
        /// </summary>
        /// <returns></returns>
         List<T> GetListPaged<T, Tkey>(int pageIndex, int pageSize, Expression<Func<T, bool>> seleWhere, out int totalcount) where T : class;

        /// <summary>获取分页集合(有条件单个排序)
        /// 获取分页集合(有条件单个排序)
        /// </summary>
        /// <returns></returns>
         List<T> GetListPaged<T, Tkey>(int pageIndex, int pageSize, Expression<Func<T, bool>> seleWhere,
            Expression<Func<T, Tkey>> orderWhere, bool isDesc, out int totalcount) where T : class;

        /// <summary>获取分页集合(有条件多字段排序)
        /// 获取分页集合(有条件多字段排序)
        /// </summary>
        /// <returns></returns>
         List<T> GetListPaged<T>(int pageIndex, int pageSize, Expression<Func<T, bool>> seleWhere,
            out int totalcount, params OrderModelField[] orderModelFiled) where T : class;
        #endregion

        #region 原始sql操作
        /// <summary>执行操作
        /// 执行操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
         void ExecuteSql(string sql, params object[] paras);

        /// <summary> 查询列表
        /// 查询列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
         List<T> QueryList<T>(string sql, params object[] paras) where T : class;

        /// <summary>查询单个
        /// 查询单个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
         T QuerySingle<T>(string sql, params object[] paras) where T : class;

        /// <summary> 执行事务https://msdn.microsoft.com/en-us/data/dn456843
        /// 执行事务
        /// </summary>
        /// <param name="lsSql"></param>
        /// <param name="lsParas"></param>
         void ExecuteTransaction(List<String> lsSql, List<Object[]> lsParas);
        #endregion
        #endregion 
    }

}
