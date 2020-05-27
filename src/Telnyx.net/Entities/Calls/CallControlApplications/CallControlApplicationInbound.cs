namespace Telnyx.net.Entities.Calls.CallControlApplications
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    public class CallControlApplicationInbound
    {
        /// <summary>
        /// When set, this will limit the total number of inbound calls to phone numbers associated with this connection.
        /// </summary>
        /// <value>When set, this will limit the total number of inbound calls to phone numbers associated with this connection.</value>
        [JsonProperty("channel_limit")]
        public int? ChannelLimit { get; set; }

        /// <summary>
        /// Specifies a subdomain that can be used to receive Inbound calls to a Connection, in the same way a phone number is used, from a SIP endpoint. Example: the subdomain \&quot;example.sip.telnyx.com\&quot; can be called from any SIP endpoint by using the SIP URI \&quot;sip:@example.sip.telnyx.com\&quot; where the user part can be any alphanumeric value. Please note TLS encrypted calls are not allowed for subdomain calls.
        /// </summary>
        /// <value>Specifies a subdomain that can be used to receive Inbound calls to a Connection, in the same way a phone number is used, from a SIP endpoint. Example: the subdomain \&quot;example.sip.telnyx.com\&quot; can be called from any SIP endpoint by using the SIP URI \&quot;sip:@example.sip.telnyx.com\&quot; where the user part can be any alphanumeric value. Please note TLS encrypted calls are not allowed for subdomain calls.</value>
        [JsonProperty("sip_subdomain")]
        public string SipSubdomain { get; set; }

        /// <summary>
        /// This option can be enabled to receive calls from: \"Anyone\" (any SIP endpoint in the public Internet) or \"Only my connections\" (any connection assigned to the same Telnyx user).
        /// </summary>
        /// <value>This option can be enabled to receive calls from: \"Anyone\" (any SIP endpoint in the public Internet) or \"Only my connections\" (any connection assigned to the same Telnyx user).</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum SipSubdomainReceiveSettingsEnum
        {
            /// <summary>
            /// Enum OnlyMyConnectionsEnum for only_my_connections
            /// </summary>
            [EnumMember(Value = "only_my_connections")]
            OnlyMyConnectionsEnum = 0,

            /// <summary>
            /// Enum FromAnyoneEnum for from_anyone
            /// </summary>
            [EnumMember(Value = "from_anyone")]
            FromAnyoneEnum = 1,        }

        /// <summary>
        /// This option can be enabled to receive calls from: \&quot;Anyone\&quot; (any SIP endpoint in the public Internet) or \&quot;Only my connections\&quot; (any connection assigned to the same Telnyx user).
        /// </summary>
        /// <value>This option can be enabled to receive calls from: \&quot;Anyone\&quot; (any SIP endpoint in the public Internet) or \&quot;Only my connections\&quot; (any connection assigned to the same Telnyx user).</value>
        [JsonProperty("sip_subdomain_receive_settings")]
        public SipSubdomainReceiveSettingsEnum? SipSubdomainReceiveSettings { get; set; }
    }
}
