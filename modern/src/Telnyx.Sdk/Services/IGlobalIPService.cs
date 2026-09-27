using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIps;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Global IPs
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IGlobalIPService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGlobalIPServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGlobalIPService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Requests creation of a new Global IP, a static IP address announced from the
/// Telnyx network. Provisioning is asynchronous, so the request is accepted and the
/// Global IP becomes available once provisioning completes.
/// </summary>
    Task<GlobalIPCreateResponse> Create(
        GlobalIPCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single Global IP, including its address and current
/// configuration.
/// </summary>
    Task<GlobalIPRetrieveResponse> Retrieve(
        GlobalIPRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(GlobalIPRetrieveParams, CancellationToken)"/>
    Task<GlobalIPRetrieveResponse> Retrieve(
        string id,
        GlobalIPRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of the Global IPs on your account, including each IP's
/// address and configuration.
/// </summary>
    Task<GlobalIPListPage> List(
        GlobalIPListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified Global IP and releases its address back to Telnyx.
/// </summary>
    Task<GlobalIPDeleteResponse> Delete(
        GlobalIPDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(GlobalIPDeleteParams, CancellationToken)"/>
    Task<GlobalIPDeleteResponse> Delete(
        string id,
        GlobalIPDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IGlobalIPService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGlobalIPServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGlobalIPServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /global_ips</c>, but is otherwise the
/// same as <see cref="IGlobalIPService.Create(GlobalIPCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPCreateResponse>> Create(
        GlobalIPCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /global_ips/{id}</c>, but is otherwise the
/// same as <see cref="IGlobalIPService.Retrieve(GlobalIPRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPRetrieveResponse>> Retrieve(
        GlobalIPRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(GlobalIPRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<GlobalIPRetrieveResponse>> Retrieve(
        string id,
        GlobalIPRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /global_ips</c>, but is otherwise the
/// same as <see cref="IGlobalIPService.List(GlobalIPListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPListPage>> List(
        GlobalIPListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /global_ips/{id}</c>, but is otherwise the
/// same as <see cref="IGlobalIPService.Delete(GlobalIPDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPDeleteResponse>> Delete(
        GlobalIPDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(GlobalIPDeleteParams, CancellationToken)"/>
    Task<HttpResponse<GlobalIPDeleteResponse>> Delete(
        string id,
        GlobalIPDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}