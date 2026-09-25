using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.Actions;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class ActionService : IActionService
{
    readonly Lazy<IActionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IActionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IActionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ActionService(this._client.WithOptions(modifier)); }

    public ActionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ActionServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _purchase =new(() => new PurchaseService(client)) ;
        _register =new(() => new RegisterService(client)) ;
    }

    readonly Lazy<IPurchaseService> _purchase;
    public IPurchaseService Purchase { get { return _purchase.Value; } }

    readonly Lazy<IRegisterService> _register;
    public IRegisterService Register { get { return _register.Value; } }
}

/// <inheritdoc/>
public sealed class ActionServiceWithRawResponse : IActionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IActionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ActionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ActionServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _purchase =new(() => new PurchaseServiceWithRawResponse(client)) ;
        _register =new(() => new RegisterServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IPurchaseServiceWithRawResponse> _purchase;
    public IPurchaseServiceWithRawResponse Purchase {
        get { return _purchase.Value; }
    }

    readonly Lazy<IRegisterServiceWithRawResponse> _register;
    public IRegisterServiceWithRawResponse Register {
        get { return _register.Value; }
    }
}