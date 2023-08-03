namespace Telnyx.net.Entities.Messaging.Messaging_URL_Domains
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MessagingURLDomain : TelnyxEntity
    {
        [JsonProperty("messaging_url_domains")]
        public List<string> MessagingURLDomains { get; set; }
    }
}
