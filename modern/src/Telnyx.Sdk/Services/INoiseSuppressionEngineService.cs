using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NoiseSuppressionEngines;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Noise suppression engines that can be selected when configuring noise suppression
/// on voice connections.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INoiseSuppressionEngineService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INoiseSuppressionEngineServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INoiseSuppressionEngineService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns all noise suppression engines available to the authenticated user.
/// Engines gated behind a feature flag are included only when the flag is enabled
/// for the user's account. Results are not paginated; the number of engines is
/// expected to remain small.
/// </summary>
    Task<NoiseSuppressionEngineListResponse> List(
        NoiseSuppressionEngineListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INoiseSuppressionEngineService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INoiseSuppressionEngineServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INoiseSuppressionEngineServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /noise_suppression_engines</c>, but is otherwise the
/// same as <see cref="INoiseSuppressionEngineService.List(NoiseSuppressionEngineListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NoiseSuppressionEngineListResponse>> List(
        NoiseSuppressionEngineListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}