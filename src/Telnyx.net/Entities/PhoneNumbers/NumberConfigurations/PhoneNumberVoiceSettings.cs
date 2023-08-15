namespace Telnyx.net.Entities.PhoneNumbers.NumberConfigurations
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public class PhoneNumberVoiceSettings : TelnyxEntity
    {
        [JsonProperty("call_forwarding")]
        public CallForwarding CallForwarding { get; set; }

        [JsonProperty("call_recording")]
        public CallRecording CallRecording { get; set; }

        [JsonProperty("cnam_listing")]
        public CnamListing CnamListing { get; set; }

        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        [JsonProperty("emergency")]
        public Emergency Emergency { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("media_features")]
        public MediaFeatures MediaFeatures { get; set; }

        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        [JsonProperty("tech_prefix_enabled")]
        public bool TechPrefixEnabled { get; set; }

        [JsonProperty("translated_number")]
        public string TranslatedNumber { get; set; }

        [JsonProperty("usage_payment_method")]
        public string UsagePaymentMethod { get; set; }
    }

    public partial class CallForwarding
    {
        [JsonProperty("call_forwarding_enabled")]
        public bool CallForwardingEnabled { get; set; }

        [JsonProperty("forwarding_type")]
        public string ForwardingType { get; set; }

        [JsonProperty("forwards_to")]
        public string ForwardsTo { get; set; }
    }

    public partial class CallRecording
    {
        [JsonProperty("inbound_call_recording_channels")]
        public string InboundCallRecordingChannels { get; set; }

        [JsonProperty("inbound_call_recording_enabled")]
        public bool InboundCallRecordingEnabled { get; set; }

        [JsonProperty("inbound_call_recording_format")]
        public string InboundCallRecordingFormat { get; set; }
    }

    public partial class CnamListing
    {
        [JsonProperty("cnam_listing_details")]
        public string CnamListingDetails { get; set; }

        [JsonProperty("cnam_listing_enabled")]
        public bool CnamListingEnabled { get; set; }
    }

    public partial class Emergency
    {
        [JsonProperty("emergency_address_id")]
        public string EmergencyAddressId { get; set; }

        [JsonProperty("emergency_enabled")]
        public bool EmergencyEnabled { get; set; }
    }

    public partial class MediaFeatures
    {
        [JsonProperty("accept_any_rtp_packets_enabled")]
        public bool AcceptAnyRtpPacketsEnabled { get; set; }

        [JsonProperty("media_handling_mode")]
        public string MediaHandlingMode { get; set; }

        [JsonProperty("rtp_auto_adjust_enabled")]
        public bool RtpAutoAdjustEnabled { get; set; }

        [JsonProperty("t38_fax_gateway_enabled")]
        public bool T38FaxGatewayEnabled { get; set; }
    }
}
