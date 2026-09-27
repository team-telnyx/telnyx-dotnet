using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Rooms;
using Rooms = Telnyx.Sdk.Services.Rooms;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Rooms operations.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRoomService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRoomServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRoomService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Rooms::IActionService Actions { get; }

    Rooms::ISessionService Sessions { get; }

    /// <summary>
/// Synchronously creates a new video room with the provided configuration and
/// returns the created room.
/// </summary>
    Task<RoomCreateResponse> Create(
        RoomCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the room identified by `room_id`, including its participant limit,
/// recording and webhook configuration, and active session identifier. Use
/// `include_sessions` to include its sessions.
/// </summary>
    Task<RoomRetrieveResponse> Retrieve(
        RoomRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RoomRetrieveParams, CancellationToken)"/>
    Task<RoomRetrieveResponse> Retrieve(
        string roomID,
        RoomRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Synchronously updates the specified video room's configuration and returns the
/// updated room.
/// </summary>
    Task<RoomUpdateResponse> Update(
        RoomUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(RoomUpdateParams, CancellationToken)"/>
    Task<RoomUpdateResponse> Update(
        string roomID,
        RoomUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of rooms. Filter the results by creation or update date
/// and unique name, and use `include_sessions` to include each room’s sessions.
/// </summary>
    Task<RoomListPage> List(
        RoomListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Synchronously delete a Room. Participants from that room will be kicked out,
/// they won't be able to join that room anymore, and you won't be charged anymore
/// for that room.
/// </summary>
    Task Delete(
        RoomDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(RoomDeleteParams, CancellationToken)"/>
    Task Delete(
        string roomID,
        RoomDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRoomService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRoomServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRoomServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Rooms::IActionServiceWithRawResponse Actions { get; }

    Rooms::ISessionServiceWithRawResponse Sessions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /rooms</c>, but is otherwise the
/// same as <see cref="IRoomService.Create(RoomCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RoomCreateResponse>> Create(
        RoomCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /rooms/{room_id}</c>, but is otherwise the
/// same as <see cref="IRoomService.Retrieve(RoomRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RoomRetrieveResponse>> Retrieve(
        RoomRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RoomRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RoomRetrieveResponse>> Retrieve(
        string roomID,
        RoomRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /rooms/{room_id}</c>, but is otherwise the
/// same as <see cref="IRoomService.Update(RoomUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RoomUpdateResponse>> Update(
        RoomUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(RoomUpdateParams, CancellationToken)"/>
    Task<HttpResponse<RoomUpdateResponse>> Update(
        string roomID,
        RoomUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /rooms</c>, but is otherwise the
/// same as <see cref="IRoomService.List(RoomListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RoomListPage>> List(
        RoomListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /rooms/{room_id}</c>, but is otherwise the
/// same as <see cref="IRoomService.Delete(RoomDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        RoomDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(RoomDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string roomID,
        RoomDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}