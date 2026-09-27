using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Networks.DefaultGateway;

namespace Telnyx.Sdk.Services.Networks;

/// <summary>
/// Network operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDefaultGatewayService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDefaultGatewayServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDefaultGatewayService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a default gateway on the specified network, directing the network's
/// outbound traffic through the chosen gateway.
/// </summary>
    Task<DefaultGatewayCreateResponse> Create(
        DefaultGatewayCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(DefaultGatewayCreateParams, CancellationToken)"/>
    Task<DefaultGatewayCreateResponse> Create(
        string networkIdentifier,
        DefaultGatewayCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the status of the default gateway configured on the specified network.
/// </summary>
    Task<DefaultGatewayRetrieveResponse> Retrieve(
        DefaultGatewayRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(DefaultGatewayRetrieveParams, CancellationToken)"/>
    Task<DefaultGatewayRetrieveResponse> Retrieve(
        string id,
        DefaultGatewayRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes the default gateway from the specified network.
/// </summary>
    Task<DefaultGatewayDeleteResponse> Delete(
        DefaultGatewayDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(DefaultGatewayDeleteParams, CancellationToken)"/>
    Task<DefaultGatewayDeleteResponse> Delete(
        string id,
        DefaultGatewayDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IDefaultGatewayService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDefaultGatewayServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDefaultGatewayServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /networks/{id}/default_gateway</c>, but is otherwise the
/// same as <see cref="IDefaultGatewayService.Create(DefaultGatewayCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DefaultGatewayCreateResponse>> Create(
        DefaultGatewayCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(DefaultGatewayCreateParams, CancellationToken)"/>
    Task<HttpResponse<DefaultGatewayCreateResponse>> Create(
        string networkIdentifier,
        DefaultGatewayCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /networks/{id}/default_gateway</c>, but is otherwise the
/// same as <see cref="IDefaultGatewayService.Retrieve(DefaultGatewayRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DefaultGatewayRetrieveResponse>> Retrieve(
        DefaultGatewayRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(DefaultGatewayRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<DefaultGatewayRetrieveResponse>> Retrieve(
        string id,
        DefaultGatewayRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /networks/{id}/default_gateway</c>, but is otherwise the
/// same as <see cref="IDefaultGatewayService.Delete(DefaultGatewayDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DefaultGatewayDeleteResponse>> Delete(
        DefaultGatewayDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(DefaultGatewayDeleteParams, CancellationToken)"/>
    Task<HttpResponse<DefaultGatewayDeleteResponse>> Delete(
        string id,
        DefaultGatewayDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}