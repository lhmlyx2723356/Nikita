using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Nikita.Base.Literacy;

namespace Nikita.Assist.CodeMaker
{
    public class BindRule
    {
        public static void ReturnObject<T>(Dictionary<string, DataTable> dicMappDictionary, ref List<T> lstObjectList)
        {
            foreach (T itemObj in lstObjectList)
            {
                Literacy literacy = GetLiteracy(itemObj);
                foreach (KeyValuePair<string, DataTable> map in dicMappDictionary)
                {
                    object obj = GetProperty(itemObj, map.Key);
                    DataRow[] drs = map.Value.Select("Name='" + obj + "'");
                    if (drs.Length > 0)
                    {
                        literacy.Property[map.Key].SetValue(itemObj, drs[0]["Value"].ToString());
                    }
                }
            }
        }

        static ObjectProperty prop;
        public static object GetProperty(object obj, string strPropertyName)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (prop == null)
            {
                prop = new Literacy(obj.GetType()).Property[strPropertyName];
                if (prop == null) throw new NotSupportedException("对象不包含" + strPropertyName + "属性");
            }
            return prop.GetValue(obj);
        }

        static Literacy literacy;
        public static Literacy GetLiteracy(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (literacy == null)
            {
                literacy = new Literacy(obj.GetType());
            }
            return literacy;
        }

    }
}
