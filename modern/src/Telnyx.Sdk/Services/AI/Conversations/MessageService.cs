using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Conversations.Messages;

namespace Telnyx.Sdk.Services.AI.Conversations;

/// <inheritdoc/>
public sealed class MessageService : IMessageService
{
    readonly Lazy<IMessageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMessageServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMessageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MessageService(this._client.WithOptions(modifier)); }

    public MessageService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MessageServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MessageListPage> List(
        MessageListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessageListPage> List(
        string conversationID,
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ConversationID = conversationID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MessageServiceWithRawResponse : IMessageServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMessageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MessageServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageListPage>> List(
        MessageListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConversationID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConversationID' cannot be null"
            );
        }

        HttpRequest<MessageListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MessageListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MessageListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessageListPage>> List(
        string conversationID,
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ConversationID = conversationID
        }, cancellationToken);
    }
}