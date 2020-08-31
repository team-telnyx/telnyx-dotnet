﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Infrastructure.JsonConverters;

namespace Telnyx.net.Entities.Enum.Webhooks
{
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
        /// Expired
        /// </summary>
        [EnumMember(Value = "expired")]
        Expired = 7,

        /// <summary>
        /// Webhook Delivered
        /// </summary>
        [EnumMember(Value = "webhook_delivered")]
        WebHookDelivered = 8,
    }
}
