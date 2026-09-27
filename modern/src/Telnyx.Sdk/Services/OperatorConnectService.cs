using System;
using Telnyx.Sdk.Core;
using OperatorConnect = Telnyx.Sdk.Services.OperatorConnect;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class OperatorConnectService : IOperatorConnectService
{
    readonly Lazy<IOperatorConnectServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOperatorConnectServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IOperatorConnectService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new OperatorConnectService(this._client.WithOptions(modifier)); }

    public OperatorConnectService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new OperatorConnectServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _actions =new(() => new OperatorConnect::ActionService(client)) ;
    }

    readonly Lazy<OperatorConnect::IActionService> _actions;
    public OperatorConnect::IActionService Actions {
        get { return _actions.Value; }
    }
}

/// <inheritdoc/>
public sealed class OperatorConnectServiceWithRawResponse : IOperatorConnectServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOperatorConnectServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new OperatorConnectServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OperatorConnectServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _actions =new(
            () => new OperatorConnect::ActionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<OperatorConnect::IActionServiceWithRawResponse> _actions;
    public OperatorConnect::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }
}