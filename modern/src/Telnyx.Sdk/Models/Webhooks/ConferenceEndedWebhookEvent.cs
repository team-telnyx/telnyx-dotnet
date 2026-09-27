using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ConferenceEndedWebhookEvent, ConferenceEndedWebhookEventFromRaw>))]
public sealed record class ConferenceEndedWebhookEvent : JsonModel
{
    public ConferenceEnded? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferenceEnded>(
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

    public ConferenceEndedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceEndedWebhookEvent (
        ConferenceEndedWebhookEvent conferenceEndedWebhookEvent
    ) : base(conferenceEndedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public ConferenceEndedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceEndedWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceEndedWebhookEventFromRaw.FromRawUnchecked"/>
    public static ConferenceEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceEndedWebhookEventFromRaw : IFromRawJson<ConferenceEndedWebhookEvent>
{
    /// <inheritdoc/>
    public ConferenceEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceEndedWebhookEvent.FromRawUnchecked(rawData);
}