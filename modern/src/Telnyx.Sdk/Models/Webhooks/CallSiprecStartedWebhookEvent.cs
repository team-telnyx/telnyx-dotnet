using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallSiprecStartedWebhookEvent, CallSiprecStartedWebhookEventFromRaw>))]
public sealed record class CallSiprecStartedWebhookEvent : JsonModel
{
    public CallSiprecStarted? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallSiprecStarted>(
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

    public CallSiprecStartedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallSiprecStartedWebhookEvent (
        CallSiprecStartedWebhookEvent callSiprecStartedWebhookEvent
    ) : base(callSiprecStartedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallSiprecStartedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallSiprecStartedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallSiprecStartedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallSiprecStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallSiprecStartedWebhookEventFromRaw : IFromRawJson<CallSiprecStartedWebhookEvent>
{
    /// <inheritdoc/>
    public CallSiprecStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallSiprecStartedWebhookEvent.FromRawUnchecked(rawData);
}