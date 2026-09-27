using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageRetrieveResponse, MessageRetrieveResponseFromRaw>))]
public sealed record class MessageRetrieveResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
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

    public MessageRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageRetrieveResponse (
        MessageRetrieveResponse messageRetrieveResponse
    ) : base(messageRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public MessageRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MessageRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageRetrieveResponseFromRaw : IFromRawJson<MessageRetrieveResponse>
{
    /// <inheritdoc/>
    public MessageRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DataConverter))]
public record class Data : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string? ID {
        get {
            return Match<string?>(outboundMessagePayload: ( x )=>x.ID,
            messagingInboundMessagePayload: ( x )=>x.ID);
        }
    }

    public System::DateTimeOffset? CompletedAt {
        get {
            return Match<System::DateTimeOffset?>(outboundMessagePayload: ( x )=>x.CompletedAt,
            messagingInboundMessagePayload: ( x )=>x.CompletedAt);
        }
    }

    public string? Encoding {
        get {
            return Match<string?>(outboundMessagePayload: ( x )=>x.Encoding,
            messagingInboundMessagePayload: ( x )=>x.Encoding);
        }
    }

    public string? MessagingProfileID {
        get {
            return Match<string?>(outboundMessagePayload: ( x )=>x.MessagingProfileID,
            messagingInboundMessagePayload: ( x )=>x.MessagingProfileID);
        }
    }

    public long? NumChars {
        get {
            return Match<long?>(outboundMessagePayload: ( x )=>x.NumChars,
            messagingInboundMessagePayload: ( x )=>x.NumChars);
        }
    }

    public string? OrganizationID {
        get {
            return Match<string?>(outboundMessagePayload: ( x )=>x.OrganizationID,
            messagingInboundMessagePayload: ( x )=>x.OrganizationID);
        }
    }

    public long? Parts {
        get {
            return Match<long?>(outboundMessagePayload: ( x )=>x.Parts,
            messagingInboundMessagePayload: ( x )=>x.Parts);
        }
    }

    public System::DateTimeOffset? ReceivedAt {
        get {
            return Match<System::DateTimeOffset?>(outboundMessagePayload: ( x )=>x.ReceivedAt,
            messagingInboundMessagePayload: ( x )=>x.ReceivedAt);
        }
    }

    public System::DateTimeOffset? SentAt {
        get {
            return Match<System::DateTimeOffset?>(outboundMessagePayload: ( x )=>x.SentAt,
            messagingInboundMessagePayload: ( x )=>x.SentAt);
        }
    }

    public string? Subject {
        get {
            return Match<string?>(outboundMessagePayload: ( x )=>x.Subject,
            messagingInboundMessagePayload: ( x )=>x.Subject);
        }
    }

    public bool? TcrCampaignBillable {
        get {
            return Match<bool?>(outboundMessagePayload: ( x )=>x.TcrCampaignBillable,
            messagingInboundMessagePayload: ( x )=>x.TcrCampaignBillable);
        }
    }

    public string? TcrCampaignID {
        get {
            return Match<string?>(outboundMessagePayload: ( x )=>x.TcrCampaignID,
            messagingInboundMessagePayload: ( x )=>x.TcrCampaignID);
        }
    }

    public string? TcrCampaignRegistered {
        get {
            return Match<string?>(outboundMessagePayload: ( x )=>x.TcrCampaignRegistered,
            messagingInboundMessagePayload: ( x )=>x.TcrCampaignRegistered);
        }
    }

    public string? Text {
        get {
            return Match<string?>(outboundMessagePayload: ( x )=>x.Text,
            messagingInboundMessagePayload: ( x )=>x.Text);
        }
    }

    public System::DateTimeOffset? ValidUntil {
        get {
            return Match<System::DateTimeOffset?>(outboundMessagePayload: ( x )=>x.ValidUntil,
            messagingInboundMessagePayload: ( x )=>x.ValidUntil);
        }
    }

    public string? WebhookFailoverUrl {
        get {
            return Match<string?>(outboundMessagePayload: ( x )=>x.WebhookFailoverUrl,
            messagingInboundMessagePayload: ( x )=>x.WebhookFailoverUrl);
        }
    }

    public string? WebhookUrl {
        get {
            return Match<string?>(outboundMessagePayload: ( x )=>x.WebhookUrl,
            messagingInboundMessagePayload: ( x )=>x.WebhookUrl);
        }
    }

    public Data (OutboundMessagePayload value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data (
        MessagingInboundMessagePayload value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Data (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="OutboundMessagePayload"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickOutboundMessagePayload(out var value)) {
///     // `value` is of type `OutboundMessagePayload`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickOutboundMessagePayload(
        [NotNullWhen(true)] out OutboundMessagePayload? value
    )
    {
        value =this.Value as OutboundMessagePayload ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="MessagingInboundMessagePayload"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickMessagingInboundMessagePayload(out var value)) {
///     // `value` is of type `MessagingInboundMessagePayload`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickMessagingInboundMessagePayload(
        [NotNullWhen(true)] out MessagingInboundMessagePayload? value
    )
    {
        value =this.Value as MessagingInboundMessagePayload ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (OutboundMessagePayload value) =&gt; {...},
///     (MessagingInboundMessagePayload value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<OutboundMessagePayload> outboundMessagePayload,
        System::Action<MessagingInboundMessagePayload> messagingInboundMessagePayload
    )
    {
        switch (this.Value)
        {
            case OutboundMessagePayload value:
                outboundMessagePayload(value);
                break;
            case MessagingInboundMessagePayload value:
                messagingInboundMessagePayload(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Data");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (OutboundMessagePayload value) =&gt; {...},
///     (MessagingInboundMessagePayload value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<OutboundMessagePayload, T> outboundMessagePayload,
        System::Func<MessagingInboundMessagePayload, T> messagingInboundMessagePayload
    )
    {
        return this.Value switch
        {
            OutboundMessagePayload value=>outboundMessagePayload(value),
            MessagingInboundMessagePayload value=>messagingInboundMessagePayload(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Data")
        } ;
    }

    public static implicit operator Data (
        OutboundMessagePayload value
    )=> new(value) ;

    public static implicit operator Data (
        MessagingInboundMessagePayload value
    )=> new(value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of Data");
        }
        this.Switch((outboundMessagePayload) => outboundMessagePayload.Validate(),
        (messagingInboundMessagePayload) => messagingInboundMessagePayload.Validate());
    }

    public virtual bool Equals(Data? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            OutboundMessagePayload _=>0,
            MessagingInboundMessagePayload _=>1,
            _ =>-1
        } ;
    }
}sealed class DataConverter : JsonConverter<Data>
{
    public override Data? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? direction;
        try {
            direction = element.GetProperty("direction").GetString();
        } catch {
            direction = null;
        }

        switch (direction)
        {
            case "outbound":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OutboundMessagePayload>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "inbound":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MessagingInboundMessagePayload>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }default:
                { return new Data(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer, Data value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}