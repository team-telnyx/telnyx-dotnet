using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallAIGatherMessageHistoryUpdatedWebhookEvent, CallAIGatherMessageHistoryUpdatedWebhookEventFromRaw>))]
public sealed record class CallAIGatherMessageHistoryUpdatedWebhookEvent : JsonModel
{
    public CallAIGatherMessageHistoryUpdated? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallAIGatherMessageHistoryUpdated>(
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

    public CallAIGatherMessageHistoryUpdatedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallAIGatherMessageHistoryUpdatedWebhookEvent (
        CallAIGatherMessageHistoryUpdatedWebhookEvent callAIGatherMessageHistoryUpdatedWebhookEvent
    ) : base(callAIGatherMessageHistoryUpdatedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallAIGatherMessageHistoryUpdatedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallAIGatherMessageHistoryUpdatedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallAIGatherMessageHistoryUpdatedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallAIGatherMessageHistoryUpdatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallAIGatherMessageHistoryUpdatedWebhookEventFromRaw : IFromRawJson<CallAIGatherMessageHistoryUpdatedWebhookEvent>
{
    /// <inheritdoc/>
    public CallAIGatherMessageHistoryUpdatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallAIGatherMessageHistoryUpdatedWebhookEvent.FromRawUnchecked(rawData);
}