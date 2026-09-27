using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Rcs.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandContact, BrandContactFromRaw>))]
public sealed record class BrandContact : JsonModel
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

    public BrandContact ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandContact (BrandContact brandContact) : base(brandContact)
    {  }
    #pragma warning restore CS8618

    public BrandContact (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandContact (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BrandContactFromRaw.FromRawUnchecked"/>
    public static BrandContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BrandContactFromRaw : IFromRawJson<BrandContact>
{
    /// <inheritdoc/>
    public BrandContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BrandContact.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BrandContactContactTypeConverter))]
public enum BrandContactContactType
{
    Brand, Primary, Officer, Agent, ResponsibleParty, Billing, Unknown
}sealed class BrandContactContactTypeConverter : JsonConverter<BrandContactContactType>
{
    public override BrandContactContactType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BRAND"=>BrandContactContactType.Brand,
            "PRIMARY"=>BrandContactContactType.Primary,
            "OFFICER"=>BrandContactContactType.Officer,
            "AGENT"=>BrandContactContactType.Agent,
            "RESPONSIBLE_PARTY"=>BrandContactContactType.ResponsibleParty,
            "BILLING"=>BrandContactContactType.Billing,
            "UNKNOWN"=>BrandContactContactType.Unknown,
            _ =>(BrandContactContactType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BrandContactContactType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BrandContactContactType.Brand=>"BRAND",
            BrandContactContactType.Primary=>"PRIMARY",
            BrandContactContactType.Officer=>"OFFICER",
            BrandContactContactType.Agent=>"AGENT",
            BrandContactContactType.ResponsibleParty=>"RESPONSIBLE_PARTY",
            BrandContactContactType.Billing=>"BILLING",
            BrandContactContactType.Unknown=>"UNKNOWN",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}