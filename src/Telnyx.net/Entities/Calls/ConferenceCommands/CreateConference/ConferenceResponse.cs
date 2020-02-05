namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Conference Response
    /// </summary>
    public class ConferenceResponse : TelnyxEntity, IHasId
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets name of the conference
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets an ISO 8901 datetime string denoting when the resource was created
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets an ISO 8901 datetime string denoting when the resource was created
        /// </summary>
        [JsonProperty("expires_at")]
        public string ExpiresAt { get; set; }

        /// <inheritdoc/>
        string IHasId.Id { get => this.Id.ToString(); set => Guid.Parse(value); }
    }
}
