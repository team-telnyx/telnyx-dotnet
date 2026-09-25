using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Storage.Kvs.Keys;

namespace Telnyx.Sdk.Services.Storage.Kvs;

/// <inheritdoc/>
public sealed class KeyService : IKeyService
{
    readonly Lazy<IKeyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IKeyServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new KeyService(this._client.WithOptions(modifier)); }

    public KeyService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new KeyServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        KeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Retrieve(parameters, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        string key,
        KeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            Key = key
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Update(
        KeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Update(
        string key,
        BinaryContent body,
        KeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with{
            Key = key,
            Body = body,
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<KeyListPage> List(
        KeyListParams parameters, CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<KeyListPage> List(
        string id,
        KeyListParams? parameters = null,
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
        KeyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string key,
        KeyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with{
            Key = key
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class KeyServiceWithRawResponse : IKeyServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IKeyServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new KeyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public KeyServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        KeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Key == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Key' cannot be null"
            );
        }

        HttpRequest<KeyRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        string key,
        KeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            Key = key
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        KeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Key == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Key' cannot be null"
            );
        }
        if (parameters.Body == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Body' cannot be null"
            );
        }

        HttpRequest<KeyUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Update(
        string key,
        BinaryContent body,
        KeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            Key = key,
            Body = body,
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<KeyListPage>> List(
        KeyListParams parameters, CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<KeyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<KeyListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new KeyListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<KeyListPage>> List(
        string id,
        KeyListParams? parameters = null,
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
        KeyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Key == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Key' cannot be null"
            );
        }

        HttpRequest<KeyDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string key,
        KeyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            Key = key
        }, cancellationToken);
    }
}