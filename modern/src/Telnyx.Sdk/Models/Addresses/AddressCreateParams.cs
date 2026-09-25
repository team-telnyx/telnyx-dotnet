using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Addresses;

/// <summary>
/// Creates a new address on your account from the provided details, for use with
/// services that require a physical address such as emergency calling and regulatory compliance.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AddressCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The business name associated with the address. An address must have either
    /// a first last name or a business name.
    /// </summary>
    public required string BusinessName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "business_name"
            );
        }
        init { this._rawBodyData.Set("business_name", value); }
    }

    /// <summary>
    /// The two-character (ISO 3166-1 alpha-2) country code of the address.
    /// </summary>
    public required string CountryCode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "country_code"
            );
        }
        init { this._rawBodyData.Set("country_code", value); }
    }

    /// <summary>
    /// The first name associated with the address. An address must have either a
    /// first last name or a business name.
    /// </summary>
    public required string FirstName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "first_name"
            );
        }
        init { this._rawBodyData.Set("first_name", value); }
    }

    /// <summary>
    /// The last name associated with the address. An address must have either a first
    /// last name or a business name.
    /// </summary>
    public required string LastName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "last_name"
            );
        }
        init { this._rawBodyData.Set("last_name", value); }
    }

    /// <summary>
    /// The locality of the address. For US addresses, this corresponds to the city
    /// of the address.
    /// </summary>
    public required string Locality {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "locality"
            );
        }
        init { this._rawBodyData.Set("locality", value); }
    }

    /// <summary>
    /// The primary street address information about the address.
    /// </summary>
    public required string StreetAddress {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "street_address"
            );
        }
        init { this._rawBodyData.Set("street_address", value); }
    }

    /// <summary>
    /// Indicates whether or not the address should be considered part of your list
    /// of addresses that appear for regular use.
    /// </summary>
    public bool? AddressBook {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "address_book"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("address_book", value);
        }
    }

    /// <summary>
    /// The locality of the address. For US addresses, this corresponds to the state
    /// of the address.
    /// </summary>
    public string? AdministrativeArea {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "administrative_area"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("administrative_area", value);
        }
    }

    /// <summary>
    /// The borough of the address. This field is not used for addresses in the US
    /// but is used for some international addresses.
    /// </summary>
    public string? Borough {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "borough"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("borough", value);
        }
    }

    /// <summary>
    /// A customer reference string for customer look ups.
    /// </summary>
    public string? CustomerReference {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "customer_reference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("customer_reference", value);
        }
    }

    /// <summary>
    /// Additional street address information about the address such as, but not limited
    /// to, unit number or apartment number.
    /// </summary>
    public string? ExtendedAddress {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "extended_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("extended_address", value);
        }
    }

    /// <summary>
    /// The neighborhood of the address. This field is not used for addresses in the
    /// US but is used for some international addresses.
    /// </summary>
    public string? Neighborhood {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "neighborhood"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("neighborhood", value);
        }
    }

    /// <summary>
    /// The phone number associated with the address.
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// The postal code of the address.
    /// </summary>
    public string? PostalCode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "postal_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("postal_code", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "validate_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("validate_address", value);
        }
    }

    public AddressCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddressCreateParams (AddressCreateParams addressCreateParams) : base(
        addressCreateParams
    )
    { this._rawBodyData = new(addressCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public AddressCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AddressCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AddressCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(AddressCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/addresses"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
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