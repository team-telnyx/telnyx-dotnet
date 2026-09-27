using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage.Migrations;
using Migrations = Telnyx.Sdk.Services.Storage.Migrations;

namespace Telnyx.Sdk.Services.Storage;

/// <summary>
/// Migrate data from an external provider into Telnyx Cloud Storage
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMigrationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMigrationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMigrationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Migrations::IActionService Actions { get; }

    /// <summary>
/// Initiate a migration of data from an external provider into Telnyx Cloud
/// Storage. Currently, only S3 is supported.
/// </summary>
    Task<MigrationCreateResponse> Create(
        MigrationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve the details and status of a specific storage migration.
/// </summary>
    Task<MigrationRetrieveResponse> Retrieve(
        MigrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MigrationRetrieveParams, CancellationToken)"/>
    Task<MigrationRetrieveResponse> Retrieve(
        string id,
        MigrationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a list of the storage migrations on your account.
/// </summary>
    Task<MigrationListResponse> List(
        MigrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMigrationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMigrationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMigrationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Migrations::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /storage/migrations</c>, but is otherwise the
/// same as <see cref="IMigrationService.Create(MigrationCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MigrationCreateResponse>> Create(
        MigrationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /storage/migrations/{id}</c>, but is otherwise the
/// same as <see cref="IMigrationService.Retrieve(MigrationRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MigrationRetrieveResponse>> Retrieve(
        MigrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MigrationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MigrationRetrieveResponse>> Retrieve(
        string id,
        MigrationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /storage/migrations</c>, but is otherwise the
/// same as <see cref="IMigrationService.List(MigrationListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MigrationListResponse>> List(
        MigrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}