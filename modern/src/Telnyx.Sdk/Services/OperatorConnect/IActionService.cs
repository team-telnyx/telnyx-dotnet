using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.OperatorConnect.Actions;

namespace Telnyx.Sdk.Services.OperatorConnect;

/// <summary>
/// External Connections operations
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
/// This endpoint will make an asynchronous request to refresh the Operator Connect
/// integration with Microsoft Teams for the current user. This will create new
/// external connections on the user's account if needed, and/or report the
/// integration results as [log
/// messages](https://developers.telnyx.com/api-reference/external-connections/list-all-log-messages#list-all-log-messages).
/// </summary>
    Task<ActionRefreshResponse> Refresh(
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
/// Returns a raw HTTP response for <c>post /operator_connect/actions/refresh</c>, but is otherwise the
/// same as <see cref="IActionService.Refresh(ActionRefreshParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionRefreshResponse>> Refresh(
        ActionRefreshParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}