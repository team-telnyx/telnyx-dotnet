using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Knowledge.Collections;

namespace Telnyx.Sdk.Services.AI.Knowledge;

/// <summary>
/// Create and manage logical collections of your Telnyx data, tune retrieval settings,
/// manage sources, and run collection-scoped semantic search.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICollectionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICollectionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICollectionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Runs search over the documents in a collection, ranked by relevance to `query`.
/// Searches currently run `vector` retrieval (semantic similarity). The
/// collection's `retrieval_type` setting is the forward-compatible selector:
/// `hybrid` (vector similarity fused with keyword matching) can be set but cannot
/// be searched yet, and `keyword` (lexical BM25 matching) is not accepted yet --
/// setting it returns 422 `unsupported_retrieval_type`. A per-request
/// `retrieval_type` is accepted but ignored; `meta.retrieval_type` echoes the mode
/// that actually ran. When `query` is omitted, returns a plain catalog listing of
/// the collection's documents.
/// 
/// <para>**How it works:** 1. The `query` text is embedded into a 1024-dimensional
/// vector using the multilingual-e5-large model. 2. The embedding is compared
/// against the collection's indexed document chunks using semantic similarity. When
/// `hybrid` and `keyword` execution ship, those scores will be fused with, or
/// replaced by, lexical BM25 matching. 3. Results are ranked by `score`
/// (descending) and paginated via `page[number]` / `page[size]`.</para>
/// 
/// <para>**Authentication:** Requires a Telnyx API key via `Authorization: Bearer
/// &lt;key&gt;`. Results are automatically scoped to your organization and cannot
/// be overridden.</para>
/// 
/// <para>**Filtering:** Use `filter[field][operator]=value` query parameters to
/// narrow results before search. Supported operators: `eq` (default), `in`, `gte`,
/// `gt`, `lte`, `lt`, `contains`. Metadata fields resolve to
/// `metadata.&lt;field&gt;`.</para>
/// 
/// <para>**Examples:** - `GET
/// /v2/ai/knowledge/collections/my-collection/documents?query=billing+issue&amp;top_k=10`
/// - `GET
/// /v2/ai/knowledge/collections/my-collection/documents?query=refund&amp;sources=voice,message`
/// - `GET
/// /v2/ai/knowledge/collections/my-collection/documents?query=outage&amp;filter[record_created_at][gte]=2026-01-01T00:00:00Z`</para>
/// </summary>
    Task<CollectionRetrieveDocumentsResponse> RetrieveDocuments(
        CollectionRetrieveDocumentsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveDocuments(CollectionRetrieveDocumentsParams, CancellationToken)"/>
    Task<CollectionRetrieveDocumentsResponse> RetrieveDocuments(
        string slug,
        CollectionRetrieveDocumentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICollectionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICollectionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICollectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/knowledge/collections/{slug}/documents</c>, but is otherwise the
/// same as <see cref="ICollectionService.RetrieveDocuments(CollectionRetrieveDocumentsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CollectionRetrieveDocumentsResponse>> RetrieveDocuments(
        CollectionRetrieveDocumentsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveDocuments(CollectionRetrieveDocumentsParams, CancellationToken)"/>
    Task<HttpResponse<CollectionRetrieveDocumentsResponse>> RetrieveDocuments(
        string slug,
        CollectionRetrieveDocumentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}