using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Reports.MdrUsageReports;

namespace Telnyx.Sdk.Services.Reports;

/// <summary>
/// Messaging usage reports
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMdrUsageReportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMdrUsageReportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMdrUsageReportService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Submit request for new new messaging usage report. This endpoint will pull and
/// aggregate messaging data in specified time period.
/// </summary>
    Task<MdrUsageReportCreateResponse> Create(
        MdrUsageReportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Fetch a single messaging usage report by id
/// </summary>
    Task<MdrUsageReportRetrieveResponse> Retrieve(
        MdrUsageReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MdrUsageReportRetrieveParams, CancellationToken)"/>
    Task<MdrUsageReportRetrieveResponse> Retrieve(
        string id,
        MdrUsageReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Fetch all messaging usage reports. Usage reports are aggregated messaging data
/// for specified time period and breakdown
/// </summary>
    Task<MdrUsageReportListPage> List(
        MdrUsageReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified messaging usage report by its identifier.
/// </summary>
    Task<MdrUsageReportDeleteResponse> Delete(
        MdrUsageReportDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MdrUsageReportDeleteParams, CancellationToken)"/>
    Task<MdrUsageReportDeleteResponse> Delete(
        string id,
        MdrUsageReportDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Generate and fetch messaging usage report synchronously. This endpoint will both
/// generate and fetch the messaging report over a specified time period. No polling
/// is necessary but the response may take up to a couple of minutes.
/// </summary>
    Task<MdrUsageReportFetchSyncResponse> FetchSync(
        MdrUsageReportFetchSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMdrUsageReportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMdrUsageReportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMdrUsageReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /reports/mdr_usage_reports</c>, but is otherwise the
/// same as <see cref="IMdrUsageReportService.Create(MdrUsageReportCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MdrUsageReportCreateResponse>> Create(
        MdrUsageReportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /reports/mdr_usage_reports/{id}</c>, but is otherwise the
/// same as <see cref="IMdrUsageReportService.Retrieve(MdrUsageReportRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MdrUsageReportRetrieveResponse>> Retrieve(
        MdrUsageReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MdrUsageReportRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MdrUsageReportRetrieveResponse>> Retrieve(
        string id,
        MdrUsageReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /reports/mdr_usage_reports</c>, but is otherwise the
/// same as <see cref="IMdrUsageReportService.List(MdrUsageReportListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MdrUsageReportListPage>> List(
        MdrUsageReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /reports/mdr_usage_reports/{id}</c>, but is otherwise the
/// same as <see cref="IMdrUsageReportService.Delete(MdrUsageReportDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MdrUsageReportDeleteResponse>> Delete(
        MdrUsageReportDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MdrUsageReportDeleteParams, CancellationToken)"/>
    Task<HttpResponse<MdrUsageReportDeleteResponse>> Delete(
        string id,
        MdrUsageReportDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /reports/mdr_usage_reports/sync</c>, but is otherwise the
/// same as <see cref="IMdrUsageReportService.FetchSync(MdrUsageReportFetchSyncParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MdrUsageReportFetchSyncResponse>> FetchSync(
        MdrUsageReportFetchSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}