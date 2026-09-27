using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ConferencePlaybackEndedWebhookEvent, ConferencePlaybackEndedWebhookEventFromRaw>))]
public sealed record class ConferencePlaybackEndedWebhookEvent : JsonModel
{
    public ConferencePlaybackEnded? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferencePlaybackEnded>(
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

    public ConferencePlaybackEndedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferencePlaybackEndedWebhookEvent (
        ConferencePlaybackEndedWebhookEvent conferencePlaybackEndedWebhookEvent
    ) : base(conferencePlaybackEndedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public ConferencePlaybackEndedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferencePlaybackEndedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferencePlaybackEndedWebhookEventFromRaw.FromRawUnchecked"/>
    public static ConferencePlaybackEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferencePlaybackEndedWebhookEventFromRaw : IFromRawJson<ConferencePlaybackEndedWebhookEvent>
{
    /// <inheritdoc/>
    public ConferencePlaybackEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferencePlaybackEndedWebhookEvent.FromRawUnchecked(rawData);
}