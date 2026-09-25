using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<TranscriptionWebhookEvent, TranscriptionWebhookEventFromRaw>))]
public sealed record class TranscriptionWebhookEvent : JsonModel
{
    public Transcription? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Transcription>(
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

    public TranscriptionWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionWebhookEvent (
        TranscriptionWebhookEvent transcriptionWebhookEvent
    ) : base(transcriptionWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public TranscriptionWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionWebhookEventFromRaw.FromRawUnchecked"/>
    public static TranscriptionWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionWebhookEventFromRaw : IFromRawJson<TranscriptionWebhookEvent>
{
    /// <inheritdoc/>
    public TranscriptionWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionWebhookEvent.FromRawUnchecked(rawData);
}