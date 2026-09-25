using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.Profile;
using Telnyx.Sdk.Services.Whatsapp.PhoneNumbers.Profile;

namespace Telnyx.Sdk.Services.Whatsapp.PhoneNumbers;

/// <inheritdoc/>
public sealed class ProfileService : IProfileService
{
    readonly Lazy<IProfileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProfileServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IProfileService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ProfileService(this._client.WithOptions(modifier)); }

    public ProfileService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ProfileServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _photo =new(() => new PhotoService(client)) ;
    }

    readonly Lazy<IPhotoService> _photo;
    public IPhotoService Photo { get { return _photo.Value; } }

    /// <inheritdoc/>
    public async Task<ProfileRetrieveResponse> Retrieve(
        ProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ProfileRetrieveResponse> Retrieve(
        string phoneNumber,
        ProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProfileUpdateResponse> Update(
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ProfileUpdateResponse> Update(
        string phoneNumber,
        ProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ProfileServiceWithRawResponse : IProfileServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ProfileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProfileServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _photo =new(() => new PhotoServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IPhotoServiceWithRawResponse> _photo;
    public IPhotoServiceWithRawResponse Photo { get { return _photo.Value; } }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProfileRetrieveResponse>> Retrieve(
        ProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<ProfileRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var profile = await response.Deserialize<ProfileRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                profile.Validate();
            }
            return profile;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ProfileRetrieveResponse>> Retrieve(
        string phoneNumber,
        ProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProfileUpdateResponse>> Update(
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<ProfileUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var profile = await response.Deserialize<ProfileUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                profile.Validate();
            }
            return profile;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ProfileUpdateResponse>> Update(
        string phoneNumber,
        ProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}