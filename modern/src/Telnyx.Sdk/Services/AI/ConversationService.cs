using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Conversations;
using Conversations = Telnyx.Sdk.Services.AI.Conversations;

namespace Telnyx.Sdk.Services.AI;

/// <inheritdoc/>
public sealed class ConversationService : IConversationService
{
    readonly Lazy<IConversationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IConversationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IConversationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ConversationService(this._client.WithOptions(modifier)); }

    public ConversationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ConversationServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _insightGroups =new(
            () => new Conversations::InsightGroupService(client)
        ) ;
        _insights =new(() => new Conversations::InsightService(client)) ;
        _messages =new(() => new Conversations::MessageService(client)) ;
        _conversationInsights =new(
            () => new Conversations::ConversationInsightService(client)
        ) ;
    }

    readonly Lazy<Conversations::IInsightGroupService> _insightGroups;
    public Conversations::IInsightGroupService InsightGroups {
        get { return _insightGroups.Value; }
    }

    readonly Lazy<Conversations::IInsightService> _insights;
    public Conversations::IInsightService Insights {
        get { return _insights.Value; }
    }

    readonly Lazy<Conversations::IMessageService> _messages;
    public Conversations::IMessageService Messages {
        get { return _messages.Value; }
    }

    readonly Lazy<Conversations::IConversationInsightService> _conversationInsights;
    public Conversations::IConversationInsightService ConversationInsights {
        get { return _conversationInsights.Value; }
    }

    /// <inheritdoc/>
    public async Task<Conversation> Create(
        ConversationCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ConversationRetrieveResponse> Retrieve(
        ConversationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ConversationRetrieveResponse> Retrieve(
        string conversationID,
        ConversationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ConversationID = conversationID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ConversationUpdateResponse> Update(
        ConversationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ConversationUpdateResponse> Update(
        string conversationID,
        ConversationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ConversationID = conversationID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ConversationListResponse> List(
        ConversationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        ConversationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string conversationID,
        ConversationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ConversationID = conversationID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task AddMessage(
        ConversationAddMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.AddMessage(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task AddMessage(
        string conversationID,
        ConversationAddMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.AddMessage(parameters with{
            ConversationID = conversationID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ConversationRetrieveConversationsInsightsResponse> RetrieveConversationsInsights(
        ConversationRetrieveConversationsInsightsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveConversationsInsights(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ConversationRetrieveConversationsInsightsResponse> RetrieveConversationsInsights(
        string conversationID,
        ConversationRetrieveConversationsInsightsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveConversationsInsights(parameters with{
            ConversationID = conversationID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ConversationServiceWithRawResponse : IConversationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IConversationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ConversationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ConversationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _insightGroups =new(
            () => new Conversations::InsightGroupServiceWithRawResponse(client)
        ) ;
        _insights =new(
            () => new Conversations::InsightServiceWithRawResponse(client)
        ) ;
        _messages =new(
            () => new Conversations::MessageServiceWithRawResponse(client)
        ) ;
        _conversationInsights =new(
            () => new Conversations::ConversationInsightServiceWithRawResponse(
                client
            )
        ) ;
    }

    readonly Lazy<Conversations::IInsightGroupServiceWithRawResponse> _insightGroups;
    public Conversations::IInsightGroupServiceWithRawResponse InsightGroups {
        get { return _insightGroups.Value; }
    }

    readonly Lazy<Conversations::IInsightServiceWithRawResponse> _insights;
    public Conversations::IInsightServiceWithRawResponse Insights {
        get { return _insights.Value; }
    }

    readonly Lazy<Conversations::IMessageServiceWithRawResponse> _messages;
    public Conversations::IMessageServiceWithRawResponse Messages {
        get { return _messages.Value; }
    }

    readonly Lazy<Conversations::IConversationInsightServiceWithRawResponse> _conversationInsights;
    public Conversations::IConversationInsightServiceWithRawResponse ConversationInsights {
        get { return _conversationInsights.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Conversation>> Create(
        ConversationCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ConversationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var conversation = await response.Deserialize<Conversation>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                conversation.Validate();
            }
            return conversation;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConversationRetrieveResponse>> Retrieve(
        ConversationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConversationID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConversationID' cannot be null"
            );
        }

        HttpRequest<ConversationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var conversation = await response.Deserialize<ConversationRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                conversation.Validate();
            }
            return conversation;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ConversationRetrieveResponse>> Retrieve(
        string conversationID,
        ConversationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ConversationID = conversationID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConversationUpdateResponse>> Update(
        ConversationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConversationID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConversationID' cannot be null"
            );
        }

        HttpRequest<ConversationUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var conversation = await response.Deserialize<ConversationUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                conversation.Validate();
            }
            return conversation;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ConversationUpdateResponse>> Update(
        string conversationID,
        ConversationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ConversationID = conversationID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConversationListResponse>> List(
        ConversationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ConversationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var conversations = await response.Deserialize<ConversationListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                conversations.Validate();
            }
            return conversations;
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ConversationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConversationID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConversationID' cannot be null"
            );
        }

        HttpRequest<ConversationDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string conversationID,
        ConversationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ConversationID = conversationID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> AddMessage(
        ConversationAddMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConversationID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConversationID' cannot be null"
            );
        }

        HttpRequest<ConversationAddMessageParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> AddMessage(
        string conversationID,
        ConversationAddMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.AddMessage(parameters with{
            ConversationID = conversationID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConversationRetrieveConversationsInsightsResponse>> RetrieveConversationsInsights(
        ConversationRetrieveConversationsInsightsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConversationID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConversationID' cannot be null"
            );
        }

        HttpRequest<ConversationRetrieveConversationsInsightsParams> request = new(

        )
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ConversationRetrieveConversationsInsightsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ConversationRetrieveConversationsInsightsResponse>> RetrieveConversationsInsights(
        string conversationID,
        ConversationRetrieveConversationsInsightsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveConversationsInsights(parameters with{
            ConversationID = conversationID
        }, cancellationToken);
    }
}