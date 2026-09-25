using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallBridgedWebhookEvent, CallBridgedWebhookEventFromRaw>))]
public sealed record class CallBridgedWebhookEvent : JsonModel
{
    public CallBridged? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallBridged>(
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

    public CallBridgedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallBridgedWebhookEvent (
        CallBridgedWebhookEvent callBridgedWebhookEvent
    ) : base(callBridgedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallBridgedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallBridgedWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallBridgedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallBridgedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallBridgedWebhookEventFromRaw : IFromRawJson<CallBridgedWebhookEvent>
{
    /// <inheritdoc/>
    public CallBridgedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallBridgedWebhookEvent.FromRawUnchecked(rawData);
}