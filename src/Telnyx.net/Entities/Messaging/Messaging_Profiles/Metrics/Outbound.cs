namespace Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics
{
    using Newtonsoft.Json;

    public class Outbound
    {
        [JsonProperty("delivered")]
        public long Delivered { get; set; }

        [JsonProperty("errors")]
        public double Errors { get; set; }

        [JsonProperty("sent")]
        public long Sent { get; set; }
    }
}
