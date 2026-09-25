using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Wireless.DetailRecordsReports;

namespace Telnyx.Sdk.Services.Wireless;

/// <inheritdoc/>
public sealed class DetailRecordsReportService : IDetailRecordsReportService
{
    readonly Lazy<IDetailRecordsReportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDetailRecordsReportServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IDetailRecordsReportService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DetailRecordsReportService(this._client.WithOptions(modifier));
    }

    public DetailRecordsReportService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new DetailRecordsReportServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<DetailRecordsReportCreateResponse> Create(
        DetailRecordsReportCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DetailRecordsReportRetrieveResponse> Retrieve(
        DetailRecordsReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DetailRecordsReportRetrieveResponse> Retrieve(
        string id,
        DetailRecordsReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DetailRecordsReportListResponse> List(
        DetailRecordsReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DetailRecordsReportDeleteResponse> Delete(
        DetailRecordsReportDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DetailRecordsReportDeleteResponse> Delete(
        string id,
        DetailRecordsReportDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DetailRecordsReportServiceWithRawResponse : IDetailRecordsReportServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDetailRecordsReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DetailRecordsReportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DetailRecordsReportServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<DetailRecordsReportCreateResponse>> Create(
        DetailRecordsReportCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DetailRecordsReportCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var detailRecordsReport = await response.Deserialize<DetailRecordsReportCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                detailRecordsReport.Validate();
            }
            return detailRecordsReport;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DetailRecordsReportRetrieveResponse>> Retrieve(
        DetailRecordsReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<DetailRecordsReportRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var detailRecordsReport = await response.Deserialize<DetailRecordsReportRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                detailRecordsReport.Validate();
            }
            return detailRecordsReport;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DetailRecordsReportRetrieveResponse>> Retrieve(
        string id,
        DetailRecordsReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DetailRecordsReportListResponse>> List(
        DetailRecordsReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DetailRecordsReportListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var detailRecordsReports = await response.Deserialize<DetailRecordsReportListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                detailRecordsReports.Validate();
            }
            return detailRecordsReports;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DetailRecordsReportDeleteResponse>> Delete(
        DetailRecordsReportDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<DetailRecordsReportDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var detailRecordsReport = await response.Deserialize<DetailRecordsReportDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                detailRecordsReport.Validate();
            }
            return detailRecordsReport;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DetailRecordsReportDeleteResponse>> Delete(
        string id,
        DetailRecordsReportDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}