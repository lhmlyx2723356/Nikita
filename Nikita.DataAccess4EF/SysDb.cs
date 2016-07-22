using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikita.DataAccess4EF
{
    public class SysDb : DbContext
    {
        bool isNew = true;//是否是新的sql执行
        string strMsg = "";//sql执行的相关信息
        string strConn = "";//数据库连接字符串
        string UserName = "";//日志用户名称
        string AdditionalInfo = "";//日志额外信息
        public SysDb(string connString) : // 数据库链接字符串
            base(connString)
        {
            strConn = connString;
            Database.SetInitializer<SysDb>(null);//设置为空，防止自动检查和生成
            base.Database.Log = (info) => Debug.WriteLine(info);
        }

        public SysDb(string connString, string logUserName, string logAdditionalInfo) : // 数据库链接字符串
            base(connString)
        {
            strConn = connString;
            Database.SetInitializer<SysDb>(null);//设置为空，防止自动检查和生成
            UserName = logUserName;
            AdditionalInfo = logAdditionalInfo;
            base.Database.Log = AddLogger;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //去掉复数映射
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="info"></param>
        public void AddLogger(string info)
        {
            if (info != "\r\n" && (!info.Contains("Sys_EventLog")))
            {
                string strTemp = info.ToUpper().Trim();
                if (isNew)
                {
                    //记录增删改
                    if (strTemp.StartsWith("INSERT") || strTemp.StartsWith("UPDATE") || strTemp.StartsWith("DELETE"))
                    {
                        strMsg = info;
                        isNew = false;
                    }
                }
                else
                {
                    if (strTemp.StartsWith("CLOSED CONNECTION"))
                    {
                        //增加新日志
                        using (SysDb db = new SysDb(strConn))
                        {
                            try
                            {
                                //保存日志到数据库或其他地方

                            }
                            catch (Exception ex)
                            {
                                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "//logError.txt"))
                                {
                                    sw.Write(ex.Message);
                                    sw.Flush();
                                }
                            }
                        }
                        //清空
                        strMsg = "";
                        isNew = true;
                    }
                    else
                    {
                        strMsg += info;
                    }
                }

            }
        }


    }
    public class SysDb<T> : SysDb where T : class
    {
        public SysDb(string connString) : // 数据库链接字符串
            base(connString)
        {
            Database.SetInitializer<SysDb<T>>(null);//设置为空，防止自动检查和生成
        }

        public SysDb(string connString, string logUserName, string logAdditionalInfo) : // 数据库链接字符串
            base(connString, logUserName, logAdditionalInfo)
        {
            Database.SetInitializer<SysDb<T>>(null);//设置为空，防止自动检查和生成
        }

        public DbSet<T> Entities { get; set; }
    }
}
