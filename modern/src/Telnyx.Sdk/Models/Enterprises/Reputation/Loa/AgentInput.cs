using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises.Reputation.Loa;

/// <summary>
/// Third-party reseller / partner managing the enterprise's phone numbers. Omit
/// when the enterprise works directly with Telnyx.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AgentInput, AgentInputFromRaw>))]
public sealed record class AgentInput : JsonModel
{
    public required string AdministrativeArea {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "administrative_area"
            );
        }
        init { this._rawData.Set("administrative_area", value); }
    }

    public required string City {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "city"
            );
        }
        init { this._rawData.Set("city", value); }
    }

    public required string ContactEmail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "contact_email"
            );
        }
        init { this._rawData.Set("contact_email", value); }
    }

    public required string ContactName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "contact_name"
            );
        }
        init { this._rawData.Set("contact_name", value); }
    }

    public required string ContactPhone {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "contact_phone"
            );
        }
        init { this._rawData.Set("contact_phone", value); }
    }

    public required string ContactTitle {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "contact_title"
            );
        }
        init { this._rawData.Set("contact_title", value); }
    }

    public required string Country {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "country"
            );
        }
        init { this._rawData.Set("country", value); }
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

    public required string PostalCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "postal_code"
            );
        }
        init { this._rawData.Set("postal_code", value); }
    }

    public required string StreetAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "street_address"
            );
        }
        init { this._rawData.Set("street_address", value); }
    }

    public string? Dba {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "dba"
            );
        }
        init { this._rawData.Set("dba", value); }
    }

    public string? ExtendedAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "extended_address"
            );
        }
        init { this._rawData.Set("extended_address", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdministrativeArea;
        _ = this.City;
        _ = this.ContactEmail;
        _ = this.ContactName;
        _ = this.ContactPhone;
        _ = this.ContactTitle;
        _ = this.Country;
        _ = this.LegalName;
        _ = this.PostalCode;
        _ = this.StreetAddress;
        _ = this.Dba;
        _ = this.ExtendedAddress;
    }

    public AgentInput ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentInput (AgentInput agentInput) : base(agentInput)
    {  }
    #pragma warning restore CS8618

    public AgentInput (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentInput (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AgentInputFromRaw.FromRawUnchecked"/>
    public static AgentInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AgentInputFromRaw : IFromRawJson<AgentInput>
{
    /// <inheritdoc/>
    public AgentInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AgentInput.FromRawUnchecked(rawData);
}