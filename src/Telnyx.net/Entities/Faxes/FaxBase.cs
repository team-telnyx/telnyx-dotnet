namespace Telnyx.net.Entities.Faxes
{
    using System;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.Webhooks;

    public abstract class FaxBase : TelnyxEntity
    {
        /// <summary>
        /// The connection ID to send the fax with.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// The phone number, in E.164 format, the fax will be sent from.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Identifies the fax.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Status of the fax.
        /// </summary>
        [JsonProperty("status")]
        public DeliveryStatus Status { get; set; }

        /// <summary>
        /// The phone number, in E.164 format, the fax will be sent to or SIP URI.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }
    }
}
