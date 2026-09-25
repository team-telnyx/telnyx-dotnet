using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MeetingSessions;
using MeetingSessions = Telnyx.Sdk.Services.MeetingSessions;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMeetingSessionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMeetingSessionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMeetingSessionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    MeetingSessions::IActionService Actions { get; }

    MeetingSessions::IArtifactService Artifacts { get; }

    /// <summary>
/// Creates a new meeting session. When an idempotency_key is supplied in the
/// request body, replay lookup is scoped to the authenticated account and compares
/// only the key; the request payload is not fingerprinted or compared. If a session
/// with that key already exists for the account, the existing session is replayed
/// (200); otherwise a new session is created (201). Supports bring-your-own-key
/// (BYOK) configuration. The session may enter asynchronous states (e.g. joining,
/// waiting_for_admission) before becoming active. Optional `camera_image` input is
/// write-only and applies only when no Avatar or Assistant webpage output takes
/// precedence. An ignored URL is not fetched. An effective URL source is resolved
/// before bot creation; neither the source URL nor image bytes are persisted,
/// returned, or logged. Treat signed URLs as credentials.
/// </summary>
    Task<MeetingSessionResponse> Create(
        MeetingSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves a single meeting session by ID. A session that does not exist or that
/// belongs to a different account both return 404.
/// </summary>
    Task<MeetingSessionResponse> Retrieve(
        MeetingSessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MeetingSessionRetrieveParams, CancellationToken)"/>
    Task<MeetingSessionResponse> Retrieve(
        string id,
        MeetingSessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates mutable properties of a meeting session. Only sessions in the scheduled
/// state can be updated; any other state returns 409 with the invalid_state error
/// code. All request fields are optional, and an empty object is a valid no-op
/// update.
/// </summary>
    Task<MeetingSessionResponse> Update(
        MeetingSessionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MeetingSessionUpdateParams, CancellationToken)"/>
    Task<MeetingSessionResponse> Update(
        string id,
        MeetingSessionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of meeting sessions, optionally filtered by status.
/// </summary>
    Task<MeetingSessionListResponse> List(
        MeetingSessionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Stops a meeting session without deleting its persisted record. Scheduled bots
/// are cancelled, while bots that are joining or active are asked to leave. The
/// persisted meeting session record remains available.
/// </summary>
    Task<MeetingSessionResponse> Delete(
        MeetingSessionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MeetingSessionDeleteParams, CancellationToken)"/>
    Task<MeetingSessionResponse> Delete(
        string id,
        MeetingSessionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Irreversibly requests deletion of provider-hosted aggregate recording media
/// under the provider contract. The operation retains the Telnyx-local Meeting
/// session, transcript segments, events, artifacts, and usage records. It is
/// separate from `DELETE /meeting_sessions/{id}`, which stops or cancels
/// participation without deleting the persisted session. A missing/foreign session
/// returns 404; provider deletion failures return 502.
/// </summary>
    Task<MeetingSessionDeleteRecordingMediaResponse> DeleteRecordingMedia(
        MeetingSessionDeleteRecordingMediaParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteRecordingMedia(MeetingSessionDeleteRecordingMediaParams, CancellationToken)"/>
    Task<MeetingSessionDeleteRecordingMediaResponse> DeleteRecordingMedia(
        string id,
        MeetingSessionDeleteRecordingMediaParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns stored events ordered by ascending `seq`. To continue, pass the last
/// returned item's `seq` as `after`. An empty page means no later stored events
/// existed at read time; this operation returns no separate next-page cursor.
/// Default `limit` is 100 and maximum is 1,000.
/// </summary>
    Task<MeetingSessionRetrieveEventsResponse> RetrieveEvents(
        MeetingSessionRetrieveEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveEvents(MeetingSessionRetrieveEventsParams, CancellationToken)"/>
    Task<MeetingSessionRetrieveEventsResponse> RetrieveEvents(
        string id,
        MeetingSessionRetrieveEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns recordings for a meeting session.
/// </summary>
    Task<MeetingSessionRetrieveRecordingsResponse> RetrieveRecordings(
        MeetingSessionRetrieveRecordingsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRecordings(MeetingSessionRetrieveRecordingsParams, CancellationToken)"/>
    Task<MeetingSessionRetrieveRecordingsResponse> RetrieveRecordings(
        string id,
        MeetingSessionRetrieveRecordingsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns transcript segments ordered by ascending `seq`. Default `limit` is 100
/// and maximum is 1,000. Continue with `after=meta.next_after`. A long-poll timeout
/// returns 200 with empty `data` and `meta.next_after: null`; retain the cursor
/// supplied to that request because null is not a replacement cursor.
/// </summary>
    Task<MeetingSessionRetrieveTranscriptResponse> RetrieveTranscript(
        MeetingSessionRetrieveTranscriptParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveTranscript(MeetingSessionRetrieveTranscriptParams, CancellationToken)"/>
    Task<MeetingSessionRetrieveTranscriptResponse> RetrieveTranscript(
        string id,
        MeetingSessionRetrieveTranscriptParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMeetingSessionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMeetingSessionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMeetingSessionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    MeetingSessions::IActionServiceWithRawResponse Actions { get; }

    MeetingSessions::IArtifactServiceWithRawResponse Artifacts { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /meeting_sessions</c>, but is otherwise the
/// same as <see cref="IMeetingSessionService.Create(MeetingSessionCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MeetingSessionResponse>> Create(
        MeetingSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /meeting_sessions/{id}</c>, but is otherwise the
/// same as <see cref="IMeetingSessionService.Retrieve(MeetingSessionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MeetingSessionResponse>> Retrieve(
        MeetingSessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MeetingSessionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MeetingSessionResponse>> Retrieve(
        string id,
        MeetingSessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /meeting_sessions/{id}</c>, but is otherwise the
/// same as <see cref="IMeetingSessionService.Update(MeetingSessionUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MeetingSessionResponse>> Update(
        MeetingSessionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MeetingSessionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<MeetingSessionResponse>> Update(
        string id,
        MeetingSessionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /meeting_sessions</c>, but is otherwise the
/// same as <see cref="IMeetingSessionService.List(MeetingSessionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MeetingSessionListResponse>> List(
        MeetingSessionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /meeting_sessions/{id}</c>, but is otherwise the
/// same as <see cref="IMeetingSessionService.Delete(MeetingSessionDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MeetingSessionResponse>> Delete(
        MeetingSessionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MeetingSessionDeleteParams, CancellationToken)"/>
    Task<HttpResponse<MeetingSessionResponse>> Delete(
        string id,
        MeetingSessionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /meeting_sessions/{id}/recording_media</c>, but is otherwise the
/// same as <see cref="IMeetingSessionService.DeleteRecordingMedia(MeetingSessionDeleteRecordingMediaParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MeetingSessionDeleteRecordingMediaResponse>> DeleteRecordingMedia(
        MeetingSessionDeleteRecordingMediaParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteRecordingMedia(MeetingSessionDeleteRecordingMediaParams, CancellationToken)"/>
    Task<HttpResponse<MeetingSessionDeleteRecordingMediaResponse>> DeleteRecordingMedia(
        string id,
        MeetingSessionDeleteRecordingMediaParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /meeting_sessions/{id}/events</c>, but is otherwise the
/// same as <see cref="IMeetingSessionService.RetrieveEvents(MeetingSessionRetrieveEventsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MeetingSessionRetrieveEventsResponse>> RetrieveEvents(
        MeetingSessionRetrieveEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveEvents(MeetingSessionRetrieveEventsParams, CancellationToken)"/>
    Task<HttpResponse<MeetingSessionRetrieveEventsResponse>> RetrieveEvents(
        string id,
        MeetingSessionRetrieveEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /meeting_sessions/{id}/recordings</c>, but is otherwise the
/// same as <see cref="IMeetingSessionService.RetrieveRecordings(MeetingSessionRetrieveRecordingsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MeetingSessionRetrieveRecordingsResponse>> RetrieveRecordings(
        MeetingSessionRetrieveRecordingsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRecordings(MeetingSessionRetrieveRecordingsParams, CancellationToken)"/>
    Task<HttpResponse<MeetingSessionRetrieveRecordingsResponse>> RetrieveRecordings(
        string id,
        MeetingSessionRetrieveRecordingsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /meeting_sessions/{id}/transcript</c>, but is otherwise the
/// same as <see cref="IMeetingSessionService.RetrieveTranscript(MeetingSessionRetrieveTranscriptParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MeetingSessionRetrieveTranscriptResponse>> RetrieveTranscript(
        MeetingSessionRetrieveTranscriptParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveTranscript(MeetingSessionRetrieveTranscriptParams, CancellationToken)"/>
    Task<HttpResponse<MeetingSessionRetrieveTranscriptResponse>> RetrieveTranscript(
        string id,
        MeetingSessionRetrieveTranscriptParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}