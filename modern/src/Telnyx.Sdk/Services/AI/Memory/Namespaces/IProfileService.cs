using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles;
using Profiles = Telnyx.Sdk.Services.AI.Memory.Namespaces.Profiles;

namespace Telnyx.Sdk.Services.AI.Memory.Namespaces;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IProfileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProfileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Profiles::IMemoryService Memories { get; }

    Profiles::ISourceService Sources { get; }

    /// <summary>
/// Profiles are never created, only written to, so this lists the ones that hold a
/// memory. A profile whose first ingest is still running is not here yet. Ordered
/// by memory count, largest first, so a profile written to while the listing is
/// paged can move between pages and be repeated or missed.
/// </summary>
    Task<ProfileListPage> List(
        ProfileListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ProfileListParams, CancellationToken)"/>
    Task<ProfileListPage> List(
        string namespace_,
        ProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete everything held about one profile. A 2xx means none of its memories are
/// left, and its summary goes with them. There is no undo.
/// </summary>
    Task<ProfileDeleteResponse> Delete(
        ProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(ProfileDeleteParams, CancellationToken)"/>
    Task<ProfileDeleteResponse> Delete(
        string profileID,
        ProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Store a session. Facts are extracted from whatever you send — the body is taken
/// as any JSON value and stored whole, so a framework's own transcript shape works
/// unchanged. `messages` of `role`/`content` is the conventional shape, not a
/// requirement. An empty object or a null body is refused. Carry a `session_id` to
/// name the session: re-ingesting the same one replaces what it held. Omit it and a
/// session is opened and returned. Extraction runs asynchronously — poll the
/// returned operation.
/// </summary>
    Task<ProfileIngestResponse> Ingest(
        ProfileIngestParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Ingest(ProfileIngestParams, CancellationToken)"/>
    Task<ProfileIngestResponse> Ingest(
        string profileID,
        ProfileIngestParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Ranked memories for a question. Matching runs over the profile's memories and
/// returns them in rank order with a relevance `score`; the score is null where the
/// deployment's reranker is a passthrough, in which case order is the only signal.
/// No model runs in this path — recall returns facts, it does not compose an
/// answer.
/// </summary>
    Task<ProfileRecallResponse> Recall(
        ProfileRecallParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Recall(ProfileRecallParams, CancellationToken)"/>
    Task<ProfileRecallResponse> Recall(
        string profileID,
        ProfileRecallParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// For a fact the agent has already distilled: `text` is stored as given, with
/// nothing extracted from it. Send a transcript to `ingest` instead. Remembering
/// the same text again writes the same memory rather than a second copy of it, so a
/// retry is safe. The write runs asynchronously -- poll the returned operation.
/// </summary>
    Task<ProfileRememberResponse> Remember(
        ProfileRememberParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Remember(ProfileRememberParams, CancellationToken)"/>
    Task<ProfileRememberResponse> Remember(
        string profileID,
        ProfileRememberParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// The whole profile as one card, precomputed, with no query. Built for the start
/// of a session, where there is no question to ask yet.
/// 
/// <para>A summary is generated in the background. `is_stale` tells you newer
/// memories have arrived since it was written; that is ordinary and the card is
/// still usable.</para>
/// </summary>
    Task<ProfileRetrieveSummaryResponse> RetrieveSummary(
        ProfileRetrieveSummaryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveSummary(ProfileRetrieveSummaryParams, CancellationToken)"/>
    Task<ProfileRetrieveSummaryResponse> RetrieveSummary(
        string profileID,
        ProfileRetrieveSummaryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IProfileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProfileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Profiles::IMemoryServiceWithRawResponse Memories { get; }

    Profiles::ISourceServiceWithRawResponse Sources { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/memory/namespaces/{namespace}/profiles</c>, but is otherwise the
/// same as <see cref="IProfileService.List(ProfileListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ProfileListPage>> List(
        ProfileListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ProfileListParams, CancellationToken)"/>
    Task<HttpResponse<ProfileListPage>> List(
        string namespace_,
        ProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/memory/namespaces/{namespace}/profiles/{profile_id}</c>, but is otherwise the
/// same as <see cref="IProfileService.Delete(ProfileDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ProfileDeleteResponse>> Delete(
        ProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(ProfileDeleteParams, CancellationToken)"/>
    Task<HttpResponse<ProfileDeleteResponse>> Delete(
        string profileID,
        ProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/memory/namespaces/{namespace}/profiles/{profile_id}/ingest</c>, but is otherwise the
/// same as <see cref="IProfileService.Ingest(ProfileIngestParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ProfileIngestResponse>> Ingest(
        ProfileIngestParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Ingest(ProfileIngestParams, CancellationToken)"/>
    Task<HttpResponse<ProfileIngestResponse>> Ingest(
        string profileID,
        ProfileIngestParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/memory/namespaces/{namespace}/profiles/{profile_id}/recall</c>, but is otherwise the
/// same as <see cref="IProfileService.Recall(ProfileRecallParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ProfileRecallResponse>> Recall(
        ProfileRecallParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Recall(ProfileRecallParams, CancellationToken)"/>
    Task<HttpResponse<ProfileRecallResponse>> Recall(
        string profileID,
        ProfileRecallParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/memory/namespaces/{namespace}/profiles/{profile_id}/remember</c>, but is otherwise the
/// same as <see cref="IProfileService.Remember(ProfileRememberParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ProfileRememberResponse>> Remember(
        ProfileRememberParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Remember(ProfileRememberParams, CancellationToken)"/>
    Task<HttpResponse<ProfileRememberResponse>> Remember(
        string profileID,
        ProfileRememberParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/memory/namespaces/{namespace}/profiles/{profile_id}/summary</c>, but is otherwise the
/// same as <see cref="IProfileService.RetrieveSummary(ProfileRetrieveSummaryParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ProfileRetrieveSummaryResponse>> RetrieveSummary(
        ProfileRetrieveSummaryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveSummary(ProfileRetrieveSummaryParams, CancellationToken)"/>
    Task<HttpResponse<ProfileRetrieveSummaryResponse>> RetrieveSummary(
        string profileID,
        ProfileRetrieveSummaryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}