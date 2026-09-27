using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Legacy.Reporting.UsageReports;
using UsageReports = Telnyx.Sdk.Services.Legacy.Reporting.UsageReports;

namespace Telnyx.Sdk.Services.Legacy.Reporting;

/// <summary>
/// Speech to text usage reports
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

    UsageReports::IMessagingService Messaging { get; }

    UsageReports::INumberLookupService NumberLookup { get; }

    UsageReports::IVoiceService Voice { get; }

    /// <summary>
/// Generate and fetch speech to text usage report synchronously. This endpoint will
/// both generate and fetch the speech to text report over a specified time period.
/// </summary>
    Task<UsageReportRetrieveSpeechToTextResponse> RetrieveSpeechToText(
        UsageReportRetrieveSpeechToTextParams? parameters = null,
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

    UsageReports::IMessagingServiceWithRawResponse Messaging { get; }

    UsageReports::INumberLookupServiceWithRawResponse NumberLookup { get; }

    UsageReports::IVoiceServiceWithRawResponse Voice { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /legacy/reporting/usage_reports/speech_to_text</c>, but is otherwise the
/// same as <see cref="IUsageReportService.RetrieveSpeechToText(UsageReportRetrieveSpeechToTextParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UsageReportRetrieveSpeechToTextResponse>> RetrieveSpeechToText(
        UsageReportRetrieveSpeechToTextParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}