using System;
using Telnyx.Sdk.Core;
using Knowledge = Telnyx.Sdk.Services.AI.Knowledge;

namespace Telnyx.Sdk.Services.AI;

/// <inheritdoc/>
public sealed class KnowledgeService : IKnowledgeService
{
    readonly Lazy<IKnowledgeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IKnowledgeServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IKnowledgeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new KnowledgeService(this._client.WithOptions(modifier)); }

    public KnowledgeService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new KnowledgeServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _collections =new(() => new Knowledge::CollectionService(client)) ;
    }

    readonly Lazy<Knowledge::ICollectionService> _collections;
    public Knowledge::ICollectionService Collections {
        get { return _collections.Value; }
    }
}

/// <inheritdoc/>
public sealed class KnowledgeServiceWithRawResponse : IKnowledgeServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IKnowledgeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new KnowledgeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public KnowledgeServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _collections =new(
            () => new Knowledge::CollectionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<Knowledge::ICollectionServiceWithRawResponse> _collections;
    public Knowledge::ICollectionServiceWithRawResponse Collections {
        get { return _collections.Value; }
    }
}