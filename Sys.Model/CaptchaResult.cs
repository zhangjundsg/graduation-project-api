using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sys.Model
{
    public class CaptchaResult
    {
        [JsonProperty("captchacode")]
        public string CaptchaCode { get; set; }
        [JsonProperty("captchamemorystream")]
        public MemoryStream CaptchaMemoryStream { get; set; }
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
