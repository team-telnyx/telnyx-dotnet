using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallDtmfReceivedWebhookEvent, CallDtmfReceivedWebhookEventFromRaw>))]
public sealed record class CallDtmfReceivedWebhookEvent : JsonModel
{
    public CallDtmfReceived? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallDtmfReceived>(
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

    public CallDtmfReceivedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallDtmfReceivedWebhookEvent (
        CallDtmfReceivedWebhookEvent callDtmfReceivedWebhookEvent
    ) : base(callDtmfReceivedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallDtmfReceivedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallDtmfReceivedWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallDtmfReceivedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallDtmfReceivedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallDtmfReceivedWebhookEventFromRaw : IFromRawJson<CallDtmfReceivedWebhookEvent>
{
    /// <inheritdoc/>
    public CallDtmfReceivedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallDtmfReceivedWebhookEvent.FromRawUnchecked(rawData);
}