using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Embeddings;
using Telnyx.Sdk.Services.AI.Embeddings;

namespace Telnyx.Sdk.Services.AI;

/// <inheritdoc/>
public sealed class EmbeddingService : IEmbeddingService
{
    readonly Lazy<IEmbeddingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEmbeddingServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IEmbeddingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new EmbeddingService(this._client.WithOptions(modifier)); }

    public EmbeddingService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new EmbeddingServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _buckets =new(() => new BucketService(client)) ;
    }

    readonly Lazy<IBucketService> _buckets;
    public IBucketService Buckets { get { return _buckets.Value; } }

    /// <inheritdoc/>
    public async Task<EmbeddingResponse> Create(
        EmbeddingCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmbeddingRetrieveResponse> Retrieve(
        EmbeddingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmbeddingRetrieveResponse> Retrieve(
        string taskID,
        EmbeddingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            TaskID = taskID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmbeddingListResponse> List(
        EmbeddingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmbeddingSimilaritySearchResponse> SimilaritySearch(
        EmbeddingSimilaritySearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SimilaritySearch(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmbeddingResponse> Url(
        EmbeddingUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Url(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EmbeddingServiceWithRawResponse : IEmbeddingServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEmbeddingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EmbeddingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EmbeddingServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _buckets =new(() => new BucketServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IBucketServiceWithRawResponse> _buckets;
    public IBucketServiceWithRawResponse Buckets {
        get { return _buckets.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmbeddingResponse>> Create(
        EmbeddingCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EmbeddingCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var embeddingResponse = await response.Deserialize<EmbeddingResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                embeddingResponse.Validate();
            }
            return embeddingResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmbeddingRetrieveResponse>> Retrieve(
        EmbeddingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TaskID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.TaskID' cannot be null"
            );
        }

        HttpRequest<EmbeddingRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var embedding = await response.Deserialize<EmbeddingRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                embedding.Validate();
            }
            return embedding;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmbeddingRetrieveResponse>> Retrieve(
        string taskID,
        EmbeddingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            TaskID = taskID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmbeddingListResponse>> List(
        EmbeddingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EmbeddingListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var embeddings = await response.Deserialize<EmbeddingListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                embeddings.Validate();
            }
            return embeddings;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmbeddingSimilaritySearchResponse>> SimilaritySearch(
        EmbeddingSimilaritySearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EmbeddingSimilaritySearchParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<EmbeddingSimilaritySearchResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmbeddingResponse>> Url(
        EmbeddingUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EmbeddingUrlParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var embeddingResponse = await response.Deserialize<EmbeddingResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                embeddingResponse.Validate();
            }
            return embeddingResponse;
        });
    }
}