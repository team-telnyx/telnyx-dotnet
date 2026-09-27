using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Networks;
using Telnyx.Sdk.Services.Networks;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Network operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INetworkService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INetworkServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INetworkService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IDefaultGatewayService DefaultGateway { get; }

    /// <summary>
/// Creates a new private network, the container that links your WireGuard
/// interfaces, gateways, and cross connects.
/// </summary>
    Task<NetworkCreateResponse> Create(
        NetworkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single network by its identifier.
/// </summary>
    Task<NetworkRetrieveResponse> Retrieve(
        NetworkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NetworkRetrieveParams, CancellationToken)"/>
    Task<NetworkRetrieveResponse> Retrieve(
        string id,
        NetworkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified network's attributes and returns the updated network.
/// </summary>
    Task<NetworkUpdateResponse> Update(
        NetworkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(NetworkUpdateParams, CancellationToken)"/>
    Task<NetworkUpdateResponse> Update(
        string networkID,
        NetworkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of the private networks on your account, with support
/// for filtering.
/// </summary>
    Task<NetworkListPage> List(
        NetworkListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified network from your account.
/// </summary>
    Task<NetworkDeleteResponse> Delete(
        NetworkDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(NetworkDeleteParams, CancellationToken)"/>
    Task<NetworkDeleteResponse> Delete(
        string id,
        NetworkDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of the interfaces attached to the specified network,
/// with support for filtering.
/// </summary>
    Task<NetworkListInterfacesPage> ListInterfaces(
        NetworkListInterfacesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListInterfaces(NetworkListInterfacesParams, CancellationToken)"/>
    Task<NetworkListInterfacesPage> ListInterfaces(
        string id,
        NetworkListInterfacesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INetworkService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INetworkServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INetworkServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IDefaultGatewayServiceWithRawResponse DefaultGateway { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /networks</c>, but is otherwise the
/// same as <see cref="INetworkService.Create(NetworkCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NetworkCreateResponse>> Create(
        NetworkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /networks/{id}</c>, but is otherwise the
/// same as <see cref="INetworkService.Retrieve(NetworkRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NetworkRetrieveResponse>> Retrieve(
        NetworkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NetworkRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<NetworkRetrieveResponse>> Retrieve(
        string id,
        NetworkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /networks/{id}</c>, but is otherwise the
/// same as <see cref="INetworkService.Update(NetworkUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NetworkUpdateResponse>> Update(
        NetworkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(NetworkUpdateParams, CancellationToken)"/>
    Task<HttpResponse<NetworkUpdateResponse>> Update(
        string networkID,
        NetworkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /networks</c>, but is otherwise the
/// same as <see cref="INetworkService.List(NetworkListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NetworkListPage>> List(
        NetworkListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /networks/{id}</c>, but is otherwise the
/// same as <see cref="INetworkService.Delete(NetworkDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NetworkDeleteResponse>> Delete(
        NetworkDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(NetworkDeleteParams, CancellationToken)"/>
    Task<HttpResponse<NetworkDeleteResponse>> Delete(
        string id,
        NetworkDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /networks/{id}/network_interfaces</c>, but is otherwise the
/// same as <see cref="INetworkService.ListInterfaces(NetworkListInterfacesParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NetworkListInterfacesPage>> ListInterfaces(
        NetworkListInterfacesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListInterfaces(NetworkListInterfacesParams, CancellationToken)"/>
    Task<HttpResponse<NetworkListInterfacesPage>> ListInterfaces(
        string id,
        NetworkListInterfacesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}