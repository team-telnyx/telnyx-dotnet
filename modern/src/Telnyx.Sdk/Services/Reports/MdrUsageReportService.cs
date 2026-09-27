using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Reports.MdrUsageReports;

namespace Telnyx.Sdk.Services.Reports;

/// <inheritdoc/>
public sealed class MdrUsageReportService : IMdrUsageReportService
{
    readonly Lazy<IMdrUsageReportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMdrUsageReportServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMdrUsageReportService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MdrUsageReportService(this._client.WithOptions(modifier)); }

    public MdrUsageReportService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MdrUsageReportServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MdrUsageReportCreateResponse> Create(
        MdrUsageReportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MdrUsageReportRetrieveResponse> Retrieve(
        MdrUsageReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MdrUsageReportRetrieveResponse> Retrieve(
        string id,
        MdrUsageReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MdrUsageReportListPage> List(
        MdrUsageReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MdrUsageReportDeleteResponse> Delete(
        MdrUsageReportDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MdrUsageReportDeleteResponse> Delete(
        string id,
        MdrUsageReportDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MdrUsageReportFetchSyncResponse> FetchSync(
        MdrUsageReportFetchSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.FetchSync(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MdrUsageReportServiceWithRawResponse : IMdrUsageReportServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMdrUsageReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MdrUsageReportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MdrUsageReportServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MdrUsageReportCreateResponse>> Create(
        MdrUsageReportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MdrUsageReportCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var mdrUsageReport = await response.Deserialize<MdrUsageReportCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                mdrUsageReport.Validate();
            }
            return mdrUsageReport;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MdrUsageReportRetrieveResponse>> Retrieve(
        MdrUsageReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MdrUsageReportRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var mdrUsageReport = await response.Deserialize<MdrUsageReportRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                mdrUsageReport.Validate();
            }
            return mdrUsageReport;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MdrUsageReportRetrieveResponse>> Retrieve(
        string id,
        MdrUsageReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MdrUsageReportListPage>> List(
        MdrUsageReportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MdrUsageReportListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MdrUsageReportListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MdrUsageReportListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MdrUsageReportDeleteResponse>> Delete(
        MdrUsageReportDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MdrUsageReportDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var mdrUsageReport = await response.Deserialize<MdrUsageReportDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                mdrUsageReport.Validate();
            }
            return mdrUsageReport;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MdrUsageReportDeleteResponse>> Delete(
        string id,
        MdrUsageReportDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MdrUsageReportFetchSyncResponse>> FetchSync(
        MdrUsageReportFetchSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MdrUsageReportFetchSyncParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MdrUsageReportFetchSyncResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}