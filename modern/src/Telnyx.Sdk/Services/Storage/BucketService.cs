using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Storage.Buckets;
using Telnyx.Sdk.Services.Storage.Buckets;

namespace Telnyx.Sdk.Services.Storage;

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
        _sslCertificate =new(() => new SslCertificateService(client)) ;
        _usage =new(() => new UsageService(client)) ;
    }

    readonly Lazy<ISslCertificateService> _sslCertificate;
    public ISslCertificateService SslCertificate {
        get { return _sslCertificate.Value; }
    }

    readonly Lazy<IUsageService> _usage;
    public IUsageService Usage { get { return _usage.Value; } }

    /// <inheritdoc/>
    public async Task<BucketCreatePresignedUrlResponse> CreatePresignedUrl(
        BucketCreatePresignedUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CreatePresignedUrl(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<BucketCreatePresignedUrlResponse> CreatePresignedUrl(
        string objectName,
        BucketCreatePresignedUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreatePresignedUrl(parameters with{
            ObjectName = objectName
        }, cancellationToken);
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
    {
        _client =client ;

        _sslCertificate =new(
            () => new SslCertificateServiceWithRawResponse(client)
        ) ;
        _usage =new(() => new UsageServiceWithRawResponse(client)) ;
    }

    readonly Lazy<ISslCertificateServiceWithRawResponse> _sslCertificate;
    public ISslCertificateServiceWithRawResponse SslCertificate {
        get { return _sslCertificate.Value; }
    }

    readonly Lazy<IUsageServiceWithRawResponse> _usage;
    public IUsageServiceWithRawResponse Usage { get { return _usage.Value; } }

    /// <inheritdoc/>
    public async Task<HttpResponse<BucketCreatePresignedUrlResponse>> CreatePresignedUrl(
        BucketCreatePresignedUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ObjectName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ObjectName' cannot be null"
            );
        }

        HttpRequest<BucketCreatePresignedUrlParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<BucketCreatePresignedUrlResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<BucketCreatePresignedUrlResponse>> CreatePresignedUrl(
        string objectName,
        BucketCreatePresignedUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreatePresignedUrl(parameters with{
            ObjectName = objectName
        }, cancellationToken);
    }
}