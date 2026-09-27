using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortingOrders.Actions;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <summary>
/// Endpoints related to porting orders management.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IActionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IActionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Activate each number in a porting order asynchronously. This operation is
/// limited to US FastPort orders only.
/// </summary>
    Task<ActionActivateResponse> Activate(
        ActionActivateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Activate(ActionActivateParams, CancellationToken)"/>
    Task<ActionActivateResponse> Activate(
        string id,
        ActionActivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Requests cancellation of the porting order and returns the updated order.
/// </summary>
    Task<ActionCancelResponse> Cancel(
        ActionCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Cancel(ActionCancelParams, CancellationToken)"/>
    Task<ActionCancelResponse> Cancel(
        string id,
        ActionCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Confirms the porting order and submits it for processing. Make sure all required
/// information and documents are attached before confirming.
/// </summary>
    Task<ActionConfirmResponse> Confirm(
        ActionConfirmParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Confirm(ActionConfirmParams, CancellationToken)"/>
    Task<ActionConfirmResponse> Confirm(
        string id,
        ActionConfirmParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Creates a sharing token for a porting order. The token can be used to share the
/// porting order with non-Telnyx users.
/// </summary>
    Task<ActionShareResponse> Share(
        ActionShareParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Share(ActionShareParams, CancellationToken)"/>
    Task<ActionShareResponse> Share(
        string id,
        ActionShareParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IActionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IActionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting_orders/{id}/actions/activate</c>, but is otherwise the
/// same as <see cref="IActionService.Activate(ActionActivateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionActivateResponse>> Activate(
        ActionActivateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Activate(ActionActivateParams, CancellationToken)"/>
    Task<HttpResponse<ActionActivateResponse>> Activate(
        string id,
        ActionActivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting_orders/{id}/actions/cancel</c>, but is otherwise the
/// same as <see cref="IActionService.Cancel(ActionCancelParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionCancelResponse>> Cancel(
        ActionCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Cancel(ActionCancelParams, CancellationToken)"/>
    Task<HttpResponse<ActionCancelResponse>> Cancel(
        string id,
        ActionCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting_orders/{id}/actions/confirm</c>, but is otherwise the
/// same as <see cref="IActionService.Confirm(ActionConfirmParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionConfirmResponse>> Confirm(
        ActionConfirmParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Confirm(ActionConfirmParams, CancellationToken)"/>
    Task<HttpResponse<ActionConfirmResponse>> Confirm(
        string id,
        ActionConfirmParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting_orders/{id}/actions/share</c>, but is otherwise the
/// same as <see cref="IActionService.Share(ActionShareParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionShareResponse>> Share(
        ActionShareParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Share(ActionShareParams, CancellationToken)"/>
    Task<HttpResponse<ActionShareResponse>> Share(
        string id,
        ActionShareParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}