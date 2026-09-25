using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.AI.FineTuning;

namespace Telnyx.Sdk.Services.AI;

/// <inheritdoc/>
public sealed class FineTuningService : IFineTuningService
{
    readonly Lazy<IFineTuningServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFineTuningServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IFineTuningService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new FineTuningService(this._client.WithOptions(modifier)); }

    public FineTuningService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new FineTuningServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _jobs =new(() => new JobService(client)) ;
    }

    readonly Lazy<IJobService> _jobs;
    public IJobService Jobs { get { return _jobs.Value; } }
}

/// <inheritdoc/>
public sealed class FineTuningServiceWithRawResponse : IFineTuningServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFineTuningServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new FineTuningServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FineTuningServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _jobs =new(() => new JobServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IJobServiceWithRawResponse> _jobs;
    public IJobServiceWithRawResponse Jobs { get { return _jobs.Value; } }
}