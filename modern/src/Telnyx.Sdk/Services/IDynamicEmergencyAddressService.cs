using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.DynamicEmergencyAddresses;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Dynamic emergency address operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDynamicEmergencyAddressService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDynamicEmergencyAddressServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDynamicEmergencyAddressService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a dynamic emergency address, the validated physical location used when
/// provisioning dynamic emergency endpoints.
/// </summary>
    Task<DynamicEmergencyAddressCreateResponse> Create(
        DynamicEmergencyAddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the dynamic emergency address based on the ID provided
/// </summary>
    Task<DynamicEmergencyAddressRetrieveResponse> Retrieve(
        DynamicEmergencyAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(DynamicEmergencyAddressRetrieveParams, CancellationToken)"/>
    Task<DynamicEmergencyAddressRetrieveResponse> Retrieve(
        string id,
        DynamicEmergencyAddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the dynamic emergency addresses according to filters
/// </summary>
    Task<DynamicEmergencyAddressListPage> List(
        DynamicEmergencyAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the dynamic emergency address based on the ID provided
/// </summary>
    Task<DynamicEmergencyAddressDeleteResponse> Delete(
        DynamicEmergencyAddressDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(DynamicEmergencyAddressDeleteParams, CancellationToken)"/>
    Task<DynamicEmergencyAddressDeleteResponse> Delete(
        string id,
        DynamicEmergencyAddressDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IDynamicEmergencyAddressService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDynamicEmergencyAddressServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDynamicEmergencyAddressServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /dynamic_emergency_addresses</c>, but is otherwise the
/// same as <see cref="IDynamicEmergencyAddressService.Create(DynamicEmergencyAddressCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DynamicEmergencyAddressCreateResponse>> Create(
        DynamicEmergencyAddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /dynamic_emergency_addresses/{id}</c>, but is otherwise the
/// same as <see cref="IDynamicEmergencyAddressService.Retrieve(DynamicEmergencyAddressRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DynamicEmergencyAddressRetrieveResponse>> Retrieve(
        DynamicEmergencyAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(DynamicEmergencyAddressRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<DynamicEmergencyAddressRetrieveResponse>> Retrieve(
        string id,
        DynamicEmergencyAddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /dynamic_emergency_addresses</c>, but is otherwise the
/// same as <see cref="IDynamicEmergencyAddressService.List(DynamicEmergencyAddressListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DynamicEmergencyAddressListPage>> List(
        DynamicEmergencyAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /dynamic_emergency_addresses/{id}</c>, but is otherwise the
/// same as <see cref="IDynamicEmergencyAddressService.Delete(DynamicEmergencyAddressDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DynamicEmergencyAddressDeleteResponse>> Delete(
        DynamicEmergencyAddressDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(DynamicEmergencyAddressDeleteParams, CancellationToken)"/>
    Task<HttpResponse<DynamicEmergencyAddressDeleteResponse>> Delete(
        string id,
        DynamicEmergencyAddressDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}