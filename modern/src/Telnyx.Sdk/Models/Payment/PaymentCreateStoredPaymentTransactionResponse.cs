using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Payment;

[JsonConverter(typeof(JsonModelConverter<PaymentCreateStoredPaymentTransactionResponse, PaymentCreateStoredPaymentTransactionResponseFromRaw>))]
public sealed record class PaymentCreateStoredPaymentTransactionResponse : JsonModel
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

    public PaymentCreateStoredPaymentTransactionResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentCreateStoredPaymentTransactionResponse (
        PaymentCreateStoredPaymentTransactionResponse paymentCreateStoredPaymentTransactionResponse
    ) : base(paymentCreateStoredPaymentTransactionResponse)
    {  }
    #pragma warning restore CS8618

    public PaymentCreateStoredPaymentTransactionResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentCreateStoredPaymentTransactionResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PaymentCreateStoredPaymentTransactionResponseFromRaw.FromRawUnchecked"/>
    public static PaymentCreateStoredPaymentTransactionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PaymentCreateStoredPaymentTransactionResponseFromRaw : IFromRawJson<PaymentCreateStoredPaymentTransactionResponse>
{
    /// <inheritdoc/>
    public PaymentCreateStoredPaymentTransactionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PaymentCreateStoredPaymentTransactionResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
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

    public long? AmountCents {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "amount_cents"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount_cents", value);
        }
    }

    public string? AmountCurrency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount_currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount_currency", value);
        }
    }

    public bool? AutoRecharge {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "auto_recharge"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("auto_recharge", value);
        }
    }

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

    public string? ProcessorStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "processor_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("processor_status", value);
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

    public ApiEnum<string, TransactionProcessingType>? TransactionProcessingType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TransactionProcessingType>>(
                "transaction_processing_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transaction_processing_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AmountCents;
        _ = this.AmountCurrency;
        _ = this.AutoRecharge;
        _ = this.CreatedAt;
        _ = this.ProcessorStatus;
        this.RecordType?.Validate();
        this.TransactionProcessingType?.Validate();
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
}[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    Transaction
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "transaction"=>RecordType.Transaction, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.Transaction=>"transaction",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(TransactionProcessingTypeConverter))]
public enum TransactionProcessingType
{
    StoredPayment
}sealed class TransactionProcessingTypeConverter : JsonConverter<TransactionProcessingType>
{
    public override TransactionProcessingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stored_payment"=>TransactionProcessingType.StoredPayment,
            _ =>(TransactionProcessingType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransactionProcessingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TransactionProcessingType.StoredPayment=>"stored_payment",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}