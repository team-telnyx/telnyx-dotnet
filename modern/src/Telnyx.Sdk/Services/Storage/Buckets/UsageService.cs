using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Storage.Buckets.Usage;

namespace Telnyx.Sdk.Services.Storage.Buckets;

/// <inheritdoc/>
public sealed class UsageService : IUsageService
{
    readonly Lazy<IUsageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUsageServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IUsageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new UsageService(this._client.WithOptions(modifier)); }

    public UsageService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new UsageServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<UsageGetApiUsageResponse> GetApiUsage(
        UsageGetApiUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetApiUsage(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UsageGetApiUsageResponse> GetApiUsage(
        string bucketName,
        UsageGetApiUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetApiUsage(parameters with{
            BucketName = bucketName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UsageGetBucketUsageResponse> GetBucketUsage(
        UsageGetBucketUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetBucketUsage(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UsageGetBucketUsageResponse> GetBucketUsage(
        string bucketName,
        UsageGetBucketUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetBucketUsage(parameters with{
            BucketName = bucketName
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class UsageServiceWithRawResponse : IUsageServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUsageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new UsageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UsageServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<UsageGetApiUsageResponse>> GetApiUsage(
        UsageGetApiUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BucketName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BucketName' cannot be null"
            );
        }

        HttpRequest<UsageGetApiUsageParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<UsageGetApiUsageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UsageGetApiUsageResponse>> GetApiUsage(
        string bucketName,
        UsageGetApiUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetApiUsage(parameters with{
            BucketName = bucketName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UsageGetBucketUsageResponse>> GetBucketUsage(
        UsageGetBucketUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BucketName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BucketName' cannot be null"
            );
        }

        HttpRequest<UsageGetBucketUsageParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<UsageGetBucketUsageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UsageGetBucketUsageResponse>> GetBucketUsage(
        string bucketName,
        UsageGetBucketUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetBucketUsage(parameters with{
            BucketName = bucketName
        }, cancellationToken);
    }
}