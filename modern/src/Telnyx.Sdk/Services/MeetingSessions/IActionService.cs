using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MeetingSessions.Actions;

namespace Telnyx.Sdk.Services.MeetingSessions;

/// <summary>
/// Send real-time speech and chat actions to an active meeting session.
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
/// Sends a chat message into a meeting session.
/// </summary>
    Task<ActionAcceptedResponse> SendChat(
        ActionSendChatParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SendChat(ActionSendChatParams, CancellationToken)"/>
    Task<ActionAcceptedResponse> SendChat(
        string id,
        ActionSendChatParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Sends audio / text-to-speech into a meeting session. With a Telnyx AI Assistant
/// (or avatar) attached, the bot is a webpage-output bot: the speak audio routes
/// through the assistant's output page rather than the bot mic and plays once the
/// assistant is connected -- it is not refused. If that page cannot be reached,
/// delivery fails with the 502 below, which may arrive without an error envelope,
/// so branch on the status code before parsing a body. The assistant is designed to
/// own the conversation, so prefer letting it speak or use `send_chat`.
/// </summary>
    Task<ActionAcceptedResponse> Speak(
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Speak(ActionSpeakParams, CancellationToken)"/>
    Task<ActionAcceptedResponse> Speak(
        string id,
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Stops any active text-to-speech playback in a meeting session.
/// </summary>
    Task<ActionAcceptedResponse> StopSpeaking(
        ActionStopSpeakingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopSpeaking(ActionStopSpeakingParams, CancellationToken)"/>
    Task<ActionAcceptedResponse> StopSpeaking(
        string id,
        ActionStopSpeakingParams? parameters = null,
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
/// Returns a raw HTTP response for <c>post /meeting_sessions/{id}/actions/send_chat</c>, but is otherwise the
/// same as <see cref="IActionService.SendChat(ActionSendChatParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionAcceptedResponse>> SendChat(
        ActionSendChatParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SendChat(ActionSendChatParams, CancellationToken)"/>
    Task<HttpResponse<ActionAcceptedResponse>> SendChat(
        string id,
        ActionSendChatParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /meeting_sessions/{id}/actions/speak</c>, but is otherwise the
/// same as <see cref="IActionService.Speak(ActionSpeakParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionAcceptedResponse>> Speak(
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Speak(ActionSpeakParams, CancellationToken)"/>
    Task<HttpResponse<ActionAcceptedResponse>> Speak(
        string id,
        ActionSpeakParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /meeting_sessions/{id}/actions/stop_speaking</c>, but is otherwise the
/// same as <see cref="IActionService.StopSpeaking(ActionStopSpeakingParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionAcceptedResponse>> StopSpeaking(
        ActionStopSpeakingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StopSpeaking(ActionStopSpeakingParams, CancellationToken)"/>
    Task<HttpResponse<ActionAcceptedResponse>> StopSpeaking(
        string id,
        ActionStopSpeakingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}