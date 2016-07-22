using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text; 

namespace Nikita.Base.IDAL
{
    public interface IBseDAL<T> : IDependency where T : class
    {
        /// <summary>增加一条数据
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add(T model);

        /// <summary>更新一条数据
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(T model);

        /// <summary>根据条件更新字段
        /// 
        /// </summary>
        /// <param name="strFieldWithValue"></param>
        /// <param name="strCond"></param>
        /// <returns></returns>
        bool Update(string strFieldWithValue, string strCond);

        /// <summary>删除一条数据
        /// 
        /// </summary>
        /// <param name="intId"></param>
        /// <returns></returns>
        bool Delete(int intId);

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        /// <param name="strCond"></param>
        /// <returns></returns>
        bool DeleteByCond(string strCond);

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        /// <param name="intId"></param>
        /// <returns></returns>
        T GetModel(int intId);

        /// <summary>根据条件得到一个对象实体
        /// 
        /// </summary>
        /// <param name="strCond"></param>
        /// <returns></returns>
        T GetModelByCond(string strCond);

        /// <summary>获得数据列表
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataSet GetList(string strWhere);

        /// <summary>获得数据列表
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strFields"></param>
        /// <returns></returns>
        DataSet GetList(string strWhere, string strFields);

        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        /// <param name="strFileds"></param>
        /// <param name="strOrder"></param>
        /// <param name="strOrderType"></param>
        /// <param name="intPageSize"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataSet GetList(string strFileds, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere);

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        List<T> GetListArray(string strWhere);

        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        /// <param name="strFileds"></param>
        /// <param name="strOrder"></param>
        /// <param name="strOrderType"></param>
        /// <param name="intPageSize"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        List<T> GetListArray(string strFileds, string strOrder, string strOrderType, int intPageSize, int intPageIndex, string strWhere);

        /// <summary>对象实体绑定数据
        /// 
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        T ReaderBind(IDataReader dataReader);
        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="strCond"></param>
        /// <returns></returns>
        int CalcCount(string strCond);
    }
}
