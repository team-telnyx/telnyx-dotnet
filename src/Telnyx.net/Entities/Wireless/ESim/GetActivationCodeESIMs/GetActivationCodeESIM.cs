using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.ESim.GetActivationCodeESIMs
{
    public class GetActivationCodeESIM : TelnyxEntity
    {
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("activation_code")]
        public string ActivationCode { get; set; }
    }
}
