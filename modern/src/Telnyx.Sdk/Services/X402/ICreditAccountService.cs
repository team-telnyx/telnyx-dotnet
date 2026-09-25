using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.X402.CreditAccount;
using CreditAccount = Telnyx.Sdk.Services.X402.CreditAccount;

namespace Telnyx.Sdk.Services.X402;

/// <summary>
/// Operations for x402 cryptocurrency payment transactions. Fund your Telnyx account
/// using USDC stablecoin payments via the x402 protocol.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICreditAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICreditAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICreditAccountService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    CreditAccount::IPaymentService Payments { get; }

    /// <summary>
/// Creates a payment quote for the specified USD amount. Returns payment details
/// including the x402 payment requirements, network, and expiration time. The quote
/// must be settled before it expires.
/// </summary>
    Task<CreditAccountCreateQuoteResponse> CreateQuote(
        CreditAccountCreateQuoteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Settles an x402 payment using the quote ID and a signed payment authorization.
/// The payment signature can be provided via the `PAYMENT-SIGNATURE` header or the
/// `payment_signature` body parameter. Settlement is idempotent — submitting the
/// same quote ID multiple times returns the existing transaction.
/// </summary>
    Task<CreditAccountSettleResponse> Settle(
        CreditAccountSettleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICreditAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICreditAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICreditAccountServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    CreditAccount::IPaymentServiceWithRawResponse Payments { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /x402/credit_account/quote</c>, but is otherwise the
/// same as <see cref="ICreditAccountService.CreateQuote(CreditAccountCreateQuoteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CreditAccountCreateQuoteResponse>> CreateQuote(
        CreditAccountCreateQuoteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /x402/credit_account</c>, but is otherwise the
/// same as <see cref="ICreditAccountService.Settle(CreditAccountSettleParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CreditAccountSettleResponse>> Settle(
        CreditAccountSettleParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}