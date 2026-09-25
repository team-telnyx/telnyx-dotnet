using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPUsage;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Global IPs
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IGlobalIPUsageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGlobalIPUsageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGlobalIPUsageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Retrieve usage metrics for your Global IPs.
/// </summary>
    Task<GlobalIPUsageRetrieveResponse> Retrieve(
        GlobalIPUsageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IGlobalIPUsageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGlobalIPUsageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGlobalIPUsageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /global_ip_usage</c>, but is otherwise the
/// same as <see cref="IGlobalIPUsageService.Retrieve(GlobalIPUsageRetrieveParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPUsageRetrieveResponse>> Retrieve(
        GlobalIPUsageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}