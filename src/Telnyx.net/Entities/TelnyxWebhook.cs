namespace Telnyx.net.Entities
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;
    using Telnyx.net.Entities.Enum.Webhooks;

    /// <summary>
    /// POCO Representing an incoming webhook.
    /// </summary>
    /// <typeparam name="T">The type of Telynx Entity the webhook is for. Can define own type if type is not available in SDK.</typeparam>
    [ExcludeFromCodeCoverage] // Only used by Telnyx.Example project which is out of scope of test coverage.
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
    [ExcludeFromCodeCoverage] // Only used by Telnyx.Example project which is out of scope of test coverage.
    public class WebhookData<T>
    {
        [JsonProperty("event_type")]
        public EventType? EventType { get; set; }

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
    [ExcludeFromCodeCoverage] // Only used by Telnyx.Example project which is out of scope of test coverage.
    public class WebhookMeta
    {
        [JsonProperty("attempt")]
        public long Attempt { get; set; }

        [JsonProperty("delivered_to")]
        public string DeliveredTo { get; set; }
    }
}
