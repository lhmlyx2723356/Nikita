using System.Data;
using System.IO;
using System.ServiceModel;

namespace Nikita.Assist.WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IService1
    {
        /// <summary>访问存储过程返回DataSet（支持多个数据库）
        /// 
        /// </summary>
        /// <param name="mthReq">MthReq包含ProceName：存储过程名，ParamKeys参数名称，ParamVals参数值，数据库名称ProceDb，ParamIndex：如果要操作多个数据库，则根据程序App.config下add key="BtProduceCS"中用|分割的数据库名称顺序,从0开始计算的索引</param>
        /// <returns>返回DataSet</returns>
        [OperationContract]
        DataSet DataRequest_By_DataSet(MethodRequest mthReq);

        /// <summary>访问存储过程返回DataSet（程序访问的数据库不止一个的情况下。）
        /// 
        /// </summary>
        /// <param name="strSpName">存储过程</param>
        /// <param name="strKey">存储过程参数</param>
        /// <param name="strVal">存储过程值</param>
        /// <param name="proceDb">数据库名称</param>
        /// <param name="dbIndex">程序App.config下add key="BtProduceCS"中用|分割的数据库名称顺序,从0开始计算</param>
        /// <returns>返回DataSet</returns>
        [OperationContract]
        DataSet DataRequest_By_DataSet_More(string strSpName, string[] strKey, object[] strVal, string proceDb, int dbIndex);

        /// <summary>访问存储过程返回DataSet（程序访问的数据库只有一个的情况下。）
        /// 
        /// </summary>
        /// <param name="strSpName">存储过程</param>
        /// <param name="strKey">存储过程参数</param>
        /// <param name="strVal">存储过程值</param>
        /// <param name="proceDb">数据库名称</param>
        /// <returns>返回DataSet</returns>
        [OperationContract]
        DataSet DataRequest_By_DataSet_New(string strSpName, string[] strKey, object[] strVal, string proceDb);

        /// <summary>访问存储过程返回DataTable（支持多个数据库）
        /// 
        /// </summary>
        /// <param name="mthReq">MthReq包含ProceName：存储过程名，ParamKeys参数名称，ParamVals参数值，数据库名称ProceDb，ParamIndex：如果要操作多个数据库，则根据程序App.config下add key="BtProduceCS"中用|分割的数据库名称顺序,从0开始计算的索引</param>
        /// <returns>返回DataTable</returns>
        [OperationContract]
        DataTable DataRequest_By_DataTable(MethodRequest mthReq);
        /// <summary>访问存储过程返回DataTable（程序访问的数据库不止一个的情况下。）
        /// 
        /// </summary>
        /// <param name="strSpName">存储过程</param>
        /// <param name="strKey">存储过程参数</param>
        /// <param name="strVal">存储过程值</param>
        /// <param name="proceDb">数据库名称</param>
        /// <param name="dbIndex">程序App.config下add key="BtProduceCS"中用|分割的数据库名称顺序,从0开始计算</param>
        /// <returns>返回DataTable</returns>
        [OperationContract]
        DataTable DataRequest_By_DataTable_More(string strSpName, string[] strKey, object[] strVal, string proceDb, int dbIndex);

        /// <summary>访问存储过程返回DataTable（程序访问的数据库只有一个的情况下。）
        /// 
        /// </summary>
        /// <param name="strSpName">存储过程</param>
        /// <param name="strKey">存储过程参数</param>
        /// <param name="strVal">存储过程值</param>
        /// <param name="proceDb">数据库名称</param>
        /// <returns>返回DataTable</returns>
        [OperationContract]
        DataTable DataRequest_By_DataTable_New(string strSpName, string[] strKey, object[] strVal, string proceDb);
        /// <summary>分块下载
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="offset">要读取的位置</param>
        /// <param name="blocksize">要读取块大小</param>
        /// <param name="folder"></param>
        /// <returns>返回数据缓冲区</returns>
        [OperationContract(Action = "DownloadFile")]
        byte[] DownloadFile(string fileName, long offset, int blocksize, string folder);

        [OperationContract(Action = "UploadFile")]
        UploadFileResponse UploadFile(FileUploadMessage request);
    }

    [MessageContract]
    public class FileUploadMessage
    {
        [MessageBodyMember(Order = 1)]
        public Stream FileData;

        [MessageHeader(MustUnderstand = true)]
        public string FileName;

        [MessageHeader(MustUnderstand = true)]
        public string SavePath;
    }

    [MessageContract]
    public class UploadFileResponse
    {
        [MessageHeader(MustUnderstand = true)]
        public bool Flag;
    }

}
