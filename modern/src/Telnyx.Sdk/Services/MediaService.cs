using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Media;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MediaService : IMediaService
{
    readonly Lazy<IMediaServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMediaServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMediaService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MediaService(this._client.WithOptions(modifier)); }

    public MediaService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MediaServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MediaRetrieveResponse> Retrieve(
        MediaRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MediaRetrieveResponse> Retrieve(
        string mediaName,
        MediaRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            MediaName = mediaName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MediaUpdateResponse> Update(
        MediaUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MediaUpdateResponse> Update(
        string mediaName,
        MediaUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            MediaName = mediaName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MediaListResponse> List(
        MediaListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        MediaDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string mediaName,
        MediaDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            MediaName = mediaName
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        MediaDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Download(parameters, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Download(
        string mediaName,
        MediaDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Download(parameters with{
            MediaName = mediaName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MediaUploadResponse> Upload(
        MediaUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Upload(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MediaServiceWithRawResponse : IMediaServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMediaServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MediaServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MediaServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MediaRetrieveResponse>> Retrieve(
        MediaRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MediaName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MediaName' cannot be null"
            );
        }

        HttpRequest<MediaRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var media = await response.Deserialize<MediaRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                media.Validate();
            }
            return media;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MediaRetrieveResponse>> Retrieve(
        string mediaName,
        MediaRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            MediaName = mediaName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MediaUpdateResponse>> Update(
        MediaUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MediaName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MediaName' cannot be null"
            );
        }

        HttpRequest<MediaUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var media = await response.Deserialize<MediaUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                media.Validate();
            }
            return media;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MediaUpdateResponse>> Update(
        string mediaName,
        MediaUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            MediaName = mediaName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MediaListResponse>> List(
        MediaListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MediaListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var media = await response.Deserialize<MediaListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                media.Validate();
            }
            return media;
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        MediaDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MediaName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MediaName' cannot be null"
            );
        }

        HttpRequest<MediaDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string mediaName,
        MediaDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            MediaName = mediaName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        MediaDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MediaName == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MediaName' cannot be null"
            );
        }

        HttpRequest<MediaDownloadParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Download(
        string mediaName,
        MediaDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Download(parameters with{
            MediaName = mediaName
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MediaUploadResponse>> Upload(
        MediaUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MediaUploadParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MediaUploadResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}