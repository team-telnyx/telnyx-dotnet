using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.X402.CreditAccount.Payments;

[JsonConverter(typeof(JsonModelConverter<PaymentRetrieveResponse, PaymentRetrieveResponseFromRaw>))]
public sealed record class PaymentRetrieveResponse : JsonModel
{
    /// <summary>
    /// An x402 payment transaction.
    /// </summary>
    public X402TransactionRecord? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<X402TransactionRecord>(
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

    public PaymentRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentRetrieveResponse (
        PaymentRetrieveResponse paymentRetrieveResponse
    ) : base(paymentRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public PaymentRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PaymentRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static PaymentRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PaymentRetrieveResponseFromRaw : IFromRawJson<PaymentRetrieveResponse>
{
    /// <inheritdoc/>
    public PaymentRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PaymentRetrieveResponse.FromRawUnchecked(rawData);
}