using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.WireguardInterfaces;

namespace Telnyx.Sdk.Services;

/// <summary>
/// WireGuard Interface operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWireguardInterfaceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWireguardInterfaceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWireguardInterfaceService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a new WireGuard Interface. Current limitation of 10 interfaces per user
/// can be created.
/// </summary>
    Task<WireguardInterfaceCreateResponse> Create(
        WireguardInterfaceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single WireGuard interface by its identifier.
/// </summary>
    Task<WireguardInterfaceRetrieveResponse> Retrieve(
        WireguardInterfaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(WireguardInterfaceRetrieveParams, CancellationToken)"/>
    Task<WireguardInterfaceRetrieveResponse> Retrieve(
        string id,
        WireguardInterfaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of the WireGuard interfaces on your account, with
/// support for filtering.
/// </summary>
    Task<WireguardInterfaceListPage> List(
        WireguardInterfaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified WireGuard interface from its network.
/// </summary>
    Task<WireguardInterfaceDeleteResponse> Delete(
        WireguardInterfaceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(WireguardInterfaceDeleteParams, CancellationToken)"/>
    Task<WireguardInterfaceDeleteResponse> Delete(
        string id,
        WireguardInterfaceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IWireguardInterfaceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWireguardInterfaceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWireguardInterfaceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /wireguard_interfaces</c>, but is otherwise the
/// same as <see cref="IWireguardInterfaceService.Create(WireguardInterfaceCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WireguardInterfaceCreateResponse>> Create(
        WireguardInterfaceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /wireguard_interfaces/{id}</c>, but is otherwise the
/// same as <see cref="IWireguardInterfaceService.Retrieve(WireguardInterfaceRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WireguardInterfaceRetrieveResponse>> Retrieve(
        WireguardInterfaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(WireguardInterfaceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<WireguardInterfaceRetrieveResponse>> Retrieve(
        string id,
        WireguardInterfaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /wireguard_interfaces</c>, but is otherwise the
/// same as <see cref="IWireguardInterfaceService.List(WireguardInterfaceListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WireguardInterfaceListPage>> List(
        WireguardInterfaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /wireguard_interfaces/{id}</c>, but is otherwise the
/// same as <see cref="IWireguardInterfaceService.Delete(WireguardInterfaceDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WireguardInterfaceDeleteResponse>> Delete(
        WireguardInterfaceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(WireguardInterfaceDeleteParams, CancellationToken)"/>
    Task<HttpResponse<WireguardInterfaceDeleteResponse>> Delete(
        string id,
        WireguardInterfaceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}