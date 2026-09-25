using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortabilityChecks;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Determining portability of phone numbers
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPortabilityCheckService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPortabilityCheckServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPortabilityCheckService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Runs a portability check, returning the results immediately.
/// </summary>
    Task<PortabilityCheckRunResponse> Run(
        PortabilityCheckRunParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPortabilityCheckService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPortabilityCheckServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPortabilityCheckServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /portability_checks</c>, but is otherwise the
/// same as <see cref="IPortabilityCheckService.Run(PortabilityCheckRunParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PortabilityCheckRunResponse>> Run(
        PortabilityCheckRunParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}