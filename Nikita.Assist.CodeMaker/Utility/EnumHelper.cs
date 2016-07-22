using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
    public class EnumHelper
    {
        /// <summary>
        /// 订单状态教程
        /// </summary>
        public enum OrderStatus
        {
            /// <summary>
            /// New
            /// </summary>
            [Description()]
            New = 1,

            /// <summary>
            /// Complate
            /// </summary>
            [Description()]
            Completed = 2
        }

        /// <summary>
        /// 字典存储
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetExtendForEnums(Type enumType)
        {
            Dictionary<int, string> allEnums = null;

            List<NameValueObject<int>> enums = GetObjectsFromEnum(enumType);
            if (enums != null && enums.Count > 0)
            {
                allEnums = new Dictionary<int, string>();
                foreach (NameValueObject<int> key in enums)
                {
                    if (!allEnums.ContainsKey(key.Value))
                    {
                        allEnums.Add(key.Value, key.Name);
                    }
                }
            }
            return allEnums;
        }

        /// <summary>
        /// 获取枚举类型对象集合
        /// </summary>
        public static List<NameValueObject<int>> GetObjectsFromEnum(string typeName)
        {
            Type enumType = Type.GetType(typeName);
            return GetObjectsFromEnum(enumType);
        }

        /// <summary>
        /// 获取枚举类型对象集合
        /// </summary>
        public static List<NameValueObject<int>> GetObjectsFromEnum(Type enumType)
        {
            if (enumType == null || enumType == (Type)Type.Missing || !enumType.IsEnum)
            {
                return null;
            }
            List<NameValueObject<int>> objs = new List<NameValueObject<int>>();
            Type typeDescription = typeof(DescriptionAttribute);
            FieldInfo[] fields = enumType.GetFields();
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    NameValueObject<int> obj = new NameValueObject<int>();
                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                        obj.Name = aa.Description;
                    }
                    else
                    {
                        obj.Name = field.Name;
                    }
                    string enumName = enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null).ToString();
                    obj.Value = Convert.ToInt32(Enum.Parse(enumType, enumName));
                    objs.Add(obj);
                }
            }
            return objs;
        }

        /// <summary>
        /// 获取枚举类型值对应的描述名称
        /// </summary>
        public string GetNameFromEnum(Type enumType, object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return string.Empty;
            }
            if (enumType.IsEnum)
            {
                string name = Enum.GetName(enumType, value);
                Type typeDescription = typeof(DescriptionAttribute);
                FieldInfo[] fields = enumType.GetFields();
                foreach (FieldInfo field in fields)
                {
                    if (field.FieldType.IsEnum && field.Name == name)
                    {
                        object[] arr = field.GetCustomAttributes(typeDescription, true);
                        if (arr.Length > 0)
                        {
                            DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                            return aa.Description;
                        }
                    }
                }
            }
            return value.ToString();
        }
    }

    /// <summary>
    /// 名称值对象
    /// </summary>

    public class NameValueObject<T>
    {
        public NameValueObject()
        {
        }

        public NameValueObject(string name, T value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }

        public T Value { get; set; }
    }
}