using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Portouts.Events;

[JsonConverter(typeof(JsonModelConverter<WebhookPortoutStatusChanged, WebhookPortoutStatusChangedFromRaw>))]
public sealed record class WebhookPortoutStatusChanged : JsonModel
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
    public IReadOnlyList<ApiEnum<string, WebhookPortoutStatusChangedAvailableNotificationMethod>>? AvailableNotificationMethods {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, WebhookPortoutStatusChangedAvailableNotificationMethod>>>(
                "available_notification_methods"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, WebhookPortoutStatusChangedAvailableNotificationMethod>>?>(
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
    public ApiEnum<string, WebhookPortoutStatusChangedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WebhookPortoutStatusChangedEventType>>(
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
    /// The webhook payload for the portout.status_changed event
    /// </summary>
    public WebhookPortoutStatusChangedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookPortoutStatusChangedPayload>(
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
    public ApiEnum<string, WebhookPortoutStatusChangedPayloadStatus>? PayloadStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WebhookPortoutStatusChangedPayloadStatus>>(
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
    /// Identifies the port-out order associated with the event.
    /// </summary>
    public string? PortoutID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "portout_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("portout_id", value);
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
        _ = this.PortoutID;
        _ = this.RecordType;
        _ = this.UpdatedAt;
    }

    public WebhookPortoutStatusChanged ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookPortoutStatusChanged (
        WebhookPortoutStatusChanged webhookPortoutStatusChanged
    ) : base(webhookPortoutStatusChanged)
    {  }
    #pragma warning restore CS8618

    public WebhookPortoutStatusChanged (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookPortoutStatusChanged (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookPortoutStatusChangedFromRaw.FromRawUnchecked"/>
    public static WebhookPortoutStatusChanged FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WebhookPortoutStatusChangedFromRaw : IFromRawJson<WebhookPortoutStatusChanged>
{
    /// <inheritdoc/>
    public WebhookPortoutStatusChanged FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookPortoutStatusChanged.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(WebhookPortoutStatusChangedAvailableNotificationMethodConverter))]
public enum WebhookPortoutStatusChangedAvailableNotificationMethod
{
    Email, Webhook
}sealed class WebhookPortoutStatusChangedAvailableNotificationMethodConverter : JsonConverter<WebhookPortoutStatusChangedAvailableNotificationMethod>
{
    public override WebhookPortoutStatusChangedAvailableNotificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email"=>WebhookPortoutStatusChangedAvailableNotificationMethod.Email,
            "webhook"=>WebhookPortoutStatusChangedAvailableNotificationMethod.Webhook,
            _ =>(WebhookPortoutStatusChangedAvailableNotificationMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookPortoutStatusChangedAvailableNotificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookPortoutStatusChangedAvailableNotificationMethod.Email=>"email",
            WebhookPortoutStatusChangedAvailableNotificationMethod.Webhook=>"webhook",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the event type
/// </summary>
[JsonConverter(typeof(WebhookPortoutStatusChangedEventTypeConverter))]
public enum WebhookPortoutStatusChangedEventType
{
    PortoutStatusChanged, PortoutFocDateChanged, PortoutNewComment
}sealed class WebhookPortoutStatusChangedEventTypeConverter : JsonConverter<WebhookPortoutStatusChangedEventType>
{
    public override WebhookPortoutStatusChangedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "portout.status_changed"=>WebhookPortoutStatusChangedEventType.PortoutStatusChanged,
            "portout.foc_date_changed"=>WebhookPortoutStatusChangedEventType.PortoutFocDateChanged,
            "portout.new_comment"=>WebhookPortoutStatusChangedEventType.PortoutNewComment,
            _ =>(WebhookPortoutStatusChangedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookPortoutStatusChangedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookPortoutStatusChangedEventType.PortoutStatusChanged=>"portout.status_changed",
            WebhookPortoutStatusChangedEventType.PortoutFocDateChanged=>"portout.foc_date_changed",
            WebhookPortoutStatusChangedEventType.PortoutNewComment=>"portout.new_comment",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The webhook payload for the portout.status_changed event
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookPortoutStatusChangedPayload, WebhookPortoutStatusChangedPayloadFromRaw>))]
public sealed record class WebhookPortoutStatusChangedPayload : JsonModel
{
    /// <summary>
    /// Identifies the port out that was moved.
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
    /// The PIN that was attempted to be used to authorize the port out.
    /// </summary>
    public string? AttemptedPin {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "attempted_pin"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("attempted_pin", value);
        }
    }

    /// <summary>
    /// Carrier the number will be ported out to
    /// </summary>
    public string? CarrierName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "carrier_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("carrier_name", value);
        }
    }

    /// <summary>
    /// Phone numbers associated with this port-out order
    /// </summary>
    public IReadOnlyList<string>? PhoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "phone_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "phone_numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The reason why the order is being rejected by the user. If the order is authorized,
    /// this field can be left null
    /// </summary>
    public string? RejectionReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "rejection_reason"
            );
        }
        init { this._rawData.Set("rejection_reason", value); }
    }

    /// <summary>
    /// The new carrier SPID.
    /// </summary>
    public string? Spid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "spid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("spid", value);
        }
    }

    /// <summary>
    /// The new status of the port out.
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
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
    /// The name of the port-out's end user.
    /// </summary>
    public string? SubscriberName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "subscriber_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("subscriber_name", value);
        }
    }

    /// <summary>
    /// Identifies the user that the port-out order belongs to.
    /// </summary>
    public string? UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AttemptedPin;
        _ = this.CarrierName;
        _ = this.PhoneNumbers;
        _ = this.RejectionReason;
        _ = this.Spid;
        this.Status?.Validate();
        _ = this.SubscriberName;
        _ = this.UserID;
    }

    public WebhookPortoutStatusChangedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookPortoutStatusChangedPayload (
        WebhookPortoutStatusChangedPayload webhookPortoutStatusChangedPayload
    ) : base(webhookPortoutStatusChangedPayload)
    {  }
    #pragma warning restore CS8618

    public WebhookPortoutStatusChangedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookPortoutStatusChangedPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookPortoutStatusChangedPayloadFromRaw.FromRawUnchecked"/>
    public static WebhookPortoutStatusChangedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WebhookPortoutStatusChangedPayloadFromRaw : IFromRawJson<WebhookPortoutStatusChangedPayload>
{
    /// <inheritdoc/>
    public WebhookPortoutStatusChangedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookPortoutStatusChangedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// The new status of the port out.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Authorized, Ported, Rejected, RejectedPending, Canceled
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>Status.Pending,
            "authorized"=>Status.Authorized,
            "ported"=>Status.Ported,
            "rejected"=>Status.Rejected,
            "rejected-pending"=>Status.RejectedPending,
            "canceled"=>Status.Canceled,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Pending=>"pending",
            Status.Authorized=>"authorized",
            Status.Ported=>"ported",
            Status.Rejected=>"rejected",
            Status.RejectedPending=>"rejected-pending",
            Status.Canceled=>"canceled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the payload generation.
/// </summary>
[JsonConverter(typeof(WebhookPortoutStatusChangedPayloadStatusConverter))]
public enum WebhookPortoutStatusChangedPayloadStatus
{
    Created, Completed
}sealed class WebhookPortoutStatusChangedPayloadStatusConverter : JsonConverter<WebhookPortoutStatusChangedPayloadStatus>
{
    public override WebhookPortoutStatusChangedPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created"=>WebhookPortoutStatusChangedPayloadStatus.Created,
            "completed"=>WebhookPortoutStatusChangedPayloadStatus.Completed,
            _ =>(WebhookPortoutStatusChangedPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookPortoutStatusChangedPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookPortoutStatusChangedPayloadStatus.Created=>"created",
            WebhookPortoutStatusChangedPayloadStatus.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}