using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallAnsweredWebhookEvent, CallAnsweredWebhookEventFromRaw>))]
public sealed record class CallAnsweredWebhookEvent : JsonModel
{
    public CallAnswered? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallAnswered>(
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

    public CallAnsweredWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallAnsweredWebhookEvent (
        CallAnsweredWebhookEvent callAnsweredWebhookEvent
    ) : base(callAnsweredWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallAnsweredWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallAnsweredWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallAnsweredWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallAnsweredWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallAnsweredWebhookEventFromRaw : IFromRawJson<CallAnsweredWebhookEvent>
{
    /// <inheritdoc/>
    public CallAnsweredWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallAnsweredWebhookEvent.FromRawUnchecked(rawData);
}