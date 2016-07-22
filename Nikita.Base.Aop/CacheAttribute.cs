using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Base.Aop
{

    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CacheAttribute : Attribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CacheAttribute" /> class.
        ///     CacheKey will be auto-generated.
        /// </summary>
        /// <param name="expiration">The expiration in seconds.</param>
        public CacheAttribute()
            : this(null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CacheAttribute" /> class.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="expiration">The expiration in seconds.</param>
        public CacheAttribute(string cacheKey)
        {
            this.CacheKey = cacheKey;
            //this.Expiration = expiration;
        }

        ///// <summary>
        ///// Gets or sets the expiration in seconds.
        ///// </summary>
        //public long Expiration { get; set; }

        /// <summary>
        /// Gets or sets the cache key.
        /// </summary>
        public string CacheKey { get; set; }

        ///// <summary>
        ///// Returns a <see cref="System.String" /> that represents this instance.
        ///// </summary>
        ///// <returns>
        ///// A <see cref="System.String" /> that represents this instance.
        ///// </returns>
        //public override string ToString()
        //{
        //    return string.Format("{{ Expiration: {0}, CacheKey = \"{1}\" }}", this.Expiration, this.CacheKey);
        //}

        public override string ToString()
        {
            return string.Format("{{ CacheKey = \"{0}\" }}", this.CacheKey);
        }
    }
}
