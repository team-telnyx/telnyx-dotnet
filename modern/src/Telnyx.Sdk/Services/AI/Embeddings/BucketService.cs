using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Embeddings.Buckets;

namespace Telnyx.Sdk.Services.AI.Embeddings;

/// <inheritdoc/>
public sealed class BucketService : IBucketService
{
    readonly Lazy<IBucketServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBucketServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IBucketService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new BucketService(this._client.WithOptions(modifier)); }

    public BucketService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new BucketServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<BucketRetrieveResponse> Retrieve(
        BucketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<BucketRetrieveResponse> Retrieve(
        string bucketName,
        BucketRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            BucketName = bucketName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BucketListResponse> List(
        BucketListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        BucketDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string bucketName,
        BucketDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            BucketName = bucketName
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BucketServiceWithRawResponse : IBucketServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBucketServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BucketServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BucketServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<BucketRetrieveResponse>> Retrieve(
        BucketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BucketName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BucketName' cannot be null"
            );
        }

        HttpRequest<BucketRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var bucket = await response.Deserialize<BucketRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                bucket.Validate();
            }
            return bucket;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<BucketRetrieveResponse>> Retrieve(
        string bucketName,
        BucketRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            BucketName = bucketName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BucketListResponse>> List(
        BucketListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BucketListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var buckets = await response.Deserialize<BucketListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                buckets.Validate();
            }
            return buckets;
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        BucketDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BucketName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BucketName' cannot be null"
            );
        }

        HttpRequest<BucketDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string bucketName,
        BucketDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            BucketName = bucketName
        }, cancellationToken);
    }
}