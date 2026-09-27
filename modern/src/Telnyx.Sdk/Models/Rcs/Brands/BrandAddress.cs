using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rcs.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandAddress, BrandAddressFromRaw>))]
public sealed record class BrandAddress : JsonModel
{
    public required string AdministrativeArea {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "administrative_area"
            );
        }
        init { this._rawData.Set("administrative_area", value); }
    }

    public required string City {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "city"
            );
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The two-letter ISO 3166-1 country code.
    /// </summary>
    public required string CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "country_code"
            );
        }
        init { this._rawData.Set("country_code", value); }
    }

    public required string Line1 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "line_1"
            );
        }
        init { this._rawData.Set("line_1", value); }
    }

    public required string PostalCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "postal_code"
            );
        }
        init { this._rawData.Set("postal_code", value); }
    }

    public string? Line2 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "line_2"
            );
        }
        init { this._rawData.Set("line_2", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdministrativeArea;
        _ = this.City;
        _ = this.CountryCode;
        _ = this.Line1;
        _ = this.PostalCode;
        _ = this.Line2;
    }

    public BrandAddress ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandAddress (BrandAddress brandAddress) : base(brandAddress)
    {  }
    #pragma warning restore CS8618

    public BrandAddress (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandAddress (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BrandAddressFromRaw.FromRawUnchecked"/>
    public static BrandAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BrandAddressFromRaw : IFromRawJson<BrandAddress>
{
    /// <inheritdoc/>
    public BrandAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BrandAddress.FromRawUnchecked(rawData);
}