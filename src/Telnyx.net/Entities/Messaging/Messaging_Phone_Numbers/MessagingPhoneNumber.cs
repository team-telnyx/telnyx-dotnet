namespace Telnyx
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;
    using Telnyx.net.Infrastructure.JsonConverters;

    /// <summary>
    /// Phone Number Type Enum.
    /// </summary>
    [JsonConverter(typeof(SafeStringEnumConverter), Unknown)]
    public enum PhoneNumberTypeEnum
    {
        Unknown = -1,

        /// <summary>
        /// long-code
        /// </summary>
        [EnumMember(Value = "longcode")]
        LongCodeEnum = 0,

        /// <summary>
        /// toll-free
        /// </summary>
        [EnumMember(Value = "tollfree")]
        TollFreeEnum = 1,

        /// <summary>
        /// short-code
        /// </summary>
        [EnumMember(Value = "shortcode")]
        ShortCodeEnum = 2
    }

    /// <summary>
    /// Messaging Phone Number.
    /// </summary>
    public class MessagingPhoneNumber : TelnyxEntity, IHasId
    {
        /// <summary>
        /// Gets or sets identifies the type of the resource.
        /// </summary>
        /// <value>Identifies the type of the resource.</value>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        /// <summary>
        /// Gets or sets uniquely identifies the resource or object.
        /// </summary>
        /// <value>Uniquely identifies the resource or object.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets +E164 formatted phone number.
        /// </summary>
        /// <value>+E164 formatted phone number.</value>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets unique identifier for a messaging profile.
        /// </summary>
        /// <value>Unique identifier for a messaging profile.</value>
        [JsonProperty("messaging_profile_id")]
        public Guid? MessagingProfileId { get; set; }

        /// <summary>
        /// Gets or sets unique identifier for the organization that owns the resource.
        /// </summary>
        /// <value>Unique identifier for the organization that owns the resource.</value>
        [JsonProperty("organization_id")]
        public Guid? OrganizationId { get; set; }

        /// <summary>
        /// Gets or sets ISO 8601 formatted date indicating when the resource was created.
        /// </summary>
        /// <value>ISO 8601 formatted date indicating when the resource was created.</value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets ISO 8601 formatted date indicating when the resource was updated.
        /// </summary>
        /// <value>ISO 8601 formatted date indicating when the resource was updated.</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets iSO 3166-1 alpha-2 country code.
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the phone number.
        /// </summary>
        [JsonProperty("type")]
        public PhoneNumberTypeEnum? Type { get; set; }

        /// <summary>
        /// Gets or sets high level health metrics about the number and it's messaging sending patterns.
        /// </summary>
        [JsonProperty("health")]
        public MessagingPhoneNumberHealth Health { get; set; }

        /// <summary>
        /// Gets or sets the messaging products that this number can be registered to use.
        /// </summary>
        [JsonProperty("eligible_messaging_products")]
        public List<string> EligibleMessagingProducts { get; set; }

        /// <summary>
        /// Gets or sets the messaging traffic or use case for which the number is currently configured.
        /// </summary>
        [JsonProperty("traffic_type")]
        public string TrafficType { get; set; }

        /// <summary>
        /// Gets or sets the messaging product that the number is registered to use.
        /// </summary>
        [JsonProperty("messaging_product")]
        public string MessagingProduct { get; set; }

        /// <summary>
        /// Gets or sets features.
        /// </summary>
        [JsonProperty("features")]
        public MessagingPhoneNumberFeatures Features { get; set; }
    }
}
