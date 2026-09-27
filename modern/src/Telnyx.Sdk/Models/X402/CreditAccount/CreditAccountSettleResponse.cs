using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.X402.CreditAccount;

[JsonConverter(typeof(JsonModelConverter<CreditAccountSettleResponse, CreditAccountSettleResponseFromRaw>))]
public sealed record class CreditAccountSettleResponse : JsonModel
{
    public CreditAccountSettleResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreditAccountSettleResponseData>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public CreditAccountSettleResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditAccountSettleResponse (
        CreditAccountSettleResponse creditAccountSettleResponse
    ) : base(creditAccountSettleResponse)
    {  }
    #pragma warning restore CS8618

    public CreditAccountSettleResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditAccountSettleResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CreditAccountSettleResponseFromRaw.FromRawUnchecked"/>
    public static CreditAccountSettleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CreditAccountSettleResponseFromRaw : IFromRawJson<CreditAccountSettleResponse>
{
    /// <inheritdoc/>
    public CreditAccountSettleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CreditAccountSettleResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CreditAccountSettleResponseData, CreditAccountSettleResponseDataFromRaw>))]
public sealed record class CreditAccountSettleResponseData : JsonModel
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

    public ApiEnum<string, CreditAccountSettleResponseDataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CreditAccountSettleResponseDataRecordType>>(
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
    /// The settlement status of the transaction.
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
    }

    public CreditAccountSettleResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditAccountSettleResponseData (
        CreditAccountSettleResponseData creditAccountSettleResponseData
    ) : base(creditAccountSettleResponseData)
    {  }
    #pragma warning restore CS8618

    public CreditAccountSettleResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditAccountSettleResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CreditAccountSettleResponseDataFromRaw.FromRawUnchecked"/>
    public static CreditAccountSettleResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CreditAccountSettleResponseDataFromRaw : IFromRawJson<CreditAccountSettleResponseData>
{
    /// <inheritdoc/>
    public CreditAccountSettleResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CreditAccountSettleResponseData.FromRawUnchecked(rawData);
}[JsonConverter(typeof(CreditAccountSettleResponseDataRecordTypeConverter))]
public enum CreditAccountSettleResponseDataRecordType
{
    X402Transaction
}sealed class CreditAccountSettleResponseDataRecordTypeConverter : JsonConverter<CreditAccountSettleResponseDataRecordType>
{
    public override CreditAccountSettleResponseDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "x402_transaction"=>CreditAccountSettleResponseDataRecordType.X402Transaction,
            _ =>(CreditAccountSettleResponseDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditAccountSettleResponseDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CreditAccountSettleResponseDataRecordType.X402Transaction=>"x402_transaction",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The settlement status of the transaction.
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