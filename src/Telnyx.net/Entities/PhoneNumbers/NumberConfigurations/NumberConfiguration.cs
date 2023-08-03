namespace Telnyx.net.Entities.PhoneNumbers.NumberConfigurations
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum NumberConfigStatus
    {
        [EnumMember(Value = "purchase-pending")]
        PurchasePending = 0,

        [EnumMember(Value = "purchase-failed")]
        PurchaseFailed = 1,

        [EnumMember(Value = "port-pending")]
        PortPending = 2,

        [EnumMember(Value = "port-failed")]
        PortFailed = 3,

        [EnumMember(Value = "active")]
        Active = 4,

        [EnumMember(Value = "deleted")]
        Deleted = 5,

        [EnumMember(Value = "emergency-only")]
        EmergencyOnly = 6,

        [EnumMember(Value = "ported-out")]
        PortedOut = 7,
        [EnumMember(Value = "port-out-pending")]
        PortOutPending = 8,
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum PaymentMethod
    {
        [EnumMember(Value = "pay-per-minute")]
        PayPerMinute = 0,

        [EnumMember(Value = "channel")]
        Channel = 1,
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum Sort
    {
        [EnumMember(Value = "purchased_at")]
        PurchasedAt = 0,

        [EnumMember(Value = "phone_number")]
        PhoneNumber = 1,

        [EnumMember(Value = "connection_name")]
        ConnectionName = 0,

        [EnumMember(Value = "usage_payment_method")]
        UsagePaymentMethod = 1,
    }

    public class NumberConfiguration : TelnyxEntity
    {
        [JsonProperty("billing_group_id")]
        public Guid? BillingGroupId { get; set; }

        [JsonProperty("call_forwarding_enabled")]
        public bool CallForwardingEnabled { get; set; }

        [JsonProperty("call_recording_enabled")]
        public bool CallRecordingEnabled { get; set; }

        [JsonProperty("caller_id_name_enabled")]
        public bool CallerIdNameEnabled { get; set; }

        [JsonProperty("cnam_listing_enabled")]
        public bool CnamListingEnabled { get; set; }

        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        [JsonProperty("connection_name")]
        public string ConnectionName { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("emergency_address_id")]
        public string EmergencyAddressId { get; set; }

        [JsonProperty("emergency_enabled")]
        public bool EmergencyEnabled { get; set; }

        [JsonProperty("external_pin")]
        public string ExternalPin { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("messaging_profile_id")]
        public Guid? MessagingProfileId { get; set; }

        [JsonProperty("messaging_profile_name")]
        public string MessagingProfileName { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("purchased_at")]
        public DateTimeOffset? PurchasedAt { get; set; }

        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        [JsonProperty("status")]
        public NumberConfigStatus? Status { get; set; }

        [JsonProperty("t38_fax_gateway_enabled")]
        public bool T38FaxGatewayEnabled { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
