using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.WinForm.ExtendControl.CommonQuery
{
    public class Filter
    {
        public string AndOr { get; set; } //And 或者 OR
        public string Contract { get; set; }
        public string Key { get; set; } //过滤的关键字
        public string Value { get; set; } //过滤的值
        // 过滤的约束 比如：'<' '<=' '>' '>=' 'like'等
    }
}