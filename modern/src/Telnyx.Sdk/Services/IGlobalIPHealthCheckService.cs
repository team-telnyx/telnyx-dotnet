using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPHealthChecks;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Global IPs
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IGlobalIPHealthCheckService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGlobalIPHealthCheckServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGlobalIPHealthCheckService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a health check for a Global IP to monitor the health of its assignments.
/// Creation is asynchronous, so the request is accepted and the health check
/// becomes active once provisioning completes.
/// </summary>
    Task<GlobalIPHealthCheckCreateResponse> Create(
        GlobalIPHealthCheckCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single Global IP health check, including its type and
/// configuration.
/// </summary>
    Task<GlobalIPHealthCheckRetrieveResponse> Retrieve(
        GlobalIPHealthCheckRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(GlobalIPHealthCheckRetrieveParams, CancellationToken)"/>
    Task<GlobalIPHealthCheckRetrieveResponse> Retrieve(
        string id,
        GlobalIPHealthCheckRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of the Global IP health checks configured on your
/// account.
/// </summary>
    Task<GlobalIPHealthCheckListPage> List(
        GlobalIPHealthCheckListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified Global IP health check so it no longer monitors the Global
/// IP's assignments.
/// </summary>
    Task<GlobalIPHealthCheckDeleteResponse> Delete(
        GlobalIPHealthCheckDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(GlobalIPHealthCheckDeleteParams, CancellationToken)"/>
    Task<GlobalIPHealthCheckDeleteResponse> Delete(
        string id,
        GlobalIPHealthCheckDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IGlobalIPHealthCheckService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGlobalIPHealthCheckServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGlobalIPHealthCheckServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /global_ip_health_checks</c>, but is otherwise the
/// same as <see cref="IGlobalIPHealthCheckService.Create(GlobalIPHealthCheckCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPHealthCheckCreateResponse>> Create(
        GlobalIPHealthCheckCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /global_ip_health_checks/{id}</c>, but is otherwise the
/// same as <see cref="IGlobalIPHealthCheckService.Retrieve(GlobalIPHealthCheckRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPHealthCheckRetrieveResponse>> Retrieve(
        GlobalIPHealthCheckRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(GlobalIPHealthCheckRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<GlobalIPHealthCheckRetrieveResponse>> Retrieve(
        string id,
        GlobalIPHealthCheckRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /global_ip_health_checks</c>, but is otherwise the
/// same as <see cref="IGlobalIPHealthCheckService.List(GlobalIPHealthCheckListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPHealthCheckListPage>> List(
        GlobalIPHealthCheckListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /global_ip_health_checks/{id}</c>, but is otherwise the
/// same as <see cref="IGlobalIPHealthCheckService.Delete(GlobalIPHealthCheckDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPHealthCheckDeleteResponse>> Delete(
        GlobalIPHealthCheckDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(GlobalIPHealthCheckDeleteParams, CancellationToken)"/>
    Task<HttpResponse<GlobalIPHealthCheckDeleteResponse>> Delete(
        string id,
        GlobalIPHealthCheckDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}