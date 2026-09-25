using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.OpenAI.Embeddings;

namespace Telnyx.Sdk.Services.AI.OpenAI;

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
    }

    /// <inheritdoc/>
    public async Task<EmbeddingCreateEmbeddingsResponse> CreateEmbeddings(
        EmbeddingCreateEmbeddingsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CreateEmbeddings(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmbeddingListEmbeddingModelsResponse> ListEmbeddingModels(
        EmbeddingListEmbeddingModelsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListEmbeddingModels(parameters, cancellationToken).ConfigureAwait(false);
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
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmbeddingCreateEmbeddingsResponse>> CreateEmbeddings(
        EmbeddingCreateEmbeddingsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EmbeddingCreateEmbeddingsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<EmbeddingCreateEmbeddingsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmbeddingListEmbeddingModelsResponse>> ListEmbeddingModels(
        EmbeddingListEmbeddingModelsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EmbeddingListEmbeddingModelsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<EmbeddingListEmbeddingModelsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}