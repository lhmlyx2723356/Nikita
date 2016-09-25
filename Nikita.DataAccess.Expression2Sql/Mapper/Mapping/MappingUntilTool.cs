using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Nikita.DataAccess.Expression2Sql.Mapper
{
    /// <summary>
    /// ** 描述：工具类
    /// </summary>
    public class MappingUntilTool
    {
        internal static Type StringType = typeof(string);
        internal static Type IntType = typeof(int);
        internal static Type DecType = typeof(decimal);
        internal static Type GuidType = typeof(Guid);
        internal static Type DateType = typeof(DateTime);
        internal static Type ByteType = typeof(Byte);
        internal static Type BoolType = typeof(bool);
        internal static Type ObjType = typeof(object);
        internal static Type Dob = typeof(double);
        internal static Type DicSS = typeof(KeyValuePair<string, string>);
        internal static Type DicSi = typeof(KeyValuePair<string, int>);
        internal static Type Dicii = typeof(KeyValuePair<int, int>);
        internal static Type DicOO = typeof(KeyValuePair<object, object>);
        internal static Type DicSo = typeof(KeyValuePair<string, object>);
        internal static Type DicIS = typeof(KeyValuePair<int, string>);
        internal static Type DicArraySS = typeof(Dictionary<string, string>);
        internal static Type DicArraySO = typeof(Dictionary<string, object>);

        /// <summary>
        /// Reader转成List《T》
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="dr"></param>
        /// <param name="isClose"></param>
        /// <returns></returns>
        internal static List<T> DataReaderToList<T>(Type type, IDataReader dr, string fields, bool isClose = true, bool isTry = true)
        {
            if (type.Name.Contains("KeyValuePair"))
            {
                List<T> strReval = new List<T>();
                FillValueTypeToDictionary(type, dr, strReval);
                return strReval;
            }
            //值类型
            else if (type.IsValueType || type == MappingUntilTool.StringType)
            {
                List<T> strReval = new List<T>();
                FillValueTypeToDr<T>(type, dr, strReval);
                return strReval;
            }
            //数组类型
            else if (type.IsArray)
            {
                List<T> strReval = new List<T>();
                FillValueTypeToArray(type, dr, strReval);
                return strReval;
            }

            var cacheManager = CacheManager<DataReaderEntityBuilder<T>>.GetInstance();
            string key = "DataReaderToList." + fields + type.FullName;
            DataReaderEntityBuilder<T> eblist = null;
            if (cacheManager.ContainsKey(key))
            {
                eblist = cacheManager[key];
            }
            else
            {
                eblist = DataReaderEntityBuilder<T>.CreateBuilder(type, dr);
                cacheManager.Add(key, eblist, cacheManager.Day);
            }
            List<T> list = new List<T>();
            try
            {
                if (dr == null) return list;
                while (dr.Read())
                {
                    list.Add(eblist.Build(dr));
                }
                if (isClose) { dr.Close(); dr.Dispose(); dr = null; }
            }
            catch (Exception ex)
            {
                if (isClose) { dr.Close(); dr.Dispose(); dr = null; }
                throw ex;
            }
            return list;
        }

        private static void FillValueTypeToDr<T>(Type type, IDataReader dr, List<T> strReval)
        {
            using (IDataReader re = dr)
            {
                while (re.Read())
                {
                    strReval.Add((T)Convert.ChangeType(re.GetValue(0), type));
                }
            }
        }

        private static void FillValueTypeToDictionary<T>(Type type, IDataReader dr, List<T> strReval)
        {
            using (IDataReader re = dr)
            {
                Dictionary<string, string> reval = new Dictionary<string, string>();
                while (re.Read())
                {
                    if (MappingUntilTool.DicOO == type)
                    {
                        var kv = new KeyValuePair<object, object>((object)Convert.ChangeType(re.GetValue(0), typeof(object)), (int)Convert.ChangeType(re.GetValue(1), typeof(object)));
                        strReval.Add((T)Convert.ChangeType(kv, typeof(KeyValuePair<object, object>)));
                    }
                    else if (MappingUntilTool.Dicii == type)
                    {
                        var kv = new KeyValuePair<int, int>((int)Convert.ChangeType(re.GetValue(0), typeof(int)), (int)Convert.ChangeType(re.GetValue(1), typeof(int)));
                        strReval.Add((T)Convert.ChangeType(kv, typeof(KeyValuePair<int, int>)));
                    }
                    else if (MappingUntilTool.DicSi == type)
                    {
                        var kv = new KeyValuePair<string, int>((string)Convert.ChangeType(re.GetValue(0), typeof(string)), (int)Convert.ChangeType(re.GetValue(1), typeof(int)));
                        strReval.Add((T)Convert.ChangeType(kv, typeof(KeyValuePair<string, int>)));
                    }
                    else if (MappingUntilTool.DicSo == type)
                    {
                        var kv = new KeyValuePair<string, object>((string)Convert.ChangeType(re.GetValue(0), typeof(string)), (object)Convert.ChangeType(re.GetValue(1), typeof(object)));
                        strReval.Add((T)Convert.ChangeType(kv, typeof(KeyValuePair<string, object>)));
                    }
                    else if (MappingUntilTool.DicSS == type)
                    {
                        var kv = new KeyValuePair<string, string>((string)Convert.ChangeType(re.GetValue(0), typeof(string)), (string)Convert.ChangeType(re.GetValue(1), typeof(string)));
                        strReval.Add((T)Convert.ChangeType(kv, typeof(KeyValuePair<string, string>)));
                    }
                    else
                    {
                        throw new Exception("暂时不支持该类型的Dictionary 你可以试试 Dictionary<string ,string>或者联系作者！！");
                    }
                }
            }
        }

        private static void FillValueTypeToArray<T>(Type type, IDataReader dr, List<T> strReval)
        {
            using (IDataReader re = dr)
            {
                int count = dr.FieldCount;
                var childType = type.GetElementType();
                while (re.Read())
                {
                    object[] array = new object[count];
                    for (int i = 0; i < count; i++)
                    {
                        array[i] = Convert.ChangeType(re.GetValue(i), childType);
                    }
                    if (childType == MappingUntilTool.StringType)
                        strReval.Add((T)Convert.ChangeType(array.Select(it => (string)it).ToArray(), type));
                    else if (childType == MappingUntilTool.ObjType)
                        strReval.Add((T)Convert.ChangeType(array.Select(it => (object)it).ToArray(), type));
                    else if (childType == MappingUntilTool.BoolType)
                        strReval.Add((T)Convert.ChangeType(array.Select(it => (bool)it).ToArray(), type));
                    else if (childType == MappingUntilTool.ByteType)
                        strReval.Add((T)Convert.ChangeType(array.Select(it => (byte)it).ToArray(), type));
                    else if (childType == MappingUntilTool.DecType)
                        strReval.Add((T)Convert.ChangeType(array.Select(it => (decimal)it).ToArray(), type));
                    else if (childType == MappingUntilTool.GuidType)
                        strReval.Add((T)Convert.ChangeType(array.Select(it => (Guid)it).ToArray(), type));
                    else if (childType == MappingUntilTool.DateType)
                        strReval.Add((T)Convert.ChangeType(array.Select(it => (DateTime)it).ToArray(), type));
                    else if (childType == MappingUntilTool.IntType)
                        strReval.Add((T)Convert.ChangeType(array.Select(it => (int)it).ToArray(), type));
                    else

                        throw new Exception("暂时不支持该类型的Array 你可以试试 object[] 或者联系作者！！");
                }
            }
        }

        public static void SetParSize(SqlParameter par)
        {
            int size = par.Size;
            if (size < 4000)
            {
                par.Size = 4000;
            }
        }

        /// <summary>
        /// 处理like条件的通配符
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string SqlLikeWordEncode(string word)
        {
            if (word == null) return word;
            return Regex.Replace(word, @"(\[|\%)", "[$1]");
        }

        public static string GetLockString(bool isNoLock)
        {
            return isNoLock ? " WITH(NOLOCK) " : "";
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        internal static Guid GetPropertyValue(object obj, string property)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(property);
            return (Guid)propertyInfo.GetValue(obj, null);
        }

        /// <summary>
        /// 包装SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="shortName"></param>
        /// <returns></returns>
        internal static string PackagingSQL(string sql, string shortName)
        {
            return string.Format(" SELECT * FROM ({0}) {1} ", sql, shortName);
        }

        /// <summary>
        /// 使用页面自动填充sqlParameter时 Request.Form出现特殊字符时可以重写Request.Form方法，使用时注意加锁并且用到将该值设为null
        /// </summary>
        public static Func<string, string> SpecialRequestForm = null;

        /// <summary>
        /// 获取最底层类型
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="isNullable"></param>
        /// <returns></returns>
        internal static Type GetUnderType(PropertyInfo propertyInfo, ref bool isNullable)
        {
            Type unType = Nullable.GetUnderlyingType(propertyInfo.PropertyType);
            isNullable = unType != null;
            unType = unType ?? propertyInfo.PropertyType;
            return unType;
        }
    }
}