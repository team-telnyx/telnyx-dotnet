using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Faxes.Actions;

namespace Telnyx.Sdk.Services.Faxes;

/// <summary>
/// Programmable fax command operations
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
/// Cancel the outbound fax that is in one of the following states: `queued`,
/// `media.processed`, `originated` or `sending`
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
/// Refreshes the inbound fax's media_url when it has expired
/// </summary>
    Task<ActionRefreshResponse> Refresh(
        ActionRefreshParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Refresh(ActionRefreshParams, CancellationToken)"/>
    Task<ActionRefreshResponse> Refresh(
        string id,
        ActionRefreshParams? parameters = null,
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
/// Returns a raw HTTP response for <c>post /faxes/{id}/actions/cancel</c>, but is otherwise the
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
/// Returns a raw HTTP response for <c>post /faxes/{id}/actions/refresh</c>, but is otherwise the
/// same as <see cref="IActionService.Refresh(ActionRefreshParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionRefreshResponse>> Refresh(
        ActionRefreshParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Refresh(ActionRefreshParams, CancellationToken)"/>
    Task<HttpResponse<ActionRefreshResponse>> Refresh(
        string id,
        ActionRefreshParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}