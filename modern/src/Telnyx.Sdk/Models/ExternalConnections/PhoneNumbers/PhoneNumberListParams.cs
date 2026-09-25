using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.PhoneNumbers;

/// <summary>
/// Returns a list of all active phone numbers associated with the given external connection.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhoneNumberListParams : ParamsBase
{
    public string? ID { get; init; }

    /// <summary>
    /// Filter parameter for phone numbers (deepObject style). Supports filtering
    /// by phone_number, civic_address_id, and location_id with eq/contains operations.
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

    public PhoneNumberListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberListParams (
        PhoneNumberListParams phoneNumberListParams
    ) : base(phoneNumberListParams)
    { this.ID = phoneNumberListParams.ID; }
    #pragma warning restore CS8618

    public PhoneNumberListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PhoneNumberListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(PhoneNumberListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/external_connections/{0}/phone_numbers",
            this.ID)
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
/// Filter parameter for phone numbers (deepObject style). Supports filtering by
/// phone_number, civic_address_id, and location_id with eq/contains operations.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    public CivicAddressID? CivicAddressID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CivicAddressID>(
                "civic_address_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("civic_address_id", value);
        }
    }

    public LocationID? LocationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LocationID>(
                "location_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("location_id", value);
        }
    }

    public PhoneNumber? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneNumber>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CivicAddressID?.Validate();
        this.LocationID?.Validate();
        this.PhoneNumber?.Validate();
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

[JsonConverter(typeof(JsonModelConverter<CivicAddressID, CivicAddressIDFromRaw>))]
public sealed record class CivicAddressID : JsonModel
{
    /// <summary>
    /// The civic address ID to filter by
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
    { _ = this.Eq; }

    public CivicAddressID ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CivicAddressID (CivicAddressID civicAddressID) : base(civicAddressID)
    {  }
    #pragma warning restore CS8618

    public CivicAddressID (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CivicAddressID (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CivicAddressIDFromRaw.FromRawUnchecked"/>
    public static CivicAddressID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CivicAddressIDFromRaw : IFromRawJson<CivicAddressID>
{
    /// <inheritdoc/>
    public CivicAddressID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CivicAddressID.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<LocationID, LocationIDFromRaw>))]
public sealed record class LocationID : JsonModel
{
    /// <summary>
    /// The location ID to filter by
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
    { _ = this.Eq; }

    public LocationID ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LocationID (LocationID locationID) : base(locationID)
    {  }
    #pragma warning restore CS8618

    public LocationID (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LocationID (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LocationIDFromRaw.FromRawUnchecked"/>
    public static LocationID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class LocationIDFromRaw : IFromRawJson<LocationID>
{
    /// <inheritdoc/>
    public LocationID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LocationID.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PhoneNumber, PhoneNumberFromRaw>))]
public sealed record class PhoneNumber : JsonModel
{
    /// <summary>
    /// The phone number to filter by (partial match)
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
    /// The phone number to filter by (exact match)
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

    public PhoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumber (PhoneNumber phoneNumber) : base(phoneNumber)
    {  }
    #pragma warning restore CS8618

    public PhoneNumber (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberFromRaw.FromRawUnchecked"/>
    public static PhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberFromRaw : IFromRawJson<PhoneNumber>
{
    /// <inheritdoc/>
    public PhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumber.FromRawUnchecked(rawData);
}