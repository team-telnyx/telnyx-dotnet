using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders;

[JsonConverter(typeof(JsonModelConverter<PortingOrderEndUserAdmin, PortingOrderEndUserAdminFromRaw>))]
public sealed record class PortingOrderEndUserAdmin : JsonModel
{
    /// <summary>
    /// The authorized person's account number with the current service provider
    /// </summary>
    public string? AccountNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "account_number"
            );
        }
        init { this._rawData.Set("account_number", value); }
    }

    /// <summary>
    /// Name of person authorizing the porting order
    /// </summary>
    public string? AuthPersonName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "auth_person_name"
            );
        }
        init { this._rawData.Set("auth_person_name", value); }
    }

    /// <summary>
    /// Billing phone number associated with these phone numbers
    /// </summary>
    public string? BillingPhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "billing_phone_number"
            );
        }
        init { this._rawData.Set("billing_phone_number", value); }
    }

    /// <summary>
    /// European business identification number. Applicable only in the European Union
    /// </summary>
    public string? BusinessIdentifier {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "business_identifier"
            );
        }
        init { this._rawData.Set("business_identifier", value); }
    }

    /// <summary>
    /// Person Name or Company name requesting the port
    /// </summary>
    public string? EntityName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "entity_name"
            );
        }
        init { this._rawData.Set("entity_name", value); }
    }

    /// <summary>
    /// PIN/passcode possibly required by the old service provider for extra verification
    /// </summary>
    public string? PinPasscode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "pin_passcode"
            );
        }
        init { this._rawData.Set("pin_passcode", value); }
    }

    /// <summary>
    /// European tax identification number. Applicable only in the European Union
    /// </summary>
    public string? TaxIdentifier {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tax_identifier"
            );
        }
        init { this._rawData.Set("tax_identifier", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountNumber;
        _ = this.AuthPersonName;
        _ = this.BillingPhoneNumber;
        _ = this.BusinessIdentifier;
        _ = this.EntityName;
        _ = this.PinPasscode;
        _ = this.TaxIdentifier;
    }

    public PortingOrderEndUserAdmin ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderEndUserAdmin (
        PortingOrderEndUserAdmin portingOrderEndUserAdmin
    ) : base(portingOrderEndUserAdmin)
    {  }
    #pragma warning restore CS8618

    public PortingOrderEndUserAdmin (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderEndUserAdmin (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderEndUserAdminFromRaw.FromRawUnchecked"/>
    public static PortingOrderEndUserAdmin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderEndUserAdminFromRaw : IFromRawJson<PortingOrderEndUserAdmin>
{
    /// <inheritdoc/>
    public PortingOrderEndUserAdmin FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderEndUserAdmin.FromRawUnchecked(rawData);
}