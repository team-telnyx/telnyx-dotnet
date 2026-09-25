using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MeetingSessions.Artifacts;

namespace Telnyx.Sdk.Services.MeetingSessions;

/// <summary>
/// Create and retrieve asynchronous summaries and action-item artifacts.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IArtifactService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IArtifactServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IArtifactService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Requests asynchronous generation of one artifact: `summary`, `action_items`,
/// `decisions`, `topics`, `open_questions`, or `custom`. Each request produces one
/// artifact. `custom` is answered from a `prompt` you supply, which is required for
/// `custom` and rejected on the five named types. Generation requires transcript
/// content and configured inference and currently reads at most the first 10,000
/// segments, so exceptionally long transcripts may produce incomplete artifacts or
/// fail model limits. **Not idempotent, and every call is billed**: each request is
/// a separate inference run, so a retry or a duplicate POST produces a second
/// artifact and a second charge. Guard the call rather than relying on the service
/// to collapse it. The automatic `summarize_on_end` attempt is billed on the same
/// basis.
/// </summary>
    Task<MeetingSessionArtifactResponse> Create(
        ArtifactCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(ArtifactCreateParams, CancellationToken)"/>
    Task<MeetingSessionArtifactResponse> Create(
        string id,
        ArtifactCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves a single meeting session artifact by ID.
/// </summary>
    Task<MeetingSessionArtifactResponse> Retrieve(
        ArtifactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ArtifactRetrieveParams, CancellationToken)"/>
    Task<MeetingSessionArtifactResponse> Retrieve(
        string artifactID,
        ArtifactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of artifacts for a meeting session.
/// </summary>
    Task<ArtifactListResponse> List(
        ArtifactListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ArtifactListParams, CancellationToken)"/>
    Task<ArtifactListResponse> List(
        string id,
        ArtifactListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IArtifactService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IArtifactServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IArtifactServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /meeting_sessions/{id}/artifacts</c>, but is otherwise the
/// same as <see cref="IArtifactService.Create(ArtifactCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MeetingSessionArtifactResponse>> Create(
        ArtifactCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(ArtifactCreateParams, CancellationToken)"/>
    Task<HttpResponse<MeetingSessionArtifactResponse>> Create(
        string id,
        ArtifactCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /meeting_sessions/{id}/artifacts/{artifact_id}</c>, but is otherwise the
/// same as <see cref="IArtifactService.Retrieve(ArtifactRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MeetingSessionArtifactResponse>> Retrieve(
        ArtifactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ArtifactRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MeetingSessionArtifactResponse>> Retrieve(
        string artifactID,
        ArtifactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /meeting_sessions/{id}/artifacts</c>, but is otherwise the
/// same as <see cref="IArtifactService.List(ArtifactListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ArtifactListResponse>> List(
        ArtifactListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ArtifactListParams, CancellationToken)"/>
    Task<HttpResponse<ArtifactListResponse>> List(
        string id,
        ArtifactListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}