using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage.Kvs;
using Telnyx.Sdk.Services.Storage.Kvs;

namespace Telnyx.Sdk.Services.Storage;

/// <summary>
/// Manage KV storage namespaces
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IKvService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IKvServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IKvService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IKeyService Keys { get; }

    /// <summary>
/// Creates a new KV namespace. Provisioning is asynchronous: the namespace is
/// returned with status `pending` and becomes usable once it reaches
/// `provision_ok`.
/// </summary>
    Task<KvNamespaceResponseWrapper> Create(
        KvCreateParams parameters, CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves a KV namespace by its ID, including its provisioning status.
/// </summary>
    Task<KvNamespaceResponseWrapper> Retrieve(
        KvRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(KvRetrieveParams, CancellationToken)"/>
    Task<KvNamespaceResponseWrapper> Retrieve(
        string id,
        KvRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists the KV namespaces for the authenticated user's organization. Results use
/// page-based pagination (`page[number]`/`page[size]`).
/// </summary>
    Task<KvListPage> List(
        KvListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes a KV namespace and all of the keys it contains. Deletion is
/// asynchronous: the namespace is returned with status `deleting`. Deleting a
/// namespace whose deletion is already in progress returns a `409`.
/// </summary>
    Task<KvNamespaceResponseWrapper> Delete(
        KvDeleteParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(KvDeleteParams, CancellationToken)"/>
    Task<KvNamespaceResponseWrapper> Delete(
        string id,
        KvDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IKvService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IKvServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IKvServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IKeyServiceWithRawResponse Keys { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /storage/kvs</c>, but is otherwise the
/// same as <see cref="IKvService.Create(KvCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<KvNamespaceResponseWrapper>> Create(
        KvCreateParams parameters, CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /storage/kvs/{id}</c>, but is otherwise the
/// same as <see cref="IKvService.Retrieve(KvRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<KvNamespaceResponseWrapper>> Retrieve(
        KvRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(KvRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<KvNamespaceResponseWrapper>> Retrieve(
        string id,
        KvRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /storage/kvs</c>, but is otherwise the
/// same as <see cref="IKvService.List(KvListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<KvListPage>> List(
        KvListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /storage/kvs/{id}</c>, but is otherwise the
/// same as <see cref="IKvService.Delete(KvDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<KvNamespaceResponseWrapper>> Delete(
        KvDeleteParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(KvDeleteParams, CancellationToken)"/>
    Task<HttpResponse<KvNamespaceResponseWrapper>> Delete(
        string id,
        KvDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}