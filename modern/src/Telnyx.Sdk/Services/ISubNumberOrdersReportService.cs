using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.SubNumberOrdersReport;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Number orders
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISubNumberOrdersReportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISubNumberOrdersReportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubNumberOrdersReportService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a CSV report for sub number orders. The report will be generated
/// asynchronously and can be downloaded once complete.
/// </summary>
    Task<SubNumberOrdersReportCreateResponse> Create(
        SubNumberOrdersReportCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get the status and details of a sub number orders report.
/// </summary>
    Task<SubNumberOrdersReportRetrieveResponse> Retrieve(
        SubNumberOrdersReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SubNumberOrdersReportRetrieveParams, CancellationToken)"/>
    Task<SubNumberOrdersReportRetrieveResponse> Retrieve(
        string reportID,
        SubNumberOrdersReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Download the CSV file for a completed sub number orders report. The report
/// status must be 'success' before the file can be downloaded.
/// </summary>
    Task<BinaryContent> Download(
        SubNumberOrdersReportDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Download(SubNumberOrdersReportDownloadParams, CancellationToken)"/>
    Task<BinaryContent> Download(
        string reportID,
        SubNumberOrdersReportDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISubNumberOrdersReportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISubNumberOrdersReportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubNumberOrdersReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /sub_number_orders_report</c>, but is otherwise the
/// same as <see cref="ISubNumberOrdersReportService.Create(SubNumberOrdersReportCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SubNumberOrdersReportCreateResponse>> Create(
        SubNumberOrdersReportCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sub_number_orders_report/{report_id}</c>, but is otherwise the
/// same as <see cref="ISubNumberOrdersReportService.Retrieve(SubNumberOrdersReportRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SubNumberOrdersReportRetrieveResponse>> Retrieve(
        SubNumberOrdersReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SubNumberOrdersReportRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SubNumberOrdersReportRetrieveResponse>> Retrieve(
        string reportID,
        SubNumberOrdersReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /sub_number_orders_report/{report_id}/download</c>, but is otherwise the
/// same as <see cref="ISubNumberOrdersReportService.Download(SubNumberOrdersReportDownloadParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BinaryContent>> Download(
        SubNumberOrdersReportDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Download(SubNumberOrdersReportDownloadParams, CancellationToken)"/>
    Task<HttpResponse<BinaryContent>> Download(
        string reportID,
        SubNumberOrdersReportDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}