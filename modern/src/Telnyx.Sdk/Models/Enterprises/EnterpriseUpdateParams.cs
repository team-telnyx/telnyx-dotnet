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

namespace Telnyx.Sdk.Models.Enterprises;

/// <summary>
/// Replace the enterprise's mutable fields. Only mutable fields may be sent. Server-assigned
/// and immutable fields (`id`, `record_type`, `created_at`, `updated_at`, status
/// fields, `organization_type`, `country_code`, `role_type`) cannot be changed: including
/// any of them in the body is rejected with `400 Bad Request` (`Field 'X' is not
/// allowed in this request`).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EnterpriseUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? EnterpriseID { get; init; }

    public PhysicalAddress? BillingAddress {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PhysicalAddress>(
                "billing_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("billing_address", value);
        }
    }

    public BillingContact? BillingContact {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BillingContact>(
                "billing_contact"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("billing_contact", value);
        }
    }

    public string? CorporateRegistrationNumber {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "corporate_registration_number"
            );
        }
        init { this._rawBodyData.Set("corporate_registration_number", value); }
    }

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

    public string? DoingBusinessAs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "doing_business_as"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("doing_business_as", value);
        }
    }

    public string? DunBradstreetNumber {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "dun_bradstreet_number"
            );
        }
        init { this._rawBodyData.Set("dun_bradstreet_number", value); }
    }

    public string? Fein {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "fein"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("fein", value);
        }
    }

    public ApiEnum<string, EnterpriseUpdateParamsIndustry>? Industry {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, EnterpriseUpdateParamsIndustry>>(
                "industry"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("industry", value);
        }
    }

    /// <summary>
    /// Updated state/province/country of incorporation. Optional on update.
    /// </summary>
    public string? JurisdictionOfIncorporation {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "jurisdiction_of_incorporation"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("jurisdiction_of_incorporation", value);
        }
    }

    /// <summary>
    /// Legal name of the enterprise.
    /// </summary>
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

    public string? NumberOfEmployees {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "number_of_employees"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("number_of_employees", value);
        }
    }

    public OrganizationContact? OrganizationContact {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<OrganizationContact>(
                "organization_contact"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("organization_contact", value);
        }
    }

    public string? OrganizationLegalType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "organization_legal_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("organization_legal_type", value);
        }
    }

    public PhysicalAddress? OrganizationPhysicalAddress {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PhysicalAddress>(
                "organization_physical_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("organization_physical_address", value);
        }
    }

    public string? PrimaryBusinessDomainSicCode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "primary_business_domain_sic_code"
            );
        }
        init {
            this._rawBodyData.Set("primary_business_domain_sic_code", value);
        }
    }

    public string? ProfessionalLicenseNumber {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "professional_license_number"
            );
        }
        init { this._rawBodyData.Set("professional_license_number", value); }
    }

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

    public EnterpriseUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnterpriseUpdateParams (
        EnterpriseUpdateParams enterpriseUpdateParams
    ) : base(enterpriseUpdateParams)
    {
        this.EnterpriseID = enterpriseUpdateParams.EnterpriseID;

        this._rawBodyData = new(enterpriseUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public EnterpriseUpdateParams (
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
    EnterpriseUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string enterpriseID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.EnterpriseID = enterpriseID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EnterpriseUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string enterpriseID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            enterpriseID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["EnterpriseID"] = JsonSerializer.SerializeToElement(this.EnterpriseID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(EnterpriseUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.EnterpriseID?.Equals(other.EnterpriseID) ?? other.EnterpriseID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/enterprises/{0}",
            EncodePathSegment(this.EnterpriseID))
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

[JsonConverter(typeof(EnterpriseUpdateParamsIndustryConverter))]
public enum EnterpriseUpdateParamsIndustry
{
    Accounting,
    Finance,
    Billing,
    Collections,
    Business,
    Charity,
    Nonprofit,
    Communications,
    Telecom,
    CustomerService,
    Support,
    Delivery,
    Shipping,
    Logistics,
    Education,
    Financial,
    Banking,
    Government,
    Public,
    Healthcare,
    Health,
    Pharmacy,
    Medical,
    Insurance,
    Legal,
    Law,
    Notifications,
    Scheduling,
    RealEstate,
    Property,
    Retail,
    Ecommerce,
    Sales,
    Marketing,
    Software,
    Technology,
    Tech,
    Media,
    Surveys,
    MarketResearch,
    Travel,
    Hospitality,
    Hotel
}

sealed class EnterpriseUpdateParamsIndustryConverter : JsonConverter<EnterpriseUpdateParamsIndustry>
{
    public override EnterpriseUpdateParamsIndustry Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accounting"=>EnterpriseUpdateParamsIndustry.Accounting,
            "finance"=>EnterpriseUpdateParamsIndustry.Finance,
            "billing"=>EnterpriseUpdateParamsIndustry.Billing,
            "collections"=>EnterpriseUpdateParamsIndustry.Collections,
            "business"=>EnterpriseUpdateParamsIndustry.Business,
            "charity"=>EnterpriseUpdateParamsIndustry.Charity,
            "nonprofit"=>EnterpriseUpdateParamsIndustry.Nonprofit,
            "communications"=>EnterpriseUpdateParamsIndustry.Communications,
            "telecom"=>EnterpriseUpdateParamsIndustry.Telecom,
            "customer service"=>EnterpriseUpdateParamsIndustry.CustomerService,
            "support"=>EnterpriseUpdateParamsIndustry.Support,
            "delivery"=>EnterpriseUpdateParamsIndustry.Delivery,
            "shipping"=>EnterpriseUpdateParamsIndustry.Shipping,
            "logistics"=>EnterpriseUpdateParamsIndustry.Logistics,
            "education"=>EnterpriseUpdateParamsIndustry.Education,
            "financial"=>EnterpriseUpdateParamsIndustry.Financial,
            "banking"=>EnterpriseUpdateParamsIndustry.Banking,
            "government"=>EnterpriseUpdateParamsIndustry.Government,
            "public"=>EnterpriseUpdateParamsIndustry.Public,
            "healthcare"=>EnterpriseUpdateParamsIndustry.Healthcare,
            "health"=>EnterpriseUpdateParamsIndustry.Health,
            "pharmacy"=>EnterpriseUpdateParamsIndustry.Pharmacy,
            "medical"=>EnterpriseUpdateParamsIndustry.Medical,
            "insurance"=>EnterpriseUpdateParamsIndustry.Insurance,
            "legal"=>EnterpriseUpdateParamsIndustry.Legal,
            "law"=>EnterpriseUpdateParamsIndustry.Law,
            "notifications"=>EnterpriseUpdateParamsIndustry.Notifications,
            "scheduling"=>EnterpriseUpdateParamsIndustry.Scheduling,
            "real estate"=>EnterpriseUpdateParamsIndustry.RealEstate,
            "property"=>EnterpriseUpdateParamsIndustry.Property,
            "retail"=>EnterpriseUpdateParamsIndustry.Retail,
            "ecommerce"=>EnterpriseUpdateParamsIndustry.Ecommerce,
            "sales"=>EnterpriseUpdateParamsIndustry.Sales,
            "marketing"=>EnterpriseUpdateParamsIndustry.Marketing,
            "software"=>EnterpriseUpdateParamsIndustry.Software,
            "technology"=>EnterpriseUpdateParamsIndustry.Technology,
            "tech"=>EnterpriseUpdateParamsIndustry.Tech,
            "media"=>EnterpriseUpdateParamsIndustry.Media,
            "surveys"=>EnterpriseUpdateParamsIndustry.Surveys,
            "market research"=>EnterpriseUpdateParamsIndustry.MarketResearch,
            "travel"=>EnterpriseUpdateParamsIndustry.Travel,
            "hospitality"=>EnterpriseUpdateParamsIndustry.Hospitality,
            "hotel"=>EnterpriseUpdateParamsIndustry.Hotel,
            _ =>(EnterpriseUpdateParamsIndustry)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EnterpriseUpdateParamsIndustry value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EnterpriseUpdateParamsIndustry.Accounting=>"accounting",
            EnterpriseUpdateParamsIndustry.Finance=>"finance",
            EnterpriseUpdateParamsIndustry.Billing=>"billing",
            EnterpriseUpdateParamsIndustry.Collections=>"collections",
            EnterpriseUpdateParamsIndustry.Business=>"business",
            EnterpriseUpdateParamsIndustry.Charity=>"charity",
            EnterpriseUpdateParamsIndustry.Nonprofit=>"nonprofit",
            EnterpriseUpdateParamsIndustry.Communications=>"communications",
            EnterpriseUpdateParamsIndustry.Telecom=>"telecom",
            EnterpriseUpdateParamsIndustry.CustomerService=>"customer service",
            EnterpriseUpdateParamsIndustry.Support=>"support",
            EnterpriseUpdateParamsIndustry.Delivery=>"delivery",
            EnterpriseUpdateParamsIndustry.Shipping=>"shipping",
            EnterpriseUpdateParamsIndustry.Logistics=>"logistics",
            EnterpriseUpdateParamsIndustry.Education=>"education",
            EnterpriseUpdateParamsIndustry.Financial=>"financial",
            EnterpriseUpdateParamsIndustry.Banking=>"banking",
            EnterpriseUpdateParamsIndustry.Government=>"government",
            EnterpriseUpdateParamsIndustry.Public=>"public",
            EnterpriseUpdateParamsIndustry.Healthcare=>"healthcare",
            EnterpriseUpdateParamsIndustry.Health=>"health",
            EnterpriseUpdateParamsIndustry.Pharmacy=>"pharmacy",
            EnterpriseUpdateParamsIndustry.Medical=>"medical",
            EnterpriseUpdateParamsIndustry.Insurance=>"insurance",
            EnterpriseUpdateParamsIndustry.Legal=>"legal",
            EnterpriseUpdateParamsIndustry.Law=>"law",
            EnterpriseUpdateParamsIndustry.Notifications=>"notifications",
            EnterpriseUpdateParamsIndustry.Scheduling=>"scheduling",
            EnterpriseUpdateParamsIndustry.RealEstate=>"real estate",
            EnterpriseUpdateParamsIndustry.Property=>"property",
            EnterpriseUpdateParamsIndustry.Retail=>"retail",
            EnterpriseUpdateParamsIndustry.Ecommerce=>"ecommerce",
            EnterpriseUpdateParamsIndustry.Sales=>"sales",
            EnterpriseUpdateParamsIndustry.Marketing=>"marketing",
            EnterpriseUpdateParamsIndustry.Software=>"software",
            EnterpriseUpdateParamsIndustry.Technology=>"technology",
            EnterpriseUpdateParamsIndustry.Tech=>"tech",
            EnterpriseUpdateParamsIndustry.Media=>"media",
            EnterpriseUpdateParamsIndustry.Surveys=>"surveys",
            EnterpriseUpdateParamsIndustry.MarketResearch=>"market research",
            EnterpriseUpdateParamsIndustry.Travel=>"travel",
            EnterpriseUpdateParamsIndustry.Hospitality=>"hospitality",
            EnterpriseUpdateParamsIndustry.Hotel=>"hotel",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}