using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallRecordingErrorWebhookEvent, CallRecordingErrorWebhookEventFromRaw>))]
public sealed record class CallRecordingErrorWebhookEvent : JsonModel
{
    public CallRecordingError? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallRecordingError>(
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

    public CallRecordingErrorWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRecordingErrorWebhookEvent (
        CallRecordingErrorWebhookEvent callRecordingErrorWebhookEvent
    ) : base(callRecordingErrorWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallRecordingErrorWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRecordingErrorWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallRecordingErrorWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallRecordingErrorWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallRecordingErrorWebhookEventFromRaw : IFromRawJson<CallRecordingErrorWebhookEvent>
{
    /// <inheritdoc/>
    public CallRecordingErrorWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallRecordingErrorWebhookEvent.FromRawUnchecked(rawData);
}