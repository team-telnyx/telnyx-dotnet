using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.MessagingTollfree.Verification;

namespace Telnyx.Sdk.Services.MessagingTollfree;

/// <inheritdoc/>
public sealed class VerificationService : IVerificationService
{
    readonly Lazy<IVerificationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVerificationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IVerificationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new VerificationService(this._client.WithOptions(modifier)); }

    public VerificationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new VerificationServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _requests =new(() => new RequestService(client)) ;
    }

    readonly Lazy<IRequestService> _requests;
    public IRequestService Requests { get { return _requests.Value; } }
}

/// <inheritdoc/>
public sealed class VerificationServiceWithRawResponse : IVerificationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVerificationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VerificationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VerificationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _requests =new(() => new RequestServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IRequestServiceWithRawResponse> _requests;
    public IRequestServiceWithRawResponse Requests {
        get { return _requests.Value; }
    }
}