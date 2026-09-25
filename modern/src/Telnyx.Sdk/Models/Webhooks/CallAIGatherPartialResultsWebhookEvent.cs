using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallAIGatherPartialResultsWebhookEvent, CallAIGatherPartialResultsWebhookEventFromRaw>))]
public sealed record class CallAIGatherPartialResultsWebhookEvent : JsonModel
{
    public CallAIGatherPartialResults? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallAIGatherPartialResults>(
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

    public CallAIGatherPartialResultsWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallAIGatherPartialResultsWebhookEvent (
        CallAIGatherPartialResultsWebhookEvent callAIGatherPartialResultsWebhookEvent
    ) : base(callAIGatherPartialResultsWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallAIGatherPartialResultsWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallAIGatherPartialResultsWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallAIGatherPartialResultsWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallAIGatherPartialResultsWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallAIGatherPartialResultsWebhookEventFromRaw : IFromRawJson<CallAIGatherPartialResultsWebhookEvent>
{
    /// <inheritdoc/>
    public CallAIGatherPartialResultsWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallAIGatherPartialResultsWebhookEvent.FromRawUnchecked(rawData);
}