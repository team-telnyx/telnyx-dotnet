using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.VoiceSdkCallReports;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class VoiceSdkCallReportService : IVoiceSdkCallReportService
{
    readonly Lazy<IVoiceSdkCallReportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVoiceSdkCallReportServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IVoiceSdkCallReportService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VoiceSdkCallReportService(this._client.WithOptions(modifier));
    }

    public VoiceSdkCallReportService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new VoiceSdkCallReportServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<List<VoiceSdkCallReport>> Retrieve(
        VoiceSdkCallReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<List<VoiceSdkCallReport>> Retrieve(
        string callID,
        VoiceSdkCallReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            CallID = callID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VoiceSdkCallReportListPage> List(
        VoiceSdkCallReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class VoiceSdkCallReportServiceWithRawResponse : IVoiceSdkCallReportServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVoiceSdkCallReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VoiceSdkCallReportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VoiceSdkCallReportServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<VoiceSdkCallReport>>> Retrieve(
        VoiceSdkCallReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallID' cannot be null"
            );
        }

        HttpRequest<VoiceSdkCallReportRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var voiceSdkCallReports = await response.Deserialize<List<VoiceSdkCallReport>>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                foreach (var item in voiceSdkCallReports)
                {
                    item.Validate();
                }
            }
            return voiceSdkCallReports;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<List<VoiceSdkCallReport>>> Retrieve(
        string callID,
        VoiceSdkCallReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            CallID = callID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VoiceSdkCallReportListPage>> List(
        VoiceSdkCallReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<VoiceSdkCallReportListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<VoiceSdkCallReportListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new VoiceSdkCallReportListPage(this, parameters, page);
        });
    }
}