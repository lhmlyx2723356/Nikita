using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikita.DataAccess.Expression2Sql.Mapper
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class OrmTableAttribute : Attribute
    {
        public OrmTableAttribute() : this(string.Empty) { }

        public OrmTableAttribute(string name)
        {
            Name = name;
        }
        /// <summary>
        /// 指定表名，推荐模型类命名为"表名Info"，不用指定
        /// </summary>
        public string Name { get; set; }
    }
}
