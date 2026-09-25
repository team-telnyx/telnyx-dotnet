using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<DeliveryUpdateWebhookEvent, DeliveryUpdateWebhookEventFromRaw>))]
public sealed record class DeliveryUpdateWebhookEvent : JsonModel
{
    public OutboundMessage? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutboundMessage>(
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

    public DeliveryUpdateWebhookEventMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DeliveryUpdateWebhookEventMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data?.Validate();
        this.Meta?.Validate();
    }

    public DeliveryUpdateWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeliveryUpdateWebhookEvent (
        DeliveryUpdateWebhookEvent deliveryUpdateWebhookEvent
    ) : base(deliveryUpdateWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public DeliveryUpdateWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DeliveryUpdateWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DeliveryUpdateWebhookEventFromRaw.FromRawUnchecked"/>
    public static DeliveryUpdateWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DeliveryUpdateWebhookEventFromRaw : IFromRawJson<DeliveryUpdateWebhookEvent>
{
    /// <inheritdoc/>
    public DeliveryUpdateWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DeliveryUpdateWebhookEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DeliveryUpdateWebhookEventMeta, DeliveryUpdateWebhookEventMetaFromRaw>))]
public sealed record class DeliveryUpdateWebhookEventMeta : JsonModel
{
    /// <summary>
    /// Number of attempts to deliver the webhook event.
    /// </summary>
    public long? Attempt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "attempt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("attempt", value);
        }
    }

    /// <summary>
    /// The webhook URL the event was delivered to.
    /// </summary>
    public string? DeliveredTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "delivered_to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("delivered_to", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Attempt;
        _ = this.DeliveredTo;
    }

    public DeliveryUpdateWebhookEventMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeliveryUpdateWebhookEventMeta (
        DeliveryUpdateWebhookEventMeta deliveryUpdateWebhookEventMeta
    ) : base(deliveryUpdateWebhookEventMeta)
    {  }
    #pragma warning restore CS8618

    public DeliveryUpdateWebhookEventMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DeliveryUpdateWebhookEventMeta (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DeliveryUpdateWebhookEventMetaFromRaw.FromRawUnchecked"/>
    public static DeliveryUpdateWebhookEventMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DeliveryUpdateWebhookEventMetaFromRaw : IFromRawJson<DeliveryUpdateWebhookEventMeta>
{
    /// <inheritdoc/>
    public DeliveryUpdateWebhookEventMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DeliveryUpdateWebhookEventMeta.FromRawUnchecked(rawData);
}