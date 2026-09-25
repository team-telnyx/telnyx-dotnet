using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Rooms.Actions;

namespace Telnyx.Sdk.Services.Rooms;

/// <summary>
/// Rooms Client Tokens operations.
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
/// Synchronously create an Client Token to join a Room. Client Token is necessary
/// to join a Telnyx Room. Client Token will expire after `token_ttl_secs`, a
/// Refresh Token is also provided to refresh a Client Token, the Refresh Token
/// expires after `refresh_token_ttl_secs`.
/// </summary>
    Task<ActionGenerateJoinClientTokenResponse> GenerateJoinClientToken(
        ActionGenerateJoinClientTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GenerateJoinClientToken(ActionGenerateJoinClientTokenParams, CancellationToken)"/>
    Task<ActionGenerateJoinClientTokenResponse> GenerateJoinClientToken(
        string roomID,
        ActionGenerateJoinClientTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Synchronously refresh an Client Token to join a Room. Client Token is necessary
/// to join a Telnyx Room. Client Token will expire after `token_ttl_secs`.
/// </summary>
    Task<ActionRefreshClientTokenResponse> RefreshClientToken(
        ActionRefreshClientTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RefreshClientToken(ActionRefreshClientTokenParams, CancellationToken)"/>
    Task<ActionRefreshClientTokenResponse> RefreshClientToken(
        string roomID,
        ActionRefreshClientTokenParams parameters,
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
/// Returns a raw HTTP response for <c>post /rooms/{room_id}/actions/generate_join_client_token</c>, but is otherwise the
/// same as <see cref="IActionService.GenerateJoinClientToken(ActionGenerateJoinClientTokenParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionGenerateJoinClientTokenResponse>> GenerateJoinClientToken(
        ActionGenerateJoinClientTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GenerateJoinClientToken(ActionGenerateJoinClientTokenParams, CancellationToken)"/>
    Task<HttpResponse<ActionGenerateJoinClientTokenResponse>> GenerateJoinClientToken(
        string roomID,
        ActionGenerateJoinClientTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /rooms/{room_id}/actions/refresh_client_token</c>, but is otherwise the
/// same as <see cref="IActionService.RefreshClientToken(ActionRefreshClientTokenParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionRefreshClientTokenResponse>> RefreshClientToken(
        ActionRefreshClientTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RefreshClientToken(ActionRefreshClientTokenParams, CancellationToken)"/>
    Task<HttpResponse<ActionRefreshClientTokenResponse>> RefreshClientToken(
        string roomID,
        ActionRefreshClientTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}