using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Balance;

[JsonConverter(typeof(JsonModelConverter<BalanceRetrieveResponse, BalanceRetrieveResponseFromRaw>))]
public sealed record class BalanceRetrieveResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
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

    public BalanceRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceRetrieveResponse (
        BalanceRetrieveResponse balanceRetrieveResponse
    ) : base(balanceRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public BalanceRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BalanceRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static BalanceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BalanceRetrieveResponseFromRaw : IFromRawJson<BalanceRetrieveResponse>
{
    /// <inheritdoc/>
    public BalanceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BalanceRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
    /// The account’s pending amount.
    /// </summary>
    public string? Pending {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "pending"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pending", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AvailableCredit;
        _ = this.Balance;
        _ = this.CreditLimit;
        _ = this.Currency;
        _ = this.Pending;
        this.RecordType?.Validate();
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    Balance
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "balance"=>RecordType.Balance, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.Balance=>"balance",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}