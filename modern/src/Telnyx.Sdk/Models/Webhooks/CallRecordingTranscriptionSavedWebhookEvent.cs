using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallRecordingTranscriptionSavedWebhookEvent, CallRecordingTranscriptionSavedWebhookEventFromRaw>))]
public sealed record class CallRecordingTranscriptionSavedWebhookEvent : JsonModel
{
    public CallRecordingTranscriptionSaved? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallRecordingTranscriptionSaved>(
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

    public CallRecordingTranscriptionSavedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRecordingTranscriptionSavedWebhookEvent (
        CallRecordingTranscriptionSavedWebhookEvent callRecordingTranscriptionSavedWebhookEvent
    ) : base(callRecordingTranscriptionSavedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallRecordingTranscriptionSavedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRecordingTranscriptionSavedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallRecordingTranscriptionSavedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallRecordingTranscriptionSavedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallRecordingTranscriptionSavedWebhookEventFromRaw : IFromRawJson<CallRecordingTranscriptionSavedWebhookEvent>
{
    /// <inheritdoc/>
    public CallRecordingTranscriptionSavedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallRecordingTranscriptionSavedWebhookEvent.FromRawUnchecked(rawData);
}