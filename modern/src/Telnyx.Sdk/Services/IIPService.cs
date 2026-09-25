using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Ips;

namespace Telnyx.Sdk.Services;

/// <summary>
/// IP operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IIPService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIPServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIPService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a new IP record for use with IP-based connections, associating an IP
/// address with the specified connection.
/// </summary>
    Task<IPCreateResponse> Create(
        IPCreateParams parameters, CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Return the details regarding a specific IP.
/// </summary>
    Task<IPRetrieveResponse> Retrieve(
        IPRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(IPRetrieveParams, CancellationToken)"/>
    Task<IPRetrieveResponse> Retrieve(
        string id,
        IPRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the details of the specified IP record and returns the updated IP.
/// </summary>
    Task<IPUpdateResponse> Update(
        IPUpdateParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(IPUpdateParams, CancellationToken)"/>
    Task<IPUpdateResponse> Update(
        string id,
        IPUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get all IPs belonging to the user that match the given filters.
/// </summary>
    Task<IPListPage> List(
        IPListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified IP record from its connection.
/// </summary>
    Task<IPDeleteResponse> Delete(
        IPDeleteParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(IPDeleteParams, CancellationToken)"/>
    Task<IPDeleteResponse> Delete(
        string id,
        IPDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IIPService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IIPServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIPServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ips</c>, but is otherwise the
/// same as <see cref="IIPService.Create(IPCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<IPCreateResponse>> Create(
        IPCreateParams parameters, CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ips/{id}</c>, but is otherwise the
/// same as <see cref="IIPService.Retrieve(IPRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<IPRetrieveResponse>> Retrieve(
        IPRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(IPRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<IPRetrieveResponse>> Retrieve(
        string id,
        IPRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /ips/{id}</c>, but is otherwise the
/// same as <see cref="IIPService.Update(IPUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<IPUpdateResponse>> Update(
        IPUpdateParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(IPUpdateParams, CancellationToken)"/>
    Task<HttpResponse<IPUpdateResponse>> Update(
        string id,
        IPUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ips</c>, but is otherwise the
/// same as <see cref="IIPService.List(IPListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<IPListPage>> List(
        IPListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ips/{id}</c>, but is otherwise the
/// same as <see cref="IIPService.Delete(IPDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<IPDeleteResponse>> Delete(
        IPDeleteParams parameters, CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(IPDeleteParams, CancellationToken)"/>
    Task<HttpResponse<IPDeleteResponse>> Delete(
        string id,
        IPDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}