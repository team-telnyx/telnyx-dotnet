using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageWhatsappResponse, MessageWhatsappResponseFromRaw>))]
public sealed record class MessageWhatsappResponse : JsonModel
{
    public MessageWhatsappResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageWhatsappResponseData>(
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

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public MessageWhatsappResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageWhatsappResponse (
        MessageWhatsappResponse messageWhatsappResponse
    ) : base(messageWhatsappResponse)
    {  }
    #pragma warning restore CS8618

    public MessageWhatsappResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageWhatsappResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageWhatsappResponseFromRaw.FromRawUnchecked"/>
    public static MessageWhatsappResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageWhatsappResponseFromRaw : IFromRawJson<MessageWhatsappResponse>
{
    /// <inheritdoc/>
    public MessageWhatsappResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageWhatsappResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MessageWhatsappResponseData, MessageWhatsappResponseDataFromRaw>))]
public sealed record class MessageWhatsappResponseData : JsonModel
{
    /// <summary>
    /// message ID
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

    public WhatsappMessageContent? Body {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappMessageContent>(
                "body"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("body", value);
        }
    }

    public string? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "direction"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("direction", value);
        }
    }

    public string? Encoding {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "encoding"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("encoding", value);
        }
    }

    public MessageWhatsappResponseDataFrom? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageWhatsappResponseDataFrom>(
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

    public string? MessagingProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_profile_id", value);
        }
    }

    public string? OrganizationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_id", value);
        }
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

    public IReadOnlyList<RcsToItem>? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RcsToItem>>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RcsToItem>?>(
                "to",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// Seconds the message is queued due to rate limiting before being sent to the
    /// carrier. Represents the maximum wait across all applicable rate limits (account,
    /// carrier, campaign). 0.0 = no queuing delay.
    /// </summary>
    public float? WaitSeconds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "wait_seconds"
            );
        }
        init { this._rawData.Set("wait_seconds", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Body?.Validate();
        _ = this.Direction;
        _ = this.Encoding;
        this.From?.Validate();
        _ = this.MessagingProfileID;
        _ = this.OrganizationID;
        _ = this.ReceivedAt;
        _ = this.RecordType;
        foreach (var item in this.To ?? [])
        {
            item.Validate();
        }
        _ = this.Type;
        _ = this.WaitSeconds;
    }

    public MessageWhatsappResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageWhatsappResponseData (
        MessageWhatsappResponseData messageWhatsappResponseData
    ) : base(messageWhatsappResponseData)
    {  }
    #pragma warning restore CS8618

    public MessageWhatsappResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageWhatsappResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageWhatsappResponseDataFromRaw.FromRawUnchecked"/>
    public static MessageWhatsappResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessageWhatsappResponseDataFromRaw : IFromRawJson<MessageWhatsappResponseData>
{
    /// <inheritdoc/>
    public MessageWhatsappResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageWhatsappResponseData.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<MessageWhatsappResponseDataFrom, MessageWhatsappResponseDataFromFromRaw>))]
public sealed record class MessageWhatsappResponseDataFrom : JsonModel
{
    /// <summary>
    /// The carrier of the sender.
    /// </summary>
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

    /// <summary>
    /// The line-type of the sender.
    /// </summary>
    public ApiEnum<string, MessageWhatsappResponseDataFromLineType>? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessageWhatsappResponseDataFromLineType>>(
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

    /// <summary>
    /// Sending address (+E.164 formatted phone number, alphanumeric sender ID, or
    /// short code).
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    public ApiEnum<string, MessageWhatsappResponseDataFromStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessageWhatsappResponseDataFromStatus>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Carrier;
        this.LineType?.Validate();
        _ = this.PhoneNumber;
        this.Status?.Validate();
    }

    public MessageWhatsappResponseDataFrom ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageWhatsappResponseDataFrom (
        MessageWhatsappResponseDataFrom messageWhatsappResponseDataFrom
    ) : base(messageWhatsappResponseDataFrom)
    {  }
    #pragma warning restore CS8618

    public MessageWhatsappResponseDataFrom (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageWhatsappResponseDataFrom (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageWhatsappResponseDataFromFromRaw.FromRawUnchecked"/>
    public static MessageWhatsappResponseDataFrom FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessageWhatsappResponseDataFromFromRaw : IFromRawJson<MessageWhatsappResponseDataFrom>
{
    /// <inheritdoc/>
    public MessageWhatsappResponseDataFrom FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageWhatsappResponseDataFrom.FromRawUnchecked(rawData);
}/// <summary>
/// The line-type of the sender.
/// </summary>
[JsonConverter(typeof(MessageWhatsappResponseDataFromLineTypeConverter))]
public enum MessageWhatsappResponseDataFromLineType
{
    Wireline, Wireless, VoWiFi, VoIP, PrePaidWireless, Undefined
}sealed class MessageWhatsappResponseDataFromLineTypeConverter : JsonConverter<MessageWhatsappResponseDataFromLineType>
{
    public override MessageWhatsappResponseDataFromLineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Wireline"=>MessageWhatsappResponseDataFromLineType.Wireline,
            "Wireless"=>MessageWhatsappResponseDataFromLineType.Wireless,
            "VoWiFi"=>MessageWhatsappResponseDataFromLineType.VoWiFi,
            "VoIP"=>MessageWhatsappResponseDataFromLineType.VoIP,
            "Pre-Paid Wireless"=>MessageWhatsappResponseDataFromLineType.PrePaidWireless,
            ""=>MessageWhatsappResponseDataFromLineType.Undefined,
            _ =>(MessageWhatsappResponseDataFromLineType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageWhatsappResponseDataFromLineType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessageWhatsappResponseDataFromLineType.Wireline=>"Wireline",
            MessageWhatsappResponseDataFromLineType.Wireless=>"Wireless",
            MessageWhatsappResponseDataFromLineType.VoWiFi=>"VoWiFi",
            MessageWhatsappResponseDataFromLineType.VoIP=>"VoIP",
            MessageWhatsappResponseDataFromLineType.PrePaidWireless=>"Pre-Paid Wireless",
            MessageWhatsappResponseDataFromLineType.Undefined=>"",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(MessageWhatsappResponseDataFromStatusConverter))]
public enum MessageWhatsappResponseDataFromStatus
{
    Received, Delivered
}sealed class MessageWhatsappResponseDataFromStatusConverter : JsonConverter<MessageWhatsappResponseDataFromStatus>
{
    public override MessageWhatsappResponseDataFromStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "received"=>MessageWhatsappResponseDataFromStatus.Received,
            "delivered"=>MessageWhatsappResponseDataFromStatus.Delivered,
            _ =>(MessageWhatsappResponseDataFromStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageWhatsappResponseDataFromStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessageWhatsappResponseDataFromStatus.Received=>"received",
            MessageWhatsappResponseDataFromStatus.Delivered=>"delivered",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}