using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Nikita.Assist.CodeMaker
{
//    1. 你的就如下操作就OK.如果BOMG有个属性如Name.
//PropertyHelper<BomG> bh = new PropertyHelper<BomG>(bomg);
//string name = bh["Name"] as string;
//2.string dec = "qazxswedc";
//ProPertyHelper<string> dechelper = new PropertyHelper<string>(dec);
//int leng = (int)dechelper["Length"] ;
//主要是把原来用属性操作的变成只要记得相关的属性字符串就行.
    public class PropertyHelper<T>
    {
        private T entiy;
        public PropertyHelper(T t)
        {
            entiy = t;
            BindingAttr = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;
        }
        public BindingFlags BindingAttr { get; set; }

        public T Entiy
        {
            get
            {
                return entiy;
            }
        }
        public object this[string name]
        {
            get
            {
                return this[name, null];
            }
            set
            {
                this[name, null] = value;
            }
        }
        public object this[string name, object[] index]
        {
            get
            {
                if (name == null)
                    throw new ArgumentNullException("name");
                object obj;
                try
                {
                    PropertyInfo info = entiy.GetType().GetProperty(name, BindingAttr);
                    obj = info.GetValue(entiy, index);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                return obj;
            }
            set
            {
                if (name == null)
                    throw new ArgumentNullException("name");
                try
                {
                    PropertyInfo info = entiy.GetType().GetProperty(name, BindingAttr);
                    info.SetValue(entiy, value, index);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}
