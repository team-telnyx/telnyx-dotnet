using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Messaging.Messaging_URL_Domains
{
    public class MessagingURLDomain : TelnyxEntity
    {
        [JsonProperty("messaging_url_domains")]
        public List<string> MessagingURLDomains { get; set; }
    }
}
