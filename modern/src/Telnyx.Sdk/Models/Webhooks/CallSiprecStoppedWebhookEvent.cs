using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallSiprecStoppedWebhookEvent, CallSiprecStoppedWebhookEventFromRaw>))]
public sealed record class CallSiprecStoppedWebhookEvent : JsonModel
{
    public CallSiprecStopped? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallSiprecStopped>(
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

    public CallSiprecStoppedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallSiprecStoppedWebhookEvent (
        CallSiprecStoppedWebhookEvent callSiprecStoppedWebhookEvent
    ) : base(callSiprecStoppedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallSiprecStoppedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallSiprecStoppedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallSiprecStoppedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallSiprecStoppedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallSiprecStoppedWebhookEventFromRaw : IFromRawJson<CallSiprecStoppedWebhookEvent>
{
    /// <inheritdoc/>
    public CallSiprecStoppedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallSiprecStoppedWebhookEvent.FromRawUnchecked(rawData);
}