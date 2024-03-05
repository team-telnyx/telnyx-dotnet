using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Messaging.Messaging_Profiles
{
    public class MessagingProfileAutoResponseConfigOption : ListOptions
    {
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAtGte { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAtLte { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAtGte { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAtLte { get; set; }
    }
}
