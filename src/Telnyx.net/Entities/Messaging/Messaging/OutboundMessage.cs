namespace Telnyx
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Telnyx.Infrastructure;
    using Telnyx.net.Entities.Enum;
    using Telnyx.net.Entities.Messaging.Messaging;

    /// <summary>
    /// Outbound message.
    /// </summary>
    public class OutboundMessage : MessageWebhook, IHasId
    {
        /// <summary>
        /// Gets or sets sending address (+E.164 formatted phone number, alphanumeric sender, or short code).
        /// </summary>
        [JsonProperty("from")]
        public new OutboundMessageFrom From { get; set; }

        /// <summary>
        /// Gets or sets To.
        /// </summary>
        [JsonProperty("to")]
        public new List<OutboundMessageTo> To { get; set; }

        /// <summary>
        /// Gets or sets Media.
        /// </summary>
        [JsonProperty("media")]
        public new List<OutboundMessageMedia> Media { get; set; }
        /// <summary>
        /// Gets or sets Cost.
        /// </summary>
        [JsonProperty("cost")]
        public new OutboundMessageCost Cost { get; set; }
        /// <inheritdoc/>
        string IHasId.Id
        {
            get => this.Id.ToString();
            set => Guid.Parse(value);
        }
    }
}
