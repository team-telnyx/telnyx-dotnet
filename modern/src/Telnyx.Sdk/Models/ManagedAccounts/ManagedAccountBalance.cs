using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.ManagedAccounts;

[JsonConverter(typeof(JsonModelConverter<ManagedAccountBalance, ManagedAccountBalanceFromRaw>))]
public sealed record class ManagedAccountBalance : JsonModel
{
    /// <summary>
    /// Available amount to spend (balance + credit limit)
    /// </summary>
    public string? AvailableCredit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "available_credit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("available_credit", value);
        }
    }

    /// <summary>
    /// The account's current balance.
    /// </summary>
    public string? Balance {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// The account's credit limit.
    /// </summary>
    public string? CreditLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "credit_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("credit_limit", value);
        }
    }

    /// <summary>
    /// The ISO 4217 currency identifier.
    /// </summary>
    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public ApiEnum<string, ManagedAccountBalanceRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ManagedAccountBalanceRecordType>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AvailableCredit;
        _ = this.Balance;
        _ = this.CreditLimit;
        _ = this.Currency;
        this.RecordType?.Validate();
    }

    public ManagedAccountBalance ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ManagedAccountBalance (
        ManagedAccountBalance managedAccountBalance
    ) : base(managedAccountBalance)
    {  }
    #pragma warning restore CS8618

    public ManagedAccountBalance (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ManagedAccountBalance (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ManagedAccountBalanceFromRaw.FromRawUnchecked"/>
    public static ManagedAccountBalance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ManagedAccountBalanceFromRaw : IFromRawJson<ManagedAccountBalance>
{
    /// <inheritdoc/>
    public ManagedAccountBalance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ManagedAccountBalance.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(ManagedAccountBalanceRecordTypeConverter))]
public enum ManagedAccountBalanceRecordType
{
    Balance
}sealed class ManagedAccountBalanceRecordTypeConverter : JsonConverter<ManagedAccountBalanceRecordType>
{
    public override ManagedAccountBalanceRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "balance"=>ManagedAccountBalanceRecordType.Balance,
            _ =>(ManagedAccountBalanceRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ManagedAccountBalanceRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ManagedAccountBalanceRecordType.Balance=>"balance",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}