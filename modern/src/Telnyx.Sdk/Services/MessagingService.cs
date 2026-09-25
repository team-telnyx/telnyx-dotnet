using System;
using Telnyx.Sdk.Core;
using Messaging = Telnyx.Sdk.Services.Messaging;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MessagingService : IMessagingService
{
    readonly Lazy<IMessagingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMessagingServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMessagingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MessagingService(this._client.WithOptions(modifier)); }

    public MessagingService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MessagingServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _rcs =new(() => new Messaging::RcService(client)) ;
    }

    readonly Lazy<Messaging::IRcService> _rcs;
    public Messaging::IRcService Rcs { get { return _rcs.Value; } }
}

/// <inheritdoc/>
public sealed class MessagingServiceWithRawResponse : IMessagingServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMessagingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessagingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MessagingServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _rcs =new(() => new Messaging::RcServiceWithRawResponse(client)) ;
    }

    readonly Lazy<Messaging::IRcServiceWithRawResponse> _rcs;
    public Messaging::IRcServiceWithRawResponse Rcs {
        get { return _rcs.Value; }
    }
}