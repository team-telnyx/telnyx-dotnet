using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.Rcs;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class RcService : IRcService
{
    readonly Lazy<IRcServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRcServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRcService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new RcService(this._client.WithOptions(modifier)); }

    public RcService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RcServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _agents =new(() => new AgentService(client)) ;
        _brands =new(() => new BrandService(client)) ;
    }

    readonly Lazy<IAgentService> _agents;
    public IAgentService Agents { get { return _agents.Value; } }

    readonly Lazy<IBrandService> _brands;
    public IBrandService Brands { get { return _brands.Value; } }
}

/// <inheritdoc/>
public sealed class RcServiceWithRawResponse : IRcServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRcServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RcServiceWithRawResponse(this._client.WithOptions(modifier)); }

    public RcServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _agents =new(() => new AgentServiceWithRawResponse(client)) ;
        _brands =new(() => new BrandServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IAgentServiceWithRawResponse> _agents;
    public IAgentServiceWithRawResponse Agents { get { return _agents.Value; } }

    readonly Lazy<IBrandServiceWithRawResponse> _brands;
    public IBrandServiceWithRawResponse Brands { get { return _brands.Value; } }
}