using System;
using Telnyx.Sdk.Core;
using Reporting = Telnyx.Sdk.Services.Legacy.Reporting;

namespace Telnyx.Sdk.Services.Legacy;

/// <inheritdoc/>
public sealed class ReportingService : IReportingService
{
    readonly Lazy<IReportingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IReportingServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IReportingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ReportingService(this._client.WithOptions(modifier)); }

    public ReportingService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ReportingServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _batchDetailRecords =new(
            () => new Reporting::BatchDetailRecordService(client)
        ) ;
        _usageReports =new(() => new Reporting::UsageReportService(client)) ;
    }

    readonly Lazy<Reporting::IBatchDetailRecordService> _batchDetailRecords;
    public Reporting::IBatchDetailRecordService BatchDetailRecords {
        get { return _batchDetailRecords.Value; }
    }

    readonly Lazy<Reporting::IUsageReportService> _usageReports;
    public Reporting::IUsageReportService UsageReports {
        get { return _usageReports.Value; }
    }
}

/// <inheritdoc/>
public sealed class ReportingServiceWithRawResponse : IReportingServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IReportingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ReportingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ReportingServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _batchDetailRecords =new(
            () => new Reporting::BatchDetailRecordServiceWithRawResponse(client)
        ) ;
        _usageReports =new(
            () => new Reporting::UsageReportServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<Reporting::IBatchDetailRecordServiceWithRawResponse> _batchDetailRecords;
    public Reporting::IBatchDetailRecordServiceWithRawResponse BatchDetailRecords {
        get { return _batchDetailRecords.Value; }
    }

    readonly Lazy<Reporting::IUsageReportServiceWithRawResponse> _usageReports;
    public Reporting::IUsageReportServiceWithRawResponse UsageReports {
        get { return _usageReports.Value; }
    }
}