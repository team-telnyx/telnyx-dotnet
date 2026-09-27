using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallAIGatherEndedWebhookEvent, CallAIGatherEndedWebhookEventFromRaw>))]
public sealed record class CallAIGatherEndedWebhookEvent : JsonModel
{
    public CallAIGatherEnded? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallAIGatherEnded>(
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

    public CallAIGatherEndedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallAIGatherEndedWebhookEvent (
        CallAIGatherEndedWebhookEvent callAIGatherEndedWebhookEvent
    ) : base(callAIGatherEndedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallAIGatherEndedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallAIGatherEndedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallAIGatherEndedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallAIGatherEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallAIGatherEndedWebhookEventFromRaw : IFromRawJson<CallAIGatherEndedWebhookEvent>
{
    /// <inheritdoc/>
    public CallAIGatherEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallAIGatherEndedWebhookEvent.FromRawUnchecked(rawData);
}