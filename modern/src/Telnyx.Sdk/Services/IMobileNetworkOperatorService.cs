using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MobileNetworkOperators;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Mobile network operators operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMobileNetworkOperatorService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMobileNetworkOperatorServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMobileNetworkOperatorService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Telnyx has a set of GSM mobile operators partners that are available through our
/// mobile network roaming. This resource is entirely managed by Telnyx and may
/// change over time. That means that this resource won't allow any write operations
/// for it. Still, it's available so it can be used as a support resource that can
/// be related to other resources or become a configuration option.
/// </summary>
    Task<MobileNetworkOperatorListPage> List(
        MobileNetworkOperatorListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMobileNetworkOperatorService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMobileNetworkOperatorServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMobileNetworkOperatorServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /mobile_network_operators</c>, but is otherwise the
/// same as <see cref="IMobileNetworkOperatorService.List(MobileNetworkOperatorListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MobileNetworkOperatorListPage>> List(
        MobileNetworkOperatorListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}