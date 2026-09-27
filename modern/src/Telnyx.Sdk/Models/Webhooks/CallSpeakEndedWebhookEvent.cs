using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallSpeakEndedWebhookEvent, CallSpeakEndedWebhookEventFromRaw>))]
public sealed record class CallSpeakEndedWebhookEvent : JsonModel
{
    public CallSpeakEnded? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallSpeakEnded>(
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

    public CallSpeakEndedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallSpeakEndedWebhookEvent (
        CallSpeakEndedWebhookEvent callSpeakEndedWebhookEvent
    ) : base(callSpeakEndedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallSpeakEndedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallSpeakEndedWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallSpeakEndedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallSpeakEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallSpeakEndedWebhookEventFromRaw : IFromRawJson<CallSpeakEndedWebhookEvent>
{
    /// <inheritdoc/>
    public CallSpeakEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallSpeakEndedWebhookEvent.FromRawUnchecked(rawData);
}