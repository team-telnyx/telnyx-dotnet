using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.ShortCode
{
    public class ShortCodes : TelnyxEntity
    {
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("short_code")]
        public string ShortCode { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("messaging_profile_id")]
        public string MessagingProfileId { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}
