/* ***********************************************
 * author :  罗敏贵
 * email  :  minguiluo@163.com
 * function:
 * history:  created by 罗敏贵 2010-3-21 17:18:30
 * ***********************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Nikita.WinForm.ExtendControl
{
    /// <summary>
    /// 数据库常量配置
    /// </summary>
    [DebuggerStepThrough]
    public class SysConst
    {
        /// <summary>
        /// --读取指定表的所有列名
        /// </summary>
        public const string columns = "select name from syscolumns where id=(select max(id) from sysobjects where xtype='u' and name='{0}')";

        /// <summary>
        /// --读取库中的所有表名
        /// </summary>
        public const string table = "select name from sysobjects where xtype='u'";

        /// <summary>
        /// --读取库中的所有视图名
        /// </summary>
        public const string view = "select name from sysobjects where xtype='v'";

        /// <summary>
        ///  目标数据库连接字符串
        /// </summary>
        public static string GoalDbConnectionString = "server=.;database=HeatingAnShan;uid=sa;pwd=123456";

        /// <summary>
        ///  源数据库 连接字符串
        /// </summary>
        public static string SourceDbConnectionString = "server=.;database=Heating_XFSJ;uid=sa;pwd=123456";

        public SysConst()
        {
        }
    }
}