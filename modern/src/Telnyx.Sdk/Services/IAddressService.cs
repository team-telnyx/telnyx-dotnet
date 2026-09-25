using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Addresses;
using Addresses = Telnyx.Sdk.Services.Addresses;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Operations to work with Address records. Address records are emergency-validated
/// addresses meant to be associated with phone numbers. They are validated for emergency
/// usage purposes at creation time, although you may validate them separately with
/// a custom workflow using the ValidateAddress operation separately. Address records
/// are not usable for physical orders, such as for Telnyx SIM cards, please use UserAddress
/// for that. It is not possible to entirely skip emergency service validation for
/// Address records; if an emergency provider for a phone number rejects the address
/// then it cannot be used on a phone number. To prevent records from getting out
/// of sync, Address records are immutable and cannot be altered once created. If
/// you realize you need to alter an address, a new record must be created with the
/// differing address.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAddressService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAddressServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAddressService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Addresses::IActionService Actions { get; }

    /// <summary>
/// Creates a new address on your account from the provided details, for use with
/// services that require a physical address such as emergency calling and
/// regulatory compliance.
/// </summary>
    Task<AddressCreateResponse> Create(
        AddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves the details of an existing address.
/// </summary>
    Task<AddressRetrieveResponse> Retrieve(
        AddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AddressRetrieveParams, CancellationToken)"/>
    Task<AddressRetrieveResponse> Retrieve(
        string id,
        AddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of the addresses on your account, with support for
/// filtering and sorting.
/// </summary>
    Task<AddressListPage> List(
        AddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified address from your account.
/// </summary>
    Task<AddressDeleteResponse> Delete(
        AddressDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AddressDeleteParams, CancellationToken)"/>
    Task<AddressDeleteResponse> Delete(
        string id,
        AddressDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAddressService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAddressServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAddressServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Addresses::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /addresses</c>, but is otherwise the
/// same as <see cref="IAddressService.Create(AddressCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AddressCreateResponse>> Create(
        AddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /addresses/{id}</c>, but is otherwise the
/// same as <see cref="IAddressService.Retrieve(AddressRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AddressRetrieveResponse>> Retrieve(
        AddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AddressRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AddressRetrieveResponse>> Retrieve(
        string id,
        AddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /addresses</c>, but is otherwise the
/// same as <see cref="IAddressService.List(AddressListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AddressListPage>> List(
        AddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /addresses/{id}</c>, but is otherwise the
/// same as <see cref="IAddressService.Delete(AddressDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AddressDeleteResponse>> Delete(
        AddressDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AddressDeleteParams, CancellationToken)"/>
    Task<HttpResponse<AddressDeleteResponse>> Delete(
        string id,
        AddressDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}