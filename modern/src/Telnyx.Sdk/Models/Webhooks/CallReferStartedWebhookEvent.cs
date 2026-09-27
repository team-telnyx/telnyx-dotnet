using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallReferStartedWebhookEvent, CallReferStartedWebhookEventFromRaw>))]
public sealed record class CallReferStartedWebhookEvent : JsonModel
{
    public CallReferStarted? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallReferStarted>(
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

    public CallReferStartedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallReferStartedWebhookEvent (
        CallReferStartedWebhookEvent callReferStartedWebhookEvent
    ) : base(callReferStartedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallReferStartedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallReferStartedWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallReferStartedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallReferStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallReferStartedWebhookEventFromRaw : IFromRawJson<CallReferStartedWebhookEvent>
{
    /// <inheritdoc/>
    public CallReferStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallReferStartedWebhookEvent.FromRawUnchecked(rawData);
}