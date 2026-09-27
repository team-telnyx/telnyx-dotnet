using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.IPConnections;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class IPConnectionService : IIPConnectionService
{
    readonly Lazy<IIPConnectionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IIPConnectionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IIPConnectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new IPConnectionService(this._client.WithOptions(modifier)); }

    public IPConnectionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new IPConnectionServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<IPConnectionCreateResponse> Create(
        IPConnectionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<IPConnectionRetrieveResponse> Retrieve(
        IPConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<IPConnectionRetrieveResponse> Retrieve(
        string id,
        IPConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IPConnectionUpdateResponse> Update(
        IPConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<IPConnectionUpdateResponse> Update(
        string id,
        IPConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IPConnectionListPage> List(
        IPConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<IPConnectionDeleteResponse> Delete(
        IPConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<IPConnectionDeleteResponse> Delete(
        string id,
        IPConnectionDeleteParams? parameters = null,
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
public sealed class IPConnectionServiceWithRawResponse : IIPConnectionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IIPConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new IPConnectionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public IPConnectionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<IPConnectionCreateResponse>> Create(
        IPConnectionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<IPConnectionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var ipConnection = await response.Deserialize<IPConnectionCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                ipConnection.Validate();
            }
            return ipConnection;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IPConnectionRetrieveResponse>> Retrieve(
        IPConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<IPConnectionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var ipConnection = await response.Deserialize<IPConnectionRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                ipConnection.Validate();
            }
            return ipConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<IPConnectionRetrieveResponse>> Retrieve(
        string id,
        IPConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IPConnectionUpdateResponse>> Update(
        IPConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<IPConnectionUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var ipConnection = await response.Deserialize<IPConnectionUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                ipConnection.Validate();
            }
            return ipConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<IPConnectionUpdateResponse>> Update(
        string id,
        IPConnectionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IPConnectionListPage>> List(
        IPConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<IPConnectionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<IPConnectionListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new IPConnectionListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IPConnectionDeleteResponse>> Delete(
        IPConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<IPConnectionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var ipConnection = await response.Deserialize<IPConnectionDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                ipConnection.Validate();
            }
            return ipConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<IPConnectionDeleteResponse>> Delete(
        string id,
        IPConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}