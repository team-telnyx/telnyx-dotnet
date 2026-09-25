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

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles;

/// <summary>
/// Store a session. Facts are extracted from whatever you send — the body is taken
/// as any JSON value and stored whole, so a framework's own transcript shape works
/// unchanged. `messages` of `role`/`content` is the conventional shape, not a requirement.
/// An empty object or a null body is refused. Carry a `session_id` to name the session:
/// re-ingesting the same one replaces what it held. Omit it and a session is opened
/// and returned. Extraction runs asynchronously — poll the returned operation.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ProfileIngestParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public required string Namespace { get; init; }

    public string? ProfileID { get; init; }

    /// <summary>
    /// The session's messages, in whatever shape your framework produces. Any JSON
    /// value but null is accepted and stored whole, as long as it holds something
    /// to remember: a body with no content anywhere in it -- `{}`, `[]`, `""`, `{"messages":
    /// []}` -- is a 422.
    /// </summary>
    public required Body Body {
        get {
            return WrappedJsonSerializer.GetNotNullClass<Body>(this.RawBodyData, "RawBodyData");
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Names the session. Re-ingesting the same session replaces what it held and
    /// keeps its `source_id`. Omit it to have one derived from the content and returned.
    /// No whitespace, control characters, or any of / \ # ? %.
    /// </summary>
    public string? SessionID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "session_id"
            );
        }
        init { this._rawQueryData.Set("session_id", value); }
    }

    public ProfileIngestParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileIngestParams (ProfileIngestParams profileIngestParams) : base(
        profileIngestParams
    )
    {
        this.Namespace = profileIngestParams.Namespace;
        this.ProfileID = profileIngestParams.ProfileID;

        this.RawBodyData = profileIngestParams.RawBodyData;
    }
    #pragma warning restore CS8618

    public ProfileIngestParams (
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileIngestParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string namespace_,
        string profileID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
        this.Namespace = namespace_;
        this.ProfileID = profileID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ProfileIngestParams FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string namespace_,
        string profileID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData,
            namespace_,
            profileID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Generic::Dictionary<string, JsonElement>(

    )
    {
        ["Namespace"] = JsonSerializer.SerializeToElement(this.Namespace),
        ["ProfileID"] = JsonSerializer.SerializeToElement(this.ProfileID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ProfileIngestParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.Namespace.Equals(other.Namespace)&&(this.ProfileID?.Equals(other.ProfileID) ?? other.ProfileID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this.RawBodyData.Equals(
            other.RawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/ai/memory/namespaces/{0}/profiles/{1}/ingest",
            this.Namespace,
            this.ProfileID)
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
/// The session's messages, in whatever shape your framework produces. Any JSON value
/// but null is accepted and stored whole, as long as it holds something to remember:
/// a body with no content anywhere in it -- `{}`, `[]`, `""`, `{"messages": []}`
/// -- is a 422.
/// </summary>
[JsonConverter(typeof(BodyConverter))]
public record class Body : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Body (
        Generic::IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public Body (UnionMember1 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonElement</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickJsonElements(out var value)) {
///     // `value` is of type `Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out Generic::IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value =this.Value as Generic::IReadOnlyDictionary<string, JsonElement> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="UnionMember1"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickUnionMember1(out var value)) {
///     // `value` is of type `UnionMember1`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickUnionMember1([NotNullWhen(true)] out UnionMember1? value)
    {
        value =this.Value as UnionMember1 ;
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
///     (Generic::IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
///     (UnionMember1 value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Generic::IReadOnlyDictionary<string, JsonElement>> jsonElements,
        System::Action<UnionMember1> unionMember1
    )
    {
        switch (this.Value)
        {
            case Generic::IReadOnlyDictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            case UnionMember1 value:
                unionMember1(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Body");

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
///     (Generic::IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
///     (UnionMember1 value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<Generic::IReadOnlyDictionary<string, JsonElement>, T> jsonElements,
        System::Func<UnionMember1, T> unionMember1
    )
    {
        return this.Value switch
        {
            Generic::IReadOnlyDictionary<string, JsonElement> value=>jsonElements(value),
            UnionMember1 value=>unionMember1(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Body")
        } ;
    }

    public static implicit operator Body (
        Generic::Dictionary<string, JsonElement> value
    )=> new((Generic::IReadOnlyDictionary<string, JsonElement>)value) ;

    public static implicit operator Body (UnionMember1 value)=> new(value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Body");
        }
        this.Switch((_) => {}, (unionMember1) => unionMember1.Validate());
    }

    public virtual bool Equals(Body? other)
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
            Generic::IReadOnlyDictionary<string, JsonElement> _=>0,
            UnionMember1 _=>1,
            _ =>-1
        } ;
    }
}

sealed class BodyConverter : JsonConverter<Body>
{
    public override Body? Read(
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
            var deserialized = JsonSerializer.Deserialize<UnionMember1>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyDictionary<string, JsonElement>>(element, options);
            if (deserialized != null) {

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
        Utf8JsonWriter writer, Body value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(UnionMember1Converter))]
public record class UnionMember1 : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public UnionMember1 (
        Generic::IReadOnlyList<JsonElement> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public UnionMember1 (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnionMember1 (double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnionMember1 (bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnionMember1 (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>JsonElement</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickJsonElements(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;JsonElement&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out Generic::IReadOnlyList<JsonElement>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<JsonElement> ;
        return value != null ;
    }

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
/// type <see cref="double"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickDouble(out var value)) {
///     // `value` is of type `double`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value =this.Value as double? ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="bool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickBool(out var value)) {
///     // `value` is of type `bool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value =this.Value as bool? ;
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
///     (Generic::IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...},
///     (string value) =&gt; {...},
///     (double value) =&gt; {...},
///     (bool value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Generic::IReadOnlyList<JsonElement>> jsonElements,
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case Generic::IReadOnlyList<JsonElement> value:
                jsonElements(value);
                break;
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of UnionMember1");

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
///     (Generic::IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...},
///     (string value) =&gt; {...},
///     (double value) =&gt; {...},
///     (bool value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<Generic::IReadOnlyList<JsonElement>, T> jsonElements,
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            Generic::IReadOnlyList<JsonElement> value=>jsonElements(value),
            string value=>@string(value),
            double value=>@double(value),
            bool value=>@bool(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of UnionMember1")
        } ;
    }

    public static implicit operator UnionMember1 (
        Generic::List<JsonElement> value
    )=> new((Generic::IReadOnlyList<JsonElement>)value) ;

    public static implicit operator UnionMember1 (string value)=> new(value) ;

    public static implicit operator UnionMember1 (double value)=> new(value) ;

    public static implicit operator UnionMember1 (bool value)=> new(value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of UnionMember1");
        }
    }

    public virtual bool Equals(UnionMember1? other)
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
            Generic::IReadOnlyList<JsonElement> _=>0,
            string _=>1,
            double _=>2,
            bool _=>3,
            _ =>-1
        } ;
    }
}

sealed class UnionMember1Converter : JsonConverter<UnionMember1>
{
    public override UnionMember1? Read(
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<JsonElement>>(element, options);
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
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, UnionMember1 value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}