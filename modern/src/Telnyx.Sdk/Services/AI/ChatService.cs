using System;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Services.AI;

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
}