using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage.Buckets.Usage;

namespace Telnyx.Sdk.Services.Storage.Buckets;

/// <summary>
/// Bucket Usage operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IUsageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUsageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the detail on API usage on a bucket of a particular time period, group
/// by method category.
/// </summary>
    Task<UsageGetApiUsageResponse> GetApiUsage(
        UsageGetApiUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetApiUsage(UsageGetApiUsageParams, CancellationToken)"/>
    Task<UsageGetApiUsageResponse> GetApiUsage(
        string bucketName,
        UsageGetApiUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the amount of storage space and number of files a bucket takes up.
/// </summary>
    Task<UsageGetBucketUsageResponse> GetBucketUsage(
        UsageGetBucketUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetBucketUsage(UsageGetBucketUsageParams, CancellationToken)"/>
    Task<UsageGetBucketUsageResponse> GetBucketUsage(
        string bucketName,
        UsageGetBucketUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IUsageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUsageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /storage/buckets/{bucketName}/usage/api</c>, but is otherwise the
/// same as <see cref="IUsageService.GetApiUsage(UsageGetApiUsageParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UsageGetApiUsageResponse>> GetApiUsage(
        UsageGetApiUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetApiUsage(UsageGetApiUsageParams, CancellationToken)"/>
    Task<HttpResponse<UsageGetApiUsageResponse>> GetApiUsage(
        string bucketName,
        UsageGetApiUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /storage/buckets/{bucketName}/usage/storage</c>, but is otherwise the
/// same as <see cref="IUsageService.GetBucketUsage(UsageGetBucketUsageParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UsageGetBucketUsageResponse>> GetBucketUsage(
        UsageGetBucketUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetBucketUsage(UsageGetBucketUsageParams, CancellationToken)"/>
    Task<HttpResponse<UsageGetBucketUsageResponse>> GetBucketUsage(
        string bucketName,
        UsageGetBucketUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}