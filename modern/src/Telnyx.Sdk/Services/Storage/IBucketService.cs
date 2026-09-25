using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage.Buckets;
using Telnyx.Sdk.Services.Storage.Buckets;

namespace Telnyx.Sdk.Services.Storage;

/// <summary>
/// Presigned object URL operations
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

    ISslCertificateService SslCertificate { get; }

    IUsageService Usage { get; }

    /// <summary>
/// Returns a timed and authenticated URL to download (GET) or upload (PUT) an
/// object. This is the equivalent to AWS S3’s “presigned” URL. Please note that
/// Telnyx performs authentication differently from AWS S3 and you MUST NOT use the
/// presign method of AWS s3api CLI or SDK to generate the presigned URL.
/// 
/// <para>Refer to: https://developers.telnyx.com/docs/cloud-storage/presigned-urls </para>
/// </summary>
    Task<BucketCreatePresignedUrlResponse> CreatePresignedUrl(
        BucketCreatePresignedUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CreatePresignedUrl(BucketCreatePresignedUrlParams, CancellationToken)"/>
    Task<BucketCreatePresignedUrlResponse> CreatePresignedUrl(
        string objectName,
        BucketCreatePresignedUrlParams parameters,
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

    ISslCertificateServiceWithRawResponse SslCertificate { get; }

    IUsageServiceWithRawResponse Usage { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /storage/buckets/{bucketName}/{objectName}/presigned_url</c>, but is otherwise the
/// same as <see cref="IBucketService.CreatePresignedUrl(BucketCreatePresignedUrlParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BucketCreatePresignedUrlResponse>> CreatePresignedUrl(
        BucketCreatePresignedUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CreatePresignedUrl(BucketCreatePresignedUrlParams, CancellationToken)"/>
    Task<HttpResponse<BucketCreatePresignedUrlResponse>> CreatePresignedUrl(
        string objectName,
        BucketCreatePresignedUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}