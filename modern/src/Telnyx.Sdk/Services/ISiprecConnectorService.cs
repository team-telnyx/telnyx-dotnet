using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.SiprecConnectors;

namespace Telnyx.Sdk.Services;

/// <summary>
/// SIPREC connectors configuration.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISiprecConnectorService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISiprecConnectorServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISiprecConnectorService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a new SIPREC connector configuration.
/// </summary>
    Task<SiprecConnectorResponse> Create(
        SiprecConnectorCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns details of a stored SIPREC connector.
/// </summary>
    Task<SiprecConnectorResponse> Retrieve(
        SiprecConnectorRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SiprecConnectorRetrieveParams, CancellationToken)"/>
    Task<SiprecConnectorResponse> Retrieve(
        string connectorName,
        SiprecConnectorRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates a stored SIPREC connector configuration.
/// </summary>
    Task<SiprecConnectorResponse> Update(
        SiprecConnectorUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(SiprecConnectorUpdateParams, CancellationToken)"/>
    Task<SiprecConnectorResponse> Update(
        string connectorName,
        SiprecConnectorUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the stored SIPREC connector with the specified connector name.
/// </summary>
    Task Delete(
        SiprecConnectorDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SiprecConnectorDeleteParams, CancellationToken)"/>
    Task Delete(
        string connectorName,
        SiprecConnectorDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISiprecConnectorService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISiprecConnectorServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISiprecConnectorServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /siprec_connectors</c>, but is otherwise the
/// same as <see cref="ISiprecConnectorService.Create(SiprecConnectorCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SiprecConnectorResponse>> Create(
        SiprecConnectorCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /siprec_connectors/{connector_name}</c>, but is otherwise the
/// same as <see cref="ISiprecConnectorService.Retrieve(SiprecConnectorRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SiprecConnectorResponse>> Retrieve(
        SiprecConnectorRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SiprecConnectorRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SiprecConnectorResponse>> Retrieve(
        string connectorName,
        SiprecConnectorRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /siprec_connectors/{connector_name}</c>, but is otherwise the
/// same as <see cref="ISiprecConnectorService.Update(SiprecConnectorUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SiprecConnectorResponse>> Update(
        SiprecConnectorUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(SiprecConnectorUpdateParams, CancellationToken)"/>
    Task<HttpResponse<SiprecConnectorResponse>> Update(
        string connectorName,
        SiprecConnectorUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /siprec_connectors/{connector_name}</c>, but is otherwise the
/// same as <see cref="ISiprecConnectorService.Delete(SiprecConnectorDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        SiprecConnectorDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SiprecConnectorDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string connectorName,
        SiprecConnectorDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}