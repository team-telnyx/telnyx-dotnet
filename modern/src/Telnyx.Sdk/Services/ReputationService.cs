using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.Reputation;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class ReputationService : IReputationService
{
    readonly Lazy<IReputationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IReputationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IReputationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ReputationService(this._client.WithOptions(modifier)); }

    public ReputationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ReputationServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _numbers =new(() => new NumberService(client)) ;
    }

    readonly Lazy<INumberService> _numbers;
    public INumberService Numbers { get { return _numbers.Value; } }
}

/// <inheritdoc/>
public sealed class ReputationServiceWithRawResponse : IReputationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IReputationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ReputationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ReputationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _numbers =new(() => new NumberServiceWithRawResponse(client)) ;
    }

    readonly Lazy<INumberServiceWithRawResponse> _numbers;
    public INumberServiceWithRawResponse Numbers {
        get { return _numbers.Value; }
    }
}