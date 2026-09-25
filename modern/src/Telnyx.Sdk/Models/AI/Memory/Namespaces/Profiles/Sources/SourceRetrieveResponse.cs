using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles.Sources;

[JsonConverter(typeof(JsonModelConverter<SourceRetrieveResponse, SourceRetrieveResponseFromRaw>))]
public sealed record class SourceRetrieveResponse : JsonModel
{
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public SourceRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SourceRetrieveResponse (
        SourceRetrieveResponse sourceRetrieveResponse
    ) : base(sourceRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public SourceRetrieveResponse (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SourceRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SourceRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SourceRetrieveResponse FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public SourceRetrieveResponse (Data data) : this()
    { this.Data = data; }
}

class SourceRetrieveResponseFromRaw : IFromRawJson<SourceRetrieveResponse>
{
    /// <inheritdoc/>
    public SourceRetrieveResponse FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SourceRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Identifies one source within its profile: an ingested session, or one remembered
    /// fact. Returned by `ingest` and `remember` when the write is accepted. Re-ingesting
    /// a session keeps its source id.
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
    /// What was stored, in the shape it was sent: an ingested JSON body as JSON,
    /// a string body or a remembered fact as a string. A session ingested before
    /// formats were recorded is returned as the text it was stored as.
    /// </summary>
    public required Content Content {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Content>(
                "content"
            );
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// Memories extracted from this source. A memory derived from several sources
    /// is not counted here.
    /// </summary>
    public required long MemoryCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "memory_count"
            );
        }
        init { this._rawData.Set("memory_count", value); }
    }

    /// <summary>
    /// The session this source was ingested as. Null for a remembered fact.
    /// </summary>
    public required string? SessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "session_id"
            );
        }
        init { this._rawData.Set("session_id", value); }
    }

    /// <summary>
    /// When the source was first stored.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// When the source was last written; re-ingesting moves it.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Content.Validate();
        _ = this.MemoryCount;
        _ = this.SessionID;
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}/// <summary>
/// What was stored, in the shape it was sent: an ingested JSON body as JSON, a string
/// body or a remembered fact as a string. A session ingested before formats were
/// recorded is returned as the text it was stored as.
/// </summary>
[JsonConverter(typeof(ContentConverter))]
public record class Content : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Content (
        Generic::IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public Content (UnionMember1 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content (JsonElement element)
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
                throw new TelnyxInvalidDataException("Data did not match any variant of Content");

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
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Content")
        } ;
    }

    public static implicit operator Content (
        Generic::Dictionary<string, JsonElement> value
    )=> new((Generic::IReadOnlyDictionary<string, JsonElement>)value) ;

    public static implicit operator Content (UnionMember1 value)=> new(value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Content");
        }
        this.Switch((_) => {}, (unionMember1) => unionMember1.Validate());
    }

    public virtual bool Equals(Content? other)
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
}sealed class ContentConverter : JsonConverter<Content>
{
    public override Content? Read(
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
        Utf8JsonWriter writer, Content value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(UnionMember1Converter))]
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
}sealed class UnionMember1Converter : JsonConverter<UnionMember1>
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