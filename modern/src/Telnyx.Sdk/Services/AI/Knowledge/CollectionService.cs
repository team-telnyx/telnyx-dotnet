using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Knowledge.Collections;

namespace Telnyx.Sdk.Services.AI.Knowledge;

/// <inheritdoc/>
public sealed class CollectionService : ICollectionService
{
    readonly Lazy<ICollectionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICollectionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICollectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new CollectionService(this._client.WithOptions(modifier)); }

    public CollectionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CollectionServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<CollectionRetrieveDocumentsResponse> RetrieveDocuments(
        CollectionRetrieveDocumentsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveDocuments(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CollectionRetrieveDocumentsResponse> RetrieveDocuments(
        string slug,
        CollectionRetrieveDocumentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveDocuments(parameters with{
            Slug = slug
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CollectionServiceWithRawResponse : ICollectionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICollectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CollectionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CollectionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<CollectionRetrieveDocumentsResponse>> RetrieveDocuments(
        CollectionRetrieveDocumentsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Slug == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Slug' cannot be null"
            );
        }

        HttpRequest<CollectionRetrieveDocumentsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CollectionRetrieveDocumentsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CollectionRetrieveDocumentsResponse>> RetrieveDocuments(
        string slug,
        CollectionRetrieveDocumentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveDocuments(parameters with{
            Slug = slug
        }, cancellationToken);
    }
}