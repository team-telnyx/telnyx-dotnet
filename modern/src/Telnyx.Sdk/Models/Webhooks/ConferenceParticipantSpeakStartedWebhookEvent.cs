using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ConferenceParticipantSpeakStartedWebhookEvent, ConferenceParticipantSpeakStartedWebhookEventFromRaw>))]
public sealed record class ConferenceParticipantSpeakStartedWebhookEvent : JsonModel
{
    public ConferenceParticipantSpeakStarted? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferenceParticipantSpeakStarted>(
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

    public ConferenceParticipantSpeakStartedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceParticipantSpeakStartedWebhookEvent (
        ConferenceParticipantSpeakStartedWebhookEvent conferenceParticipantSpeakStartedWebhookEvent
    ) : base(conferenceParticipantSpeakStartedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public ConferenceParticipantSpeakStartedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceParticipantSpeakStartedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceParticipantSpeakStartedWebhookEventFromRaw.FromRawUnchecked"/>
    public static ConferenceParticipantSpeakStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceParticipantSpeakStartedWebhookEventFromRaw : IFromRawJson<ConferenceParticipantSpeakStartedWebhookEvent>
{
    /// <inheritdoc/>
    public ConferenceParticipantSpeakStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceParticipantSpeakStartedWebhookEvent.FromRawUnchecked(rawData);
}