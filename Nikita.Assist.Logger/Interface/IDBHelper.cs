using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Assist.Logger
{
  public  interface IDBHelper
    { 
        /// <summary>创建Command对象
        /// 
        /// </summary>
        /// <param name="sql">SQL语句</param>
         void CreateCommand(string sql);


        /// <summary>添加参数
        /// 
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="value">值</param>
         void AddParameter(string paramName, object value);


        /// <summary>执行不带参数的增删改SQL语句
        ///  
        /// </summary>
        /// <param name="cmdText">增删改SQL语句</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
         bool ExecuteNonQuery();

        /// <summary>执行查询SQL语句
        ///  
        /// </summary>
        /// <param name="cmdText">查询SQL语句</param>
        /// <returns></returns>
         DataTable ExecuteQuery();


        /// <summary>返回查询SQL语句查询出的结果的第一行第一列的值
        /// 
        /// </summary>
        /// <returns></returns>
         string ExecuteScalar();


        /// <summary>返回IDataReader
        /// 
        /// </summary>
        /// <returns></returns>
         IDataReader ExecuteReader();

        /// <summary>关闭数据库连接
        /// 
        /// </summary>
         void CloseConn();

         /// <summary>测试连接
         /// 
         /// </summary>
         bool TestConn();
    }
}
