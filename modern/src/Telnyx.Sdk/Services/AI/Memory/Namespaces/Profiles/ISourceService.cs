using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles.Sources;

namespace Telnyx.Sdk.Services.AI.Memory.Namespaces.Profiles;

/// <summary>
/// What a profile stored, and what its memories came from.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISourceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISourceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISourceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// One source and its content, as it was stored: an ingested session's payload or a
/// remembered fact. A source whose ingest is still queued answers 404 until it has
/// been stored.
/// </summary>
    Task<SourceRetrieveResponse> Retrieve(
        SourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SourceRetrieveParams, CancellationToken)"/>
    Task<SourceRetrieveResponse> Retrieve(
        string sourceID,
        SourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Everything a profile has stored and extracts memories from: each ingested
/// session, and each remembered fact, which has no session. Content is not listed;
/// read one source for it. A source whose ingest is still queued is not here yet.
/// Re-ingesting a session moves it to the front, so a listing paged while sessions
/// are written can repeat or miss one at a page boundary. A `session_id` narrows
/// the listing to the source that session was stored as: one source or none, and
/// none -- an empty page, not a 404 -- for a session never ingested, still queued,
/// or another profile's.
/// </summary>
    Task<SourceListPage> List(
        SourceListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(SourceListParams, CancellationToken)"/>
    Task<SourceListPage> List(
        string profileID,
        SourceListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes one source -- an ingested session or a remembered fact -- together with
/// the memories derived from it. A memory derived from this source and others is
/// deleted too, and derived again from what remains in the background. It answers
/// only once the source is gone. A source that is not there -- never stored,
/// another profile's, or already deleted -- answers 404, so on a `502` or a `504`
/// repeat the identical request and read a 404 as done. An ingest of the same
/// session that is still queued is not cancelled, and stores the session again when
/// it runs. Nothing here can be undone.
/// </summary>
    Task<SourceDeleteResponse> Delete(
        SourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SourceDeleteParams, CancellationToken)"/>
    Task<SourceDeleteResponse> Delete(
        string sourceID,
        SourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISourceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISourceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISourceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/memory/namespaces/{namespace}/profiles/{profile_id}/sources/{source_id}</c>, but is otherwise the
/// same as <see cref="ISourceService.Retrieve(SourceRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SourceRetrieveResponse>> Retrieve(
        SourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SourceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SourceRetrieveResponse>> Retrieve(
        string sourceID,
        SourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/memory/namespaces/{namespace}/profiles/{profile_id}/sources</c>, but is otherwise the
/// same as <see cref="ISourceService.List(SourceListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SourceListPage>> List(
        SourceListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(SourceListParams, CancellationToken)"/>
    Task<HttpResponse<SourceListPage>> List(
        string profileID,
        SourceListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/memory/namespaces/{namespace}/profiles/{profile_id}/sources/{source_id}</c>, but is otherwise the
/// same as <see cref="ISourceService.Delete(SourceDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SourceDeleteResponse>> Delete(
        SourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SourceDeleteParams, CancellationToken)"/>
    Task<HttpResponse<SourceDeleteResponse>> Delete(
        string sourceID,
        SourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}