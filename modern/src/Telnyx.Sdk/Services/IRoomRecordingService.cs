using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.RoomRecordings;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Rooms Recordings operations.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRoomRecordingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRoomRecordingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRoomRecordingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns the recording identified by `room_recording_id`, including its room,
/// session, participant, status, media details, lifecycle timestamps, and download
/// URL.
/// </summary>
    Task<RoomRecordingRetrieveResponse> Retrieve(
        RoomRecordingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RoomRecordingRetrieveParams, CancellationToken)"/>
    Task<RoomRecordingRetrieveResponse> Retrieve(
        string roomRecordingID,
        RoomRecordingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of room recordings. Filter recordings by room, session,
/// participant, recording type, status, duration, or start and end dates.
/// </summary>
    Task<RoomRecordingListPage> List(
        RoomRecordingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Synchronously deletes the specified video room recording. The recording's media
/// is removed permanently.
/// </summary>
    Task Delete(
        RoomRecordingDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(RoomRecordingDeleteParams, CancellationToken)"/>
    Task Delete(
        string roomRecordingID,
        RoomRecordingDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the room recordings that match the supplied filters and returns the
/// number of recordings affected. Filters support room, session, participant,
/// recording type, status, duration, and start or end dates.
/// </summary>
    Task<RoomRecordingDeleteBulkResponse> DeleteBulk(
        RoomRecordingDeleteBulkParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRoomRecordingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRoomRecordingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRoomRecordingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /room_recordings/{room_recording_id}</c>, but is otherwise the
/// same as <see cref="IRoomRecordingService.Retrieve(RoomRecordingRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RoomRecordingRetrieveResponse>> Retrieve(
        RoomRecordingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RoomRecordingRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RoomRecordingRetrieveResponse>> Retrieve(
        string roomRecordingID,
        RoomRecordingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /room_recordings</c>, but is otherwise the
/// same as <see cref="IRoomRecordingService.List(RoomRecordingListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RoomRecordingListPage>> List(
        RoomRecordingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /room_recordings/{room_recording_id}</c>, but is otherwise the
/// same as <see cref="IRoomRecordingService.Delete(RoomRecordingDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        RoomRecordingDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(RoomRecordingDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string roomRecordingID,
        RoomRecordingDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /room_recordings</c>, but is otherwise the
/// same as <see cref="IRoomRecordingService.DeleteBulk(RoomRecordingDeleteBulkParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RoomRecordingDeleteBulkResponse>> DeleteBulk(
        RoomRecordingDeleteBulkParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}