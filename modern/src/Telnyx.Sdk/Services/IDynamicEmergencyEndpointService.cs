using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.DynamicEmergencyEndpoints;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Dynamic Emergency Endpoints
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDynamicEmergencyEndpointService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDynamicEmergencyEndpointServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDynamicEmergencyEndpointService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a dynamic emergency endpoint, associating a callback number and location
/// with a device for emergency calling.
/// </summary>
    Task<DynamicEmergencyEndpointCreateResponse> Create(
        DynamicEmergencyEndpointCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the dynamic emergency endpoint based on the ID provided
/// </summary>
    Task<DynamicEmergencyEndpointRetrieveResponse> Retrieve(
        DynamicEmergencyEndpointRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(DynamicEmergencyEndpointRetrieveParams, CancellationToken)"/>
    Task<DynamicEmergencyEndpointRetrieveResponse> Retrieve(
        string id,
        DynamicEmergencyEndpointRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the dynamic emergency endpoints according to filters
/// </summary>
    Task<DynamicEmergencyEndpointListPage> List(
        DynamicEmergencyEndpointListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the dynamic emergency endpoint based on the ID provided
/// </summary>
    Task<DynamicEmergencyEndpointDeleteResponse> Delete(
        DynamicEmergencyEndpointDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(DynamicEmergencyEndpointDeleteParams, CancellationToken)"/>
    Task<DynamicEmergencyEndpointDeleteResponse> Delete(
        string id,
        DynamicEmergencyEndpointDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IDynamicEmergencyEndpointService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDynamicEmergencyEndpointServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDynamicEmergencyEndpointServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /dynamic_emergency_endpoints</c>, but is otherwise the
/// same as <see cref="IDynamicEmergencyEndpointService.Create(DynamicEmergencyEndpointCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DynamicEmergencyEndpointCreateResponse>> Create(
        DynamicEmergencyEndpointCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /dynamic_emergency_endpoints/{id}</c>, but is otherwise the
/// same as <see cref="IDynamicEmergencyEndpointService.Retrieve(DynamicEmergencyEndpointRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DynamicEmergencyEndpointRetrieveResponse>> Retrieve(
        DynamicEmergencyEndpointRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(DynamicEmergencyEndpointRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<DynamicEmergencyEndpointRetrieveResponse>> Retrieve(
        string id,
        DynamicEmergencyEndpointRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /dynamic_emergency_endpoints</c>, but is otherwise the
/// same as <see cref="IDynamicEmergencyEndpointService.List(DynamicEmergencyEndpointListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DynamicEmergencyEndpointListPage>> List(
        DynamicEmergencyEndpointListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /dynamic_emergency_endpoints/{id}</c>, but is otherwise the
/// same as <see cref="IDynamicEmergencyEndpointService.Delete(DynamicEmergencyEndpointDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DynamicEmergencyEndpointDeleteResponse>> Delete(
        DynamicEmergencyEndpointDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(DynamicEmergencyEndpointDeleteParams, CancellationToken)"/>
    Task<HttpResponse<DynamicEmergencyEndpointDeleteResponse>> Delete(
        string id,
        DynamicEmergencyEndpointDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}