using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallSpeakStartedWebhookEvent, CallSpeakStartedWebhookEventFromRaw>))]
public sealed record class CallSpeakStartedWebhookEvent : JsonModel
{
    public CallSpeakStarted? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallSpeakStarted>(
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

    public CallSpeakStartedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallSpeakStartedWebhookEvent (
        CallSpeakStartedWebhookEvent callSpeakStartedWebhookEvent
    ) : base(callSpeakStartedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallSpeakStartedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallSpeakStartedWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallSpeakStartedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallSpeakStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallSpeakStartedWebhookEventFromRaw : IFromRawJson<CallSpeakStartedWebhookEvent>
{
    /// <inheritdoc/>
    public CallSpeakStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallSpeakStartedWebhookEvent.FromRawUnchecked(rawData);
}