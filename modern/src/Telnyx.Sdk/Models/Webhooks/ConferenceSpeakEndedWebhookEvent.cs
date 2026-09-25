using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ConferenceSpeakEndedWebhookEvent, ConferenceSpeakEndedWebhookEventFromRaw>))]
public sealed record class ConferenceSpeakEndedWebhookEvent : JsonModel
{
    public ConferenceSpeakEnded? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferenceSpeakEnded>(
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

    public ConferenceSpeakEndedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceSpeakEndedWebhookEvent (
        ConferenceSpeakEndedWebhookEvent conferenceSpeakEndedWebhookEvent
    ) : base(conferenceSpeakEndedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public ConferenceSpeakEndedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceSpeakEndedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceSpeakEndedWebhookEventFromRaw.FromRawUnchecked"/>
    public static ConferenceSpeakEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceSpeakEndedWebhookEventFromRaw : IFromRawJson<ConferenceSpeakEndedWebhookEvent>
{
    /// <inheritdoc/>
    public ConferenceSpeakEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceSpeakEndedWebhookEvent.FromRawUnchecked(rawData);
}