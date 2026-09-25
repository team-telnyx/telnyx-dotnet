using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Porting.Reports;

namespace Telnyx.Sdk.Services.Porting;

/// <summary>
/// Endpoints related to porting orders management.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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

    /// <summary>
/// Generate reports about porting operations.
/// </summary>
    Task<ReportCreateResponse> Create(
        ReportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a previously requested porting report, including its
/// status and parameters.
/// </summary>
    Task<ReportRetrieveResponse> Retrieve(
        ReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ReportRetrieveParams, CancellationToken)"/>
    Task<ReportRetrieveResponse> Retrieve(
        string id,
        ReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List the reports generated about porting operations.
/// </summary>
    Task<ReportListPage> List(
        ReportListParams? parameters = null,
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

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting/reports</c>, but is otherwise the
/// same as <see cref="IReportService.Create(ReportCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ReportCreateResponse>> Create(
        ReportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting/reports/{id}</c>, but is otherwise the
/// same as <see cref="IReportService.Retrieve(ReportRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ReportRetrieveResponse>> Retrieve(
        ReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ReportRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ReportRetrieveResponse>> Retrieve(
        string id,
        ReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting/reports</c>, but is otherwise the
/// same as <see cref="IReportService.List(ReportListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ReportListPage>> List(
        ReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}