using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Rcs.Brands;

/// <summary>
/// Creates an editable RCS brand draft. Creating the draft does not begin external review.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BrandCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required IReadOnlyDictionary<string, BrandAddress> Addresses {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<FrozenDictionary<string, BrandAddress>>(
                "addresses"
            );
        }
        init {
            this._rawBodyData.Set<FrozenDictionary<string, BrandAddress>>(
                "addresses",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Named business contacts. Use the `brand` key for the required BRAND contact.
    /// </summary>
    public required Contacts Contacts {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Contacts>(
                "contacts"
            );
        }
        init { this._rawBodyData.Set("contacts", value); }
    }

    public required string DisplayName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "display_name"
            );
        }
        init { this._rawBodyData.Set("display_name", value); }
    }

    /// <summary>
    /// Named business identifiers. Use the `ein` key for the required EIN and `stock_symbol`
    /// for a public-profit brand's stock symbol.
    /// </summary>
    public required Identifiers Identifiers {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Identifiers>(
                "identifiers"
            );
        }
        init { this._rawBodyData.Set("identifiers", value); }
    }

    public required ApiEnum<string, BrandLegalEntityType> LegalEntityType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, BrandLegalEntityType>>(
                "legal_entity_type"
            );
        }
        init { this._rawBodyData.Set("legal_entity_type", value); }
    }

    public required string LegalName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "legal_name"
            );
        }
        init { this._rawBodyData.Set("legal_name", value); }
    }

    public required ApiEnum<string, BrandOrganizationType> OrganizationType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, BrandOrganizationType>>(
                "organization_type"
            );
        }
        init { this._rawBodyData.Set("organization_type", value); }
    }

    public required string WebsiteUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "website_url"
            );
        }
        init { this._rawBodyData.Set("website_url", value); }
    }

    /// <summary>
    /// A Messaging Profile owned by the authenticated organization. Agents inherit
    /// this value when they do not provide their own profile.
    /// </summary>
    public string? ProfileID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "profile_id"
            );
        }
        init { this._rawBodyData.Set("profile_id", value); }
    }

    public BrandCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandCreateParams (BrandCreateParams brandCreateParams) : base(
        brandCreateParams
    )
    { this._rawBodyData = new(brandCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public BrandCreateParams (
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
    BrandCreateParams (
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
    public static BrandCreateParams FromRawUnchecked(
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

    public virtual bool Equals(BrandCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/rcs/brands"
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
/// Named business contacts. Use the `brand` key for the required BRAND contact.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Contacts, ContactsFromRaw>))]
public sealed record class Contacts : JsonModel
{
    public required Brand Brand {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Brand>(
                "brand"
            );
        }
        init { this._rawData.Set("brand", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Brand.Validate(); }

    public Contacts ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Contacts (Contacts contacts) : base(contacts)
    {  }
    #pragma warning restore CS8618

    public Contacts (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Contacts (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ContactsFromRaw.FromRawUnchecked"/>
    public static Contacts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Contacts (Brand brand) : this()
    { this.Brand = brand; }
}

class ContactsFromRaw : IFromRawJson<Contacts>
{
    /// <inheritdoc/>
    public Contacts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Contacts.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Brand, BrandFromRaw>))]
public sealed record class Brand : JsonModel
{
    public required ApiEnum<string, BrandContactContactType> ContactType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BrandContactContactType>>(
                "contact_type"
            );
        }
        init { this._rawData.Set("contact_type", value); }
    }

    public required string Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "email"
            );
        }
        init { this._rawData.Set("email", value); }
    }

    public required string FirstName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "first_name"
            );
        }
        init { this._rawData.Set("first_name", value); }
    }

    public required string LastName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "last_name"
            );
        }
        init { this._rawData.Set("last_name", value); }
    }

    public required string PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phone_number"
            );
        }
        init { this._rawData.Set("phone_number", value); }
    }

    public string? Title {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "title"
            );
        }
        init { this._rawData.Set("title", value); }
    }

    public static implicit operator BrandContact (Brand brand)=> new() {
        ContactType = brand.ContactType,
        Email = brand.Email,
        FirstName = brand.FirstName,
        LastName = brand.LastName,
        PhoneNumber = brand.PhoneNumber,
        Title = brand.Title
    } ;

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ContactType.Validate();
        _ = this.Email;
        _ = this.FirstName;
        _ = this.LastName;
        _ = this.PhoneNumber;
        _ = this.Title;
    }

    public Brand ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Brand (Brand brand) : base(brand)
    {  }
    #pragma warning restore CS8618

    public Brand (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Brand (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BrandFromRaw.FromRawUnchecked"/>
    public static Brand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BrandFromRaw : IFromRawJson<Brand>
{
    /// <inheritdoc/>
    public Brand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Brand.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
    public ApiEnum<string, ContactType>? ContactType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ContactType>>(
                "contact_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("contact_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.ContactType?.Validate(); }

    public IntersectionMember1 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1 (IntersectionMember1 intersectionMember1) : base(
        intersectionMember1
    )
    {  }
    #pragma warning restore CS8618

    public IntersectionMember1 (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class IntersectionMember1FromRaw : IFromRawJson<IntersectionMember1>
{
    /// <inheritdoc/>
    public IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ContactTypeConverter))]
public enum ContactType
{
    Brand
}

sealed class ContactTypeConverter : JsonConverter<ContactType>
{
    public override ContactType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "BRAND"=>ContactType.Brand, _ =>(ContactType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, ContactType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ContactType.Brand=>"BRAND",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Named business identifiers. Use the `ein` key for the required EIN and `stock_symbol`
/// for a public-profit brand's stock symbol.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Identifiers, IdentifiersFromRaw>))]
public sealed record class Identifiers : JsonModel
{
    public required EinBrandIdentifier Ein {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EinBrandIdentifier>(
                "ein"
            );
        }
        init { this._rawData.Set("ein", value); }
    }

    public StockSymbolBrandIdentifier? StockSymbol {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StockSymbolBrandIdentifier>(
                "stock_symbol"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("stock_symbol", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Ein.Validate();
        this.StockSymbol?.Validate();
    }

    public Identifiers ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Identifiers (Identifiers identifiers) : base(identifiers)
    {  }
    #pragma warning restore CS8618

    public Identifiers (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Identifiers (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IdentifiersFromRaw.FromRawUnchecked"/>
    public static Identifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Identifiers (EinBrandIdentifier ein) : this()
    { this.Ein = ein; }
}

class IdentifiersFromRaw : IFromRawJson<Identifiers>
{
    /// <inheritdoc/>
    public Identifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Identifiers.FromRawUnchecked(rawData);
}