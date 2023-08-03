namespace Telnyx.net.Entities.WebRTC.Credentials
{
    using Newtonsoft.Json;

    /// <summary>
    /// WebRTC Credential Entity.
    /// </summary>
    public class WebRtcCredential : TelnyxEntity, IHasId
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets or Sets RecordType.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; private set; }

        /// <summary>
        /// Gets or Sets resource_id.
        /// </summary>
        [JsonProperty("resource_id")]
        public string ResourceId { get; private set; }

        /// <summary>
        /// Gets or Sets user_id.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; private set; }

        /// <summary>
        /// Gets or Sets sip_password.
        /// </summary>
        [JsonProperty("sip_password")]
        public string SipPassword { get; private set; }

        /// <summary>
        /// Gets or Sets sip_username.
        /// </summary>
        [JsonProperty("sip_username")]
        public string SipUsername { get; private set; }

        /// <summary>
        /// ISO 8601 formatted date-time indicating when the resource was expired.
        /// </summary>
        [JsonProperty("expires_at")]
        public string ExpiredAt { get; private set; }

        /// <summary>
        /// ISO 8601 formatted date-time indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; private set; }

        /// <summary>
        /// ISO 8601 formatted date-time indicating when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; private set; }
    }
}
