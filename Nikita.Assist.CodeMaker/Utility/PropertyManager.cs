using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Nikita.Core.Literacy;

namespace Nikita.Assist.CodeMaker
{
    public class PropertyManager : IProperty
    {
        readonly Dictionary<object, Literacy> _dicLiteracyDictionary = new Dictionary<object, Literacy>();

        private static PropertyManager m_propertyManager;

        public static PropertyManager BsePropertyManager
        {
            get { return m_propertyManager ?? (m_propertyManager = new PropertyManager()); }
        }

        public object GetProperty<T>(T obj, string strPropertyName)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            Literacy literacy;
            if (_dicLiteracyDictionary.ContainsKey(obj.GetType().ToString()))
            {
                _dicLiteracyDictionary.TryGetValue(obj.GetType(), out literacy);
                if (literacy != null)
                {
                    if (  literacy.Property.ContainsKey(strPropertyName))
                    { 
                        return literacy.Property[strPropertyName].GetValue(obj);
                    }
                    throw new NotSupportedException("对象不包含" + strPropertyName + "属性");
                }
            }
            literacy = new Literacy(obj.GetType());
            if (literacy == null)
            {
                throw new NotSupportedException("未能找到对象" + obj.GetType() + "");
            }
            if (!_dicLiteracyDictionary.ContainsKey(obj.GetType().ToString()))
            {
                _dicLiteracyDictionary.Add(obj.GetType().ToString(), literacy);
            }
            if (literacy.Property.ContainsKey(strPropertyName))
            {
                return literacy.Property[strPropertyName].GetValue(obj);
            }
            throw new NotSupportedException("对象不包含" + strPropertyName + "属性"); 
        }

        public void SetProperty<T>(T obj, string strPropertyName, object objValue)
        {
            Literacy literacy = GetLiteracy(obj);
            if (literacy != null)
            {
                if (literacy.Property.ContainsKey(strPropertyName))
                { 
                    literacy.Property[strPropertyName].SetValue(obj, objValue);
                }
                else
                { 
                    throw new NotSupportedException("对象不包含" + strPropertyName + "属性"); 
                }
            }
            else
            { 
                throw new NotSupportedException("未能找到对象" + obj.GetType() + "");
            }
        }

        public Literacy GetLiteracy(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            Literacy literacy = null;
            if (_dicLiteracyDictionary.ContainsKey(obj.GetType().ToString()))
            {
                _dicLiteracyDictionary.TryGetValue(obj.GetType(), out   literacy);
            }
            return literacy ?? (new Literacy(obj.GetType()));
        }
    }
}
