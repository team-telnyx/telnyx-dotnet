using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PublicInternetGateways;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Public Internet Gateway operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPublicInternetGatewayService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPublicInternetGatewayServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPublicInternetGatewayService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Requests creation of a public internet gateway on the specified network, giving
/// the network internet egress. Creation is asynchronous, so the request is
/// accepted and completes in the background.
/// </summary>
    Task<PublicInternetGatewayCreateResponse> Create(
        PublicInternetGatewayCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single public internet gateway by its identifier.
/// </summary>
    Task<PublicInternetGatewayRetrieveResponse> Retrieve(
        PublicInternetGatewayRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PublicInternetGatewayRetrieveParams, CancellationToken)"/>
    Task<PublicInternetGatewayRetrieveResponse> Retrieve(
        string id,
        PublicInternetGatewayRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of the public internet gateways on your account, with
/// support for filtering.
/// </summary>
    Task<PublicInternetGatewayListPage> List(
        PublicInternetGatewayListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified public internet gateway, removing internet egress through
/// it.
/// </summary>
    Task<PublicInternetGatewayDeleteResponse> Delete(
        PublicInternetGatewayDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PublicInternetGatewayDeleteParams, CancellationToken)"/>
    Task<PublicInternetGatewayDeleteResponse> Delete(
        string id,
        PublicInternetGatewayDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPublicInternetGatewayService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPublicInternetGatewayServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPublicInternetGatewayServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /public_internet_gateways</c>, but is otherwise the
/// same as <see cref="IPublicInternetGatewayService.Create(PublicInternetGatewayCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PublicInternetGatewayCreateResponse>> Create(
        PublicInternetGatewayCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /public_internet_gateways/{id}</c>, but is otherwise the
/// same as <see cref="IPublicInternetGatewayService.Retrieve(PublicInternetGatewayRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PublicInternetGatewayRetrieveResponse>> Retrieve(
        PublicInternetGatewayRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PublicInternetGatewayRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PublicInternetGatewayRetrieveResponse>> Retrieve(
        string id,
        PublicInternetGatewayRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /public_internet_gateways</c>, but is otherwise the
/// same as <see cref="IPublicInternetGatewayService.List(PublicInternetGatewayListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PublicInternetGatewayListPage>> List(
        PublicInternetGatewayListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /public_internet_gateways/{id}</c>, but is otherwise the
/// same as <see cref="IPublicInternetGatewayService.Delete(PublicInternetGatewayDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PublicInternetGatewayDeleteResponse>> Delete(
        PublicInternetGatewayDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PublicInternetGatewayDeleteParams, CancellationToken)"/>
    Task<HttpResponse<PublicInternetGatewayDeleteResponse>> Delete(
        string id,
        PublicInternetGatewayDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}