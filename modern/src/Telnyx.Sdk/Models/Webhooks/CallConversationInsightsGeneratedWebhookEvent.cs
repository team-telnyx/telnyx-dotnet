using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallConversationInsightsGeneratedWebhookEvent, CallConversationInsightsGeneratedWebhookEventFromRaw>))]
public sealed record class CallConversationInsightsGeneratedWebhookEvent : JsonModel
{
    public CallConversationInsightsGenerated? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallConversationInsightsGenerated>(
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

    public CallConversationInsightsGeneratedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallConversationInsightsGeneratedWebhookEvent (
        CallConversationInsightsGeneratedWebhookEvent callConversationInsightsGeneratedWebhookEvent
    ) : base(callConversationInsightsGeneratedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallConversationInsightsGeneratedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallConversationInsightsGeneratedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallConversationInsightsGeneratedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallConversationInsightsGeneratedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallConversationInsightsGeneratedWebhookEventFromRaw : IFromRawJson<CallConversationInsightsGeneratedWebhookEvent>
{
    /// <inheritdoc/>
    public CallConversationInsightsGeneratedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallConversationInsightsGeneratedWebhookEvent.FromRawUnchecked(rawData);
}