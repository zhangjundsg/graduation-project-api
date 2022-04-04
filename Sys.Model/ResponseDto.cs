using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model
{
    public class ResponseDto
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Msg { get; set; }
    }
}
