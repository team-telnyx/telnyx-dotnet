using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.VerifiedNumbers
{
    public class VerifiedNumber : TelnyxEntity
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("verified_at")]
        public string VerifiedAt { get; set; }
    }

}
