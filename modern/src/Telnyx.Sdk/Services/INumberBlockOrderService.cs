using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NumberBlockOrders;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface INumberBlockOrderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INumberBlockOrderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberBlockOrderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates an order for a block of consecutive phone numbers and returns the
/// created order. Track fulfillment through the order's status.
/// </summary>
    Task<NumberBlockOrderCreateResponse> Create(
        NumberBlockOrderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get an existing phone number block order.
/// </summary>
    Task<NumberBlockOrderRetrieveResponse> Retrieve(
        NumberBlockOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NumberBlockOrderRetrieveParams, CancellationToken)"/>
    Task<NumberBlockOrderRetrieveResponse> Retrieve(
        string numberBlockOrderID,
        NumberBlockOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get a paginated list of number block orders.
/// </summary>
    Task<NumberBlockOrderListPage> List(
        NumberBlockOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INumberBlockOrderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INumberBlockOrderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberBlockOrderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /number_block_orders</c>, but is otherwise the
/// same as <see cref="INumberBlockOrderService.Create(NumberBlockOrderCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberBlockOrderCreateResponse>> Create(
        NumberBlockOrderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /number_block_orders/{number_block_order_id}</c>, but is otherwise the
/// same as <see cref="INumberBlockOrderService.Retrieve(NumberBlockOrderRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberBlockOrderRetrieveResponse>> Retrieve(
        NumberBlockOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NumberBlockOrderRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<NumberBlockOrderRetrieveResponse>> Retrieve(
        string numberBlockOrderID,
        NumberBlockOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /number_block_orders</c>, but is otherwise the
/// same as <see cref="INumberBlockOrderService.List(NumberBlockOrderListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberBlockOrderListPage>> List(
        NumberBlockOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}