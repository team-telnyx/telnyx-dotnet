using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Regions;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Regions
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRegionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRegionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRegionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// List all regions and the interfaces that region supports
/// </summary>
    Task<RegionListResponse> List(
        RegionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRegionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRegionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRegionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /regions</c>, but is otherwise the
/// same as <see cref="IRegionService.List(RegionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RegionListResponse>> List(
        RegionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}