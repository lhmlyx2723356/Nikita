using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nikita.Core
{
    #region 文件帮助类，包括文件地址，文件夹操作等

    public class FileHelper
    {
        /// <summary>返回指示文件是否已被其它程序使用的布尔值
        ///
        /// </summary>
        /// <param name="fileFullName">文件的完全限定名，例如：“C:\MyFile.txt”。</param>
        /// <returns>如果文件已被其它程序使用，则为 true；否则为 false。</returns>
        public static Boolean FileIsUsed(String fileFullName)
        {
            Boolean result;
            //判断文件是否存在，如果不存在，直接返回 false
            if (!File.Exists(fileFullName))
            {
                result = false;
            }//end: 如果文件不存在的处理逻辑
            else
            {//如果文件存在，则继续判断文件是否已被其它程序使用
                //逻辑：尝试执行打开文件的操作，如果文件已经被其它程序使用，则打开失败，抛出异常，根据此类异常可以判断文件是否已被其它程序使用。
                FileStream fileStream = null;
                try
                {
                    fileStream = File.Open(fileFullName, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                    result = false;
                }
                catch (IOException)
                {
                    result = true;
                }
                catch (Exception)
                {
                    result = true;
                }
                finally
                {
                    if (fileStream != null)
                    {
                        fileStream.Close();
                    }
                }
            }//end: 如果文件存在的处理逻辑
            //返回指示文件是否已被其它程序使用的值
            return result;
        }//end method FileIsUsed

        /// <summary>获取当前运行系统bin目录下的文件夹下的某个文件路径
        ///
        /// </summary>
        /// <param name="folder">bin 目录下的文件夹名字</param>
        /// <param name="fileName">文件名称</param>
        /// <returns> E:\\....\\bin\\Debug\\Images\\1.png </returns>
        public static string GetFilePath(string folder, string fileName)
        {
            return Application.StartupPath + "\\" + folder + "\\" + fileName;
        }

        /// <summary>获取当前运行系统bin目录下的文件夹下的路径
        ///
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        public static string GetFilePath(string folder)
        {
            return Application.StartupPath + "\\" + folder + "\\";
        }

        #region Stream、byte[] 和 文件之间的转换

        /// <summary>将 byte[] 转成 Stream
        ///
        /// </summary>
        public static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        /// <summary>将文件读取到缓冲区中
        ///
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static byte[] FileToBytes(string filePath)
        {
            //获取文件的大小
            int fileSize = GetFileSize(filePath);

            //创建一个临时缓冲区
            byte[] buffer = new byte[fileSize];

            //创建一个文件流
            FileInfo fi = new FileInfo(filePath);
            FileStream fs = fi.Open(FileMode.Open);

            try
            {
                //将文件流读入缓冲区
                fs.Read(buffer, 0, fileSize);

                return buffer;
            }
            catch (IOException ex)
            {
                throw ex;
            }
            finally
            {
                //关闭文件流
                fs.Close();
            }
        }

        /// <summary>从文件读取 Stream
        ///
        /// </summary>
        public static Stream FileToStream(string fileName)
        {
            // 打开文件
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            // 读取文件的 byte[]
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            // 把 byte[] 转换成 Stream
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        /// <summary> 将文件读取到字符串中
        ///
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static string FileToString(string filePath)
        {
            return FileToString(filePath, Encoding.Default);
        }

        /// <summary>将文件读取到字符串中
        ///
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="encoding">字符编码</param>
        public static string FileToString(string filePath, Encoding encoding)
        {
            try
            {
                //创建流读取器
                using (StreamReader reader = new StreamReader(filePath, encoding))
                {
                    //读取流
                    return reader.ReadToEnd();
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        /// <summary>从嵌入资源中读取文件内容(e.g: xml).
        ///
        /// </summary>
        /// <param name="fileWholeName">嵌入资源文件名，包括项目的命名空间.</param>
        /// <returns>资源中的文件内容.</returns>
        public static string ReadFileFromEmbedded(string fileWholeName)
        {
            string result = string.Empty;

            if (fileWholeName != null)
                using (TextReader reader = new StreamReader(
                    Assembly.GetExecutingAssembly().GetManifestResourceStream(fileWholeName)))
                {
                    result = reader.ReadToEnd();
                }
            return result;
        }

        /// <summary> 将流读取到缓冲区中
        ///
        /// </summary>
        /// <param name="stream">原始流</param>
        public static byte[] StreamToBytes(Stream stream)
        {
            try
            {
                //创建缓冲区
                byte[] buffer = new byte[stream.Length];

                //读取流
                stream.Read(buffer, 0, Convert.ToInt32(stream.Length));

                //返回流
                return buffer;
            }
            catch (IOException ex)
            {
                throw ex;
            }
            finally
            {
                //关闭流
                stream.Close();
            }
        }

        /// <summary>将 Stream 写入文件
        ///
        /// </summary>
        public static void StreamToFile(Stream stream, string fileName)
        {
            // 把 Stream 转换成 byte[]
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            // 把 byte[] 写入文件
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }

        #endregion Stream、byte[] 和 文件之间的转换

        #region 获取文件的编码类型

        /// <summary>获取文件编码
        ///
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <returns></returns>
        public static Encoding GetEncoding(string filePath)
        {
            return GetEncoding(filePath, Encoding.Default);
        }

        /// <summary>获取文件编码
        ///
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <param name="defaultEncoding">找不到则返回这个默认编码</param>
        /// <returns></returns>
        public static Encoding GetEncoding(string filePath, Encoding defaultEncoding)
        {
            Encoding targetEncoding = defaultEncoding;
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4))
            {
                if (fs.Length >= 2)
                {
                    long pos = fs.Position;
                    fs.Position = 0;
                    int[] buffer = new int[4];
                    //long x = fs.Seek(0, SeekOrigin.Begin);
                    //fs.Read(buffer,0,4);
                    buffer[0] = fs.ReadByte();
                    buffer[1] = fs.ReadByte();
                    buffer[2] = fs.ReadByte();
                    buffer[3] = fs.ReadByte();

                    fs.Position = pos;

                    if (buffer[0] == 0xFE && buffer[1] == 0xFF)//UnicodeBe
                    {
                        targetEncoding = Encoding.BigEndianUnicode;
                    }
                    if (buffer[0] == 0xFF && buffer[1] == 0xFE)//Unicode
                    {
                        targetEncoding = Encoding.Unicode;
                    }
                    if (buffer[0] == 0xEF && buffer[1] == 0xBB && buffer[2] == 0xBF)//UTF8
                    {
                        targetEncoding = Encoding.UTF8;
                    }
                }
            }

            return targetEncoding;
        }

        #endregion 获取文件的编码类型

        #region 文件操作

        #region 获取一个文件的长度

        /// <summary>获取一个文件的长度,单位为Byte
        ///
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static int GetFileSize(string filePath)
        {
            //创建一个文件对象
            FileInfo fi = new FileInfo(filePath);

            //获取文件的大小
            return (int)fi.Length;
        }

        /// <summary>获取一个文件的长度,单位为KB
        ///
        /// </summary>
        /// <param name="filePath">文件的路径</param>
        public static double GetFileSizeKb(string filePath)
        {
            //创建一个文件对象
            FileInfo fi = new FileInfo(filePath);

            //获取文件的大小
            return ConvertHelper.ToDouble(Convert.ToDouble(fi.Length) / 1024, 1);
        }

        /// <summary>获取一个文件的长度,单位为MB
        ///
        /// </summary>
        /// <param name="filePath">文件的路径</param>
        public static double GetFileSizeMb(string filePath)
        {
            //创建一个文件对象
            FileInfo fi = new FileInfo(filePath);

            //获取文件的大小
            return ConvertHelper.ToDouble(Convert.ToDouble(fi.Length) / 1024 / 1024, 1);
        }

        #endregion 获取一个文件的长度

        /// <summary> 向文本文件的尾部追加内容
        ///
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="content">写入的内容</param>
        public static void AppendText(string filePath, string content)
        {
            File.AppendAllText(filePath, content, Encoding.Default);
        }

        /// <summary>清空文件内容
        ///
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static void ClearFile(string filePath)
        {
            //删除文件
            File.Delete(filePath);

            //重新创建该文件
            CreateFile(filePath);
        }

        /// <summary>判断两个文件的哈希值是否一致
        ///
        /// </summary>
        /// <param name="fileName1"></param>
        /// <param name="fileName2"></param>
        /// <returns></returns>
        public static bool CompareFilesHash(string fileName1, string fileName2)
        {
            using (HashAlgorithm hashAlg = HashAlgorithm.Create())
            {
                using (FileStream fs1 = new FileStream(fileName1, FileMode.Open), fs2 = new FileStream(fileName2, FileMode.Open))
                {
                    byte[] hashBytes1 = hashAlg.ComputeHash(fs1);
                    byte[] hashBytes2 = hashAlg.ComputeHash(fs2);

                    // 比较哈希码
                    return (BitConverter.ToString(hashBytes1) == BitConverter.ToString(hashBytes2));
                }
            }
        }

        /// <summary> 将源文件的内容复制到目标文件中
        ///
        /// </summary>
        /// <param name="sourceFilePath">源文件的绝对路径</param>
        /// <param name="destFilePath">目标文件的绝对路径</param>
        public static void Copy(string sourceFilePath, string destFilePath)
        {
            File.Copy(sourceFilePath, destFilePath, true);
        }

        /// <summary>创建一个文件。
        ///
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static void CreateFile(string filePath)
        {
            try
            {
                //如果文件不存在则创建该文件
                if (!IsExistFile(filePath))
                {
                    File.Create(filePath);
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        /// <summary>创建一个文件,并将字节流写入文件。
        ///
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="buffer">二进制流数据</param>
        public static void CreateFile(string filePath, byte[] buffer)
        {
            try
            {
                //如果文件不存在则创建该文件
                if (!IsExistFile(filePath))
                {
                    //创建文件
                    using (FileStream fs = File.Create(filePath))
                    {
                        //写入二进制流
                        fs.Write(buffer, 0, buffer.Length);
                    }
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        /// <summary>创建一个零字节临时文件
        ///
        /// </summary>
        /// <returns></returns>
        public static string CreateTempZeroByteFile()
        {
            return Path.GetTempFileName();
        }

        /// <summary>删除指定文件
        ///
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static void DeleteFile(string filePath)
        {
            if (IsExistFile(filePath))
            {
                File.Delete(filePath);
            }
        }

        /// <summary>文件是否存在或无权访问
        ///
        /// </summary>
        /// <param name="path">相对路径或绝对路径</param>
        /// <returns>如果是目录也返回false</returns>
        public static bool FileIsExist(string path)
        {
            return File.Exists(path);
        }

        /// <summary>文件是否只读
        ///
        /// </summary>
        /// <param name="fullpath"></param>
        /// <returns></returns>
        public static bool FileIsReadOnly(string fullpath)
        {
            FileInfo file = new FileInfo(fullpath);
            if ((file.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary> 从文件的绝对路径中获取扩展名
        ///
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static string GetExtension(string filePath)
        {
            //获取文件的名称
            FileInfo fi = new FileInfo(filePath);
            return fi.Extension;
        }

        /// <summary> 取文件创建时间
        ///
        /// </summary>
        /// <param name="fullpath"></param>
        /// <returns></returns>
        public static DateTime GetFileCreateTime(string fullpath)
        {
            FileInfo fi = new FileInfo(fullpath);
            return fi.CreationTime;
        }

        /// <summary>从文件的绝对路径中获取文件名( 包含扩展名 )
        ///
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static string GetFileName(string filePath)
        {
            //获取文件的名称
            FileInfo fi = new FileInfo(filePath);
            return fi.Name;
        }

        ///  <summary> 取文件名
        ///
        ///  </summary>
        ///  <param name="fullpath"></param>
        /// <param name="removeExt"></param>
        /// <returns></returns>
        public static string GetFileName(string fullpath, bool removeExt)
        {
            FileInfo fi = new FileInfo(fullpath);
            string name = fi.Name;
            if (removeExt)
            {
                name = name.Remove(name.IndexOf('.'));
            }
            return name;
        }

        /// <summary>从文件的绝对路径中获取文件名( 不包含扩展名 )
        ///
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static string GetFileNameNoExtension(string filePath)
        {
            //获取文件的名称
            FileInfo fi = new FileInfo(filePath);
            return fi.Name.Substring(0, fi.Name.LastIndexOf('.'));
        }

        /// <summary>取文件最后存储时间
        ///
        /// </summary>
        /// <param name="fullpath"></param>
        /// <returns></returns>
        public static DateTime GetLastWriteTime(string fullpath)
        {
            FileInfo fi = new FileInfo(fullpath);
            return fi.LastWriteTime;
        }

        /// <summary>获取文本文件的行数
        ///
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static int GetLineCount(string filePath)
        {
            //将文本文件的各行读到一个字符串数组中
            string[] rows = File.ReadAllLines(filePath);

            //返回行数
            return rows.Length;
        }

        /// <summary> 创建一个随机文件名，不创建文件本身
        ///
        /// </summary>
        /// <returns></returns>
        public static string GetRandomFileName()
        {
            return Path.GetRandomFileName();
        }

        /// <summary>检测指定文件是否存在,如果存在则返回true。
        ///
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static bool IsExistFile(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>将文件移动到指定目录
        ///
        /// </summary>
        /// <param name="sourceFilePath">需要移动的源文件的绝对路径</param>
        /// <param name="descDirectoryPath">移动到的目录的绝对路径</param>
        public static void Move(string sourceFilePath, string descDirectoryPath)
        {
            //获取源文件的名称
            string sourceFileName = GetFileName(sourceFilePath);

            if (Directory.Exists(descDirectoryPath))
            {
                //如果目标中存在同名文件,则删除
                if (IsExistFile(descDirectoryPath + "\\" + sourceFileName))
                {
                    DeleteFile(descDirectoryPath + "\\" + sourceFileName);
                }
                //将文件移动到指定目录
                File.Move(sourceFilePath, descDirectoryPath + "\\" + sourceFileName);
            }
        }

        /// <summary>设置文件是否只读
        ///
        /// </summary>
        /// <param name="fullpath"></param>
        /// <param name="flag">true表示只读，反之</param>
        public static void SetFileReadonly(string fullpath, bool flag)
        {
            FileInfo file = new FileInfo(fullpath);

            if (flag)
            {
                // 添加只读属性
                file.Attributes |= FileAttributes.ReadOnly;
            }
            else
            {
                // 移除只读属性
                file.Attributes &= ~FileAttributes.ReadOnly;
            }
        }

        /// <summary> 向文本文件中写入内容
        ///
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="content">写入的内容</param>
        public static void WriteText(string filePath, string content)
        {
            //向文件写入内容
            File.WriteAllText(filePath, content, Encoding.Default);
        }

        #endregion 文件操作
         
    }

    #endregion 文件帮助类，包括文件地址，文件夹操作等
}