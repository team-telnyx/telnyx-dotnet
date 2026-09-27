using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallStreamingStoppedWebhookEvent, CallStreamingStoppedWebhookEventFromRaw>))]
public sealed record class CallStreamingStoppedWebhookEvent : JsonModel
{
    public CallStreamingStopped? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallStreamingStopped>(
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

    public CallStreamingStoppedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallStreamingStoppedWebhookEvent (
        CallStreamingStoppedWebhookEvent callStreamingStoppedWebhookEvent
    ) : base(callStreamingStoppedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallStreamingStoppedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallStreamingStoppedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallStreamingStoppedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallStreamingStoppedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallStreamingStoppedWebhookEventFromRaw : IFromRawJson<CallStreamingStoppedWebhookEvent>
{
    /// <inheritdoc/>
    public CallStreamingStoppedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallStreamingStoppedWebhookEvent.FromRawUnchecked(rawData);
}