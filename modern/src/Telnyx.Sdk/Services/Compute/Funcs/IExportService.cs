using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Compute.Funcs.Export;

namespace Telnyx.Sdk.Services.Compute.Funcs;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IExportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExportService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Configures the external OTLP endpoint a function's runtime and/or invocation
/// logs are pushed to as they happen. This operation is a **full replace, not a
/// patch**: `endpoint`, `headers`, `runtime_export_enabled`, and
/// `invocation_export_enabled` are all required on every call — omitting any of
/// them is a 422, not "keep the current value". Headers are encrypted at rest and
/// never returned in any response.
/// 
/// <para>The endpoint must be an HTTPS URL. When export is configured, new log
/// records are converted to OTLP log records and delivered continuously; export
/// never bypasses platform log storage, and delivery retries with a bounded policy
/// while the destination is unreachable. Only logs generated after configuration
/// are exported — there is no historical replay.</para>
/// </summary>
    Task<FuncLogExportConfigResponse> Create(
        ExportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(ExportCreateParams, CancellationToken)"/>
    Task<FuncLogExportConfigResponse> Create(
        string id,
        ExportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the function's configured log export destination and which log types are
/// exported. Headers are never returned. Returns 404 (error code 10005) when no
/// destination is configured for the function.
/// </summary>
    Task<FuncLogExportConfigResponse> List(
        ExportListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ExportListParams, CancellationToken)"/>
    Task<FuncLogExportConfigResponse> List(
        string id,
        ExportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Stops exporting a function's logs and removes its destination configuration.
/// Idempotent: deleting when nothing is configured succeeds.
/// </summary>
    Task DeleteAll(
        ExportDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteAll(ExportDeleteAllParams, CancellationToken)"/>
    Task DeleteAll(
        string id,
        ExportDeleteAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IExportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /compute/funcs/{id}/logs/export</c>, but is otherwise the
/// same as <see cref="IExportService.Create(ExportCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FuncLogExportConfigResponse>> Create(
        ExportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(ExportCreateParams, CancellationToken)"/>
    Task<HttpResponse<FuncLogExportConfigResponse>> Create(
        string id,
        ExportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /compute/funcs/{id}/logs/export</c>, but is otherwise the
/// same as <see cref="IExportService.List(ExportListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FuncLogExportConfigResponse>> List(
        ExportListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ExportListParams, CancellationToken)"/>
    Task<HttpResponse<FuncLogExportConfigResponse>> List(
        string id,
        ExportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /compute/funcs/{id}/logs/export</c>, but is otherwise the
/// same as <see cref="IExportService.DeleteAll(ExportDeleteAllParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> DeleteAll(
        ExportDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteAll(ExportDeleteAllParams, CancellationToken)"/>
    Task<HttpResponse> DeleteAll(
        string id,
        ExportDeleteAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}