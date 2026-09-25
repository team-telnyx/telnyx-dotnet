using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AccessIPRanges;

/// <summary>
/// Retrieve a paginated list of access IP ranges configured on your account.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AccessIPRangeListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[cidr_block],
    /// filter[cidr_block][startswith], filter[cidr_block][endswith], filter[cidr_block][contains],
    /// filter[created_at]. Supports complex bracket operations for dynamic filtering.
    /// </summary>
    public Filter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Filter>(
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

    public long? PageNumber {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[number]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[number]", value);
        }
    }

    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[size]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[size]", value);
        }
    }

    public AccessIPRangeListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccessIPRangeListParams (
        AccessIPRangeListParams accessIPRangeListParams
    ) : base(accessIPRangeListParams)
    {  }
    #pragma warning restore CS8618

    public AccessIPRangeListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AccessIPRangeListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AccessIPRangeListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(AccessIPRangeListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/access_ip_ranges"
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
/// Consolidated filter parameter (deepObject style). Originally: filter[cidr_block],
/// filter[cidr_block][startswith], filter[cidr_block][endswith], filter[cidr_block][contains],
/// filter[created_at]. Supports complex bracket operations for dynamic filtering.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Filter by exact CIDR block match
    /// </summary>
    public CidrBlock? CidrBlock {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CidrBlock>(
                "cidr_block"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cidr_block", value);
        }
    }

    /// <summary>
    /// Filter by exact creation date-time
    /// </summary>
    public CreatedAt? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreatedAt>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CidrBlock?.Validate();
        this.CreatedAt?.Validate();
    }

    public Filter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter (Filter filter) : base(filter)
    {  }
    #pragma warning restore CS8618

    public Filter (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by exact CIDR block match
/// </summary>
[JsonConverter(typeof(CidrBlockConverter))]
public record class CidrBlock : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public CidrBlock (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CidrBlock (CidrBlockPatternFilter value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CidrBlock (JsonElement element)
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
/// type <see cref="CidrBlockPatternFilter"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickPatternFilter(out var value)) {
///     // `value` is of type `CidrBlockPatternFilter`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickPatternFilter(
        [NotNullWhen(true)] out CidrBlockPatternFilter? value
    )
    {
        value =this.Value as CidrBlockPatternFilter ;
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
///     (CidrBlockPatternFilter value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<CidrBlockPatternFilter> patternFilter
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case CidrBlockPatternFilter value:
                patternFilter(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of CidrBlock");

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
///     (CidrBlockPatternFilter value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<CidrBlockPatternFilter, T> patternFilter
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            CidrBlockPatternFilter value=>patternFilter(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of CidrBlock")
        } ;
    }

    public static implicit operator CidrBlock (string value)=> new(value) ;

    public static implicit operator CidrBlock (
        CidrBlockPatternFilter value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of CidrBlock");
        }
        this.Switch((_) => {}, (patternFilter) => patternFilter.Validate());
    }

    public virtual bool Equals(CidrBlock? other)
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
        { string _=>0, CidrBlockPatternFilter _=>1, _ =>-1 } ;
    }
}

sealed class CidrBlockConverter : JsonConverter<CidrBlock>
{
    public override CidrBlock? Read(
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
            var deserialized = JsonSerializer.Deserialize<CidrBlockPatternFilter>(element, options);
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

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, CidrBlock value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// CIDR block pattern matching operations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CidrBlockPatternFilter, CidrBlockPatternFilterFromRaw>))]
public sealed record class CidrBlockPatternFilter : JsonModel
{
    /// <summary>
    /// Filter CIDR blocks containing the specified string
    /// </summary>
    public string? Contains {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "contains"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("contains", value);
        }
    }

    /// <summary>
    /// Filter CIDR blocks ending with the specified string
    /// </summary>
    public string? Endswith {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "endswith"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("endswith", value);
        }
    }

    /// <summary>
    /// Filter CIDR blocks starting with the specified string
    /// </summary>
    public string? Startswith {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "startswith"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("startswith", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Contains;
        _ = this.Endswith;
        _ = this.Startswith;
    }

    public CidrBlockPatternFilter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CidrBlockPatternFilter (
        CidrBlockPatternFilter cidrBlockPatternFilter
    ) : base(cidrBlockPatternFilter)
    {  }
    #pragma warning restore CS8618

    public CidrBlockPatternFilter (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CidrBlockPatternFilter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CidrBlockPatternFilterFromRaw.FromRawUnchecked"/>
    public static CidrBlockPatternFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CidrBlockPatternFilterFromRaw : IFromRawJson<CidrBlockPatternFilter>
{
    /// <inheritdoc/>
    public CidrBlockPatternFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CidrBlockPatternFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by exact creation date-time
/// </summary>
[JsonConverter(typeof(CreatedAtConverter))]
public record class CreatedAt : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public CreatedAt (System::DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreatedAt (DateRangeFilter value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreatedAt (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="System::DateTimeOffset"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickDateTimeOffset(out var value)) {
///     // `value` is of type `System::DateTimeOffset`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickDateTimeOffset(
        [NotNullWhen(true)] out System::DateTimeOffset? value
    )
    {
        value =this.Value as System::DateTimeOffset? ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="DateRangeFilter"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickDateRangeFilter(out var value)) {
///     // `value` is of type `DateRangeFilter`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickDateRangeFilter(
        [NotNullWhen(true)] out DateRangeFilter? value
    )
    {
        value =this.Value as DateRangeFilter ;
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
///     (System::DateTimeOffset value) =&gt; {...},
///     (DateRangeFilter value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<System::DateTimeOffset> @dateTimeOffset,
        System::Action<DateRangeFilter> dateRangeFilter
    )
    {
        switch (this.Value)
        {
            case System::DateTimeOffset value:
                @dateTimeOffset(value);
                break;
            case DateRangeFilter value:
                dateRangeFilter(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of CreatedAt");

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
///     (System::DateTimeOffset value) =&gt; {...},
///     (DateRangeFilter value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<System::DateTimeOffset, T> @dateTimeOffset,
        System::Func<DateRangeFilter, T> dateRangeFilter
    )
    {
        return this.Value switch
        {
            System::DateTimeOffset value=>@dateTimeOffset(value),
            DateRangeFilter value=>dateRangeFilter(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of CreatedAt")
        } ;
    }

    public static implicit operator CreatedAt (
        System::DateTimeOffset value
    )=> new(value) ;

    public static implicit operator CreatedAt (
        DateRangeFilter value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of CreatedAt");
        }
        this.Switch((_) => {}, (dateRangeFilter) => dateRangeFilter.Validate());
    }

    public virtual bool Equals(CreatedAt? other)
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
        { System::DateTimeOffset _=>0, DateRangeFilter _=>1, _ =>-1 } ;
    }
}

sealed class CreatedAtConverter : JsonConverter<CreatedAt>
{
    public override CreatedAt? Read(
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
            var deserialized = JsonSerializer.Deserialize<DateRangeFilter>(element, options);
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
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(element, options), element);
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, CreatedAt value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Date range filtering operations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DateRangeFilter, DateRangeFilterFromRaw>))]
public sealed record class DateRangeFilter : JsonModel
{
    /// <summary>
    /// Filter for creation date-time greater than
    /// </summary>
    public System::DateTimeOffset? Gt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "gt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gt", value);
        }
    }

    /// <summary>
    /// Filter for creation date-time greater than or equal to
    /// </summary>
    public System::DateTimeOffset? Gte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "gte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gte", value);
        }
    }

    /// <summary>
    /// Filter for creation date-time less than
    /// </summary>
    public System::DateTimeOffset? Lt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "lt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lt", value);
        }
    }

    /// <summary>
    /// Filter for creation date-time less than or equal to
    /// </summary>
    public System::DateTimeOffset? Lte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "lte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lte", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Gt;
        _ = this.Gte;
        _ = this.Lt;
        _ = this.Lte;
    }

    public DateRangeFilter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DateRangeFilter (DateRangeFilter dateRangeFilter) : base(
        dateRangeFilter
    )
    {  }
    #pragma warning restore CS8618

    public DateRangeFilter (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DateRangeFilter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DateRangeFilterFromRaw.FromRawUnchecked"/>
    public static DateRangeFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DateRangeFilterFromRaw : IFromRawJson<DateRangeFilter>
{
    /// <inheritdoc/>
    public DateRangeFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DateRangeFilter.FromRawUnchecked(rawData);
}