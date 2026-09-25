using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage.Sqldbs;
using Sqldbs = Telnyx.Sdk.Services.Storage.Sqldbs;

namespace Telnyx.Sdk.Services.Storage;

/// <summary>
/// Manage SQL databases and run SQL against them
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISqldbService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISqldbServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISqldbService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Sqldbs::IActionService Actions { get; }

    /// <summary>
/// Creates a new SQL database. Provisioning is asynchronous: the database is
/// returned with status `pending` and becomes usable once it reaches
/// `provision_ok`.
/// </summary>
    Task<SqlDatabaseResponseWrapper> Create(
        SqldbCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves a SQL database by its ID, including its provisioning status.
/// </summary>
    Task<SqlDatabaseResponseWrapper> Retrieve(
        SqldbRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SqldbRetrieveParams, CancellationToken)"/>
    Task<SqlDatabaseResponseWrapper> Retrieve(
        string id,
        SqldbRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists the SQL databases for the authenticated user's organization. Results use
/// page-based pagination (`page[number]`/`page[size]`) and can be filtered and
/// sorted.
/// </summary>
    Task<SqldbListPage> List(
        SqldbListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes a SQL database and all of the data it holds. Deletion is asynchronous
/// and returns `202` with an empty body — the record is not removed synchronously.
/// Poll `GET /storage/sqldbs/{id}`, which returns `404` once the database has been
/// purged; there is no durable `deleted` state. A database still bound by a
/// function is refused with `409` unless `force=true`.
/// </summary>
    Task Delete(
        SqldbDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SqldbDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        SqldbDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISqldbService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISqldbServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISqldbServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Sqldbs::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /storage/sqldbs</c>, but is otherwise the
/// same as <see cref="ISqldbService.Create(SqldbCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SqlDatabaseResponseWrapper>> Create(
        SqldbCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /storage/sqldbs/{id}</c>, but is otherwise the
/// same as <see cref="ISqldbService.Retrieve(SqldbRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SqlDatabaseResponseWrapper>> Retrieve(
        SqldbRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SqldbRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SqlDatabaseResponseWrapper>> Retrieve(
        string id,
        SqldbRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /storage/sqldbs</c>, but is otherwise the
/// same as <see cref="ISqldbService.List(SqldbListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SqldbListPage>> List(
        SqldbListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /storage/sqldbs/{id}</c>, but is otherwise the
/// same as <see cref="ISqldbService.Delete(SqldbDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        SqldbDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SqldbDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        SqldbDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}