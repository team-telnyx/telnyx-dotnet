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

[JsonConverter(typeof(JsonModelConverter<WebhookPortoutFocDateChanged, WebhookPortoutFocDateChangedFromRaw>))]
public sealed record class WebhookPortoutFocDateChanged : JsonModel
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
    public ApiEnum<string, WebhookPortoutFocDateChangedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WebhookPortoutFocDateChangedEventType>>(
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
    /// The webhook payload for the portout.foc_date_changed event
    /// </summary>
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

    public WebhookPortoutFocDateChanged ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookPortoutFocDateChanged (
        WebhookPortoutFocDateChanged webhookPortoutFocDateChanged
    ) : base(webhookPortoutFocDateChanged)
    {  }
    #pragma warning restore CS8618

    public WebhookPortoutFocDateChanged (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookPortoutFocDateChanged (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookPortoutFocDateChangedFromRaw.FromRawUnchecked"/>
    public static WebhookPortoutFocDateChanged FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WebhookPortoutFocDateChangedFromRaw : IFromRawJson<WebhookPortoutFocDateChanged>
{
    /// <inheritdoc/>
    public WebhookPortoutFocDateChanged FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookPortoutFocDateChanged.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AvailableNotificationMethodConverter))]
public enum AvailableNotificationMethod
{
    Email, Webhook
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
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the event type
/// </summary>
[JsonConverter(typeof(WebhookPortoutFocDateChangedEventTypeConverter))]
public enum WebhookPortoutFocDateChangedEventType
{
    PortoutStatusChanged, PortoutFocDateChanged, PortoutNewComment
}sealed class WebhookPortoutFocDateChangedEventTypeConverter : JsonConverter<WebhookPortoutFocDateChangedEventType>
{
    public override WebhookPortoutFocDateChangedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "portout.status_changed"=>WebhookPortoutFocDateChangedEventType.PortoutStatusChanged,
            "portout.foc_date_changed"=>WebhookPortoutFocDateChangedEventType.PortoutFocDateChanged,
            "portout.new_comment"=>WebhookPortoutFocDateChangedEventType.PortoutNewComment,
            _ =>(WebhookPortoutFocDateChangedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookPortoutFocDateChangedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookPortoutFocDateChangedEventType.PortoutStatusChanged=>"portout.status_changed",
            WebhookPortoutFocDateChangedEventType.PortoutFocDateChanged=>"portout.foc_date_changed",
            WebhookPortoutFocDateChangedEventType.PortoutNewComment=>"portout.new_comment",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The webhook payload for the portout.foc_date_changed event
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Payload, PayloadFromRaw>))]
public sealed record class Payload : JsonModel
{
    /// <summary>
    /// Identifies the port-out order that have the FOC date changed.
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
    /// ISO 8601 formatted date indicating the new FOC date.
    /// </summary>
    public System::DateTimeOffset? FocDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "foc_date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("foc_date", value);
        }
    }

    /// <summary>
    /// Identifies the organization that port-out order belongs to.
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
        _ = this.FocDate;
        _ = this.UserID;
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