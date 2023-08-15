namespace Telnyx.net.Entities.Messaging.Messaging_Profiles
{
    using Newtonsoft.Json;

    public class UrlShortenerSettings
    {
        /// <summary>
        /// One of the domains provided by the Telnyx URL shortener service. Example: "acct.fyi".
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// Optional prefix that can be used to identify your brand, and will appear in the Telnyx generated URLs after the domain name.
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        /// <summary>
        /// Use the link replacement tool only for links that are specifically blacklisted by Telnyx.
        /// </summary>
        [JsonProperty("replace_blacklist_only")]
        public bool ReplaceBlackListOnly { get; set; }

        /// <summary>
        /// Receive webhooks for when your replaced links are clicked. Webhooks are sent to the webhooks on the messaging profile.
        /// </summary>
        [JsonProperty("send_webhooks")]
        public bool SendWebhooks { get; set; }
    }
}
