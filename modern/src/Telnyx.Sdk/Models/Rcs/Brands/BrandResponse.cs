using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Rcs.Agents;

namespace Telnyx.Sdk.Models.Rcs.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandResponse, BrandResponseFromRaw>))]
public sealed record class BrandResponse : JsonModel
{
    public required IReadOnlyDictionary<string, BrandAddress> Addresses {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, BrandAddress>>(
                "addresses"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, BrandAddress>>(
                "addresses",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required string BrandID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "brand_id"
            );
        }
        init { this._rawData.Set("brand_id", value); }
    }

    public required CapabilitiesResponse Capabilities {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitiesResponse>(
                "capabilities"
            );
        }
        init { this._rawData.Set("capabilities", value); }
    }

    public required IReadOnlyDictionary<string, BrandContact> Contacts {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, BrandContact>>(
                "contacts"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, BrandContact>>(
                "contacts",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required string DisplayName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "display_name"
            );
        }
        init { this._rawData.Set("display_name", value); }
    }

    public required IReadOnlyDictionary<string, BrandIdentifier> Identifiers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, BrandIdentifier>>(
                "identifiers"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, BrandIdentifier>>(
                "identifiers",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required string LegalEntityType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "legal_entity_type"
            );
        }
        init { this._rawData.Set("legal_entity_type", value); }
    }

    public required string LegalName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "legal_name"
            );
        }
        init { this._rawData.Set("legal_name", value); }
    }

    public required string OrganizationType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "organization_type"
            );
        }
        init { this._rawData.Set("organization_type", value); }
    }

    public required string? ProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "profile_id"
            );
        }
        init { this._rawData.Set("profile_id", value); }
    }

    public required ApiEnum<string, global::Telnyx.Sdk.Models.Rcs.Brands.Status> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, global::Telnyx.Sdk.Models.Rcs.Brands.Status>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required string WebsiteUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "website_url"
            );
        }
        init { this._rawData.Set("website_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Addresses.Values)
        {
            item.Validate();
        }
        _ = this.BrandID;
        this.Capabilities.Validate();
        foreach (var item in this.Contacts.Values)
        {
            item.Validate();
        }
        _ = this.DisplayName;
        foreach (var item in this.Identifiers.Values)
        {
            item.Validate();
        }
        _ = this.LegalEntityType;
        _ = this.LegalName;
        _ = this.OrganizationType;
        _ = this.ProfileID;
        this.Status.Validate();
        _ = this.WebsiteUrl;
    }

    public BrandResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandResponse (BrandResponse brandResponse) : base(brandResponse)
    {  }
    #pragma warning restore CS8618

    public BrandResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BrandResponseFromRaw.FromRawUnchecked"/>
    public static BrandResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BrandResponseFromRaw : IFromRawJson<BrandResponse>
{
    /// <inheritdoc/>
    public BrandResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BrandResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::Telnyx.Sdk.Models.Rcs.Brands.StatusConverter))]
public enum Status
{
    Created,
    Configured,
    Submitted,
    Reviewing,
    Vetting,
    Verified,
    Rejected,
    Failed
}sealed class StatusConverter : JsonConverter<global::Telnyx.Sdk.Models.Rcs.Brands.Status>
{
    public override global::Telnyx.Sdk.Models.Rcs.Brands.Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CREATED"=>global::Telnyx.Sdk.Models.Rcs.Brands.Status.Created,
            "CONFIGURED"=>global::Telnyx.Sdk.Models.Rcs.Brands.Status.Configured,
            "SUBMITTED"=>global::Telnyx.Sdk.Models.Rcs.Brands.Status.Submitted,
            "REVIEWING"=>global::Telnyx.Sdk.Models.Rcs.Brands.Status.Reviewing,
            "VETTING"=>global::Telnyx.Sdk.Models.Rcs.Brands.Status.Vetting,
            "VERIFIED"=>global::Telnyx.Sdk.Models.Rcs.Brands.Status.Verified,
            "REJECTED"=>global::Telnyx.Sdk.Models.Rcs.Brands.Status.Rejected,
            "FAILED"=>global::Telnyx.Sdk.Models.Rcs.Brands.Status.Failed,
            _ =>(global::Telnyx.Sdk.Models.Rcs.Brands.Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.Rcs.Brands.Status value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.Rcs.Brands.Status.Created=>"CREATED",
            global::Telnyx.Sdk.Models.Rcs.Brands.Status.Configured=>"CONFIGURED",
            global::Telnyx.Sdk.Models.Rcs.Brands.Status.Submitted=>"SUBMITTED",
            global::Telnyx.Sdk.Models.Rcs.Brands.Status.Reviewing=>"REVIEWING",
            global::Telnyx.Sdk.Models.Rcs.Brands.Status.Vetting=>"VETTING",
            global::Telnyx.Sdk.Models.Rcs.Brands.Status.Verified=>"VERIFIED",
            global::Telnyx.Sdk.Models.Rcs.Brands.Status.Rejected=>"REJECTED",
            global::Telnyx.Sdk.Models.Rcs.Brands.Status.Failed=>"FAILED",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}