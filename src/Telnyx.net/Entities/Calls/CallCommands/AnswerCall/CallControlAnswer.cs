namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Call Control Answer
    /// </summary>
    public class CallControlAnswer : TelnyxEntity, IHasId
    {
        /// <summary>
        /// Gets Id
        /// </summary>
        [JsonProperty("id")]
        public Guid? Id { get; private set; }

        /// <summary>
        /// Gets RecordType
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; private set; }

        /// <summary>
        /// Gets EventType
        /// </summary>
        [JsonProperty("event_type")]
        public string EventType { get; private set; }

        /// <summary>
        /// Gets an ISO 8901 datetime string denoting when the resource was created
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; private set; }

        /// <summary>
        /// Gets or sets get the obtained payload
        /// </summary>
        [JsonProperty("payload")]
        public Payload PayloadObtained { get; set; }

        /// <summary>
        /// Gets or sets Id
        /// </summary>
        string IHasId.Id { get => this.Id.ToString(); set => Guid.Parse(value); }
    }
}
