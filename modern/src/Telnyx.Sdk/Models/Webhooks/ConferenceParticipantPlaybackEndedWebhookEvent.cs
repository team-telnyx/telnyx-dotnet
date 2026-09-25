using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ConferenceParticipantPlaybackEndedWebhookEvent, ConferenceParticipantPlaybackEndedWebhookEventFromRaw>))]
public sealed record class ConferenceParticipantPlaybackEndedWebhookEvent : JsonModel
{
    public ConferenceParticipantPlaybackEnded? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferenceParticipantPlaybackEnded>(
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

    public ConferenceParticipantPlaybackEndedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceParticipantPlaybackEndedWebhookEvent (
        ConferenceParticipantPlaybackEndedWebhookEvent conferenceParticipantPlaybackEndedWebhookEvent
    ) : base(conferenceParticipantPlaybackEndedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public ConferenceParticipantPlaybackEndedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceParticipantPlaybackEndedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceParticipantPlaybackEndedWebhookEventFromRaw.FromRawUnchecked"/>
    public static ConferenceParticipantPlaybackEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceParticipantPlaybackEndedWebhookEventFromRaw : IFromRawJson<ConferenceParticipantPlaybackEndedWebhookEvent>
{
    /// <inheritdoc/>
    public ConferenceParticipantPlaybackEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceParticipantPlaybackEndedWebhookEvent.FromRawUnchecked(rawData);
}