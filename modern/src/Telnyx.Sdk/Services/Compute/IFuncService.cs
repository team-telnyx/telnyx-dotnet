using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Compute.Funcs;
using Telnyx.Sdk.Services.Compute.Funcs;

namespace Telnyx.Sdk.Services.Compute;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFuncService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFuncServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFuncService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IExportService Export { get; }

    /// <summary>
/// Returns logs oldest first. `type=runtime` (default) returns function
/// stdout/stderr. `type=invocations` returns one platform-generated record per HTTP
/// request served.
/// </summary>
    Task<FuncRetrieveLogsResponse> RetrieveLogs(
        FuncRetrieveLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveLogs(FuncRetrieveLogsParams, CancellationToken)"/>
    Task<FuncRetrieveLogsResponse> RetrieveLogs(
        string id,
        FuncRetrieveLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns aggregate request, latency, CPU, memory, and resource-limit metrics for
/// a function over the requested window.
/// </summary>
    Task<FuncRetrieveMetricAggregatesPage> RetrieveMetricAggregates(
        FuncRetrieveMetricAggregatesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveMetricAggregates(FuncRetrieveMetricAggregatesParams, CancellationToken)"/>
    Task<FuncRetrieveMetricAggregatesPage> RetrieveMetricAggregates(
        string id,
        FuncRetrieveMetricAggregatesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists a function's ship history newest first, including per-ship failure stage
/// and reason when recorded.
/// </summary>
    Task<FuncRetrieveRevisionsPage> RetrieveRevisions(
        FuncRetrieveRevisionsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRevisions(FuncRetrieveRevisionsParams, CancellationToken)"/>
    Task<FuncRetrieveRevisionsPage> RetrieveRevisions(
        string id,
        FuncRetrieveRevisionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the latest ship outcome. The stage is `none` on success, `pending` while
/// building, or a failure stage such as `build`, `platform`, `pre_build`, `deploy`,
/// or `security_review`. This stage-neutral customer-facing path is an alias over
/// the same inspection resource as `build_log_inspection`.
/// </summary>
    Task<FuncRetrieveShipInspectionResponse> RetrieveShipInspection(
        FuncRetrieveShipInspectionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveShipInspection(FuncRetrieveShipInspectionParams, CancellationToken)"/>
    Task<FuncRetrieveShipInspectionResponse> RetrieveShipInspection(
        string id,
        FuncRetrieveShipInspectionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IFuncService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFuncServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFuncServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IExportServiceWithRawResponse Export { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /compute/funcs/{id}/logs</c>, but is otherwise the
/// same as <see cref="IFuncService.RetrieveLogs(FuncRetrieveLogsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FuncRetrieveLogsResponse>> RetrieveLogs(
        FuncRetrieveLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveLogs(FuncRetrieveLogsParams, CancellationToken)"/>
    Task<HttpResponse<FuncRetrieveLogsResponse>> RetrieveLogs(
        string id,
        FuncRetrieveLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /compute/funcs/{id}/metric_aggregates</c>, but is otherwise the
/// same as <see cref="IFuncService.RetrieveMetricAggregates(FuncRetrieveMetricAggregatesParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FuncRetrieveMetricAggregatesPage>> RetrieveMetricAggregates(
        FuncRetrieveMetricAggregatesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveMetricAggregates(FuncRetrieveMetricAggregatesParams, CancellationToken)"/>
    Task<HttpResponse<FuncRetrieveMetricAggregatesPage>> RetrieveMetricAggregates(
        string id,
        FuncRetrieveMetricAggregatesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /compute/funcs/{id}/revisions</c>, but is otherwise the
/// same as <see cref="IFuncService.RetrieveRevisions(FuncRetrieveRevisionsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FuncRetrieveRevisionsPage>> RetrieveRevisions(
        FuncRetrieveRevisionsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRevisions(FuncRetrieveRevisionsParams, CancellationToken)"/>
    Task<HttpResponse<FuncRetrieveRevisionsPage>> RetrieveRevisions(
        string id,
        FuncRetrieveRevisionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /compute/funcs/{id}/ship_inspection</c>, but is otherwise the
/// same as <see cref="IFuncService.RetrieveShipInspection(FuncRetrieveShipInspectionParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FuncRetrieveShipInspectionResponse>> RetrieveShipInspection(
        FuncRetrieveShipInspectionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveShipInspection(FuncRetrieveShipInspectionParams, CancellationToken)"/>
    Task<HttpResponse<FuncRetrieveShipInspectionResponse>> RetrieveShipInspection(
        string id,
        FuncRetrieveShipInspectionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}