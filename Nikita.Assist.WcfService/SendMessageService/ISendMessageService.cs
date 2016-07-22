using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text; 

namespace Nikita.Assist.WcfService
{
    // 注意: 如果更改此处的接口名称 "ISendMessageService"，也必须更新 Web.config 中对 "ISendMessageService" 的引用。
    [ServiceContract(CallbackContract = typeof(ISendMessageServiceCallBack))]
    public interface ISendMessageService
    {
        [OperationContract(IsOneWay = true)]
        void GetMessage();


        [OperationContract(IsOneWay = true)]
        void AddMessage(MessageEntity messageEntity);
    }

    public interface ISendMessageServiceCallBack
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(MessageEntity messageEntity);
    }
}
