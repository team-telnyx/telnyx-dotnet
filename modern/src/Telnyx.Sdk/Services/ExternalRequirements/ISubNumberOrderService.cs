using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.ExternalRequirements.SubNumberOrders;

namespace Telnyx.Sdk.Services.ExternalRequirements;

/// <summary>
/// Requirement Groups
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
/// Returns the input fields an action requirement needs and the current requirement
/// action for a sub number order. Action requirements are fulfilled by an external
/// step rather than by uploading documents. Australia mobile ID verification is
/// currently the only action requirement. Once a verification link has been
/// generated, it is returned in `requirement_action.value`.
/// </summary>
    Task<SubNumberOrderRetrieveResponse> Retrieve(
        SubNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SubNumberOrderRetrieveParams, CancellationToken)"/>
    Task<SubNumberOrderRetrieveResponse> Retrieve(
        string subNumberOrderID,
        SubNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Submits the end user's details to the external verification provider and returns
/// the requirement action. Australia mobile ID verification is currently the only
/// action requirement. It generates a unique Onfido verification link, returned in
/// `requirement_action.value`, which you share with the end user. The end user's
/// `first_name` and `last_name` must be nested inside a `requirement` object;
/// sending them at the top level is rejected.
/// </summary>
    Task<SubNumberOrderUpdateResponse> Update(
        SubNumberOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(SubNumberOrderUpdateParams, CancellationToken)"/>
    Task<SubNumberOrderUpdateResponse> Update(
        string subNumberOrderID,
        SubNumberOrderUpdateParams parameters,
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
/// Returns a raw HTTP response for <c>get /external_requirements/{regulatory_requirement_id}/sub_number_orders/{sub_number_order_id}</c>, but is otherwise the
/// same as <see cref="ISubNumberOrderService.Retrieve(SubNumberOrderRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SubNumberOrderRetrieveResponse>> Retrieve(
        SubNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SubNumberOrderRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SubNumberOrderRetrieveResponse>> Retrieve(
        string subNumberOrderID,
        SubNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /external_requirements/{regulatory_requirement_id}/sub_number_orders/{sub_number_order_id}</c>, but is otherwise the
/// same as <see cref="ISubNumberOrderService.Update(SubNumberOrderUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SubNumberOrderUpdateResponse>> Update(
        SubNumberOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(SubNumberOrderUpdateParams, CancellationToken)"/>
    Task<HttpResponse<SubNumberOrderUpdateResponse>> Update(
        string subNumberOrderID,
        SubNumberOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}