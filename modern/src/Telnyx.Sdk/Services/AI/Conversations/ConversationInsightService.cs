using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Conversations.ConversationInsights;

namespace Telnyx.Sdk.Services.AI.Conversations;

/// <inheritdoc/>
public sealed class ConversationInsightService : IConversationInsightService
{
    readonly Lazy<IConversationInsightServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IConversationInsightServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IConversationInsightService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ConversationInsightService(this._client.WithOptions(modifier));
    }

    public ConversationInsightService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ConversationInsightServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ConversationInsightRetrieveAggregatesResponse> RetrieveAggregates(
        ConversationInsightRetrieveAggregatesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveAggregates(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ConversationInsightServiceWithRawResponse : IConversationInsightServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IConversationInsightServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ConversationInsightServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ConversationInsightServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConversationInsightRetrieveAggregatesResponse>> RetrieveAggregates(
        ConversationInsightRetrieveAggregatesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ConversationInsightRetrieveAggregatesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ConversationInsightRetrieveAggregatesResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}