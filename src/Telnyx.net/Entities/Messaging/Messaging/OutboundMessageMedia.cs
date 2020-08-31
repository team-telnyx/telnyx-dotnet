namespace Telnyx
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Messaging.Messaging;

    /// <summary>
    /// Outbound media.
    /// </summary>
    public class OutboundMessageMedia : MessageMedia
    {
        [JsonProperty("sha256")]
        public new string Sha256 { get; set; }

    }
}
