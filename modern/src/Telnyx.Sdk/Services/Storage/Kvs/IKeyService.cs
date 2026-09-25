using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage.Kvs.Keys;

namespace Telnyx.Sdk.Services.Storage.Kvs;

/// <summary>
/// Read and write keys within a KV namespace
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IKeyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IKeyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the raw stored value for a key. The response body is the value exactly
/// as it was written; the `Content-Type` header echoes the value's stored content
/// type (defaults to `application/octet-stream`).
/// 
/// <para>It's the caller's responsibility to dispose the returned response.</para>
/// </summary>
    Task<HttpResponse> Retrieve(
        KeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(KeyRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string key,
        KeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Creates or replaces the value for a key. The request body is stored verbatim as
/// the value — no base64, no JSON envelope — up to 1 MiB. The request's
/// `Content-Type` header is stored with the value and echoed back on retrieval.
/// Returns `201` when the key is created and `200` when an existing key is updated.
/// </summary>
    Task Update(
        KeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(KeyUpdateParams, CancellationToken)"/>
    Task Update(
        string key,
        BinaryContent body,
        KeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists the keys in a namespace. Returns key names and metadata only, never
/// values. Results are paginated with `limit` and an opaque `cursor`.
/// </summary>
    Task<KeyListPage> List(
        KeyListParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(KeyListParams, CancellationToken)"/>
    Task<KeyListPage> List(
        string id,
        KeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes a key. Idempotent: deleting a key that does not exist still succeeds.
/// The namespace itself must exist and be provisioned.
/// </summary>
    Task Delete(
        KeyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(KeyDeleteParams, CancellationToken)"/>
    Task Delete(
        string key,
        KeyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IKeyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IKeyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IKeyServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /storage/kvs/{id}/keys/{key}</c>, but is otherwise the
/// same as <see cref="IKeyService.Retrieve(KeyRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Retrieve(
        KeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(KeyRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string key,
        KeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /storage/kvs/{id}/keys/{key}</c>, but is otherwise the
/// same as <see cref="IKeyService.Update(KeyUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Update(
        KeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(KeyUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string key,
        BinaryContent body,
        KeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /storage/kvs/{id}/keys</c>, but is otherwise the
/// same as <see cref="IKeyService.List(KeyListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<KeyListPage>> List(
        KeyListParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(KeyListParams, CancellationToken)"/>
    Task<HttpResponse<KeyListPage>> List(
        string id,
        KeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /storage/kvs/{id}/keys/{key}</c>, but is otherwise the
/// same as <see cref="IKeyService.Delete(KeyDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        KeyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(KeyDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string key,
        KeyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}