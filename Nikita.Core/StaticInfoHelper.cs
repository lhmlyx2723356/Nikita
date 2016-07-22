using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Core
{
    public class StaticInfoHelper
    {
        /// <summary>是否已经打开窗体
        /// 大于1就是打开过了
        /// </summary>

        public static int IsOpen
        {
            get;
            set;
        }
    }
}