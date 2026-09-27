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

[JsonConverter(typeof(JsonModelConverter<PortingEventDeletedPayload, PortingEventDeletedPayloadFromRaw>))]
public sealed record class PortingEventDeletedPayload : JsonModel
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
    public IReadOnlyList<ApiEnum<string, AvailableNotificationMethod>>? AvailableNotificationMethods {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, AvailableNotificationMethod>>>(
                "available_notification_methods"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, AvailableNotificationMethod>>?>(
                "available_notification_methods",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Identifies the event type
    /// </summary>
    public ApiEnum<string, EventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EventType>>(
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

    public Payload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Payload>(
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
    public ApiEnum<string, PayloadStatus>? PayloadStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PayloadStatus>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.AvailableNotificationMethods ?? [])
        {
            item.Validate();
        }
        this.EventType?.Validate();
        this.Payload?.Validate();
        this.PayloadStatus?.Validate();
        _ = this.PortingOrderID;
    }

    public PortingEventDeletedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingEventDeletedPayload (
        PortingEventDeletedPayload portingEventDeletedPayload
    ) : base(portingEventDeletedPayload)
    {  }
    #pragma warning restore CS8618

    public PortingEventDeletedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingEventDeletedPayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingEventDeletedPayloadFromRaw.FromRawUnchecked"/>
    public static PortingEventDeletedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingEventDeletedPayloadFromRaw : IFromRawJson<PortingEventDeletedPayload>
{
    /// <inheritdoc/>
    public PortingEventDeletedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingEventDeletedPayload.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AvailableNotificationMethodConverter))]
public enum AvailableNotificationMethod
{
    Email, Webhook, WebhookV1
}sealed class AvailableNotificationMethodConverter : JsonConverter<AvailableNotificationMethod>
{
    public override AvailableNotificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email"=>AvailableNotificationMethod.Email,
            "webhook"=>AvailableNotificationMethod.Webhook,
            "webhook_v1"=>AvailableNotificationMethod.WebhookV1,
            _ =>(AvailableNotificationMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AvailableNotificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AvailableNotificationMethod.Email=>"email",
            AvailableNotificationMethod.Webhook=>"webhook",
            AvailableNotificationMethod.WebhookV1=>"webhook_v1",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the event type
/// </summary>
[JsonConverter(typeof(EventTypeConverter))]
public enum EventType
{
    PortingOrderDeleted
}sealed class EventTypeConverter : JsonConverter<EventType>
{
    public override EventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "porting_order.deleted"=>EventType.PortingOrderDeleted,
            _ =>(EventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, EventType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EventType.PortingOrderDeleted=>"porting_order.deleted",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Payload, PayloadFromRaw>))]
public sealed record class Payload : JsonModel
{
    /// <summary>
    /// Identifies the porting order that was deleted.
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
    /// ISO 8601 formatted date indicating when the porting order was deleted.
    /// </summary>
    public System::DateTimeOffset? DeletedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "deleted_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("deleted_at", value);
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
        _ = this.CreatedAt;
        _ = this.CustomerReference;
        _ = this.DeletedAt;
        _ = this.RecordType;
        _ = this.UpdatedAt;
    }

    public Payload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Payload (Payload payload) : base(payload)
    {  }
    #pragma warning restore CS8618

    public Payload (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Payload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PayloadFromRaw.FromRawUnchecked"/>
    public static Payload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PayloadFromRaw : IFromRawJson<Payload>
{
    /// <inheritdoc/>
    public Payload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Payload.FromRawUnchecked(rawData);
}/// <summary>
/// The status of the payload generation.
/// </summary>
[JsonConverter(typeof(PayloadStatusConverter))]
public enum PayloadStatus
{
    Created, Completed
}sealed class PayloadStatusConverter : JsonConverter<PayloadStatus>
{
    public override PayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created"=>PayloadStatus.Created,
            "completed"=>PayloadStatus.Completed,
            _ =>(PayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PayloadStatus.Created=>"created",
            PayloadStatus.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}