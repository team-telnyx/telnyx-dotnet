using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallForkStoppedWebhookEvent, CallForkStoppedWebhookEventFromRaw>))]
public sealed record class CallForkStoppedWebhookEvent : JsonModel
{
    public CallForkStopped? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallForkStopped>(
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

    public CallForkStoppedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallForkStoppedWebhookEvent (
        CallForkStoppedWebhookEvent callForkStoppedWebhookEvent
    ) : base(callForkStoppedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallForkStoppedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallForkStoppedWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallForkStoppedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallForkStoppedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallForkStoppedWebhookEventFromRaw : IFromRawJson<CallForkStoppedWebhookEvent>
{
    /// <inheritdoc/>
    public CallForkStoppedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallForkStoppedWebhookEvent.FromRawUnchecked(rawData);
}