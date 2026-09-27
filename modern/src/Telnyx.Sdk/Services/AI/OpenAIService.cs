using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI;
using Telnyx.Sdk.Models.AI.OpenAI;
using OpenAI = Telnyx.Sdk.Services.AI.OpenAI;

namespace Telnyx.Sdk.Services.AI;

/// <inheritdoc/>
public sealed class OpenAIService : IOpenAIService
{
    readonly Lazy<IOpenAIServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOpenAIServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IOpenAIService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new OpenAIService(this._client.WithOptions(modifier)); }

    public OpenAIService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new OpenAIServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _embeddings =new(() => new OpenAI::EmbeddingService(client)) ;
        _chat =new(() => new OpenAI::ChatService(client)) ;
    }

    readonly Lazy<OpenAI::IEmbeddingService> _embeddings;
    public OpenAI::IEmbeddingService Embeddings {
        get { return _embeddings.Value; }
    }

    readonly Lazy<OpenAI::IChatService> _chat;
    public OpenAI::IChatService Chat { get { return _chat.Value; } }

    /// <inheritdoc/>
    public async Task<Dictionary<string, JsonElement>> CreateResponse(
        OpenAICreateResponseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CreateResponse(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ModelsResponse> ListModels(
        OpenAIListModelsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListModels(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class OpenAIServiceWithRawResponse : IOpenAIServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOpenAIServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new OpenAIServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OpenAIServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _embeddings =new(
            () => new OpenAI::EmbeddingServiceWithRawResponse(client)
        ) ;
        _chat =new(() => new OpenAI::ChatServiceWithRawResponse(client)) ;
    }

    readonly Lazy<OpenAI::IEmbeddingServiceWithRawResponse> _embeddings;
    public OpenAI::IEmbeddingServiceWithRawResponse Embeddings {
        get { return _embeddings.Value; }
    }

    readonly Lazy<OpenAI::IChatServiceWithRawResponse> _chat;
    public OpenAI::IChatServiceWithRawResponse Chat {
        get { return _chat.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, JsonElement>>> CreateResponse(
        OpenAICreateResponseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OpenAICreateResponseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<Dictionary<string, JsonElement>>(token).ConfigureAwait(false);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ModelsResponse>> ListModels(
        OpenAIListModelsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OpenAIListModelsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var modelsResponse = await response.Deserialize<ModelsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                modelsResponse.Validate();
            }
            return modelsResponse;
        });
    }
}