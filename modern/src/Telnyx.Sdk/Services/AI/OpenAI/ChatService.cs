using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.OpenAI.Chat;

namespace Telnyx.Sdk.Services.AI.OpenAI;

/// <inheritdoc/>
public sealed class ChatService : IChatService
{
    readonly Lazy<IChatServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IChatServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IChatService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new ChatService(this._client.WithOptions(modifier)); }

    public ChatService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ChatServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, JsonElement>> CreateCompletion(
        ChatCreateCompletionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CreateCompletion(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ChatServiceWithRawResponse : IChatServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IChatServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ChatServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ChatServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, JsonElement>>> CreateCompletion(
        ChatCreateCompletionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ChatCreateCompletionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<Dictionary<string, JsonElement>>(token).ConfigureAwait(false);
        });
    }
}