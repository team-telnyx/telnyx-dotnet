using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles.Memories;

namespace Telnyx.Sdk.Services.AI.Memory.Namespaces.Profiles;

/// <summary>
/// What a namespace and a profile hold.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMemoryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMemoryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMemoryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// One memory by its id, as `recall` and the listing return it, together with what
/// it came from. A fact names its `source_id`: read it with `GET
/// .../sources/{source_id}` to see what was stored. A memory derived from other
/// memories names them in `derived_from` instead; read each of those to reach its
/// source.
/// </summary>
    Task<MemoryRetrieveResponse> Retrieve(
        MemoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MemoryRetrieveParams, CancellationToken)"/>
    Task<MemoryRetrieveResponse> Retrieve(
        string memoryID,
        MemoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Everything stored under one profile, unranked -- ask `recall` for the memories
/// that answer a question. A profile that holds nothing is an empty page rather
/// than a 404: profiles exist by being written to. Each memory names the
/// `source_id` it was extracted from, or null for a memory derived from other
/// memories -- which can read almost the same as the fact it restates. A
/// `source_id` narrows the listing to the memories extracted from that source, and
/// a `session_id` to those extracted from the session, which is the same thing
/// named another way; pass one or the other. Neither is everything the source led
/// to: a memory derived from several sources belongs to no single one and appears
/// only in the unfiltered listing. A memory written while the listing is paged
/// shifts the pages after it, so an entry can be repeated or missed at a page
/// boundary.
/// </summary>
    Task<MemoryListPage> List(
        MemoryListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(MemoryListParams, CancellationToken)"/>
    Task<MemoryListPage> List(
        string profileID,
        MemoryListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMemoryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMemoryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMemoryServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/memory/namespaces/{namespace}/profiles/{profile_id}/memories/{memory_id}</c>, but is otherwise the
/// same as <see cref="IMemoryService.Retrieve(MemoryRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MemoryRetrieveResponse>> Retrieve(
        MemoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MemoryRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MemoryRetrieveResponse>> Retrieve(
        string memoryID,
        MemoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/memory/namespaces/{namespace}/profiles/{profile_id}/memories</c>, but is otherwise the
/// same as <see cref="IMemoryService.List(MemoryListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MemoryListPage>> List(
        MemoryListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(MemoryListParams, CancellationToken)"/>
    Task<HttpResponse<MemoryListPage>> List(
        string profileID,
        MemoryListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}