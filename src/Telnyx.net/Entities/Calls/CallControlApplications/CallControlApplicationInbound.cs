namespace Telnyx.net.Entities.Calls.CallControlApplications
{
    using Newtonsoft.Json;

    public class CallControlApplicationInbound
    {
        /// <summary>
        /// When set, this will limit the total number of inbound calls to phone numbers associated with this connection.
        /// </summary>
        [JsonProperty("channel_limit")]
        public int? ChannelLimit { get; set; }

        /// <summary>
        /// Specifies a subdomain that can be used to receive Inbound calls to a Connection, in the same way a phone number is used, from a SIP endpoint. Example: the subdomain \&quot;example.sip.telnyx.com\&quot; can be called from any SIP endpoint by using the SIP URI \&quot;sip:@example.sip.telnyx.com\&quot; where the user part can be any alphanumeric value. Please note TLS encrypted calls are not allowed for subdomain calls.
        /// </summary>
        [JsonProperty("sip_subdomain")]
        public string SipSubdomain { get; set; }

        /// <summary>
        /// This option can be enabled to receive calls from: \&quot;Anyone\&quot; (any SIP endpoint in the public Internet) or \&quot;Only my connections\&quot; (any connection assigned to the same Telnyx user).
        /// </summary>
        [JsonProperty("sip_subdomain_receive_settings")]
        public SipSubdomainReceiveSettings? SipSubdomainReceiveSettings { get; set; }
    }
}
