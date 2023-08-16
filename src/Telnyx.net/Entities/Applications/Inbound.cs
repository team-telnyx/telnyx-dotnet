namespace Telnyx.net.Entities.Applications
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    public class Inbound
    {
        /// <summary>
        /// When set, this will limit the number of concurrent inbound calls to phone numbers associated with this connection.
        /// </summary>
        [JsonProperty("channel_limit")]
        public int? ChannelLimit { get; set; } = null;

        /// <summary>
        /// Specifies a subdomain that can be used to receive Inbound calls to a Connection, in the same way a phone number is used, from a SIP endpoint. Example: the subdomain "example.sip.telnyx.com" can be called from any SIP endpoint by using the SIP URI "sip:@example.sip.telnyx.com" where the user part can be any alphanumeric value. Please note TLS encrypted calls are not allowed for subdomain calls.
        /// </summary>
        [JsonProperty("sip_subdomain")]
        public string SipSubdomain { get; set; } = null;

        /// <summary>
        /// This option can be enabled to receive calls from: "Anyone" (any SIP endpoint in the public Internet) or "Only my connections" (any connection assigned to the same Telnyx user).
        /// </summary>
        [JsonProperty("sip_subdomain_receive_settings")]
        public SipSubdomainReceiveSettings SipSubdomainReceiveSettings { get; set; } = SipSubdomainReceiveSettings.FromAnyone;
    }
}
