using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Porting.LoaConfigurations;

[JsonConverter(typeof(JsonModelConverter<PortingLoaConfiguration, PortingLoaConfigurationFromRaw>))]
public sealed record class PortingLoaConfiguration : JsonModel
{
    /// <summary>
    /// Uniquely identifies the LOA configuration.
    /// </summary>
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

    /// <summary>
    /// The address of the company.
    /// </summary>
    public PortingLoaConfigurationAddress? Address {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingLoaConfigurationAddress>(
                "address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    /// <summary>
    /// The name of the company
    /// </summary>
    public string? CompanyName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "company_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("company_name", value);
        }
    }

    /// <summary>
    /// The contact information of the company.
    /// </summary>
    public PortingLoaConfigurationContact? Contact {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingLoaConfigurationContact>(
                "contact"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("contact", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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

    /// <summary>
    /// The logo to be used in the LOA.
    /// </summary>
    public PortingLoaConfigurationLogo? Logo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingLoaConfigurationLogo>(
                "logo"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("logo", value);
        }
    }

    /// <summary>
    /// The name of the LOA configuration
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The organization that owns the LOA configuration
    /// </summary>
    public string? OrganizationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_id", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was updated.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Address?.Validate();
        _ = this.CompanyName;
        this.Contact?.Validate();
        _ = this.CreatedAt;
        this.Logo?.Validate();
        _ = this.Name;
        _ = this.OrganizationID;
        _ = this.RecordType;
        _ = this.UpdatedAt;
    }

    public PortingLoaConfiguration ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingLoaConfiguration (
        PortingLoaConfiguration portingLoaConfiguration
    ) : base(portingLoaConfiguration)
    {  }
    #pragma warning restore CS8618

    public PortingLoaConfiguration (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingLoaConfiguration (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingLoaConfigurationFromRaw.FromRawUnchecked"/>
    public static PortingLoaConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingLoaConfigurationFromRaw : IFromRawJson<PortingLoaConfiguration>
{
    /// <inheritdoc/>
    public PortingLoaConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingLoaConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// The address of the company.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PortingLoaConfigurationAddress, PortingLoaConfigurationAddressFromRaw>))]
public sealed record class PortingLoaConfigurationAddress : JsonModel
{
    /// <summary>
    /// The locality of the company
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
    /// The country code of the company
    /// </summary>
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

    /// <summary>
    /// The extended address of the company
    /// </summary>
    public string? ExtendedAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "extended_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("extended_address", value);
        }
    }

    /// <summary>
    /// The administrative area of the company
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
    /// The street address of the company
    /// </summary>
    public string? StreetAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "street_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("street_address", value);
        }
    }

    /// <summary>
    /// The postal code of the company
    /// </summary>
    public string? ZipCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "zip_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("zip_code", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.CountryCode;
        _ = this.ExtendedAddress;
        _ = this.State;
        _ = this.StreetAddress;
        _ = this.ZipCode;
    }

    public PortingLoaConfigurationAddress ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingLoaConfigurationAddress (
        PortingLoaConfigurationAddress portingLoaConfigurationAddress
    ) : base(portingLoaConfigurationAddress)
    {  }
    #pragma warning restore CS8618

    public PortingLoaConfigurationAddress (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingLoaConfigurationAddress (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingLoaConfigurationAddressFromRaw.FromRawUnchecked"/>
    public static PortingLoaConfigurationAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortingLoaConfigurationAddressFromRaw : IFromRawJson<PortingLoaConfigurationAddress>
{
    /// <inheritdoc/>
    public PortingLoaConfigurationAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingLoaConfigurationAddress.FromRawUnchecked(rawData);
}/// <summary>
/// The contact information of the company.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PortingLoaConfigurationContact, PortingLoaConfigurationContactFromRaw>))]
public sealed record class PortingLoaConfigurationContact : JsonModel
{
    /// <summary>
    /// The email address of the contact
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
    /// The phone number of the contact
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.PhoneNumber;
    }

    public PortingLoaConfigurationContact ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingLoaConfigurationContact (
        PortingLoaConfigurationContact portingLoaConfigurationContact
    ) : base(portingLoaConfigurationContact)
    {  }
    #pragma warning restore CS8618

    public PortingLoaConfigurationContact (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingLoaConfigurationContact (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingLoaConfigurationContactFromRaw.FromRawUnchecked"/>
    public static PortingLoaConfigurationContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortingLoaConfigurationContactFromRaw : IFromRawJson<PortingLoaConfigurationContact>
{
    /// <inheritdoc/>
    public PortingLoaConfigurationContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingLoaConfigurationContact.FromRawUnchecked(rawData);
}/// <summary>
/// The logo to be used in the LOA.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PortingLoaConfigurationLogo, PortingLoaConfigurationLogoFromRaw>))]
public sealed record class PortingLoaConfigurationLogo : JsonModel
{
    /// <summary>
    /// The content type of the logo.
    /// </summary>
    public ApiEnum<string, ContentType>? ContentType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ContentType>>(
                "content_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("content_type", value);
        }
    }

    /// <summary>
    /// Identifies the document that contains the logo.
    /// </summary>
    public string? DocumentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "document_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("document_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ContentType?.Validate();
        _ = this.DocumentID;
    }

    public PortingLoaConfigurationLogo ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingLoaConfigurationLogo (
        PortingLoaConfigurationLogo portingLoaConfigurationLogo
    ) : base(portingLoaConfigurationLogo)
    {  }
    #pragma warning restore CS8618

    public PortingLoaConfigurationLogo (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingLoaConfigurationLogo (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingLoaConfigurationLogoFromRaw.FromRawUnchecked"/>
    public static PortingLoaConfigurationLogo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortingLoaConfigurationLogoFromRaw : IFromRawJson<PortingLoaConfigurationLogo>
{
    /// <inheritdoc/>
    public PortingLoaConfigurationLogo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingLoaConfigurationLogo.FromRawUnchecked(rawData);
}/// <summary>
/// The content type of the logo.
/// </summary>
[JsonConverter(typeof(ContentTypeConverter))]
public enum ContentType
{
    ImagePng
}sealed class ContentTypeConverter : JsonConverter<ContentType>
{
    public override ContentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "image/png"=>ContentType.ImagePng, _ =>(ContentType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, ContentType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ContentType.ImagePng=>"image/png",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}