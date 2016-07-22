using System;
using System.Collections;
using System.Reflection;
using System.Web;
using System.Web.Caching;

//public void Test()
//{
//    // 获取数据
//    var testData = CacheHelper.GetCacheData<List<int>>(new Func<int, List<int>>(GetTestData), "TestKey", 5, 10);

//    if (testData != null && testData.Count > 0)
//    {
//        Console.WriteLine("获取数据成功！");
//    }
//}

///// <summary>
///// 获取原始数据
///// </summary>
///// <param name="count"></param>
///// <returns></returns>
//public List<int> GetTestData(int count)
//{
//    var testData = new List<int>();
//    for (int i = 0; i < count; i++)
//    {
//        testData.Add(i);
//    }

//    return testData;
//}

namespace Nikita.Core
{
    /// <summary>
    /// 通用缓存组件
    /// </summary>
    public class CacheHelper
    {
        /// <summary>
        /// 获取数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        public static object GetCache(string cacheKey)
        {
            Cache objCache = HttpRuntime.Cache;
            return objCache[cacheKey];
        }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <typeparam name="T">缓存实体对象</typeparam>
        /// <param name="dele">实体数据获取方法</param>
        /// <param name="cacheKey">缓存关键字</param>
        /// <param name="cacheDuration">缓存时间（分钟）</param>
        /// <param name="objs">实体数据获取参数</param>
        /// <returns>返回对象</returns>
        public static T GetCacheData<T>(Delegate dele, string cacheKey, int cacheDuration, params object[] objs)
        {
            // 缓存为空
            if (HttpRuntime.Cache.Get(cacheKey) == null)
            {
                // 执行实体数据获取方法
                MethodInfo methodInfo = dele.Method;

                T result = (T)methodInfo.Invoke(dele.Target, objs);

                if (result != null)
                {
                    // 到期时间
                    DateTime cacheTime = DateTime.Now.AddMinutes(cacheDuration);

                    // 添加入缓存
                    HttpRuntime.Cache.Add(cacheKey, result, null, cacheTime, Cache.NoSlidingExpiration,
                        CacheItemPriority.NotRemovable, null);
                }
            }

            return (T)HttpRuntime.Cache[cacheKey];
        }

        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        public static void RemoveAllCache(string cacheKey)
        {
            Cache cache = HttpRuntime.Cache;
            cache.Remove(cacheKey);
        }

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public static void RemoveAllCache()
        {
            Cache cache = HttpRuntime.Cache;
            IDictionaryEnumerator cacheEnum = cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                cache.Remove(cacheEnum.Key.ToString());
            }
        }

        /// <summary>
        /// 设置数据缓存
        /// </summary>
        public static void SetCache(string cacheKey, object objObject)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject);
        }

        /// <summary>
        /// 设置数据缓存
        /// </summary>
        public static void SetCache(string cacheKey, object objObject, TimeSpan timeout)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject, null, DateTime.MaxValue, timeout, CacheItemPriority.NotRemovable, null);
        }

        /// <summary>
        /// 设置数据缓存
        /// </summary>
        public static void SetCache(string cacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject, null, absoluteExpiration, slidingExpiration);
        }
    }
}