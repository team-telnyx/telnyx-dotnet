using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Storage.Buckets.SslCertificate;

namespace Telnyx.Sdk.Services.Storage.Buckets;

/// <inheritdoc/>
public sealed class SslCertificateService : ISslCertificateService
{
    readonly Lazy<ISslCertificateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISslCertificateServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISslCertificateService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new SslCertificateService(this._client.WithOptions(modifier)); }

    public SslCertificateService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SslCertificateServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<SslCertificateCreateResponse> Create(
        SslCertificateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SslCertificateCreateResponse> Create(
        string bucketName,
        SslCertificateCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            BucketName = bucketName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SslCertificateRetrieveResponse> Retrieve(
        SslCertificateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SslCertificateRetrieveResponse> Retrieve(
        string bucketName,
        SslCertificateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            BucketName = bucketName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SslCertificateDeleteResponse> Delete(
        SslCertificateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SslCertificateDeleteResponse> Delete(
        string bucketName,
        SslCertificateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            BucketName = bucketName
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SslCertificateServiceWithRawResponse : ISslCertificateServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISslCertificateServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SslCertificateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SslCertificateServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<SslCertificateCreateResponse>> Create(
        SslCertificateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BucketName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BucketName' cannot be null"
            );
        }

        HttpRequest<SslCertificateCreateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var sslCertificate = await response.Deserialize<SslCertificateCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                sslCertificate.Validate();
            }
            return sslCertificate;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SslCertificateCreateResponse>> Create(
        string bucketName,
        SslCertificateCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            BucketName = bucketName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SslCertificateRetrieveResponse>> Retrieve(
        SslCertificateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BucketName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BucketName' cannot be null"
            );
        }

        HttpRequest<SslCertificateRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var sslCertificate = await response.Deserialize<SslCertificateRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                sslCertificate.Validate();
            }
            return sslCertificate;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SslCertificateRetrieveResponse>> Retrieve(
        string bucketName,
        SslCertificateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            BucketName = bucketName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SslCertificateDeleteResponse>> Delete(
        SslCertificateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BucketName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BucketName' cannot be null"
            );
        }

        HttpRequest<SslCertificateDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var sslCertificate = await response.Deserialize<SslCertificateDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                sslCertificate.Validate();
            }
            return sslCertificate;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SslCertificateDeleteResponse>> Delete(
        string bucketName,
        SslCertificateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            BucketName = bucketName
        }, cancellationToken);
    }
}