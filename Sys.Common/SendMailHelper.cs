using Sys.Model;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Sys.Common
{
    public class SendMailHelper
    {
        /// <summary>
        /// 根据实体类发送邮件
        /// 创建人：金永宝
        /// 创建时间：2020年8月11日
        /// </summary>
        /// <param name="mails"></param>
        /// <returns></returns>
        public static void SendMail(SendEmail mails)
        {
            string[] sArray = mails.fromPerson.Split(new char[2] { '@', '.' });
            if (sArray[1] == "qq")
            {
                mails.host = "smtp.qq.com";
            }
            else if (sArray[1] == "163")
            {
                mails.host = "smtp.163.com";
            }

            //将发件人邮箱带入MailAddress中初始化
            MailAddress mailAddress = new MailAddress(mails.fromPerson);
            //创建Email的Message对象
            MailMessage mailMessage = new MailMessage();
            //收件人
            mailMessage.To.Add(mails.recipientArry);
            //发件人邮箱
            mailMessage.From = mailAddress;
            //标题
            mailMessage.Subject = mails.mailTitle;
            //编码
            mailMessage.SubjectEncoding = Encoding.UTF8;
            //正文
            mailMessage.Body = mails.mailBody;
            //正文编码
            mailMessage.BodyEncoding = Encoding.Default;
            //邮件优先级
            mailMessage.Priority = MailPriority.High;
            //正文是否是html格式
            mailMessage.IsBodyHtml = mails.isbodyHtml;
            //实例化一个Smtp客户端
            SmtpClient smtp = new SmtpClient();
            //将发件人的邮件地址和客户端授权码带入以验证发件人身份
            smtp.Credentials = new System.Net.NetworkCredential(mails.fromPerson, mails.code);
            //指定SMTP邮件服务器
            smtp.Host = mails.host;

            //邮件发送到SMTP服务器
            smtp.Send(mailMessage);
        }
    }
}
