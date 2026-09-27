using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Rooms.Sessions;
using Sessions = Telnyx.Sdk.Services.Rooms.Sessions;

namespace Telnyx.Sdk.Services.Rooms;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISessionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISessionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISessionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Sessions::IActionService Actions { get; }

    /// <summary>
/// Returns the room session identified by `room_session_id`, including its room,
/// active status, and lifecycle timestamps. Use `include_participants` to include
/// its participant records.
/// </summary>
    Task<SessionRetrieveResponse> Retrieve(
        SessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SessionRetrieveParams, CancellationToken)"/>
    Task<SessionRetrieveResponse> Retrieve(
        string roomSessionID,
        SessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of room sessions across the account. Filter sessions by
/// room, creation, update, or end date and active status, and use
/// `include_participants` to include participant records.
/// </summary>
    Task<SessionList0Page> List0(
        SessionList0Params? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of sessions for the specified room. Filter sessions by
/// creation, update, or end date and active status, and use `include_participants`
/// to include participant records.
/// </summary>
    Task<SessionList1Page> List1(
        SessionList1Params parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List1(SessionList1Params, CancellationToken)"/>
    Task<SessionList1Page> List1(
        string roomID,
        SessionList1Params? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of participants for the specified room session. Filter
/// participants by join, update, or leave date and by participant context.
/// </summary>
    Task<SessionRetrieveParticipantsPage> RetrieveParticipants(
        SessionRetrieveParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveParticipants(SessionRetrieveParticipantsParams, CancellationToken)"/>
    Task<SessionRetrieveParticipantsPage> RetrieveParticipants(
        string roomSessionID,
        SessionRetrieveParticipantsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISessionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISessionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISessionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Sessions::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /room_sessions/{room_session_id}</c>, but is otherwise the
/// same as <see cref="ISessionService.Retrieve(SessionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SessionRetrieveResponse>> Retrieve(
        SessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SessionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SessionRetrieveResponse>> Retrieve(
        string roomSessionID,
        SessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /room_sessions</c>, but is otherwise the
/// same as <see cref="ISessionService.List0(SessionList0Params?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SessionList0Page>> List0(
        SessionList0Params? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /rooms/{room_id}/sessions</c>, but is otherwise the
/// same as <see cref="ISessionService.List1(SessionList1Params, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SessionList1Page>> List1(
        SessionList1Params parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List1(SessionList1Params, CancellationToken)"/>
    Task<HttpResponse<SessionList1Page>> List1(
        string roomID,
        SessionList1Params? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /room_sessions/{room_session_id}/participants</c>, but is otherwise the
/// same as <see cref="ISessionService.RetrieveParticipants(SessionRetrieveParticipantsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SessionRetrieveParticipantsPage>> RetrieveParticipants(
        SessionRetrieveParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveParticipants(SessionRetrieveParticipantsParams, CancellationToken)"/>
    Task<HttpResponse<SessionRetrieveParticipantsPage>> RetrieveParticipants(
        string roomSessionID,
        SessionRetrieveParticipantsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}