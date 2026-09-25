using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallGatherEndedWebhookEvent, CallGatherEndedWebhookEventFromRaw>))]
public sealed record class CallGatherEndedWebhookEvent : JsonModel
{
    public CallGatherEnded? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallGatherEnded>(
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

    public CallGatherEndedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallGatherEndedWebhookEvent (
        CallGatherEndedWebhookEvent callGatherEndedWebhookEvent
    ) : base(callGatherEndedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallGatherEndedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallGatherEndedWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallGatherEndedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallGatherEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallGatherEndedWebhookEventFromRaw : IFromRawJson<CallGatherEndedWebhookEvent>
{
    /// <inheritdoc/>
    public CallGatherEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallGatherEndedWebhookEvent.FromRawUnchecked(rawData);
}