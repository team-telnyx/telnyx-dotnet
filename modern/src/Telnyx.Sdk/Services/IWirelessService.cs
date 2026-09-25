using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Wireless;
using Telnyx.Sdk.Services.Wireless;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Regions for wireless services
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWirelessService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWirelessServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWirelessService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IDetailRecordsReportService DetailRecordsReports { get; }

    /// <summary>
/// Retrieve all wireless regions for the given product.
/// </summary>
    Task<WirelessRetrieveRegionsResponse> RetrieveRegions(
        WirelessRetrieveRegionsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IWirelessService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWirelessServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWirelessServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IDetailRecordsReportServiceWithRawResponse DetailRecordsReports { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /wireless/regions</c>, but is otherwise the
/// same as <see cref="IWirelessService.RetrieveRegions(WirelessRetrieveRegionsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WirelessRetrieveRegionsResponse>> RetrieveRegions(
        WirelessRetrieveRegionsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}