namespace Telnyx.net.Entities.Wireless.OTAUpdates
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public class OTAUpdatesRecord : TelnyxEntity, IHasId
    {
        /// <summary>
        /// Identifies the resource.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets ts RecordType.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; private set; }

        /// <summary>
        /// The indentification UUID of the related SIM card resource.
        /// </summary>
        [JsonProperty("sim_card_id")]
        public Guid? SimCardId { get; set; }

        /// <summary>
        /// Represents the type of the operation requested. This will relate directly to the source of the request.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets Settings.
        /// </summary>
        [JsonProperty("settings")]
        public CompleteOTAUpdateSettings Settings { get; set; }

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
