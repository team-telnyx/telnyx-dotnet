using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallStreamingFailedWebhookEvent, CallStreamingFailedWebhookEventFromRaw>))]
public sealed record class CallStreamingFailedWebhookEvent : JsonModel
{
    public CallStreamingFailed? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallStreamingFailed>(
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

    public CallStreamingFailedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallStreamingFailedWebhookEvent (
        CallStreamingFailedWebhookEvent callStreamingFailedWebhookEvent
    ) : base(callStreamingFailedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallStreamingFailedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallStreamingFailedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallStreamingFailedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallStreamingFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallStreamingFailedWebhookEventFromRaw : IFromRawJson<CallStreamingFailedWebhookEvent>
{
    /// <inheritdoc/>
    public CallStreamingFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallStreamingFailedWebhookEvent.FromRawUnchecked(rawData);
}