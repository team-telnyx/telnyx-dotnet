using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallForkStartedWebhookEvent, CallForkStartedWebhookEventFromRaw>))]
public sealed record class CallForkStartedWebhookEvent : JsonModel
{
    public CallForkStarted? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallForkStarted>(
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

    public CallForkStartedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallForkStartedWebhookEvent (
        CallForkStartedWebhookEvent callForkStartedWebhookEvent
    ) : base(callForkStartedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallForkStartedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallForkStartedWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallForkStartedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallForkStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallForkStartedWebhookEventFromRaw : IFromRawJson<CallForkStartedWebhookEvent>
{
    /// <inheritdoc/>
    public CallForkStartedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallForkStartedWebhookEvent.FromRawUnchecked(rawData);
}