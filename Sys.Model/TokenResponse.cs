using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model
{
    public class TokenResponse
    {
        [JsonProperty("tokenheader")]
        public string TokenHeader { get; set; }
        [JsonProperty("token")]
        public string Token  { get; set; }
        [JsonProperty("msg")]
        public string Msg { get; set; }
    }
}
