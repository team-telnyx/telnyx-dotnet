using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MachinePayments;

/// <summary>
/// Creates an account credit using the Machine Payment Protocol (MPP), an HTTP-402
/// payment flow for machines and agents.
///
/// <para>The flow has two steps. First, send an authenticated request with the `amount_usd`
/// to credit; the response is `402 Payment Required` with one or more payment challenges
/// (for example separate Tempo and Stripe challenges) in the `WWW-Authenticate` header.
/// Second, retry the request with an `Authorization: Payment ...` credential constructed
/// from the challenge; on success the response includes the credited transaction
/// and a `Payment-Receipt` header.</para>
///
/// <para>The credited account is never chosen by the request body: the initial request
/// credits the account of the authenticated user, and a paid retry credits the account
/// bound to the verified payment credential. The amount must be within the configured
/// bounds (by default between 5.00 and 500.00 USD).</para>
///
/// <para>Successful paid retries are idempotent — when Rails reaches its duplicate-transaction
/// lookup for an already-recorded payment, it returns the existing transaction with
/// `created: false` instead of crediting the account again. This deduplication applies
/// to successful fulfillment: re-sending the same Stripe credential may instead be
/// rejected by the upstream provider as an idempotent replay and return `402 Payment
/// Required` rather than the existing transaction.</para>
///
/// <para>&gt; **Warning: the payment credential is bound to a specific Telnyx account
/// ID.** A payment is captured before the bound account is validated. If the credential
/// names an account that is missing, suspended, blocked, cancelled, dormant, or ineligible
/// for the tier, the payment is captured but **no account is credited**. If the
/// credential names a different but eligible account, that account is credited —
/// the service does not compare it against the payer's account. There is **no automatic
/// refund**: if the captured payment does not credit the intended account, contact
/// Telnyx support for remediation.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MachinePaymentAccountCreditParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Amount to credit in USD, as a decimal string with up to two fractional digits
    /// (by default between 5.00 and 500.00). The request body is required on the
    /// initial challenge request and remains required on a paid retry, where you
    /// re-send the identical body plus the payment credential — the credential, not
    /// the body, selects the payment, and the retried body is not re-validated.
    /// </summary>
    public required string AmountUsd {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "amount_usd"
            );
        }
        init { this._rawBodyData.Set("amount_usd", value); }
    }

    public MachinePaymentAccountCreditParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MachinePaymentAccountCreditParams (
        MachinePaymentAccountCreditParams machinePaymentAccountCreditParams
    ) : base(machinePaymentAccountCreditParams)
    { this._rawBodyData = new(machinePaymentAccountCreditParams._rawBodyData); }
    #pragma warning restore CS8618

    public MachinePaymentAccountCreditParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MachinePaymentAccountCreditParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MachinePaymentAccountCreditParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(MachinePaymentAccountCreditParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/machine-payments/account-credit"
        )
        {
            Query = this.QueryString(
                options,
                new()
                {
                    BearerAuth = true,
                    Payment = true,
                }
            ),
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request,
            options,
            new()
            {
                BearerAuth = true,
                Payment = true,
            }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}