using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.UserAddresses;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class UserAddressService : IUserAddressService
{
    readonly Lazy<IUserAddressServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUserAddressServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IUserAddressService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new UserAddressService(this._client.WithOptions(modifier)); }

    public UserAddressService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new UserAddressServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<UserAddressCreateResponse> Create(
        UserAddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UserAddressRetrieveResponse> Retrieve(
        UserAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UserAddressRetrieveResponse> Retrieve(
        string id,
        UserAddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UserAddressListPage> List(
        UserAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class UserAddressServiceWithRawResponse : IUserAddressServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUserAddressServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new UserAddressServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UserAddressServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserAddressCreateResponse>> Create(
        UserAddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UserAddressCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var userAddress = await response.Deserialize<UserAddressCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                userAddress.Validate();
            }
            return userAddress;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserAddressRetrieveResponse>> Retrieve(
        UserAddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<UserAddressRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var userAddress = await response.Deserialize<UserAddressRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                userAddress.Validate();
            }
            return userAddress;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UserAddressRetrieveResponse>> Retrieve(
        string id,
        UserAddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserAddressListPage>> List(
        UserAddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UserAddressListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<UserAddressListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new UserAddressListPage(this, parameters, page);
        });
    }
}