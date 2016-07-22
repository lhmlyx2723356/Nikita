using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nikita.Assist.WcfHost
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Process proc = StartupHelper.RunningInstance();
            if (proc != null)
            {
                MessageBox.Show("很抱歉,该程序已经在运行中。" + System.Environment.NewLine + "请您先退出该程序,再重新打开。");
                return;
            }

            Application.Run(new FrmWcfHost());
        }
    }
}