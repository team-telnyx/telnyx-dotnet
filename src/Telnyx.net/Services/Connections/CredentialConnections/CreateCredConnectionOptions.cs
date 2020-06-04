using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Connections;
using Telnyx.net.Entities.Connections.CredentialConnections;
using Telnyx.net.Entities.Enum;
using Telnyx.net.Entities.Enum.Connections;

namespace Telnyx.net.Services.Connections.CredentialConnections
{
    public class CreateCredConnectionOptions : BaseOptions
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("anchorsite_override")]
        public AnchorsiteOverride? AnchorsiteOverride { get; set; }

        [JsonProperty("connection_name")]
        public string ConnectionName { get; set; }

        [JsonProperty("default_on_hold_comfort_noise_enabled")]
        public bool DefaultOnHoldComfortNoiseEnabled { get; set; }

        [JsonProperty("dtmf_type")]
        public DTMFType? DtmfType { get; set; }

        [JsonProperty("encode_contact_header_enabled")]
        public bool EncodeContactHeaderEnabled { get; set; }

        [JsonProperty("encrypted_media")]
        public EncryptedMedia? EncryptedMedia { get; set; }

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

        [JsonProperty("user_name")]
        public string UserName { get; set; }
    }
}
