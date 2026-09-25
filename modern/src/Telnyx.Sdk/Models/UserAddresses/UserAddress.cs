using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.UserAddresses;

[JsonConverter(typeof(JsonModelConverter<UserAddress, UserAddressFromRaw>))]
public sealed record class UserAddress : JsonModel
{
    /// <summary>
    /// Uniquely identifies the user address.
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

    /// <summary>
    /// The locality of the user address. For US addresses, this corresponds to the
    /// state of the address.
    /// </summary>
    public string? AdministrativeArea {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "administrative_area"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("administrative_area", value);
        }
    }

    /// <summary>
    /// The borough of the user address. This field is not used for addresses in
    /// the US but is used for some international addresses.
    /// </summary>
    public string? Borough {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "borough"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("borough", value);
        }
    }

    /// <summary>
    /// The business name associated with the user address.
    /// </summary>
    public string? BusinessName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "business_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("business_name", value);
        }
    }

    /// <summary>
    /// The two-character (ISO 3166-1 alpha-2) country code of the user address.
    /// </summary>
    public string? CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// A customer reference string for customer look ups.
    /// </summary>
    public string? CustomerReference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// Additional street address information about the user address such as, but
    /// not limited to, unit number or apartment number.
    /// </summary>
    public string? ExtendedAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "extended_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("extended_address", value);
        }
    }

    /// <summary>
    /// The first name associated with the user address.
    /// </summary>
    public string? FirstName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "first_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("first_name", value);
        }
    }

    /// <summary>
    /// The last name associated with the user address.
    /// </summary>
    public string? LastName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "last_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("last_name", value);
        }
    }

    /// <summary>
    /// The locality of the user address. For US addresses, this corresponds to the
    /// city of the address.
    /// </summary>
    public string? Locality {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "locality"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("locality", value);
        }
    }

    /// <summary>
    /// The neighborhood of the user address. This field is not used for addresses
    /// in the US but is used for some international addresses.
    /// </summary>
    public string? Neighborhood {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "neighborhood"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("neighborhood", value);
        }
    }

    /// <summary>
    /// The phone number associated with the user address.
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    /// <summary>
    /// The postal code of the user address.
    /// </summary>
    public string? PostalCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "postal_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("postal_code", value);
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

    /// <summary>
    /// The primary street address information about the user address.
    /// </summary>
    public string? StreetAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        _ = this.ID;
        _ = this.AdministrativeArea;
        _ = this.Borough;
        _ = this.BusinessName;
        _ = this.CountryCode;
        _ = this.CreatedAt;
        _ = this.CustomerReference;
        _ = this.ExtendedAddress;
        _ = this.FirstName;
        _ = this.LastName;
        _ = this.Locality;
        _ = this.Neighborhood;
        _ = this.PhoneNumber;
        _ = this.PostalCode;
        _ = this.RecordType;
        _ = this.StreetAddress;
        _ = this.UpdatedAt;
    }

    public UserAddress ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserAddress (UserAddress userAddress) : base(userAddress)
    {  }
    #pragma warning restore CS8618

    public UserAddress (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserAddress (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserAddressFromRaw.FromRawUnchecked"/>
    public static UserAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UserAddressFromRaw : IFromRawJson<UserAddress>
{
    /// <inheritdoc/>
    public UserAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserAddress.FromRawUnchecked(rawData);
}