namespace Telnyx
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Messaging.Messaging;

    /// <summary>
    /// Outbound Message To.
    /// </summary>
    [DataContract]
    public class OutboundMessageTo : MessageTo
    {
        /// <summary>
        /// Gets or sets status.
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum QueuedEnum for queued
            /// </summary>
            [EnumMember(Value = "queued")]
            QueuedEnum = 0,

            /// <summary>
            /// Enum SendingEnum for sending
            /// </summary>
            [EnumMember(Value = "sending")]
            SendingEnum = 1,

            /// <summary>
            /// Enum SentEnum for sent
            /// </summary>
            [EnumMember(Value = "sent")]
            SentEnum = 2,

            /// <summary>
            /// Enum DeliveredEnum for delivered
            /// </summary>
            [EnumMember(Value = "delivered")]
            DeliveredEnum = 3,

            /// <summary>
            /// Enum SendingFailedEnum for sending_failed
            /// </summary>
            [EnumMember(Value = "sending_failed")]
            SendingFailedEnum = 4,

            /// <summary>
            /// Enum DeliveryFailedEnum for delivery_failed
            /// </summary>
            [EnumMember(Value = "delivery_failed")]
            DeliveryFailedEnum = 5,

            /// <summary>
            /// Enum DeliveryUnconfirmedEnum for delivery_unconfirmed
            /// </summary>
            [EnumMember(Value = "delivery_unconfirmed")]
            DeliveryUnconfirmedEnum = 6
        }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [DataMember(Name = "status")]
        public new StatusEnum? Status { get; set; }
    }
}
