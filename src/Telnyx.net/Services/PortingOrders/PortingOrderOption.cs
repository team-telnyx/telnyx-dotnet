namespace Telnyx.net.Services
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.Connections;

    public class PortingOrderOption : ListOptions
    {
        /// <summary>
        /// Default: true
        /// Include the first 50 phone number objects in the results.
        /// </summary>
        [JsonProperty("include_phone_numbers")]
        public bool IncludePhoneNumbers { get; set; } = true;

        /// <summary>
        /// Filter results by status
        /// </summary>
        [JsonProperty("filter[status]")]
        public PortingOrderStatus? Status { get; set; }

        /// <summary>
        /// Filter results by user reference.
        /// </summary>
        [JsonProperty("filter[customer_reference]")]
        public string CustomerReference { get; set; }

        /// <summary>
        /// Filter results by country ISO 3166-1 alpha-2 code.
        /// </summary>
        [JsonProperty("filter[phone_numbers][country_code]")]
        public string PhoneNumberCountryCode { get; set; }

        /// <summary>
        /// Filter results by old service provider.
        /// </summary>
        [JsonProperty("filter[phone_numbers][carrier_name]")]
        public string PhoneNumberCarrierName { get; set; }

        /// <summary>
        /// Filter results by porting order type.
        /// Enum: "full" "partial".
        /// </summary>
        [JsonProperty("filter[misc][type]")]
        public MiscType? MiscType { get; set; }

        /// <summary>
        /// Filter results by person or company name.
        /// </summary>
        [JsonProperty("filter[end_user][admin][entity_name]")]
        public string EndUserAdminEntityName { get; set; }

        /// <summary>
        /// Filter results by authorized person.
        /// </summary>
        [JsonProperty("filter[end_user][admin][auth_person_name]")]
        public string EndUserAdminAuthPersonName { get; set; }

        /// <summary>
        /// Filter results by fast port eligible.
        /// </summary>
        [JsonProperty("filter[activation_settings][fast_port_eligible]")]
        public bool? ActivationSettingFastPortEligible { get; set; }

        /// <summary>
        /// Filter results by foc date later than this value.
        /// </summary>
        [JsonProperty("filter[activation_settings][foc_datetime_requested][gt]")]
        public DateTime? ActivationSettingFocDateTimeRequestedGt { get; set; }

        /// <summary>
        /// Filter results by foc date earlier than this value.
        /// </summary>
        [JsonProperty("filter[activation_settings][foc_datetime_requested][lt]")]
        public DateTime? ActivationSettingFocDateTimeRequestedLt { get; set; }

        /// <summary>
        /// Specifies the sort order for results. If not given, results are sorted by created_at in descending order.
        /// </summary>
        [JsonProperty("sort")]
        public ConnectionSort Sort { get; set; } = ConnectionSort.CreatedAt;
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    /// <value>Type of the resource.</value>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum PortingOrderStatus
    {
        [EnumMember(Value = "draft")]
        Draft = 0,
        [EnumMember(Value = "in-process")]
        InProcess = 1,
        [EnumMember(Value = "submitted")]
        Submitted = 0,
        [EnumMember(Value = "exception")]
        Exception = 1,
        [EnumMember(Value = "foc-date-confirmed")]
        FocDateConfirmed = 0,
        [EnumMember(Value = "cancel-pending")]
        CancelPending = 1,
        [EnumMember(Value = "ported")]
        Ported = 0,
        [EnumMember(Value = "cancelled")]
        Cancelled = 1,
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    /// <value>Type of the resource.</value>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum MiscType
    {
        [EnumMember(Value = "full")]
        Full = 0,
        [EnumMember(Value = "partial")]
        Partial = 1
    }
}
