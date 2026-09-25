using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.InventoryCoverage;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Inventory Level
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IInventoryCoverageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInventoryCoverageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInventoryCoverageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates an inventory coverage request. If locality, npa or
/// national_destination_code is used in groupBy, and no region or locality filters
/// are used, the whole paginated set is returned.
/// </summary>
    Task<InventoryCoverageListResponse> List(
        InventoryCoverageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IInventoryCoverageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInventoryCoverageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInventoryCoverageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /inventory_coverage</c>, but is otherwise the
/// same as <see cref="IInventoryCoverageService.List(InventoryCoverageListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<InventoryCoverageListResponse>> List(
        InventoryCoverageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}