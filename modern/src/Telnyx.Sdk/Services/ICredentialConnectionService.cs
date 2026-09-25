using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.CredentialConnections;
using CredentialConnections = Telnyx.Sdk.Services.CredentialConnections;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Credential connection operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICredentialConnectionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICredentialConnectionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICredentialConnectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    CredentialConnections::IActionService Actions { get; }

    /// <summary>
/// Creates a new credential-based SIP connection. Credential connections
/// authenticate with a username and password rather than by IP address.
/// </summary>
    Task<CredentialConnectionCreateResponse> Create(
        CredentialConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves the details of an existing credential connection.
/// </summary>
    Task<CredentialConnectionRetrieveResponse> Retrieve(
        CredentialConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CredentialConnectionRetrieveParams, CancellationToken)"/>
    Task<CredentialConnectionRetrieveResponse> Retrieve(
        string id,
        CredentialConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates settings of an existing credential connection.
/// </summary>
    Task<CredentialConnectionUpdateResponse> Update(
        CredentialConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CredentialConnectionUpdateParams, CancellationToken)"/>
    Task<CredentialConnectionUpdateResponse> Update(
        string id,
        CredentialConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of your credential connections.
/// </summary>
    Task<CredentialConnectionListPage> List(
        CredentialConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes an existing credential connection.
/// </summary>
    Task<CredentialConnectionDeleteResponse> Delete(
        CredentialConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(CredentialConnectionDeleteParams, CancellationToken)"/>
    Task<CredentialConnectionDeleteResponse> Delete(
        string id,
        CredentialConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICredentialConnectionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICredentialConnectionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICredentialConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    CredentialConnections::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /credential_connections</c>, but is otherwise the
/// same as <see cref="ICredentialConnectionService.Create(CredentialConnectionCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CredentialConnectionCreateResponse>> Create(
        CredentialConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /credential_connections/{id}</c>, but is otherwise the
/// same as <see cref="ICredentialConnectionService.Retrieve(CredentialConnectionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CredentialConnectionRetrieveResponse>> Retrieve(
        CredentialConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CredentialConnectionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CredentialConnectionRetrieveResponse>> Retrieve(
        string id,
        CredentialConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /credential_connections/{id}</c>, but is otherwise the
/// same as <see cref="ICredentialConnectionService.Update(CredentialConnectionUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CredentialConnectionUpdateResponse>> Update(
        CredentialConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CredentialConnectionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CredentialConnectionUpdateResponse>> Update(
        string id,
        CredentialConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /credential_connections</c>, but is otherwise the
/// same as <see cref="ICredentialConnectionService.List(CredentialConnectionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CredentialConnectionListPage>> List(
        CredentialConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /credential_connections/{id}</c>, but is otherwise the
/// same as <see cref="ICredentialConnectionService.Delete(CredentialConnectionDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CredentialConnectionDeleteResponse>> Delete(
        CredentialConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(CredentialConnectionDeleteParams, CancellationToken)"/>
    Task<HttpResponse<CredentialConnectionDeleteResponse>> Delete(
        string id,
        CredentialConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}