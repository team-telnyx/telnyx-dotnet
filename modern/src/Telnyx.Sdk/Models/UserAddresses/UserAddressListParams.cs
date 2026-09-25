using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.UserAddresses;

/// <summary>
/// Returns a paginated list of your user addresses, with support for filtering and sorting.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UserAddressListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[customer_reference][eq],
    /// filter[customer_reference][contains], filter[street_address][contains]
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

    /// <summary>
    /// Specifies the sort order for results. By default sorting direction is ascending.
    /// To have the results sorted in descending order add the &lt;code&gt; -&lt;/code&gt;
    /// prefix.&lt;br/&gt;&lt;br/&gt; That is: &lt;ul&gt;   &lt;li&gt;     &lt;code&gt;street_address&lt;/code&gt;:
    /// sorts the result by the     &lt;code&gt;street_address&lt;/code&gt; field
    /// in ascending order.   &lt;/li&gt;
    ///
    /// <para>  &lt;li&gt;     &lt;code&gt;-street_address&lt;/code&gt;: sorts the
    /// result by the     &lt;code&gt;street_address&lt;/code&gt; field in descending
    /// order.   &lt;/li&gt; &lt;/ul&gt; &lt;br/&gt; If not given, results are sorted
    /// by &lt;code&gt;created_at&lt;/code&gt; in descending order.</para>
    /// </summary>
    public ApiEnum<string, Sort>? Sort {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Sort>>(
                "sort"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("sort", value);
        }
    }

    public UserAddressListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserAddressListParams (
        UserAddressListParams userAddressListParams
    ) : base(userAddressListParams)
    {  }
    #pragma warning restore CS8618

    public UserAddressListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserAddressListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UserAddressListParams FromRawUnchecked(
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

    public virtual bool Equals(UserAddressListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/user_addresses"
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
/// Consolidated filter parameter (deepObject style). Originally: filter[customer_reference][eq],
/// filter[customer_reference][contains], filter[street_address][contains]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Filter user addresses via the customer reference. Supports both exact matching
    /// (eq) and partial matching (contains). Matching is not case-sensitive.
    /// </summary>
    public CustomerReference? CustomerReference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerReference>(
                "customer_reference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("customer_reference", value);
        }
    }

    /// <summary>
    /// Filter user addresses via street address. Supports partial matching (contains).
    /// Matching is not case-sensitive.
    /// </summary>
    public StreetAddress? StreetAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StreetAddress>(
                "street_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("street_address", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CustomerReference?.Validate();
        this.StreetAddress?.Validate();
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
/// Filter user addresses via the customer reference. Supports both exact matching
/// (eq) and partial matching (contains). Matching is not case-sensitive.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CustomerReference, CustomerReferenceFromRaw>))]
public sealed record class CustomerReference : JsonModel
{
    /// <summary>
    /// If present, user addresses with &lt;code&gt;customer_reference&lt;/code&gt;
    /// containing the given value will be returned. Matching is not case-sensitive.
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
    /// Filter user addresses via exact customer reference match. Matching is not case-sensitive.
    /// </summary>
    public string? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Contains;
        _ = this.Eq;
    }

    public CustomerReference ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerReference (CustomerReference customerReference) : base(
        customerReference
    )
    {  }
    #pragma warning restore CS8618

    public CustomerReference (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerReference (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CustomerReferenceFromRaw.FromRawUnchecked"/>
    public static CustomerReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CustomerReferenceFromRaw : IFromRawJson<CustomerReference>
{
    /// <inheritdoc/>
    public CustomerReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CustomerReference.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter user addresses via street address. Supports partial matching (contains).
/// Matching is not case-sensitive.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StreetAddress, StreetAddressFromRaw>))]
public sealed record class StreetAddress : JsonModel
{
    /// <summary>
    /// If present, user addresses with &lt;code&gt;street_address&lt;/code&gt; containing
    /// the given value will be returned. Matching is not case-sensitive. Requires
    /// at least three characters.
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

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Contains; }

    public StreetAddress ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public StreetAddress (StreetAddress streetAddress) : base(streetAddress)
    {  }
    #pragma warning restore CS8618

    public StreetAddress (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    StreetAddress (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StreetAddressFromRaw.FromRawUnchecked"/>
    public static StreetAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class StreetAddressFromRaw : IFromRawJson<StreetAddress>
{
    /// <inheritdoc/>
    public StreetAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>StreetAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the sort order for results. By default sorting direction is ascending.
/// To have the results sorted in descending order add the &lt;code&gt; -&lt;/code&gt;
/// prefix.&lt;br/&gt;&lt;br/&gt; That is: &lt;ul&gt;   &lt;li&gt;     &lt;code&gt;street_address&lt;/code&gt;:
/// sorts the result by the     &lt;code&gt;street_address&lt;/code&gt; field in
/// ascending order.   &lt;/li&gt;
///
/// <para>  &lt;li&gt;     &lt;code&gt;-street_address&lt;/code&gt;: sorts the result
/// by the     &lt;code&gt;street_address&lt;/code&gt; field in descending order.
///   &lt;/li&gt; &lt;/ul&gt; &lt;br/&gt; If not given, results are sorted by &lt;code&gt;created_at&lt;/code&gt;
/// in descending order.</para>
/// </summary>
[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    CreatedAt, FirstName, LastName, BusinessName, StreetAddress
}

sealed class SortConverter : JsonConverter<Sort>
{
    public override Sort Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created_at"=>Sort.CreatedAt,
            "first_name"=>Sort.FirstName,
            "last_name"=>Sort.LastName,
            "business_name"=>Sort.BusinessName,
            "street_address"=>Sort.StreetAddress,
            _ =>(Sort)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Sort value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Sort.CreatedAt=>"created_at",
            Sort.FirstName=>"first_name",
            Sort.LastName=>"last_name",
            Sort.BusinessName=>"business_name",
            Sort.StreetAddress=>"street_address",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}