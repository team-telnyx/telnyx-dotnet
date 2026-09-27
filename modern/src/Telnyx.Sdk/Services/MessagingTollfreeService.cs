using System;
using Telnyx.Sdk.Core;
using MessagingTollfree = Telnyx.Sdk.Services.MessagingTollfree;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MessagingTollfreeService : IMessagingTollfreeService
{
    readonly Lazy<IMessagingTollfreeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMessagingTollfreeServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMessagingTollfreeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MessagingTollfreeService(this._client.WithOptions(modifier)); }

    public MessagingTollfreeService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MessagingTollfreeServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _verification =new(
            () => new MessagingTollfree::VerificationService(client)
        ) ;
    }

    readonly Lazy<MessagingTollfree::IVerificationService> _verification;
    public MessagingTollfree::IVerificationService Verification {
        get { return _verification.Value; }
    }
}

/// <inheritdoc/>
public sealed class MessagingTollfreeServiceWithRawResponse : IMessagingTollfreeServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMessagingTollfreeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessagingTollfreeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MessagingTollfreeServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _verification =new(
            () => new MessagingTollfree::VerificationServiceWithRawResponse(
                client
            )
        ) ;
    }

    readonly Lazy<MessagingTollfree::IVerificationServiceWithRawResponse> _verification;
    public MessagingTollfree::IVerificationServiceWithRawResponse Verification {
        get { return _verification.Value; }
    }
}