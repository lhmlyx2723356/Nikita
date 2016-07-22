using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nikita.Core;

namespace Nikita.Applications.DxFramework
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
            BonusSkins.Register();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");

            if (string.IsNullOrEmpty(UserInfoHelper.CreateUserId))
            {
                FrmLogin login = new FrmLogin();
                if (login.ShowDialog() == DialogResult.OK)
                {

                    login.Close(); 
                    if (UserInfoHelper.SystemStyle == "Ribbon")
                    {
                        FrmMainRibbon main = new FrmMainRibbon();
                        main.ShowDialog();
                    }
                    else if (UserInfoHelper.SystemStyle == "经典")
                    {
                        FrmMain main = new FrmMain();
                        main.ShowDialog();
                    }
                    else
                    {
                        FrmMainTree main = new FrmMainTree();
                        main.ShowDialog();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            { 
                //Application.Run(new frmMainBase ());
                if (UserInfoHelper.SystemStyle == "Ribbon")
                {
                    Application.Run(new FrmMainRibbon());
                }
                else if (UserInfoHelper.SystemStyle == "经典")
                {

                    Application.Run(new FrmMain());
                }
                else
                {
                    Application.Run(new FrmMainTree());
                }
            }



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
            LogHelper.ErrorLog(null, e.Exception);
        }
        /// <summary>
        /// 处理未捕获的异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogHelper.ErrorLog(null, e.ExceptionObject as Exception);
        }
    }
}
