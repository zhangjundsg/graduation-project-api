using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model
{
    public class UserEmail
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
