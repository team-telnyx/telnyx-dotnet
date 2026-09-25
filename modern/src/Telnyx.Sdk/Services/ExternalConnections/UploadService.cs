using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.ExternalConnections.Uploads;

namespace Telnyx.Sdk.Services.ExternalConnections;

/// <inheritdoc/>
public sealed class UploadService : IUploadService
{
    readonly Lazy<IUploadServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUploadServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IUploadService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new UploadService(this._client.WithOptions(modifier)); }

    public UploadService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new UploadServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<UploadCreateResponse> Create(
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UploadCreateResponse> Create(
        string id,
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UploadRetrieveResponse> Retrieve(
        UploadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UploadRetrieveResponse> Retrieve(
        string ticketID,
        UploadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            TicketID = ticketID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UploadListPage> List(
        UploadListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UploadListPage> List(
        string id,
        UploadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UploadPendingCountResponse> PendingCount(
        UploadPendingCountParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.PendingCount(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UploadPendingCountResponse> PendingCount(
        string id,
        UploadPendingCountParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.PendingCount(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UploadRefreshStatusResponse> RefreshStatus(
        UploadRefreshStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RefreshStatus(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UploadRefreshStatusResponse> RefreshStatus(
        string id,
        UploadRefreshStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RefreshStatus(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UploadRetryResponse> Retry(
        UploadRetryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retry(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UploadRetryResponse> Retry(
        string ticketID,
        UploadRetryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retry(parameters with{
            TicketID = ticketID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class UploadServiceWithRawResponse : IUploadServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUploadServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new UploadServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UploadServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<UploadCreateResponse>> Create(
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<UploadCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var upload = await response.Deserialize<UploadCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                upload.Validate();
            }
            return upload;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UploadCreateResponse>> Create(
        string id,
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UploadRetrieveResponse>> Retrieve(
        UploadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TicketID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.TicketID' cannot be null"
            );
        }

        HttpRequest<UploadRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var upload = await response.Deserialize<UploadRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                upload.Validate();
            }
            return upload;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UploadRetrieveResponse>> Retrieve(
        string ticketID,
        UploadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            TicketID = ticketID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UploadListPage>> List(
        UploadListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<UploadListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<UploadListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new UploadListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UploadListPage>> List(
        string id,
        UploadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UploadPendingCountResponse>> PendingCount(
        UploadPendingCountParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<UploadPendingCountParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<UploadPendingCountResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UploadPendingCountResponse>> PendingCount(
        string id,
        UploadPendingCountParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.PendingCount(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UploadRefreshStatusResponse>> RefreshStatus(
        UploadRefreshStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<UploadRefreshStatusParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<UploadRefreshStatusResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UploadRefreshStatusResponse>> RefreshStatus(
        string id,
        UploadRefreshStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RefreshStatus(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UploadRetryResponse>> Retry(
        UploadRetryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TicketID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.TicketID' cannot be null"
            );
        }

        HttpRequest<UploadRetryParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<UploadRetryResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UploadRetryResponse>> Retry(
        string ticketID,
        UploadRetryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retry(parameters with{
            TicketID = ticketID
        }, cancellationToken);
    }
}