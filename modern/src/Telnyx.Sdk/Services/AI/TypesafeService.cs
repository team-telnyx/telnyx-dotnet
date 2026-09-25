using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.AI.Typesafe;

namespace Telnyx.Sdk.Services.AI;

/// <inheritdoc/>
public sealed class TypesafeService : ITypesafeService
{
    readonly Lazy<ITypesafeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITypesafeServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ITypesafeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new TypesafeService(this._client.WithOptions(modifier)); }

    public TypesafeService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new TypesafeServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _v1 =new(() => new V1Service(client)) ;
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1 { get { return _v1.Value; } }
}

/// <inheritdoc/>
public sealed class TypesafeServiceWithRawResponse : ITypesafeServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITypesafeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TypesafeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TypesafeServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _v1 =new(() => new V1ServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IV1ServiceWithRawResponse> _v1;
    public IV1ServiceWithRawResponse V1 { get { return _v1.Value; } }
}