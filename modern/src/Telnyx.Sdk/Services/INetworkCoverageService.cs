using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NetworkCoverage;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface INetworkCoverageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INetworkCoverageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INetworkCoverageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// List all locations and the interfaces that region supports
/// </summary>
    Task<NetworkCoverageListPage> List(
        NetworkCoverageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INetworkCoverageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INetworkCoverageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INetworkCoverageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /network_coverage</c>, but is otherwise the
/// same as <see cref="INetworkCoverageService.List(NetworkCoverageListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NetworkCoverageListPage>> List(
        NetworkCoverageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}