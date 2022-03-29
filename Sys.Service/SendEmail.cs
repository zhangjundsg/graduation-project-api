using MailKit.Net.Smtp;
using MimeKit;
using Sys.Common;
using Sys.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Service
{
    public class SendEmail : ISendEmail
    {
        public async Task<string> SendEmailAsync(Model.SendEmail sm)
        {
            try
            {
                string[] sArray = sm.fromPerson.Split(new char[2] { '@', '.' });
                if (sArray[1] == "qq")
                {
                    sm.host = "smtp.qq.com";
                }
                else if (sArray[1] == "163")
                {
                    sm.host = "smtp.163.com";
                }
                var address = new List<MailboxAddress>
                {
                new MailboxAddress(sm.recipientName,sm.recipientArry)
                };

                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(sm.fromPersonName, sm.fromPerson));
                message.To.AddRange(address);
                message.Subject = sm.mailTitle;
                message.Body = new BodyBuilder { TextBody = sm.mailBody }.ToMessageBody();

                using var client = new SmtpClient
                {
                    ServerCertificateValidationCallback = (s, c, h, e) => true
                };
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                await client.ConnectAsync(sm.host, 465, true);
                await client.AuthenticateAsync(sm.fromPerson, sm.code);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                return "发送成功";
            }
            catch (Exception)
            {
                return "发送失败";
            }
        }

    }
}
