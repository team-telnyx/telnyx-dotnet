using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Connections;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IConnectionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IConnectionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConnectionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Retrieves the high-level details of an existing connection. To retrieve specific
/// authentication information, use the endpoint for the specific connection type.
/// </summary>
    Task<ConnectionRetrieveResponse> Retrieve(
        ConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ConnectionRetrieveParams, CancellationToken)"/>
    Task<ConnectionRetrieveResponse> Retrieve(
        string id,
        ConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of your connections irrespective of type.
/// </summary>
    Task<ConnectionListPage> List(
        ConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists all active calls for given connection. Acceptable connections are either
/// SIP connections with webhook_url or xml_request_url, call control or texml.
/// Returned results are cursor paginated.
/// </summary>
    Task<ConnectionListActiveCallsPage> ListActiveCalls(
        ConnectionListActiveCallsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListActiveCalls(ConnectionListActiveCallsParams, CancellationToken)"/>
    Task<ConnectionListActiveCallsPage> ListActiveCalls(
        string connectionID,
        ConnectionListActiveCallsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the number of connections associated with the authenticated user,
/// grouped by connection type, together with the connection limits that apply to
/// the user. Forward-only connections are excluded from the counts.
/// </summary>
    Task<ConnectionRetrieveCountResponse> RetrieveCount(
        ConnectionRetrieveCountParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IConnectionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IConnectionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /connections/{id}</c>, but is otherwise the
/// same as <see cref="IConnectionService.Retrieve(ConnectionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConnectionRetrieveResponse>> Retrieve(
        ConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ConnectionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ConnectionRetrieveResponse>> Retrieve(
        string id,
        ConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /connections</c>, but is otherwise the
/// same as <see cref="IConnectionService.List(ConnectionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConnectionListPage>> List(
        ConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /connections/{connection_id}/active_calls</c>, but is otherwise the
/// same as <see cref="IConnectionService.ListActiveCalls(ConnectionListActiveCallsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConnectionListActiveCallsPage>> ListActiveCalls(
        ConnectionListActiveCallsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListActiveCalls(ConnectionListActiveCallsParams, CancellationToken)"/>
    Task<HttpResponse<ConnectionListActiveCallsPage>> ListActiveCalls(
        string connectionID,
        ConnectionListActiveCallsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /connections/count</c>, but is otherwise the
/// same as <see cref="IConnectionService.RetrieveCount(ConnectionRetrieveCountParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConnectionRetrieveCountResponse>> RetrieveCount(
        ConnectionRetrieveCountParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}