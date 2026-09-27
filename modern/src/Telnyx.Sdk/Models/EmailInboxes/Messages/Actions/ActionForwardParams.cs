using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailInboxes.Messages.Actions;

/// <summary>
/// Sends from the inbox address through the standard email send pipeline to caller-supplied
/// To, Cc, and Bcc recipients. `to` must contain at least one recipient. Optional
/// `text` and `html` are prepended to a forwarded-message block containing the original
/// metadata and available body content. The subject is prefixed with `Fwd:` unless
/// it already has that prefix.
///
/// <para>Threading headers are derived from the original message: `In-Reply-To` is
/// set to its RFC Message-ID, and `References` contains the original References values
/// plus that Message-ID, de-duplicated and limited to the most recent 20 values.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionForwardParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public Generic::IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string InboxID { get; init; }

    public string? MessageID { get; init; }

    /// <summary>
    /// One recipient or a non-empty recipient array. Each recipient may be an email
    /// string or an object with `email` and optional `name`.
    /// </summary>
    public required To To {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<To>(
                "to"
            );
        }
        init { this._rawBodyData.Set("to", value); }
    }

    /// <summary>
    /// One recipient or a recipient array. Each recipient may be an email string
    /// or an object with `email` and optional `name`.
    /// </summary>
    public InboxActionRecipientInput? Bcc {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InboxActionRecipientInput>(
                "bcc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("bcc", value);
        }
    }

    /// <summary>
    /// One recipient or a recipient array. Each recipient may be an email string
    /// or an object with `email` and optional `name`.
    /// </summary>
    public InboxActionRecipientInput? Cc {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InboxActionRecipientInput>(
                "cc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("cc", value);
        }
    }

    /// <summary>
    /// Optional HTML note prepended to the generated forwarded-message block. Blank
    /// values are treated as omitted.
    /// </summary>
    public string? Html {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "html"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("html", value);
        }
    }

    /// <summary>
    /// Optional plain-text note prepended to the generated forwarded-message block.
    /// Blank values are treated as omitted.
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

    public ActionForwardParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionForwardParams (ActionForwardParams actionForwardParams) : base(
        actionForwardParams
    )
    {
        this.InboxID = actionForwardParams.InboxID;
        this.MessageID = actionForwardParams.MessageID;

        this._rawBodyData = new(actionForwardParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionForwardParams (
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionForwardParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string inboxID,
        string messageID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.InboxID = inboxID;
        this.MessageID = messageID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActionForwardParams FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string inboxID,
        string messageID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            inboxID,
            messageID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Generic::Dictionary<string, JsonElement>(

    )
    {
        ["InboxID"] = JsonSerializer.SerializeToElement(this.InboxID),
        ["MessageID"] = JsonSerializer.SerializeToElement(this.MessageID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ActionForwardParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.InboxID.Equals(other.InboxID)&&(this.MessageID?.Equals(other.MessageID) ?? other.MessageID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/email_inboxes/{0}/messages/{1}/actions/forward",
            EncodePathSegment(this.InboxID),
            EncodePathSegment(this.MessageID))
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
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
/// One recipient or a non-empty recipient array. Each recipient may be an email string
/// or an object with `email` and optional `name`.
/// </summary>
[JsonConverter(typeof(ToConverter))]
public record class To : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public To (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To (InboxRecipientAddress value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To (
        Generic::IReadOnlyList<InboxActionEmailAddressInput> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public To (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="InboxRecipientAddress"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickInboxRecipientAddress(out var value)) {
///     // `value` is of type `InboxRecipientAddress`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickInboxRecipientAddress(
        [NotNullWhen(true)] out InboxRecipientAddress? value
    )
    {
        value =this.Value as InboxRecipientAddress ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>InboxActionEmailAddressInput</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickRequiredInboxRecipientList(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;InboxActionEmailAddressInput&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickRequiredInboxRecipientList(
        [NotNullWhen(true)] out Generic::IReadOnlyList<InboxActionEmailAddressInput>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<InboxActionEmailAddressInput> ;
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
///     (string value) =&gt; {...},
///     (InboxRecipientAddress value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;InboxActionEmailAddressInput&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<InboxRecipientAddress> inboxRecipientAddress,
        System::Action<Generic::IReadOnlyList<InboxActionEmailAddressInput>> requiredInboxRecipientList
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case InboxRecipientAddress value:
                inboxRecipientAddress(value);
                break;
            case Generic::IReadOnlyList<InboxActionEmailAddressInput> value:
                requiredInboxRecipientList(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of To");

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
///     (string value) =&gt; {...},
///     (InboxRecipientAddress value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;InboxActionEmailAddressInput&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<InboxRecipientAddress, T> inboxRecipientAddress,
        System::Func<Generic::IReadOnlyList<InboxActionEmailAddressInput>, T> requiredInboxRecipientList
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            InboxRecipientAddress value=>inboxRecipientAddress(value),
            Generic::IReadOnlyList<InboxActionEmailAddressInput> value=>requiredInboxRecipientList(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of To")
        } ;
    }

    public static implicit operator To (string value)=> new(value) ;

    public static implicit operator To (
        InboxRecipientAddress value
    )=> new(value) ;

    public static implicit operator To (
        Generic::List<InboxActionEmailAddressInput> value
    )=> new((Generic::IReadOnlyList<InboxActionEmailAddressInput>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of To");
        }
        this.Switch((_) => {},
        (inboxRecipientAddress) => inboxRecipientAddress.Validate(),
        (requiredInboxRecipientList) => {foreach (var item in requiredInboxRecipientList)
        {
            item.Validate();
        }});
    }

    public virtual bool Equals(To? other)
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
            string _=>0,
            InboxRecipientAddress _=>1,
            Generic::IReadOnlyList<InboxActionEmailAddressInput> _=>2,
            _ =>-1
        } ;
    }
}

sealed class ToConverter : JsonConverter<To>
{
    public override To? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<InboxRecipientAddress>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<InboxActionEmailAddressInput>>(element, options);
            if (deserialized != null) {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, To value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(JsonModelConverter<InboxRecipientAddress, InboxRecipientAddressFromRaw>))]
public sealed record class InboxRecipientAddress : JsonModel
{
    public required string Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "email"
            );
        }
        init { this._rawData.Set("email", value); }
    }

    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.Name;
    }

    public InboxRecipientAddress ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboxRecipientAddress (
        InboxRecipientAddress inboxRecipientAddress
    ) : base(inboxRecipientAddress)
    {  }
    #pragma warning restore CS8618

    public InboxRecipientAddress (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InboxRecipientAddress (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboxRecipientAddressFromRaw.FromRawUnchecked"/>
    public static InboxRecipientAddress FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public InboxRecipientAddress (string email) : this()
    { this.Email = email; }
}

class InboxRecipientAddressFromRaw : IFromRawJson<InboxRecipientAddress>
{
    /// <inheritdoc/>
    public InboxRecipientAddress FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InboxRecipientAddress.FromRawUnchecked(rawData);
}