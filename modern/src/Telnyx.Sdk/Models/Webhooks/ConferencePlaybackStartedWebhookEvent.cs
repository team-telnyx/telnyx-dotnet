using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ConferencePlaybackStartedWebhookEvent, ConferencePlaybackStartedWebhookEventFromRaw>))]
public sealed record class ConferencePlaybackStartedWebhookEvent : JsonModel
{
    public ConferencePlaybackStarted? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferencePlaybackStarted>(
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

    public ConferencePlaybackStartedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferencePlaybackStartedWebhookEvent (
        ConferencePlaybackStartedWebhookEvent conferencePlaybackStartedWebhookEvent
    ) : base(conferencePlaybackStartedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public ConferencePlaybackStartedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferencePlaybackStartedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferencePlaybackStartedWebhookEventFromRaw.FromRawUnchecked"/>
    public static ConferencePlaybackStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferencePlaybackStartedWebhookEventFromRaw : IFromRawJson<ConferencePlaybackStartedWebhookEvent>
{
    /// <inheritdoc/>
    public ConferencePlaybackStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferencePlaybackStartedWebhookEvent.FromRawUnchecked(rawData);
}