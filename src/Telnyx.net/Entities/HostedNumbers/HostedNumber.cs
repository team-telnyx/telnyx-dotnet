namespace Telnyx.net.Entities.HostedNumbers
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public class HostedNumber : TelnyxEntity
    {
        /// <summary>
        /// Resource unique identifier.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The messaging hosted phone number (+E.164 format).
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Identifies the type of the resource.
        /// <see cref="Enum.RecordType"/>.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordType RecordType { get; set; }

        /// <summary>
        /// <see cref="NumberOrderStatus"/>.
        /// </summary>
        [JsonProperty("status")]
        public NumberOrderStatus Status { get; set; }
    }
}
