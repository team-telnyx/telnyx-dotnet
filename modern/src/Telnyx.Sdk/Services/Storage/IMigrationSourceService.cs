using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage.MigrationSources;

namespace Telnyx.Sdk.Services.Storage;

/// <summary>
/// Migrate data from an external provider into Telnyx Cloud Storage
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMigrationSourceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMigrationSourceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMigrationSourceService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a source from which data can be migrated from.
/// </summary>
    Task<MigrationSourceCreateResponse> Create(
        MigrationSourceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve the details of a specific migration source.
/// </summary>
    Task<MigrationSourceRetrieveResponse> Retrieve(
        MigrationSourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MigrationSourceRetrieveParams, CancellationToken)"/>
    Task<MigrationSourceRetrieveResponse> Retrieve(
        string id,
        MigrationSourceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List the migration sources configured on your account. A migration source is an
/// external storage bucket from which data can be migrated into Telnyx Cloud
/// Storage.
/// </summary>
    Task<MigrationSourceListResponse> List(
        MigrationSourceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete a migration source configuration.
/// </summary>
    Task<MigrationSourceDeleteResponse> Delete(
        MigrationSourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MigrationSourceDeleteParams, CancellationToken)"/>
    Task<MigrationSourceDeleteResponse> Delete(
        string id,
        MigrationSourceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMigrationSourceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMigrationSourceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMigrationSourceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /storage/migration_sources</c>, but is otherwise the
/// same as <see cref="IMigrationSourceService.Create(MigrationSourceCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MigrationSourceCreateResponse>> Create(
        MigrationSourceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /storage/migration_sources/{id}</c>, but is otherwise the
/// same as <see cref="IMigrationSourceService.Retrieve(MigrationSourceRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MigrationSourceRetrieveResponse>> Retrieve(
        MigrationSourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MigrationSourceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MigrationSourceRetrieveResponse>> Retrieve(
        string id,
        MigrationSourceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /storage/migration_sources</c>, but is otherwise the
/// same as <see cref="IMigrationSourceService.List(MigrationSourceListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MigrationSourceListResponse>> List(
        MigrationSourceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /storage/migration_sources/{id}</c>, but is otherwise the
/// same as <see cref="IMigrationSourceService.Delete(MigrationSourceDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MigrationSourceDeleteResponse>> Delete(
        MigrationSourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MigrationSourceDeleteParams, CancellationToken)"/>
    Task<HttpResponse<MigrationSourceDeleteResponse>> Delete(
        string id,
        MigrationSourceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}