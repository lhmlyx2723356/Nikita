using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Nikita.Assist.WcfService;
using Nikita.Base.Services.SendMessageService; 

namespace Nikita.Base.Services
{
    public class SendService //:  ISendMessageServiceCallback
    { 
        public void GetMessage()
        {
            SendMessageServiceClient client = new SendMessageServiceClient(new System.ServiceModel.InstanceContext(this));
            client.GetMessage();
        }

        public void AddMessage(MessageEntity messageEntity)
        {
            SendMessageServiceClient client = new SendMessageServiceClient(new System.ServiceModel.InstanceContext(this));
            client.AddMessage(messageEntity);
        }
         
    }
}
