using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallMachineGreetingEndedWebhookEvent, CallMachineGreetingEndedWebhookEventFromRaw>))]
public sealed record class CallMachineGreetingEndedWebhookEvent : JsonModel
{
    public CallMachineGreetingEnded? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallMachineGreetingEnded>(
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

    public CallMachineGreetingEndedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallMachineGreetingEndedWebhookEvent (
        CallMachineGreetingEndedWebhookEvent callMachineGreetingEndedWebhookEvent
    ) : base(callMachineGreetingEndedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallMachineGreetingEndedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallMachineGreetingEndedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallMachineGreetingEndedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallMachineGreetingEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallMachineGreetingEndedWebhookEventFromRaw : IFromRawJson<CallMachineGreetingEndedWebhookEvent>
{
    /// <inheritdoc/>
    public CallMachineGreetingEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallMachineGreetingEndedWebhookEvent.FromRawUnchecked(rawData);
}