using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Porting.LoaConfigurations;

/// <summary>
/// Preview the LOA template that would be generated without need to create LOA configuration.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class LoaConfigurationPreviewParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The address of the company.
    /// </summary>
    public required LoaConfigurationPreviewParamsAddress Address {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<LoaConfigurationPreviewParamsAddress>(
                "address"
            );
        }
        init { this._rawBodyData.Set("address", value); }
    }

    /// <summary>
    /// The name of the company
    /// </summary>
    public required string CompanyName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "company_name"
            );
        }
        init { this._rawBodyData.Set("company_name", value); }
    }

    /// <summary>
    /// The contact information of the company.
    /// </summary>
    public required LoaConfigurationPreviewParamsContact Contact {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<LoaConfigurationPreviewParamsContact>(
                "contact"
            );
        }
        init { this._rawBodyData.Set("contact", value); }
    }

    /// <summary>
    /// The logo of the LOA configuration
    /// </summary>
    public required LoaConfigurationPreviewParamsLogo Logo {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<LoaConfigurationPreviewParamsLogo>(
                "logo"
            );
        }
        init { this._rawBodyData.Set("logo", value); }
    }

    /// <summary>
    /// The name of the LOA configuration
    /// </summary>
    public required string Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawBodyData.Set("name", value); }
    }

    public LoaConfigurationPreviewParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LoaConfigurationPreviewParams (
        LoaConfigurationPreviewParams loaConfigurationPreviewParams
    ) : base(loaConfigurationPreviewParams)
    { this._rawBodyData = new(loaConfigurationPreviewParams._rawBodyData); }
    #pragma warning restore CS8618

    public LoaConfigurationPreviewParams (
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
    LoaConfigurationPreviewParams (
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
    public static LoaConfigurationPreviewParams FromRawUnchecked(
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

    public virtual bool Equals(LoaConfigurationPreviewParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/porting/loa_configurations/preview"
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
        request.Headers.Add("Accept", "application/pdf");
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
/// The address of the company.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LoaConfigurationPreviewParamsAddress, LoaConfigurationPreviewParamsAddressFromRaw>))]
public sealed record class LoaConfigurationPreviewParamsAddress : JsonModel
{
    /// <summary>
    /// The locality of the company
    /// </summary>
    public required string City {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "city"
            );
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The country code of the company
    /// </summary>
    public required string CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "country_code"
            );
        }
        init { this._rawData.Set("country_code", value); }
    }

    /// <summary>
    /// The administrative area of the company
    /// </summary>
    public required string State {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "state"
            );
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The street address of the company
    /// </summary>
    public required string StreetAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "street_address"
            );
        }
        init { this._rawData.Set("street_address", value); }
    }

    /// <summary>
    /// The postal code of the company
    /// </summary>
    public required string ZipCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "zip_code"
            );
        }
        init { this._rawData.Set("zip_code", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.CountryCode;
        _ = this.State;
        _ = this.StreetAddress;
        _ = this.ZipCode;
        _ = this.ExtendedAddress;
    }

    public LoaConfigurationPreviewParamsAddress ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LoaConfigurationPreviewParamsAddress (
        LoaConfigurationPreviewParamsAddress loaConfigurationPreviewParamsAddress
    ) : base(loaConfigurationPreviewParamsAddress)
    {  }
    #pragma warning restore CS8618

    public LoaConfigurationPreviewParamsAddress (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LoaConfigurationPreviewParamsAddress (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LoaConfigurationPreviewParamsAddressFromRaw.FromRawUnchecked"/>
    public static LoaConfigurationPreviewParamsAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class LoaConfigurationPreviewParamsAddressFromRaw : IFromRawJson<LoaConfigurationPreviewParamsAddress>
{
    /// <inheritdoc/>
    public LoaConfigurationPreviewParamsAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LoaConfigurationPreviewParamsAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The contact information of the company.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LoaConfigurationPreviewParamsContact, LoaConfigurationPreviewParamsContactFromRaw>))]
public sealed record class LoaConfigurationPreviewParamsContact : JsonModel
{
    /// <summary>
    /// The email address of the contact
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
    /// The phone number of the contact
    /// </summary>
    public required string PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phone_number"
            );
        }
        init { this._rawData.Set("phone_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.PhoneNumber;
    }

    public LoaConfigurationPreviewParamsContact ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LoaConfigurationPreviewParamsContact (
        LoaConfigurationPreviewParamsContact loaConfigurationPreviewParamsContact
    ) : base(loaConfigurationPreviewParamsContact)
    {  }
    #pragma warning restore CS8618

    public LoaConfigurationPreviewParamsContact (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LoaConfigurationPreviewParamsContact (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LoaConfigurationPreviewParamsContactFromRaw.FromRawUnchecked"/>
    public static LoaConfigurationPreviewParamsContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class LoaConfigurationPreviewParamsContactFromRaw : IFromRawJson<LoaConfigurationPreviewParamsContact>
{
    /// <inheritdoc/>
    public LoaConfigurationPreviewParamsContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LoaConfigurationPreviewParamsContact.FromRawUnchecked(rawData);
}

/// <summary>
/// The logo of the LOA configuration
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LoaConfigurationPreviewParamsLogo, LoaConfigurationPreviewParamsLogoFromRaw>))]
public sealed record class LoaConfigurationPreviewParamsLogo : JsonModel
{
    /// <summary>
    /// The document identification
    /// </summary>
    public required string DocumentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "document_id"
            );
        }
        init { this._rawData.Set("document_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.DocumentID; }

    public LoaConfigurationPreviewParamsLogo ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LoaConfigurationPreviewParamsLogo (
        LoaConfigurationPreviewParamsLogo loaConfigurationPreviewParamsLogo
    ) : base(loaConfigurationPreviewParamsLogo)
    {  }
    #pragma warning restore CS8618

    public LoaConfigurationPreviewParamsLogo (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LoaConfigurationPreviewParamsLogo (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LoaConfigurationPreviewParamsLogoFromRaw.FromRawUnchecked"/>
    public static LoaConfigurationPreviewParamsLogo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public LoaConfigurationPreviewParamsLogo (string documentID) : this()
    { this.DocumentID = documentID; }
}

class LoaConfigurationPreviewParamsLogoFromRaw : IFromRawJson<LoaConfigurationPreviewParamsLogo>
{
    /// <inheritdoc/>
    public LoaConfigurationPreviewParamsLogo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LoaConfigurationPreviewParamsLogo.FromRawUnchecked(rawData);
}