namespace Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

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
