using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum;
using Telnyx.net.Entities.Enum.Connections;

namespace Telnyx.net.Entities.Connections
{
    public partial class ConnectionBase : TelnyxEntity, IHasId
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("anchorsite_override")]
        public AnchorsiteOverride? AnchorsiteOverride { get; set; }

        [JsonProperty("connection_name")]
        public string ConnectionName { get; set; }

        [JsonProperty("created_at")]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.DateTimeConverterBase))]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("default_on_hold_comfort_noise_enabled")]
        public bool DefaultOnHoldComfortNoiseEnabled { get; set; }

        [JsonProperty("dtmf_type")]
        public DTMFType? DtmfType { get; set; }

        [JsonProperty("encode_contact_header_enabled")]
        public bool EncodeContactHeaderEnabled { get; set; }

        [JsonProperty("encrypted_media")]
        public EncryptedMedia? EncryptedMedia { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("inbound")]
        public Inbound Inbound { get; set; }

        [JsonProperty("onnet_t38_passthrough_enabled")]
        public bool OnnetT38PassthroughEnabled { get; set; }

        [JsonProperty("outbound")]
        public Outbound Outbound { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("rtcp_settings")]
        public RtcpSettings RtcpSettings { get; set; }

        [JsonProperty("sip_uri_calling_preference")]
        public string SipUriCallingPreference { get; set; }

        [JsonProperty("updated_at")]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.DateTimeConverterBase))]

        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }
    }

    public partial class Inbound
    {
        [JsonProperty("ani_number_format")]
        public string AniNumberFormat { get; set; }

        [JsonProperty("channel_limit")]
        public int ChannelLimit { get; set; }

        [JsonProperty("codecs")]
        public List<string> Codecs { get; set; }

        [JsonProperty("dnis_number_format")]
        public string DnisNumberFormat { get; set; }

        [JsonProperty("generate_ringback_tone")]
        public bool GenerateRingbackTone { get; set; }

        [JsonProperty("isup_headers_enabled")]
        public bool IsupHeadersEnabled { get; set; }

        [JsonProperty("prack_enabled")]
        public bool PrackEnabled { get; set; }

        [JsonProperty("privacy_zone_enabled")]
        public bool PrivacyZoneEnabled { get; set; }

        [JsonProperty("sip_compact_headers_enabled")]
        public bool SipCompactHeadersEnabled { get; set; }

        [JsonProperty("timeout_1xx_secs")]
        public string Timeout1XxSecs { get; set; }

        [JsonProperty("timeout_2xx_secs")]
        public string Timeout2XxSecs { get; set; }
    }

    public partial class Outbound
    {
        [JsonProperty("ani_override")]
        public string AniOverride { get; set; }

        [JsonProperty("ani_override_type")]
        public string AniOverrideType { get; set; }

        [JsonProperty("call_parking_enabled")]
        public bool CallParkingEnabled { get; set; }

        [JsonProperty("channel_limit")]
        public int ChannelLimit { get; set; }

        [JsonProperty("generate_ringback_tone")]
        public bool GenerateRingbackTone { get; set; }

        [JsonProperty("instant_ringback_enabled")]
        public bool InstantRingbackEnabled { get; set; }

        [JsonProperty("localization")]
        public string Localization { get; set; }

        [JsonProperty("outbound_voice_profile_id")]
        public string OutboundVoiceProfileId { get; set; }

        [JsonProperty("t38_reinvite_source")]
        public string T38ReinviteSource { get; set; }
    }

    public partial class RtcpSettings
    {
        [JsonProperty("port")]
        public string Port { get; set; }

        [JsonProperty("report_enabled")]
        public bool ReportEnabled { get; set; }

        [JsonProperty("report_frequency_seconds")]
        public int ReportFrequencySeconds { get; set; }
    }
}
