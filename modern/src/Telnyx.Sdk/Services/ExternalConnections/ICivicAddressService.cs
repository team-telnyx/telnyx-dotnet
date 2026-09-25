using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.ExternalConnections.CivicAddresses;

namespace Telnyx.Sdk.Services.ExternalConnections;

/// <summary>
/// External Connections operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICivicAddressService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICivicAddressServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICivicAddressService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Return the details of an existing Civic Address with its Locations inside the
/// 'data' attribute of the response.
/// </summary>
    Task<CivicAddressRetrieveResponse> Retrieve(
        CivicAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CivicAddressRetrieveParams, CancellationToken)"/>
    Task<CivicAddressRetrieveResponse> Retrieve(
        string addressID,
        CivicAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the civic addresses and locations from Microsoft Teams.
/// </summary>
    Task<CivicAddressListResponse> List(
        CivicAddressListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(CivicAddressListParams, CancellationToken)"/>
    Task<CivicAddressListResponse> List(
        string id,
        CivicAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICivicAddressService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICivicAddressServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICivicAddressServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /external_connections/{id}/civic_addresses/{address_id}</c>, but is otherwise the
/// same as <see cref="ICivicAddressService.Retrieve(CivicAddressRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CivicAddressRetrieveResponse>> Retrieve(
        CivicAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CivicAddressRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CivicAddressRetrieveResponse>> Retrieve(
        string addressID,
        CivicAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /external_connections/{id}/civic_addresses</c>, but is otherwise the
/// same as <see cref="ICivicAddressService.List(CivicAddressListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CivicAddressListResponse>> List(
        CivicAddressListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(CivicAddressListParams, CancellationToken)"/>
    Task<HttpResponse<CivicAddressListResponse>> List(
        string id,
        CivicAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}