namespace Telnyx.net.Entities.Enum
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Telnyx.net.Infrastructure.JsonConverters;

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    /// <value>Type of the resource.</value>
    [JsonConverter(typeof(SafeStringEnumConverter), Unknown)]
    public enum RecordType
    {
        Unknown = -1,
        [EnumMember(Value = "ip_connection")]
        IPConnection = 0,
        [EnumMember(Value = "call")]
        Call = 1,

        /// <summary>
        /// Enum NumberEnum for available_phone_number
        /// </summary>
        [EnumMember(Value = "available_phone_number")]
        NumberEnum = 2,

        /// <summary>
        /// Enum MessageEnum for message
        /// </summary>
        [EnumMember(Value = "message")]
        MessageEnum = 3,

        /// <summary>
        /// Enum NumberEnum for messaging_phone_number
        /// </summary>
        [EnumMember(Value = "messaging_phone_number")]
        MessagingPhoneNumberEnum = 4,

        /// <summary>
        /// Enum ProfileEnum for messaging_profile
        /// </summary>
        [EnumMember(Value = "messaging_profile")]
        ProfileEnum = 5,

        /// <summary>
        /// Enum CodeEnum for short_code
        /// </summary>
        [EnumMember(Value = "short_code")]
        CodeEnum = 6,

        [EnumMember(Value = "credential_connection")]
        CredentialConnection = 7,

        [EnumMember(Value = "fqdn_connection")]
        FQDNConnection = 8,

        [EnumMember(Value = "messaging_profile_metrics")]
        MessagingProfileMetrics = 9,

        [EnumMember(Value = "event")]
        Event = 10,

        [EnumMember(Value = "inbound_channels")]
        InboundChannels = 11,

        [EnumMember(Value = "address")]
        Address = 12,

        [EnumMember(Value = "call_control_application")]
        CallControlApplication = 13,

        [EnumMember(Value = "call_event")]
        CallEvent = 13,

        [EnumMember(Value = "ota_update")]
        OtaUpdate = 14,

        [EnumMember(Value = "conference")]
        Conference = 15,

        [EnumMember(Value = "csv_download")]
        CsvDownload = 16,

        [EnumMember(Value = "fqdn")]
        Fqdn = 17,

        [EnumMember(Value = "fax")]
        Fax = 18,

        [EnumMember(Value = "mdr_report")]
        MdrReport = 20,

        [EnumMember(Value = "mdr_usage_report")]
        MdrUsageReport = 21,

        [EnumMember(Value = "messaging_hosted_number_order")]
        MessagingHostedNumberOrder = 22,

        [EnumMember(Value = "messaging_settings")]
        MessagingSettings = 24,

        [EnumMember(Value = "messaging_url_domain")]
        MessagingUrlDomain = 25,

        [EnumMember(Value = "mobile_operator_networks")]
        MobileOperatorNetworks = 26,

        [EnumMember(Value = "number_lookup")]
        NumberLookup = 27,

        [EnumMember(Value = "number_order")]
        NumberOrder = 28,

        [EnumMember(Value = "number_order_phone_number")]
        NumberOrderPhoneNumber = 29,

        [EnumMember(Value = "phone_number_regulatory_requirement")]
        PhoneNumberRegulatoryRequirement = 30,

        [EnumMember(Value = "number_order_document")]
        NumberOrderDocument = 31,

        [EnumMember(Value = "number_reservation")]
        NumberReservation = 32,

        [EnumMember(Value = "reserved_phone_number")]
        ReservedPhoneNumber = 33,

        [EnumMember(Value = "outbount_voice_profile")]
        OutboundVoiceProfile = 34,

        [EnumMember(Value = "participant")]
        Participant = 35,

        [EnumMember(Value = "phone_number")]
        PhoneNumber = 36,

        [EnumMember(Value = "voice_settings")]
        VoiceSettings = 37,

        [EnumMember(Value = "portability_check_result")]
        PortabilityCheckResult = 38,

        [EnumMember(Value = "portout")]
        Portout = 39,

        [EnumMember(Value = "Recording")]
        Recording = 40,

        [EnumMember(Value = "regulatory_requirement")]
        RegulatoryRequirement = 41,

        [EnumMember(Value = "phone_number_regulatory_requirement_criteria")]
        PhoneNumberRegulatoryRequirementCriteria = 42,

        [EnumMember(Value = "link_clicked")]
        LinkClicked = 43,

        [EnumMember(Value = "sim_card")]
        SimCard = 44,

        [EnumMember(Value = "sim_card_group")]
        SimCardGroup = 45,

        [EnumMember(Value = "sim_card_network_preference")]
        SimCardNetworkPreference = 46,

        [EnumMember(Value = "short_code_info_blob")]
        ShortCodeInfoBlob = 47,

        [EnumMember(Value = "credential")]
        Credential = 48,

        [EnumMember(Value = "texml_application")]
        TexmlApplication = 49,

        [EnumMember(Value = "balance")]
        Balance = 50,

        [EnumMember(Value = "detail_records_report")]
        DetailRecordReport = 51,

        [EnumMember(Value = "messaging_hosted_number")]
        MessagingHostedNumber = 52,

        [EnumMember(Value = "ip")]
        IP = 54,

        [EnumMember(Value = "ledger_billing_group_report")]
        LedgerBillingGroupReport = 53,

        [EnumMember(Value = "billing_group")]
        BillingGroup = 54,

        [EnumMember(Value = "verify_profile")]
        VerifyProfile = 55,

        [EnumMember(Value = "verification")]
        Verification = 56,

        [EnumMember(Value = "fax_application")]
        FaxApplication = 57,
    }
}
