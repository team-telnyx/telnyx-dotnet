using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ConferenceParticipantJoinedWebhookEvent, ConferenceParticipantJoinedWebhookEventFromRaw>))]
public sealed record class ConferenceParticipantJoinedWebhookEvent : JsonModel
{
    public ConferenceParticipantJoined? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferenceParticipantJoined>(
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

    public ConferenceParticipantJoinedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceParticipantJoinedWebhookEvent (
        ConferenceParticipantJoinedWebhookEvent conferenceParticipantJoinedWebhookEvent
    ) : base(conferenceParticipantJoinedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public ConferenceParticipantJoinedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceParticipantJoinedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceParticipantJoinedWebhookEventFromRaw.FromRawUnchecked"/>
    public static ConferenceParticipantJoinedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceParticipantJoinedWebhookEventFromRaw : IFromRawJson<ConferenceParticipantJoinedWebhookEvent>
{
    /// <inheritdoc/>
    public ConferenceParticipantJoinedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceParticipantJoinedWebhookEvent.FromRawUnchecked(rawData);
}