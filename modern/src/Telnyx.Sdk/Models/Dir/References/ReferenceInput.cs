using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Dir.References;

/// <summary>
/// One reference supplied at submit. The reference type is implied by the field that
/// carries it (business_references vs financial_reference).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReferenceInput, ReferenceInputFromRaw>))]
public sealed record class ReferenceInput : JsonModel
{
    /// <summary>
    /// Reference contact email address. Required: the reference is emailed scheduling
    /// and dial-in notices.
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
    /// Full name of the reference contact.
    /// </summary>
    public required string FullName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "full_name"
            );
        }
        init { this._rawData.Set("full_name", value); }
    }

    /// <summary>
    /// Reference phone number in E.164 format, e.g. +14155550123.
    /// </summary>
    public required string PhoneE164 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phone_e164"
            );
        }
        init { this._rawData.Set("phone_e164", value); }
    }

    /// <summary>
    /// IANA timezone id for the reference (e.g. America/New_York). Required: calls
    /// are only placed within the reference's local 8am-9pm window.
    /// </summary>
    public required string Timezone {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "timezone"
            );
        }
        init { this._rawData.Set("timezone", value); }
    }

    /// <summary>
    /// Job title of the reference contact.
    /// </summary>
    public string? JobTitle {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "job_title"
            );
        }
        init { this._rawData.Set("job_title", value); }
    }

    /// <summary>
    /// Organization the reference contact belongs to.
    /// </summary>
    public string? Organization {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization"
            );
        }
        init { this._rawData.Set("organization", value); }
    }

    /// <summary>
    /// How the reference contact is related to the registering business.
    /// </summary>
    public string? RelationshipToRegistrant {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "relationship_to_registrant"
            );
        }
        init { this._rawData.Set("relationship_to_registrant", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.FullName;
        _ = this.PhoneE164;
        _ = this.Timezone;
        _ = this.JobTitle;
        _ = this.Organization;
        _ = this.RelationshipToRegistrant;
    }

    public ReferenceInput ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReferenceInput (ReferenceInput referenceInput) : base(referenceInput)
    {  }
    #pragma warning restore CS8618

    public ReferenceInput (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReferenceInput (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReferenceInputFromRaw.FromRawUnchecked"/>
    public static ReferenceInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReferenceInputFromRaw : IFromRawJson<ReferenceInput>
{
    /// <inheritdoc/>
    public ReferenceInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReferenceInput.FromRawUnchecked(rawData);
}