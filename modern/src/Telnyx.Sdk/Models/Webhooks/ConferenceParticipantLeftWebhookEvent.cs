using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ConferenceParticipantLeftWebhookEvent, ConferenceParticipantLeftWebhookEventFromRaw>))]
public sealed record class ConferenceParticipantLeftWebhookEvent : JsonModel
{
    public ConferenceParticipantLeft? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferenceParticipantLeft>(
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

    public ConferenceParticipantLeftWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceParticipantLeftWebhookEvent (
        ConferenceParticipantLeftWebhookEvent conferenceParticipantLeftWebhookEvent
    ) : base(conferenceParticipantLeftWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public ConferenceParticipantLeftWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceParticipantLeftWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceParticipantLeftWebhookEventFromRaw.FromRawUnchecked"/>
    public static ConferenceParticipantLeftWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceParticipantLeftWebhookEventFromRaw : IFromRawJson<ConferenceParticipantLeftWebhookEvent>
{
    /// <inheritdoc/>
    public ConferenceParticipantLeftWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceParticipantLeftWebhookEvent.FromRawUnchecked(rawData);
}