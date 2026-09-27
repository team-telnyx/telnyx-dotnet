using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.Profile.Photo;

namespace Telnyx.Sdk.Services.Whatsapp.PhoneNumbers.Profile;

/// <inheritdoc/>
public sealed class PhotoService : IPhotoService
{
    readonly Lazy<IPhotoServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhotoServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPhotoService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new PhotoService(this._client.WithOptions(modifier)); }

    public PhotoService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PhotoServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PhotoRetrieveResponse> Retrieve(
        PhotoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhotoRetrieveResponse> Retrieve(
        string phoneNumber,
        PhotoRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        PhotoDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string phoneNumber,
        PhotoDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PhotoUploadResponse> Upload(
        PhotoUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Upload(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhotoUploadResponse> Upload(
        string phoneNumber,
        PhotoUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upload(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PhotoServiceWithRawResponse : IPhotoServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhotoServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhotoServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhotoServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhotoRetrieveResponse>> Retrieve(
        PhotoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<PhotoRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var photo = await response.Deserialize<PhotoRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                photo.Validate();
            }
            return photo;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhotoRetrieveResponse>> Retrieve(
        string phoneNumber,
        PhotoRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        PhotoDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<PhotoDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string phoneNumber,
        PhotoDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhotoUploadResponse>> Upload(
        PhotoUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<PhotoUploadParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<PhotoUploadResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhotoUploadResponse>> Upload(
        string phoneNumber,
        PhotoUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upload(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}