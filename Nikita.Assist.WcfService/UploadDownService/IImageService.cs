using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Nikita.Assist.WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IImageService”。
    [ServiceContract]
    public interface IImageService
    {
        [OperationContract]
        byte[] FileRead(string strUrl, string fileName);


        [OperationContract]
        byte[] FileReadImage(  string fileName);
         
        [OperationContract]
        void FileSave(byte[] retBytes, string fileName,
              string imgUrl, string bigImgUrl, string smallImgUrl,
              string recentSmallImgUrl, string recentBigImgUrl, string recentOrgImgUrl);

        [OperationContract]
        void FileSaveImage(byte[] retBytes, string fileName);
         
    }
}
