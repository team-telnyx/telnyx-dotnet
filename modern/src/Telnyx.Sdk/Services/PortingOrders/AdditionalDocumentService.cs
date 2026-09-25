using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.PortingOrders.AdditionalDocuments;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <inheritdoc/>
public sealed class AdditionalDocumentService : IAdditionalDocumentService
{
    readonly Lazy<IAdditionalDocumentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAdditionalDocumentServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAdditionalDocumentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AdditionalDocumentService(this._client.WithOptions(modifier));
    }

    public AdditionalDocumentService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AdditionalDocumentServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<AdditionalDocumentCreateResponse> Create(
        AdditionalDocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AdditionalDocumentCreateResponse> Create(
        string id,
        AdditionalDocumentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AdditionalDocumentListPage> List(
        AdditionalDocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AdditionalDocumentListPage> List(
        string id,
        AdditionalDocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        AdditionalDocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string additionalDocumentID,
        AdditionalDocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with{
            AdditionalDocumentID = additionalDocumentID
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AdditionalDocumentServiceWithRawResponse : IAdditionalDocumentServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAdditionalDocumentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AdditionalDocumentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AdditionalDocumentServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<AdditionalDocumentCreateResponse>> Create(
        AdditionalDocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<AdditionalDocumentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var additionalDocument = await response.Deserialize<AdditionalDocumentCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                additionalDocument.Validate();
            }
            return additionalDocument;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AdditionalDocumentCreateResponse>> Create(
        string id,
        AdditionalDocumentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AdditionalDocumentListPage>> List(
        AdditionalDocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<AdditionalDocumentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<AdditionalDocumentListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new AdditionalDocumentListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AdditionalDocumentListPage>> List(
        string id,
        AdditionalDocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        AdditionalDocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AdditionalDocumentID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AdditionalDocumentID' cannot be null"
            );
        }

        HttpRequest<AdditionalDocumentDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string additionalDocumentID,
        AdditionalDocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            AdditionalDocumentID = additionalDocumentID
        }, cancellationToken);
    }
}