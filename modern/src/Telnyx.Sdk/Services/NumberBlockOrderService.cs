using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.NumberBlockOrders;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class NumberBlockOrderService : INumberBlockOrderService
{
    readonly Lazy<INumberBlockOrderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INumberBlockOrderServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INumberBlockOrderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new NumberBlockOrderService(this._client.WithOptions(modifier)); }

    public NumberBlockOrderService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NumberBlockOrderServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<NumberBlockOrderCreateResponse> Create(
        NumberBlockOrderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NumberBlockOrderRetrieveResponse> Retrieve(
        NumberBlockOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NumberBlockOrderRetrieveResponse> Retrieve(
        string numberBlockOrderID,
        NumberBlockOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            NumberBlockOrderID = numberBlockOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NumberBlockOrderListPage> List(
        NumberBlockOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class NumberBlockOrderServiceWithRawResponse : INumberBlockOrderServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INumberBlockOrderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NumberBlockOrderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NumberBlockOrderServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberBlockOrderCreateResponse>> Create(
        NumberBlockOrderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<NumberBlockOrderCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var numberBlockOrder = await response.Deserialize<NumberBlockOrderCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                numberBlockOrder.Validate();
            }
            return numberBlockOrder;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberBlockOrderRetrieveResponse>> Retrieve(
        NumberBlockOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NumberBlockOrderID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.NumberBlockOrderID' cannot be null"
            );
        }

        HttpRequest<NumberBlockOrderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var numberBlockOrder = await response.Deserialize<NumberBlockOrderRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                numberBlockOrder.Validate();
            }
            return numberBlockOrder;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NumberBlockOrderRetrieveResponse>> Retrieve(
        string numberBlockOrderID,
        NumberBlockOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            NumberBlockOrderID = numberBlockOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberBlockOrderListPage>> List(
        NumberBlockOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NumberBlockOrderListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<NumberBlockOrderListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new NumberBlockOrderListPage(this, parameters, page);
        });
    }
}