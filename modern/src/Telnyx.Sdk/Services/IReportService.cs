using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Reports;
using Telnyx.Sdk.Services.Reports;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IReportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IReportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReportService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    ICdrUsageReportService CdrUsageReports { get; }

    IMdrUsageReportService MdrUsageReports { get; }

    /// <summary>
/// Returns message detail records (MDRs) matching the provided criteria, such as
/// date range, direction, status, and message type.
/// </summary>
    Task<ReportListMdrsResponse> ListMdrs(
        ReportListMdrsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns wireless detail records (WDRs) matching the provided criteria, such as
/// date range, SIM card, IMSI, or phone number, with pagination and sorting.
/// </summary>
    Task<ReportListWdrsPage> ListWdrs(
        ReportListWdrsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IReportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IReportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ICdrUsageReportServiceWithRawResponse CdrUsageReports { get; }

    IMdrUsageReportServiceWithRawResponse MdrUsageReports { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /reports/mdrs</c>, but is otherwise the
/// same as <see cref="IReportService.ListMdrs(ReportListMdrsParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ReportListMdrsResponse>> ListMdrs(
        ReportListMdrsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /reports/wdrs</c>, but is otherwise the
/// same as <see cref="IReportService.ListWdrs(ReportListWdrsParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ReportListWdrsPage>> ListWdrs(
        ReportListWdrsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}