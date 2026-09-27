using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.SubNumberOrders;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISubNumberOrderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISubNumberOrderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubNumberOrderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns the details of an existing sub number order, with support for filtering.
/// </summary>
    Task<SubNumberOrderRetrieveResponse> Retrieve(
        SubNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SubNumberOrderRetrieveParams, CancellationToken)"/>
    Task<SubNumberOrderRetrieveResponse> Retrieve(
        string subNumberOrderID,
        SubNumberOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the requirements of an existing sub number order and returns the updated
/// order.
/// </summary>
    Task<SubNumberOrderUpdateResponse> Update(
        SubNumberOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(SubNumberOrderUpdateParams, CancellationToken)"/>
    Task<SubNumberOrderUpdateResponse> Update(
        string subNumberOrderID,
        SubNumberOrderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get a paginated list of sub number orders.
/// </summary>
    Task<SubNumberOrderListResponse> List(
        SubNumberOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Allows you to cancel a sub number order in 'pending' status.
/// </summary>
    Task<SubNumberOrderCancelResponse> Cancel(
        SubNumberOrderCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Cancel(SubNumberOrderCancelParams, CancellationToken)"/>
    Task<SubNumberOrderCancelResponse> Cancel(
        string subNumberOrderID,
        SubNumberOrderCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Associates an existing requirement group with the specified sub number order.
/// The response contains the updated sub number order requirement-group
/// relationship.
/// </summary>
    Task<SubNumberOrderUpdateRequirementGroupResponse> UpdateRequirementGroup(
        SubNumberOrderUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateRequirementGroup(SubNumberOrderUpdateRequirementGroupParams, CancellationToken)"/>
    Task<SubNumberOrderUpdateRequirementGroupResponse> UpdateRequirementGroup(
        string id,
        SubNumberOrderUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISubNumberOrderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISubNumberOrderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubNumberOrderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sub_number_orders/{sub_number_order_id}</c>, but is otherwise the
/// same as <see cref="ISubNumberOrderService.Retrieve(SubNumberOrderRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SubNumberOrderRetrieveResponse>> Retrieve(
        SubNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SubNumberOrderRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SubNumberOrderRetrieveResponse>> Retrieve(
        string subNumberOrderID,
        SubNumberOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /sub_number_orders/{sub_number_order_id}</c>, but is otherwise the
/// same as <see cref="ISubNumberOrderService.Update(SubNumberOrderUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SubNumberOrderUpdateResponse>> Update(
        SubNumberOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(SubNumberOrderUpdateParams, CancellationToken)"/>
    Task<HttpResponse<SubNumberOrderUpdateResponse>> Update(
        string subNumberOrderID,
        SubNumberOrderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sub_number_orders</c>, but is otherwise the
/// same as <see cref="ISubNumberOrderService.List(SubNumberOrderListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SubNumberOrderListResponse>> List(
        SubNumberOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /sub_number_orders/{sub_number_order_id}/cancel</c>, but is otherwise the
/// same as <see cref="ISubNumberOrderService.Cancel(SubNumberOrderCancelParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SubNumberOrderCancelResponse>> Cancel(
        SubNumberOrderCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Cancel(SubNumberOrderCancelParams, CancellationToken)"/>
    Task<HttpResponse<SubNumberOrderCancelResponse>> Cancel(
        string subNumberOrderID,
        SubNumberOrderCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sub_number_orders/{id}/requirement_group</c>, but is otherwise the
/// same as <see cref="ISubNumberOrderService.UpdateRequirementGroup(SubNumberOrderUpdateRequirementGroupParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SubNumberOrderUpdateRequirementGroupResponse>> UpdateRequirementGroup(
        SubNumberOrderUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateRequirementGroup(SubNumberOrderUpdateRequirementGroupParams, CancellationToken)"/>
    Task<HttpResponse<SubNumberOrderUpdateRequirementGroupResponse>> UpdateRequirementGroup(
        string id,
        SubNumberOrderUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}