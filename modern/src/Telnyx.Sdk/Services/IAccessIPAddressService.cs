using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AccessIPAddress;

namespace Telnyx.Sdk.Services;

/// <summary>
/// IP Address Operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAccessIPAddressService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccessIPAddressServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccessIPAddressService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a new access IP address entry on your account.
/// </summary>
    Task<AccessIPAddressResponse> Create(
        AccessIPAddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve the details of a specific access IP address.
/// </summary>
    Task<AccessIPAddressResponse> Retrieve(
        AccessIPAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AccessIPAddressRetrieveParams, CancellationToken)"/>
    Task<AccessIPAddressResponse> Retrieve(
        string accessIPAddressID,
        AccessIPAddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a paginated list of access IP addresses configured on your account.
/// </summary>
    Task<AccessIPAddressListPage> List(
        AccessIPAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Delete an access IP address entry from your account.
/// </summary>
    Task<AccessIPAddressResponse> Delete(
        AccessIPAddressDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AccessIPAddressDeleteParams, CancellationToken)"/>
    Task<AccessIPAddressResponse> Delete(
        string accessIPAddressID,
        AccessIPAddressDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAccessIPAddressService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccessIPAddressServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccessIPAddressServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /access_ip_address</c>, but is otherwise the
/// same as <see cref="IAccessIPAddressService.Create(AccessIPAddressCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AccessIPAddressResponse>> Create(
        AccessIPAddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /access_ip_address/{access_ip_address_id}</c>, but is otherwise the
/// same as <see cref="IAccessIPAddressService.Retrieve(AccessIPAddressRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AccessIPAddressResponse>> Retrieve(
        AccessIPAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AccessIPAddressRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AccessIPAddressResponse>> Retrieve(
        string accessIPAddressID,
        AccessIPAddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /access_ip_address</c>, but is otherwise the
/// same as <see cref="IAccessIPAddressService.List(AccessIPAddressListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AccessIPAddressListPage>> List(
        AccessIPAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /access_ip_address/{access_ip_address_id}</c>, but is otherwise the
/// same as <see cref="IAccessIPAddressService.Delete(AccessIPAddressDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AccessIPAddressResponse>> Delete(
        AccessIPAddressDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AccessIPAddressDeleteParams, CancellationToken)"/>
    Task<HttpResponse<AccessIPAddressResponse>> Delete(
        string accessIPAddressID,
        AccessIPAddressDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}