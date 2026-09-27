using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ConferenceCreatedWebhookEvent, ConferenceCreatedWebhookEventFromRaw>))]
public sealed record class ConferenceCreatedWebhookEvent : JsonModel
{
    public ConferenceCreated? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConferenceCreated>(
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

    public ConferenceCreatedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceCreatedWebhookEvent (
        ConferenceCreatedWebhookEvent conferenceCreatedWebhookEvent
    ) : base(conferenceCreatedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public ConferenceCreatedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceCreatedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceCreatedWebhookEventFromRaw.FromRawUnchecked"/>
    public static ConferenceCreatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceCreatedWebhookEventFromRaw : IFromRawJson<ConferenceCreatedWebhookEvent>
{
    /// <inheritdoc/>
    public ConferenceCreatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceCreatedWebhookEvent.FromRawUnchecked(rawData);
}