using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises;

[JsonConverter(typeof(JsonModelConverter<BillingContact, BillingContactFromRaw>))]
public sealed record class BillingContact : JsonModel
{
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

    /// <summary>
    /// E.164 format with leading `+`.
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
        _ = this.FirstName;
        _ = this.LastName;
        _ = this.PhoneNumber;
    }

    public BillingContact ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingContact (BillingContact billingContact) : base(billingContact)
    {  }
    #pragma warning restore CS8618

    public BillingContact (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingContact (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BillingContactFromRaw.FromRawUnchecked"/>
    public static BillingContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BillingContactFromRaw : IFromRawJson<BillingContact>
{
    /// <inheritdoc/>
    public BillingContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BillingContact.FromRawUnchecked(rawData);
}