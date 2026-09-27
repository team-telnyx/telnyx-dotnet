using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Porting.LoaConfigurations;

/// <summary>
/// Creates a new LOA configuration with your company details and branding for use
/// when generating LOA documents for porting orders.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class LoaConfigurationCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The address of the company.
    /// </summary>
    public required Address Address {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Address>(
                "address"
            );
        }
        init { this._rawBodyData.Set("address", value); }
    }

    /// <summary>
    /// The name of the company
    /// </summary>
    public required string CompanyName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "company_name"
            );
        }
        init { this._rawBodyData.Set("company_name", value); }
    }

    /// <summary>
    /// The contact information of the company.
    /// </summary>
    public required Contact Contact {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Contact>(
                "contact"
            );
        }
        init { this._rawBodyData.Set("contact", value); }
    }

    /// <summary>
    /// The logo of the LOA configuration
    /// </summary>
    public required Logo Logo {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Logo>(
                "logo"
            );
        }
        init { this._rawBodyData.Set("logo", value); }
    }

    /// <summary>
    /// The name of the LOA configuration
    /// </summary>
    public required string Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawBodyData.Set("name", value); }
    }

    public LoaConfigurationCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LoaConfigurationCreateParams (
        LoaConfigurationCreateParams loaConfigurationCreateParams
    ) : base(loaConfigurationCreateParams)
    { this._rawBodyData = new(loaConfigurationCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public LoaConfigurationCreateParams (
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
    LoaConfigurationCreateParams (
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
    public static LoaConfigurationCreateParams FromRawUnchecked(
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

    public virtual bool Equals(LoaConfigurationCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/porting/loa_configurations"
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

/// <summary>
/// The address of the company.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : JsonModel
{
    /// <summary>
    /// The locality of the company
    /// </summary>
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
    /// The country code of the company
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

    /// <summary>
    /// The administrative area of the company
    /// </summary>
    public required string State {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "state"
            );
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The street address of the company
    /// </summary>
    public required string StreetAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "street_address"
            );
        }
        init { this._rawData.Set("street_address", value); }
    }

    /// <summary>
    /// The postal code of the company
    /// </summary>
    public required string ZipCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "zip_code"
            );
        }
        init { this._rawData.Set("zip_code", value); }
    }

    /// <summary>
    /// The extended address of the company
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.CountryCode;
        _ = this.State;
        _ = this.StreetAddress;
        _ = this.ZipCode;
        _ = this.ExtendedAddress;
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

/// <summary>
/// The contact information of the company.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Contact, ContactFromRaw>))]
public sealed record class Contact : JsonModel
{
    /// <summary>
    /// The email address of the contact
    /// </summary>
    public required string Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "email"
            );
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// The phone number of the contact
    /// </summary>
    public required string PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phone_number"
            );
        }
        init { this._rawData.Set("phone_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.PhoneNumber;
    }

    public Contact ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Contact (Contact contact) : base(contact)
    {  }
    #pragma warning restore CS8618

    public Contact (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Contact (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ContactFromRaw.FromRawUnchecked"/>
    public static Contact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ContactFromRaw : IFromRawJson<Contact>
{
    /// <inheritdoc/>
    public Contact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Contact.FromRawUnchecked(rawData);
}

/// <summary>
/// The logo of the LOA configuration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Logo, LogoFromRaw>))]
public sealed record class Logo : JsonModel
{
    /// <summary>
    /// The document identification
    /// </summary>
    public required string DocumentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "document_id"
            );
        }
        init { this._rawData.Set("document_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.DocumentID; }

    public Logo ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Logo (Logo logo) : base(logo)
    {  }
    #pragma warning restore CS8618

    public Logo (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Logo (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LogoFromRaw.FromRawUnchecked"/>
    public static Logo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Logo (string documentID) : this()
    { this.DocumentID = documentID; }
}

class LogoFromRaw : IFromRawJson<Logo>
{
    /// <inheritdoc/>
    public Logo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Logo.FromRawUnchecked(rawData);
}