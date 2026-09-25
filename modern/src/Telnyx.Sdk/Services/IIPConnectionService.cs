using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.IPConnections;

namespace Telnyx.Sdk.Services;

/// <summary>
/// IP connection operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IIPConnectionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIPConnectionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIPConnectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a new IP-based SIP connection, which authenticates traffic by source IP
/// address.
/// </summary>
    Task<IPConnectionCreateResponse> Create(
        IPConnectionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves the details of an existing ip connection.
/// </summary>
    Task<IPConnectionRetrieveResponse> Retrieve(
        IPConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(IPConnectionRetrieveParams, CancellationToken)"/>
    Task<IPConnectionRetrieveResponse> Retrieve(
        string id,
        IPConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates settings of an existing IP connection.
/// </summary>
    Task<IPConnectionUpdateResponse> Update(
        IPConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(IPConnectionUpdateParams, CancellationToken)"/>
    Task<IPConnectionUpdateResponse> Update(
        string id,
        IPConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of your IP-based SIP connections, with support for
/// filtering and sorting.
/// </summary>
    Task<IPConnectionListPage> List(
        IPConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified IP connection from your account.
/// </summary>
    Task<IPConnectionDeleteResponse> Delete(
        IPConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(IPConnectionDeleteParams, CancellationToken)"/>
    Task<IPConnectionDeleteResponse> Delete(
        string id,
        IPConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IIPConnectionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IIPConnectionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIPConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ip_connections</c>, but is otherwise the
/// same as <see cref="IIPConnectionService.Create(IPConnectionCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<IPConnectionCreateResponse>> Create(
        IPConnectionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ip_connections/{id}</c>, but is otherwise the
/// same as <see cref="IIPConnectionService.Retrieve(IPConnectionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<IPConnectionRetrieveResponse>> Retrieve(
        IPConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(IPConnectionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<IPConnectionRetrieveResponse>> Retrieve(
        string id,
        IPConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /ip_connections/{id}</c>, but is otherwise the
/// same as <see cref="IIPConnectionService.Update(IPConnectionUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<IPConnectionUpdateResponse>> Update(
        IPConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(IPConnectionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<IPConnectionUpdateResponse>> Update(
        string id,
        IPConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ip_connections</c>, but is otherwise the
/// same as <see cref="IIPConnectionService.List(IPConnectionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<IPConnectionListPage>> List(
        IPConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ip_connections/{id}</c>, but is otherwise the
/// same as <see cref="IIPConnectionService.Delete(IPConnectionDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<IPConnectionDeleteResponse>> Delete(
        IPConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(IPConnectionDeleteParams, CancellationToken)"/>
    Task<HttpResponse<IPConnectionDeleteResponse>> Delete(
        string id,
        IPConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}