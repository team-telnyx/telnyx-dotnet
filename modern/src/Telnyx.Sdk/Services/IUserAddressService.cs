using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.UserAddresses;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Operations for working with UserAddress records. UserAddress records are stored
/// addresses that users can use for non-emergency-calling purposes, such as for shipping
/// addresses for orders of wireless SIMs (or other physical items). They cannot
/// be used for emergency calling and are distinct from Address records, which are
/// used on phone numbers.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IUserAddressService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserAddressServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserAddressService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a new user address from the provided details and returns the created
/// address.
/// </summary>
    Task<UserAddressCreateResponse> Create(
        UserAddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves the details of an existing user address.
/// </summary>
    Task<UserAddressRetrieveResponse> Retrieve(
        UserAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(UserAddressRetrieveParams, CancellationToken)"/>
    Task<UserAddressRetrieveResponse> Retrieve(
        string id,
        UserAddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of your user addresses, with support for filtering and
/// sorting.
/// </summary>
    Task<UserAddressListPage> List(
        UserAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IUserAddressService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserAddressServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserAddressServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /user_addresses</c>, but is otherwise the
/// same as <see cref="IUserAddressService.Create(UserAddressCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UserAddressCreateResponse>> Create(
        UserAddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /user_addresses/{id}</c>, but is otherwise the
/// same as <see cref="IUserAddressService.Retrieve(UserAddressRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UserAddressRetrieveResponse>> Retrieve(
        UserAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(UserAddressRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<UserAddressRetrieveResponse>> Retrieve(
        string id,
        UserAddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /user_addresses</c>, but is otherwise the
/// same as <see cref="IUserAddressService.List(UserAddressListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UserAddressListPage>> List(
        UserAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}