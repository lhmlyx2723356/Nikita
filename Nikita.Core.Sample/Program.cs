using Nikita.Assist.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Nikita.Core.Sample
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            BindExceptionHandler();//绑定程序中的异常处理
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMainDemo()); 
        }

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
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {  
           //LogHelper.WriteLog( e.Exception);
            //LogHelper.WriteLog2Sqlite(e.Exception); 
            MessageBox.Show("异常信息:" + e.Exception.Message);
            LoggerHelper.GetLogger().Add(e.Exception, "1");
        }
        /// <summary>
        /// 处理未捕获的异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        { 
            //LogHelper.WriteLog(e.ExceptionObject as Exception);
            //LogHelper.WriteLog2Sqlite(e.ExceptionObject as Exception); 
            var exception = e.ExceptionObject as Exception;
            if (exception != null)
                MessageBox.Show("异常信息:" + exception.Message);
            LoggerHelper.GetLogger().Add(exception, "1");
        }
    }
}
