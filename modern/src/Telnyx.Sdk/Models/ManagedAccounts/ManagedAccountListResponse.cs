using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.ManagedAccounts;

[JsonConverter(typeof(JsonModelConverter<ManagedAccountListResponse, ManagedAccountListResponseFromRaw>))]
public sealed record class ManagedAccountListResponse : JsonModel
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
    public required ApiEnum<string, ManagedAccountListResponseRecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ManagedAccountListResponseRecordType>>(
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
        _ = this.ApiUser;
        _ = this.CreatedAt;
        _ = this.Email;
        _ = this.ManagerAccountID;
        this.RecordType.Validate();
        _ = this.UpdatedAt;
        _ = this.ManagedAccountAllowCustomPricing;
        _ = this.OrganizationName;
        _ = this.RollupBilling;
    }

    public ManagedAccountListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ManagedAccountListResponse (
        ManagedAccountListResponse managedAccountListResponse
    ) : base(managedAccountListResponse)
    {  }
    #pragma warning restore CS8618

    public ManagedAccountListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ManagedAccountListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ManagedAccountListResponseFromRaw.FromRawUnchecked"/>
    public static ManagedAccountListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ManagedAccountListResponseFromRaw : IFromRawJson<ManagedAccountListResponse>
{
    /// <inheritdoc/>
    public ManagedAccountListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ManagedAccountListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(ManagedAccountListResponseRecordTypeConverter))]
public enum ManagedAccountListResponseRecordType
{
    ManagedAccount
}sealed class ManagedAccountListResponseRecordTypeConverter : JsonConverter<ManagedAccountListResponseRecordType>
{
    public override ManagedAccountListResponseRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "managed_account"=>ManagedAccountListResponseRecordType.ManagedAccount,
            _ =>(ManagedAccountListResponseRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ManagedAccountListResponseRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ManagedAccountListResponseRecordType.ManagedAccount=>"managed_account",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}