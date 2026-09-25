using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallPlaybackStartedWebhookEvent, CallPlaybackStartedWebhookEventFromRaw>))]
public sealed record class CallPlaybackStartedWebhookEvent : JsonModel
{
    public CallPlaybackStarted? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallPlaybackStarted>(
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

    public CallPlaybackStartedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallPlaybackStartedWebhookEvent (
        CallPlaybackStartedWebhookEvent callPlaybackStartedWebhookEvent
    ) : base(callPlaybackStartedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallPlaybackStartedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallPlaybackStartedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallPlaybackStartedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallPlaybackStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallPlaybackStartedWebhookEventFromRaw : IFromRawJson<CallPlaybackStartedWebhookEvent>
{
    /// <inheritdoc/>
    public CallPlaybackStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallPlaybackStartedWebhookEvent.FromRawUnchecked(rawData);
}