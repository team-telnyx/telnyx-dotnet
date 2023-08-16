namespace Telnyx.net.Entities.Connections
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;
    using Telnyx.net.Entities.Enum.Connections;
    using Telnyx.net.Infrastructure.JsonConverters;

    public partial class ConnectionBase : TelnyxEntity, IHasId
    {
        /// <summary>
        /// Defaults to true.
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; } = true;

        /// <summary>
        /// `Latency` directs Telnyx to route media through the site with the lowest round-trip time to the user's connection. Telnyx calculates this time using ICMP ping messages. This can be disabled by specifying a site to handle all media.
        /// </summary>
        [JsonProperty("anchorsite_override")]
        public AnchorsiteOverride? AnchorsiteOverride { get; set; }

        [JsonProperty("connection_name")]
        public string ConnectionName { get; set; }

        /// <summary>
        /// ISO-8601 formatted date indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// When enabled, Telnyx will generate comfort noise when you place the call on hold. If disabled, you will need to generate comfort noise or on hold music to avoid RTP timeout.
        /// </summary>
        [JsonProperty("default_on_hold_comfort_noise_enabled")]
        public bool DefaultOnHoldComfortNoiseEnabled { get; set; }

        /// <summary>
        /// Sets the type of DTMF digits sent from Telnyx to this Connection. Note that DTMF digits sent to Telnyx will be accepted in all formats
        /// Default RFC 2833.
        /// </summary>
        [JsonProperty("dtmf_type")]
        public DTMFType? DtmfType { get; set; } = DTMFType.RFC_2833;

        /// <summary>
        /// Encode the SIP contact header sent by Telnyx to avoid issues for NAT or ALG scenarios.
        /// </summary>
        [JsonProperty("encode_contact_header_enabled")]
        public bool EncodeContactHeaderEnabled { get; set; }

        /// <summary>
        /// Enable use of SRTP or ZRTP for encryption. Valid values are those listed or null. Cannot be set to non-null if the transport_portocol is TLS.
        /// </summary>
        [JsonProperty("encrypted_media")]
        public EncryptedMedia? EncryptedMedia { get; set; }

        /// <summary>
        /// Identifies the type of resource.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("inbound")]
        public Inbound Inbound { get; set; }

        /// <summary>
        /// Enable on-net T38 if you prefer the sender and receiver negotiating T38 directly if both are on the Telnyx network. If this is disabled, Telnyx will be able to use T38 on just one leg of the call depending on each leg's settings.
        /// </summary>
        [JsonProperty("onnet_t38_passthrough_enabled")]
        public bool OnnetT38PassthroughEnabled { get; set; }

        /// <summary>
        ///  Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        [JsonProperty("rtcp_settings")]
        public RtcpSettings RtcpSettings { get; set; }

        /// <summary>
        /// ISO-8601 formatted date indicating when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset? UpdatedAt { get; set; }
    }

    public partial class Inbound
    {
        /// <summary>
        /// This setting allows you to set the format with which the caller's number (ANI) is sent for inbound phone calls.
        /// </summary>
        [JsonProperty("ani_number_format")]
        public string AniNumberFormat { get; set; }

        /// <summary>
        /// When set, this will limit the total number of inbound calls to phone numbers associated with this connection.
        /// Default: null.
        /// </summary>
        [JsonProperty("channel_limit")]
        public int? ChannelLimit { get; set; }

        /// <summary>
        /// Defines the list of codecs that Telnyx will send for inbound calls to a specific number on your portal account, in priority order. This only works when the Connection the number is assigned to uses Media Handling mode: default. OPUS and H.264 codecs are available only when using TCP or TLS transport for SIP.
        /// Default: ["G722","G711U","G711A","G729","OPUS","H.264"].
        /// </summary>
        [JsonProperty("codecs")]
        public List<string> Codecs { get; set; }

        /// <summary>
        /// Default: "e164".
        /// Options: ["+e164","e164","national"].
        /// </summary>
        [JsonProperty("dnis_number_format")]
        public string DnisNumberFormat { get; set; }

        /// <summary>
        /// Generate ringback tone through 183 session progress message with early media.
        /// </summary>
        [JsonProperty("generate_ringback_tone")]
        public bool GenerateRingbackTone { get; set; }

        /// <summary>
        /// When set, inbound phone calls will receive ISUP parameters via SIP headers. (Only when available and only when using TCP or TLS transport.)
        /// Default: false.
        /// </summary>
        [JsonProperty("isup_headers_enabled")]
        public bool IsupHeadersEnabled { get; set; }

        /// <summary>
        /// Enable PRACK messages as defined in RFC3262.
        /// </summary>
        [JsonProperty("prack_enabled")]
        public bool PrackEnabled { get; set; }

        /// <summary>
        /// By default, Telnyx does not send caller-id information when the caller has chosen to hide this information. When this option is enabled, Telnyx will send the SIP header Privacy:id plus the caller-id information so that the receiver side can choose when to hide it.
        /// </summary>
        [JsonProperty("privacy_zone_enabled")]
        public bool PrivacyZoneEnabled { get; set; }

        /// <summary>
        /// Defaults to true;.
        /// </summary>
        [JsonProperty("sip_compact_headers_enabled")]
        public bool SipCompactHeadersEnabled { get; set; } = true;

        /// <summary>
        /// Time(sec) before aborting if connection is not made (min: 1, max: 20). Default: "3".
        /// </summary>
        [JsonProperty("timeout_1xx_secs")]
        public int? Timeout1XxSecs { get; set; } = 3;

        /// <summary>
        /// Time(sec) before aborting if call is unanswered (min: 1, max: 600). Default: "90".
        /// </summary>
        [JsonProperty("timeout_2xx_secs")]
        public int? Timeout2XxSecs { get; set; } = 90;
    }

    public partial class Outbound
    {
        /// <summary>
        /// Set a phone number as the ani_override value to override caller id number on outbound calls.
        /// Default = "".
        /// </summary>
        [JsonProperty("ani_override")]
        public string AniOverride { get; set; } = "";

        /// <summary>
        /// Specifies when we apply your ani_override setting. Only applies when ani_override is not blank.
        /// Default: always.
        /// </summary>
        [JsonProperty("ani_override_type")]
        public AniOverrideType AniOverrideType { get; set; } = AniOverrideType.Always;

        /// <summary>
        /// Forces all SIP calls originated on this connection to be "parked" instead of "bridged" to the destination specified on the URI. 
        /// Parked calls will return ringback to the caller and will await for a Call Control command to define which action will be taken next.
        /// </summary>
        [JsonProperty("call_parking_enabled")]
        public bool? CallParkingEnabled { get; set; }

        /// <summary>
        /// When set, this will limit the total number of outbound calls to phone numbers associated with this connection.
        /// Default: null.
        /// </summary>
        [JsonProperty("channel_limit")]
        public int? ChannelLimit { get; set; }

        /// <summary>
        /// Generate ringback tone through 183 session progress message with early media.
        /// </summary>
        [JsonProperty("generate_ringback_tone")]
        public bool? GenerateRingbackTone { get; set; }

        /// <summary>
        /// When set, ringback will not wait for indication before sending ringback tone to calling party.
        /// </summary>
        [JsonProperty("instant_ringback_enabled")]
        public bool? InstantRingbackEnabled { get; set; } = true;

        /// <summary>
        /// A 2-character country code specifying the country whose national dialing rules should be used. 
        /// For example, if set to `US` then any US number can be dialed without preprending +1 to the number. 
        /// When left blank, Telnyx will try US and GB dialing rules, in that order, by default.
        /// Default : null.
        /// </summary>
        [JsonProperty("localization")]
        public string Localization { get; set; }

        /// <summary>
        /// Identifies the associated outbound voice profile.
        /// </summary>
        [JsonProperty("outbound_voice_profile_id")]
        public string OutboundVoiceProfileId { get; set; }

        /// <summary>
        /// This setting only affects connections with Fax-type Outbound Voice Profiles. The setting dictates whether or not Telnyx sends a t.38 reinvite
        /// By default, Telnyx will send the re-invite. If set to `customer`, the caller is expected to send the t.38 reinvite.
        /// Default: telnyx.
        /// Options: ["telnyx","customer","disabled","passthru","caller-passthru","callee-passthru"].
        /// </summary>
        [JsonProperty("t38_reinvite_source")]
        public string T38ReinviteSource { get; set; } = "telnyx";
    }

    public partial class RtcpSettings
    {
        /// <summary>
        /// RTCP port by default is rtp+1, it can also be set to rtcp-mux
        /// Default: "rtp+1".
        /// </summary>
        [JsonProperty("port")]
        public string Port { get; set; } = "rtp+1";

        /// <summary>
        /// DEPRECATED - RTCP reports are always sent to customers/vendors. For backwards compatibility, the value is always true.
        /// </summary>
        [JsonProperty("report_enabled")]
        [Obsolete]
        public bool? ReportEnabled { get; set; } = true;

        /// <summary>
        /// RTCP reports are sent to customers based on the frequency set. Frequency is in seconds and it can be set to values from 5 to 3000 seconds.
        /// Default: 10.
        /// </summary>
        [JsonProperty("report_frequency_seconds")]
        public int? ReportFrequencySeconds { get; set; } = 10;
    }
}
