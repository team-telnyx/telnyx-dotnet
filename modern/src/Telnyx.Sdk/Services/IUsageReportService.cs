using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.UsageReports;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Usage data reporting across Telnyx products
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IUsageReportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUsageReportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageReportService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Get Telnyx usage data by product, broken out by the specified dimensions
/// </summary>
    Task<UsageReportListPage> List(
        UsageReportListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get the Usage Reports options for querying usage, including the products
/// available and their respective metrics and dimensions
/// </summary>
    Task<UsageReportGetOptionsResponse> GetOptions(
        UsageReportGetOptionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IUsageReportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUsageReportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /usage_reports</c>, but is otherwise the
/// same as <see cref="IUsageReportService.List(UsageReportListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UsageReportListPage>> List(
        UsageReportListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /usage_reports/options</c>, but is otherwise the
/// same as <see cref="IUsageReportService.GetOptions(UsageReportGetOptionsParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UsageReportGetOptionsResponse>> GetOptions(
        UsageReportGetOptionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}