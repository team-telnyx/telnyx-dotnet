using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallConversationEndedWebhookEvent, CallConversationEndedWebhookEventFromRaw>))]
public sealed record class CallConversationEndedWebhookEvent : JsonModel
{
    public CallConversationEnded? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallConversationEnded>(
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

    public CallConversationEndedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallConversationEndedWebhookEvent (
        CallConversationEndedWebhookEvent callConversationEndedWebhookEvent
    ) : base(callConversationEndedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallConversationEndedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallConversationEndedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallConversationEndedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallConversationEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallConversationEndedWebhookEventFromRaw : IFromRawJson<CallConversationEndedWebhookEvent>
{
    /// <inheritdoc/>
    public CallConversationEndedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallConversationEndedWebhookEvent.FromRawUnchecked(rawData);
}