using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ConferenceParticipantPlaybackStartedWebhookEvent, ConferenceParticipantPlaybackStartedWebhookEventFromRaw>))]
public sealed record class ConferenceParticipantPlaybackStartedWebhookEvent : JsonModel
{
    public ConferenceParticipantPlaybackStarted? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferenceParticipantPlaybackStarted>(
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

    public ConferenceParticipantPlaybackStartedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceParticipantPlaybackStartedWebhookEvent (
        ConferenceParticipantPlaybackStartedWebhookEvent conferenceParticipantPlaybackStartedWebhookEvent
    ) : base(conferenceParticipantPlaybackStartedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public ConferenceParticipantPlaybackStartedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceParticipantPlaybackStartedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceParticipantPlaybackStartedWebhookEventFromRaw.FromRawUnchecked"/>
    public static ConferenceParticipantPlaybackStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceParticipantPlaybackStartedWebhookEventFromRaw : IFromRawJson<ConferenceParticipantPlaybackStartedWebhookEvent>
{
    /// <inheritdoc/>
    public ConferenceParticipantPlaybackStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceParticipantPlaybackStartedWebhookEvent.FromRawUnchecked(rawData);
}