using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallPlaybackEndedWebhookEvent, CallPlaybackEndedWebhookEventFromRaw>))]
public sealed record class CallPlaybackEndedWebhookEvent : JsonModel
{
    public CallPlaybackEnded? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallPlaybackEnded>(
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

    public CallPlaybackEndedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallPlaybackEndedWebhookEvent (
        CallPlaybackEndedWebhookEvent callPlaybackEndedWebhookEvent
    ) : base(callPlaybackEndedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallPlaybackEndedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallPlaybackEndedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallPlaybackEndedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallPlaybackEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallPlaybackEndedWebhookEventFromRaw : IFromRawJson<CallPlaybackEndedWebhookEvent>
{
    /// <inheritdoc/>
    public CallPlaybackEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallPlaybackEndedWebhookEvent.FromRawUnchecked(rawData);
}