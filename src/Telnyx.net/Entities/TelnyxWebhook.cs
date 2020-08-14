﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum;
using Telnyx.net.Entities.Enum.Webhooks;

namespace Telnyx.net.Entities
{
    /// <summary>
    /// POCO Representing an incoming webhook.
    /// </summary>
    /// <typeparam name="T">The type of Telynx Entity the webhook is for. Can define own type if type is not available in SDK.</typeparam>
    public class TelnyxWebhook<T>
    {
        [JsonProperty("data")]
        public WebhookData<T> Data { get; set; }

        [JsonProperty("meta")]
        public WebhookMeta Meta { get; set; }
    }
    /// <summary>
    /// POCO Representing an incoming webhook's payload.
    /// </summary>
    /// <typeparam name="T">The type of Telynx Entity the webhook is for. Can define own type if type is not available in SDK.</typeparam>
    public class WebhookData<T>
    {
        [JsonProperty("event_type")]
        public EventTypes? EventType { get; set; }

        [JsonProperty("id")]
        public Guid? Id { get; set; }

        [JsonProperty("occurred_at")]
        public DateTimeOffset OccurredAt { get; set; }

        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        [JsonProperty("payload")]
        public T Payload { get; set; }
    }

    /// <summary>
    /// Metadata provided by the webhook.
    /// </summary>
    public class WebhookMeta
    {
        [JsonProperty("attempt")]
        public long Attempt { get; set; }

        [JsonProperty("delivered_to")]
        public string DeliveredTo { get; set; }
    }
}