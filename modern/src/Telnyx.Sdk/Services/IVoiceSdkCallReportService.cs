using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.VoiceSdkCallReports;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Retrieve raw Voice SDK call report stats payloads for WebRTC call troubleshooting.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVoiceSdkCallReportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVoiceSdkCallReportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVoiceSdkCallReportService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns raw call report stats JSON payloads stored for the authenticated user
/// and `call_id`. The user is derived from Telnyx authentication, not from request
/// parameters.
/// </summary>
    Task<List<VoiceSdkCallReport>> Retrieve(
        VoiceSdkCallReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VoiceSdkCallReportRetrieveParams, CancellationToken)"/>
    Task<List<VoiceSdkCallReport>> Retrieve(
        string callID,
        VoiceSdkCallReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns paginated raw call report stats JSON payloads stored for the
/// authenticated user. The user is derived from Telnyx authentication, not from
/// request parameters.
/// </summary>
    Task<VoiceSdkCallReportListPage> List(
        VoiceSdkCallReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IVoiceSdkCallReportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVoiceSdkCallReportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVoiceSdkCallReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /voice_sdk_call_reports/{call_id}</c>, but is otherwise the
/// same as <see cref="IVoiceSdkCallReportService.Retrieve(VoiceSdkCallReportRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<List<VoiceSdkCallReport>>> Retrieve(
        VoiceSdkCallReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VoiceSdkCallReportRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<List<VoiceSdkCallReport>>> Retrieve(
        string callID,
        VoiceSdkCallReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /voice_sdk_call_reports</c>, but is otherwise the
/// same as <see cref="IVoiceSdkCallReportService.List(VoiceSdkCallReportListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoiceSdkCallReportListPage>> List(
        VoiceSdkCallReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}