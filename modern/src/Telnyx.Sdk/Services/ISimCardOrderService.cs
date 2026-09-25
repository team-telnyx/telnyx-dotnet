using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.SimCardOrders;

namespace Telnyx.Sdk.Services;

/// <summary>
/// SIM Card Orders operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISimCardOrderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISimCardOrderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISimCardOrderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a new order for physical SIM cards, including quantity and shipping
/// details, and returns the created order.
/// </summary>
    Task<SimCardOrderCreateResponse> Create(
        SimCardOrderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single SIM card order by its ID, including its status.
/// </summary>
    Task<SimCardOrderRetrieveResponse> Retrieve(
        SimCardOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SimCardOrderRetrieveParams, CancellationToken)"/>
    Task<SimCardOrderRetrieveResponse> Retrieve(
        string id,
        SimCardOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get all SIM card orders according to filters.
/// </summary>
    Task<SimCardOrderListPage> List(
        SimCardOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISimCardOrderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISimCardOrderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISimCardOrderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sim_card_orders</c>, but is otherwise the
/// same as <see cref="ISimCardOrderService.Create(SimCardOrderCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardOrderCreateResponse>> Create(
        SimCardOrderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sim_card_orders/{id}</c>, but is otherwise the
/// same as <see cref="ISimCardOrderService.Retrieve(SimCardOrderRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardOrderRetrieveResponse>> Retrieve(
        SimCardOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SimCardOrderRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SimCardOrderRetrieveResponse>> Retrieve(
        string id,
        SimCardOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sim_card_orders</c>, but is otherwise the
/// same as <see cref="ISimCardOrderService.List(SimCardOrderListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SimCardOrderListPage>> List(
        SimCardOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}