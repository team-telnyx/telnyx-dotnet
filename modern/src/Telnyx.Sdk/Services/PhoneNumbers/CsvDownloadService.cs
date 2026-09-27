using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.PhoneNumbers.CsvDownloads;

namespace Telnyx.Sdk.Services.PhoneNumbers;

/// <inheritdoc/>
public sealed class CsvDownloadService : ICsvDownloadService
{
    readonly Lazy<ICsvDownloadServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICsvDownloadServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICsvDownloadService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new CsvDownloadService(this._client.WithOptions(modifier)); }

    public CsvDownloadService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CsvDownloadServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<CsvDownloadCreateResponse> Create(
        CsvDownloadCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CsvDownloadRetrieveResponse> Retrieve(
        CsvDownloadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CsvDownloadRetrieveResponse> Retrieve(
        string id,
        CsvDownloadRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CsvDownloadListPage> List(
        CsvDownloadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CsvDownloadServiceWithRawResponse : ICsvDownloadServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICsvDownloadServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CsvDownloadServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CsvDownloadServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<CsvDownloadCreateResponse>> Create(
        CsvDownloadCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CsvDownloadCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var csvDownload = await response.Deserialize<CsvDownloadCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                csvDownload.Validate();
            }
            return csvDownload;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CsvDownloadRetrieveResponse>> Retrieve(
        CsvDownloadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<CsvDownloadRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var csvDownload = await response.Deserialize<CsvDownloadRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                csvDownload.Validate();
            }
            return csvDownload;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CsvDownloadRetrieveResponse>> Retrieve(
        string id,
        CsvDownloadRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CsvDownloadListPage>> List(
        CsvDownloadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CsvDownloadListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<CsvDownloadListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new CsvDownloadListPage(this, parameters, page);
        });
    }
}