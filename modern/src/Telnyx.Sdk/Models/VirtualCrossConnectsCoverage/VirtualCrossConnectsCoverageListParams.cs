using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.VirtualCrossConnectsCoverage;

/// <summary>
/// List Virtual Cross Connects Cloud Coverage.&lt;br /&gt;&lt;br /&gt;This endpoint
/// shows which cloud regions are available for the `location_code` your Virtual
/// Cross Connect will be provisioned in.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VirtualCrossConnectsCoverageListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[cloud_provider],
    /// filter[cloud_provider_region], filter[location.region], filter[location.site],
    /// filter[location.pop], filter[location.code]
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
    /// Consolidated filters parameter (deepObject style). Originally: filters[available_bandwidth][contains]
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

    public VirtualCrossConnectsCoverageListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VirtualCrossConnectsCoverageListParams (
        VirtualCrossConnectsCoverageListParams virtualCrossConnectsCoverageListParams
    ) : base(virtualCrossConnectsCoverageListParams)
    {  }
    #pragma warning restore CS8618

    public VirtualCrossConnectsCoverageListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VirtualCrossConnectsCoverageListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VirtualCrossConnectsCoverageListParams FromRawUnchecked(
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

    public virtual bool Equals(VirtualCrossConnectsCoverageListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/virtual_cross_connects_coverage"
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
/// Consolidated filter parameter (deepObject style). Originally: filter[cloud_provider],
/// filter[cloud_provider_region], filter[location.region], filter[location.site],
/// filter[location.pop], filter[location.code]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// The Virtual Private Cloud provider.
    /// </summary>
    public ApiEnum<string, CloudProvider>? CloudProvider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CloudProvider>>(
                "cloud_provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cloud_provider", value);
        }
    }

    /// <summary>
    /// The region of specific cloud provider.
    /// </summary>
    public string? CloudProviderRegion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cloud_provider_region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cloud_provider_region", value);
        }
    }

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
        this.CloudProvider?.Validate();
        _ = this.CloudProviderRegion;
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
/// The Virtual Private Cloud provider.
/// </summary>
[JsonConverter(typeof(CloudProviderConverter))]
public enum CloudProvider
{
    Aws, Azure, Gce
}

sealed class CloudProviderConverter : JsonConverter<CloudProvider>
{
    public override CloudProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aws"=>CloudProvider.Aws,
            "azure"=>CloudProvider.Azure,
            "gce"=>CloudProvider.Gce,
            _ =>(CloudProvider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CloudProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CloudProvider.Aws=>"aws",
            CloudProvider.Azure=>"azure",
            CloudProvider.Gce=>"gce",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Consolidated filters parameter (deepObject style). Originally: filters[available_bandwidth][contains]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filters, FiltersFromRaw>))]
public sealed record class Filters : JsonModel
{
    /// <summary>
    /// Filter by exact available bandwidth match
    /// </summary>
    public AvailableBandwidth? AvailableBandwidth {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AvailableBandwidth>(
                "available_bandwidth"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("available_bandwidth", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.AvailableBandwidth?.Validate(); }

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
/// Filter by exact available bandwidth match
/// </summary>
[JsonConverter(typeof(AvailableBandwidthConverter))]
public record class AvailableBandwidth : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public AvailableBandwidth (long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AvailableBandwidth (Contains value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AvailableBandwidth (JsonElement element)
    { this._element = element; }

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
///     (long value) =&gt; {...},
///     (Contains value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<long> @long, System::Action<Contains> contains
    )
    {
        switch (this.Value)
        {
            case long value:
                @long(value);
                break;
            case Contains value:
                contains(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of AvailableBandwidth");

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
///     (Contains value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (System::Func<long, T> @long, System::Func<Contains, T> contains)
    {
        return this.Value switch
        {
            long value=>@long(value),
            Contains value=>contains(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of AvailableBandwidth")
        } ;
    }

    public static implicit operator AvailableBandwidth (
        long value
    )=> new(value) ;

    public static implicit operator AvailableBandwidth (
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
            throw new TelnyxInvalidDataException("Data did not match any variant of AvailableBandwidth");
        }
        this.Switch((_) => {}, (contains) => contains.Validate());
    }

    public virtual bool Equals(AvailableBandwidth? other)
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
        { long _=>0, Contains _=>1, _ =>-1 } ;
    }
}

sealed class AvailableBandwidthConverter : JsonConverter<AvailableBandwidth>
{
    public override AvailableBandwidth? Read(
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

        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AvailableBandwidth value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Available bandwidth filtering operations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Contains, ContainsFromRaw>))]
public sealed record class Contains : JsonModel
{
    /// <summary>
    /// Filter by available bandwidth containing the specified value
    /// </summary>
    public long? ContainsValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
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
    { _ = this.ContainsValue; }

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