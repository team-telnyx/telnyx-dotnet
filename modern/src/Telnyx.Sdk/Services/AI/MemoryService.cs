using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.AI.Memory;

namespace Telnyx.Sdk.Services.AI;

/// <inheritdoc/>
public sealed class MemoryService : IMemoryService
{
    readonly Lazy<IMemoryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMemoryServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMemoryService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MemoryService(this._client.WithOptions(modifier)); }

    public MemoryService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MemoryServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _namespaces =new(() => new NamespaceService(client)) ;
    }

    readonly Lazy<INamespaceService> _namespaces;
    public INamespaceService Namespaces { get { return _namespaces.Value; } }
}

/// <inheritdoc/>
public sealed class MemoryServiceWithRawResponse : IMemoryServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMemoryServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MemoryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MemoryServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _namespaces =new(() => new NamespaceServiceWithRawResponse(client)) ;
    }

    readonly Lazy<INamespaceServiceWithRawResponse> _namespaces;
    public INamespaceServiceWithRawResponse Namespaces {
        get { return _namespaces.Value; }
    }
}