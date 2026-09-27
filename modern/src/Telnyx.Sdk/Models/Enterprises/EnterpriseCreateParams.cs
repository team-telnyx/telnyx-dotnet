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
/// Create the legal entity (enterprise) that represents your business on the Telnyx platform.
///
/// <para>The response carries a server-assigned `id` you use for every subsequent
/// call. An enterprise is created once and reused; the API collects all required
/// fields up front.</para>
///
/// <para>Common failure modes: - `422` - a required field is missing or malformed
/// (the response `errors[].source.pointer` names the field). - `409` - an enterprise
/// with the same identifying details already exists under your account.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EnterpriseCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required PhysicalAddress BillingAddress {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<PhysicalAddress>(
                "billing_address"
            );
        }
        init { this._rawBodyData.Set("billing_address", value); }
    }

    public required BillingContact BillingContact {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<BillingContact>(
                "billing_contact"
            );
        }
        init { this._rawBodyData.Set("billing_contact", value); }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code. Currently `US` and `CA` are supported.
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

    public required string DoingBusinessAs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "doing_business_as"
            );
        }
        init { this._rawBodyData.Set("doing_business_as", value); }
    }

    /// <summary>
    /// US Federal Employer Identification Number (`NN-NNNNNNN`) or Canadian equivalent.
    /// </summary>
    public required string Fein {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "fein"
            );
        }
        init { this._rawBodyData.Set("fein", value); }
    }

    /// <summary>
    /// Industry classification.
    /// </summary>
    public required ApiEnum<string, Industry> Industry {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Industry>>(
                "industry"
            );
        }
        init { this._rawBodyData.Set("industry", value); }
    }

    public required string JurisdictionOfIncorporation {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "jurisdiction_of_incorporation"
            );
        }
        init { this._rawBodyData.Set("jurisdiction_of_incorporation", value); }
    }

    /// <summary>
    /// Legal name of the enterprise.
    /// </summary>
    public required string LegalName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "legal_name"
            );
        }
        init { this._rawBodyData.Set("legal_name", value); }
    }

    /// <summary>
    /// Approximate headcount range. Used for vetting heuristics; pick the bucket
    /// that contains your current employee count.
    /// </summary>
    public required ApiEnum<string, NumberOfEmployees> NumberOfEmployees {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, NumberOfEmployees>>(
                "number_of_employees"
            );
        }
        init { this._rawBodyData.Set("number_of_employees", value); }
    }

    public required OrganizationContact OrganizationContact {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<OrganizationContact>(
                "organization_contact"
            );
        }
        init { this._rawBodyData.Set("organization_contact", value); }
    }

    /// <summary>
    /// Legal-entity form. Pick the form that matches your incorporation documents:
    /// - `corporation` - C-corp or S-corp. - `llc` - limited liability company.
    /// - `partnership` - general/limited partnership. - `nonprofit` - non-profit
    /// corporation, charitable trust, or 501(c)(3)/equivalent. - `other` - anything
    /// else (sole proprietorships, government bodies, DBAs, etc.). You may be asked
    /// for additional documents during vetting.
    /// </summary>
    public required ApiEnum<string, OrganizationLegalType> OrganizationLegalType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, OrganizationLegalType>>(
                "organization_legal_type"
            );
        }
        init { this._rawBodyData.Set("organization_legal_type", value); }
    }

    public required PhysicalAddress OrganizationPhysicalAddress {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<PhysicalAddress>(
                "organization_physical_address"
            );
        }
        init { this._rawBodyData.Set("organization_physical_address", value); }
    }

    /// <summary>
    /// Organization category for vetting purposes: - `commercial` - for-profit business
    /// entities (LLC, corp, partnership, sole proprietorship). Most callers fall
    /// here. - `government` - federal/state/local government bodies. - `non_profit`
    /// - registered 501(c)(3)/equivalent (incl. educational institutions, charities,
    /// religious organisations).
    /// </summary>
    public required ApiEnum<string, OrganizationType> OrganizationType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, OrganizationType>>(
                "organization_type"
            );
        }
        init { this._rawBodyData.Set("organization_type", value); }
    }

    public required string Website {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "website"
            );
        }
        init { this._rawBodyData.Set("website", value); }
    }

    /// <summary>
    /// Optional corporate-registration / company-number identifier.
    /// </summary>
    public string? CorporateRegistrationNumber {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "corporate_registration_number"
            );
        }
        init { this._rawBodyData.Set("corporate_registration_number", value); }
    }

    /// <summary>
    /// Optional free-form string the caller can attach for their own bookkeeping.
    /// Telnyx does not interpret it.
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
    /// Optional D-U-N-S Number.
    /// </summary>
    public string? DunBradstreetNumber {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "dun_bradstreet_number"
            );
        }
        init { this._rawBodyData.Set("dun_bradstreet_number", value); }
    }

    /// <summary>
    /// Optional SIC code for the primary line of business.
    /// </summary>
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

    /// <summary>
    /// Optional professional-license number for regulated industries.
    /// </summary>
    public string? ProfessionalLicenseNumber {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "professional_license_number"
            );
        }
        init { this._rawBodyData.Set("professional_license_number", value); }
    }

    /// <summary>
    /// `enterprise` for an organization registering its own DIRs; `bpo` for a Business
    /// Process Outsourcer placing calls on behalf of one or more enterprises.
    /// </summary>
    public ApiEnum<string, RoleType>? RoleType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, RoleType>>(
                "role_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("role_type", value);
        }
    }

    public EnterpriseCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnterpriseCreateParams (
        EnterpriseCreateParams enterpriseCreateParams
    ) : base(enterpriseCreateParams)
    { this._rawBodyData = new(enterpriseCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public EnterpriseCreateParams (
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
    EnterpriseCreateParams (
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
    public static EnterpriseCreateParams FromRawUnchecked(
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

    public virtual bool Equals(EnterpriseCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/enterprises"
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
/// Industry classification.
/// </summary>
[JsonConverter(typeof(IndustryConverter))]
public enum Industry
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

sealed class IndustryConverter : JsonConverter<Industry>
{
    public override Industry Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accounting"=>Industry.Accounting,
            "finance"=>Industry.Finance,
            "billing"=>Industry.Billing,
            "collections"=>Industry.Collections,
            "business"=>Industry.Business,
            "charity"=>Industry.Charity,
            "nonprofit"=>Industry.Nonprofit,
            "communications"=>Industry.Communications,
            "telecom"=>Industry.Telecom,
            "customer service"=>Industry.CustomerService,
            "support"=>Industry.Support,
            "delivery"=>Industry.Delivery,
            "shipping"=>Industry.Shipping,
            "logistics"=>Industry.Logistics,
            "education"=>Industry.Education,
            "financial"=>Industry.Financial,
            "banking"=>Industry.Banking,
            "government"=>Industry.Government,
            "public"=>Industry.Public,
            "healthcare"=>Industry.Healthcare,
            "health"=>Industry.Health,
            "pharmacy"=>Industry.Pharmacy,
            "medical"=>Industry.Medical,
            "insurance"=>Industry.Insurance,
            "legal"=>Industry.Legal,
            "law"=>Industry.Law,
            "notifications"=>Industry.Notifications,
            "scheduling"=>Industry.Scheduling,
            "real estate"=>Industry.RealEstate,
            "property"=>Industry.Property,
            "retail"=>Industry.Retail,
            "ecommerce"=>Industry.Ecommerce,
            "sales"=>Industry.Sales,
            "marketing"=>Industry.Marketing,
            "software"=>Industry.Software,
            "technology"=>Industry.Technology,
            "tech"=>Industry.Tech,
            "media"=>Industry.Media,
            "surveys"=>Industry.Surveys,
            "market research"=>Industry.MarketResearch,
            "travel"=>Industry.Travel,
            "hospitality"=>Industry.Hospitality,
            "hotel"=>Industry.Hotel,
            _ =>(Industry)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Industry value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Industry.Accounting=>"accounting",
            Industry.Finance=>"finance",
            Industry.Billing=>"billing",
            Industry.Collections=>"collections",
            Industry.Business=>"business",
            Industry.Charity=>"charity",
            Industry.Nonprofit=>"nonprofit",
            Industry.Communications=>"communications",
            Industry.Telecom=>"telecom",
            Industry.CustomerService=>"customer service",
            Industry.Support=>"support",
            Industry.Delivery=>"delivery",
            Industry.Shipping=>"shipping",
            Industry.Logistics=>"logistics",
            Industry.Education=>"education",
            Industry.Financial=>"financial",
            Industry.Banking=>"banking",
            Industry.Government=>"government",
            Industry.Public=>"public",
            Industry.Healthcare=>"healthcare",
            Industry.Health=>"health",
            Industry.Pharmacy=>"pharmacy",
            Industry.Medical=>"medical",
            Industry.Insurance=>"insurance",
            Industry.Legal=>"legal",
            Industry.Law=>"law",
            Industry.Notifications=>"notifications",
            Industry.Scheduling=>"scheduling",
            Industry.RealEstate=>"real estate",
            Industry.Property=>"property",
            Industry.Retail=>"retail",
            Industry.Ecommerce=>"ecommerce",
            Industry.Sales=>"sales",
            Industry.Marketing=>"marketing",
            Industry.Software=>"software",
            Industry.Technology=>"technology",
            Industry.Tech=>"tech",
            Industry.Media=>"media",
            Industry.Surveys=>"surveys",
            Industry.MarketResearch=>"market research",
            Industry.Travel=>"travel",
            Industry.Hospitality=>"hospitality",
            Industry.Hotel=>"hotel",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Approximate headcount range. Used for vetting heuristics; pick the bucket that
/// contains your current employee count.
/// </summary>
[JsonConverter(typeof(NumberOfEmployeesConverter))]
public enum NumberOfEmployees
{
    NumberOfEmployees1_10,
    NumberOfEmployees11_50,
    NumberOfEmployees51_200,
    NumberOfEmployees201_500,
    NumberOfEmployees501_2000,
    NumberOfEmployees2001_10000,
    NumberOfEmployees10001Plus
}

sealed class NumberOfEmployeesConverter : JsonConverter<NumberOfEmployees>
{
    public override NumberOfEmployees Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1-10"=>NumberOfEmployees.NumberOfEmployees1_10,
            "11-50"=>NumberOfEmployees.NumberOfEmployees11_50,
            "51-200"=>NumberOfEmployees.NumberOfEmployees51_200,
            "201-500"=>NumberOfEmployees.NumberOfEmployees201_500,
            "501-2000"=>NumberOfEmployees.NumberOfEmployees501_2000,
            "2001-10000"=>NumberOfEmployees.NumberOfEmployees2001_10000,
            "10001+"=>NumberOfEmployees.NumberOfEmployees10001Plus,
            _ =>(NumberOfEmployees)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NumberOfEmployees value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            NumberOfEmployees.NumberOfEmployees1_10=>"1-10",
            NumberOfEmployees.NumberOfEmployees11_50=>"11-50",
            NumberOfEmployees.NumberOfEmployees51_200=>"51-200",
            NumberOfEmployees.NumberOfEmployees201_500=>"201-500",
            NumberOfEmployees.NumberOfEmployees501_2000=>"501-2000",
            NumberOfEmployees.NumberOfEmployees2001_10000=>"2001-10000",
            NumberOfEmployees.NumberOfEmployees10001Plus=>"10001+",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Legal-entity form. Pick the form that matches your incorporation documents: -
/// `corporation` - C-corp or S-corp. - `llc` - limited liability company. - `partnership`
/// - general/limited partnership. - `nonprofit` - non-profit corporation, charitable
/// trust, or 501(c)(3)/equivalent. - `other` - anything else (sole proprietorships,
/// government bodies, DBAs, etc.). You may be asked for additional documents during vetting.
/// </summary>
[JsonConverter(typeof(OrganizationLegalTypeConverter))]
public enum OrganizationLegalType
{
    Corporation, Llc, Partnership, Nonprofit, Other
}

sealed class OrganizationLegalTypeConverter : JsonConverter<OrganizationLegalType>
{
    public override OrganizationLegalType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "corporation"=>OrganizationLegalType.Corporation,
            "llc"=>OrganizationLegalType.Llc,
            "partnership"=>OrganizationLegalType.Partnership,
            "nonprofit"=>OrganizationLegalType.Nonprofit,
            "other"=>OrganizationLegalType.Other,
            _ =>(OrganizationLegalType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OrganizationLegalType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OrganizationLegalType.Corporation=>"corporation",
            OrganizationLegalType.Llc=>"llc",
            OrganizationLegalType.Partnership=>"partnership",
            OrganizationLegalType.Nonprofit=>"nonprofit",
            OrganizationLegalType.Other=>"other",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Organization category for vetting purposes: - `commercial` - for-profit business
/// entities (LLC, corp, partnership, sole proprietorship). Most callers fall here.
/// - `government` - federal/state/local government bodies. - `non_profit` - registered
/// 501(c)(3)/equivalent (incl. educational institutions, charities, religious organisations).
/// </summary>
[JsonConverter(typeof(OrganizationTypeConverter))]
public enum OrganizationType
{
    Commercial, Government, NonProfit
}

sealed class OrganizationTypeConverter : JsonConverter<OrganizationType>
{
    public override OrganizationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "commercial"=>OrganizationType.Commercial,
            "government"=>OrganizationType.Government,
            "non_profit"=>OrganizationType.NonProfit,
            _ =>(OrganizationType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OrganizationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OrganizationType.Commercial=>"commercial",
            OrganizationType.Government=>"government",
            OrganizationType.NonProfit=>"non_profit",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// `enterprise` for an organization registering its own DIRs; `bpo` for a Business
/// Process Outsourcer placing calls on behalf of one or more enterprises.
/// </summary>
[JsonConverter(typeof(RoleTypeConverter))]
public enum RoleType
{
    Enterprise, Bpo
}

sealed class RoleTypeConverter : JsonConverter<RoleType>
{
    public override RoleType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enterprise"=>RoleType.Enterprise,
            "bpo"=>RoleType.Bpo,
            _ =>(RoleType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RoleType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RoleType.Enterprise=>"enterprise",
            RoleType.Bpo=>"bpo",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}