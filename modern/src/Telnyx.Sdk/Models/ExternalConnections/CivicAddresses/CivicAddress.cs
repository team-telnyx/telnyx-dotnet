using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.CivicAddresses;

[JsonConverter(typeof(JsonModelConverter<CivicAddress, CivicAddressFromRaw>))]
public sealed record class CivicAddress : JsonModel
{
    /// <summary>
    /// Uniquely identifies the resource.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? CityOrTown {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "city_or_town"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("city_or_town", value);
        }
    }

    public string? CityOrTownAlias {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "city_or_town_alias"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("city_or_town_alias", value);
        }
    }

    public string? CompanyName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "company_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("company_name", value);
        }
    }

    public string? Country {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country", value);
        }
    }

    public string? CountryOrDistrict {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_or_district"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_or_district", value);
        }
    }

    /// <summary>
    /// Identifies what is the default location in the list of locations.
    /// </summary>
    public string? DefaultLocationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "default_location_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("default_location_id", value);
        }
    }

    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public string? HouseNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "house_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("house_number", value);
        }
    }

    public string? HouseNumberSuffix {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "house_number_suffix"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("house_number_suffix", value);
        }
    }

    public IReadOnlyList<Location>? Locations {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Location>>(
                "locations"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Location>?>(
                "locations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? PostalOrZipCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "postal_or_zip_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("postal_or_zip_code", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    public string? StateOrProvince {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "state_or_province"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("state_or_province", value);
        }
    }

    public string? StreetName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "street_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("street_name", value);
        }
    }

    public string? StreetSuffix {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "street_suffix"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("street_suffix", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CityOrTown;
        _ = this.CityOrTownAlias;
        _ = this.CompanyName;
        _ = this.Country;
        _ = this.CountryOrDistrict;
        _ = this.DefaultLocationID;
        _ = this.Description;
        _ = this.HouseNumber;
        _ = this.HouseNumberSuffix;
        foreach (var item in this.Locations ?? [])
        {
            item.Validate();
        }
        _ = this.PostalOrZipCode;
        _ = this.RecordType;
        _ = this.StateOrProvince;
        _ = this.StreetName;
        _ = this.StreetSuffix;
    }

    public CivicAddress ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CivicAddress (CivicAddress civicAddress) : base(civicAddress)
    {  }
    #pragma warning restore CS8618

    public CivicAddress (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CivicAddress (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CivicAddressFromRaw.FromRawUnchecked"/>
    public static CivicAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CivicAddressFromRaw : IFromRawJson<CivicAddress>
{
    /// <inheritdoc/>
    public CivicAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CivicAddress.FromRawUnchecked(rawData);
}