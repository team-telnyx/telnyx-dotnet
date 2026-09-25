using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

/// <summary>
/// Update a brand's attributes by `brandId`.
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

    public string? BrandID { get; init; }

    /// <summary>
    /// ISO2 2 characters country code. Example: US - United States
    /// </summary>
    public required string Country {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "country"
            );
        }
        init { this._rawBodyData.Set("country", value); }
    }

    /// <summary>
    /// Display or marketing name of the brand.
    /// </summary>
    public required string DisplayName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "displayName"
            );
        }
        init { this._rawBodyData.Set("displayName", value); }
    }

    /// <summary>
    /// Valid email address of brand support contact.
    /// </summary>
    public required string Email {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "email"
            );
        }
        init { this._rawBodyData.Set("email", value); }
    }

    /// <summary>
    /// Entity type behind the brand. This is the form of business establishment.
    /// </summary>
    public required ApiEnum<string, EntityType> EntityType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, EntityType>>(
                "entityType"
            );
        }
        init { this._rawBodyData.Set("entityType", value); }
    }

    /// <summary>
    /// Vertical or industry segment of the brand or campaign.
    /// </summary>
    public required ApiEnum<string, Vertical> Vertical {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Vertical>>(
                "vertical"
            );
        }
        init { this._rawBodyData.Set("vertical", value); }
    }

    /// <summary>
    /// Alternate business identifier such as DUNS, LEI, or GIIN
    /// </summary>
    public string? AltBusinessID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "altBusinessId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("altBusinessId", value);
        }
    }

    /// <summary>
    /// An enumeration.
    /// </summary>
    public ApiEnum<string, AltBusinessIDType>? AltBusinessIDType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, AltBusinessIDType>>(
                "altBusinessIdType"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("altBusinessIdType", value);
        }
    }

    /// <summary>
    /// Business contact email.
    ///
    /// <para>Required if `entityType` will be changed to `PUBLIC_PROFIT`. Otherwise,
    /// it is recommended to either omit this field or set it to `null`.</para>
    /// </summary>
    public string? BusinessContactEmail {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "businessContactEmail"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("businessContactEmail", value);
        }
    }

    /// <summary>
    /// City name
    /// </summary>
    public string? City {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "city"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("city", value);
        }
    }

    /// <summary>
    /// (Required for Non-profit/private/public) Legal company name.
    /// </summary>
    public string? CompanyName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "companyName"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("companyName", value);
        }
    }

    /// <summary>
    /// (Required for Non-profit) Government assigned corporate tax ID. EIN is 9-digits
    /// in U.S.
    /// </summary>
    public string? Ein {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "ein"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ein", value);
        }
    }

    /// <summary>
    /// First name of business contact.
    /// </summary>
    public string? FirstName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "firstName"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("firstName", value);
        }
    }

    /// <summary>
    /// The verification status of an active brand
    /// </summary>
    public ApiEnum<string, BrandIdentityStatus>? IdentityStatus {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, BrandIdentityStatus>>(
                "identityStatus"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("identityStatus", value);
        }
    }

    /// <summary>
    /// IP address of the browser requesting to create brand identity.
    /// </summary>
    public string? IPAddress {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "ipAddress"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ipAddress", value);
        }
    }

    public bool? IsReseller {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "isReseller"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("isReseller", value);
        }
    }

    /// <summary>
    /// Last name of business contact.
    /// </summary>
    public string? LastName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "lastName"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("lastName", value);
        }
    }

    /// <summary>
    /// Valid phone number in e.164 international format.
    /// </summary>
    public string? Phone {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "phone"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("phone", value);
        }
    }

    /// <summary>
    /// Postal codes. Use 5 digit zipcode for United States
    /// </summary>
    public string? PostalCode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "postalCode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("postalCode", value);
        }
    }

    /// <summary>
    /// State. Must be 2 letters code for United States.
    /// </summary>
    public string? State {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("state", value);
        }
    }

    /// <summary>
    /// (Required for public company) stock exchange.
    /// </summary>
    public ApiEnum<string, StockExchange>? StockExchange {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, StockExchange>>(
                "stockExchange"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("stockExchange", value);
        }
    }

    /// <summary>
    /// (Required for public company) stock symbol.
    /// </summary>
    public string? StockSymbol {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "stockSymbol"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("stockSymbol", value);
        }
    }

    /// <summary>
    /// Street number and name.
    /// </summary>
    public string? Street {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "street"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("street", value);
        }
    }

    /// <summary>
    /// Webhook failover URL for brand status updates.
    /// </summary>
    public string? WebhookFailoverUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhookFailoverURL"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhookFailoverURL", value);
        }
    }

    /// <summary>
    /// Webhook URL for brand status updates.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhookURL"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhookURL", value);
        }
    }

    /// <summary>
    /// Brand website URL.
    /// </summary>
    public string? Website {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "website"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("website", value);
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
        this.BrandID = brandUpdateParams.BrandID;

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
        string brandID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.BrandID = brandID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BrandUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string brandID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            brandID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["BrandID"] = JsonSerializer.SerializeToElement(this.BrandID),
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
        return (this.BrandID?.Equals(other.BrandID) ?? other.BrandID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/10dlc/brand/{0}",
            this.BrandID)
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