using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MachinePayments;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Machine payment (MPP) account-credit operations. Fund your Telnyx account programmatically
/// from a machine or agent using the Machine Payment Protocol, an HTTP-402 flow settled
/// via Stripe or Tempo.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMachinePaymentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMachinePaymentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMachinePaymentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates an account credit using the Machine Payment Protocol (MPP), an HTTP-402
/// payment flow for machines and agents.
/// 
/// <para>The flow has two steps. First, send an authenticated request with the
/// `amount_usd` to credit; the response is `402 Payment Required` with one or more
/// payment challenges (for example separate Tempo and Stripe challenges) in the
/// `WWW-Authenticate` header. Second, retry the request with an `Authorization:
/// Payment ...` credential constructed from the challenge; on success the response
/// includes the credited transaction and a `Payment-Receipt` header.</para>
/// 
/// <para>The credited account is never chosen by the request body: the initial
/// request credits the account of the authenticated user, and a paid retry credits
/// the account bound to the verified payment credential. The amount must be within
/// the configured bounds (by default between 5.00 and 500.00 USD).</para>
/// 
/// <para>Successful paid retries are idempotent — when Rails reaches its
/// duplicate-transaction lookup for an already-recorded payment, it returns the
/// existing transaction with `created: false` instead of crediting the account
/// again. This deduplication applies to successful fulfillment: re-sending the same
/// Stripe credential may instead be rejected by the upstream provider as an
/// idempotent replay and return `402 Payment Required` rather than the existing
/// transaction.</para>
/// 
/// <para>&gt; **Warning: the payment credential is bound to a specific Telnyx
/// account ID.** A payment is captured before the bound account is validated. If
/// the credential names an account that is missing, suspended, blocked, cancelled,
/// dormant, or ineligible for the tier, the payment is captured but **no account is
/// credited**. If the credential names a different but eligible account, that
/// account is credited — the service does not compare it against the payer's
/// account. There is **no automatic refund**: if the captured payment does not
/// credit the intended account, contact Telnyx support for remediation.</para>
/// </summary>
    Task<MachinePaymentAccountCreditResponse> AccountCredit(
        MachinePaymentAccountCreditParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMachinePaymentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMachinePaymentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMachinePaymentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /machine-payments/account-credit</c>, but is otherwise the
/// same as <see cref="IMachinePaymentService.AccountCredit(MachinePaymentAccountCreditParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MachinePaymentAccountCreditResponse>> AccountCredit(
        MachinePaymentAccountCreditParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}