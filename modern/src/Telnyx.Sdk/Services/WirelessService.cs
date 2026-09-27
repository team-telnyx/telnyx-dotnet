using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Wireless;
using Telnyx.Sdk.Services.Wireless;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class WirelessService : IWirelessService
{
    readonly Lazy<IWirelessServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWirelessServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IWirelessService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new WirelessService(this._client.WithOptions(modifier)); }

    public WirelessService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new WirelessServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _detailRecordsReports =new(
            () => new DetailRecordsReportService(client)
        ) ;
    }

    readonly Lazy<IDetailRecordsReportService> _detailRecordsReports;
    public IDetailRecordsReportService DetailRecordsReports {
        get { return _detailRecordsReports.Value; }
    }

    /// <inheritdoc/>
    public async Task<WirelessRetrieveRegionsResponse> RetrieveRegions(
        WirelessRetrieveRegionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveRegions(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class WirelessServiceWithRawResponse : IWirelessServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWirelessServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WirelessServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WirelessServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _detailRecordsReports =new(
            () => new DetailRecordsReportServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<IDetailRecordsReportServiceWithRawResponse> _detailRecordsReports;
    public IDetailRecordsReportServiceWithRawResponse DetailRecordsReports {
        get { return _detailRecordsReports.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WirelessRetrieveRegionsResponse>> RetrieveRegions(
        WirelessRetrieveRegionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WirelessRetrieveRegionsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<WirelessRetrieveRegionsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}