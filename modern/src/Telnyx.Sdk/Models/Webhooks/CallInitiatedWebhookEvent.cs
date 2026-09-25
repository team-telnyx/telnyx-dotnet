using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallInitiatedWebhookEvent, CallInitiatedWebhookEventFromRaw>))]
public sealed record class CallInitiatedWebhookEvent : JsonModel
{
    public CallInitiated? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallInitiated>(
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

    public CallInitiatedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallInitiatedWebhookEvent (
        CallInitiatedWebhookEvent callInitiatedWebhookEvent
    ) : base(callInitiatedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallInitiatedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallInitiatedWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallInitiatedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallInitiatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallInitiatedWebhookEventFromRaw : IFromRawJson<CallInitiatedWebhookEvent>
{
    /// <inheritdoc/>
    public CallInitiatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallInitiatedWebhookEvent.FromRawUnchecked(rawData);
}