using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Nikita.DataAccess.Expression2Sql.Mapper
{
    internal static class ReflectionHelper
    {
        private static Dictionary<Type, object> ReflectionInfoCache = new Dictionary<Type, object>(50);

        //用于匿名对象
        private static Dictionary<Type, PropertyInfo[]> PropertysDict = new Dictionary<Type, PropertyInfo[]>();

        public static ReflectionInfo<TObject> GetInfo<TObject>()
        {
            var type = typeof(TObject);
            object info;
            if (ReflectionInfoCache.TryGetValue(type, out info))
            {
                return (ReflectionInfo<TObject>)info;
            }
            else
            {
                var refInfo = new ReflectionInfo<TObject>(type);
                ReflectionInfoCache[type] = refInfo;
                return refInfo;
            }
        }

        public static PropertyInfo[] GetCachedProperties(Type type)
        {
            PropertyInfo[] value;
            if (PropertysDict.TryGetValue(type, out value))
            {
                return value;
            }
            value = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            PropertysDict[type] = value;
            return value;
        }
    }

    internal class ReflectionInfo<TObject>
    {
        public string TableName { get; set; }

        private Dictionary<string, Accessor> accessorDict;
        public Dictionary<PropertyInfo, OrmFieldAttribute> FieldAttrDict { get; private set; }
        public PropertyInfo[] Properties { get; }
        public Func<TObject> NewInstance;

        public ReflectionInfo(Type modelType)
        {
            var tableAttr = modelType.GetCustomAttributes(typeof(OrmTableAttribute), true).FirstOrDefault() as OrmTableAttribute;
            if (tableAttr != null && tableAttr.Name != null && tableAttr.Name.Length != 0)
            {
                TableName = tableAttr.Name;
            }
            else
            {
                if (modelType.Name.EndsWith("Info", StringComparison.OrdinalIgnoreCase))
                {
                    TableName = modelType.Name.Substring(0, modelType.Name.Length - 4);
                }
                else if (modelType.Name.EndsWith("Model", StringComparison.OrdinalIgnoreCase))
                {
                    TableName = modelType.Name.Substring(0, modelType.Name.Length - 5);
                }
                else
                {
                    TableName = modelType.Name;
                }
            }

            Properties = modelType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            //构造委托
            NewInstance = Expression.Lambda<Func<TObject>>(Expression.New(modelType)).Compile();
            InitInfo();
        }

        private void InitInfo()
        {
            accessorDict = new Dictionary<string, Accessor>(Properties.Length);
            FieldAttrDict = new Dictionary<PropertyInfo, OrmFieldAttribute>(Properties.Length);
            foreach (var prop in Properties)
            {
                Accessor accessor = null;

                string propName = prop.Name.ToUpper();
                var propType = prop.PropertyType;

                if (propType.IsEnum)
                {
                    propType = propType.GetEnumUnderlyingType();
                }
                if (typeof(string) == propType)
                {
                    accessor = new StringAccessor(prop);
                }
                else if (typeof(int) == propType)
                {
                    accessor = new IntAccessor(prop);
                }
                else if (typeof(int?) == propType)
                {
                    accessor = new IntNullableAccessor(prop);
                }
                else if (typeof(DateTime) == propType)
                {
                    accessor = new DateTimeAccessor(prop);
                }
                else if (typeof(DateTime?) == propType)
                {
                    accessor = new DateTimeNullableAccessor(prop);
                }
                else if (typeof(long) == propType)
                {
                    accessor = new LongAccessor(prop);
                }
                else if (typeof(long?) == propType)
                {
                    accessor = new LongNullableAccessor(prop);
                }
                else if (typeof(float) == propType)
                {
                    accessor = new FloatAccessor(prop);
                }
                else if (typeof(float?) == propType)
                {
                    accessor = new FloatNullableAccessor(prop);
                }
                else if (typeof(double) == propType)
                {
                    accessor = new DoubleAccessor(prop);
                }
                else if (typeof(double?) == propType)
                {
                    accessor = new DoubleNullableAccessor(prop);
                }
                else if (typeof(Guid) == propType)
                {
                    accessor = new GuidAccessor(prop);
                }
                else if (typeof(Guid?) == propType)
                {
                    accessor = new GuidNullableAccessor(prop);
                }
                else if (typeof(short) == propType)
                {
                    accessor = new ShortAccessor(prop);
                }
                else if (typeof(short?) == propType)
                {
                    accessor = new ShortNullableAccessor(prop);
                }
                else if (typeof(byte) == propType)
                {
                    accessor = new ByteAccessor(prop);
                }
                else if (typeof(byte?) == propType)
                {
                    accessor = new ByteNullableAccessor(prop);
                }
                else if (typeof(char) == propType)
                {
                    accessor = new CharAccessor(prop);
                }
                else if (typeof(char?) == propType)
                {
                    accessor = new CharNullableAccessor(prop);
                }
                else if (typeof(decimal) == propType)
                {
                    accessor = new DecimalAccessor(prop);
                }
                else if (typeof(decimal?) == propType)
                {
                    accessor = new DecimalNullableAccessor(prop);
                }
                else if (typeof(byte[]) == propType)
                {
                    accessor = new ByteArrayAccessor(prop);
                }
                else if (typeof(bool) == propType)
                {
                    accessor = new BoolAccessor(prop);
                }
                else if (typeof(bool?) == propType)
                {
                    accessor = new BoolNullableAccessor(prop);
                }
                else if (typeof(TimeSpan) == propType)
                {
                    accessor = new TimeSpanAccessor(prop);
                }
                else if (typeof(TimeSpan?) == propType)
                {
                    accessor = new TimeSpanNullableAccessor(prop);
                }
                accessorDict[propName] = accessor;
                //自定义属性
                var customerAttributes = prop.GetCustomAttributes(typeof(OrmFieldAttribute), false);
                if (customerAttributes == null || customerAttributes.Length == 0)
                {
                    FieldAttrDict[prop] = null;
                }
                else
                {
                    FieldAttrDict[prop] = (OrmFieldAttribute)customerAttributes[0];
                }
            }
        }

        public Accessor GetAccessor(string fieldName)
        {
            Accessor accessor;
            if (accessorDict.TryGetValue(fieldName.ToUpper(), out accessor))
            {
                return accessor;
            }
            return new EmptyAccessor();
        }

        public OrmFieldAttribute GetFieldAttr(PropertyInfo prop)
        {
            OrmFieldAttribute attr;
            if (FieldAttrDict.TryGetValue(prop, out attr))
            {
                return attr;
            }
            else
            {
                return null;
            }
        }

        public abstract class Accessor
        {
            public void Set(TObject obj, object value)
            {
                if (value == null || value is DBNull)
                {
                    return;
                }
                DoSet(obj, value);
            }

            public object Get(TObject obj)
            {
                return DoGet(obj);
            }

            protected abstract void DoSet(TObject obj, object value);

            protected abstract object DoGet(TObject obj);
        }

        #region Accessor

        public class EmptyAccessor : Accessor
        {
            protected override object DoGet(TObject obj)
            {
                return null;
            }

            protected override void DoSet(TObject obj, object value)
            {
                return;
            }
        }

        public class StringAccessor : Accessor
        {
            private Action<TObject, string> setter;
            private Func<TObject, string> getter;

            public StringAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, string>)Delegate.CreateDelegate(typeof(Action<TObject, string>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, string>)Delegate.CreateDelegate(typeof(Func<TObject, string>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (string)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class IntAccessor : Accessor
        {
            private Action<TObject, int> setter;
            private Func<TObject, int> getter;

            public IntAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, int>)Delegate.CreateDelegate(typeof(Action<TObject, int>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, int>)Delegate.CreateDelegate(typeof(Func<TObject, int>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (int)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class IntNullableAccessor : Accessor
        {
            private Action<TObject, int?> setter;
            private Func<TObject, int?> getter;

            public IntNullableAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, int?>)Delegate.CreateDelegate(typeof(Action<TObject, int?>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, int?>)Delegate.CreateDelegate(typeof(Func<TObject, int?>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (int)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class DateTimeAccessor : Accessor
        {
            private Action<TObject, DateTime> setter;
            private Func<TObject, DateTime> getter;

            public DateTimeAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, DateTime>)Delegate.CreateDelegate(typeof(Action<TObject, DateTime>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, DateTime>)Delegate.CreateDelegate(typeof(Func<TObject, DateTime>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (DateTime)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class DateTimeNullableAccessor : Accessor
        {
            private Action<TObject, DateTime?> setter;
            private Func<TObject, DateTime?> getter;

            public DateTimeNullableAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, DateTime?>)Delegate.CreateDelegate(typeof(Action<TObject, DateTime?>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, DateTime?>)Delegate.CreateDelegate(typeof(Func<TObject, DateTime?>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (DateTime?)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class LongAccessor : Accessor
        {
            private Action<TObject, long> setter;
            private Func<TObject, long> getter;

            public LongAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, long>)Delegate.CreateDelegate(typeof(Action<TObject, long>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, long>)Delegate.CreateDelegate(typeof(Func<TObject, long>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (long)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class LongNullableAccessor : Accessor
        {
            private Action<TObject, long?> setter;
            private Func<TObject, long?> getter;

            public LongNullableAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, long?>)Delegate.CreateDelegate(typeof(Action<TObject, long?>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, long?>)Delegate.CreateDelegate(typeof(Func<TObject, long?>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (long)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class DoubleAccessor : Accessor
        {
            private Action<TObject, double> setter;
            private Func<TObject, double> getter;

            public DoubleAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, double>)Delegate.CreateDelegate(typeof(Action<TObject, double>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, double>)Delegate.CreateDelegate(typeof(Func<TObject, double>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (double)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class DoubleNullableAccessor : Accessor
        {
            private Action<TObject, double?> setter;
            private Func<TObject, double?> getter;

            public DoubleNullableAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, double?>)Delegate.CreateDelegate(typeof(Action<TObject, double?>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, double?>)Delegate.CreateDelegate(typeof(Func<TObject, double?>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (double)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class FloatAccessor : Accessor
        {
            private Action<TObject, float> setter;
            private Func<TObject, float> getter;

            public FloatAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, float>)Delegate.CreateDelegate(typeof(Action<TObject, float>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, float>)Delegate.CreateDelegate(typeof(Func<TObject, float>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (float)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class FloatNullableAccessor : Accessor
        {
            private Action<TObject, float?> setter;
            private Func<TObject, float?> getter;

            public FloatNullableAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, float?>)Delegate.CreateDelegate(typeof(Action<TObject, float?>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, float?>)Delegate.CreateDelegate(typeof(Func<TObject, float?>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (float)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class GuidAccessor : Accessor
        {
            private Action<TObject, Guid> setter;
            private Func<TObject, Guid> getter;

            public GuidAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, Guid>)Delegate.CreateDelegate(typeof(Action<TObject, Guid>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, Guid>)Delegate.CreateDelegate(typeof(Func<TObject, Guid>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (Guid)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class GuidNullableAccessor : Accessor
        {
            private Action<TObject, Guid?> setter;
            private Func<TObject, Guid?> getter;

            public GuidNullableAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, Guid?>)Delegate.CreateDelegate(typeof(Action<TObject, Guid?>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, Guid?>)Delegate.CreateDelegate(typeof(Func<TObject, Guid?>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (Guid)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class ByteAccessor : Accessor
        {
            private Action<TObject, byte> setter;
            private Func<TObject, byte> getter;

            public ByteAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, byte>)Delegate.CreateDelegate(typeof(Action<TObject, byte>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, byte>)Delegate.CreateDelegate(typeof(Func<TObject, byte>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                if (value is byte)
                {
                    setter(obj, (byte)value);
                }
                else
                {
                    setter(obj, Convert.ToByte(value));
                }
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class ByteNullableAccessor : Accessor
        {
            private Action<TObject, byte?> setter;
            private Func<TObject, byte?> getter;

            public ByteNullableAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, byte?>)Delegate.CreateDelegate(typeof(Action<TObject, byte?>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, byte?>)Delegate.CreateDelegate(typeof(Func<TObject, byte?>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                if (value is byte)
                {
                    setter(obj, (byte)value);
                }
                else
                {
                    setter(obj, Convert.ToByte(value));
                }
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class ShortAccessor : Accessor
        {
            private Action<TObject, short> setter;
            private Func<TObject, short> getter;

            public ShortAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, short>)Delegate.CreateDelegate(typeof(Action<TObject, short>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, short>)Delegate.CreateDelegate(typeof(Func<TObject, short>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (short)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class ShortNullableAccessor : Accessor
        {
            private Action<TObject, short?> setter;
            private Func<TObject, short?> getter;

            public ShortNullableAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, short?>)Delegate.CreateDelegate(typeof(Action<TObject, short?>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, short?>)Delegate.CreateDelegate(typeof(Func<TObject, short?>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (short)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class CharAccessor : Accessor
        {
            private Action<TObject, char> setter;
            private Func<TObject, char> getter;

            public CharAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, char>)Delegate.CreateDelegate(typeof(Action<TObject, char>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, char>)Delegate.CreateDelegate(typeof(Func<TObject, char>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (char)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class CharNullableAccessor : Accessor
        {
            private Action<TObject, char?> setter;
            private Func<TObject, char?> getter;

            public CharNullableAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, char?>)Delegate.CreateDelegate(typeof(Action<TObject, char?>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, char?>)Delegate.CreateDelegate(typeof(Func<TObject, char?>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (char)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class BoolAccessor : Accessor
        {
            private Action<TObject, bool> setter;
            private Func<TObject, bool> getter;

            public BoolAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, bool>)Delegate.CreateDelegate(typeof(Action<TObject, bool>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, bool>)Delegate.CreateDelegate(typeof(Func<TObject, bool>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                if (value is bool)
                {
                    setter(obj, (bool)value);
                }
                else
                {
                    setter(obj, Convert.ToUInt16(value) > 0);
                }
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class BoolNullableAccessor : Accessor
        {
            private Action<TObject, bool?> setter;
            private Func<TObject, bool?> getter;

            public BoolNullableAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, bool?>)Delegate.CreateDelegate(typeof(Action<TObject, bool?>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, bool?>)Delegate.CreateDelegate(typeof(Func<TObject, bool?>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                if (value is bool)
                {
                    setter(obj, (bool)value);
                }
                else
                {
                    setter(obj, Convert.ToUInt16(value) > 0);
                }
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class TimeSpanAccessor : Accessor
        {
            private Action<TObject, TimeSpan> setter;
            private Func<TObject, TimeSpan> getter;

            public TimeSpanAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, TimeSpan>)Delegate.CreateDelegate(typeof(Action<TObject, TimeSpan>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, TimeSpan>)Delegate.CreateDelegate(typeof(Func<TObject, TimeSpan>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (TimeSpan)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class TimeSpanNullableAccessor : Accessor
        {
            private Action<TObject, TimeSpan?> setter;
            private Func<TObject, TimeSpan?> getter;

            public TimeSpanNullableAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, TimeSpan?>)Delegate.CreateDelegate(typeof(Action<TObject, TimeSpan?>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, TimeSpan?>)Delegate.CreateDelegate(typeof(Func<TObject, TimeSpan?>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (TimeSpan)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class DecimalAccessor : Accessor
        {
            private Action<TObject, decimal> setter;
            private Func<TObject, decimal> getter;

            public DecimalAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, decimal>)Delegate.CreateDelegate(typeof(Action<TObject, decimal>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, decimal>)Delegate.CreateDelegate(typeof(Func<TObject, decimal>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (decimal)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class DecimalNullableAccessor : Accessor
        {
            private Action<TObject, decimal?> setter;
            private Func<TObject, decimal?> getter;

            public DecimalNullableAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, decimal?>)Delegate.CreateDelegate(typeof(Action<TObject, decimal?>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, decimal?>)Delegate.CreateDelegate(typeof(Func<TObject, decimal?>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (decimal)value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        public class ByteArrayAccessor : Accessor
        {
            private Action<TObject, byte[]> setter;
            private Func<TObject, byte[]> getter;

            public ByteArrayAccessor(PropertyInfo prop)
            {
                setter = (Action<TObject, byte[]>)Delegate.CreateDelegate(typeof(Action<TObject, byte[]>), null, prop.GetSetMethod(true));
                getter = (Func<TObject, byte[]>)Delegate.CreateDelegate(typeof(Func<TObject, byte[]>), null, prop.GetGetMethod(true));
            }

            protected override void DoSet(TObject obj, object value)
            {
                setter(obj, (byte[])value);
            }

            protected override object DoGet(TObject obj)
            {
                return getter(obj);
            }
        }

        #endregion Accessor
    }
}