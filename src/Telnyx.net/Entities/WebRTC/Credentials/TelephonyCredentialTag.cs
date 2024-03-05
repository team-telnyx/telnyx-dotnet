using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.WebRTC.Credentials
{
    public class TelephonyCredentialTag : TelnyxEntity
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
