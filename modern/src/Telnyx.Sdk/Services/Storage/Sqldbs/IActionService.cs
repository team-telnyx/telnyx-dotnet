using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage.Sqldbs.Actions;

namespace Telnyx.Sdk.Services.Storage.Sqldbs;

/// <summary>
/// Manage SQL databases and run SQL against them
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IActionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IActionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Runs SQL against the database and returns the resulting rows — empty for
/// statements that return none, such as DDL. Bind positional `?` placeholders with
/// `params` rather than interpolating values into the SQL string.
/// </summary>
    Task<ActionQueryResponse> Query(
        ActionQueryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Query(ActionQueryParams, CancellationToken)"/>
    Task<ActionQueryResponse> Query(
        string id,
        ActionQueryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IActionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IActionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /storage/sqldbs/{id}/actions/query</c>, but is otherwise the
/// same as <see cref="IActionService.Query(ActionQueryParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionQueryResponse>> Query(
        ActionQueryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Query(ActionQueryParams, CancellationToken)"/>
    Task<HttpResponse<ActionQueryResponse>> Query(
        string id,
        ActionQueryParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}