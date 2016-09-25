using System;
using System.Collections.Generic;
using System.Linq;

namespace Nikita.DataAccess.Expression2Sql.Mapper
{
    /// <summary>
    /// ** 描述：缓存操作类 
    /// </summary>
    /// <typeparam name="TV">值</typeparam>
    internal class CacheManager<TV> : IStorageObject<TV>
    {

        readonly System.Collections.Concurrent.ConcurrentDictionary<string, TV> _instanceCache = new System.Collections.Concurrent.ConcurrentDictionary<string, TV>();

        #region 全局变量
        private static CacheManager<TV> _instance;
        private static readonly object _instanceLock = new object();
        #endregion

        #region 构造函数

        private CacheManager() { }
        #endregion

        #region  属性
        /// <summary>         
        ///根据key获取value     
        /// </summary>         
        /// <value></value>      
        public override TV this[string key]
        {
            get
            {
                return Get(key);
            }
        }
        #endregion

        #region 公共函数

        /// <summary>         
        /// 验证key是否存在       
        /// </summary>         
        /// <param name="key">key</param>         
        /// <returns> /// 	存在<c>true</c> 不存在<c>false</c>.        /// /// </returns>         
        public override bool ContainsKey(string key)
        {
            return this._instanceCache.ContainsKey(key); 
        }

        /// <summary>         
        /// 根据key获取value  
        /// </summary>         
        /// <param name="key">key</param>         
        /// <returns></returns>         
        public override TV Get(string key)
        {
            return this._instanceCache[key];
        }

        /// <summary>         
        /// 获取实例 （单例模式）       
        /// </summary>         
        /// <returns></returns>         
        public static CacheManager<TV> GetInstance()
        {
            if (_instance == null)
                lock (_instanceLock)
                    if (_instance == null)
                        _instance = new CacheManager<TV>();
            return _instance;
        }

        /// <summary>         
        /// 插入缓存(默认20分钟)        
        /// </summary>         
        /// <param name="key"> key</param>         
        /// <param name="value">value</param>          
        public override void Add(string key, TV value)
        {
            this._instanceCache.GetOrAdd(key, value);
        }

        /// <summary>         
        /// 插入缓存        
        /// </summary>         
        /// <param name="key"> key</param>         
        /// <param name="value">value</param>         
        /// <param name="cacheDurationInSeconds">过期时间单位秒</param>         
        public void Add(string key, TV value, int cacheDurationInSeconds)
        {
            Add(key, value);
        } 

        /// <summary>         
        /// 删除缓存         
        /// </summary>         
        /// <param name="key">key</param>         
        public override void Remove(string key)
        {
            TV val;
            this._instanceCache.TryRemove(key, out val); 
        }

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public override void RemoveAll()
        {
            this._instanceCache.Clear();

        }

        /// <summary>
        /// 清除所有包含关键字的缓存
        /// </summary> 
        /// <param name="removeExpression">关键字</param>
        public override void RemoveAll(Func<string, bool> removeExpression)
        { 
            var allKeyList = GetAllKey();
            var delKeyList = allKeyList.Where(removeExpression).ToList();
            foreach (var key in delKeyList)
            {
                Remove(key);
            }
        }

        /// <summary>
        /// 获取所有缓存key
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<string> GetAllKey()
        {
            return this._instanceCache.Keys; 
        }
        #endregion


    }
}
