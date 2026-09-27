using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPLatency;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Global IPs
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IGlobalIPLatencyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGlobalIPLatencyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGlobalIPLatencyService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Retrieve latency metrics measured for your Global IPs.
/// </summary>
    Task<GlobalIPLatencyRetrieveResponse> Retrieve(
        GlobalIPLatencyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IGlobalIPLatencyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGlobalIPLatencyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGlobalIPLatencyServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /global_ip_latency</c>, but is otherwise the
/// same as <see cref="IGlobalIPLatencyService.Retrieve(GlobalIPLatencyRetrieveParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPLatencyRetrieveResponse>> Retrieve(
        GlobalIPLatencyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}