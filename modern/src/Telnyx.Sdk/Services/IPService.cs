using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Ips;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class IPService : IIPService
{
    readonly Lazy<IIPServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IIPServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IIPService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new IPService(this._client.WithOptions(modifier)); }

    public IPService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new IPServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<IPCreateResponse> Create(
        IPCreateParams parameters, CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<IPRetrieveResponse> Retrieve(
        IPRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<IPRetrieveResponse> Retrieve(
        string id,
        IPRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IPUpdateResponse> Update(
        IPUpdateParams parameters, CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<IPUpdateResponse> Update(
        string id,
        IPUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IPListPage> List(
        IPListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<IPDeleteResponse> Delete(
        IPDeleteParams parameters, CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<IPDeleteResponse> Delete(
        string id,
        IPDeleteParams? parameters = null,
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
public sealed class IPServiceWithRawResponse : IIPServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IIPServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new IPServiceWithRawResponse(this._client.WithOptions(modifier)); }

    public IPServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<IPCreateResponse>> Create(
        IPCreateParams parameters, CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IPCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var ip = await response.Deserialize<IPCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                ip.Validate();
            }
            return ip;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IPRetrieveResponse>> Retrieve(
        IPRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<IPRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var ip = await response.Deserialize<IPRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                ip.Validate();
            }
            return ip;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<IPRetrieveResponse>> Retrieve(
        string id,
        IPRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IPUpdateResponse>> Update(
        IPUpdateParams parameters, CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<IPUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var ip = await response.Deserialize<IPUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                ip.Validate();
            }
            return ip;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<IPUpdateResponse>> Update(
        string id,
        IPUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IPListPage>> List(
        IPListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<IPListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<IPListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new IPListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IPDeleteResponse>> Delete(
        IPDeleteParams parameters, CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<IPDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var ip = await response.Deserialize<IPDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                ip.Validate();
            }
            return ip;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<IPDeleteResponse>> Delete(
        string id,
        IPDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}