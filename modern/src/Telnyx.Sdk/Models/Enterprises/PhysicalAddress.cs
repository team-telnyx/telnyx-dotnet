using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises;

[JsonConverter(typeof(JsonModelConverter<PhysicalAddress, PhysicalAddressFromRaw>))]
public sealed record class PhysicalAddress : JsonModel
{
    /// <summary>
    /// State or province code (e.g. `IL`, `ON`).
    /// </summary>
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
    /// ISO 3166-1 alpha-2 code (currently `US` or `CA`).
    /// </summary>
    public required string Country {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "country"
            );
        }
        init { this._rawData.Set("country", value); }
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

    public required string StreetAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "street_address"
            );
        }
        init { this._rawData.Set("street_address", value); }
    }

    public string? ExtendedAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "extended_address"
            );
        }
        init { this._rawData.Set("extended_address", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdministrativeArea;
        _ = this.City;
        _ = this.Country;
        _ = this.PostalCode;
        _ = this.StreetAddress;
        _ = this.ExtendedAddress;
    }

    public PhysicalAddress ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalAddress (PhysicalAddress physicalAddress) : base(
        physicalAddress
    )
    {  }
    #pragma warning restore CS8618

    public PhysicalAddress (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhysicalAddress (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhysicalAddressFromRaw.FromRawUnchecked"/>
    public static PhysicalAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhysicalAddressFromRaw : IFromRawJson<PhysicalAddress>
{
    /// <inheritdoc/>
    public PhysicalAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhysicalAddress.FromRawUnchecked(rawData);
}