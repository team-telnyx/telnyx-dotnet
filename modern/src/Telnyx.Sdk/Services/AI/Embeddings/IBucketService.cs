using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Embeddings.Buckets;

namespace Telnyx.Sdk.Services.AI.Embeddings;

/// <summary>
/// Embed documents and perform text searches
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBucketService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBucketServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBucketService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Get all embedded files for a given user bucket, including their processing
/// status.
/// </summary>
    Task<BucketRetrieveResponse> Retrieve(
        BucketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(BucketRetrieveParams, CancellationToken)"/>
    Task<BucketRetrieveResponse> Retrieve(
        string bucketName,
        BucketRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the list of storage buckets that have been embedded for your account,
/// for use with similarity search.
/// </summary>
    Task<BucketListResponse> List(
        BucketListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes an entire bucket's embeddings and disables the bucket for AI-use,
/// returning it to normal storage pricing.
/// </summary>
    Task Delete(
        BucketDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(BucketDeleteParams, CancellationToken)"/>
    Task Delete(
        string bucketName,
        BucketDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IBucketService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBucketServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBucketServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/embeddings/buckets/{bucket_name}</c>, but is otherwise the
/// same as <see cref="IBucketService.Retrieve(BucketRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BucketRetrieveResponse>> Retrieve(
        BucketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(BucketRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BucketRetrieveResponse>> Retrieve(
        string bucketName,
        BucketRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/embeddings/buckets</c>, but is otherwise the
/// same as <see cref="IBucketService.List(BucketListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BucketListResponse>> List(
        BucketListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/embeddings/buckets/{bucket_name}</c>, but is otherwise the
/// same as <see cref="IBucketService.Delete(BucketDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        BucketDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(BucketDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string bucketName,
        BucketDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}