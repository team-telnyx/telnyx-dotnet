using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.ExternalConnections.Releases;

namespace Telnyx.Sdk.Services.ExternalConnections;

/// <summary>
/// External Connections operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IReleaseService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IReleaseServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReleaseService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Return the details of a Release request and its phone numbers.
/// </summary>
    Task<ReleaseRetrieveResponse> Retrieve(
        ReleaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ReleaseRetrieveParams, CancellationToken)"/>
    Task<ReleaseRetrieveResponse> Retrieve(
        string releaseID,
        ReleaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of your Releases for the given external connection. These are
/// automatically created when you change the `connection_id` of a phone number that
/// is currently on Microsoft Teams.
/// </summary>
    Task<ReleaseListPage> List(
        ReleaseListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ReleaseListParams, CancellationToken)"/>
    Task<ReleaseListPage> List(
        string id,
        ReleaseListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IReleaseService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IReleaseServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReleaseServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /external_connections/{id}/releases/{release_id}</c>, but is otherwise the
/// same as <see cref="IReleaseService.Retrieve(ReleaseRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ReleaseRetrieveResponse>> Retrieve(
        ReleaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ReleaseRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ReleaseRetrieveResponse>> Retrieve(
        string releaseID,
        ReleaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /external_connections/{id}/releases</c>, but is otherwise the
/// same as <see cref="IReleaseService.List(ReleaseListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ReleaseListPage>> List(
        ReleaseListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ReleaseListParams, CancellationToken)"/>
    Task<HttpResponse<ReleaseListPage>> List(
        string id,
        ReleaseListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}