using System;

namespace Nikita.DataAccess.Expression2Sql.Mapper
{
    /// <summary>
    /// ** 描述：http存储对象接口
    /// </summary>
    internal abstract class IStorageObject<V>
    {
        public int Minutes = 60;
        public int Hour = 60 * 60;
        public int Day = 60 * 60 * 24;

        public abstract void Add(string key, V value);

        public abstract bool ContainsKey(string key);

        public abstract V Get(string key);

        public abstract global::System.Collections.Generic.IEnumerable<string> GetAllKey();

        public abstract void Remove(string key);

        public abstract void RemoveAll();

        public abstract void RemoveAll(Func<string, bool> removeExpression);

        public abstract V this[string key] { get; }
    }
}