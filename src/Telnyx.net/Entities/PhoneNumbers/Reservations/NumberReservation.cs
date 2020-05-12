namespace Telnyx
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Number Reservation.
    /// </summary>
    public class NumberReservation : BaseOptions, ITelnyxEntity, IHasId
    {
        /// <summary>
        /// The status of the entire reservation.
        /// </summary>
        /// <value>Status of the entire reservation.</value>
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
        /// Gets id.
        /// </summary>
        [JsonProperty("id")]
        public Guid? Id { get; private set; }

        /// <summary>
        /// Gets recordType.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; private set; }

        /// <summary>
        /// Gets or sets PhoneNumbers.
        /// </summary>
        [JsonProperty("phone_numbers")]
        public List<ReservedPhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets the status of the entire reservation.
        /// </summary>
        /// <value>The status of the entire reservation.</value>
        [JsonProperty("status")]
        public StatusEnum? Status { get; set; }

        /// <summary>
        /// Gets or sets a customer reference string for customer look ups.
        /// </summary>
        /// <value>A customer reference string for customer look ups.</value>
        [JsonProperty("customer_reference")]
        public string CustomerReference { get; set; }

        /// <summary>
        /// Gets an ISO 8901 datetime string denoting when the numbers reservation was created.
        /// </summary>
        /// <value>An ISO 8901 datetime string denoting when the numbers reservation was created.</value>
        [JsonProperty("created_at")]
        public string CreatedAt { get; private set; }

        /// <summary>
        /// Gets an ISO 8901 datetime string for when the number reservation was updated.
        /// </summary>
        /// <value>An ISO 8901 datetime string for when the number reservation was updated.</value>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; private set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        string IHasId.Id { get => this.Id.ToString(); set => Guid.Parse(value); }

        /// <summary>
        /// Gets or sets Telnyx Response.
        /// </summary>
        [JsonIgnore]
        public TelnyxResponse TelnyxResponse { get; set; }
    }
}