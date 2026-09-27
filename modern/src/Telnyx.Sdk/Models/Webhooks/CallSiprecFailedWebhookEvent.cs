using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallSiprecFailedWebhookEvent, CallSiprecFailedWebhookEventFromRaw>))]
public sealed record class CallSiprecFailedWebhookEvent : JsonModel
{
    public CallSiprecFailed? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallSiprecFailed>(
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

    public CallSiprecFailedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallSiprecFailedWebhookEvent (
        CallSiprecFailedWebhookEvent callSiprecFailedWebhookEvent
    ) : base(callSiprecFailedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public CallSiprecFailedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallSiprecFailedWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallSiprecFailedWebhookEventFromRaw.FromRawUnchecked"/>
    public static CallSiprecFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallSiprecFailedWebhookEventFromRaw : IFromRawJson<CallSiprecFailedWebhookEvent>
{
    /// <inheritdoc/>
    public CallSiprecFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallSiprecFailedWebhookEvent.FromRawUnchecked(rawData);
}