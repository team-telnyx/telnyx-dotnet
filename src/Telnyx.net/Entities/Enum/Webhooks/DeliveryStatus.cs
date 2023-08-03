namespace Telnyx.net.Entities.Enum.Webhooks
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Telnyx.net.Infrastructure.JsonConverters;

    [JsonConverter(typeof(SafeStringEnumConverter), Unknown)]
    /// <summary>
    /// The Telnyx Messaging Services will attempt to notify you about each status update based on the hierarchy of URLs using the following statuses.
    /// </summary>
    public enum DeliveryStatus
    {
        Unknown = -1,

        /// <summary>
        /// The message is queued up on Telnyx's side.
        /// </summary>
        [EnumMember(Value = "queued")]
        Queued = 0,

        /// <summary>
        /// The message is currently being sent to an upstream provider.
        /// </summary>
        [EnumMember(Value = "sending")]
        Sending = 1,

        /// <summary>
        /// The message has been sent to the upstream provider.
        /// </summary>
        [EnumMember(Value = "sent")]
        Sent = 2,

        /// <summary>
        /// The upstream provider has confirmed delivery of the message.
        /// </summary>
        [EnumMember(Value = "delivered")]
        Delivered = 3,

        /// <summary>
        /// Telnyx has failed to send the message to the upstream provider. Please reach out to our support if you have received this status.
        /// </summary>
        [EnumMember(Value = "sending_failed")]
        SendingFailed = 4,

        /// <summary>
        /// The upstream provider has failed to send the message to the receiver. Please reach out to our support if you have received this status.
        /// </summary>
        [EnumMember(Value = "delivery_failed")]
        DeliveryFailed = 5,

        /// <summary>
        /// There is no indication whether or not the message has reached the receiver. Please reach out to our support if you have received this status
        /// </summary>
        [EnumMember(Value = "delivery_unconfirmed")]
        DeliveryUnconfirmed = 6,

        /// <summary>
        /// Media sent has been processed.
        /// </summary>
        [EnumMember(Value = "media.processed")]
        MediaProcessed = 7,
    }
}
