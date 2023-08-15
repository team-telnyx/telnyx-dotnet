namespace Telnyx.net.Entities.HostedNumbers
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public partial class HostedNumberOrder : TelnyxEntity
    {
        /// <summary>
        /// Resource unique identifier.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Collection of phone numbers for this order.
        /// </summary>
        [JsonProperty("phone_numbers")]
        public IEnumerable<HostedNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Automatically associate the number with this messaging profile ID when the order is complete.
        /// </summary>
        [JsonProperty("messaging_profile_id")]
        public string MessagingProfileId { get; set; }

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
