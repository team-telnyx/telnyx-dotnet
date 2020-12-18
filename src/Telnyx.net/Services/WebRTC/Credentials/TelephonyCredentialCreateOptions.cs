namespace Telnyx.net.Services.WebRTC.Credentials
{
    using Newtonsoft.Json;

    public class TelephonyCredentialCreateOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets connection_id.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// Gets or sets expires_at.
        /// </summary>
        [JsonProperty("expires_at")]
        public string ExpiresAt { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// Optional.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets tag.
        /// Optional.
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}
