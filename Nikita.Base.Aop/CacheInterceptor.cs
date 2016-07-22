
using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace Nikita.Base.Aop
{
    public class CacheInterceptor : IInterceptor
    {
        /// <summary>
        ///     Intercept the specified invocation and apply caching.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        public void Intercept(IInvocation invocation)
        {
            CacheAttribute attribute = null;
            object[] attributes = invocation.Method.GetCustomAttributes(typeof(CacheAttribute), false);
            foreach (object attributeTemp in attributes)
            {
                if (attributeTemp is CacheAttribute)
                {
                    attribute = (CacheAttribute)attributeTemp;
                }
            }
            // Caching should not be applied when CacheAttribute was not set on the invoked method.
            if (attribute == null)
            {
                invocation.Proceed();
                return;
            }


            // The CacheAttribute has been set for this method so we can apply caching.
            // This interceptor object must implement the ICacheHandler which we use to access the cache.
            //var cacheHandler = this as ICacheHandler;

            //if (cacheHandler == null)
            //{
            //    invocation.Proceed();
            //    return;
            //}

            object[] objArguments = invocation.Arguments;
            if (objArguments.Length == 0)
            {
                invocation.Proceed();
                return;
            }
            // Get or generate the cache key.
            //string cacheKey = attribute.CacheKey ?? this.GenerateCacheKey(invocation);
            string strTableName = objArguments.GetValue(0).ToString();
            string strWhere = objArguments.GetValue(1).ToString();

            // Try to retrieve the cached object and return that instead of processing the original method call.
            object cachedResult = new CacheHandler().GetCache(strTableName, strWhere);

            if (cachedResult == null)
            {
                // Nothing was found in the cache for this method.
                // Invoke the method and cache the result.
                invocation.Proceed();
                //cacheHandler.AddToCache(invocation.ReturnValue, cacheKey, attribute.Expiration);
            }
            else
            {
                // Return the cached result.
                invocation.ReturnValue = cachedResult;
            }
        }

        /// <summary>
        ///     Generates the cache key based on the method info.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <returns></returns>
        private string GenerateCacheKey(IInvocation invocation)
        {
            var methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;

            // Get info on class and method name.
            string className = (methodInfo.DeclaringType ?? this.GetType()).FullName;
            string methodName = methodInfo.Name;
            string arguments = string.Empty;

            // Format a list with argument names and values.
            var parameters = methodInfo.GetParameters();

            if (parameters.Any() && parameters.Length == invocation.Arguments.Length)
            {
                // Format a list with argument names and values in the format:
                // { name : value, name2 : value2 }
                arguments = string.Format("{{ {0} }}",
                    string.Join(", ", parameters.Select((arg, index)
                        => this.FormatArgumentString(arg, invocation.Arguments[index]))));
            }

            // Create a cache key using the retrieved info.
            return string.Format("{0}.{1}({2})", className, methodName, arguments);
        }

        /// <summary>
        ///     Formats a method argument to a string that is used during generation of the cache key.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private string FormatArgumentString(ParameterInfo argument, object value)
        {
            // Convert value to string and remove line breaks.
            string stringValue = Convert.ToString(value)
                .Replace("\r", "\\r")
                .Replace("\n", "\\n");

            // Wrap value in quotes if it's a string
            string formatted = argument.ParameterType == typeof(string)
                ? string.Concat("\"", stringValue, "\"")
                : stringValue;

            return string.Format("{0} : {1}", argument.Name, formatted);
        }
    }
}
