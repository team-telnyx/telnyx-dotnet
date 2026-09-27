using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallEnqueuedWebhookEvent, CallEnqueuedWebhookEventFromRaw>))]
public sealed record class CallEnqueuedWebhookEvent : JsonModel
{
    public CallEnqueued? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallEnqueued>(
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

    public CallEnqueuedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallEnqueuedWebhookEvent (
        CallEnqueuedWebhookEvent callEnqueuedWebhookEvent
    ) : base(callEnqueuedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallEnqueuedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallEnqueuedWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallEnqueuedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallEnqueuedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallEnqueuedWebhookEventFromRaw : IFromRawJson<CallEnqueuedWebhookEvent>
{
    /// <inheritdoc/>
    public CallEnqueuedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallEnqueuedWebhookEvent.FromRawUnchecked(rawData);
}