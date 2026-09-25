using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.WireguardPeers;

namespace Telnyx.Sdk.Services;

/// <summary>
/// WireGuard Interface operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWireguardPeerService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWireguardPeerServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWireguardPeerService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a new WireGuard Peer. Current limitation of 5 peers per interface can be
/// created.
/// </summary>
    Task<WireguardPeerCreateResponse> Create(
        WireguardPeerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single WireGuard peer by its identifier.
/// </summary>
    Task<WireguardPeerRetrieveResponse> Retrieve(
        WireguardPeerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(WireguardPeerRetrieveParams, CancellationToken)"/>
    Task<WireguardPeerRetrieveResponse> Retrieve(
        string id,
        WireguardPeerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified WireGuard peer and returns the updated peer.
/// </summary>
    Task<WireguardPeerUpdateResponse> Update(
        WireguardPeerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(WireguardPeerUpdateParams, CancellationToken)"/>
    Task<WireguardPeerUpdateResponse> Update(
        string id,
        WireguardPeerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of your WireGuard peers, with support for filtering.
/// </summary>
    Task<WireguardPeerListPage> List(
        WireguardPeerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified WireGuard peer from its interface.
/// </summary>
    Task<WireguardPeerDeleteResponse> Delete(
        WireguardPeerDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(WireguardPeerDeleteParams, CancellationToken)"/>
    Task<WireguardPeerDeleteResponse> Delete(
        string id,
        WireguardPeerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve Wireguard config template for Peer
/// </summary>
    Task<string> RetrieveConfig(
        WireguardPeerRetrieveConfigParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveConfig(WireguardPeerRetrieveConfigParams, CancellationToken)"/>
    Task<string> RetrieveConfig(
        string id,
        WireguardPeerRetrieveConfigParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IWireguardPeerService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWireguardPeerServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWireguardPeerServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /wireguard_peers</c>, but is otherwise the
/// same as <see cref="IWireguardPeerService.Create(WireguardPeerCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WireguardPeerCreateResponse>> Create(
        WireguardPeerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /wireguard_peers/{id}</c>, but is otherwise the
/// same as <see cref="IWireguardPeerService.Retrieve(WireguardPeerRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WireguardPeerRetrieveResponse>> Retrieve(
        WireguardPeerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(WireguardPeerRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<WireguardPeerRetrieveResponse>> Retrieve(
        string id,
        WireguardPeerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /wireguard_peers/{id}</c>, but is otherwise the
/// same as <see cref="IWireguardPeerService.Update(WireguardPeerUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WireguardPeerUpdateResponse>> Update(
        WireguardPeerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(WireguardPeerUpdateParams, CancellationToken)"/>
    Task<HttpResponse<WireguardPeerUpdateResponse>> Update(
        string id,
        WireguardPeerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /wireguard_peers</c>, but is otherwise the
/// same as <see cref="IWireguardPeerService.List(WireguardPeerListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WireguardPeerListPage>> List(
        WireguardPeerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /wireguard_peers/{id}</c>, but is otherwise the
/// same as <see cref="IWireguardPeerService.Delete(WireguardPeerDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WireguardPeerDeleteResponse>> Delete(
        WireguardPeerDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(WireguardPeerDeleteParams, CancellationToken)"/>
    Task<HttpResponse<WireguardPeerDeleteResponse>> Delete(
        string id,
        WireguardPeerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /wireguard_peers/{id}/config</c>, but is otherwise the
/// same as <see cref="IWireguardPeerService.RetrieveConfig(WireguardPeerRetrieveConfigParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<string>> RetrieveConfig(
        WireguardPeerRetrieveConfigParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveConfig(WireguardPeerRetrieveConfigParams, CancellationToken)"/>
    Task<HttpResponse<string>> RetrieveConfig(
        string id,
        WireguardPeerRetrieveConfigParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}