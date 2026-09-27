using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.WirelessBlocklists;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class WirelessBlocklistService : IWirelessBlocklistService
{
    readonly Lazy<IWirelessBlocklistServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWirelessBlocklistServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IWirelessBlocklistService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new WirelessBlocklistService(this._client.WithOptions(modifier)); }

    public WirelessBlocklistService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new WirelessBlocklistServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<WirelessBlocklistCreateResponse> Create(
        WirelessBlocklistCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WirelessBlocklistRetrieveResponse> Retrieve(
        WirelessBlocklistRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<WirelessBlocklistRetrieveResponse> Retrieve(
        string id,
        WirelessBlocklistRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WirelessBlocklistUpdateResponse> Update(
        WirelessBlocklistUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<WirelessBlocklistUpdateResponse> Update(
        string id,
        WirelessBlocklistUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WirelessBlocklistListPage> List(
        WirelessBlocklistListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        WirelessBlocklistDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        WirelessBlocklistDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ID = id
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class WirelessBlocklistServiceWithRawResponse : IWirelessBlocklistServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWirelessBlocklistServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WirelessBlocklistServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WirelessBlocklistServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<WirelessBlocklistCreateResponse>> Create(
        WirelessBlocklistCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WirelessBlocklistCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var wirelessBlocklist = await response.Deserialize<WirelessBlocklistCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                wirelessBlocklist.Validate();
            }
            return wirelessBlocklist;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WirelessBlocklistRetrieveResponse>> Retrieve(
        WirelessBlocklistRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<WirelessBlocklistRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var wirelessBlocklist = await response.Deserialize<WirelessBlocklistRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                wirelessBlocklist.Validate();
            }
            return wirelessBlocklist;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<WirelessBlocklistRetrieveResponse>> Retrieve(
        string id,
        WirelessBlocklistRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WirelessBlocklistUpdateResponse>> Update(
        WirelessBlocklistUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<WirelessBlocklistUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var wirelessBlocklist = await response.Deserialize<WirelessBlocklistUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                wirelessBlocklist.Validate();
            }
            return wirelessBlocklist;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<WirelessBlocklistUpdateResponse>> Update(
        string id,
        WirelessBlocklistUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WirelessBlocklistListPage>> List(
        WirelessBlocklistListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WirelessBlocklistListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<WirelessBlocklistListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new WirelessBlocklistListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        WirelessBlocklistDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<WirelessBlocklistDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        WirelessBlocklistDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}