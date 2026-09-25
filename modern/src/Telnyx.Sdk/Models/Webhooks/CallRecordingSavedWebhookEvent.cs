using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallRecordingSavedWebhookEvent, CallRecordingSavedWebhookEventFromRaw>))]
public sealed record class CallRecordingSavedWebhookEvent : JsonModel
{
    public CallRecordingSaved? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallRecordingSaved>(
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

    public CallRecordingSavedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRecordingSavedWebhookEvent (
        CallRecordingSavedWebhookEvent callRecordingSavedWebhookEvent
    ) : base(callRecordingSavedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallRecordingSavedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRecordingSavedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallRecordingSavedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallRecordingSavedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallRecordingSavedWebhookEventFromRaw : IFromRawJson<CallRecordingSavedWebhookEvent>
{
    /// <inheritdoc/>
    public CallRecordingSavedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallRecordingSavedWebhookEvent.FromRawUnchecked(rawData);
}