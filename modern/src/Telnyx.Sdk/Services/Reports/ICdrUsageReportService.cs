using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Reports.CdrUsageReports;

namespace Telnyx.Sdk.Services.Reports;

/// <summary>
/// Voice usage reports
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICdrUsageReportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICdrUsageReportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICdrUsageReportService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Generate and fetch voice usage report synchronously. This endpoint will both
/// generate and fetch the voice report over a specified time period. No polling is
/// necessary but the response may take up to a couple of minutes.
/// </summary>
    Task<CdrUsageReportFetchSyncResponse> FetchSync(
        CdrUsageReportFetchSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICdrUsageReportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICdrUsageReportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICdrUsageReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /reports/cdr_usage_reports/sync</c>, but is otherwise the
/// same as <see cref="ICdrUsageReportService.FetchSync(CdrUsageReportFetchSyncParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CdrUsageReportFetchSyncResponse>> FetchSync(
        CdrUsageReportFetchSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}