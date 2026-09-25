using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.ManagedAccounts;

[JsonConverter(typeof(JsonModelConverter<ManagedAccount, ManagedAccountFromRaw>))]
public sealed record class ManagedAccount : JsonModel
{
    /// <summary>
    /// Uniquely identifies the managed account.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The managed account's V2 API access key
    /// </summary>
    public required string ApiKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "api_key"
            );
        }
        init { this._rawData.Set("api_key", value); }
    }

    /// <summary>
    /// The managed account's V1 API token
    /// </summary>
    public required string ApiToken {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "api_token"
            );
        }
        init { this._rawData.Set("api_token", value); }
    }

    /// <summary>
    /// The manager account's email, which serves as the V1 API user identifier
    /// </summary>
    public required string ApiUser {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "api_user"
            );
        }
        init { this._rawData.Set("api_user", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public required string CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The managed account's email.
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
    /// The ID of the manager account associated with the managed account.
    /// </summary>
    public required string ManagerAccountID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "manager_account_id"
            );
        }
        init { this._rawData.Set("manager_account_id", value); }
    }

    /// <summary>
    /// Identifies the type of the resource.
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
    /// ISO 8601 formatted date indicating when the resource was updated.
    /// </summary>
    public required string UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public ManagedAccountBalance? Balance {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ManagedAccountBalance>(
                "balance"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("balance", value);
        }
    }

    /// <summary>
    /// Boolean value that indicates if the managed account is able to have custom
    /// pricing set for it or not. If false, uses the pricing of the manager account.
    /// Defaults to false. There may be time lag between when the value is changed
    /// and pricing changes take effect.
    /// </summary>
    public bool? ManagedAccountAllowCustomPricing {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "managed_account_allow_custom_pricing"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("managed_account_allow_custom_pricing", value);
        }
    }

    /// <summary>
    /// The organization the managed account is associated with.
    /// </summary>
    public string? OrganizationName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_name", value);
        }
    }

    /// <summary>
    /// Boolean value that indicates if the billing information and charges to the
    /// managed account "roll up" to the manager account. If true, the managed account
    /// will not have its own balance and will use the shared balance with the manager
    /// account. This value cannot be changed after account creation without going
    /// through Telnyx support as changes require manual updates to the account ledger.
    /// Defaults to false.
    /// </summary>
    public bool? RollupBilling {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "rollup_billing"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rollup_billing", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ApiKey;
        _ = this.ApiToken;
        _ = this.ApiUser;
        _ = this.CreatedAt;
        _ = this.Email;
        _ = this.ManagerAccountID;
        this.RecordType.Validate();
        _ = this.UpdatedAt;
        this.Balance?.Validate();
        _ = this.ManagedAccountAllowCustomPricing;
        _ = this.OrganizationName;
        _ = this.RollupBilling;
    }

    public ManagedAccount ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ManagedAccount (ManagedAccount managedAccount) : base(managedAccount)
    {  }
    #pragma warning restore CS8618

    public ManagedAccount (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ManagedAccount (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ManagedAccountFromRaw.FromRawUnchecked"/>
    public static ManagedAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ManagedAccountFromRaw : IFromRawJson<ManagedAccount>
{
    /// <inheritdoc/>
    public ManagedAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ManagedAccount.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    ManagedAccount
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "managed_account"=>RecordType.ManagedAccount, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.ManagedAccount=>"managed_account",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}