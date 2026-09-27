using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<InboundMessageWebhookEvent, InboundMessageWebhookEventFromRaw>))]
public sealed record class InboundMessageWebhookEvent : JsonModel
{
    public MessagingInboundMessage? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingInboundMessage>(
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

    public InboundMessageWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundMessageWebhookEvent (
        InboundMessageWebhookEvent inboundMessageWebhookEvent
    ) : base(inboundMessageWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public InboundMessageWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundMessageWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboundMessageWebhookEventFromRaw.FromRawUnchecked"/>
    public static InboundMessageWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InboundMessageWebhookEventFromRaw : IFromRawJson<InboundMessageWebhookEvent>
{
    /// <inheritdoc/>
    public InboundMessageWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InboundMessageWebhookEvent.FromRawUnchecked(rawData);
}