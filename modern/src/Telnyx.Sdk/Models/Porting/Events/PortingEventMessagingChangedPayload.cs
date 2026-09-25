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

[JsonConverter(typeof(JsonModelConverter<PortingEventMessagingChangedPayload, PortingEventMessagingChangedPayloadFromRaw>))]
public sealed record class PortingEventMessagingChangedPayload : JsonModel
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
    public IReadOnlyList<ApiEnum<string, PortingEventMessagingChangedPayloadAvailableNotificationMethod>>? AvailableNotificationMethods {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, PortingEventMessagingChangedPayloadAvailableNotificationMethod>>>(
                "available_notification_methods"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, PortingEventMessagingChangedPayloadAvailableNotificationMethod>>?>(
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
    public ApiEnum<string, PortingEventMessagingChangedPayloadEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingEventMessagingChangedPayloadEventType>>(
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
    /// The webhook payload for the porting_order.messaging_changed event
    /// </summary>
    public PortingEventMessagingChangedPayloadPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingEventMessagingChangedPayloadPayload>(
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
    public ApiEnum<string, PortingEventMessagingChangedPayloadPayloadStatus>? PayloadStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingEventMessagingChangedPayloadPayloadStatus>>(
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

    public PortingEventMessagingChangedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingEventMessagingChangedPayload (
        PortingEventMessagingChangedPayload portingEventMessagingChangedPayload
    ) : base(portingEventMessagingChangedPayload)
    {  }
    #pragma warning restore CS8618

    public PortingEventMessagingChangedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingEventMessagingChangedPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingEventMessagingChangedPayloadFromRaw.FromRawUnchecked"/>
    public static PortingEventMessagingChangedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingEventMessagingChangedPayloadFromRaw : IFromRawJson<PortingEventMessagingChangedPayload>
{
    /// <inheritdoc/>
    public PortingEventMessagingChangedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingEventMessagingChangedPayload.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PortingEventMessagingChangedPayloadAvailableNotificationMethodConverter))]
public enum PortingEventMessagingChangedPayloadAvailableNotificationMethod
{
    Email, Webhook, WebhookV1
}sealed class PortingEventMessagingChangedPayloadAvailableNotificationMethodConverter : JsonConverter<PortingEventMessagingChangedPayloadAvailableNotificationMethod>
{
    public override PortingEventMessagingChangedPayloadAvailableNotificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email"=>PortingEventMessagingChangedPayloadAvailableNotificationMethod.Email,
            "webhook"=>PortingEventMessagingChangedPayloadAvailableNotificationMethod.Webhook,
            "webhook_v1"=>PortingEventMessagingChangedPayloadAvailableNotificationMethod.WebhookV1,
            _ =>(PortingEventMessagingChangedPayloadAvailableNotificationMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingEventMessagingChangedPayloadAvailableNotificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingEventMessagingChangedPayloadAvailableNotificationMethod.Email=>"email",
            PortingEventMessagingChangedPayloadAvailableNotificationMethod.Webhook=>"webhook",
            PortingEventMessagingChangedPayloadAvailableNotificationMethod.WebhookV1=>"webhook_v1",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the event type
/// </summary>
[JsonConverter(typeof(PortingEventMessagingChangedPayloadEventTypeConverter))]
public enum PortingEventMessagingChangedPayloadEventType
{
    PortingOrderMessagingChanged
}sealed class PortingEventMessagingChangedPayloadEventTypeConverter : JsonConverter<PortingEventMessagingChangedPayloadEventType>
{
    public override PortingEventMessagingChangedPayloadEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "porting_order.messaging_changed"=>PortingEventMessagingChangedPayloadEventType.PortingOrderMessagingChanged,
            _ =>(PortingEventMessagingChangedPayloadEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingEventMessagingChangedPayloadEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingEventMessagingChangedPayloadEventType.PortingOrderMessagingChanged=>"porting_order.messaging_changed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The webhook payload for the porting_order.messaging_changed event
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PortingEventMessagingChangedPayloadPayload, PortingEventMessagingChangedPayloadPayloadFromRaw>))]
public sealed record class PortingEventMessagingChangedPayloadPayload : JsonModel
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
    /// The messaging portability status of the porting order.
    /// </summary>
    public PortingEventMessagingChangedPayloadPayloadMessaging? Messaging {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingEventMessagingChangedPayloadPayloadMessaging>(
                "messaging"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CustomerReference;
        this.Messaging?.Validate();
        _ = this.SupportKey;
    }

    public PortingEventMessagingChangedPayloadPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingEventMessagingChangedPayloadPayload (
        PortingEventMessagingChangedPayloadPayload portingEventMessagingChangedPayloadPayload
    ) : base(portingEventMessagingChangedPayloadPayload)
    {  }
    #pragma warning restore CS8618

    public PortingEventMessagingChangedPayloadPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingEventMessagingChangedPayloadPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingEventMessagingChangedPayloadPayloadFromRaw.FromRawUnchecked"/>
    public static PortingEventMessagingChangedPayloadPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortingEventMessagingChangedPayloadPayloadFromRaw : IFromRawJson<PortingEventMessagingChangedPayloadPayload>
{
    /// <inheritdoc/>
    public PortingEventMessagingChangedPayloadPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingEventMessagingChangedPayloadPayload.FromRawUnchecked(rawData);
}/// <summary>
/// The messaging portability status of the porting order.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PortingEventMessagingChangedPayloadPayloadMessaging, PortingEventMessagingChangedPayloadPayloadMessagingFromRaw>))]
public sealed record class PortingEventMessagingChangedPayloadPayloadMessaging : JsonModel
{
    /// <summary>
    /// Indicates whether Telnyx will port messaging capabilities from the losing
    /// carrier. If false, any messaging capabilities will stay with their current provider.
    /// </summary>
    public bool? EnableMessaging {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enable_messaging"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enable_messaging", value);
        }
    }

    /// <summary>
    /// Indicates whether the porting order is messaging capable.
    /// </summary>
    public bool? MessagingCapable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "messaging_capable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_capable", value);
        }
    }

    /// <summary>
    /// Indicates whether the messaging port is completed.
    /// </summary>
    public bool? MessagingPortCompleted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "messaging_port_completed"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_port_completed", value);
        }
    }

    /// <summary>
    /// Indicates the messaging port status of the porting order.
    /// </summary>
    public ApiEnum<string, MessagingPortStatus>? MessagingPortStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingPortStatus>>(
                "messaging_port_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_port_status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EnableMessaging;
        _ = this.MessagingCapable;
        _ = this.MessagingPortCompleted;
        this.MessagingPortStatus?.Validate();
    }

    public PortingEventMessagingChangedPayloadPayloadMessaging ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingEventMessagingChangedPayloadPayloadMessaging (
        PortingEventMessagingChangedPayloadPayloadMessaging portingEventMessagingChangedPayloadPayloadMessaging
    ) : base(portingEventMessagingChangedPayloadPayloadMessaging)
    {  }
    #pragma warning restore CS8618

    public PortingEventMessagingChangedPayloadPayloadMessaging (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingEventMessagingChangedPayloadPayloadMessaging (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingEventMessagingChangedPayloadPayloadMessagingFromRaw.FromRawUnchecked"/>
    public static PortingEventMessagingChangedPayloadPayloadMessaging FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortingEventMessagingChangedPayloadPayloadMessagingFromRaw : IFromRawJson<PortingEventMessagingChangedPayloadPayloadMessaging>
{
    /// <inheritdoc/>
    public PortingEventMessagingChangedPayloadPayloadMessaging FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingEventMessagingChangedPayloadPayloadMessaging.FromRawUnchecked(rawData);
}/// <summary>
/// Indicates the messaging port status of the porting order.
/// </summary>
[JsonConverter(typeof(MessagingPortStatusConverter))]
public enum MessagingPortStatus
{
    NotApplicable,
    Pending,
    Activating,
    Exception,
    Canceled,
    PartialPortComplete,
    Ported
}sealed class MessagingPortStatusConverter : JsonConverter<MessagingPortStatus>
{
    public override MessagingPortStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_applicable"=>MessagingPortStatus.NotApplicable,
            "pending"=>MessagingPortStatus.Pending,
            "activating"=>MessagingPortStatus.Activating,
            "exception"=>MessagingPortStatus.Exception,
            "canceled"=>MessagingPortStatus.Canceled,
            "partial_port_complete"=>MessagingPortStatus.PartialPortComplete,
            "ported"=>MessagingPortStatus.Ported,
            _ =>(MessagingPortStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingPortStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingPortStatus.NotApplicable=>"not_applicable",
            MessagingPortStatus.Pending=>"pending",
            MessagingPortStatus.Activating=>"activating",
            MessagingPortStatus.Exception=>"exception",
            MessagingPortStatus.Canceled=>"canceled",
            MessagingPortStatus.PartialPortComplete=>"partial_port_complete",
            MessagingPortStatus.Ported=>"ported",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the payload generation.
/// </summary>
[JsonConverter(typeof(PortingEventMessagingChangedPayloadPayloadStatusConverter))]
public enum PortingEventMessagingChangedPayloadPayloadStatus
{
    Created, Completed
}sealed class PortingEventMessagingChangedPayloadPayloadStatusConverter : JsonConverter<PortingEventMessagingChangedPayloadPayloadStatus>
{
    public override PortingEventMessagingChangedPayloadPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created"=>PortingEventMessagingChangedPayloadPayloadStatus.Created,
            "completed"=>PortingEventMessagingChangedPayloadPayloadStatus.Completed,
            _ =>(PortingEventMessagingChangedPayloadPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingEventMessagingChangedPayloadPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingEventMessagingChangedPayloadPayloadStatus.Created=>"created",
            PortingEventMessagingChangedPayloadPayloadStatus.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}