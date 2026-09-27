using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.Compute;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class ComputeService : IComputeService
{
    readonly Lazy<IComputeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IComputeServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IComputeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ComputeService(this._client.WithOptions(modifier)); }

    public ComputeService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ComputeServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _funcs =new(() => new FuncService(client)) ;
    }

    readonly Lazy<IFuncService> _funcs;
    public IFuncService Funcs { get { return _funcs.Value; } }
}

/// <inheritdoc/>
public sealed class ComputeServiceWithRawResponse : IComputeServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IComputeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ComputeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ComputeServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _funcs =new(() => new FuncServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IFuncServiceWithRawResponse> _funcs;
    public IFuncServiceWithRawResponse Funcs { get { return _funcs.Value; } }
}