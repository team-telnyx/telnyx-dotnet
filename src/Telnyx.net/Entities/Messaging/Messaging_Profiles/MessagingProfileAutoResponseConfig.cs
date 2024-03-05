using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Messaging.Messaging_Profiles
{
    public class MessagingProfileAutoResponseConfig : TelnyxEntity
    {
        [JsonProperty("op")]
        public string Operation { get; set; }

        [JsonProperty("keywords")]
        public string[] Keywords { get; set; }

        [JsonProperty("resp_text")]
        public string ResponseText { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
