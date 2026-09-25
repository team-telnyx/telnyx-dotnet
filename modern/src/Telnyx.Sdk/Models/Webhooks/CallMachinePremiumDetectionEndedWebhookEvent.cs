using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallMachinePremiumDetectionEndedWebhookEvent, CallMachinePremiumDetectionEndedWebhookEventFromRaw>))]
public sealed record class CallMachinePremiumDetectionEndedWebhookEvent : JsonModel
{
    public CallMachinePremiumDetectionEnded? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallMachinePremiumDetectionEnded>(
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

    public CallMachinePremiumDetectionEndedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallMachinePremiumDetectionEndedWebhookEvent (
        CallMachinePremiumDetectionEndedWebhookEvent callMachinePremiumDetectionEndedWebhookEvent
    ) : base(callMachinePremiumDetectionEndedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallMachinePremiumDetectionEndedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallMachinePremiumDetectionEndedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallMachinePremiumDetectionEndedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallMachinePremiumDetectionEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallMachinePremiumDetectionEndedWebhookEventFromRaw : IFromRawJson<CallMachinePremiumDetectionEndedWebhookEvent>
{
    /// <inheritdoc/>
    public CallMachinePremiumDetectionEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallMachinePremiumDetectionEndedWebhookEvent.FromRawUnchecked(rawData);
}