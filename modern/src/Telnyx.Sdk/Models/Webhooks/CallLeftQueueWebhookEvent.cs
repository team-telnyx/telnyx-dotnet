using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallLeftQueueWebhookEvent, CallLeftQueueWebhookEventFromRaw>))]
public sealed record class CallLeftQueueWebhookEvent : JsonModel
{
    public CallLeftQueue? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallLeftQueue>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public CallLeftQueueWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallLeftQueueWebhookEvent (
        CallLeftQueueWebhookEvent callLeftQueueWebhookEvent
    ) : base(callLeftQueueWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallLeftQueueWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallLeftQueueWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallLeftQueueWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallLeftQueueWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallLeftQueueWebhookEventFromRaw : IFromRawJson<CallLeftQueueWebhookEvent>
{
    /// <inheritdoc/>
    public CallLeftQueueWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallLeftQueueWebhookEvent.FromRawUnchecked(rawData);
}