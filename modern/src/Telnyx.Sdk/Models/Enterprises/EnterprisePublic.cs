using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises;

[JsonConverter(typeof(JsonModelConverter<EnterprisePublic, EnterprisePublicFromRaw>))]
public sealed record class EnterprisePublic : JsonModel
{
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

    public PhysicalAddress? BillingAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhysicalAddress>(
                "billing_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("billing_address", value);
        }
    }

    public BillingContact? BillingContact {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BillingContact>(
                "billing_contact"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("billing_contact", value);
        }
    }

    /// <summary>
    /// True once Branded Calling has been activated on this enterprise (see `POST /enterprises/{id}/branded_calling`).
    /// </summary>
    public bool? BrandedCallingEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "branded_calling_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("branded_calling_enabled", value);
        }
    }

    /// <summary>
    /// Optional corporate-registration / company-number identifier.
    /// </summary>
    public string? CorporateRegistrationNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "corporate_registration_number"
            );
        }
        init { this._rawData.Set("corporate_registration_number", value); }
    }

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

    public DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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

    public string? DoingBusinessAs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "doing_business_as"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("doing_business_as", value);
        }
    }

    /// <summary>
    /// Optional D-U-N-S Number issued by Dun &amp; Bradstreet.
    /// </summary>
    public string? DunBradstreetNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "dun_bradstreet_number"
            );
        }
        init { this._rawData.Set("dun_bradstreet_number", value); }
    }

    public string? Fein {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "fein"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("fein", value);
        }
    }

    public string? Industry {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "industry"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("industry", value);
        }
    }

    public string? JurisdictionOfIncorporation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "jurisdiction_of_incorporation"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("jurisdiction_of_incorporation", value);
        }
    }

    public string? LegalName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "legal_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("legal_name", value);
        }
    }

    public string? NumberOfEmployees {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "number_of_employees"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("number_of_employees", value);
        }
    }

    /// <summary>
    /// True once Phone Number Reputation has been enabled on this enterprise (see
    /// `POST /enterprises/{id}/reputation`).
    /// </summary>
    public bool? NumberReputationEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "number_reputation_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("number_reputation_enabled", value);
        }
    }

    public OrganizationContact? OrganizationContact {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OrganizationContact>(
                "organization_contact"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_contact", value);
        }
    }

    public string? OrganizationLegalType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization_legal_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_legal_type", value);
        }
    }

    public PhysicalAddress? OrganizationPhysicalAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhysicalAddress>(
                "organization_physical_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_physical_address", value);
        }
    }

    public string? OrganizationType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_type", value);
        }
    }

    /// <summary>
    /// Optional SIC code for the primary line of business.
    /// </summary>
    public string? PrimaryBusinessDomainSicCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "primary_business_domain_sic_code"
            );
        }
        init { this._rawData.Set("primary_business_domain_sic_code", value); }
    }

    /// <summary>
    /// Optional professional-license number for regulated industries.
    /// </summary>
    public string? ProfessionalLicenseNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "professional_license_number"
            );
        }
        init { this._rawData.Set("professional_license_number", value); }
    }

    public string? RoleType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "role_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("role_type", value);
        }
    }

    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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

    public string? Website {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "website"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("website", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.BillingAddress?.Validate();
        this.BillingContact?.Validate();
        _ = this.BrandedCallingEnabled;
        _ = this.CorporateRegistrationNumber;
        _ = this.CountryCode;
        _ = this.CreatedAt;
        _ = this.CustomerReference;
        _ = this.DoingBusinessAs;
        _ = this.DunBradstreetNumber;
        _ = this.Fein;
        _ = this.Industry;
        _ = this.JurisdictionOfIncorporation;
        _ = this.LegalName;
        _ = this.NumberOfEmployees;
        _ = this.NumberReputationEnabled;
        this.OrganizationContact?.Validate();
        _ = this.OrganizationLegalType;
        this.OrganizationPhysicalAddress?.Validate();
        _ = this.OrganizationType;
        _ = this.PrimaryBusinessDomainSicCode;
        _ = this.ProfessionalLicenseNumber;
        _ = this.RoleType;
        _ = this.UpdatedAt;
        _ = this.Website;
    }

    public EnterprisePublic ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnterprisePublic (EnterprisePublic enterprisePublic) : base(
        enterprisePublic
    )
    {  }
    #pragma warning restore CS8618

    public EnterprisePublic (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EnterprisePublic (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EnterprisePublicFromRaw.FromRawUnchecked"/>
    public static EnterprisePublic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EnterprisePublicFromRaw : IFromRawJson<EnterprisePublic>
{
    /// <inheritdoc/>
    public EnterprisePublic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EnterprisePublic.FromRawUnchecked(rawData);
}