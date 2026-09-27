using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.RoomParticipants;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Rooms Participants operations.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRoomParticipantService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRoomParticipantServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRoomParticipantService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns the participant identified by `room_participant_id`, including its
/// session, context, and join, update, and leave timestamps.
/// </summary>
    Task<RoomParticipantRetrieveResponse> Retrieve(
        RoomParticipantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RoomParticipantRetrieveParams, CancellationToken)"/>
    Task<RoomParticipantRetrieveResponse> Retrieve(
        string roomParticipantID,
        RoomParticipantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of room participants across sessions. Filter
/// participants by session, join, update, or leave date and by participant context.
/// </summary>
    Task<RoomParticipantListPage> List(
        RoomParticipantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRoomParticipantService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRoomParticipantServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRoomParticipantServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /room_participants/{room_participant_id}</c>, but is otherwise the
/// same as <see cref="IRoomParticipantService.Retrieve(RoomParticipantRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RoomParticipantRetrieveResponse>> Retrieve(
        RoomParticipantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RoomParticipantRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RoomParticipantRetrieveResponse>> Retrieve(
        string roomParticipantID,
        RoomParticipantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /room_participants</c>, but is otherwise the
/// same as <see cref="IRoomParticipantService.List(RoomParticipantListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RoomParticipantListPage>> List(
        RoomParticipantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}