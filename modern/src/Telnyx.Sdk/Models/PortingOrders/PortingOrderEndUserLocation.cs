using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders;

[JsonConverter(typeof(JsonModelConverter<PortingOrderEndUserLocation, PortingOrderEndUserLocationFromRaw>))]
public sealed record class PortingOrderEndUserLocation : JsonModel
{
    /// <summary>
    /// State, province, or similar of billing address
    /// </summary>
    public string? AdministrativeArea {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "administrative_area"
            );
        }
        init { this._rawData.Set("administrative_area", value); }
    }

    /// <summary>
    /// ISO3166-1 alpha-2 country code of billing address
    /// </summary>
    public string? CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_code"
            );
        }
        init { this._rawData.Set("country_code", value); }
    }

    /// <summary>
    /// Second line of billing address
    /// </summary>
    public string? ExtendedAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "extended_address"
            );
        }
        init { this._rawData.Set("extended_address", value); }
    }

    /// <summary>
    /// City or municipality of billing address
    /// </summary>
    public string? Locality {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "locality"
            );
        }
        init { this._rawData.Set("locality", value); }
    }

    /// <summary>
    /// Postal Code of billing address
    /// </summary>
    public string? PostalCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "postal_code"
            );
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <summary>
    /// First line of billing address
    /// </summary>
    public string? StreetAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "street_address"
            );
        }
        init { this._rawData.Set("street_address", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdministrativeArea;
        _ = this.CountryCode;
        _ = this.ExtendedAddress;
        _ = this.Locality;
        _ = this.PostalCode;
        _ = this.StreetAddress;
    }

    public PortingOrderEndUserLocation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderEndUserLocation (
        PortingOrderEndUserLocation portingOrderEndUserLocation
    ) : base(portingOrderEndUserLocation)
    {  }
    #pragma warning restore CS8618

    public PortingOrderEndUserLocation (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderEndUserLocation (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderEndUserLocationFromRaw.FromRawUnchecked"/>
    public static PortingOrderEndUserLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderEndUserLocationFromRaw : IFromRawJson<PortingOrderEndUserLocation>
{
    /// <inheritdoc/>
    public PortingOrderEndUserLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderEndUserLocation.FromRawUnchecked(rawData);
}