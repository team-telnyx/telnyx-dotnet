using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Addresses;

[JsonConverter(typeof(JsonModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : JsonModel
{
    /// <summary>
    /// Uniquely identifies the address.
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
    /// Indicates whether or not the address should be considered part of your list
    /// of addresses that appear for regular use.
    /// </summary>
    public bool? AddressBook {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "address_book"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("address_book", value);
        }
    }

    /// <summary>
    /// The locality of the address. For US addresses, this corresponds to the state
    /// of the address.
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
    /// The borough of the address. This field is not used for addresses in the US
    /// but is used for some international addresses.
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
    /// The business name associated with the address. An address must have either
    /// a first last name or a business name.
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
    /// The two-character (ISO 3166-1 alpha-2) country code of the address.
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
    /// Additional street address information about the address such as, but not limited
    /// to, unit number or apartment number.
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
    /// The first name associated with the address. An address must have either a
    /// first last name or a business name.
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
    /// The last name associated with the address. An address must have either a first
    /// last name or a business name.
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
    /// The locality of the address. For US addresses, this corresponds to the city
    /// of the address.
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
    /// The neighborhood of the address. This field is not used for addresses in the
    /// US but is used for some international addresses.
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
    /// The phone number associated with the address.
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
    /// The postal code of the address.
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
    /// The primary street address information about the address.
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

    /// <summary>
    /// Indicates whether or not the address should be validated for emergency use
    /// upon creation or not. This should be left with the default value of `true`
    /// unless you have used the `/addresses/actions/validate` endpoint to validate
    /// the address separately prior to creation. If an address is not validated for
    /// emergency use upon creation and it is not valid, it will not be able to be
    /// used for emergency services.
    /// </summary>
    public bool? ValidateAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "validate_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("validate_address", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AddressBook;
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
        _ = this.ValidateAddress;
    }

    public Address ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Address (Address address) : base(address)
    {  }
    #pragma warning restore CS8618

    public Address (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Address (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AddressFromRaw.FromRawUnchecked"/>
    public static Address FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AddressFromRaw : IFromRawJson<Address>
{
    /// <inheritdoc/>
    public Address FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Address.FromRawUnchecked(rawData);
}