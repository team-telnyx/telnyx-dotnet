using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MessagingProfileMetrics;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMessagingProfileMetricService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessagingProfileMetricServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingProfileMetricService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// List high-level metrics for all messaging profiles belonging to the
/// authenticated user.
/// </summary>
    Task<MessagingProfileMetricListResponse> List(
        MessagingProfileMetricListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMessagingProfileMetricService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessagingProfileMetricServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingProfileMetricServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_profile_metrics</c>, but is otherwise the
/// same as <see cref="IMessagingProfileMetricService.List(MessagingProfileMetricListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingProfileMetricListResponse>> List(
        MessagingProfileMetricListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}