using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Autofac;
using Nikita.Core.Autofac;

namespace Nikita.Applications.WinFramework
{
    internal static class Program
    { 
        /// <summary>
        /// 绑定程序中的异常处理
        /// </summary>
        private static void BindExceptionHandler()
        {
            //设置应用程序处理异常方式：ThreadException处理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += Application_ThreadException;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); 
            ////var basetype = typeof(BseUrlDAL);
            //var builder = new ContainerBuilder();
            ////var assembly = Assembly.GetAssembly(basetype);
            //var assembly = Assembly.LoadFile(Application.StartupPath + "\\Nikita.Assist.Note.DAL.dll");
            //builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            //GlobalHelp.Container = builder.Build();
            FrmLogin login = new FrmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                login.Close();
                Application.Run(new FrmTreeMainForm());
            }
        }
    }
}