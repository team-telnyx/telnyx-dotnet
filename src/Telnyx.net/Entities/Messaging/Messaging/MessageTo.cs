using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum.Webhooks;

namespace Telnyx.net.Entities.Messaging.Messaging
{
    public class MessageTo
    {
        
        /// <summary>
        /// Gets or sets Address.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status")]
        public DeliveryStatus? Status { get; set; }

        /// <summary>
        /// Gets or sets ISO 8601 formatted date indicating when the resource was updated.
        /// </summary>
        /// <value>ISO 8601 formatted date indicating when the resource was updated.</value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
