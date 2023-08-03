namespace Telnyx.net.Entities.DynamicEmergencyEndpoints
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.DynamicEmergencyEndpoints;

    public class DynamicEmergencyEndpoint : TelnyxEntity
    {
        /// <summary>
        /// The callback number.
        /// </summary>
        [JsonProperty("callback_number")]
        public string CallbackNumber { get; set; }

        /// <summary>
        /// The caller name.
        /// </summary>
        [JsonProperty("caller_name")]
        public string CallerName { get; set; }

        /// <summary>
        /// The creation date of the resource.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// The ID of the currently active dynamic emergency location.
        /// </summary>
        [JsonProperty("dynamic_emergency_address_id")]
        public string DynamicEmergencyAddressId { get; set; }

        /// <summary>
        /// The unique identifier of the resource.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// The SIP from ID.
        /// </summary>
        [JsonProperty("sip_from_id")]
        public string SipFromId { get; set; }

        /// <summary>
        /// The status of dynamic emergency address.
        /// Enum: "pending" "activated" "rejected".
        /// </summary>
        [JsonProperty("status")]
        public DynamicEmergencyAddressStatus Status { get; set; }

        /// <summary>
        /// The last updated date of the resource.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}
