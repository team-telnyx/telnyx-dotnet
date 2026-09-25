using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Conversations;

/// <summary>
/// Add a new message to the conversation. Used to insert a new messages to a conversation
/// manually ( without using chat endpoint )
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ConversationAddMessageParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public Generic::IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ConversationID { get; init; }

    public required string Role {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "role"
            );
        }
        init { this._rawBodyData.Set("role", value); }
    }

    public string? Content {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "content"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("content", value);
        }
    }

    public Generic::IReadOnlyDictionary<string, Metadata>? Metadata {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, Metadata>>(
                "metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, Metadata>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    public System::DateTimeOffset? SentAt {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>(
                "sent_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sent_at", value);
        }
    }

    public string? ToolCallID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "tool_call_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("tool_call_id", value);
        }
    }

    public Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>? ToolCalls {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "tool_calls"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "tool_calls",
                value == null ? null : ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
            );
        }
    }

    public ToolChoice? ToolChoice {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ToolChoice>(
                "tool_choice"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("tool_choice", value);
        }
    }

    public string? IdempotencyKey {
        get {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>(
                "Idempotency-Key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawHeaderData.Set("Idempotency-Key", value);
        }
    }

    public ConversationAddMessageParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationAddMessageParams (
        ConversationAddMessageParams conversationAddMessageParams
    ) : base(conversationAddMessageParams)
    {
        this.ConversationID = conversationAddMessageParams.ConversationID;

        this._rawBodyData = new(conversationAddMessageParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ConversationAddMessageParams (
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
    ConversationAddMessageParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string conversationID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ConversationID = conversationID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ConversationAddMessageParams FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string conversationID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            conversationID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Generic::Dictionary<string, JsonElement>(

    )
    {
        ["ConversationID"] = JsonSerializer.SerializeToElement(this.ConversationID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ConversationAddMessageParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ConversationID?.Equals(other.ConversationID) ?? other.ConversationID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/ai/conversations/{0}/message",
            this.ConversationID)
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

[JsonConverter(typeof(MetadataConverter))]
public record class Metadata : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Metadata (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Metadata (long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Metadata (bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Metadata (
        Generic::IReadOnlyList<UnnamedSchemaWithArrayParent2> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Metadata (JsonElement element)
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
/// type <see cref="long"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickLong(out var value)) {
///     // `value` is of type `long`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value =this.Value as long? ;
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
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>UnnamedSchemaWithArrayParent2</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickArrayValue(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;UnnamedSchemaWithArrayParent2&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickArrayValue(
        [NotNullWhen(true)] out Generic::IReadOnlyList<UnnamedSchemaWithArrayParent2>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<UnnamedSchemaWithArrayParent2> ;
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
///     (long value) =&gt; {...},
///     (bool value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;UnnamedSchemaWithArrayParent2&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<long> @long,
        System::Action<bool> @bool,
        System::Action<Generic::IReadOnlyList<UnnamedSchemaWithArrayParent2>> metadataArrayValue
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case long value:
                @long(value);
                break;
            case bool value:
                @bool(value);
                break;
            case Generic::IReadOnlyList<UnnamedSchemaWithArrayParent2> value:
                metadataArrayValue(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Metadata");

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
///     (long value) =&gt; {...},
///     (bool value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;UnnamedSchemaWithArrayParent2&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<long, T> @long,
        System::Func<bool, T> @bool,
        System::Func<Generic::IReadOnlyList<UnnamedSchemaWithArrayParent2>, T> metadataArrayValue
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            long value=>@long(value),
            bool value=>@bool(value),
            Generic::IReadOnlyList<UnnamedSchemaWithArrayParent2> value=>metadataArrayValue(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Metadata")
        } ;
    }

    public static implicit operator Metadata (string value)=> new(value) ;

    public static implicit operator Metadata (long value)=> new(value) ;

    public static implicit operator Metadata (bool value)=> new(value) ;

    public static implicit operator Metadata (
        Generic::List<UnnamedSchemaWithArrayParent2> value
    )=> new((Generic::IReadOnlyList<UnnamedSchemaWithArrayParent2>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Metadata");
        }
        this.Switch((_) => {},
        (_) => {},
        (_) => {},
        (metadataArrayValue) => {foreach (var item in metadataArrayValue)
        {
            item.Validate();
        }});
    }

    public virtual bool Equals(Metadata? other)
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
            long _=>1,
            bool _=>2,
            Generic::IReadOnlyList<UnnamedSchemaWithArrayParent2> _=>3,
            _ =>-1
        } ;
    }
}

sealed class MetadataConverter : JsonConverter<Metadata>
{
    public override Metadata? Read(
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
            return new(JsonSerializer.Deserialize<long>(element, options), element);
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

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<UnnamedSchemaWithArrayParent2>>(element, options);
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
        Utf8JsonWriter writer, Metadata value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(UnnamedSchemaWithArrayParent2Converter))]
public record class UnnamedSchemaWithArrayParent2 : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public UnnamedSchemaWithArrayParent2 (
        string value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent2 (
        long value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent2 (
        bool value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent2 (JsonElement element)
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
/// type <see cref="long"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickLong(out var value)) {
///     // `value` is of type `long`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value =this.Value as long? ;
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
///     (string value) =&gt; {...},
///     (long value) =&gt; {...},
///     (bool value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<long> @long,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case long value:
                @long(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of UnnamedSchemaWithArrayParent2");

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
///     (long value) =&gt; {...},
///     (bool value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<long, T> @long,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            long value=>@long(value),
            bool value=>@bool(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of UnnamedSchemaWithArrayParent2")
        } ;
    }

    public static implicit operator UnnamedSchemaWithArrayParent2 (
        string value
    )=> new(value) ;

    public static implicit operator UnnamedSchemaWithArrayParent2 (
        long value
    )=> new(value) ;

    public static implicit operator UnnamedSchemaWithArrayParent2 (
        bool value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of UnnamedSchemaWithArrayParent2");
        }
    }

    public virtual bool Equals(UnnamedSchemaWithArrayParent2? other)
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
        { string _=>0, long _=>1, bool _=>2, _ =>-1 } ;
    }
}

sealed class UnnamedSchemaWithArrayParent2Converter : JsonConverter<UnnamedSchemaWithArrayParent2>
{
    public override UnnamedSchemaWithArrayParent2? Read(
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
            return new(JsonSerializer.Deserialize<long>(element, options), element);
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
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent2 value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(ToolChoiceConverter))]
public record class ToolChoice : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public ToolChoice (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolChoice (
        Generic::IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public ToolChoice (JsonElement element)
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
/// type <see cref="Generic::Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonElement</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickObject(out var value)) {
///     // `value` is of type `Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickObject(
        [NotNullWhen(true)] out Generic::IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value =this.Value as Generic::IReadOnlyDictionary<string, JsonElement> ;
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
///     (Generic::IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<Generic::IReadOnlyDictionary<string, JsonElement>> toolChoiceObject
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case Generic::IReadOnlyDictionary<string, JsonElement> value:
                toolChoiceObject(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of ToolChoice");

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
///     (Generic::IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<Generic::IReadOnlyDictionary<string, JsonElement>, T> toolChoiceObject
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            Generic::IReadOnlyDictionary<string, JsonElement> value=>toolChoiceObject(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of ToolChoice")
        } ;
    }

    public static implicit operator ToolChoice (string value)=> new(value) ;

    public static implicit operator ToolChoice (
        Generic::Dictionary<string, JsonElement> value
    )=> new((Generic::IReadOnlyDictionary<string, JsonElement>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of ToolChoice");
        }
    }

    public virtual bool Equals(ToolChoice? other)
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
            Generic::IReadOnlyDictionary<string, JsonElement> _=>1,
            _ =>-1
        } ;
    }
}

sealed class ToolChoiceConverter : JsonConverter<ToolChoice>
{
    public override ToolChoice? Read(
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
        Utf8JsonWriter writer, ToolChoice value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}