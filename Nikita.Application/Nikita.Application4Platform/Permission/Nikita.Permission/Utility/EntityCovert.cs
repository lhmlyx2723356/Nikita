using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Permission
{
    public class EntityCovert
    {
        public static IList<T> GetEntities<T>(DataTable table) where T : new()
        {
            IList<T> entities = new List<T>();
            foreach (DataRow row in table.Rows)
            {
                T entity = new T();
                foreach (var item in entity.GetType().GetProperties())
                {
                    item.SetValue(entity, Convert.ChangeType(row[item.Name], item.PropertyType), null);
                }
                entities.Add(entity);
            }
            return entities;
        }

        public static T GetEntity<T>(DataTable table) where T : new()
        {
            T entity = new T();
            foreach (DataRow row in table.Rows)
            {
                foreach (var item in entity.GetType().GetProperties())
                {
                    if (row.Table.Columns.Contains(item.Name))
                    {
                        if (DBNull.Value != row[item.Name])
                        {
                            item.SetValue(entity, Convert.ChangeType(row[item.Name], item.PropertyType), null);
                        }
                    }
                }
            }

            return entity;
        }

        //获取实体类里面所有的名称、值、DESCRIPTION值
        public static Dictionary<string, object> GetProperties<T>(T t)
        {
            Dictionary<string, object> DicResult = new Dictionary<string, object>();
            if (t == null)
            {
                return DicResult;
            }
            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return DicResult;
            }
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name; //名称
                object value = item.GetValue(t, null);  //值
                //string des = ((DescriptionAttribute)Attribute.GetCustomAttribute(item, typeof(DescriptionAttribute))).Description;// 属性值

                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    DicResult.Add(name, value == null ? System.DBNull.Value : value);
                }
                else
                {
                    GetProperties(value);
                }
            }
            return DicResult;
        }

        public static DataRow SetDataRowByEntity<T>(DataRow dr, T t)
        {
            Dictionary<string, object> dicResult = GetProperties<T>(t);
            foreach (KeyValuePair<string, object> item in dicResult)
            {
                if (dr.Table.Columns.Contains(item.Key))
                {
                    dr[item.Key] = item.Value;
                }
                else
                {
                    dr[item.Key] = System.DBNull.Value;
                }
            }
            return dr;
        }
    }
}