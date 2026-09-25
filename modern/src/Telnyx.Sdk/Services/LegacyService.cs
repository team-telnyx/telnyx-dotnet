using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.Legacy;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class LegacyService : ILegacyService
{
    readonly Lazy<ILegacyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILegacyServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ILegacyService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new LegacyService(this._client.WithOptions(modifier)); }

    public LegacyService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new LegacyServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _reporting =new(() => new ReportingService(client)) ;
    }

    readonly Lazy<IReportingService> _reporting;
    public IReportingService Reporting { get { return _reporting.Value; } }
}

/// <inheritdoc/>
public sealed class LegacyServiceWithRawResponse : ILegacyServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILegacyServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new LegacyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LegacyServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _reporting =new(() => new ReportingServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IReportingServiceWithRawResponse> _reporting;
    public IReportingServiceWithRawResponse Reporting {
        get { return _reporting.Value; }
    }
}