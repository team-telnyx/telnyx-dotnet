using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum.Messaging;
using Telnyx.net.Entities.Enum.Webhooks;

namespace Telnyx.net.Entities.Messaging.Messaging
{
    public class MessageCC
    {
        /// <summary>
        /// Gets or sets Phone Number.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets Line Type.
        /// </summary>
        [JsonProperty("line_type")]
        public LineTypeEnum? LineType { get; set; }

        /// <summary>
        /// Gets or sets Carrier.
        /// </summary>
        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status")]
        public DeliveryStatus? Status { get; set; }

    }
}
