using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Dir.References;

/// <summary>
/// A reference (business or financial) on a DIR, in the customer-facing shape. No
/// internal identifiers are exposed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Reference, ReferenceFromRaw>))]
public sealed record class Reference : JsonModel
{
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
    /// Reference phone number in E.164 format.
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
    /// Always `dir_reference`.
    /// </summary>
    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Whether this is a business reference or the financial reference.
    /// </summary>
    public required ApiEnum<string, ReferenceRefType> RefType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ReferenceRefType>>(
                "ref_type"
            );
        }
        init { this._rawData.Set("ref_type", value); }
    }

    /// <summary>
    /// Position within the reference type, counting from 1. Business references
    /// occupy slots 1 and 2, in the order they were sent in the `business_references`
    /// array; the financial reference occupies slot 1. Use this value together with
    /// `ref_type` to address the reference when updating it.
    /// </summary>
    public required long Slot {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "slot"
            );
        }
        init { this._rawData.Set("slot", value); }
    }

    /// <summary>
    /// IANA timezone id for the reference. Calls are only placed within the reference's
    /// local 8am-9pm window.
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
    /// Reference contact email address.
    /// </summary>
    public string? Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "email"
            );
        }
        init { this._rawData.Set("email", value); }
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
        _ = this.FullName;
        _ = this.PhoneE164;
        this.RecordType.Validate();
        this.RefType.Validate();
        _ = this.Slot;
        _ = this.Timezone;
        _ = this.Email;
        _ = this.JobTitle;
        _ = this.Organization;
        _ = this.RelationshipToRegistrant;
    }

    public Reference ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Reference (Reference reference) : base(reference)
    {  }
    #pragma warning restore CS8618

    public Reference (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Reference (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReferenceFromRaw.FromRawUnchecked"/>
    public static Reference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReferenceFromRaw : IFromRawJson<Reference>
{
    /// <inheritdoc/>
    public Reference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Reference.FromRawUnchecked(rawData);
}

/// <summary>
/// Always `dir_reference`.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    DirReference
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "dir_reference"=>RecordType.DirReference, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.DirReference=>"dir_reference",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Whether this is a business reference or the financial reference.
/// </summary>
[JsonConverter(typeof(ReferenceRefTypeConverter))]
public enum ReferenceRefType
{
    Business, Financial
}sealed class ReferenceRefTypeConverter : JsonConverter<ReferenceRefType>
{
    public override ReferenceRefType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "business"=>ReferenceRefType.Business,
            "financial"=>ReferenceRefType.Financial,
            _ =>(ReferenceRefType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReferenceRefType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ReferenceRefType.Business=>"business",
            ReferenceRefType.Financial=>"financial",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}