using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Messages = Telnyx.Sdk.Models.Messages;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<WhatsappMessageEcho, WhatsappMessageEchoFromRaw>))]
public sealed record class WhatsappMessageEcho : JsonModel
{
    public required WhatsappMessageEchoData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WhatsappMessageEchoData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public WhatsappMessageEcho ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappMessageEcho (WhatsappMessageEcho whatsappMessageEcho) : base(
        whatsappMessageEcho
    )
    {  }
    #pragma warning restore CS8618

    public WhatsappMessageEcho (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappMessageEcho (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappMessageEchoFromRaw.FromRawUnchecked"/>
    public static WhatsappMessageEcho FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public WhatsappMessageEcho (WhatsappMessageEchoData data) : this()
    { this.Data = data; }
}

class WhatsappMessageEchoFromRaw : IFromRawJson<WhatsappMessageEcho>
{
    /// <inheritdoc/>
    public WhatsappMessageEcho FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappMessageEcho.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<WhatsappMessageEchoData, WhatsappMessageEchoDataFromRaw>))]
public sealed record class WhatsappMessageEchoData : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, WhatsappMessageEchoDataEventType> EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WhatsappMessageEchoDataEventType>>(
                "event_type"
            );
        }
        init { this._rawData.Set("event_type", value); }
    }

    public required System::DateTimeOffset OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "occurred_at"
            );
        }
        init { this._rawData.Set("occurred_at", value); }
    }

    public required WhatsappMessageEchoDataPayload Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WhatsappMessageEchoDataPayload>(
                "payload"
            );
        }
        init { this._rawData.Set("payload", value); }
    }

    public required ApiEnum<string, WhatsappMessageEchoDataRecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WhatsappMessageEchoDataRecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.EventType.Validate();
        _ = this.OccurredAt;
        this.Payload.Validate();
        this.RecordType.Validate();
    }

    public WhatsappMessageEchoData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappMessageEchoData (
        WhatsappMessageEchoData whatsappMessageEchoData
    ) : base(whatsappMessageEchoData)
    {  }
    #pragma warning restore CS8618

    public WhatsappMessageEchoData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappMessageEchoData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappMessageEchoDataFromRaw.FromRawUnchecked"/>
    public static WhatsappMessageEchoData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WhatsappMessageEchoDataFromRaw : IFromRawJson<WhatsappMessageEchoData>
{
    /// <inheritdoc/>
    public WhatsappMessageEchoData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappMessageEchoData.FromRawUnchecked(rawData);
}[JsonConverter(typeof(WhatsappMessageEchoDataEventTypeConverter))]
public enum WhatsappMessageEchoDataEventType
{
    MessageEcho
}sealed class WhatsappMessageEchoDataEventTypeConverter : JsonConverter<WhatsappMessageEchoDataEventType>
{
    public override WhatsappMessageEchoDataEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "message.echo"=>WhatsappMessageEchoDataEventType.MessageEcho,
            _ =>(WhatsappMessageEchoDataEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsappMessageEchoDataEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WhatsappMessageEchoDataEventType.MessageEcho=>"message.echo",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<WhatsappMessageEchoDataPayload, WhatsappMessageEchoDataPayloadFromRaw>))]
public sealed record class WhatsappMessageEchoDataPayload : JsonModel
{
    /// <summary>
    /// Telnyx identifier for the mirrored message.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Mirrored WhatsApp message content. The content property matches the value
    /// of `type`.
    /// </summary>
    public required Body Body {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Body>(
                "body"
            );
        }
        init { this._rawData.Set("body", value); }
    }

    /// <summary>
    /// No charge is created for a Business app message echo.
    /// </summary>
    public required Cost Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Cost>(
                "cost"
            );
        }
        init { this._rawData.Set("cost", value); }
    }

    /// <summary>
    /// Indicates that the business sent the message to the WhatsApp user.
    /// </summary>
    public required ApiEnum<string, WhatsappMessageEchoDataPayloadDirection> Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WhatsappMessageEchoDataPayloadDirection>>(
                "direction"
            );
        }
        init { this._rawData.Set("direction", value); }
    }

    public required IReadOnlyList<Messages::MessagingError0b38e7044b> Errors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Messages::MessagingError0b38e7044b>>(
                "errors"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Messages::MessagingError0b38e7044b>>(
                "errors",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required From From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<From>(
                "from"
            );
        }
        init { this._rawData.Set("from", value); }
    }

    public required string MessagingProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "messaging_profile_id"
            );
        }
        init { this._rawData.Set("messaging_profile_id", value); }
    }

    public required string OrganizationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "organization_id"
            );
        }
        init { this._rawData.Set("organization_id", value); }
    }

    /// <summary>
    /// Identifies the WhatsApp Business app as the source of the message.
    /// </summary>
    public required ApiEnum<string, Origin> Origin {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Origin>>(
                "origin"
            );
        }
        init { this._rawData.Set("origin", value); }
    }

    public required ApiEnum<string, WhatsappMessageEchoDataPayloadRecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WhatsappMessageEchoDataPayloadRecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// WhatsApp user who received the Business app message.
    /// </summary>
    public required string To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "to"
            );
        }
        init { this._rawData.Set("to", value); }
    }

    public required ApiEnum<string, WhatsappMessageEchoDataPayloadType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WhatsappMessageEchoDataPayloadType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    public System::DateTimeOffset? ReceivedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "received_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("received_at", value);
        }
    }

    public IReadOnlyList<string>? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? WebhookFailoverUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_failover_url"
            );
        }
        init { this._rawData.Set("webhook_failover_url", value); }
    }

    public string? WebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init { this._rawData.Set("webhook_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Body.Validate();
        this.Cost.Validate();
        this.Direction.Validate();
        foreach (var item in this.Errors)
        {
            item.Validate();
        }
        this.From.Validate();
        _ = this.MessagingProfileID;
        _ = this.OrganizationID;
        this.Origin.Validate();
        this.RecordType.Validate();
        _ = this.To;
        this.Type.Validate();
        _ = this.ReceivedAt;
        _ = this.Tags;
        _ = this.WebhookFailoverUrl;
        _ = this.WebhookUrl;
    }

    public WhatsappMessageEchoDataPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappMessageEchoDataPayload (
        WhatsappMessageEchoDataPayload whatsappMessageEchoDataPayload
    ) : base(whatsappMessageEchoDataPayload)
    {  }
    #pragma warning restore CS8618

    public WhatsappMessageEchoDataPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappMessageEchoDataPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappMessageEchoDataPayloadFromRaw.FromRawUnchecked"/>
    public static WhatsappMessageEchoDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WhatsappMessageEchoDataPayloadFromRaw : IFromRawJson<WhatsappMessageEchoDataPayload>
{
    /// <inheritdoc/>
    public WhatsappMessageEchoDataPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappMessageEchoDataPayload.FromRawUnchecked(rawData);
}/// <summary>
/// Mirrored WhatsApp message content. The content property matches the value of `type`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Body, BodyFromRaw>))]
public sealed record class Body : JsonModel
{
    /// <summary>
    /// Telnyx identifier for the mirrored message.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Meta WhatsApp message identifier, also known as a wamid.
    /// </summary>
    public required string ForeignID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "foreign_id"
            );
        }
        init { this._rawData.Set("foreign_id", value); }
    }

    /// <summary>
    /// Unix timestamp supplied by Meta.
    /// </summary>
    public required string Timestamp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "timestamp"
            );
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// WhatsApp message content type.
    /// </summary>
    public required string Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// WhatsApp user who received the message.
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// Opaque recipient identifier when Meta does not supply a phone number.
    /// </summary>
    public string? FromUserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from_user_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from_user_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ForeignID;
        _ = this.Timestamp;
        _ = this.Type;
        _ = this.From;
        _ = this.FromUserID;
    }

    public Body ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Body (Body body) : base(body)
    {  }
    #pragma warning restore CS8618

    public Body (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Body (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BodyFromRaw.FromRawUnchecked"/>
    public static Body FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class BodyFromRaw : IFromRawJson<Body>
{
    /// <inheritdoc/>
    public Body FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Body.FromRawUnchecked(rawData);
}/// <summary>
/// No charge is created for a Business app message echo.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Cost, CostFromRaw>))]
public sealed record class Cost : JsonModel
{
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init { this._rawData.Set("amount", value); }
    }

    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Cost ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cost (Cost cost) : base(cost)
    {  }
    #pragma warning restore CS8618

    public Cost (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Cost (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CostFromRaw.FromRawUnchecked"/>
    public static Cost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CostFromRaw : IFromRawJson<Cost>
{
    /// <inheritdoc/>
    public Cost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Cost.FromRawUnchecked(rawData);
}/// <summary>
/// Indicates that the business sent the message to the WhatsApp user.
/// </summary>
[JsonConverter(typeof(WhatsappMessageEchoDataPayloadDirectionConverter))]
public enum WhatsappMessageEchoDataPayloadDirection
{
    Outbound
}sealed class WhatsappMessageEchoDataPayloadDirectionConverter : JsonConverter<WhatsappMessageEchoDataPayloadDirection>
{
    public override WhatsappMessageEchoDataPayloadDirection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "outbound"=>WhatsappMessageEchoDataPayloadDirection.Outbound,
            _ =>(WhatsappMessageEchoDataPayloadDirection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsappMessageEchoDataPayloadDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WhatsappMessageEchoDataPayloadDirection.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<From, FromFromRaw>))]
public sealed record class From : JsonModel
{
    /// <summary>
    /// Coexistence-enabled business phone number in E.164 format.
    /// </summary>
    public required string PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phone_number"
            );
        }
        init { this._rawData.Set("phone_number", value); }
    }

    public string? Carrier {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "carrier"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("carrier", value);
        }
    }

    public string? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "line_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("line_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PhoneNumber;
        _ = this.Carrier;
        _ = this.LineType;
    }

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

    [SetsRequiredMembers]
    public From (string phoneNumber) : this()
    { this.PhoneNumber = phoneNumber; }
}class FromFromRaw : IFromRawJson<From>
{
    /// <inheritdoc/>
    public From FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>From.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the WhatsApp Business app as the source of the message.
/// </summary>
[JsonConverter(typeof(OriginConverter))]
public enum Origin
{
    WhatsappBusinessApp
}sealed class OriginConverter : JsonConverter<Origin>
{
    public override Origin Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "whatsapp_business_app"=>Origin.WhatsappBusinessApp,
            _ =>(Origin)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Origin value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Origin.WhatsappBusinessApp=>"whatsapp_business_app",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(WhatsappMessageEchoDataPayloadRecordTypeConverter))]
public enum WhatsappMessageEchoDataPayloadRecordType
{
    Message
}sealed class WhatsappMessageEchoDataPayloadRecordTypeConverter : JsonConverter<WhatsappMessageEchoDataPayloadRecordType>
{
    public override WhatsappMessageEchoDataPayloadRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "message"=>WhatsappMessageEchoDataPayloadRecordType.Message,
            _ =>(WhatsappMessageEchoDataPayloadRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsappMessageEchoDataPayloadRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WhatsappMessageEchoDataPayloadRecordType.Message=>"message",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(WhatsappMessageEchoDataPayloadTypeConverter))]
public enum WhatsappMessageEchoDataPayloadType
{
    Whatsapp
}sealed class WhatsappMessageEchoDataPayloadTypeConverter : JsonConverter<WhatsappMessageEchoDataPayloadType>
{
    public override WhatsappMessageEchoDataPayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "WHATSAPP"=>WhatsappMessageEchoDataPayloadType.Whatsapp,
            _ =>(WhatsappMessageEchoDataPayloadType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsappMessageEchoDataPayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WhatsappMessageEchoDataPayloadType.Whatsapp=>"WHATSAPP",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(WhatsappMessageEchoDataRecordTypeConverter))]
public enum WhatsappMessageEchoDataRecordType
{
    Event
}sealed class WhatsappMessageEchoDataRecordTypeConverter : JsonConverter<WhatsappMessageEchoDataRecordType>
{
    public override WhatsappMessageEchoDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>WhatsappMessageEchoDataRecordType.Event,
            _ =>(WhatsappMessageEchoDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsappMessageEchoDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WhatsappMessageEchoDataRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}