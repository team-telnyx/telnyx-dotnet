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

[JsonConverter(typeof(JsonModelConverter<PortingEventSplitEvent, PortingEventSplitEventFromRaw>))]
public sealed record class PortingEventSplitEvent : JsonModel
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
    public IReadOnlyList<ApiEnum<string, PortingEventSplitEventAvailableNotificationMethod>>? AvailableNotificationMethods {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, PortingEventSplitEventAvailableNotificationMethod>>>(
                "available_notification_methods"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, PortingEventSplitEventAvailableNotificationMethod>>?>(
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
    public ApiEnum<string, PortingEventSplitEventEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingEventSplitEventEventType>>(
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
    /// The webhook payload for the porting_order.split event
    /// </summary>
    public PortingEventSplitEventPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingEventSplitEventPayload>(
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
    public ApiEnum<string, PortingEventSplitEventPayloadStatus>? PayloadStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingEventSplitEventPayloadStatus>>(
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

    public PortingEventSplitEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingEventSplitEvent (
        PortingEventSplitEvent portingEventSplitEvent
    ) : base(portingEventSplitEvent)
    {  }
    #pragma warning restore CS8618

    public PortingEventSplitEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingEventSplitEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingEventSplitEventFromRaw.FromRawUnchecked"/>
    public static PortingEventSplitEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingEventSplitEventFromRaw : IFromRawJson<PortingEventSplitEvent>
{
    /// <inheritdoc/>
    public PortingEventSplitEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingEventSplitEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PortingEventSplitEventAvailableNotificationMethodConverter))]
public enum PortingEventSplitEventAvailableNotificationMethod
{
    Email, Webhook, WebhookV1
}sealed class PortingEventSplitEventAvailableNotificationMethodConverter : JsonConverter<PortingEventSplitEventAvailableNotificationMethod>
{
    public override PortingEventSplitEventAvailableNotificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email"=>PortingEventSplitEventAvailableNotificationMethod.Email,
            "webhook"=>PortingEventSplitEventAvailableNotificationMethod.Webhook,
            "webhook_v1"=>PortingEventSplitEventAvailableNotificationMethod.WebhookV1,
            _ =>(PortingEventSplitEventAvailableNotificationMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingEventSplitEventAvailableNotificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingEventSplitEventAvailableNotificationMethod.Email=>"email",
            PortingEventSplitEventAvailableNotificationMethod.Webhook=>"webhook",
            PortingEventSplitEventAvailableNotificationMethod.WebhookV1=>"webhook_v1",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the event type
/// </summary>
[JsonConverter(typeof(PortingEventSplitEventEventTypeConverter))]
public enum PortingEventSplitEventEventType
{
    PortingOrderSplit
}sealed class PortingEventSplitEventEventTypeConverter : JsonConverter<PortingEventSplitEventEventType>
{
    public override PortingEventSplitEventEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "porting_order.split"=>PortingEventSplitEventEventType.PortingOrderSplit,
            _ =>(PortingEventSplitEventEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingEventSplitEventEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingEventSplitEventEventType.PortingOrderSplit=>"porting_order.split",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The webhook payload for the porting_order.split event
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PortingEventSplitEventPayload, PortingEventSplitEventPayloadFromRaw>))]
public sealed record class PortingEventSplitEventPayload : JsonModel
{
    /// <summary>
    /// The porting order that was split.
    /// </summary>
    public From? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<From>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// The list of porting phone numbers that were moved to the new porting order.
    /// </summary>
    public IReadOnlyList<PortingPhoneNumber>? PortingPhoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortingPhoneNumber>>(
                "porting_phone_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortingPhoneNumber>?>(
                "porting_phone_numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The new porting order that the phone numbers was moved to.
    /// </summary>
    public To? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<To>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.From?.Validate();
        foreach (var item in this.PortingPhoneNumbers ?? [])
        {
            item.Validate();
        }
        this.To?.Validate();
    }

    public PortingEventSplitEventPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingEventSplitEventPayload (
        PortingEventSplitEventPayload portingEventSplitEventPayload
    ) : base(portingEventSplitEventPayload)
    {  }
    #pragma warning restore CS8618

    public PortingEventSplitEventPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingEventSplitEventPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingEventSplitEventPayloadFromRaw.FromRawUnchecked"/>
    public static PortingEventSplitEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortingEventSplitEventPayloadFromRaw : IFromRawJson<PortingEventSplitEventPayload>
{
    /// <inheritdoc/>
    public PortingEventSplitEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingEventSplitEventPayload.FromRawUnchecked(rawData);
}/// <summary>
/// The porting order that was split.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<From, FromFromRaw>))]
public sealed record class From : JsonModel
{
    /// <summary>
    /// Identifies the porting order that was split.
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

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.ID; }

    public From ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public From (From from) : base(from)
    {  }
    #pragma warning restore CS8618

    public From (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    From (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FromFromRaw.FromRawUnchecked"/>
    public static From FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FromFromRaw : IFromRawJson<From>
{
    /// <inheritdoc/>
    public From FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>From.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<PortingPhoneNumber, PortingPhoneNumberFromRaw>))]
public sealed record class PortingPhoneNumber : JsonModel
{
    /// <summary>
    /// Identifies the porting phone number that was moved.
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

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.ID; }

    public PortingPhoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingPhoneNumber (PortingPhoneNumber portingPhoneNumber) : base(
        portingPhoneNumber
    )
    {  }
    #pragma warning restore CS8618

    public PortingPhoneNumber (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingPhoneNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingPhoneNumberFromRaw.FromRawUnchecked"/>
    public static PortingPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortingPhoneNumberFromRaw : IFromRawJson<PortingPhoneNumber>
{
    /// <inheritdoc/>
    public PortingPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingPhoneNumber.FromRawUnchecked(rawData);
}/// <summary>
/// The new porting order that the phone numbers was moved to.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<To, ToFromRaw>))]
public sealed record class To : JsonModel
{
    /// <summary>
    /// Identifies the porting order that was split.
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

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.ID; }

    public To ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public To (To to) : base(to)
    {  }
    #pragma warning restore CS8618

    public To (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    To (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ToFromRaw.FromRawUnchecked"/>
    public static To FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ToFromRaw : IFromRawJson<To>
{
    /// <inheritdoc/>
    public To FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    =>To.FromRawUnchecked(rawData);
}/// <summary>
/// The status of the payload generation.
/// </summary>
[JsonConverter(typeof(PortingEventSplitEventPayloadStatusConverter))]
public enum PortingEventSplitEventPayloadStatus
{
    Created, Completed
}sealed class PortingEventSplitEventPayloadStatusConverter : JsonConverter<PortingEventSplitEventPayloadStatus>
{
    public override PortingEventSplitEventPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created"=>PortingEventSplitEventPayloadStatus.Created,
            "completed"=>PortingEventSplitEventPayloadStatus.Completed,
            _ =>(PortingEventSplitEventPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingEventSplitEventPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingEventSplitEventPayloadStatus.Created=>"created",
            PortingEventSplitEventPayloadStatus.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}