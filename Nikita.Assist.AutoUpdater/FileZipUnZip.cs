using ICSharpCode.SharpZipLib.Zip;
using System;

namespace Nikita.Assist.AutoUpdater
{
    public class FileZipUnZip
    {
        /// <summary>文件解压方法
        ///
        /// </summary>
        /// <param name="zipFilePath">要解压的文件的名称的路径，ex:Application.StartupPath + "\\UploadFile\\1.rar"</param>
        /// <param name="targetDir">解压到哪个文件，ex：Application.StartupPath + "\\UploadFile\\"</param>
        public static bool CompressFile(string zipFilePath, string targetDir)
        {
            bool flag;
            try
            {
                FastZipEvents fz = new FastZipEvents();
                FastZip fs = new FastZip(fz);
                fs.ExtractZip(zipFilePath, targetDir, "");
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }
    }
}