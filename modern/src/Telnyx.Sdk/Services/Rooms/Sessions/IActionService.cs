using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Rooms.Sessions.Actions;

namespace Telnyx.Sdk.Services.Rooms.Sessions;

/// <summary>
/// Rooms Sessions operations.
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
/// Note: this will also kick all participants currently present in the room
/// </summary>
    Task<ActionEndResponse> End(
        ActionEndParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="End(ActionEndParams, CancellationToken)"/>
    Task<ActionEndResponse> End(
        string roomSessionID,
        ActionEndParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes the selected participants from the specified room session. Apply the
/// action to a list of participant IDs or to `all`, with optional participant IDs
/// excluded from the action.
/// </summary>
    Task<ActionKickResponse> Kick(
        ActionKickParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Kick(ActionKickParams, CancellationToken)"/>
    Task<ActionKickResponse> Kick(
        string roomSessionID,
        ActionKickParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Mutes the selected participants in the specified room session. Apply the action
/// to a list of participant IDs or to `all`, with optional participant IDs excluded
/// from the action.
/// </summary>
    Task<ActionMuteResponse> Mute(
        ActionMuteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Mute(ActionMuteParams, CancellationToken)"/>
    Task<ActionMuteResponse> Mute(
        string roomSessionID,
        ActionMuteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Unmutes the selected participants in the specified room session. Apply the
/// action to a list of participant IDs or to `all`, with optional participant IDs
/// excluded from the action.
/// </summary>
    Task<ActionUnmuteResponse> Unmute(
        ActionUnmuteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Unmute(ActionUnmuteParams, CancellationToken)"/>
    Task<ActionUnmuteResponse> Unmute(
        string roomSessionID,
        ActionUnmuteParams? parameters = null,
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
/// Returns a raw HTTP response for <c>post /room_sessions/{room_session_id}/actions/end</c>, but is otherwise the
/// same as <see cref="IActionService.End(ActionEndParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionEndResponse>> End(
        ActionEndParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="End(ActionEndParams, CancellationToken)"/>
    Task<HttpResponse<ActionEndResponse>> End(
        string roomSessionID,
        ActionEndParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /room_sessions/{room_session_id}/actions/kick</c>, but is otherwise the
/// same as <see cref="IActionService.Kick(ActionKickParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionKickResponse>> Kick(
        ActionKickParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Kick(ActionKickParams, CancellationToken)"/>
    Task<HttpResponse<ActionKickResponse>> Kick(
        string roomSessionID,
        ActionKickParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /room_sessions/{room_session_id}/actions/mute</c>, but is otherwise the
/// same as <see cref="IActionService.Mute(ActionMuteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionMuteResponse>> Mute(
        ActionMuteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Mute(ActionMuteParams, CancellationToken)"/>
    Task<HttpResponse<ActionMuteResponse>> Mute(
        string roomSessionID,
        ActionMuteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /room_sessions/{room_session_id}/actions/unmute</c>, but is otherwise the
/// same as <see cref="IActionService.Unmute(ActionUnmuteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionUnmuteResponse>> Unmute(
        ActionUnmuteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Unmute(ActionUnmuteParams, CancellationToken)"/>
    Task<HttpResponse<ActionUnmuteResponse>> Unmute(
        string roomSessionID,
        ActionUnmuteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}