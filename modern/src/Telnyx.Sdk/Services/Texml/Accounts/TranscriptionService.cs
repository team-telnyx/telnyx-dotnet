using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.Texml.Accounts.Transcriptions;

namespace Telnyx.Sdk.Services.Texml.Accounts;

/// <inheritdoc/>
public sealed class TranscriptionService : ITranscriptionService
{
    readonly Lazy<ITranscriptionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITranscriptionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ITranscriptionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new TranscriptionService(this._client.WithOptions(modifier)); }

    public TranscriptionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new TranscriptionServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _json =new(() => new JsonService(client)) ;
    }

    readonly Lazy<IJsonService> _json;
    public IJsonService Json { get { return _json.Value; } }
}

/// <inheritdoc/>
public sealed class TranscriptionServiceWithRawResponse : ITranscriptionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITranscriptionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TranscriptionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TranscriptionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _json =new(() => new JsonServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IJsonServiceWithRawResponse> _json;
    public IJsonServiceWithRawResponse Json { get { return _json.Value; } }
}