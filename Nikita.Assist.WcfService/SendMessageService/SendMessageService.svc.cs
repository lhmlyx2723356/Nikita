using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Threading;

namespace Nikita.Assist.WcfService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class SendMessageService : ISendMessageService
    {
        ISendMessageServiceCallBack _callback;
        Timer _heartTimer;
        readonly Random _random = new Random();

        List<MessageEntity> _messageList = HttpRuntime.Cache["MessageEntityList"] as List<MessageEntity>;
        #region ISendMessageService 成员

        /// <summary>添加信息
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void AddMessage(MessageEntity message)
        {
            if (_messageList == null)
            {
                _messageList = new List<MessageEntity> { message };
                HttpRuntime.Cache.Add("MessageEntityList", _messageList, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, null);
            }
            else
            {
                _messageList.Add(message);
                HttpRuntime.Cache["MessageEntityList"] = _messageList;
            }
            //立刻发布消息
            if (_messageList!=null)
            {
                GetMessage();
            }
        }
        /// <summary>获取信息
        /// 
        /// </summary>
        public void GetMessage()
        {
            _callback = OperationContext.Current.GetCallbackChannel<ISendMessageServiceCallBack>();
            List<MessageEntity> list = HttpRuntime.Cache["MessageEntityList"] as List<MessageEntity>;
            if (list != null && list.Count > 0)
            {
                MessageEntity message = list[0];
                list.Remove(message);
                HttpRuntime.Cache["MessageEntityList"] = list;
                _callback.ReceiveMessage(message);
            }
            //_heartTimer = new Timer(heartTimer_Elapsed, null, 5, Timeout.Infinite);
        }

        #endregion

        private void heartTimer_Elapsed(object data)
        {
            List<MessageEntity> messageList = HttpRuntime.Cache["MessageEntityList"] as List<MessageEntity>;
            if (messageList != null && messageList.Count > 0)
            {
                MessageEntity message = messageList[0];
                messageList.Remove(message);
                HttpRuntime.Cache["MessageEntityList"] = messageList;
                _callback.ReceiveMessage(message);
            }
            int interval = _random.Next(0, 1000);
            _heartTimer.Change(interval, Timeout.Infinite);
        }
    }
}
