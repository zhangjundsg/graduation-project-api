using MailKit.Net.Smtp;
using MimeKit;
using Sys.Common;
using Sys.IService;
using Sys.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Service
{
    public class SendEmailService : ISendEmailService
    {
        public async Task<ResponseDto> SendEmailAsync(Model.SendEmail sm)
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
            var multipart = new Multipart();
            multipart.Add(new TextPart() { Text = sm.mailBody });
            if (sm.files.Count > 0)
            {
                foreach (var item in sm.files)
                {
                    var path = @"E:\System_Uploads\" + item;
                    FileStream stream = new FileStream(path, FileMode.Open);
                    var attachment = new MimePart()
                    {
                        Content = new MimeContent(stream, ContentEncoding.Default),
                        ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                        ContentTransferEncoding = ContentEncoding.Base64,
                        FileName = Path.GetFileName(path)
                    };
                    multipart.Add(attachment);
                }

            }
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(sm.fromPersonName, sm.fromPerson));
            message.To.AddRange(address);
            message.Subject = sm.mailTitle;
            message.Body = multipart;

            using var client = new SmtpClient
            {
                ServerCertificateValidationCallback = (s, c, h, e) => true
            };
            client.AuthenticationMechanisms.Remove("XOAUTH2");

            await client.ConnectAsync(sm.host, 465, true);
            await client.AuthenticateAsync(sm.fromPerson, sm.code);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
            return new ResponseDto() { Code = (int)ResponseCode.Success, Msg = "发送成功" };
        }

    }
}
