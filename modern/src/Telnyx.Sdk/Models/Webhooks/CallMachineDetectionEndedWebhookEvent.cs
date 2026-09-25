using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallMachineDetectionEndedWebhookEvent, CallMachineDetectionEndedWebhookEventFromRaw>))]
public sealed record class CallMachineDetectionEndedWebhookEvent : JsonModel
{
    public CallMachineDetectionEnded? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallMachineDetectionEnded>(
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

    public CallMachineDetectionEndedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallMachineDetectionEndedWebhookEvent (
        CallMachineDetectionEndedWebhookEvent callMachineDetectionEndedWebhookEvent
    ) : base(callMachineDetectionEndedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallMachineDetectionEndedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallMachineDetectionEndedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallMachineDetectionEndedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallMachineDetectionEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallMachineDetectionEndedWebhookEventFromRaw : IFromRawJson<CallMachineDetectionEndedWebhookEvent>
{
    /// <inheritdoc/>
    public CallMachineDetectionEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallMachineDetectionEndedWebhookEvent.FromRawUnchecked(rawData);
}