using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model
{
    public class TokenResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("tokenheader")]
        public string TokenHeader { get; set; }
        [JsonProperty("token")]
        public string Token  { get; set; }
        [JsonProperty("msg")]
        public string Msg { get; set; }
    }
}
