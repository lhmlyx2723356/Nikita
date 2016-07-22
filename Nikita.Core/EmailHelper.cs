using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Nikita.Core
{
    public class EmailHelper
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="subject">主题</param>
        /// <param name="body">邮件内容</param>
        /// <param name="to">对方邮箱</param>
        /// <param name="mailFrom">发件人</param>
        /// <param name="mailFromName">邮件显示发送人的名称</param>
        /// <param name="mailDomain">服务器地址</param>
        /// <param name="mailServerUserName">用户名和密码</param>
        /// <param name="mailServerPassWord">密码</param>
        /// <param name="lstAttemt">附件列表，如果为空则不发送</param>
        /// <returns></returns>
        public static bool Send(string subject, string body, string to, string mailFrom, string mailFromName, string mailDomain, string mailServerUserName, string mailServerPassWord, List<string> lstAttemt)
        {
            try
            {
                MailMessage msg = new MailMessage { From = new MailAddress(mailFrom, mailFromName) };
                msg.To.Add(new MailAddress(to, to));
                msg.Subject = subject;
                msg.Body = body;
                msg.IsBodyHtml = true;
                if (lstAttemt != null && lstAttemt.Count > 0)
                {
                    foreach (string strAttemt in lstAttemt)
                    {
                        //System.Net.Mime.ContentType type=new System.Net.Mime.ContentType();
                        //Attachment.CreateAttachmentFromString(strAttemt,)
                    }
                }
                msg.Priority = MailPriority.Normal;
                msg.SubjectEncoding = Encoding.UTF8;
                msg.BodyEncoding = Encoding.UTF8;
                //不被当作垃圾邮件的关键代码--Begin
                msg.Headers.Add("X-Priority", "3");
                msg.Headers.Add("X-MSMail-Priority", "Normal");
                msg.Headers.Add("X-Mailer", "Microsoft Outlook Express 6.00.2900.2869");   //本文以outlook名义发送邮件，不会被当作垃圾邮件
                msg.Headers.Add("X-MimeOLE", "Produced By Microsoft MimeOLE V6.00.2900.2869");
                msg.Headers.Add("ReturnReceipt", "1");

                //不被当作垃圾邮件的关键代码--End

                SmtpClient client = new SmtpClient(mailDomain)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(mailServerUserName, mailServerPassWord),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                //帐号密码
                client.Send(msg);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

//腾讯QQ邮箱
//接收服务器：pop.qq.com
//发送服务器：smtp.qq.com

//网易126邮箱
//接收服务器：pop3.126.com
//发送服务器：smtp.126.com

//网易163免费邮
//接收服务器：pop.163.com
//发送服务器：smtp.163.com

//网易163VIP邮箱
// 接收服务器：pop.vip.163.com
//发送服务器：smtp.vip.163.com

//网易188财富邮
// 接收服务器：pop.188.com
//发送服务器：smtp.188.com

//网易yeah.net邮箱
// 接收服务器：pop.yeah.net
//发送服务器：smtp.yeah.net

//网易netease.com邮箱
// 接收服务器：pop.netease.com
//发送服务器：smtp.netease.com

//新浪收费邮箱
// 接收服务器：pop3.vip.sina.com
//发送服务器：smtp.vip.sina.com

//新浪免费邮箱
// 接收服务器：pop3.sina.com.cn
//发送服务器：smtp.sina.com.cn

//搜狐邮箱
// 接收服务器：pop3.sohu.com
//发送服务器：smtp.sohu.com

// 21cn快感邮
// 接收服务器：vip.21cn.com
//发送服务器：vip.21cn.com

// 21cn经济邮
// 接收服务器：pop.163.com
//发送服务器：smtp.163.com

// tom邮箱
// 接收服务器：pop.tom.com
//发送服务器：smtp.tom.com

// 263邮箱
// 接收服务器：263.net
//发送服务器：smtp.263.net

//网易163.com邮箱
// 接收服务器：rwypop.china.com
//发送服务器：rwypop.china.com

//雅虎邮箱
// 接收服务器：pop.mail.yahoo.com
//发送服务器：smtp.mail.yahoo.com

// Gmail邮箱
// 接收服务器：pop.gmail.com
//发送服务器：smtp.gmail.com