using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Storage.Kvs;
using Telnyx.Sdk.Services.Storage.Kvs;

namespace Telnyx.Sdk.Services.Storage;

/// <inheritdoc/>
public sealed class KvService : IKvService
{
    readonly Lazy<IKvServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IKvServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IKvService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new KvService(this._client.WithOptions(modifier)); }

    public KvService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new KvServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _keys =new(() => new KeyService(client)) ;
    }

    readonly Lazy<IKeyService> _keys;
    public IKeyService Keys { get { return _keys.Value; } }

    /// <inheritdoc/>
    public async Task<KvNamespaceResponseWrapper> Create(
        KvCreateParams parameters, CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<KvNamespaceResponseWrapper> Retrieve(
        KvRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<KvNamespaceResponseWrapper> Retrieve(
        string id,
        KvRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<KvListPage> List(
        KvListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<KvNamespaceResponseWrapper> Delete(
        KvDeleteParams parameters, CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<KvNamespaceResponseWrapper> Delete(
        string id,
        KvDeleteParams? parameters = null,
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
public sealed class KvServiceWithRawResponse : IKvServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IKvServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new KvServiceWithRawResponse(this._client.WithOptions(modifier)); }

    public KvServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _keys =new(() => new KeyServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IKeyServiceWithRawResponse> _keys;
    public IKeyServiceWithRawResponse Keys { get { return _keys.Value; } }

    /// <inheritdoc/>
    public async Task<HttpResponse<KvNamespaceResponseWrapper>> Create(
        KvCreateParams parameters, CancellationToken cancellationToken = default
    )
    {
        HttpRequest<KvCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var kvNamespaceResponseWrapper = await response.Deserialize<KvNamespaceResponseWrapper>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                kvNamespaceResponseWrapper.Validate();
            }
            return kvNamespaceResponseWrapper;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<KvNamespaceResponseWrapper>> Retrieve(
        KvRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<KvRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var kvNamespaceResponseWrapper = await response.Deserialize<KvNamespaceResponseWrapper>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                kvNamespaceResponseWrapper.Validate();
            }
            return kvNamespaceResponseWrapper;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<KvNamespaceResponseWrapper>> Retrieve(
        string id,
        KvRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<KvListPage>> List(
        KvListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<KvListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<KvListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new KvListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<KvNamespaceResponseWrapper>> Delete(
        KvDeleteParams parameters, CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<KvDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var kvNamespaceResponseWrapper = await response.Deserialize<KvNamespaceResponseWrapper>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                kvNamespaceResponseWrapper.Validate();
            }
            return kvNamespaceResponseWrapper;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<KvNamespaceResponseWrapper>> Delete(
        string id,
        KvDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}