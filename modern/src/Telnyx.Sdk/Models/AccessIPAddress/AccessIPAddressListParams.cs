using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AccessIPAddress;

/// <summary>
/// Retrieve a paginated list of access IP addresses configured on your account.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AccessIPAddressListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[ip_source],
    /// filter[ip_address], filter[created_at]. Supports complex bracket operations
    /// for dynamic filtering.
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

    public AccessIPAddressListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccessIPAddressListParams (
        AccessIPAddressListParams accessIPAddressListParams
    ) : base(accessIPAddressListParams)
    {  }
    #pragma warning restore CS8618

    public AccessIPAddressListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AccessIPAddressListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AccessIPAddressListParams FromRawUnchecked(
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

    public virtual bool Equals(AccessIPAddressListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/access_ip_address"
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
/// Consolidated filter parameter (deepObject style). Originally: filter[ip_source],
/// filter[ip_address], filter[created_at]. Supports complex bracket operations for
/// dynamic filtering.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
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

    /// <summary>
    /// Filter by IP address
    /// </summary>
    public string? IPAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ip_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ip_address", value);
        }
    }

    /// <summary>
    /// Filter by IP source
    /// </summary>
    public string? IPSource {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ip_source"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ip_source", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CreatedAt?.Validate();
        _ = this.IPAddress;
        _ = this.IPSource;
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