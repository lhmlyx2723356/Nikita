using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nikita.Core
{
    public class UserInfoHelper
    {
        /// <summary>编号
        ///
        /// </summary>

        public static string Birthday
        {
            get;
            set;
        }

        public static string Bloc_Id
        {
            get;
            set;
        }

        public static string BlocName
        {
            get;
            set;
        }

        public static string Company_Id
        {
            get;
            set;
        }

        public static string CompanyName
        {
            get;
            set;
        }

        public static string conn_Temp
        {
            get;
            set;
        }

        public static string CreateName
        {
            get;
            set;
        }

        public static string CreateUserId
        {
            get;
            set;
        }

        public static string Dept_Id
        {
            get;
            set;
        }

        public static string DeptName
        {
            get;
            set;
        }

        public static DataTable dtServer
        {
            get;
            set;
        }

        public static string Duty
        {
            get;
            set;
        }

        /// <summary>邮箱
        ///
        /// </summary>
        public static string Email
        {
            get;
            set;
        }

        public static string HomeAddress
        {
            get;
            set;
        }

        public static bool is_Visible_Dictionary
        {
            get;
            set;
        }

        /// <summary>系统语言选择
        ///
        /// </summary>
        public static string Lang
        {
            get;
            set;
        }

        public static string Mobile
        {
            get;
            set;
        }

        public static string MrPassword
        {
            get;
            set;
        }

        public static string Number
        {
            get;
            set;
        }

        /// <summary>登录用户名
        ///
        /// </summary>

        public static string Password
        {
            get;
            set;
        }

        public static string preSvr_Ip
        {
            get;
            set;
        }

        public static string QQ
        {
            get;
            set;
        }

        /// <summary>性别
        ///
        /// </summary>
        public static string Sex
        {
            get;
            set;
        }

        public static string svr_Ip
        {
            get;
            set;
        }

        public static string svr_Pwd
        {
            get;
            set;
        }

        /// <summary>部门ID
        ///
        /// </summary>
        /// <summary>部门名称
        ///
        /// </summary>
        /// <summary>公司ID
        ///
        /// </summary>
        /// <summary>公司名称
        ///
        /// </summary>
        /// <summary>集团ID
        ///
        /// </summary>
        /// <summary>集团名称
        ///
        /// </summary>
        /// <summary>用于判断是否已经登录了数据字典服务端（True为已登录，False为未登录）
        ///
        /// </summary>
        /// <summary>登录数据字典服务端当前的Ip
        ///
        /// </summary>
        /// <summary>登录数据字典后，再次切换服务端时，记录上一次登录的服务端Ip
        ///
        /// </summary>
        /// <summary>登录数据字典服务端的Sa账号
        ///
        /// </summary>
        public static string svr_Sa
        {
            get;
            set;
        }

        public static string SystemId
        {
            get;
            set;
        }

        public static string SystemStyle
        {
            get;
            set;
        }

        public static string Telephone
        {
            get;
            set;
        }

        public static string Theme
        {
            get;
            set;
        }

        public static string Title
        {
            get;
            set;
        }

        public static string UserName
        {
            get;
            set;
        }

        /// <summary>真实名
        ///
        /// </summary>
        /// <summary>登录用户ID
        ///
        /// </summary>
        /// <summary>岗位
        ///
        /// </summary>
        /// <summary>职称
        ///
        /// </summary>
        /// <summary>登录密码
        ///
        /// </summary>
        /// <summary>生日
        ///
        /// </summary>
        /// <summary>手机
        ///
        /// </summary>
        /// <summary>电话
        ///
        /// </summary>
        /// <summary>QQ号码
        ///
        /// </summary>
        /// <summary>家庭住址
        ///
        /// </summary>
        /// <summary>系统主题
        ///
        /// </summary>
        /// <summary>登录数据字典服务端的Sa密码
        ///
        /// </summary>
        /// <summary>未登录数据字典服务端时，就点击存储过程，或者视图或者表菜单的记录
        ///
        /// </summary>
        ///
        //private static string DicWithoutLogin;
        //public static string dicWithoutLogin
        //{
        //    get;
        //    set;
        //}

        /// <summary>登录数据字典服务端的数据库连接字符串
        ///
        /// </summary>
        /// <summary>登录数据字典服务端后获取该服务端下所有数据库的集合表
        ///
        /// </summary>
        /// <summary>用户前缀
        ///
        /// </summary>

        public static string userPrefix
        {
            get;
            set;
        }

        /// <summary>默认密码
        ///
        /// </summary>
        /// <summary>系统主界面样式：Ribbon /经典
        ///
        /// </summary>
        /// <summary>用户所处系统
        ///
        /// </summary>
    }
}