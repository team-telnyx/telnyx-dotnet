using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallReferFailedWebhookEvent, CallReferFailedWebhookEventFromRaw>))]
public sealed record class CallReferFailedWebhookEvent : JsonModel
{
    public CallReferFailed? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallReferFailed>(
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

    public CallReferFailedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallReferFailedWebhookEvent (
        CallReferFailedWebhookEvent callReferFailedWebhookEvent
    ) : base(callReferFailedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallReferFailedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallReferFailedWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallReferFailedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallReferFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallReferFailedWebhookEventFromRaw : IFromRawJson<CallReferFailedWebhookEvent>
{
    /// <inheritdoc/>
    public CallReferFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallReferFailedWebhookEvent.FromRawUnchecked(rawData);
}