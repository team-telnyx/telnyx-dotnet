using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallReferCompletedWebhookEvent, CallReferCompletedWebhookEventFromRaw>))]
public sealed record class CallReferCompletedWebhookEvent : JsonModel
{
    public CallReferCompleted? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallReferCompleted>(
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

    public CallReferCompletedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallReferCompletedWebhookEvent (
        CallReferCompletedWebhookEvent callReferCompletedWebhookEvent
    ) : base(callReferCompletedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallReferCompletedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallReferCompletedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallReferCompletedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallReferCompletedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallReferCompletedWebhookEventFromRaw : IFromRawJson<CallReferCompletedWebhookEvent>
{
    /// <inheritdoc/>
    public CallReferCompletedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallReferCompletedWebhookEvent.FromRawUnchecked(rawData);
}