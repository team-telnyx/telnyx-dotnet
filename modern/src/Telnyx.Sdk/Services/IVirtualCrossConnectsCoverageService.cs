using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.VirtualCrossConnectsCoverage;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Virtual Cross Connect operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVirtualCrossConnectsCoverageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVirtualCrossConnectsCoverageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVirtualCrossConnectsCoverageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// List Virtual Cross Connects Cloud Coverage.&lt;br /&gt;&lt;br /&gt;This endpoint
/// shows which cloud regions are available for the `location_code` your Virtual
/// Cross Connect will be provisioned in.
/// </summary>
    Task<VirtualCrossConnectsCoverageListPage> List(
        VirtualCrossConnectsCoverageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IVirtualCrossConnectsCoverageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVirtualCrossConnectsCoverageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVirtualCrossConnectsCoverageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /virtual_cross_connects_coverage</c>, but is otherwise the
/// same as <see cref="IVirtualCrossConnectsCoverageService.List(VirtualCrossConnectsCoverageListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VirtualCrossConnectsCoverageListPage>> List(
        VirtualCrossConnectsCoverageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}