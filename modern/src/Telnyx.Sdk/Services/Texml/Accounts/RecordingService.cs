using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.Texml.Accounts.Recordings;

namespace Telnyx.Sdk.Services.Texml.Accounts;

/// <inheritdoc/>
public sealed class RecordingService : IRecordingService
{
    readonly Lazy<IRecordingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRecordingServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRecordingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RecordingService(this._client.WithOptions(modifier)); }

    public RecordingService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RecordingServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _json =new(() => new JsonService(client)) ;
    }

    readonly Lazy<IJsonService> _json;
    public IJsonService Json { get { return _json.Value; } }
}

/// <inheritdoc/>
public sealed class RecordingServiceWithRawResponse : IRecordingServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRecordingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RecordingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RecordingServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _json =new(() => new JsonServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IJsonServiceWithRawResponse> _json;
    public IJsonServiceWithRawResponse Json { get { return _json.Value; } }
}