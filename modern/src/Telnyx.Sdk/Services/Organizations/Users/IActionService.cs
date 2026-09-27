using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Organizations.Users.Actions;

namespace Telnyx.Sdk.Services.Organizations.Users;

/// <summary>
/// Operations related to users in your organization
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
/// Removes the specified user from your organization and returns the result of the
/// removal.
/// </summary>
    Task<ActionRemoveResponse> Remove(
        ActionRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Remove(ActionRemoveParams, CancellationToken)"/>
    Task<ActionRemoveResponse> Remove(
        string id,
        ActionRemoveParams? parameters = null,
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
/// Returns a raw HTTP response for <c>post /organizations/users/{id}/actions/remove</c>, but is otherwise the
/// same as <see cref="IActionService.Remove(ActionRemoveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionRemoveResponse>> Remove(
        ActionRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Remove(ActionRemoveParams, CancellationToken)"/>
    Task<HttpResponse<ActionRemoveResponse>> Remove(
        string id,
        ActionRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}