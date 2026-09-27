using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortingOrders.ActionRequirements;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <summary>
/// Endpoints related to porting orders management.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IActionRequirementService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IActionRequirementServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionRequirementService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a list of action requirements for a specific porting order.
/// </summary>
    Task<ActionRequirementListPage> List(
        ActionRequirementListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ActionRequirementListParams, CancellationToken)"/>
    Task<ActionRequirementListPage> List(
        string portingOrderID,
        ActionRequirementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Initiates a specific action requirement for a porting order.
/// </summary>
    Task<ActionRequirementInitiateResponse> Initiate(
        ActionRequirementInitiateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Initiate(ActionRequirementInitiateParams, CancellationToken)"/>
    Task<ActionRequirementInitiateResponse> Initiate(
        string id,
        ActionRequirementInitiateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IActionRequirementService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IActionRequirementServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionRequirementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders/{porting_order_id}/action_requirements</c>, but is otherwise the
/// same as <see cref="IActionRequirementService.List(ActionRequirementListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionRequirementListPage>> List(
        ActionRequirementListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ActionRequirementListParams, CancellationToken)"/>
    Task<HttpResponse<ActionRequirementListPage>> List(
        string portingOrderID,
        ActionRequirementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting_orders/{porting_order_id}/action_requirements/{id}/initiate</c>, but is otherwise the
/// same as <see cref="IActionRequirementService.Initiate(ActionRequirementInitiateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionRequirementInitiateResponse>> Initiate(
        ActionRequirementInitiateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Initiate(ActionRequirementInitiateParams, CancellationToken)"/>
    Task<HttpResponse<ActionRequirementInitiateResponse>> Initiate(
        string id,
        ActionRequirementInitiateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}