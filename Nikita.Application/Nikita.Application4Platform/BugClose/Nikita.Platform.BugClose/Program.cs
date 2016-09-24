using Autofac;
using Nikita.Base.CacheStore;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Nikita.Platform.BugClose
{
    internal static class Program
    {
        /// <summary>
        /// 绑定程序中的异常处理
        /// </summary>
        private static void BindExceptionHandler()
        {
            //设置应用程序处理异常方式：ThreadException处理
            System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            System.Windows.Forms.Application.ThreadException += Application_ThreadException;
            //处理未捕获的异常
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        /// <summary>
        /// 处理UI线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        /// <summary>
        /// 处理未捕获的异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            if (exception != null) MessageBox.Show(exception.Message);
        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            BindExceptionHandler();//绑定程序中的异常处理
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            #region Autoface注册接口

            var builder = new ContainerBuilder();
            //var assembly = Assembly.GetAssembly(basetype);
            var assembly = Assembly.LoadFile(Path.Combine(Application.StartupPath, "Nikita.Platform.BugClose.DAL.dll"));
            Assembly[] arrAssemblies = new Assembly[1];
            arrAssemblies[0] = assembly;
            builder.RegisterAssemblyTypes(arrAssemblies).AsImplementedInterfaces();
            GlobalHelp.Container = builder.Build();

            #endregion Autoface注册接口

            //System.Windows.Forms.Application.Run(new FrmTestCache());
            FrmLogin login = new FrmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                login.Close();
                if (CacheManager.AllowCache)
                {
                    //同步缓存
                    CacheManager.SynCache();
                    //开始监听缓存
                    CacheListener.StartClient();
                }
                System.Windows.Forms.Application.Run(new FrmBugCloseMainForm());
            }
        }
    }
}