using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.FqdnConnections;
using Telnyx.Sdk.Services.FqdnConnections;

namespace Telnyx.Sdk.Services;

/// <summary>
/// FQDN connection operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IFqdnConnectionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFqdnConnectionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFqdnConnectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IFqdnAuthenticationService FqdnAuthentication { get; }

    /// <summary>
/// Creates a new FQDN-based SIP connection. FQDN connections authenticate by your
/// registered domain names rather than static IP addresses.
/// </summary>
    Task<FqdnConnectionCreateResponse> Create(
        FqdnConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves the details of an existing FQDN connection.
/// </summary>
    Task<FqdnConnectionRetrieveResponse> Retrieve(
        FqdnConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(FqdnConnectionRetrieveParams, CancellationToken)"/>
    Task<FqdnConnectionRetrieveResponse> Retrieve(
        string id,
        FqdnConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates settings of an existing FQDN connection.
/// </summary>
    Task<FqdnConnectionUpdateResponse> Update(
        FqdnConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(FqdnConnectionUpdateParams, CancellationToken)"/>
    Task<FqdnConnectionUpdateResponse> Update(
        string id,
        FqdnConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of your FQDN connections.
/// </summary>
    Task<FqdnConnectionListPage> List(
        FqdnConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified FQDN connection from your account.
/// </summary>
    Task<FqdnConnectionDeleteResponse> Delete(
        FqdnConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(FqdnConnectionDeleteParams, CancellationToken)"/>
    Task<FqdnConnectionDeleteResponse> Delete(
        string id,
        FqdnConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IFqdnConnectionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFqdnConnectionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFqdnConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IFqdnAuthenticationServiceWithRawResponse FqdnAuthentication { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /fqdn_connections</c>, but is otherwise the
/// same as <see cref="IFqdnConnectionService.Create(FqdnConnectionCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FqdnConnectionCreateResponse>> Create(
        FqdnConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /fqdn_connections/{id}</c>, but is otherwise the
/// same as <see cref="IFqdnConnectionService.Retrieve(FqdnConnectionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FqdnConnectionRetrieveResponse>> Retrieve(
        FqdnConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(FqdnConnectionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<FqdnConnectionRetrieveResponse>> Retrieve(
        string id,
        FqdnConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /fqdn_connections/{id}</c>, but is otherwise the
/// same as <see cref="IFqdnConnectionService.Update(FqdnConnectionUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FqdnConnectionUpdateResponse>> Update(
        FqdnConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(FqdnConnectionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<FqdnConnectionUpdateResponse>> Update(
        string id,
        FqdnConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /fqdn_connections</c>, but is otherwise the
/// same as <see cref="IFqdnConnectionService.List(FqdnConnectionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FqdnConnectionListPage>> List(
        FqdnConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /fqdn_connections/{id}</c>, but is otherwise the
/// same as <see cref="IFqdnConnectionService.Delete(FqdnConnectionDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FqdnConnectionDeleteResponse>> Delete(
        FqdnConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(FqdnConnectionDeleteParams, CancellationToken)"/>
    Task<HttpResponse<FqdnConnectionDeleteResponse>> Delete(
        string id,
        FqdnConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}