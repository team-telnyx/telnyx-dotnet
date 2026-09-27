using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.WireguardInterfaces;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class WireguardInterfaceService : IWireguardInterfaceService
{
    readonly Lazy<IWireguardInterfaceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWireguardInterfaceServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IWireguardInterfaceService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WireguardInterfaceService(this._client.WithOptions(modifier));
    }

    public WireguardInterfaceService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new WireguardInterfaceServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<WireguardInterfaceCreateResponse> Create(
        WireguardInterfaceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WireguardInterfaceRetrieveResponse> Retrieve(
        WireguardInterfaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<WireguardInterfaceRetrieveResponse> Retrieve(
        string id,
        WireguardInterfaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WireguardInterfaceListPage> List(
        WireguardInterfaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WireguardInterfaceDeleteResponse> Delete(
        WireguardInterfaceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<WireguardInterfaceDeleteResponse> Delete(
        string id,
        WireguardInterfaceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class WireguardInterfaceServiceWithRawResponse : IWireguardInterfaceServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWireguardInterfaceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WireguardInterfaceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WireguardInterfaceServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireguardInterfaceCreateResponse>> Create(
        WireguardInterfaceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WireguardInterfaceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var wireguardInterface = await response.Deserialize<WireguardInterfaceCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                wireguardInterface.Validate();
            }
            return wireguardInterface;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireguardInterfaceRetrieveResponse>> Retrieve(
        WireguardInterfaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<WireguardInterfaceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var wireguardInterface = await response.Deserialize<WireguardInterfaceRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                wireguardInterface.Validate();
            }
            return wireguardInterface;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<WireguardInterfaceRetrieveResponse>> Retrieve(
        string id,
        WireguardInterfaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireguardInterfaceListPage>> List(
        WireguardInterfaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WireguardInterfaceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<WireguardInterfaceListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new WireguardInterfaceListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireguardInterfaceDeleteResponse>> Delete(
        WireguardInterfaceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<WireguardInterfaceDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var wireguardInterface = await response.Deserialize<WireguardInterfaceDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                wireguardInterface.Validate();
            }
            return wireguardInterface;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<WireguardInterfaceDeleteResponse>> Delete(
        string id,
        WireguardInterfaceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}