using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum;

namespace Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics
{
    public class MessagingProfileMetricsOverview : TelnyxEntity
    {
        [JsonProperty("inbound")]
        public Inbound Inbound { get; set; }

        [JsonProperty("messaging_profile_id")]
        public Guid? MessagingProfileId { get; set; }

        [JsonProperty("outbound")]
        public Outbound Outbound { get; set; }

        [JsonProperty("phone_numbers")]
        public long PhoneNumbers { get; set; }

        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }
    }
}
