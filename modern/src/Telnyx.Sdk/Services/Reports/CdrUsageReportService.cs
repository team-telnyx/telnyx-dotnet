using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Reports.CdrUsageReports;

namespace Telnyx.Sdk.Services.Reports;

/// <inheritdoc/>
public sealed class CdrUsageReportService : ICdrUsageReportService
{
    readonly Lazy<ICdrUsageReportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICdrUsageReportServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICdrUsageReportService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new CdrUsageReportService(this._client.WithOptions(modifier)); }

    public CdrUsageReportService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CdrUsageReportServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<CdrUsageReportFetchSyncResponse> FetchSync(
        CdrUsageReportFetchSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.FetchSync(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CdrUsageReportServiceWithRawResponse : ICdrUsageReportServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICdrUsageReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CdrUsageReportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CdrUsageReportServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<CdrUsageReportFetchSyncResponse>> FetchSync(
        CdrUsageReportFetchSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CdrUsageReportFetchSyncParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CdrUsageReportFetchSyncResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}