using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPProtocols;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Global IPs
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IGlobalIPProtocolService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGlobalIPProtocolServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGlobalIPProtocolService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns the network protocols supported for Global IP traffic, for use when
/// configuring Global IP resources.
/// </summary>
    Task<GlobalIPProtocolListResponse> List(
        GlobalIPProtocolListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IGlobalIPProtocolService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGlobalIPProtocolServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGlobalIPProtocolServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /global_ip_protocols</c>, but is otherwise the
/// same as <see cref="IGlobalIPProtocolService.List(GlobalIPProtocolListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPProtocolListResponse>> List(
        GlobalIPProtocolListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}