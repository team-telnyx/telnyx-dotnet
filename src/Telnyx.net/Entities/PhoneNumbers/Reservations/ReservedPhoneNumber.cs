namespace Telnyx
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Reserved Phone Number.
    /// </summary>
    public class ReservedPhoneNumber
    {
        /// <summary>
        /// The status of the phone number's reservation.
        /// </summary>
        /// <value>Status of the phone number's reservation.</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum PendingEnum for pending
            /// </summary>
            [EnumMember(Value = "pending")]
            PendingEnum = 0,

            /// <summary>
            /// Enum SuccessEnum for success
            /// </summary>
            [EnumMember(Value = "success")]
            SuccessEnum = 1,

            /// <summary>
            /// Enum FailureEnum for failure
            /// </summary>
            [EnumMember(Value = "failure")]
            FailureEnum = 2
        }

        /// <summary>
        /// Gets Id.
        /// </summary>
        [JsonProperty("id")]
        public Guid? Id { get; private set; }

        /// <summary>
        /// Gets recordType.
        /// </summary>
        [JsonProperty("record_type", NullValueHandling = NullValueHandling.Ignore)]
        public string RecordType { get; private set; }

        /// <summary>
        /// Gets or sets PhoneNumber.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the status of the phone number's reservation.
        /// </summary>
        /// <value>The status of the phone number&#x27;s reservation.</value>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public StatusEnum? Status { get; set; }

        /// <summary>
        /// Gets an ISO 8901 datetime string denoting when the individual number reservation was created.
        /// </summary>
        /// <value>An ISO 8901 datetime string denoting when the individual number reservation was created.</value>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; private set; }

        /// <summary>
        /// Gets an ISO 8901 datetime string for when the the individual number reservation was updated.
        /// </summary>
        /// <value>An ISO 8901 datetime string for when the the individual number reservation was updated.</value>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; private set; }

        /// <summary>
        /// Gets an ISO 8901 datetime string for when the individual number reservation is going to expire.
        /// </summary>
        /// <value>An ISO 8901 datetime string for when the individual number reservation is going to expire.</value>
        [JsonProperty("expired_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiredAt { get; private set; }
    }
}
