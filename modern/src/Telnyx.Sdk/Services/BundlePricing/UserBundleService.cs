using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.BundlePricing.UserBundles;

namespace Telnyx.Sdk.Services.BundlePricing;

/// <inheritdoc/>
public sealed class UserBundleService : IUserBundleService
{
    readonly Lazy<IUserBundleServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUserBundleServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IUserBundleService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new UserBundleService(this._client.WithOptions(modifier)); }

    public UserBundleService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new UserBundleServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<UserBundleCreateResponse> Create(
        UserBundleCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UserBundleRetrieveResponse> Retrieve(
        UserBundleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UserBundleRetrieveResponse> Retrieve(
        string userBundleID,
        UserBundleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            UserBundleID = userBundleID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UserBundleListPage> List(
        UserBundleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UserBundleDeactivateResponse> Deactivate(
        UserBundleDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Deactivate(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UserBundleDeactivateResponse> Deactivate(
        string userBundleID,
        UserBundleDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deactivate(parameters with{
            UserBundleID = userBundleID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UserBundleListResourcesResponse> ListResources(
        UserBundleListResourcesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListResources(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UserBundleListResourcesResponse> ListResources(
        string userBundleID,
        UserBundleListResourcesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListResources(parameters with{
            UserBundleID = userBundleID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UserBundleListUnusedResponse> ListUnused(
        UserBundleListUnusedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListUnused(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class UserBundleServiceWithRawResponse : IUserBundleServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUserBundleServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new UserBundleServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UserBundleServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserBundleCreateResponse>> Create(
        UserBundleCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UserBundleCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var userBundle = await response.Deserialize<UserBundleCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                userBundle.Validate();
            }
            return userBundle;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserBundleRetrieveResponse>> Retrieve(
        UserBundleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserBundleID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.UserBundleID' cannot be null"
            );
        }

        HttpRequest<UserBundleRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var userBundle = await response.Deserialize<UserBundleRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                userBundle.Validate();
            }
            return userBundle;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UserBundleRetrieveResponse>> Retrieve(
        string userBundleID,
        UserBundleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            UserBundleID = userBundleID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserBundleListPage>> List(
        UserBundleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UserBundleListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<UserBundleListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new UserBundleListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserBundleDeactivateResponse>> Deactivate(
        UserBundleDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserBundleID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.UserBundleID' cannot be null"
            );
        }

        HttpRequest<UserBundleDeactivateParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<UserBundleDeactivateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UserBundleDeactivateResponse>> Deactivate(
        string userBundleID,
        UserBundleDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deactivate(parameters with{
            UserBundleID = userBundleID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserBundleListResourcesResponse>> ListResources(
        UserBundleListResourcesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserBundleID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.UserBundleID' cannot be null"
            );
        }

        HttpRequest<UserBundleListResourcesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<UserBundleListResourcesResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UserBundleListResourcesResponse>> ListResources(
        string userBundleID,
        UserBundleListResourcesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListResources(parameters with{
            UserBundleID = userBundleID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserBundleListUnusedResponse>> ListUnused(
        UserBundleListUnusedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UserBundleListUnusedParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<UserBundleListUnusedResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}