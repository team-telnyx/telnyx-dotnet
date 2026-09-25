using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Integrations.Connections;

namespace Telnyx.Sdk.Services.AI.Integrations;

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
/// Returns the details of a single integration connection by its ID.
/// </summary>
    Task<ConnectionRetrieveResponse> Retrieve(
        ConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ConnectionRetrieveParams, CancellationToken)"/>
    Task<ConnectionRetrieveResponse> Retrieve(
        string userConnectionID,
        ConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the list of integration connections you have set up, linking your
/// account to third-party services.
/// </summary>
    Task<ConnectionListResponse> List(
        ConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete a specific integration connection.
/// </summary>
    Task Delete(
        ConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(ConnectionDeleteParams, CancellationToken)"/>
    Task Delete(
        string userConnectionID,
        ConnectionDeleteParams? parameters = null,
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
/// Returns a raw HTTP response for <c>get /ai/integrations/connections/{user_connection_id}</c>, but is otherwise the
/// same as <see cref="IConnectionService.Retrieve(ConnectionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConnectionRetrieveResponse>> Retrieve(
        ConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ConnectionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ConnectionRetrieveResponse>> Retrieve(
        string userConnectionID,
        ConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/integrations/connections</c>, but is otherwise the
/// same as <see cref="IConnectionService.List(ConnectionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConnectionListResponse>> List(
        ConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/integrations/connections/{user_connection_id}</c>, but is otherwise the
/// same as <see cref="IConnectionService.Delete(ConnectionDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        ConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(ConnectionDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string userConnectionID,
        ConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}