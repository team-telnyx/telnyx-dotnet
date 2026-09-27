using System;
using Telnyx.Sdk.Core;
using Reporting = Telnyx.Sdk.Services.Legacy.Reporting;

namespace Telnyx.Sdk.Services.Legacy;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IReportingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IReportingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReportingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Reporting::IBatchDetailRecordService BatchDetailRecords { get; }

    Reporting::IUsageReportService UsageReports { get; }
}

/// <summary>
/// A view of <see cref="IReportingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IReportingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReportingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Reporting::IBatchDetailRecordServiceWithRawResponse BatchDetailRecords {
        get;
    }

    Reporting::IUsageReportServiceWithRawResponse UsageReports { get; }
}