﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nikita.Base.Services.SendMessageService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SendMessageService.ISendMessageService", CallbackContract=typeof(Nikita.Base.Services.SendMessageService.ISendMessageServiceCallback))]
    public interface ISendMessageService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISendMessageService/GetMessage")]
        void GetMessage();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISendMessageService/AddMessage")]
        void AddMessage(Nikita.Assist.WcfService.MessageEntity messageEntity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISendMessageServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISendMessageService/ReceiveMessage")]
        void ReceiveMessage(Nikita.Assist.WcfService.MessageEntity messageEntity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISendMessageServiceChannel : Nikita.Base.Services.SendMessageService.ISendMessageService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SendMessageServiceClient : System.ServiceModel.DuplexClientBase<Nikita.Base.Services.SendMessageService.ISendMessageService>, Nikita.Base.Services.SendMessageService.ISendMessageService {
        
        public SendMessageServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public SendMessageServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public SendMessageServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public SendMessageServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public SendMessageServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void GetMessage() {
            base.Channel.GetMessage();
        }
        
        public void AddMessage(Nikita.Assist.WcfService.MessageEntity messageEntity) {
            base.Channel.AddMessage(messageEntity);
        }
    }
}
