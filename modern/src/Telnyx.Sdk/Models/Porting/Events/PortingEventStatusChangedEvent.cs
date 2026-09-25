using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Porting.Events;

[JsonConverter(typeof(JsonModelConverter<PortingEventStatusChangedEvent, PortingEventStatusChangedEventFromRaw>))]
public sealed record class PortingEventStatusChangedEvent : JsonModel
{
    /// <summary>
    /// Uniquely identifies the event.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Indicates the notification methods used.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, PortingEventStatusChangedEventAvailableNotificationMethod>>? AvailableNotificationMethods {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, PortingEventStatusChangedEventAvailableNotificationMethod>>>(
                "available_notification_methods"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, PortingEventStatusChangedEventAvailableNotificationMethod>>?>(
                "available_notification_methods",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Identifies the event type
    /// </summary>
    public ApiEnum<string, PortingEventStatusChangedEventEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingEventStatusChangedEventEventType>>(
                "event_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("event_type", value);
        }
    }

    /// <summary>
    /// The webhook payload for the porting_order.status_changed event
    /// </summary>
    public PortingEventStatusChangedEventPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingEventStatusChangedEventPayload>(
                "payload"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payload", value);
        }
    }

    /// <summary>
    /// The status of the payload generation.
    /// </summary>
    public ApiEnum<string, PortingEventStatusChangedEventPayloadStatus>? PayloadStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingEventStatusChangedEventPayloadStatus>>(
                "payload_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payload_status", value);
        }
    }

    /// <summary>
    /// Identifies the porting order associated with the event.
    /// </summary>
    public string? PortingOrderID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "porting_order_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("porting_order_id", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was updated.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.AvailableNotificationMethods ?? [])
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        this.EventType?.Validate();
        this.Payload?.Validate();
        this.PayloadStatus?.Validate();
        _ = this.PortingOrderID;
        _ = this.RecordType;
        _ = this.UpdatedAt;
    }

    public PortingEventStatusChangedEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingEventStatusChangedEvent (
        PortingEventStatusChangedEvent portingEventStatusChangedEvent
    ) : base(portingEventStatusChangedEvent)
    {  }
    #pragma warning restore CS8618

    public PortingEventStatusChangedEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingEventStatusChangedEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingEventStatusChangedEventFromRaw.FromRawUnchecked"/>
    public static PortingEventStatusChangedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingEventStatusChangedEventFromRaw : IFromRawJson<PortingEventStatusChangedEvent>
{
    /// <inheritdoc/>
    public PortingEventStatusChangedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingEventStatusChangedEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PortingEventStatusChangedEventAvailableNotificationMethodConverter))]
public enum PortingEventStatusChangedEventAvailableNotificationMethod
{
    Email, Webhook, WebhookV1
}sealed class PortingEventStatusChangedEventAvailableNotificationMethodConverter : JsonConverter<PortingEventStatusChangedEventAvailableNotificationMethod>
{
    public override PortingEventStatusChangedEventAvailableNotificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email"=>PortingEventStatusChangedEventAvailableNotificationMethod.Email,
            "webhook"=>PortingEventStatusChangedEventAvailableNotificationMethod.Webhook,
            "webhook_v1"=>PortingEventStatusChangedEventAvailableNotificationMethod.WebhookV1,
            _ =>(PortingEventStatusChangedEventAvailableNotificationMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingEventStatusChangedEventAvailableNotificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingEventStatusChangedEventAvailableNotificationMethod.Email=>"email",
            PortingEventStatusChangedEventAvailableNotificationMethod.Webhook=>"webhook",
            PortingEventStatusChangedEventAvailableNotificationMethod.WebhookV1=>"webhook_v1",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the event type
/// </summary>
[JsonConverter(typeof(PortingEventStatusChangedEventEventTypeConverter))]
public enum PortingEventStatusChangedEventEventType
{
    PortingOrderStatusChanged
}sealed class PortingEventStatusChangedEventEventTypeConverter : JsonConverter<PortingEventStatusChangedEventEventType>
{
    public override PortingEventStatusChangedEventEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "porting_order.status_changed"=>PortingEventStatusChangedEventEventType.PortingOrderStatusChanged,
            _ =>(PortingEventStatusChangedEventEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingEventStatusChangedEventEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingEventStatusChangedEventEventType.PortingOrderStatusChanged=>"porting_order.status_changed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The webhook payload for the porting_order.status_changed event
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PortingEventStatusChangedEventPayload, PortingEventStatusChangedEventPayloadFromRaw>))]
public sealed record class PortingEventStatusChangedEventPayload : JsonModel
{
    /// <summary>
    /// Identifies the porting order that was moved.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Identifies the customer reference associated with the porting order.
    /// </summary>
    public string? CustomerReference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "customer_reference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("customer_reference", value);
        }
    }

    /// <summary>
    /// Porting order status
    /// </summary>
    public PortingOrderStatus? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrderStatus>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// Identifies the support key associated with the porting order.
    /// </summary>
    public string? SupportKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "support_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("support_key", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the porting order was moved.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <summary>
    /// The URL to send the webhook to.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CustomerReference;
        this.Status?.Validate();
        _ = this.SupportKey;
        _ = this.UpdatedAt;
        _ = this.WebhookUrl;
    }

    public PortingEventStatusChangedEventPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingEventStatusChangedEventPayload (
        PortingEventStatusChangedEventPayload portingEventStatusChangedEventPayload
    ) : base(portingEventStatusChangedEventPayload)
    {  }
    #pragma warning restore CS8618

    public PortingEventStatusChangedEventPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingEventStatusChangedEventPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingEventStatusChangedEventPayloadFromRaw.FromRawUnchecked"/>
    public static PortingEventStatusChangedEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortingEventStatusChangedEventPayloadFromRaw : IFromRawJson<PortingEventStatusChangedEventPayload>
{
    /// <inheritdoc/>
    public PortingEventStatusChangedEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingEventStatusChangedEventPayload.FromRawUnchecked(rawData);
}/// <summary>
/// The status of the payload generation.
/// </summary>
[JsonConverter(typeof(PortingEventStatusChangedEventPayloadStatusConverter))]
public enum PortingEventStatusChangedEventPayloadStatus
{
    Created, Completed
}sealed class PortingEventStatusChangedEventPayloadStatusConverter : JsonConverter<PortingEventStatusChangedEventPayloadStatus>
{
    public override PortingEventStatusChangedEventPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created"=>PortingEventStatusChangedEventPayloadStatus.Created,
            "completed"=>PortingEventStatusChangedEventPayloadStatus.Completed,
            _ =>(PortingEventStatusChangedEventPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingEventStatusChangedEventPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingEventStatusChangedEventPayloadStatus.Created=>"created",
            PortingEventStatusChangedEventPayloadStatus.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}