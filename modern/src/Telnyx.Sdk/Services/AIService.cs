using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI;
using Telnyx.Sdk.Services.AI;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class AIService : IAIService
{
    readonly Lazy<IAIServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAIServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAIService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new AIService(this._client.WithOptions(modifier)); }

    public AIService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AIServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _assistants =new(() => new AssistantService(client)) ;
        _audio =new(() => new AudioService(client)) ;
        _chat =new(() => new ChatService(client)) ;
        _clusters =new(() => new ClusterService(client)) ;
        _collections =new(() => new CollectionService(client)) ;
        _conversations =new(() => new ConversationService(client)) ;
        _embeddings =new(() => new EmbeddingService(client)) ;
        _fineTuning =new(() => new FineTuningService(client)) ;
        _integrations =new(() => new IntegrationService(client)) ;
        _mcpServers =new(() => new McpServerService(client)) ;
        _missions =new(() => new MissionService(client)) ;
        _openai =new(() => new OpenAIService(client)) ;
        _tools =new(() => new ToolService(client)) ;
        _anthropic =new(() => new AnthropicService(client)) ;
        _knowledge =new(() => new KnowledgeService(client)) ;
        _typesafe =new(() => new TypesafeService(client)) ;
        _memory =new(() => new MemoryService(client)) ;
    }

    readonly Lazy<IAssistantService> _assistants;
    public IAssistantService Assistants { get { return _assistants.Value; } }

    readonly Lazy<IAudioService> _audio;
    public IAudioService Audio { get { return _audio.Value; } }

    readonly Lazy<IChatService> _chat;
    public IChatService Chat { get { return _chat.Value; } }

    readonly Lazy<IClusterService> _clusters;
    public IClusterService Clusters { get { return _clusters.Value; } }

    readonly Lazy<ICollectionService> _collections;
    public ICollectionService Collections { get { return _collections.Value; } }

    readonly Lazy<IConversationService> _conversations;
    public IConversationService Conversations {
        get { return _conversations.Value; }
    }

    readonly Lazy<IEmbeddingService> _embeddings;
    public IEmbeddingService Embeddings { get { return _embeddings.Value; } }

    readonly Lazy<IFineTuningService> _fineTuning;
    public IFineTuningService FineTuning { get { return _fineTuning.Value; } }

    readonly Lazy<IIntegrationService> _integrations;
    public IIntegrationService Integrations {
        get { return _integrations.Value; }
    }

    readonly Lazy<IMcpServerService> _mcpServers;
    public IMcpServerService McpServers { get { return _mcpServers.Value; } }

    readonly Lazy<IMissionService> _missions;
    public IMissionService Missions { get { return _missions.Value; } }

    readonly Lazy<IOpenAIService> _openai;
    public IOpenAIService OpenAI { get { return _openai.Value; } }

    readonly Lazy<IToolService> _tools;
    public IToolService Tools { get { return _tools.Value; } }

    readonly Lazy<IAnthropicService> _anthropic;
    public IAnthropicService Anthropic { get { return _anthropic.Value; } }

    readonly Lazy<IKnowledgeService> _knowledge;
    public IKnowledgeService Knowledge { get { return _knowledge.Value; } }

    readonly Lazy<ITypesafeService> _typesafe;
    public ITypesafeService Typesafe { get { return _typesafe.Value; } }

    readonly Lazy<IMemoryService> _memory;
    public IMemoryService Memory { get { return _memory.Value; } }

    /// <inheritdoc/>
    public async Task<AIRetrieveConversationHistoriesPage> RetrieveConversationHistories(
        AIRetrieveConversationHistoriesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveConversationHistories(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AISummarizeResponse> Summarize(
        AISummarizeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Summarize(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AIServiceWithRawResponse : IAIServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAIServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new AIServiceWithRawResponse(this._client.WithOptions(modifier)); }

    public AIServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _assistants =new(() => new AssistantServiceWithRawResponse(client)) ;
        _audio =new(() => new AudioServiceWithRawResponse(client)) ;
        _chat =new(() => new ChatServiceWithRawResponse(client)) ;
        _clusters =new(() => new ClusterServiceWithRawResponse(client)) ;
        _collections =new(() => new CollectionServiceWithRawResponse(client)) ;
        _conversations =new(
            () => new ConversationServiceWithRawResponse(client)
        ) ;
        _embeddings =new(() => new EmbeddingServiceWithRawResponse(client)) ;
        _fineTuning =new(() => new FineTuningServiceWithRawResponse(client)) ;
        _integrations =new(
            () => new IntegrationServiceWithRawResponse(client)
        ) ;
        _mcpServers =new(() => new McpServerServiceWithRawResponse(client)) ;
        _missions =new(() => new MissionServiceWithRawResponse(client)) ;
        _openai =new(() => new OpenAIServiceWithRawResponse(client)) ;
        _tools =new(() => new ToolServiceWithRawResponse(client)) ;
        _anthropic =new(() => new AnthropicServiceWithRawResponse(client)) ;
        _knowledge =new(() => new KnowledgeServiceWithRawResponse(client)) ;
        _typesafe =new(() => new TypesafeServiceWithRawResponse(client)) ;
        _memory =new(() => new MemoryServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IAssistantServiceWithRawResponse> _assistants;
    public IAssistantServiceWithRawResponse Assistants {
        get { return _assistants.Value; }
    }

    readonly Lazy<IAudioServiceWithRawResponse> _audio;
    public IAudioServiceWithRawResponse Audio { get { return _audio.Value; } }

    readonly Lazy<IChatServiceWithRawResponse> _chat;
    public IChatServiceWithRawResponse Chat { get { return _chat.Value; } }

    readonly Lazy<IClusterServiceWithRawResponse> _clusters;
    public IClusterServiceWithRawResponse Clusters {
        get { return _clusters.Value; }
    }

    readonly Lazy<ICollectionServiceWithRawResponse> _collections;
    public ICollectionServiceWithRawResponse Collections {
        get { return _collections.Value; }
    }

    readonly Lazy<IConversationServiceWithRawResponse> _conversations;
    public IConversationServiceWithRawResponse Conversations {
        get { return _conversations.Value; }
    }

    readonly Lazy<IEmbeddingServiceWithRawResponse> _embeddings;
    public IEmbeddingServiceWithRawResponse Embeddings {
        get { return _embeddings.Value; }
    }

    readonly Lazy<IFineTuningServiceWithRawResponse> _fineTuning;
    public IFineTuningServiceWithRawResponse FineTuning {
        get { return _fineTuning.Value; }
    }

    readonly Lazy<IIntegrationServiceWithRawResponse> _integrations;
    public IIntegrationServiceWithRawResponse Integrations {
        get { return _integrations.Value; }
    }

    readonly Lazy<IMcpServerServiceWithRawResponse> _mcpServers;
    public IMcpServerServiceWithRawResponse McpServers {
        get { return _mcpServers.Value; }
    }

    readonly Lazy<IMissionServiceWithRawResponse> _missions;
    public IMissionServiceWithRawResponse Missions {
        get { return _missions.Value; }
    }

    readonly Lazy<IOpenAIServiceWithRawResponse> _openai;
    public IOpenAIServiceWithRawResponse OpenAI {
        get { return _openai.Value; }
    }

    readonly Lazy<IToolServiceWithRawResponse> _tools;
    public IToolServiceWithRawResponse Tools { get { return _tools.Value; } }

    readonly Lazy<IAnthropicServiceWithRawResponse> _anthropic;
    public IAnthropicServiceWithRawResponse Anthropic {
        get { return _anthropic.Value; }
    }

    readonly Lazy<IKnowledgeServiceWithRawResponse> _knowledge;
    public IKnowledgeServiceWithRawResponse Knowledge {
        get { return _knowledge.Value; }
    }

    readonly Lazy<ITypesafeServiceWithRawResponse> _typesafe;
    public ITypesafeServiceWithRawResponse Typesafe {
        get { return _typesafe.Value; }
    }

    readonly Lazy<IMemoryServiceWithRawResponse> _memory;
    public IMemoryServiceWithRawResponse Memory {
        get { return _memory.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AIRetrieveConversationHistoriesPage>> RetrieveConversationHistories(
        AIRetrieveConversationHistoriesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AIRetrieveConversationHistoriesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<AIRetrieveConversationHistoriesPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new AIRetrieveConversationHistoriesPage(this,
            parameters,
            page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AISummarizeResponse>> Summarize(
        AISummarizeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AISummarizeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<AISummarizeResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}