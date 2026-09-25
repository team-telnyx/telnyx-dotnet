using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallStreamingStartedWebhookEvent, CallStreamingStartedWebhookEventFromRaw>))]
public sealed record class CallStreamingStartedWebhookEvent : JsonModel
{
    public CallStreamingStarted? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallStreamingStarted>(
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

    public CallStreamingStartedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallStreamingStartedWebhookEvent (
        CallStreamingStartedWebhookEvent callStreamingStartedWebhookEvent
    ) : base(callStreamingStartedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallStreamingStartedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallStreamingStartedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallStreamingStartedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallStreamingStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallStreamingStartedWebhookEventFromRaw : IFromRawJson<CallStreamingStartedWebhookEvent>
{
    /// <inheritdoc/>
    public CallStreamingStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallStreamingStartedWebhookEvent.FromRawUnchecked(rawData);
}