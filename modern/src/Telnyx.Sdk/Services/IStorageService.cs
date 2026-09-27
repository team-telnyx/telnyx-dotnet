using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage;
using Telnyx.Sdk.Services.Storage;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Migrate data from an external provider into Telnyx Cloud Storage
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IStorageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IStorageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStorageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IBucketService Buckets { get; }

    IMigrationSourceService MigrationSources { get; }

    IMigrationService Migrations { get; }

    IKvService Kvs { get; }

    ICloudfService Cloudfs { get; }

    ISqldbService Sqldbs { get; }

    /// <summary>
/// List the external storage providers and regions supported as migration sources.
/// </summary>
    Task<StorageListMigrationSourceCoverageResponse> ListMigrationSourceCoverage(
        StorageListMigrationSourceCoverageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IStorageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IStorageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStorageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IBucketServiceWithRawResponse Buckets { get; }

    IMigrationSourceServiceWithRawResponse MigrationSources { get; }

    IMigrationServiceWithRawResponse Migrations { get; }

    IKvServiceWithRawResponse Kvs { get; }

    ICloudfServiceWithRawResponse Cloudfs { get; }

    ISqldbServiceWithRawResponse Sqldbs { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /storage/migration_source_coverage</c>, but is otherwise the
/// same as <see cref="IStorageService.ListMigrationSourceCoverage(StorageListMigrationSourceCoverageParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<StorageListMigrationSourceCoverageResponse>> ListMigrationSourceCoverage(
        StorageListMigrationSourceCoverageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}