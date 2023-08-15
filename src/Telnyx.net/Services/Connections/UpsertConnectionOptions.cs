namespace Telnyx.net.Services.Connections
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Connections;
    using Telnyx.net.Entities.Enum;
    using Telnyx.net.Entities.Enum.Connections;

    public class UpsertConnectionOptions : BaseOptions
    {
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
        /// When enabled, Telnyx will generate comfort noise when you place the call on hold. If disabled, you will need to generate comfort noise or on hold music to avoid RTP timeout.
        /// </summary>
        [JsonProperty("default_on_hold_comfort_noise_enabled")]
        public bool DefaultOnHoldComfortNoiseEnabled { get; set; }

        /// <summary>
        /// Sets the type of DTMF digits sent from Telnyx to this Connection. Note that DTMF digits sent to Telnyx will be accepted in all formats.
        /// Defailt: "RFC 2833".
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

        [JsonProperty("inbound")]
        public Inbound Inbound { get; set; }

        /// <summary>
        /// Enable on-net T38 if you prefer the sender and receiver negotiating T38 directly if both are on the Telnyx network. If this is disabled, Telnyx will be able to use T38 on just one leg of the call depending on each leg's settings.
        /// </summary>
        [JsonProperty("onnet_t38_passthrough_enabled")]
        public bool OnnetT38PassthroughEnabled { get; set; }

        [JsonProperty("rtcp_settings")]
        public RtcpSettings RtcpSettings { get; set; }
    }
}
