using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Collections.Sources;

namespace Telnyx.Sdk.Services.AI.Collections;

/// <summary>
/// Create and manage logical collections of your Telnyx data, tune retrieval settings,
/// manage sources, and run collection-scoped semantic search.
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
/// Attaches a new content source to the specified collection and returns the
/// created source. The source's content is ingested and embedded so it becomes
/// searchable within the collection.
/// </summary>
    Task<SourceCreateResponse> Create(
        SourceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(SourceCreateParams, CancellationToken)"/>
    Task<SourceCreateResponse> Create(
        string uuid,
        SourceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the sources attached to a collection.
/// </summary>
    Task<SourceListResponse> List(
        SourceListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(SourceListParams, CancellationToken)"/>
    Task<SourceListResponse> List(
        string uuid,
        SourceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes a single source from a collection.
/// </summary>
    Task Delete(
        SourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SourceDeleteParams, CancellationToken)"/>
    Task Delete(
        string sourceID,
        SourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Replaces the collection's entire source set. The response `meta` reports which
/// sources were added, retained, and removed.
/// </summary>
    Task<SourceReplaceResponse> Replace(
        SourceReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Replace(SourceReplaceParams, CancellationToken)"/>
    Task<SourceReplaceResponse> Replace(
        string uuid,
        SourceReplaceParams parameters,
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
/// Returns a raw HTTP response for <c>post /ai/collections/{uuid}/sources</c>, but is otherwise the
/// same as <see cref="ISourceService.Create(SourceCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SourceCreateResponse>> Create(
        SourceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(SourceCreateParams, CancellationToken)"/>
    Task<HttpResponse<SourceCreateResponse>> Create(
        string uuid,
        SourceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/collections/{uuid}/sources</c>, but is otherwise the
/// same as <see cref="ISourceService.List(SourceListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SourceListResponse>> List(
        SourceListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(SourceListParams, CancellationToken)"/>
    Task<HttpResponse<SourceListResponse>> List(
        string uuid,
        SourceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/collections/{uuid}/sources/{sourceId}</c>, but is otherwise the
/// same as <see cref="ISourceService.Delete(SourceDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        SourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SourceDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string sourceID,
        SourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /ai/collections/{uuid}/sources</c>, but is otherwise the
/// same as <see cref="ISourceService.Replace(SourceReplaceParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SourceReplaceResponse>> Replace(
        SourceReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Replace(SourceReplaceParams, CancellationToken)"/>
    Task<HttpResponse<SourceReplaceResponse>> Replace(
        string uuid,
        SourceReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}