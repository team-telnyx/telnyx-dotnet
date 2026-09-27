using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Reports;
using Telnyx.Sdk.Services.Reports;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class ReportService : IReportService
{
    readonly Lazy<IReportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IReportServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IReportService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ReportService(this._client.WithOptions(modifier)); }

    public ReportService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ReportServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _cdrUsageReports =new(() => new CdrUsageReportService(client)) ;
        _mdrUsageReports =new(() => new MdrUsageReportService(client)) ;
    }

    readonly Lazy<ICdrUsageReportService> _cdrUsageReports;
    public ICdrUsageReportService CdrUsageReports {
        get { return _cdrUsageReports.Value; }
    }

    readonly Lazy<IMdrUsageReportService> _mdrUsageReports;
    public IMdrUsageReportService MdrUsageReports {
        get { return _mdrUsageReports.Value; }
    }

    /// <inheritdoc/>
    public async Task<ReportListMdrsResponse> ListMdrs(
        ReportListMdrsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListMdrs(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ReportListWdrsPage> ListWdrs(
        ReportListWdrsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListWdrs(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ReportServiceWithRawResponse : IReportServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ReportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ReportServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _cdrUsageReports =new(
            () => new CdrUsageReportServiceWithRawResponse(client)
        ) ;
        _mdrUsageReports =new(
            () => new MdrUsageReportServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<ICdrUsageReportServiceWithRawResponse> _cdrUsageReports;
    public ICdrUsageReportServiceWithRawResponse CdrUsageReports {
        get { return _cdrUsageReports.Value; }
    }

    readonly Lazy<IMdrUsageReportServiceWithRawResponse> _mdrUsageReports;
    public IMdrUsageReportServiceWithRawResponse MdrUsageReports {
        get { return _mdrUsageReports.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReportListMdrsResponse>> ListMdrs(
        ReportListMdrsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ReportListMdrsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ReportListMdrsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReportListWdrsPage>> ListWdrs(
        ReportListWdrsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ReportListWdrsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ReportListWdrsPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ReportListWdrsPage(this, parameters, page);
        });
    }
}