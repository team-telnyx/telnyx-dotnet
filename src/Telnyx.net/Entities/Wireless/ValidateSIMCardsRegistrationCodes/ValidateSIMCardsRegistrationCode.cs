using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.ValidateSIMCardsRegistrationCodes
{
    public class ValidateSIMCardsRegistrationCode : TelnyxEntity
    {
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("registration_code")]
        public string RegistrationCode { get; set; }

        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("invalid_detail")]
        public string InvalidDetail { get; set; }
    }
}
