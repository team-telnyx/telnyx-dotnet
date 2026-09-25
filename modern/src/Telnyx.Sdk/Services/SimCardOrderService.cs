using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.SimCardOrders;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class SimCardOrderService : ISimCardOrderService
{
    readonly Lazy<ISimCardOrderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISimCardOrderServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISimCardOrderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new SimCardOrderService(this._client.WithOptions(modifier)); }

    public SimCardOrderService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SimCardOrderServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<SimCardOrderCreateResponse> Create(
        SimCardOrderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SimCardOrderRetrieveResponse> Retrieve(
        SimCardOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SimCardOrderRetrieveResponse> Retrieve(
        string id,
        SimCardOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SimCardOrderListPage> List(
        SimCardOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SimCardOrderServiceWithRawResponse : ISimCardOrderServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISimCardOrderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SimCardOrderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SimCardOrderServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardOrderCreateResponse>> Create(
        SimCardOrderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SimCardOrderCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var simCardOrder = await response.Deserialize<SimCardOrderCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                simCardOrder.Validate();
            }
            return simCardOrder;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardOrderRetrieveResponse>> Retrieve(
        SimCardOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SimCardOrderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var simCardOrder = await response.Deserialize<SimCardOrderRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                simCardOrder.Validate();
            }
            return simCardOrder;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SimCardOrderRetrieveResponse>> Retrieve(
        string id,
        SimCardOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardOrderListPage>> List(
        SimCardOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SimCardOrderListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<SimCardOrderListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new SimCardOrderListPage(this, parameters, page);
        });
    }
}