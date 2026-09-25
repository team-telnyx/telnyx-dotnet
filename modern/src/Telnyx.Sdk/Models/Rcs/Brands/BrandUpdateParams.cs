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
/// Updates one or more fields on a brand while its status is `CREATED`. Submitted
/// brands cannot be changed.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BrandUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    public IReadOnlyDictionary<string, BrandAddress>? Addresses {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, BrandAddress>>(
                "addresses"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, BrandAddress>?>(
                "addresses",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Named business contacts. Use the `brand` key for the required BRAND contact.
    /// </summary>
    public BrandUpdateParamsContacts? Contacts {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BrandUpdateParamsContacts>(
                "contacts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("contacts", value);
        }
    }

    public string? DisplayName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "display_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("display_name", value);
        }
    }

    /// <summary>
    /// Named business identifiers. Use the `ein` key for the required EIN and `stock_symbol`
    /// for a public-profit brand's stock symbol.
    /// </summary>
    public BrandUpdateParamsIdentifiers? Identifiers {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BrandUpdateParamsIdentifiers>(
                "identifiers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("identifiers", value);
        }
    }

    public ApiEnum<string, BrandLegalEntityType>? LegalEntityType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, BrandLegalEntityType>>(
                "legal_entity_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("legal_entity_type", value);
        }
    }

    public string? LegalName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "legal_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("legal_name", value);
        }
    }

    public ApiEnum<string, BrandOrganizationType>? OrganizationType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, BrandOrganizationType>>(
                "organization_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("organization_type", value);
        }
    }

    public string? ProfileID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("profile_id", value);
        }
    }

    public string? WebsiteUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "website_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("website_url", value);
        }
    }

    public BrandUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandUpdateParams (BrandUpdateParams brandUpdateParams) : base(
        brandUpdateParams
    )
    {
        this.ID = brandUpdateParams.ID;

        this._rawBodyData = new(brandUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public BrandUpdateParams (
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
    BrandUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BrandUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(BrandUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/rcs/brands/{0}",
            this.ID)
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
[JsonConverter(typeof(JsonModelConverter<BrandUpdateParamsContacts, BrandUpdateParamsContactsFromRaw>))]
public sealed record class BrandUpdateParamsContacts : JsonModel
{
    public required BrandUpdateParamsContactsBrand Brand {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrandUpdateParamsContactsBrand>(
                "brand"
            );
        }
        init { this._rawData.Set("brand", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Brand.Validate(); }

    public BrandUpdateParamsContacts ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandUpdateParamsContacts (
        BrandUpdateParamsContacts brandUpdateParamsContacts
    ) : base(brandUpdateParamsContacts)
    {  }
    #pragma warning restore CS8618

    public BrandUpdateParamsContacts (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandUpdateParamsContacts (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BrandUpdateParamsContactsFromRaw.FromRawUnchecked"/>
    public static BrandUpdateParamsContacts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public BrandUpdateParamsContacts (
        BrandUpdateParamsContactsBrand brand
    ) : this()
    { this.Brand = brand; }
}

class BrandUpdateParamsContactsFromRaw : IFromRawJson<BrandUpdateParamsContacts>
{
    /// <inheritdoc/>
    public BrandUpdateParamsContacts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BrandUpdateParamsContacts.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BrandUpdateParamsContactsBrand, BrandUpdateParamsContactsBrandFromRaw>))]
public sealed record class BrandUpdateParamsContactsBrand : JsonModel
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

    public static implicit operator BrandContact (
        BrandUpdateParamsContactsBrand brandUpdateParamsContactsBrand
    )=> new() {
        ContactType = brandUpdateParamsContactsBrand.ContactType,
        Email = brandUpdateParamsContactsBrand.Email,
        FirstName = brandUpdateParamsContactsBrand.FirstName,
        LastName = brandUpdateParamsContactsBrand.LastName,
        PhoneNumber = brandUpdateParamsContactsBrand.PhoneNumber,
        Title = brandUpdateParamsContactsBrand.Title
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

    public BrandUpdateParamsContactsBrand ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandUpdateParamsContactsBrand (
        BrandUpdateParamsContactsBrand brandUpdateParamsContactsBrand
    ) : base(brandUpdateParamsContactsBrand)
    {  }
    #pragma warning restore CS8618

    public BrandUpdateParamsContactsBrand (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandUpdateParamsContactsBrand (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BrandUpdateParamsContactsBrandFromRaw.FromRawUnchecked"/>
    public static BrandUpdateParamsContactsBrand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BrandUpdateParamsContactsBrandFromRaw : IFromRawJson<BrandUpdateParamsContactsBrand>
{
    /// <inheritdoc/>
    public BrandUpdateParamsContactsBrand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BrandUpdateParamsContactsBrand.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BrandUpdateParamsContactsBrandIntersectionMember1, BrandUpdateParamsContactsBrandIntersectionMember1FromRaw>))]
public sealed record class BrandUpdateParamsContactsBrandIntersectionMember1 : JsonModel
{
    public ApiEnum<string, BrandUpdateParamsContactsBrandIntersectionMember1ContactType>? ContactType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BrandUpdateParamsContactsBrandIntersectionMember1ContactType>>(
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

    public BrandUpdateParamsContactsBrandIntersectionMember1 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandUpdateParamsContactsBrandIntersectionMember1 (
        BrandUpdateParamsContactsBrandIntersectionMember1 brandUpdateParamsContactsBrandIntersectionMember1
    ) : base(brandUpdateParamsContactsBrandIntersectionMember1)
    {  }
    #pragma warning restore CS8618

    public BrandUpdateParamsContactsBrandIntersectionMember1 (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandUpdateParamsContactsBrandIntersectionMember1 (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BrandUpdateParamsContactsBrandIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static BrandUpdateParamsContactsBrandIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BrandUpdateParamsContactsBrandIntersectionMember1FromRaw : IFromRawJson<BrandUpdateParamsContactsBrandIntersectionMember1>
{
    /// <inheritdoc/>
    public BrandUpdateParamsContactsBrandIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BrandUpdateParamsContactsBrandIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BrandUpdateParamsContactsBrandIntersectionMember1ContactTypeConverter))]
public enum BrandUpdateParamsContactsBrandIntersectionMember1ContactType
{
    Brand
}

sealed class BrandUpdateParamsContactsBrandIntersectionMember1ContactTypeConverter : JsonConverter<BrandUpdateParamsContactsBrandIntersectionMember1ContactType>
{
    public override BrandUpdateParamsContactsBrandIntersectionMember1ContactType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BRAND"=>BrandUpdateParamsContactsBrandIntersectionMember1ContactType.Brand,
            _ =>(BrandUpdateParamsContactsBrandIntersectionMember1ContactType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BrandUpdateParamsContactsBrandIntersectionMember1ContactType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BrandUpdateParamsContactsBrandIntersectionMember1ContactType.Brand=>"BRAND",
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
[JsonConverter(typeof(JsonModelConverter<BrandUpdateParamsIdentifiers, BrandUpdateParamsIdentifiersFromRaw>))]
public sealed record class BrandUpdateParamsIdentifiers : JsonModel
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

    public BrandUpdateParamsIdentifiers ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandUpdateParamsIdentifiers (
        BrandUpdateParamsIdentifiers brandUpdateParamsIdentifiers
    ) : base(brandUpdateParamsIdentifiers)
    {  }
    #pragma warning restore CS8618

    public BrandUpdateParamsIdentifiers (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandUpdateParamsIdentifiers (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BrandUpdateParamsIdentifiersFromRaw.FromRawUnchecked"/>
    public static BrandUpdateParamsIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public BrandUpdateParamsIdentifiers (EinBrandIdentifier ein) : this()
    { this.Ein = ein; }
}

class BrandUpdateParamsIdentifiersFromRaw : IFromRawJson<BrandUpdateParamsIdentifiers>
{
    /// <inheritdoc/>
    public BrandUpdateParamsIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BrandUpdateParamsIdentifiers.FromRawUnchecked(rawData);
}