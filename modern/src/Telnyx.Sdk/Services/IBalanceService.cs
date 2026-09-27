using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Balance;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Billing operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBalanceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBalanceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBalanceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Retrieve the current balance, available credit, and credit limit for your
/// account.
/// </summary>
    Task<BalanceRetrieveResponse> Retrieve(
        BalanceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IBalanceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBalanceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBalanceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /balance</c>, but is otherwise the
/// same as <see cref="IBalanceService.Retrieve(BalanceRetrieveParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BalanceRetrieveResponse>> Retrieve(
        BalanceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}