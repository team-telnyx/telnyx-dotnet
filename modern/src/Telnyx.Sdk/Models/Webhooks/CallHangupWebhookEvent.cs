using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallHangupWebhookEvent, CallHangupWebhookEventFromRaw>))]
public sealed record class CallHangupWebhookEvent : JsonModel
{
    public CallHangup? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallHangup>(
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

    public CallHangupWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallHangupWebhookEvent (
        CallHangupWebhookEvent callHangupWebhookEvent
    ) : base(callHangupWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallHangupWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallHangupWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallHangupWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallHangupWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallHangupWebhookEventFromRaw : IFromRawJson<CallHangupWebhookEvent>
{
    /// <inheritdoc/>
    public CallHangupWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallHangupWebhookEvent.FromRawUnchecked(rawData);
}