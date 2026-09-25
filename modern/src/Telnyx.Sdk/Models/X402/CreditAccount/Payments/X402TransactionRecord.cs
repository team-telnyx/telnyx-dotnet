using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.X402.CreditAccount.Payments;

/// <summary>
/// An x402 payment transaction.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<X402TransactionRecord, X402TransactionRecordFromRaw>))]
public sealed record class X402TransactionRecord : JsonModel
{
    /// <summary>
    /// Unique transaction identifier.
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
    /// The transaction amount in the specified currency.
    /// </summary>
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when the transaction was created.
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
    /// The currency of the transaction amount (e.g. USD).
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
    /// The original quote ID associated with this transaction.
    /// </summary>
    public string? QuoteID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "quote_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("quote_id", value);
        }
    }

    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
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
    /// The settlement status of the transaction. x402 transactions are created after
    /// successful on-chain settlement, so the status is `settled`.
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// The on-chain transaction hash, if available.
    /// </summary>
    public string? TxHash {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tx_hash"
            );
        }
        init { this._rawData.Set("tx_hash", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp when the transaction was last updated.
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
        _ = this.Amount;
        _ = this.CreatedAt;
        _ = this.Currency;
        _ = this.QuoteID;
        this.RecordType?.Validate();
        this.Status?.Validate();
        _ = this.TxHash;
        _ = this.UpdatedAt;
    }

    public X402TransactionRecord ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public X402TransactionRecord (
        X402TransactionRecord x402TransactionRecord
    ) : base(x402TransactionRecord)
    {  }
    #pragma warning restore CS8618

    public X402TransactionRecord (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    X402TransactionRecord (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="X402TransactionRecordFromRaw.FromRawUnchecked"/>
    public static X402TransactionRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class X402TransactionRecordFromRaw : IFromRawJson<X402TransactionRecord>
{
    /// <inheritdoc/>
    public X402TransactionRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>X402TransactionRecord.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    X402Transaction
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "x402_transaction"=>RecordType.X402Transaction, _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.X402Transaction=>"x402_transaction",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The settlement status of the transaction. x402 transactions are created after
/// successful on-chain settlement, so the status is `settled`.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Settled
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "settled"=>Status.Settled, _ =>(Status)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Settled=>"settled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}