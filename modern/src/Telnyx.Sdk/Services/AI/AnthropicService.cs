using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.AI.Anthropic;

namespace Telnyx.Sdk.Services.AI;

/// <inheritdoc/>
public sealed class AnthropicService : IAnthropicService
{
    readonly Lazy<IAnthropicServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAnthropicServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAnthropicService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new AnthropicService(this._client.WithOptions(modifier)); }

    public AnthropicService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AnthropicServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _v1 =new(() => new V1Service(client)) ;
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1 { get { return _v1.Value; } }
}

/// <inheritdoc/>
public sealed class AnthropicServiceWithRawResponse : IAnthropicServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAnthropicServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AnthropicServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AnthropicServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _v1 =new(() => new V1ServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IV1ServiceWithRawResponse> _v1;
    public IV1ServiceWithRawResponse V1 { get { return _v1.Value; } }
}