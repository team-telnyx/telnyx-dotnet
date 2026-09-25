using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Portouts;

/// <summary>
/// Given a port-out ID, list rejection codes that are eligible for that port-out
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PortoutListRejectionCodesParams : ParamsBase
{
    public string? PortoutID { get; init; }

    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[code], filter[code][in]
    /// </summary>
    public PortoutListRejectionCodesParamsFilter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<PortoutListRejectionCodesParamsFilter>(
                "filter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter", value);
        }
    }

    public PortoutListRejectionCodesParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortoutListRejectionCodesParams (
        PortoutListRejectionCodesParams portoutListRejectionCodesParams
    ) : base(portoutListRejectionCodesParams)
    { this.PortoutID = portoutListRejectionCodesParams.PortoutID; }
    #pragma warning restore CS8618

    public PortoutListRejectionCodesParams (
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortoutListRejectionCodesParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string portoutID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.PortoutID = portoutID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PortoutListRejectionCodesParams FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string portoutID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            portoutID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Generic::Dictionary<string, JsonElement>(

    )
    {
        ["PortoutID"] = JsonSerializer.SerializeToElement(this.PortoutID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(PortoutListRejectionCodesParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.PortoutID?.Equals(other.PortoutID) ?? other.PortoutID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/portouts/rejections/{0}",
            this.PortoutID)
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
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
/// Consolidated filter parameter (deepObject style). Originally: filter[code], filter[code][in]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PortoutListRejectionCodesParamsFilter, PortoutListRejectionCodesParamsFilterFromRaw>))]
public sealed record class PortoutListRejectionCodesParamsFilter : JsonModel
{
    /// <summary>
    /// Filter rejections of a specific code
    /// </summary>
    public Code? Code {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Code>(
                "code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Code?.Validate(); }

    public PortoutListRejectionCodesParamsFilter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortoutListRejectionCodesParamsFilter (
        PortoutListRejectionCodesParamsFilter portoutListRejectionCodesParamsFilter
    ) : base(portoutListRejectionCodesParamsFilter)
    {  }
    #pragma warning restore CS8618

    public PortoutListRejectionCodesParamsFilter (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortoutListRejectionCodesParamsFilter (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortoutListRejectionCodesParamsFilterFromRaw.FromRawUnchecked"/>
    public static PortoutListRejectionCodesParamsFilter FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortoutListRejectionCodesParamsFilterFromRaw : IFromRawJson<PortoutListRejectionCodesParamsFilter>
{
    /// <inheritdoc/>
    public PortoutListRejectionCodesParamsFilter FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortoutListRejectionCodesParamsFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter rejections of a specific code
/// </summary>
[JsonConverter(typeof(CodeConverter))]
public record class Code : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Code (long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Code (
        Generic::IReadOnlyList<long> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Code (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="long"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickOne(out var value)) {
///     // `value` is of type `long`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickOne([NotNullWhen(true)] out long? value)
    {
        value =this.Value as long? ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>long</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickListOfCodes(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;long&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickListOfCodes(
        [NotNullWhen(true)] out Generic::IReadOnlyList<long>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<long> ;
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
///     (long value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;long&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<long> @oneCode,
        System::Action<Generic::IReadOnlyList<long>> listOfCodes
    )
    {
        switch (this.Value)
        {
            case long value:
                @oneCode(value);
                break;
            case Generic::IReadOnlyList<long> value:
                listOfCodes(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Code");

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
///     (long value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;long&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<long, T> @oneCode,
        System::Func<Generic::IReadOnlyList<long>, T> listOfCodes
    )
    {
        return this.Value switch
        {
            long value=>@oneCode(value),
            Generic::IReadOnlyList<long> value=>listOfCodes(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Code")
        } ;
    }

    public static implicit operator Code (long value)=> new(value) ;

    public static implicit operator Code (
        Generic::List<long> value
    )=> new((Generic::IReadOnlyList<long>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Code");
        }
    }

    public virtual bool Equals(Code? other)
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
        { long _=>0, Generic::IReadOnlyList<long> _=>1, _ =>-1 } ;
    }
}

sealed class CodeConverter : JsonConverter<Code>
{
    public override Code? Read(
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
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<long>>(element, options);
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
        Utf8JsonWriter writer, Code value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}