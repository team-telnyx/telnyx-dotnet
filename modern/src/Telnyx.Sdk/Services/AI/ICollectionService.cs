using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Collections;
using Telnyx.Sdk.Services.AI.Collections;

namespace Telnyx.Sdk.Services.AI;

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

    ISettingService Settings { get; }

    ISourceService Sources { get; }

    /// <summary>
/// Creates a new collection scoped to your organization. Optionally attach sources
/// and retrieval settings at creation time. If `slug` is omitted, one is derived
/// from `name` and must be unique within your organization.
/// </summary>
    Task<CollectionEnvelope> Create(
        CollectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Fetches a single collection by its `slug`.
/// </summary>
    Task<CollectionEnvelope> Retrieve(
        CollectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CollectionRetrieveParams, CancellationToken)"/>
    Task<CollectionEnvelope> Retrieve(
        string slug,
        CollectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates a collection's metadata (`name` and/or `description`). Sources and
/// settings are managed through their own sub-resources.
/// </summary>
    Task<CollectionEnvelope> Update(
        CollectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CollectionUpdateParams, CancellationToken)"/>
    Task<CollectionEnvelope> Update(
        string uuid,
        CollectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of collections in your organization.
/// </summary>
    Task<CollectionListPage> List(
        CollectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Soft-deletes a collection. Its `slug` is freed and may be reused by a new
/// collection.
/// </summary>
    Task Delete(
        CollectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(CollectionDeleteParams, CancellationToken)"/>
    Task Delete(
        string uuid,
        CollectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Fetches a single collection by its `uuid`.
/// </summary>
    Task<CollectionEnvelope> RetrieveByID(
        CollectionRetrieveByIDParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveByID(CollectionRetrieveByIDParams, CancellationToken)"/>
    Task<CollectionEnvelope> RetrieveByID(
        string uuid,
        CollectionRetrieveByIDParams? parameters = null,
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

    ISettingServiceWithRawResponse Settings { get; }

    ISourceServiceWithRawResponse Sources { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/collections</c>, but is otherwise the
/// same as <see cref="ICollectionService.Create(CollectionCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CollectionEnvelope>> Create(
        CollectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/collections/slug/{slug}</c>, but is otherwise the
/// same as <see cref="ICollectionService.Retrieve(CollectionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CollectionEnvelope>> Retrieve(
        CollectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CollectionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CollectionEnvelope>> Retrieve(
        string slug,
        CollectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /ai/collections/{uuid}</c>, but is otherwise the
/// same as <see cref="ICollectionService.Update(CollectionUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CollectionEnvelope>> Update(
        CollectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CollectionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CollectionEnvelope>> Update(
        string uuid,
        CollectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/collections</c>, but is otherwise the
/// same as <see cref="ICollectionService.List(CollectionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CollectionListPage>> List(
        CollectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/collections/{uuid}</c>, but is otherwise the
/// same as <see cref="ICollectionService.Delete(CollectionDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        CollectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(CollectionDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string uuid,
        CollectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/collections/{uuid}</c>, but is otherwise the
/// same as <see cref="ICollectionService.RetrieveByID(CollectionRetrieveByIDParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CollectionEnvelope>> RetrieveByID(
        CollectionRetrieveByIDParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveByID(CollectionRetrieveByIDParams, CancellationToken)"/>
    Task<HttpResponse<CollectionEnvelope>> RetrieveByID(
        string uuid,
        CollectionRetrieveByIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}