using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using SystemText = System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messages;

/// <summary>
/// Sends a WhatsApp message using a Telnyx WhatsApp-enabled number. The message body,
/// interactive elements, media, location, and reaction content are specified in
/// the `whatsapp_message` field. Delivery progress and final disposition are reported
/// asynchronously through messaging webhooks.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MessageWhatsappParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Phone number in +E.164 format associated with Whatsapp account
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
    /// Phone number in +E.164 format
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

    public required WhatsappMessageContent WhatsappMessage {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<WhatsappMessageContent>(
                "whatsapp_message"
            );
        }
        init { this._rawBodyData.Set("whatsapp_message", value); }
    }

    /// <summary>
    /// Messaging profile ID - required if the 'from' number is not SMS-enabled
    /// </summary>
    public string? MessagingProfileID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "messaging_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("messaging_profile_id", value);
        }
    }

    /// <summary>
    /// Message type - must be set to "WHATSAPP"
    /// </summary>
    public ApiEnum<string, MessageWhatsappParamsType>? Type {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, MessageWhatsappParamsType>>(
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

    public MessageWhatsappParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageWhatsappParams (
        MessageWhatsappParams messageWhatsappParams
    ) : base(messageWhatsappParams)
    { this._rawBodyData = new(messageWhatsappParams._rawBodyData); }
    #pragma warning restore CS8618

    public MessageWhatsappParams (
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
    MessageWhatsappParams (
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
    public static MessageWhatsappParams FromRawUnchecked(
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

    public virtual bool Equals(MessageWhatsappParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/messages/whatsapp"
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
/// Message type - must be set to "WHATSAPP"
/// </summary>
[JsonConverter(typeof(MessageWhatsappParamsTypeConverter))]
public enum MessageWhatsappParamsType
{
    Whatsapp
}

sealed class MessageWhatsappParamsTypeConverter : JsonConverter<MessageWhatsappParamsType>
{
    public override MessageWhatsappParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "WHATSAPP"=>MessageWhatsappParamsType.Whatsapp,
            _ =>(MessageWhatsappParamsType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageWhatsappParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessageWhatsappParamsType.Whatsapp=>"WHATSAPP",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}