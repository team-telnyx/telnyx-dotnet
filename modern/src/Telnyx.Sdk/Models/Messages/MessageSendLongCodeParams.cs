using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using SystemText = System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messages;

/// <summary>
/// Queues an outbound SMS or MMS using a long-code sender. Delivery progress and
/// final disposition are reported asynchronously through messaging webhooks.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MessageSendLongCodeParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Phone number, in +E.164 format, used to send the message.
    /// </summary>
    public required string From {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "from"
            );
        }
        init { this._rawBodyData.Set("from", value); }
    }

    /// <summary>
    /// Receiving address (+E.164 formatted phone number or short code).
    /// </summary>
    public required string To {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "to"
            );
        }
        init { this._rawBodyData.Set("to", value); }
    }

    /// <summary>
    /// Automatically detect if an SMS message is unusually long and exceeds a recommended
    /// limit of message parts.
    /// </summary>
    public bool? AutoDetect {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "auto_detect"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("auto_detect", value);
        }
    }

    /// <summary>
    /// Encoding to use for the message. `auto` (default) uses smart encoding to
    /// automatically select the most efficient encoding. `gsm7` forces GSM-7 encoding
    /// (returns 400 if message contains characters that cannot be encoded). `ucs2`
    /// forces UCS-2 encoding and disables smart encoding. When set, this overrides
    /// the messaging profile's `smart_encoding` setting.
    /// </summary>
    public ApiEnum<string, MessageSendLongCodeParamsEncoding>? Encoding {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, MessageSendLongCodeParamsEncoding>>(
                "encoding"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("encoding", value);
        }
    }

    /// <summary>
    /// A list of media URLs. The total media size must be less than 1 MB.
    ///
    /// <para>**Required for MMS**</para>
    /// </summary>
    public IReadOnlyList<string>? MediaUrls {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "media_urls"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "media_urls",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Subject of multimedia message
    /// </summary>
    public string? Subject {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "subject"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("subject", value);
        }
    }

    /// <summary>
    /// Message body (i.e., content) as a non-empty string.
    ///
    /// <para>**Required for SMS**</para>
    /// </summary>
    public string? Text {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("text", value);
        }
    }

    /// <summary>
    /// The protocol for sending the message, either SMS or MMS.
    /// </summary>
    public ApiEnum<string, MessageSendLongCodeParamsType>? Type {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, MessageSendLongCodeParamsType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("type", value);
        }
    }

    /// <summary>
    /// If the profile this number is associated with has webhooks, use them for delivery
    /// notifications. If webhooks are also specified on the message itself, they
    /// will be attempted first, then those on the profile.
    /// </summary>
    public bool? UseProfileWebhooks {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "use_profile_webhooks"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("use_profile_webhooks", value);
        }
    }

    /// <summary>
    /// The failover URL where webhooks related to this message will be sent if sending
    /// to the primary URL fails.
    /// </summary>
    public string? WebhookFailoverUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_failover_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_failover_url", value);
        }
    }

    /// <summary>
    /// The URL where webhooks related to this message will be sent.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_url", value);
        }
    }

    public MessageSendLongCodeParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageSendLongCodeParams (
        MessageSendLongCodeParams messageSendLongCodeParams
    ) : base(messageSendLongCodeParams)
    { this._rawBodyData = new(messageSendLongCodeParams._rawBodyData); }
    #pragma warning restore CS8618

    public MessageSendLongCodeParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageSendLongCodeParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MessageSendLongCodeParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(MessageSendLongCodeParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/messages/long_code"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            SystemText::Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// Encoding to use for the message. `auto` (default) uses smart encoding to automatically
/// select the most efficient encoding. `gsm7` forces GSM-7 encoding (returns 400
/// if message contains characters that cannot be encoded). `ucs2` forces UCS-2 encoding
/// and disables smart encoding. When set, this overrides the messaging profile's
/// `smart_encoding` setting.
/// </summary>
[JsonConverter(typeof(MessageSendLongCodeParamsEncodingConverter))]
public enum MessageSendLongCodeParamsEncoding
{
    Auto, Gsm7, Ucs2
}

sealed class MessageSendLongCodeParamsEncodingConverter : JsonConverter<MessageSendLongCodeParamsEncoding>
{
    public override MessageSendLongCodeParamsEncoding Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto"=>MessageSendLongCodeParamsEncoding.Auto,
            "gsm7"=>MessageSendLongCodeParamsEncoding.Gsm7,
            "ucs2"=>MessageSendLongCodeParamsEncoding.Ucs2,
            _ =>(MessageSendLongCodeParamsEncoding)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageSendLongCodeParamsEncoding value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessageSendLongCodeParamsEncoding.Auto=>"auto",
            MessageSendLongCodeParamsEncoding.Gsm7=>"gsm7",
            MessageSendLongCodeParamsEncoding.Ucs2=>"ucs2",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The protocol for sending the message, either SMS or MMS.
/// </summary>
[JsonConverter(typeof(MessageSendLongCodeParamsTypeConverter))]
public enum MessageSendLongCodeParamsType
{
    Sms, Mms
}

sealed class MessageSendLongCodeParamsTypeConverter : JsonConverter<MessageSendLongCodeParamsType>
{
    public override MessageSendLongCodeParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SMS"=>MessageSendLongCodeParamsType.Sms,
            "MMS"=>MessageSendLongCodeParamsType.Mms,
            _ =>(MessageSendLongCodeParamsType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageSendLongCodeParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessageSendLongCodeParamsType.Sms=>"SMS",
            MessageSendLongCodeParamsType.Mms=>"MMS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}