using log4net;
using System;

namespace Nikita.Permission
{
    public class LogHelper
    {
        public static readonly ILog Logerror = LogManager.GetLogger("logerror");
        public static readonly ILog Loginfo = LogManager.GetLogger("loginfo");
        private static readonly ILog Log = LogManager.GetLogger("logger");

        public static void Debug(string message)
        {
            if (Log.IsDebugEnabled)
            {
                Log.Debug(message);
            }
        }

        public static void Debug(Exception ex1)
        {
            if (Log.IsDebugEnabled)
            {
                Log.Debug(ex1.Message + "/r/n" + ex1.Source + "/r/n" + ex1.TargetSite + "/r/n" + ex1.StackTrace);
            }
        }

        public static void Error(string message)
        {
            if (Log.IsErrorEnabled)
            {
                Log.Error(message);
            }
        }

        /// <summary>
        /// 错误记录
        /// </summary>
        /// <param name="info">附加信息</param>
        /// <param name="ex">错误</param>
        public static void ErrorLog(string info, Exception ex)
        {
            if (!string.IsNullOrEmpty(info) && ex == null)
            {
                Logerror.ErrorFormat("【附加信息】 : {0}<br>", info);
            }
            else if (!string.IsNullOrEmpty(info) && ex != null)
            {
                string errorMsg = BeautyErrorMsg(ex);
                Logerror.ErrorFormat("【附加信息】 : {0}<br>{1}", info, errorMsg);
            }
            else if (string.IsNullOrEmpty(info) && ex != null)
            {
                string errorMsg = BeautyErrorMsg(ex);
                Logerror.Error(errorMsg);
            }
        }

        public static void Fatal(string message)
        {
            if (Log.IsFatalEnabled)
            {
                Log.Fatal(message);
            }
        }

        public static void Info(string message)
        {
            if (Log.IsInfoEnabled)
            {
                Log.Info(message);
            }
        }

        public static void Warn(string message)
        {
            if (Log.IsWarnEnabled)
            {
                Log.Warn(message);
            }
        }

        public static void WriteLog(string info)
        {
            if (Loginfo.IsInfoEnabled)
            {
                Loginfo.Info(info);
            }
        }

        /// <summary>
        /// 美化错误信息
        /// </summary>
        /// <param name="ex">异常</param>
        /// <returns>错误信息</returns>
        private static string BeautyErrorMsg(Exception ex)
        {
            string errorMsg = string.Format("【异常类型】：{0} <br>【异常信息】：{1} <br>【堆栈调用】：{2}", new object[] { ex.GetType().Name, ex.Message, ex.StackTrace });
            errorMsg = errorMsg.Replace("\r\n", "<br>");
            errorMsg = errorMsg.Replace("位置", "<strong style=\"color:red\">位置</strong>");
            return errorMsg;
        }
    }
}