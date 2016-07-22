using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Nikita.Core.Compression
{
    public class FileCompression
    {
        #region 加密、压缩文件

        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="fileNames">要打包的文件列表</param>
        /// <param name="gzipFileName">目标文件名</param>
        /// <param name="compressionLevel">压缩品质级别（0~9）</param>
        /// <param name="sleepTimer">休眠时间（单位毫秒）</param>
        public static void Compress(List<FileInfo> fileNames, string gzipFileName, int compressionLevel, int sleepTimer)
        {
            ZipOutputStream s = new ZipOutputStream(File.Create(gzipFileName));
            try
            {
                s.SetLevel(compressionLevel);   //0 - store only to 9 - means best compression
                foreach (FileInfo file in fileNames)
                {
                    FileStream fs;
                    try
                    {
                        fs = file.Open(FileMode.Open, FileAccess.ReadWrite);
                    }
                    catch
                    { continue; }
                    //  方法二，将文件分批读入缓冲区
                    byte[] data = new byte[2048];
                    int size = 2048;
                    ZipEntry entry = new ZipEntry(Path.GetFileName(file.Name))
                    {
                        DateTime = (file.CreationTime > file.LastWriteTime ? file.LastWriteTime : file.CreationTime)
                    };
                    s.PutNextEntry(entry);
                    while (true)
                    {
                        size = fs.Read(data, 0, size);
                        if (size <= 0) break;
                        s.Write(data, 0, size);
                    }
                    fs.Close();
                    Thread.Sleep(sleepTimer);
                }
            }
            finally
            {
                s.Finish();
                s.Close();
            }
        }

        #endregion 加密、压缩文件

        #region 解密、解压缩文件

        /// <summary>
        /// 解压缩文件
        /// </summary>
        /// <param name="gzipFile">压缩包文件名</param>
        /// <param name="targetPath">解压缩目标路径</param>
        public static void Decompress(string gzipFile, string targetPath)
        {
            //string directoryName = Path.GetDirectoryName(targetPath + "\\") + "\\";
            string directoryName = targetPath;
            if (!Directory.Exists(directoryName)) Directory.CreateDirectory(directoryName);//生成解压目录
            string currentDirectory = directoryName;
            byte[] data = new byte[2048];
            using (ZipInputStream s = new ZipInputStream(File.OpenRead(gzipFile)))
            {
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    if (theEntry.IsDirectory)
                    {
                        // 该结点是目录
                        if (!Directory.Exists(currentDirectory + theEntry.Name)) Directory.CreateDirectory(currentDirectory + theEntry.Name);
                    }
                    else
                    {
                        if (theEntry.Name != String.Empty)
                        {
                            //解压文件到指定的目录
                            using (FileStream streamWriter = File.Create(currentDirectory + theEntry.Name))
                            {
                                while (true)
                                {
                                    var size = s.Read(data, 0, data.Length);
                                    if (size <= 0) break;
                                    streamWriter.Write(data, 0, size);
                                }
                                streamWriter.Close();
                            }
                        }
                    }
                }
                s.Close();
            }
        }

        #endregion 解密、解压缩文件
    }
}