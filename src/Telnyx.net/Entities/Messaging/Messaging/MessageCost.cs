using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Messaging.Messaging
{
    public class MessageCost
    {
        /// <summary>
        /// Gets or sets the amount deducted from your account.
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Gets or sets the ISO 4217 currency identifier.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
