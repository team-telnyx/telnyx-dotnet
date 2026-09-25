using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging10dlc;

[JsonConverter(typeof(Messaging10dlcGetEnumResponseConverter))]
public record class Messaging10dlcGetEnumResponse : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Messaging10dlcGetEnumResponse (
        Generic::IReadOnlyList<string> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Messaging10dlcGetEnumResponse (
        Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)));
        this._element = element;
    }

    public Messaging10dlcGetEnumResponse (
        Generic::IReadOnlyDictionary<string, string> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public Messaging10dlcGetEnumResponse (
        Generic::IReadOnlyDictionary<string, Generic::IReadOnlyDictionary<string, JsonElement>> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value, entry => entry.Key, ( entry )=>FrozenDictionary.ToFrozenDictionary(entry.Value));
        this._element = element;
    }

    public Messaging10dlcGetEnumResponse (
        EnumPaginatedResponse value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Messaging10dlcGetEnumResponse (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>string</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickEnumStringList(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;string&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickEnumStringList(
        [NotNullWhen(true)] out Generic::IReadOnlyList<string>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<string> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>Generic::Dictionary&lt;string, JsonElement&gt;</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickEnumObjectList(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickEnumObjectList(
        [NotNullWhen(true)] out Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>string</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickEnumObjectToString(out var value)) {
///     // `value` is of type `Generic::IReadOnlyDictionary&lt;string, string&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickEnumObjectToString(
        [NotNullWhen(true)] out Generic::IReadOnlyDictionary<string, string>? value
    )
    {
        value =this.Value as Generic::IReadOnlyDictionary<string, string> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>Generic::Dictionary&lt;string, JsonElement&gt;</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickEnumObjecToObjectt(out var value)) {
///     // `value` is of type `Generic::IReadOnlyDictionary&lt;string, Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickEnumObjecToObjectt(
        [NotNullWhen(true)] out Generic::IReadOnlyDictionary<string, Generic::IReadOnlyDictionary<string, JsonElement>>? value
    )
    {
        value =this.Value as Generic::IReadOnlyDictionary<string, Generic::IReadOnlyDictionary<string, JsonElement>> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="EnumPaginatedResponse"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickEnumPaginated(out var value)) {
///     // `value` is of type `EnumPaginatedResponse`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickEnumPaginated(
        [NotNullWhen(true)] out EnumPaginatedResponse? value
    )
    {
        value =this.Value as EnumPaginatedResponse ;
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
///     (Generic::IReadOnlyList&lt;string&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt; value) =&gt; {...},
///     (Generic::IReadOnlyDictionary&lt;string, string&gt; value) =&gt; {...},
///     (Generic::IReadOnlyDictionary&lt;string, Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt; value) =&gt; {...},
///     (EnumPaginatedResponse value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Generic::IReadOnlyList<string>> enumStringListResponse,
        System::Action<Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>> enumObjectListResponse,
        System::Action<Generic::IReadOnlyDictionary<string, string>> enumObjectToStringResponse,
        System::Action<Generic::IReadOnlyDictionary<string, Generic::IReadOnlyDictionary<string, JsonElement>>> enumObjecToObjecttResponse,
        System::Action<EnumPaginatedResponse> enumPaginated
    )
    {
        switch (this.Value)
        {
            case Generic::IReadOnlyList<string> value:
                enumStringListResponse(value);
                break;
            case Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> value:
                enumObjectListResponse(value);
                break;
            case Generic::IReadOnlyDictionary<string, string> value:
                enumObjectToStringResponse(value);
                break;
            case Generic::IReadOnlyDictionary<string, Generic::IReadOnlyDictionary<string, JsonElement>> value:
                enumObjecToObjecttResponse(value);
                break;
            case EnumPaginatedResponse value:
                enumPaginated(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Messaging10dlcGetEnumResponse");

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
///     (Generic::IReadOnlyList&lt;string&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt; value) =&gt; {...},
///     (Generic::IReadOnlyDictionary&lt;string, string&gt; value) =&gt; {...},
///     (Generic::IReadOnlyDictionary&lt;string, Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt; value) =&gt; {...},
///     (EnumPaginatedResponse value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<Generic::IReadOnlyList<string>, T> enumStringListResponse,
        System::Func<Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>, T> enumObjectListResponse,
        System::Func<Generic::IReadOnlyDictionary<string, string>, T> enumObjectToStringResponse,
        System::Func<Generic::IReadOnlyDictionary<string, Generic::IReadOnlyDictionary<string, JsonElement>>, T> enumObjecToObjecttResponse,
        System::Func<EnumPaginatedResponse, T> enumPaginated
    )
    {
        return this.Value switch
        {
            Generic::IReadOnlyList<string> value=>enumStringListResponse(value),
            Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> value=>enumObjectListResponse(value),
            Generic::IReadOnlyDictionary<string, string> value=>enumObjectToStringResponse(value),
            Generic::IReadOnlyDictionary<string, Generic::IReadOnlyDictionary<string, JsonElement>> value=>enumObjecToObjecttResponse(value),
            EnumPaginatedResponse value=>enumPaginated(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Messaging10dlcGetEnumResponse")
        } ;
    }

    public static implicit operator Messaging10dlcGetEnumResponse (
        Generic::List<string> value
    )=> new((Generic::IReadOnlyList<string>)value) ;

    public static implicit operator Messaging10dlcGetEnumResponse (
        Generic::List<Generic::Dictionary<string, JsonElement>> value
    )=> new((Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>)value) ;

    public static implicit operator Messaging10dlcGetEnumResponse (
        Generic::Dictionary<string, string> value
    )=> new((Generic::IReadOnlyDictionary<string, string>)value) ;

    public static implicit operator Messaging10dlcGetEnumResponse (
        Generic::Dictionary<string, Generic::Dictionary<string, JsonElement>> value
    )=> new((Generic::IReadOnlyDictionary<string, Generic::IReadOnlyDictionary<string, JsonElement>>)value) ;

    public static implicit operator Messaging10dlcGetEnumResponse (
        EnumPaginatedResponse value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of Messaging10dlcGetEnumResponse");
        }
        this.Switch((_) => {},
        (_) => {},
        (_) => {},
        (_) => {},
        (enumPaginated) => enumPaginated.Validate());
    }

    public virtual bool Equals(Messaging10dlcGetEnumResponse? other)
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
            Generic::IReadOnlyList<string> _=>0,
            Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> _=>1,
            Generic::IReadOnlyDictionary<string, string> _=>2,
            Generic::IReadOnlyDictionary<string, Generic::IReadOnlyDictionary<string, JsonElement>> _=>3,
            EnumPaginatedResponse _=>4,
            _ =>-1
        } ;
    }
}

sealed class Messaging10dlcGetEnumResponseConverter : JsonConverter<Messaging10dlcGetEnumResponse>
{
    public override Messaging10dlcGetEnumResponse? Read(
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
            var deserialized = JsonSerializer.Deserialize<EnumPaginatedResponse>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<string>>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyDictionary<string, string>>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyDictionary<string, Generic::IReadOnlyDictionary<string, JsonElement>>>(element, options);
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
        Utf8JsonWriter writer,
        Messaging10dlcGetEnumResponse value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(JsonModelConverter<EnumPaginatedResponse, EnumPaginatedResponseFromRaw>))]
public sealed record class EnumPaginatedResponse : JsonModel
{
    public required long Page {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "page"
            );
        }
        init { this._rawData.Set("page", value); }
    }

    public required Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> Records {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "records"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "records",
                ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
            );
        }
    }

    public required long TotalRecords {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "totalRecords"
            );
        }
        init { this._rawData.Set("totalRecords", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Page;
        _ = this.Records;
        _ = this.TotalRecords;
    }

    public EnumPaginatedResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnumPaginatedResponse (
        EnumPaginatedResponse enumPaginatedResponse
    ) : base(enumPaginatedResponse)
    {  }
    #pragma warning restore CS8618

    public EnumPaginatedResponse (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EnumPaginatedResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EnumPaginatedResponseFromRaw.FromRawUnchecked"/>
    public static EnumPaginatedResponse FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EnumPaginatedResponseFromRaw : IFromRawJson<EnumPaginatedResponse>
{
    /// <inheritdoc/>
    public EnumPaginatedResponse FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EnumPaginatedResponse.FromRawUnchecked(rawData);
}