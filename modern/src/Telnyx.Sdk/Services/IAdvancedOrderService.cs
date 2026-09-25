using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AdvancedOrders;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAdvancedOrderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAdvancedOrderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAdvancedOrderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates an advanced number order from the requested order configuration. The
/// response contains the resulting advanced order and its initial state.
/// </summary>
    Task<AdvancedOrder> Create(
        AdvancedOrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the advanced number order identified by `order_id`, including its
/// configuration and current state.
/// </summary>
    Task<AdvancedOrder> Retrieve(
        AdvancedOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AdvancedOrderRetrieveParams, CancellationToken)"/>
    Task<AdvancedOrder> Retrieve(
        string orderID,
        AdvancedOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the advanced number orders associated with the account. Each result
/// includes the order configuration and its current state.
/// </summary>
    Task<AdvancedOrderListResponse> List(
        AdvancedOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the requirement-group configuration for the specified advanced number
/// order. The response contains the updated advanced order.
/// </summary>
    Task<AdvancedOrder> UpdateRequirementGroup(
        AdvancedOrderUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateRequirementGroup(AdvancedOrderUpdateRequirementGroupParams, CancellationToken)"/>
    Task<AdvancedOrder> UpdateRequirementGroup(
        string advancedOrderID,
        AdvancedOrderUpdateRequirementGroupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAdvancedOrderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAdvancedOrderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAdvancedOrderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /advanced_orders</c>, but is otherwise the
/// same as <see cref="IAdvancedOrderService.Create(AdvancedOrderCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AdvancedOrder>> Create(
        AdvancedOrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /advanced_orders/{order_id}</c>, but is otherwise the
/// same as <see cref="IAdvancedOrderService.Retrieve(AdvancedOrderRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AdvancedOrder>> Retrieve(
        AdvancedOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AdvancedOrderRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AdvancedOrder>> Retrieve(
        string orderID,
        AdvancedOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /advanced_orders</c>, but is otherwise the
/// same as <see cref="IAdvancedOrderService.List(AdvancedOrderListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AdvancedOrderListResponse>> List(
        AdvancedOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /advanced_orders/{advanced-order-id}/requirement_group</c>, but is otherwise the
/// same as <see cref="IAdvancedOrderService.UpdateRequirementGroup(AdvancedOrderUpdateRequirementGroupParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AdvancedOrder>> UpdateRequirementGroup(
        AdvancedOrderUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateRequirementGroup(AdvancedOrderUpdateRequirementGroupParams, CancellationToken)"/>
    Task<HttpResponse<AdvancedOrder>> UpdateRequirementGroup(
        string advancedOrderID,
        AdvancedOrderUpdateRequirementGroupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}