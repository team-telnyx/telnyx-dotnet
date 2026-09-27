using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

[JsonConverter(typeof(JsonModelConverter<BrandListResponse, BrandListResponseFromRaw>))]
public sealed record class BrandListResponse : JsonModel
{
    /// <summary>
    /// Number of campaigns associated with the brand
    /// </summary>
    public long? AssignedCampaingsCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "assignedCampaingsCount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("assignedCampaingsCount", value);
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
    /// Display or marketing name of the brand.
    /// </summary>
    public string? DisplayName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "displayName"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("displayName", value);
        }
    }

    /// <summary>
    /// Valid email address of brand support contact.
    /// </summary>
    public string? Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "email"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// Entity type behind the brand. This is the form of business establishment.
    /// </summary>
    public ApiEnum<string, EntityType>? EntityType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EntityType>>(
                "entityType"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("entityType", value);
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
    /// Status of the brand
    /// </summary>
    public ApiEnum<string, BrandListResponseStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BrandListResponseStatus>>(
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
        _ = this.AssignedCampaingsCount;
        _ = this.BrandID;
        _ = this.CompanyName;
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.Email;
        this.EntityType?.Validate();
        _ = this.FailureReasons;
        this.IdentityStatus?.Validate();
        this.Status?.Validate();
        _ = this.TcrBrandID;
        _ = this.UpdatedAt;
        _ = this.Website;
    }

    public BrandListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandListResponse (BrandListResponse brandListResponse) : base(
        brandListResponse
    )
    {  }
    #pragma warning restore CS8618

    public BrandListResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BrandListResponseFromRaw.FromRawUnchecked"/>
    public static BrandListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BrandListResponseFromRaw : IFromRawJson<BrandListResponse>
{
    /// <inheritdoc/>
    public BrandListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BrandListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of the brand
/// </summary>
[JsonConverter(typeof(BrandListResponseStatusConverter))]
public enum BrandListResponseStatus
{
    Ok, RegistrationPending, RegistrationFailed
}sealed class BrandListResponseStatusConverter : JsonConverter<BrandListResponseStatus>
{
    public override BrandListResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OK"=>BrandListResponseStatus.Ok,
            "REGISTRATION_PENDING"=>BrandListResponseStatus.RegistrationPending,
            "REGISTRATION_FAILED"=>BrandListResponseStatus.RegistrationFailed,
            _ =>(BrandListResponseStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BrandListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BrandListResponseStatus.Ok=>"OK",
            BrandListResponseStatus.RegistrationPending=>"REGISTRATION_PENDING",
            BrandListResponseStatus.RegistrationFailed=>"REGISTRATION_FAILED",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}