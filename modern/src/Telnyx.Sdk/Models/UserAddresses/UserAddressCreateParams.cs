using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.UserAddresses;

/// <summary>
/// Creates a new user address from the provided details and returns the created address.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UserAddressCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The business name associated with the user address.
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
    /// The two-character (ISO 3166-1 alpha-2) country code of the user address.
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
    /// The first name associated with the user address.
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
    /// The last name associated with the user address.
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
    /// The locality of the user address. For US addresses, this corresponds to the
    /// city of the address.
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
    /// The primary street address information about the user address.
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
    /// The locality of the user address. For US addresses, this corresponds to the
    /// state of the address.
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
    /// The borough of the user address. This field is not used for addresses in
    /// the US but is used for some international addresses.
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
    /// Additional street address information about the user address such as, but
    /// not limited to, unit number or apartment number.
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
    /// The neighborhood of the user address. This field is not used for addresses
    /// in the US but is used for some international addresses.
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
    /// The phone number associated with the user address.
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
    /// The postal code of the user address.
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
    /// An optional boolean value specifying if verification of the address should
    /// be skipped or not. UserAddresses are generally used for shipping addresses,
    /// and failure to validate your shipping address will likely result in a failure
    /// to deliver SIM cards or other items ordered from Telnyx. Do not use this parameter
    /// unless you are sure that the address is correct even though it cannot be
    /// validated. If this is set to any value other than true, verification of the
    /// address will be attempted, and the user address will not be allowed if verification
    /// fails. If verification fails but suggested values are available that might
    /// make the address correct, they will be present in the response as well. If
    /// this value is set to true, then the verification will not be attempted. Defaults
    /// to false (verification will be performed).
    /// </summary>
    public bool? SkipAddressVerification {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "skip_address_verification"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("skip_address_verification", value);
        }
    }

    public UserAddressCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserAddressCreateParams (
        UserAddressCreateParams userAddressCreateParams
    ) : base(userAddressCreateParams)
    { this._rawBodyData = new(userAddressCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public UserAddressCreateParams (
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
    UserAddressCreateParams (
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
    public static UserAddressCreateParams FromRawUnchecked(
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

    public virtual bool Equals(UserAddressCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/user_addresses"
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