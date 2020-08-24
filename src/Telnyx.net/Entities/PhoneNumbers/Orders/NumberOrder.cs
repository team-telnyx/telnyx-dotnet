namespace Telnyx
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    /// <summary>
    /// Number Order.
    /// </summary>
    public class NumberOrder : TelnyxEntity, IHasId
    {
        /// <summary>
        /// The status of the order.
        /// </summary>
        /// <value>Status of the order.</value>
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
        public RecordType? RecordType { get; private set; }

        /// <summary>
        /// Gets or sets PhoneNumbers.
        /// </summary>
        [JsonProperty("phone_numbers")]
        public List<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Gets the count of phone numbers in the number order.
        /// </summary>
        /// <value>The count of phone numbers in the number order.</value>
        [JsonProperty("phone_numbers_count")]
        public int? PhoneNumbersCount { get; private set; }

        /// <summary>
        /// Gets or sets the status of the order.
        /// </summary>
        /// <value>The status of the order. <see cref="StatusEnum"/>.</value>
        [JsonProperty("status")]
        public StatusEnum? Status { get; set; }

        /// <summary>
        /// Gets or sets a customer reference string for customer look ups.
        /// </summary>
        /// <value>A customer reference string for customer look ups.</value>
        [JsonProperty("customer_reference")]
        public string CustomerReference { get; set; }

        /// <summary>
        /// Gets or sets the connection id to set the number to upon acquiring the number.
        /// </summary>
        /// <value>The connection id to set the number to upon acquiring the number.</value>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// Gets or sets the messaging profile id to set the number to upon acquiring the number.
        /// </summary>
        /// <value>The messaging profile id to set the number to upon acquiring the number.</value>
        [JsonProperty("messaging_profile_id")]
        public Guid? MessagingProfileId { get; set; }

        /// <summary>
        /// Gets or sets a webhook URL for number order status updates.
        /// </summary>
        /// <value>A webhook URL for number order status updates.</value>
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        /// <summary>
        /// Gets or sets if above webhook URL fails, this URL will be used as a fail over.
        /// </summary>
        /// <value>If above webhook URL fails, this URL will be used as a fail over.</value>
        [JsonProperty("webhook_failover_url")]
        public string WebhookFailoverUrl { get; set; }

        /// <summary>
        /// Gets an ISO 8901 datetime string denoting when the number order was created.
        /// </summary>
        /// <value>An ISO 8901 datetime string denoting when the number order was created.</value>
        [JsonProperty("created_at")]
        public string CreatedAt { get; private set; }

        /// <summary>
        /// Gets an ISO 8901 datetime string for when the number order was updated.
        /// </summary>
        /// <value>An ISO 8901 datetime string for when the number order was updated.</value>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; private set; }

        /// <summary>
        /// Gets true if all requirements are met for every phone number, false otherwise.
        /// </summary>
        /// <value>True if all requirements are met for every phone number, false otherwise.</value>
        [JsonProperty("requirements_met")]
        public bool? RequirementsMet { get; private set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        string IHasId.Id { get => this.Id.ToString(); set => Guid.Parse(value); }
    }
}
