using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MachinePayments;

[JsonConverter(typeof(JsonModelConverter<MachinePaymentAccountCreditResponse, MachinePaymentAccountCreditResponseFromRaw>))]
public sealed record class MachinePaymentAccountCreditResponse : JsonModel
{
    /// <summary>
    /// An account-credit transaction settled through the Machine Payment Protocol.
    /// </summary>
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

    public MachinePaymentAccountCreditResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MachinePaymentAccountCreditResponse (
        MachinePaymentAccountCreditResponse machinePaymentAccountCreditResponse
    ) : base(machinePaymentAccountCreditResponse)
    {  }
    #pragma warning restore CS8618

    public MachinePaymentAccountCreditResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MachinePaymentAccountCreditResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MachinePaymentAccountCreditResponseFromRaw.FromRawUnchecked"/>
    public static MachinePaymentAccountCreditResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MachinePaymentAccountCreditResponseFromRaw : IFromRawJson<MachinePaymentAccountCreditResponse>
{
    /// <inheritdoc/>
    public MachinePaymentAccountCreditResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MachinePaymentAccountCreditResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// An account-credit transaction settled through the Machine Payment Protocol.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Unique identifier of the account-credit transaction.
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
    /// Identifier of the credited Telnyx account. Derived from the authenticated
    /// user on the initial request and from the verified payment credential on a
    /// paid retry — never from the request body.
    /// </summary>
    public required string AccountID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "account_id"
            );
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// Credited amount as a decimal string with two fractional digits.
    /// </summary>
    public required string Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "amount"
            );
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// ISO 4217 currency code of the credited amount (currently always USD).
    /// </summary>
    public required string Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Payment source identifier distinguishing machine payments from other account-credit sources.
    /// </summary>
    public required ApiEnum<string, PaymentSource> PaymentSource {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PaymentSource>>(
                "payment_source"
            );
        }
        init { this._rawData.Set("payment_source", value); }
    }

    /// <summary>
    /// Record type identifier.
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
    /// True when this response created a new account credit, false when an existing
    /// transaction was returned for a duplicate paid retry.
    /// </summary>
    public bool? Created {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "created"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created", value);
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
    /// Machine Payment Protocol resource identifier the payment credential was bound to.
    /// </summary>
    public string? MppResource {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mpp_resource"
            );
        }
        init { this._rawData.Set("mpp_resource", value); }
    }

    /// <summary>
    /// Stripe PaymentIntent identifier for Stripe settlements. Absent for Tempo settlements.
    /// </summary>
    public string? PaymentIntentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "payment_intent_id"
            );
        }
        init { this._rawData.Set("payment_intent_id", value); }
    }

    /// <summary>
    /// Payment method used by the provider: `stripe_spt` for Stripe Shared Payment
    /// Token payments, `tempo_usdc` for Tempo USDC payments.
    /// </summary>
    public ApiEnum<string, PaymentMethod>? PaymentMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PaymentMethod>>(
                "payment_method"
            );
        }
        init { this._rawData.Set("payment_method", value); }
    }

    /// <summary>
    /// Upstream payment provider that settled the payment.
    /// </summary>
    public ApiEnum<string, Provider>? Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Provider>>(
                "provider"
            );
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// Provider receipt reference: the Stripe PaymentIntent identifier for Stripe
    /// settlements, or the on-chain transaction hash for Tempo settlements.
    /// </summary>
    public string? ReceiptReference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "receipt_reference"
            );
        }
        init { this._rawData.Set("receipt_reference", value); }
    }

    /// <summary>
    /// Status of the transaction. Successful machine payment credits are recorded
    /// as `settled`.
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.Amount;
        _ = this.Currency;
        this.PaymentSource.Validate();
        this.RecordType.Validate();
        _ = this.Created;
        _ = this.CreatedAt;
        _ = this.MppResource;
        _ = this.PaymentIntentID;
        this.PaymentMethod?.Validate();
        this.Provider?.Validate();
        _ = this.ReceiptReference;
        this.Status?.Validate();
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
/// Payment source identifier distinguishing machine payments from other account-credit sources.
/// </summary>
[JsonConverter(typeof(PaymentSourceConverter))]
public enum PaymentSource
{
    MachinePayment
}sealed class PaymentSourceConverter : JsonConverter<PaymentSource>
{
    public override PaymentSource Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "machine_payment"=>PaymentSource.MachinePayment,
            _ =>(PaymentSource)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PaymentSource.MachinePayment=>"machine_payment",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Record type identifier.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    MachinePaymentAccountCredit
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
            "machine_payment_account_credit"=>RecordType.MachinePaymentAccountCredit,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.MachinePaymentAccountCredit=>"machine_payment_account_credit",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Payment method used by the provider: `stripe_spt` for Stripe Shared Payment Token
/// payments, `tempo_usdc` for Tempo USDC payments.
/// </summary>
[JsonConverter(typeof(PaymentMethodConverter))]
public enum PaymentMethod
{
    StripeSpt, TempoUsdc
}sealed class PaymentMethodConverter : JsonConverter<PaymentMethod>
{
    public override PaymentMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe_spt"=>PaymentMethod.StripeSpt,
            "tempo_usdc"=>PaymentMethod.TempoUsdc,
            _ =>(PaymentMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PaymentMethod.StripeSpt=>"stripe_spt",
            PaymentMethod.TempoUsdc=>"tempo_usdc",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Upstream payment provider that settled the payment.
/// </summary>
[JsonConverter(typeof(ProviderConverter))]
public enum Provider
{
    Stripe, Tempo
}sealed class ProviderConverter : JsonConverter<Provider>
{
    public override Provider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe"=>Provider.Stripe,
            "tempo"=>Provider.Tempo,
            _ =>(Provider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Provider value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Provider.Stripe=>"stripe",
            Provider.Tempo=>"tempo",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Status of the transaction. Successful machine payment credits are recorded as `settled`.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    New, Processing, Settled, Expired, Invalid
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "new"=>Status.New,
            "processing"=>Status.Processing,
            "settled"=>Status.Settled,
            "expired"=>Status.Expired,
            "invalid"=>Status.Invalid,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.New=>"new",
            Status.Processing=>"processing",
            Status.Settled=>"settled",
            Status.Expired=>"expired",
            Status.Invalid=>"invalid",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}