namespace Telnyx.net.Entities.Connections.CredentialConnections
{
    using Newtonsoft.Json;

    public class CredentialConnection : ConnectionBase
    {
        /// <summary>
        /// The user name to be used as part of the credentials. Must be 4-32 characters long and alphanumeric values only (no spaces or special characters).
        /// </summary>
        [JsonProperty("user_name")]
        public string UserName { get; set; }

        /// <summary>
        /// This feature enables inbound SIP URI calls to your Credential Auth Connection. If enabled for all (unrestricted) then anyone who calls the SIP URI @telnyx.com will be connected to your Connection. You can also choose to allow only calls that are originated on any Connections under your account (internal).
        /// Options: [ "disabled","unrestricted","internal ].
        /// </summary>
        [JsonProperty("sip_uri_calling_preference")]
        public string SipUriCallingPreference { get; set; }

        [JsonProperty("outbound")]
        public Outbound Outbound { get; set; }

        /// <summary>
        /// The password to be used as part of the credentials. Must be 8 to 128 characters long.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
