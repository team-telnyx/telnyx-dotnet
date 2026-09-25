using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Messages;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<MessagingInboundMessage, MessagingInboundMessageFromRaw>))]
public sealed record class MessagingInboundMessage : JsonModel
{
    /// <summary>
    /// Identifies the type of resource.
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
    /// The type of event being delivered.
    /// </summary>
    public ApiEnum<string, MessagingInboundMessageEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingInboundMessageEventType>>(
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
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public System::DateTimeOffset? OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "occurred_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("occurred_at", value);
        }
    }

    public MessagingInboundMessagePayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingInboundMessagePayload>(
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
    /// Identifies the type of the resource.
    /// </summary>
    public ApiEnum<string, MessagingInboundMessageRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingInboundMessageRecordType>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.EventType?.Validate();
        _ = this.OccurredAt;
        this.Payload?.Validate();
        this.RecordType?.Validate();
    }

    public MessagingInboundMessage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingInboundMessage (
        MessagingInboundMessage messagingInboundMessage
    ) : base(messagingInboundMessage)
    {  }
    #pragma warning restore CS8618

    public MessagingInboundMessage (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingInboundMessage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingInboundMessageFromRaw.FromRawUnchecked"/>
    public static MessagingInboundMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingInboundMessageFromRaw : IFromRawJson<MessagingInboundMessage>
{
    /// <inheritdoc/>
    public MessagingInboundMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingInboundMessage.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(MessagingInboundMessageEventTypeConverter))]
public enum MessagingInboundMessageEventType
{
    MessageReceived
}sealed class MessagingInboundMessageEventTypeConverter : JsonConverter<MessagingInboundMessageEventType>
{
    public override MessagingInboundMessageEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "message.received"=>MessagingInboundMessageEventType.MessageReceived,
            _ =>(MessagingInboundMessageEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingInboundMessageEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingInboundMessageEventType.MessageReceived=>"message.received",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(MessagingInboundMessageRecordTypeConverter))]
public enum MessagingInboundMessageRecordType
{
    Event
}sealed class MessagingInboundMessageRecordTypeConverter : JsonConverter<MessagingInboundMessageRecordType>
{
    public override MessagingInboundMessageRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>MessagingInboundMessageRecordType.Event,
            _ =>(MessagingInboundMessageRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingInboundMessageRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingInboundMessageRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}