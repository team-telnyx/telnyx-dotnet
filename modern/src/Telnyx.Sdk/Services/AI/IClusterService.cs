using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Clusters;

namespace Telnyx.Sdk.Services.AI;

/// <summary>
/// Identify common themes and patterns in your embedded documents
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IClusterService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IClusterServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IClusterService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Fetch the results of a clustering task, including the discovered clusters.
/// </summary>
    Task<ClusterRetrieveResponse> Retrieve(
        ClusterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ClusterRetrieveParams, CancellationToken)"/>
    Task<ClusterRetrieveResponse> Retrieve(
        string taskID,
        ClusterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a paginated list of clustering tasks and their statuses.
/// </summary>
    Task<ClusterListPage> List(
        ClusterListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete a clustering task and its computed results.
/// </summary>
    Task Delete(
        ClusterDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(ClusterDeleteParams, CancellationToken)"/>
    Task Delete(
        string taskID,
        ClusterDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Starts a background task to compute how the data in an [embedded storage
/// bucket](https://developers.telnyx.com/api-reference/embeddings/embed-documents)
/// is clustered. This helps identify common themes and patterns in the data.
/// </summary>
    Task<ClusterComputeResponse> Compute(
        ClusterComputeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Fetch a visualization image of the clusters computed by a clustering task.
/// 
/// <para>It's the caller's responsibility to dispose the returned response.</para>
/// </summary>
    Task<HttpResponse> FetchGraph(
        ClusterFetchGraphParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="FetchGraph(ClusterFetchGraphParams, CancellationToken)"/>
    Task<HttpResponse> FetchGraph(
        string taskID,
        ClusterFetchGraphParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IClusterService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IClusterServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IClusterServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/clusters/{task_id}</c>, but is otherwise the
/// same as <see cref="IClusterService.Retrieve(ClusterRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ClusterRetrieveResponse>> Retrieve(
        ClusterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ClusterRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ClusterRetrieveResponse>> Retrieve(
        string taskID,
        ClusterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/clusters</c>, but is otherwise the
/// same as <see cref="IClusterService.List(ClusterListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ClusterListPage>> List(
        ClusterListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/clusters/{task_id}</c>, but is otherwise the
/// same as <see cref="IClusterService.Delete(ClusterDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        ClusterDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(ClusterDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string taskID,
        ClusterDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/clusters</c>, but is otherwise the
/// same as <see cref="IClusterService.Compute(ClusterComputeParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ClusterComputeResponse>> Compute(
        ClusterComputeParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/clusters/{task_id}/graph</c>, but is otherwise the
/// same as <see cref="IClusterService.FetchGraph(ClusterFetchGraphParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> FetchGraph(
        ClusterFetchGraphParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="FetchGraph(ClusterFetchGraphParams, CancellationToken)"/>
    Task<HttpResponse> FetchGraph(
        string taskID,
        ClusterFetchGraphParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}