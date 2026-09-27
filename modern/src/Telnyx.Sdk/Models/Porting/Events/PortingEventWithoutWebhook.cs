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

[JsonConverter(typeof(JsonModelConverter<PortingEventWithoutWebhook, PortingEventWithoutWebhookFromRaw>))]
public sealed record class PortingEventWithoutWebhook : JsonModel
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
    public IReadOnlyList<ApiEnum<string, PortingEventWithoutWebhookAvailableNotificationMethod>>? AvailableNotificationMethods {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, PortingEventWithoutWebhookAvailableNotificationMethod>>>(
                "available_notification_methods"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, PortingEventWithoutWebhookAvailableNotificationMethod>>?>(
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
    public ApiEnum<string, PortingEventWithoutWebhookEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingEventWithoutWebhookEventType>>(
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

    public Null? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Null>(
                "payload"
            );
        }
        init { this._rawData.Set("payload", value); }
    }

    /// <summary>
    /// The status of the payload generation.
    /// </summary>
    public ApiEnum<string, PortingEventWithoutWebhookPayloadStatus>? PayloadStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingEventWithoutWebhookPayloadStatus>>(
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
        _ = this.Payload;
        this.PayloadStatus?.Validate();
        _ = this.PortingOrderID;
        _ = this.RecordType;
        _ = this.UpdatedAt;
    }

    public PortingEventWithoutWebhook ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingEventWithoutWebhook (
        PortingEventWithoutWebhook portingEventWithoutWebhook
    ) : base(portingEventWithoutWebhook)
    {  }
    #pragma warning restore CS8618

    public PortingEventWithoutWebhook (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingEventWithoutWebhook (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingEventWithoutWebhookFromRaw.FromRawUnchecked"/>
    public static PortingEventWithoutWebhook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingEventWithoutWebhookFromRaw : IFromRawJson<PortingEventWithoutWebhook>
{
    /// <inheritdoc/>
    public PortingEventWithoutWebhook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingEventWithoutWebhook.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PortingEventWithoutWebhookAvailableNotificationMethodConverter))]
public enum PortingEventWithoutWebhookAvailableNotificationMethod
{
    Email, Webhook, WebhookV1
}sealed class PortingEventWithoutWebhookAvailableNotificationMethodConverter : JsonConverter<PortingEventWithoutWebhookAvailableNotificationMethod>
{
    public override PortingEventWithoutWebhookAvailableNotificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email"=>PortingEventWithoutWebhookAvailableNotificationMethod.Email,
            "webhook"=>PortingEventWithoutWebhookAvailableNotificationMethod.Webhook,
            "webhook_v1"=>PortingEventWithoutWebhookAvailableNotificationMethod.WebhookV1,
            _ =>(PortingEventWithoutWebhookAvailableNotificationMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingEventWithoutWebhookAvailableNotificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingEventWithoutWebhookAvailableNotificationMethod.Email=>"email",
            PortingEventWithoutWebhookAvailableNotificationMethod.Webhook=>"webhook",
            PortingEventWithoutWebhookAvailableNotificationMethod.WebhookV1=>"webhook_v1",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the event type
/// </summary>
[JsonConverter(typeof(PortingEventWithoutWebhookEventTypeConverter))]
public enum PortingEventWithoutWebhookEventType
{
    PortingOrderLoaUpdated, PortingOrderSharingTokenExpired
}sealed class PortingEventWithoutWebhookEventTypeConverter : JsonConverter<PortingEventWithoutWebhookEventType>
{
    public override PortingEventWithoutWebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "porting_order.loa_updated"=>PortingEventWithoutWebhookEventType.PortingOrderLoaUpdated,
            "porting_order.sharing_token_expired"=>PortingEventWithoutWebhookEventType.PortingOrderSharingTokenExpired,
            _ =>(PortingEventWithoutWebhookEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingEventWithoutWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingEventWithoutWebhookEventType.PortingOrderLoaUpdated=>"porting_order.loa_updated",
            PortingEventWithoutWebhookEventType.PortingOrderSharingTokenExpired=>"porting_order.sharing_token_expired",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the payload generation.
/// </summary>
[JsonConverter(typeof(PortingEventWithoutWebhookPayloadStatusConverter))]
public enum PortingEventWithoutWebhookPayloadStatus
{
    Created, Completed
}sealed class PortingEventWithoutWebhookPayloadStatusConverter : JsonConverter<PortingEventWithoutWebhookPayloadStatus>
{
    public override PortingEventWithoutWebhookPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created"=>PortingEventWithoutWebhookPayloadStatus.Created,
            "completed"=>PortingEventWithoutWebhookPayloadStatus.Completed,
            _ =>(PortingEventWithoutWebhookPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingEventWithoutWebhookPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingEventWithoutWebhookPayloadStatus.Created=>"created",
            PortingEventWithoutWebhookPayloadStatus.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}