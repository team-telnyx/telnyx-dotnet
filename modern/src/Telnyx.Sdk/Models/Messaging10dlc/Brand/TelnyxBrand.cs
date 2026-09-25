using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

/// <summary>
/// Telnyx-specific extensions to The Campaign Registry's `Brand` type
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TelnyxBrand, TelnyxBrandFromRaw>))]
public sealed record class TelnyxBrand : JsonModel
{
    /// <summary>
    /// Brand relationship to the CSP.
    /// </summary>
    public required ApiEnum<string, BrandRelationship> BrandRelationship {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BrandRelationship>>(
                "brandRelationship"
            );
        }
        init { this._rawData.Set("brandRelationship", value); }
    }

    /// <summary>
    /// ISO2 2 characters country code. Example: US - United States
    /// </summary>
    public required string Country {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "country"
            );
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// Display or marketing name of the brand.
    /// </summary>
    public required string DisplayName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "displayName"
            );
        }
        init { this._rawData.Set("displayName", value); }
    }

    /// <summary>
    /// Valid email address of brand support contact.
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
    /// Entity type behind the brand. This is the form of business establishment.
    /// </summary>
    public required ApiEnum<string, EntityType> EntityType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EntityType>>(
                "entityType"
            );
        }
        init { this._rawData.Set("entityType", value); }
    }

    /// <summary>
    /// Vertical or industry segment of the brand.
    /// </summary>
    public required string Vertical {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "vertical"
            );
        }
        init { this._rawData.Set("vertical", value); }
    }

    /// <summary>
    /// Alternate business identifier such as DUNS, LEI, or GIIN
    /// </summary>
    public string? AltBusinessID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "altBusinessId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("altBusinessId", value);
        }
    }

    /// <summary>
    /// An enumeration.
    /// </summary>
    public ApiEnum<string, AltBusinessIDType>? AltBusinessIDType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AltBusinessIDType>>(
                "altBusinessIdType"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("altBusinessIdType", value);
        }
    }

    /// <summary>
    /// Unique identifier assigned to the brand.
    /// </summary>
    public string? BrandID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "brandId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("brandId", value);
        }
    }

    /// <summary>
    /// Business contact email.
    ///
    /// <para>Required if `entityType` is `PUBLIC_PROFIT`.</para>
    /// </summary>
    public string? BusinessContactEmail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "businessContactEmail"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("businessContactEmail", value);
        }
    }

    /// <summary>
    /// City name
    /// </summary>
    public string? City {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "city"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("city", value);
        }
    }

    /// <summary>
    /// (Required for Non-profit/private/public) Legal company name.
    /// </summary>
    public string? CompanyName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "companyName"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("companyName", value);
        }
    }

    /// <summary>
    /// Date and time that the brand was created at.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "createdAt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// Unique identifier assigned to the csp by the registry.
    /// </summary>
    public string? CspID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cspId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cspId", value);
        }
    }

    /// <summary>
    /// (Required for Non-profit) Government assigned corporate tax ID. EIN is 9-digits
    /// in U.S.
    /// </summary>
    public string? Ein {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ein"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ein", value);
        }
    }

    /// <summary>
    /// Failure reasons for brand
    /// </summary>
    public string? FailureReasons {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "failureReasons"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("failureReasons", value);
        }
    }

    /// <summary>
    /// First name of business contact.
    /// </summary>
    public string? FirstName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "firstName"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("firstName", value);
        }
    }

    /// <summary>
    /// The verification status of an active brand
    /// </summary>
    public ApiEnum<string, BrandIdentityStatus>? IdentityStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BrandIdentityStatus>>(
                "identityStatus"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("identityStatus", value);
        }
    }

    /// <summary>
    /// IP address of the browser requesting to create brand identity.
    /// </summary>
    public string? IPAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ipAddress"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ipAddress", value);
        }
    }

    /// <summary>
    /// Indicates whether this brand is known to be a reseller
    /// </summary>
    public bool? IsReseller {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "isReseller"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("isReseller", value);
        }
    }

    /// <summary>
    /// Last name of business contact.
    /// </summary>
    public string? LastName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "lastName"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lastName", value);
        }
    }

    /// <summary>
    /// Valid mobile phone number in e.164 international format.
    /// </summary>
    public string? MobilePhone {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mobilePhone"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mobilePhone", value);
        }
    }

    /// <summary>
    /// Mock brand for testing purposes
    /// </summary>
    public bool? Mock {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "mock"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mock", value);
        }
    }

    public BrandOptionalAttributes? OptionalAttributes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrandOptionalAttributes>(
                "optionalAttributes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("optionalAttributes", value);
        }
    }

    /// <summary>
    /// Valid phone number in e.164 international format.
    /// </summary>
    public string? Phone {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone", value);
        }
    }

    /// <summary>
    /// Postal codes. Use 5 digit zipcode for United States
    /// </summary>
    public string? PostalCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "postalCode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("postalCode", value);
        }
    }

    /// <summary>
    /// Unique identifier Telnyx assigned to the brand - the brandId
    /// </summary>
    public string? ReferenceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "referenceId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("referenceId", value);
        }
    }

    /// <summary>
    /// State. Must be 2 letters code for United States.
    /// </summary>
    public string? State {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <summary>
    /// Status of the brand
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// (Required for public company) stock exchange.
    /// </summary>
    public ApiEnum<string, StockExchange>? StockExchange {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, StockExchange>>(
                "stockExchange"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("stockExchange", value);
        }
    }

    /// <summary>
    /// (Required for public company) stock symbol.
    /// </summary>
    public string? StockSymbol {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "stockSymbol"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("stockSymbol", value);
        }
    }

    /// <summary>
    /// Street number and name.
    /// </summary>
    public string? Street {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "street"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("street", value);
        }
    }

    /// <summary>
    /// Unique identifier assigned to the brand by the registry.
    /// </summary>
    public string? TcrBrandID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tcrBrandId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tcrBrandId", value);
        }
    }

    /// <summary>
    /// Universal EIN of Brand, Read Only.
    /// </summary>
    public string? UniversalEin {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "universalEin"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("universalEin", value);
        }
    }

    /// <summary>
    /// Date and time that the brand was last updated at.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "updatedAt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <summary>
    /// Failover webhook to which brand status updates are sent.
    /// </summary>
    public string? WebhookFailoverUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhookFailoverURL"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhookFailoverURL", value);
        }
    }

    /// <summary>
    /// Webhook to which brand status updates are sent.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhookURL"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhookURL", value);
        }
    }

    /// <summary>
    /// Brand website URL.
    /// </summary>
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
        this.BrandRelationship.Validate();
        _ = this.Country;
        _ = this.DisplayName;
        _ = this.Email;
        this.EntityType.Validate();
        _ = this.Vertical;
        _ = this.AltBusinessID;
        this.AltBusinessIDType?.Validate();
        _ = this.BrandID;
        _ = this.BusinessContactEmail;
        _ = this.City;
        _ = this.CompanyName;
        _ = this.CreatedAt;
        _ = this.CspID;
        _ = this.Ein;
        _ = this.FailureReasons;
        _ = this.FirstName;
        this.IdentityStatus?.Validate();
        _ = this.IPAddress;
        _ = this.IsReseller;
        _ = this.LastName;
        _ = this.MobilePhone;
        _ = this.Mock;
        this.OptionalAttributes?.Validate();
        _ = this.Phone;
        _ = this.PostalCode;
        _ = this.ReferenceID;
        _ = this.State;
        this.Status?.Validate();
        this.StockExchange?.Validate();
        _ = this.StockSymbol;
        _ = this.Street;
        _ = this.TcrBrandID;
        _ = this.UniversalEin;
        _ = this.UpdatedAt;
        _ = this.WebhookFailoverUrl;
        _ = this.WebhookUrl;
        _ = this.Website;
    }

    public TelnyxBrand ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelnyxBrand (TelnyxBrand telnyxBrand) : base(telnyxBrand)
    {  }
    #pragma warning restore CS8618

    public TelnyxBrand (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelnyxBrand (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelnyxBrandFromRaw.FromRawUnchecked"/>
    public static TelnyxBrand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelnyxBrandFromRaw : IFromRawJson<TelnyxBrand>
{
    /// <inheritdoc/>
    public TelnyxBrand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelnyxBrand.FromRawUnchecked(rawData);
}

/// <summary>
/// Brand relationship to the CSP.
/// </summary>
[JsonConverter(typeof(BrandRelationshipConverter))]
public enum BrandRelationship
{
    BasicAccount, SmallAccount, MediumAccount, LargeAccount, KeyAccount
}sealed class BrandRelationshipConverter : JsonConverter<BrandRelationship>
{
    public override BrandRelationship Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BASIC_ACCOUNT"=>BrandRelationship.BasicAccount,
            "SMALL_ACCOUNT"=>BrandRelationship.SmallAccount,
            "MEDIUM_ACCOUNT"=>BrandRelationship.MediumAccount,
            "LARGE_ACCOUNT"=>BrandRelationship.LargeAccount,
            "KEY_ACCOUNT"=>BrandRelationship.KeyAccount,
            _ =>(BrandRelationship)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BrandRelationship value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BrandRelationship.BasicAccount=>"BASIC_ACCOUNT",
            BrandRelationship.SmallAccount=>"SMALL_ACCOUNT",
            BrandRelationship.MediumAccount=>"MEDIUM_ACCOUNT",
            BrandRelationship.LargeAccount=>"LARGE_ACCOUNT",
            BrandRelationship.KeyAccount=>"KEY_ACCOUNT",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Status of the brand
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Ok, RegistrationPending, RegistrationFailed
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OK"=>Status.Ok,
            "REGISTRATION_PENDING"=>Status.RegistrationPending,
            "REGISTRATION_FAILED"=>Status.RegistrationFailed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Ok=>"OK",
            Status.RegistrationPending=>"REGISTRATION_PENDING",
            Status.RegistrationFailed=>"REGISTRATION_FAILED",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}