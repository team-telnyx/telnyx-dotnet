using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.X402.CreditAccount.Payments;

namespace Telnyx.Sdk.Services.X402.CreditAccount;

/// <summary>
/// Operations for x402 cryptocurrency payment transactions. Fund your Telnyx account
/// using USDC stablecoin payments via the x402 protocol.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPaymentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPaymentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPaymentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns a single x402 payment transaction by ID. The transaction must belong to
/// the authenticated user; organization sub-users must have read permission on
/// transactions. Returns 404 if the transaction does not exist or belongs to
/// another user.
/// </summary>
    Task<PaymentRetrieveResponse> Retrieve(
        PaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PaymentRetrieveParams, CancellationToken)"/>
    Task<PaymentRetrieveResponse> Retrieve(
        string id,
        PaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of the authenticated user's x402 payment transactions,
/// newest first. Organization sub-users must have read permission on transactions;
/// without it the list is empty.
/// </summary>
    Task<PaymentListPage> List(
        PaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPaymentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPaymentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPaymentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /x402/credit_account/payments/{id}</c>, but is otherwise the
/// same as <see cref="IPaymentService.Retrieve(PaymentRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PaymentRetrieveResponse>> Retrieve(
        PaymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PaymentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PaymentRetrieveResponse>> Retrieve(
        string id,
        PaymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /x402/credit_account/payments</c>, but is otherwise the
/// same as <see cref="IPaymentService.List(PaymentListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PaymentListPage>> List(
        PaymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}