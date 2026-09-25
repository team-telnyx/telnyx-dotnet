using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallMachinePremiumGreetingEndedWebhookEvent, CallMachinePremiumGreetingEndedWebhookEventFromRaw>))]
public sealed record class CallMachinePremiumGreetingEndedWebhookEvent : JsonModel
{
    public CallMachinePremiumGreetingEnded? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallMachinePremiumGreetingEnded>(
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

    public CallMachinePremiumGreetingEndedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallMachinePremiumGreetingEndedWebhookEvent (
        CallMachinePremiumGreetingEndedWebhookEvent callMachinePremiumGreetingEndedWebhookEvent
    ) : base(callMachinePremiumGreetingEndedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallMachinePremiumGreetingEndedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallMachinePremiumGreetingEndedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallMachinePremiumGreetingEndedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallMachinePremiumGreetingEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallMachinePremiumGreetingEndedWebhookEventFromRaw : IFromRawJson<CallMachinePremiumGreetingEndedWebhookEvent>
{
    /// <inheritdoc/>
    public CallMachinePremiumGreetingEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallMachinePremiumGreetingEndedWebhookEvent.FromRawUnchecked(rawData);
}