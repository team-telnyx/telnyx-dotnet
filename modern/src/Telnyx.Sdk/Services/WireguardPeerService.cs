using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.WireguardPeers;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class WireguardPeerService : IWireguardPeerService
{
    readonly Lazy<IWireguardPeerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWireguardPeerServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IWireguardPeerService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new WireguardPeerService(this._client.WithOptions(modifier)); }

    public WireguardPeerService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new WireguardPeerServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<WireguardPeerCreateResponse> Create(
        WireguardPeerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WireguardPeerRetrieveResponse> Retrieve(
        WireguardPeerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<WireguardPeerRetrieveResponse> Retrieve(
        string id,
        WireguardPeerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WireguardPeerUpdateResponse> Update(
        WireguardPeerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<WireguardPeerUpdateResponse> Update(
        string id,
        WireguardPeerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WireguardPeerListPage> List(
        WireguardPeerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WireguardPeerDeleteResponse> Delete(
        WireguardPeerDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<WireguardPeerDeleteResponse> Delete(
        string id,
        WireguardPeerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<string> RetrieveConfig(
        WireguardPeerRetrieveConfigParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveConfig(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<string> RetrieveConfig(
        string id,
        WireguardPeerRetrieveConfigParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveConfig(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class WireguardPeerServiceWithRawResponse : IWireguardPeerServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWireguardPeerServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WireguardPeerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WireguardPeerServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireguardPeerCreateResponse>> Create(
        WireguardPeerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WireguardPeerCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var wireguardPeer = await response.Deserialize<WireguardPeerCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                wireguardPeer.Validate();
            }
            return wireguardPeer;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireguardPeerRetrieveResponse>> Retrieve(
        WireguardPeerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<WireguardPeerRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var wireguardPeer = await response.Deserialize<WireguardPeerRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                wireguardPeer.Validate();
            }
            return wireguardPeer;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<WireguardPeerRetrieveResponse>> Retrieve(
        string id,
        WireguardPeerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireguardPeerUpdateResponse>> Update(
        WireguardPeerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<WireguardPeerUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var wireguardPeer = await response.Deserialize<WireguardPeerUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                wireguardPeer.Validate();
            }
            return wireguardPeer;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<WireguardPeerUpdateResponse>> Update(
        string id,
        WireguardPeerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireguardPeerListPage>> List(
        WireguardPeerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WireguardPeerListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<WireguardPeerListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new WireguardPeerListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WireguardPeerDeleteResponse>> Delete(
        WireguardPeerDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<WireguardPeerDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var wireguardPeer = await response.Deserialize<WireguardPeerDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                wireguardPeer.Validate();
            }
            return wireguardPeer;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<WireguardPeerDeleteResponse>> Delete(
        string id,
        WireguardPeerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<string>> RetrieveConfig(
        WireguardPeerRetrieveConfigParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<WireguardPeerRetrieveConfigParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<string>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<string>> RetrieveConfig(
        string id,
        WireguardPeerRetrieveConfigParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveConfig(parameters with{
            ID = id
        }, cancellationToken);
    }
}