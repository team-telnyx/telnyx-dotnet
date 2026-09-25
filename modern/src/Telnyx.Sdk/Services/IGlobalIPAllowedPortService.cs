using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPAllowedPorts;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Global IPs
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IGlobalIPAllowedPortService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGlobalIPAllowedPortServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGlobalIPAllowedPortService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns the ports allowed for Global IP traffic, for use when configuring Global
/// IP resources.
/// </summary>
    Task<GlobalIPAllowedPortListResponse> List(
        GlobalIPAllowedPortListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IGlobalIPAllowedPortService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGlobalIPAllowedPortServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGlobalIPAllowedPortServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /global_ip_allowed_ports</c>, but is otherwise the
/// same as <see cref="IGlobalIPAllowedPortService.List(GlobalIPAllowedPortListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPAllowedPortListResponse>> List(
        GlobalIPAllowedPortListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}