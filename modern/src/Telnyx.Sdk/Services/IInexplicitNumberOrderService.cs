using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.InexplicitNumberOrders;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Inexplicit number orders for bulk purchasing without specifying exact numbers
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IInexplicitNumberOrderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInexplicitNumberOrderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInexplicitNumberOrderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create an inexplicit number order to programmatically purchase phone numbers
/// without specifying exact numbers.
/// </summary>
    Task<InexplicitNumberOrderCreateResponse> Create(
        InexplicitNumberOrderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get an existing inexplicit number order by ID.
/// </summary>
    Task<InexplicitNumberOrderRetrieveResponse> Retrieve(
        InexplicitNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(InexplicitNumberOrderRetrieveParams, CancellationToken)"/>
    Task<InexplicitNumberOrderRetrieveResponse> Retrieve(
        string id,
        InexplicitNumberOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get a paginated list of inexplicit number orders.
/// </summary>
    Task<InexplicitNumberOrderListPage> List(
        InexplicitNumberOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IInexplicitNumberOrderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInexplicitNumberOrderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInexplicitNumberOrderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /inexplicit_number_orders</c>, but is otherwise the
/// same as <see cref="IInexplicitNumberOrderService.Create(InexplicitNumberOrderCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InexplicitNumberOrderCreateResponse>> Create(
        InexplicitNumberOrderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /inexplicit_number_orders/{id}</c>, but is otherwise the
/// same as <see cref="IInexplicitNumberOrderService.Retrieve(InexplicitNumberOrderRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InexplicitNumberOrderRetrieveResponse>> Retrieve(
        InexplicitNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(InexplicitNumberOrderRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InexplicitNumberOrderRetrieveResponse>> Retrieve(
        string id,
        InexplicitNumberOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /inexplicit_number_orders</c>, but is otherwise the
/// same as <see cref="IInexplicitNumberOrderService.List(InexplicitNumberOrderListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InexplicitNumberOrderListPage>> List(
        InexplicitNumberOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}