namespace Telnyx
{
    using Newtonsoft.Json;

    /// <summary>
    /// Outbound media
    /// </summary>
    public class OutboundMessageMedia
    {
        /// <summary>
        /// Gets or sets Url
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets ContentType
        /// </summary>
        [JsonProperty("content_type")]
        public string ContentType { get; set; }
    }
}
