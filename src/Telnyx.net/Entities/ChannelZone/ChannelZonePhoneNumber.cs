using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.ChannelZone
{
    public class ChannelZonePhoneNumber : TelnyxEntity
    {
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("channel_zone_id")]
        public string ChannelZoneId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
    }
}
