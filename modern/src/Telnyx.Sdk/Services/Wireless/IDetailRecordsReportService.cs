using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Wireless.DetailRecordsReports;

namespace Telnyx.Sdk.Services.Wireless;

/// <summary>
/// Wireless reporting operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDetailRecordsReportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDetailRecordsReportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDetailRecordsReportService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Asynchronously create a report containing Wireless Detail Records (WDRs) for the
/// SIM cards that consumed wireless data in the given time period.
/// </summary>
    Task<DetailRecordsReportCreateResponse> Create(
        DetailRecordsReportCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a single Wireless Detail Record (WDR) report by its identifier,
/// including its parameters and current status.
/// </summary>
    Task<DetailRecordsReportRetrieveResponse> Retrieve(
        DetailRecordsReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(DetailRecordsReportRetrieveParams, CancellationToken)"/>
    Task<DetailRecordsReportRetrieveResponse> Retrieve(
        string id,
        DetailRecordsReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the WDR Reports that match the given parameters.
/// </summary>
    Task<DetailRecordsReportListResponse> List(
        DetailRecordsReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified Wireless Detail Record (WDR) report.
/// </summary>
    Task<DetailRecordsReportDeleteResponse> Delete(
        DetailRecordsReportDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(DetailRecordsReportDeleteParams, CancellationToken)"/>
    Task<DetailRecordsReportDeleteResponse> Delete(
        string id,
        DetailRecordsReportDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IDetailRecordsReportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDetailRecordsReportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDetailRecordsReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /wireless/detail_records_reports</c>, but is otherwise the
/// same as <see cref="IDetailRecordsReportService.Create(DetailRecordsReportCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DetailRecordsReportCreateResponse>> Create(
        DetailRecordsReportCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /wireless/detail_records_reports/{id}</c>, but is otherwise the
/// same as <see cref="IDetailRecordsReportService.Retrieve(DetailRecordsReportRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DetailRecordsReportRetrieveResponse>> Retrieve(
        DetailRecordsReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(DetailRecordsReportRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<DetailRecordsReportRetrieveResponse>> Retrieve(
        string id,
        DetailRecordsReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /wireless/detail_records_reports</c>, but is otherwise the
/// same as <see cref="IDetailRecordsReportService.List(DetailRecordsReportListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DetailRecordsReportListResponse>> List(
        DetailRecordsReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /wireless/detail_records_reports/{id}</c>, but is otherwise the
/// same as <see cref="IDetailRecordsReportService.Delete(DetailRecordsReportDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DetailRecordsReportDeleteResponse>> Delete(
        DetailRecordsReportDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(DetailRecordsReportDeleteParams, CancellationToken)"/>
    Task<HttpResponse<DetailRecordsReportDeleteResponse>> Delete(
        string id,
        DetailRecordsReportDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}