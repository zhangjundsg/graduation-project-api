using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model
{
    public class SendEmail
    {
        /// <summary>
        /// 发送人
        /// </summary>
        public string fromPerson { get; set; } = "zhangjun200135@163.com";

        /// <summary>
        /// 发送人名称
        /// </summary>
        public string fromPersonName { get; set; }

        /// <summary>
        /// 收件人地址
        /// </summary>
        public string recipientArry { get; set; }

        /// <summary>
        /// 收件人名称
        /// </summary>
        public string recipientName { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string mailTitle { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public string mailBody { get; set; }

        /// <summary>
        /// 客户端授权码
        /// </summary>
        public string code { get; set; } = "GEBFBXEXBLGRGWMC";

        /// <summary>
        /// SMTP邮件服务器
        /// </summary>
        public string host { get; set; }

        /// <summary>
        /// 附件名
        /// </summary>
        public List<string> files { get; set; }

    }
}
