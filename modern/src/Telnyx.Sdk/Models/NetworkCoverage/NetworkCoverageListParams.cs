using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.NetworkCoverage;

/// <summary>
/// List all locations and the interfaces that region supports
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class NetworkCoverageListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[location.region],
    /// filter[location.site], filter[location.pop], filter[location.code]
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

    /// <summary>
    /// Consolidated filters parameter (deepObject style). Originally: filters[available_services][contains]
    /// </summary>
    public Filters? Filters {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Filters>(
                "filters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filters", value);
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

    public NetworkCoverageListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkCoverageListParams (
        NetworkCoverageListParams networkCoverageListParams
    ) : base(networkCoverageListParams)
    {  }
    #pragma warning restore CS8618

    public NetworkCoverageListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkCoverageListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static NetworkCoverageListParams FromRawUnchecked(
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

    public virtual bool Equals(NetworkCoverageListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/network_coverage"
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
/// Consolidated filter parameter (deepObject style). Originally: filter[location.region],
/// filter[location.site], filter[location.pop], filter[location.code]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// The code of associated location to filter on.
    /// </summary>
    public string? LocationCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "location.code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("location.code", value);
        }
    }

    /// <summary>
    /// The POP of associated location to filter on.
    /// </summary>
    public string? LocationPop {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "location.pop"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("location.pop", value);
        }
    }

    /// <summary>
    /// The region of associated location to filter on.
    /// </summary>
    public string? LocationRegion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "location.region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("location.region", value);
        }
    }

    /// <summary>
    /// The site of associated location to filter on.
    /// </summary>
    public string? LocationSite {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "location.site"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("location.site", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LocationCode;
        _ = this.LocationPop;
        _ = this.LocationRegion;
        _ = this.LocationSite;
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
/// Consolidated filters parameter (deepObject style). Originally: filters[available_services][contains]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filters, FiltersFromRaw>))]
public sealed record class Filters : JsonModel
{
    /// <summary>
    /// Filter by exact available service match
    /// </summary>
    public AvailableServices? AvailableServices {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AvailableServices>(
                "available_services"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("available_services", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.AvailableServices?.Validate(); }

    public Filters ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filters (Filters filters) : base(filters)
    {  }
    #pragma warning restore CS8618

    public Filters (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Filters (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FiltersFromRaw.FromRawUnchecked"/>
    public static Filters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FiltersFromRaw : IFromRawJson<Filters>
{
    /// <inheritdoc/>
    public Filters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Filters.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by exact available service match
/// </summary>
[JsonConverter(typeof(AvailableServicesConverter))]
public record class AvailableServices : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public AvailableServices (
        ApiEnum<string, AvailableService> value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AvailableServices (Contains value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AvailableServices (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ApiEnum{TRaw, TEnum}"/> with a <c>TRaw</c> of <c>string</c> and a <c>TEnum</c> of AvailableService>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickService(out var value)) {
///     // `value` is of type `ApiEnum&lt;string, AvailableService&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickService(
        [NotNullWhen(true)] out ApiEnum<string, AvailableService>? value
    )
    {
        value =this.Value as ApiEnum<string, AvailableService> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Contains"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickContains(out var value)) {
///     // `value` is of type `Contains`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickContains([NotNullWhen(true)] out Contains? value)
    {
        value =this.Value as Contains ;
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
///     (ApiEnum&lt;string, AvailableService&gt; value) =&gt; {...},
///     (Contains value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<ApiEnum<string, AvailableService>> service,
        System::Action<Contains> contains
    )
    {
        switch (this.Value)
        {
            case ApiEnum<string, AvailableService> value:
                service(value);
                break;
            case Contains value:
                contains(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of AvailableServices");

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
///     (ApiEnum&lt;string, AvailableService&gt; value) =&gt; {...},
///     (Contains value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<ApiEnum<string, AvailableService>, T> service,
        System::Func<Contains, T> contains
    )
    {
        return this.Value switch
        {
            ApiEnum<string, AvailableService> value=>service(value),
            Contains value=>contains(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of AvailableServices")
        } ;
    }

    public static implicit operator AvailableServices (
        ApiEnum<string, AvailableService> value
    )=> new(value) ;

    public static implicit operator AvailableServices (
        AvailableService value
    )=> new(value) ;

    public static implicit operator AvailableServices (
        Contains value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of AvailableServices");
        }
        this.Switch((service) => service.Validate(),
        (contains) => contains.Validate());
    }

    public virtual bool Equals(AvailableServices? other)
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
        { ApiEnum<string, AvailableService> _=>0, Contains _=>1, _ =>-1 } ;
    }
}

sealed class AvailableServicesConverter : JsonConverter<AvailableServices>
{
    public override AvailableServices? Read(
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
            var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AvailableService>>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<Contains>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
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
        AvailableServices value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Available service filtering operations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Contains, ContainsFromRaw>))]
public sealed record class Contains : JsonModel
{
    /// <summary>
    /// Filter by available services containing the specified service
    /// </summary>
    public ApiEnum<string, AvailableService>? ContainsValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AvailableService>>(
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

    /// <inheritdoc/>
    public override void Validate()
    { this.ContainsValue?.Validate(); }

    public Contains ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Contains (Contains contains) : base(contains)
    {  }
    #pragma warning restore CS8618

    public Contains (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Contains (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ContainsFromRaw.FromRawUnchecked"/>
    public static Contains FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ContainsFromRaw : IFromRawJson<Contains>
{
    /// <inheritdoc/>
    public Contains FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Contains.FromRawUnchecked(rawData);
}