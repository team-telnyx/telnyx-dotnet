using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NumberOrders;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Number orders
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INumberOrderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INumberOrderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberOrderService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates an order to purchase the specified phone numbers and returns the created
/// order. Track fulfillment through the order's status.
/// </summary>
    Task<NumberOrderCreateResponse> Create(
        NumberOrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of an existing phone number order, including its status and
/// the numbers included.
/// </summary>
    Task<NumberOrderRetrieveResponse> Retrieve(
        NumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NumberOrderRetrieveParams, CancellationToken)"/>
    Task<NumberOrderRetrieveResponse> Retrieve(
        string numberOrderID,
        NumberOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates an existing phone number order, for example to satisfy regulatory
/// requirements attached to the order, and returns the updated order.
/// </summary>
    Task<NumberOrderUpdateResponse> Update(
        NumberOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(NumberOrderUpdateParams, CancellationToken)"/>
    Task<NumberOrderUpdateResponse> Update(
        string numberOrderID,
        NumberOrderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of your phone number orders, with support for
/// filtering.
/// </summary>
    Task<NumberOrderListPage> List(
        NumberOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INumberOrderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INumberOrderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberOrderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /number_orders</c>, but is otherwise the
/// same as <see cref="INumberOrderService.Create(NumberOrderCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberOrderCreateResponse>> Create(
        NumberOrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /number_orders/{number_order_id}</c>, but is otherwise the
/// same as <see cref="INumberOrderService.Retrieve(NumberOrderRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberOrderRetrieveResponse>> Retrieve(
        NumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NumberOrderRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<NumberOrderRetrieveResponse>> Retrieve(
        string numberOrderID,
        NumberOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /number_orders/{number_order_id}</c>, but is otherwise the
/// same as <see cref="INumberOrderService.Update(NumberOrderUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberOrderUpdateResponse>> Update(
        NumberOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(NumberOrderUpdateParams, CancellationToken)"/>
    Task<HttpResponse<NumberOrderUpdateResponse>> Update(
        string numberOrderID,
        NumberOrderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /number_orders</c>, but is otherwise the
/// same as <see cref="INumberOrderService.List(NumberOrderListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberOrderListPage>> List(
        NumberOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}