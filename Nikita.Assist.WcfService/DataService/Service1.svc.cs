using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.Hosting;

namespace Nikita.Assist.WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class Service1 : IService1
    {
        private readonly ShareSqlManager _shareSqlMgr = new ShareSqlManager();

        /// <summary>访问存储过程返回DataSet（支持多个数据库）
        ///
        /// </summary>
        /// <param name="mthReq">MthReq包含ProceName：存储过程名，ParamKeys参数名称，ParamVals参数值，数据库名称ProceDb，ParamIndex：如果要操作多个数据库，则根据程序App.config下add key="BtProduceCS"中用|分割的数据库名称顺序,从0开始计算的索引</param>
        /// <returns>返回DataSet</returns>
        public DataSet DataRequest_By_DataSet(MethodRequest mthReq)
        {
            string proceDb = mthReq.ProceDb;
            if (mthReq.ParamIndex >= 0)
            {
                string[] dbArray = proceDb.Split('|');
                if (mthReq.ParamIndex <= dbArray.Length - 1)
                {
                    proceDb = dbArray[mthReq.ParamIndex];
                }
                else
                {
                    return null;
                }
            }
            string btProduceBs = ConfigurationManager.ConnectionStrings[proceDb].ToString();
            string proceName = mthReq.ProceName;
            object[] paramVals = mthReq.ParamVals;
            string[] paramKeys = mthReq.ParamKeys;
            DataSet ds = (DataSet)_shareSqlMgr.ExecStoredProc(proceName, paramKeys, paramVals, btProduceBs, RetType.DataSet);
            return ds;
        }

        /// <summary>访问存储过程返回DataSet（程序访问的数据库不止一个的情况下。）
        ///
        /// </summary>
        /// <param name="strSpName">存储过程</param>
        /// <param name="strKey">存储过程参数</param>
        /// <param name="strVal">存储过程值</param>
        /// <param name="proceDb">数据库名称</param>
        /// <param name="dbIndex">程序App.config下add key="BtProduceCS"中用|分割的数据库名称顺序,从0开始计算</param>
        /// <returns>返回DataSet</returns>
        public DataSet DataRequest_By_DataSet_More(string strSpName, string[] strKey, object[] strVal, string proceDb, int dbIndex)
        {
            if (dbIndex >= 0)
            {
                string[] dbArray = proceDb.Split('|');
                if (dbIndex <= dbArray.Length - 1)
                {
                    proceDb = dbArray[dbIndex];
                }
                else
                {
                    return null;
                }
            }
            DataSet ds = (DataSet)_shareSqlMgr.ExecStoredProc(strSpName, strKey, strVal, proceDb, RetType.DataSet);
            return ds;
        }

        /// <summary>访问存储过程返回DataSet（程序访问的数据库只有一个的情况下。）
        ///
        /// </summary>
        /// <param name="strSpName">存储过程</param>
        /// <param name="strKey">存储过程参数</param>
        /// <param name="strVal">存储过程值</param>
        /// <param name="proceDb">数据库名称</param>
        /// <returns>返回DataSet</returns>
        public DataSet DataRequest_By_DataSet_New(string strSpName, string[] strKey, object[] strVal, string proceDb)
        {
            string btProduceBs = ConfigurationManager.ConnectionStrings[proceDb].ToString();
            DataSet ds = (DataSet)_shareSqlMgr.ExecStoredProc(strSpName, strKey, strVal, btProduceBs, RetType.DataSet);
            return ds;
        }

        /// <summary>访问存储过程返回DataTable（支持多个数据库）
        ///
        /// </summary>
        /// <param name="mthReq">MthReq包含ProceName：存储过程名，ParamKeys参数名称，ParamVals参数值，数据库名称ProceDb，ParamIndex：如果要操作多个数据库，则根据程序App.config下add key="BtProduceCS"中用|分割的数据库名称顺序,从0开始计算的索引</param>
        /// <returns>返回DataTable</returns>
        public DataTable DataRequest_By_DataTable(MethodRequest mthReq)
        {
            string proceDb = mthReq.ProceDb;
            if (mthReq.ParamIndex >= 0)
            {
                string[] dbArray = proceDb.Split('|');
                if (mthReq.ParamIndex <= dbArray.Length - 1)
                {
                    proceDb = dbArray[mthReq.ParamIndex];
                }
                else
                {
                    return null;
                }
            }
            string btProduceBs = ConfigurationManager.ConnectionStrings[proceDb].ToString();
            string proceName = mthReq.ProceName;
            object[] paramVals = mthReq.ParamVals;
            string[] paramKeys = mthReq.ParamKeys;
            var dt = (DataTable)_shareSqlMgr.ExecStoredProc(proceName, paramKeys, paramVals, btProduceBs, RetType.Table);
            return dt;
        }

        /// <summary>访问存储过程返回DataTable（程序访问的数据库不止一个的情况下。）
        ///
        /// </summary>
        /// <param name="strSpName">存储过程</param>
        /// <param name="strKey">存储过程参数</param>
        /// <param name="strVal">存储过程值</param>
        /// <param name="proceDb">数据库名称</param>
        /// <param name="dbIndex">程序App.config下add key="BtProduceCS"中用|分割的数据库名称顺序,从0开始计算</param>
        /// <returns>返回DataTable</returns>
        public DataTable DataRequest_By_DataTable_More(string strSpName, string[] strKey, object[] strVal, string proceDb, int dbIndex)
        {
            if (dbIndex >= 0)
            {
                string[] dbArray = proceDb.Split('|');
                if (dbIndex <= dbArray.Length - 1)
                {
                    proceDb = dbArray[dbIndex];
                }
                else
                {
                    return null;
                }
            }
            string btProduceBs = ConfigurationManager.ConnectionStrings[proceDb].ToString();
            var dt = (DataTable)_shareSqlMgr.ExecStoredProc(strSpName, strKey, strVal, btProduceBs, RetType.Table);
            return dt;
        }

        /// <summary>访问存储过程返回DataTable（程序访问的数据库只有一个的情况下。）
        ///
        /// </summary>
        /// <param name="strSpName">存储过程</param>
        /// <param name="strKey">存储过程参数</param>
        /// <param name="strVal">存储过程值</param>
        /// <param name="proceDb">数据库名称</param>
        /// <returns>返回DataTable</returns>
        public DataTable DataRequest_By_DataTable_New(string strSpName, string[] strKey, object[] strVal, string proceDb)
        {
            string btProduceBs = ConfigurationManager.ConnectionStrings[proceDb].ToString();
            var dt = (DataTable)_shareSqlMgr.ExecStoredProc(strSpName, strKey, strVal, btProduceBs, RetType.Table);
            return dt;
        }

        /// <summary>分块下载
        ///
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="offset">要读取的位置</param>
        /// <param name="blocksize">要读取块大小</param>
        /// <param name="folder"></param>
        /// <returns>返回数据缓冲区</returns>
        public byte[] DownloadFile(string fileName, long offset, int blocksize, string folder)
        {
            string path = ConfigurationManager.AppSettings["SystemUpdateFilePath"] + "\\" + folder;
            path = Path.Combine(path, fileName);
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
                return null;
            if ((offset < 0) || (offset >= fileInfo.Length) || (blocksize < 0) || (blocksize > 1024 * 128))
                return null;
            var buff = new byte[blocksize];
            using (FileStream fs = new FileStream(path, FileMode.Open,
                                       FileAccess.Read, FileShare.Read))
            {
                fs.Seek(offset, SeekOrigin.Begin);
                fs.Read(buff, 0, blocksize);
                return buff;
            }
        }

        public UploadFileResponse UploadFile(FileUploadMessage request)
        {
            UploadFileResponse result = new UploadFileResponse();
            //string uploadFolder = "D:\\TestImg\\";
            string uploadFolder = request.SavePath;
            string fileName = request.FileName;
            Stream sourceStream = request.FileData;
            if (!sourceStream.CanRead)
            {
                throw new Exception("数据流不可读!");
            }
            if (!uploadFolder.EndsWith("\\")) uploadFolder += "\\";
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }
            string filePath = Path.Combine(uploadFolder, fileName);
            FileStream targetStream;
            using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                const int bufferLen = 1024 * 5;
                byte[] buffer = new byte[bufferLen];
                int count;
                while ((count = sourceStream.Read(buffer, 0, bufferLen)) > 0)
                {
                    targetStream.Write(buffer, 0, count);
                }
                targetStream.Close();
                sourceStream.Close();
            }
            result.Flag = true;
            return result;
        }
    }
}