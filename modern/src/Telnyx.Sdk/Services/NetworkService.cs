using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Networks;
using Telnyx.Sdk.Services.Networks;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class NetworkService : INetworkService
{
    readonly Lazy<INetworkServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INetworkServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INetworkService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new NetworkService(this._client.WithOptions(modifier)); }

    public NetworkService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NetworkServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _defaultGateway =new(() => new DefaultGatewayService(client)) ;
    }

    readonly Lazy<IDefaultGatewayService> _defaultGateway;
    public IDefaultGatewayService DefaultGateway {
        get { return _defaultGateway.Value; }
    }

    /// <inheritdoc/>
    public async Task<NetworkCreateResponse> Create(
        NetworkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NetworkRetrieveResponse> Retrieve(
        NetworkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NetworkRetrieveResponse> Retrieve(
        string id,
        NetworkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NetworkUpdateResponse> Update(
        NetworkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NetworkUpdateResponse> Update(
        string networkID,
        NetworkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            NetworkID = networkID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NetworkListPage> List(
        NetworkListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NetworkDeleteResponse> Delete(
        NetworkDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NetworkDeleteResponse> Delete(
        string id,
        NetworkDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NetworkListInterfacesPage> ListInterfaces(
        NetworkListInterfacesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListInterfaces(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NetworkListInterfacesPage> ListInterfaces(
        string id,
        NetworkListInterfacesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListInterfaces(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class NetworkServiceWithRawResponse : INetworkServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INetworkServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NetworkServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NetworkServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _defaultGateway =new(
            () => new DefaultGatewayServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<IDefaultGatewayServiceWithRawResponse> _defaultGateway;
    public IDefaultGatewayServiceWithRawResponse DefaultGateway {
        get { return _defaultGateway.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NetworkCreateResponse>> Create(
        NetworkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<NetworkCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var network = await response.Deserialize<NetworkCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                network.Validate();
            }
            return network;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NetworkRetrieveResponse>> Retrieve(
        NetworkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<NetworkRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var network = await response.Deserialize<NetworkRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                network.Validate();
            }
            return network;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NetworkRetrieveResponse>> Retrieve(
        string id,
        NetworkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NetworkUpdateResponse>> Update(
        NetworkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NetworkID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.NetworkID' cannot be null"
            );
        }

        HttpRequest<NetworkUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var network = await response.Deserialize<NetworkUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                network.Validate();
            }
            return network;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NetworkUpdateResponse>> Update(
        string networkID,
        NetworkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            NetworkID = networkID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NetworkListPage>> List(
        NetworkListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NetworkListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<NetworkListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new NetworkListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NetworkDeleteResponse>> Delete(
        NetworkDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<NetworkDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var network = await response.Deserialize<NetworkDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                network.Validate();
            }
            return network;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NetworkDeleteResponse>> Delete(
        string id,
        NetworkDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NetworkListInterfacesPage>> ListInterfaces(
        NetworkListInterfacesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<NetworkListInterfacesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<NetworkListInterfacesPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new NetworkListInterfacesPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NetworkListInterfacesPage>> ListInterfaces(
        string id,
        NetworkListInterfacesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListInterfaces(parameters with{
            ID = id
        }, cancellationToken);
    }
}