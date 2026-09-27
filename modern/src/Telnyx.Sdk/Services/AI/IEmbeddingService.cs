using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Embeddings;
using Telnyx.Sdk.Services.AI.Embeddings;

namespace Telnyx.Sdk.Services.AI;

/// <summary>
/// Embed documents and perform text searches
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEmbeddingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEmbeddingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmbeddingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IBucketService Buckets { get; }

    /// <summary>
/// Perform embedding on a Telnyx Storage Bucket using the a embedding model. The
/// current supported file types are: - PDF - HTML - txt/unstructured text files -
/// json - csv - audio / video (mp3, mp4, mpeg, mpga, m4a, wav, or webm ) - Max of
/// 100mb file size.
/// 
/// <para>Any files not matching the above types will be attempted to be embedded as
/// unstructured text.</para>
/// 
/// <para>This process can be slow, so it runs in the background and the user can
/// check the status of the task using the endpoint `/ai/embeddings/{task_id}`.</para>
/// 
/// <para> **Important Note**: When you update documents in a Telnyx Storage bucket, their
/// associated embeddings are automatically kept up to date. If you add or update a file,
/// it is automatically embedded. If you delete a file, the embeddings are deleted for
/// that particular file.</para>
/// 
/// <para>You can also specify a custom `loader` param. Currently the only supported
/// loader value is `intercom` which loads Intercom article jsons as specified by
/// [the Intercom article
/// API](https://developers.intercom.com/docs/references/rest-api/api.intercom.io/Articles/article/)
/// This loader will split each article into paragraphs and save additional
/// parameters relevant to Intercom docs, such as `article_url` and `heading`. These
/// values will be returned by the `/v2/ai/embeddings/similarity-search` endpoint in
/// the `loader_metadata` field.</para>
/// </summary>
    Task<EmbeddingResponse> Create(
        EmbeddingCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Check the status of a current embedding task. Will be one of the following: -
/// `queued` - Task is waiting to be picked up by a worker - `processing` - The
/// embedding task is running - `success` - Task completed successfully and the
/// bucket is embedded - `failure` - Task failed and no files were embedded
/// successfully - `partial_success` - Some files were embedded successfully, but at
/// least one failed
/// </summary>
    Task<EmbeddingRetrieveResponse> Retrieve(
        EmbeddingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EmbeddingRetrieveParams, CancellationToken)"/>
    Task<EmbeddingRetrieveResponse> Retrieve(
        string taskID,
        EmbeddingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve tasks for the user that are either `queued`, `processing`, `failed`,
/// `success` or `partial_success` based on the query string. Defaults to `queued`
/// and `processing`.
/// </summary>
    Task<EmbeddingListResponse> List(
        EmbeddingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Perform a similarity search on a Telnyx Storage Bucket, returning the most
/// similar `num_docs` document chunks to the query.
/// 
/// <para>Currently the only available distance metric is cosine similarity which
/// will return a `distance` between 0 and 1. The lower the distance, the more
/// similar the returned document chunks are to the query. A `certainty` will also
/// be returned, which is a value between 0 and 1 where the higher the certainty,
/// the more similar the document. You can read more about Weaviate distance metrics
/// here: [Weaviate
/// Docs](https://weaviate.io/developers/weaviate/config-refs/distances)</para>
/// 
/// <para>If a bucket was embedded using a custom loader, such as `intercom`, the
/// additional metadata will be returned in the  `loader_metadata` field.</para>
/// </summary>
    Task<EmbeddingSimilaritySearchResponse> SimilaritySearch(
        EmbeddingSimilaritySearchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Embed website content from a specified URL, including child pages up to 5 levels
/// deep within the same domain. The process crawls and loads content from the main
/// URL and its linked pages into a Telnyx Cloud Storage bucket. As soon as each
/// webpage is added to the bucket, its content is immediately processed for
/// embeddings, that can be used for [similarity
/// search](https://developers.telnyx.com/api-reference/embeddings/search-for-documents)
/// and [clustering](https://developers.telnyx.com/docs/inference/clusters).
/// </summary>
    Task<EmbeddingResponse> Url(
        EmbeddingUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IEmbeddingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEmbeddingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmbeddingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IBucketServiceWithRawResponse Buckets { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/embeddings</c>, but is otherwise the
/// same as <see cref="IEmbeddingService.Create(EmbeddingCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmbeddingResponse>> Create(
        EmbeddingCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/embeddings/{task_id}</c>, but is otherwise the
/// same as <see cref="IEmbeddingService.Retrieve(EmbeddingRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmbeddingRetrieveResponse>> Retrieve(
        EmbeddingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EmbeddingRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EmbeddingRetrieveResponse>> Retrieve(
        string taskID,
        EmbeddingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/embeddings</c>, but is otherwise the
/// same as <see cref="IEmbeddingService.List(EmbeddingListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmbeddingListResponse>> List(
        EmbeddingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/embeddings/similarity-search</c>, but is otherwise the
/// same as <see cref="IEmbeddingService.SimilaritySearch(EmbeddingSimilaritySearchParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmbeddingSimilaritySearchResponse>> SimilaritySearch(
        EmbeddingSimilaritySearchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/embeddings/url</c>, but is otherwise the
/// same as <see cref="IEmbeddingService.Url(EmbeddingUrlParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmbeddingResponse>> Url(
        EmbeddingUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}