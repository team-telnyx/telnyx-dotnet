namespace Telnyx.net.Entities.Messaging.Messaging_Profiles.Metrics
{
    using Newtonsoft.Json;

    public class Inbound
    {
        [JsonProperty("received")]
        public long Received { get; set; }
    }
}
