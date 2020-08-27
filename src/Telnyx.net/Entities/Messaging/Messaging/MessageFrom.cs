using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum.Messaging;

namespace Telnyx.net.Entities.Messaging.Messaging
{
    public class MessageFrom
    {
        /// <summary>
        /// Gets or sets the carrier of the receiver.
        /// </summary>
        /// <value>The carrier of the receiver.</value>
        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        /// <summary>
        /// Gets or sets the line-type of the receiver.
        /// </summary>
        /// <value>The line-type of the receiver.</value>
        [JsonProperty("line_type")]
        public LineTypeEnum? LineType { get; set; }

        /// <summary>
        /// Gets or sets the phonenumber of the sender.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
