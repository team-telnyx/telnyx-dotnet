using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.PronunciationDicts;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class PronunciationDictService : IPronunciationDictService
{
    readonly Lazy<IPronunciationDictServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPronunciationDictServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPronunciationDictService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new PronunciationDictService(this._client.WithOptions(modifier)); }

    public PronunciationDictService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PronunciationDictServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PronunciationDictResponse> Create(
        PronunciationDictCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PronunciationDictResponse> Retrieve(
        PronunciationDictRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PronunciationDictResponse> Retrieve(
        string id,
        PronunciationDictRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PronunciationDictResponse> Update(
        PronunciationDictUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PronunciationDictResponse> Update(
        string id,
        PronunciationDictUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PronunciationDictListPage> List(
        PronunciationDictListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        PronunciationDictDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        PronunciationDictDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ID = id
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PronunciationDictServiceWithRawResponse : IPronunciationDictServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPronunciationDictServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PronunciationDictServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PronunciationDictServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PronunciationDictResponse>> Create(
        PronunciationDictCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PronunciationDictCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var pronunciationDictResponse = await response.Deserialize<PronunciationDictResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                pronunciationDictResponse.Validate();
            }
            return pronunciationDictResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PronunciationDictResponse>> Retrieve(
        PronunciationDictRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PronunciationDictRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var pronunciationDictResponse = await response.Deserialize<PronunciationDictResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                pronunciationDictResponse.Validate();
            }
            return pronunciationDictResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PronunciationDictResponse>> Retrieve(
        string id,
        PronunciationDictRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PronunciationDictResponse>> Update(
        PronunciationDictUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PronunciationDictUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var pronunciationDictResponse = await response.Deserialize<PronunciationDictResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                pronunciationDictResponse.Validate();
            }
            return pronunciationDictResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PronunciationDictResponse>> Update(
        string id,
        PronunciationDictUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PronunciationDictListPage>> List(
        PronunciationDictListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PronunciationDictListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PronunciationDictListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PronunciationDictListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        PronunciationDictDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PronunciationDictDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        PronunciationDictDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}