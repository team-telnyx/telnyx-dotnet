using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.Voice;

namespace Telnyx.Sdk.Services.Legacy.Reporting.UsageReports;

/// <summary>
/// Voice usage reports
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVoiceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVoiceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a new legacy usage V2 CDR report request with the specified filters
/// </summary>
    Task<VoiceCreateResponse> Create(
        VoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a single CDR (Call Detail Record) usage report by its identifier,
/// including its parameters and current status.
/// </summary>
    Task<VoiceRetrieveResponse> Retrieve(
        VoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VoiceRetrieveParams, CancellationToken)"/>
    Task<VoiceRetrieveResponse> Retrieve(
        string id,
        VoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Fetch all previous requests for cdr usage reports.
/// </summary>
    Task<VoiceListPage> List(
        VoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes a specific V2 legacy usage CDR report request by ID
/// </summary>
    Task<VoiceDeleteResponse> Delete(
        VoiceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(VoiceDeleteParams, CancellationToken)"/>
    Task<VoiceDeleteResponse> Delete(
        string id,
        VoiceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IVoiceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVoiceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVoiceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /legacy/reporting/usage_reports/voice</c>, but is otherwise the
/// same as <see cref="IVoiceService.Create(VoiceCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoiceCreateResponse>> Create(
        VoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /legacy/reporting/usage_reports/voice/{id}</c>, but is otherwise the
/// same as <see cref="IVoiceService.Retrieve(VoiceRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoiceRetrieveResponse>> Retrieve(
        VoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VoiceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<VoiceRetrieveResponse>> Retrieve(
        string id,
        VoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /legacy/reporting/usage_reports/voice</c>, but is otherwise the
/// same as <see cref="IVoiceService.List(VoiceListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoiceListPage>> List(
        VoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /legacy/reporting/usage_reports/voice/{id}</c>, but is otherwise the
/// same as <see cref="IVoiceService.Delete(VoiceDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoiceDeleteResponse>> Delete(
        VoiceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(VoiceDeleteParams, CancellationToken)"/>
    Task<HttpResponse<VoiceDeleteResponse>> Delete(
        string id,
        VoiceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}