using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PrivateWirelessGateways;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Private Wireless Gateways operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPrivateWirelessGatewayService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPrivateWirelessGatewayServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPrivateWirelessGatewayService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Asynchronously create a Private Wireless Gateway for SIM cards for a previously
/// created network. This operation may take several minutes so you can check the
/// Private Wireless Gateway status at the section Get a Private Wireless Gateway.
/// </summary>
    Task<PrivateWirelessGatewayCreateResponse> Create(
        PrivateWirelessGatewayCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve information about a Private Wireless Gateway.
/// </summary>
    Task<PrivateWirelessGatewayRetrieveResponse> Retrieve(
        PrivateWirelessGatewayRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PrivateWirelessGatewayRetrieveParams, CancellationToken)"/>
    Task<PrivateWirelessGatewayRetrieveResponse> Retrieve(
        string id,
        PrivateWirelessGatewayRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get all Private Wireless Gateways belonging to the user.
/// </summary>
    Task<PrivateWirelessGatewayListPage> List(
        PrivateWirelessGatewayListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified Private Wireless Gateway from your account.
/// </summary>
    Task<PrivateWirelessGatewayDeleteResponse> Delete(
        PrivateWirelessGatewayDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PrivateWirelessGatewayDeleteParams, CancellationToken)"/>
    Task<PrivateWirelessGatewayDeleteResponse> Delete(
        string id,
        PrivateWirelessGatewayDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPrivateWirelessGatewayService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPrivateWirelessGatewayServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPrivateWirelessGatewayServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /private_wireless_gateways</c>, but is otherwise the
/// same as <see cref="IPrivateWirelessGatewayService.Create(PrivateWirelessGatewayCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PrivateWirelessGatewayCreateResponse>> Create(
        PrivateWirelessGatewayCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /private_wireless_gateways/{id}</c>, but is otherwise the
/// same as <see cref="IPrivateWirelessGatewayService.Retrieve(PrivateWirelessGatewayRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PrivateWirelessGatewayRetrieveResponse>> Retrieve(
        PrivateWirelessGatewayRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PrivateWirelessGatewayRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PrivateWirelessGatewayRetrieveResponse>> Retrieve(
        string id,
        PrivateWirelessGatewayRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /private_wireless_gateways</c>, but is otherwise the
/// same as <see cref="IPrivateWirelessGatewayService.List(PrivateWirelessGatewayListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PrivateWirelessGatewayListPage>> List(
        PrivateWirelessGatewayListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /private_wireless_gateways/{id}</c>, but is otherwise the
/// same as <see cref="IPrivateWirelessGatewayService.Delete(PrivateWirelessGatewayDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PrivateWirelessGatewayDeleteResponse>> Delete(
        PrivateWirelessGatewayDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PrivateWirelessGatewayDeleteParams, CancellationToken)"/>
    Task<HttpResponse<PrivateWirelessGatewayDeleteResponse>> Delete(
        string id,
        PrivateWirelessGatewayDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}