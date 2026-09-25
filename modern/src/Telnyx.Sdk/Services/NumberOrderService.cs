using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.NumberOrders;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class NumberOrderService : INumberOrderService
{
    readonly Lazy<INumberOrderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INumberOrderServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INumberOrderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new NumberOrderService(this._client.WithOptions(modifier)); }

    public NumberOrderService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NumberOrderServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<NumberOrderCreateResponse> Create(
        NumberOrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NumberOrderRetrieveResponse> Retrieve(
        NumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NumberOrderRetrieveResponse> Retrieve(
        string numberOrderID,
        NumberOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            NumberOrderID = numberOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NumberOrderUpdateResponse> Update(
        NumberOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NumberOrderUpdateResponse> Update(
        string numberOrderID,
        NumberOrderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            NumberOrderID = numberOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NumberOrderListPage> List(
        NumberOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class NumberOrderServiceWithRawResponse : INumberOrderServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INumberOrderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NumberOrderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NumberOrderServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberOrderCreateResponse>> Create(
        NumberOrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NumberOrderCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var numberOrder = await response.Deserialize<NumberOrderCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                numberOrder.Validate();
            }
            return numberOrder;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberOrderRetrieveResponse>> Retrieve(
        NumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NumberOrderID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.NumberOrderID' cannot be null"
            );
        }

        HttpRequest<NumberOrderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var numberOrder = await response.Deserialize<NumberOrderRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                numberOrder.Validate();
            }
            return numberOrder;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NumberOrderRetrieveResponse>> Retrieve(
        string numberOrderID,
        NumberOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            NumberOrderID = numberOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberOrderUpdateResponse>> Update(
        NumberOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NumberOrderID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.NumberOrderID' cannot be null"
            );
        }

        HttpRequest<NumberOrderUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var numberOrder = await response.Deserialize<NumberOrderUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                numberOrder.Validate();
            }
            return numberOrder;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NumberOrderUpdateResponse>> Update(
        string numberOrderID,
        NumberOrderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            NumberOrderID = numberOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberOrderListPage>> List(
        NumberOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NumberOrderListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<NumberOrderListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new NumberOrderListPage(this, parameters, page);
        });
    }
}