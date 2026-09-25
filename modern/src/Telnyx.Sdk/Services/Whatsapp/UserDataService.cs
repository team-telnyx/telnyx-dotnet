using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Whatsapp.UserData;

namespace Telnyx.Sdk.Services.Whatsapp;

/// <inheritdoc/>
public sealed class UserDataService : IUserDataService
{
    readonly Lazy<IUserDataServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUserDataServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IUserDataService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new UserDataService(this._client.WithOptions(modifier)); }

    public UserDataService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new UserDataServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<UserDataRetrieveResponse> Retrieve(
        UserDataRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UserDataUpdateResponse> Update(
        UserDataUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class UserDataServiceWithRawResponse : IUserDataServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUserDataServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new UserDataServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UserDataServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserDataRetrieveResponse>> Retrieve(
        UserDataRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UserDataRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var userData = await response.Deserialize<UserDataRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                userData.Validate();
            }
            return userData;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserDataUpdateResponse>> Update(
        UserDataUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UserDataUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var userData = await response.Deserialize<UserDataUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                userData.Validate();
            }
            return userData;
        });
    }
}