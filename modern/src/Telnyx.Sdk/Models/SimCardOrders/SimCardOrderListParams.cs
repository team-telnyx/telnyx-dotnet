using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardOrders;

/// <summary>
/// Get all SIM card orders according to filters.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SimCardOrderListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter for SIM card orders (deepObject style). Originally:
    /// filter[created_at], filter[updated_at], filter[quantity], filter[cost.amount],
    /// filter[cost.currency], filter[address.id], filter[address.street_address],
    /// filter[address.extended_address], filter[address.locality], filter[address.administrative_area],
    /// filter[address.country_code], filter[address.postal_code]
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

    public SimCardOrderListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardOrderListParams (
        SimCardOrderListParams simCardOrderListParams
    ) : base(simCardOrderListParams)
    {  }
    #pragma warning restore CS8618

    public SimCardOrderListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardOrderListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SimCardOrderListParams FromRawUnchecked(
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

    public virtual bool Equals(SimCardOrderListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/sim_card_orders"
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
/// Consolidated filter parameter for SIM card orders (deepObject style). Originally:
/// filter[created_at], filter[updated_at], filter[quantity], filter[cost.amount],
/// filter[cost.currency], filter[address.id], filter[address.street_address], filter[address.extended_address],
/// filter[address.locality], filter[address.administrative_area], filter[address.country_code], filter[address.postal_code]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Filter by state or province where the address is located.
    /// </summary>
    public string? AddressAdministrativeArea {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "address.administrative_area"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("address.administrative_area", value);
        }
    }

    /// <summary>
    /// Filter by the mobile operator two-character (ISO 3166-1 alpha-2) origin country code.
    /// </summary>
    public string? AddressCountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "address.country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("address.country_code", value);
        }
    }

    /// <summary>
    /// Returns entries with matching name of the supplemental field for address information.
    /// </summary>
    public string? AddressExtendedAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "address.extended_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("address.extended_address", value);
        }
    }

    /// <summary>
    /// Uniquely identifies the address for the order.
    /// </summary>
    public string? AddressID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "address.id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("address.id", value);
        }
    }

    /// <summary>
    /// Filter by the name of the city where the address is located.
    /// </summary>
    public string? AddressLocality {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "address.locality"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("address.locality", value);
        }
    }

    /// <summary>
    /// Filter by postal code for the address.
    /// </summary>
    public string? AddressPostalCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "address.postal_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("address.postal_code", value);
        }
    }

    /// <summary>
    /// Returns entries with matching name of the street where the address is located.
    /// </summary>
    public string? AddressStreetAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "address.street_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("address.street_address", value);
        }
    }

    /// <summary>
    /// The total monetary amount of the order.
    /// </summary>
    public string? CostAmount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cost.amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cost.amount", value);
        }
    }

    /// <summary>
    /// Filter by ISO 4217 currency string.
    /// </summary>
    public string? CostCurrency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cost.currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cost.currency", value);
        }
    }

    /// <summary>
    /// Filter by ISO 8601 formatted date-time string matching resource creation date-time.
    /// </summary>
    public DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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
    /// Filter orders by how many SIM cards were ordered.
    /// </summary>
    public long? Quantity {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "quantity"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("quantity", value);
        }
    }

    /// <summary>
    /// Filter by ISO 8601 formatted date-time string matching resource last update date-time.
    /// </summary>
    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddressAdministrativeArea;
        _ = this.AddressCountryCode;
        _ = this.AddressExtendedAddress;
        _ = this.AddressID;
        _ = this.AddressLocality;
        _ = this.AddressPostalCode;
        _ = this.AddressStreetAddress;
        _ = this.CostAmount;
        _ = this.CostCurrency;
        _ = this.CreatedAt;
        _ = this.Quantity;
        _ = this.UpdatedAt;
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