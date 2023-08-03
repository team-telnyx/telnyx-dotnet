namespace Telnyx.net.Services.Connections.CredentialConnections
{
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Connections;

    public class UpsertCredentialConnectionOptions : UpsertConnectionOptions
    {
        /// <summary>
        /// This feature enables inbound SIP URI calls to your Credential Auth Connection. If enabled for all (unrestricted) then anyone who calls the SIP URI @telnyx.com will be connected to your Connection. You can also choose to allow only calls that are originated on any Connections under your account (internal).
        /// Defailt: disabled.
        /// Options: ["disabled","unrestricted","internal"].
        /// </summary>
        [JsonProperty("sip_uri_calling_preference")]
        public string SipUriCallingPreference { get; set; } = "disabled";

        /// <summary>
        /// The user name to be used as part of the credentials. Must be 4-32 characters long and alphanumeric values only (no spaces or special characters).
        /// Example: myusername123.
        /// </summary>
        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("outbound")]
        public Outbound Outbound { get; set; }

        /// <summary>
        /// The password to be used as part of the credentials. Must be 8 to 128 characters long.
        /// Example: Sup3rS3cur3P@ssw0rd.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
