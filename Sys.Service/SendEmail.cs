using Sys.Common;
using Sys.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Service
{
    public class SendEmail : ISendEmail
    {
        public string SendSysEmail(Model.SendEmail sm)
        {
            try
            {
                SendMailHelper.SendMail(sm);
                return "发送成功！";
            }
            catch (Exception)
            {
                return "发送失败！";
            }
        }
    }
}
