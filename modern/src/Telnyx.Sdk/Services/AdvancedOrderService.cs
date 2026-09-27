using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AdvancedOrders;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class AdvancedOrderService : IAdvancedOrderService
{
    readonly Lazy<IAdvancedOrderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAdvancedOrderServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAdvancedOrderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new AdvancedOrderService(this._client.WithOptions(modifier)); }

    public AdvancedOrderService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AdvancedOrderServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<AdvancedOrder> Create(
        AdvancedOrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AdvancedOrder> Retrieve(
        AdvancedOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AdvancedOrder> Retrieve(
        string orderID,
        AdvancedOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            OrderID = orderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AdvancedOrderListResponse> List(
        AdvancedOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AdvancedOrder> UpdateRequirementGroup(
        AdvancedOrderUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateRequirementGroup(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AdvancedOrder> UpdateRequirementGroup(
        string advancedOrderID,
        AdvancedOrderUpdateRequirementGroupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateRequirementGroup(parameters with{
            AdvancedOrderID = advancedOrderID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AdvancedOrderServiceWithRawResponse : IAdvancedOrderServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAdvancedOrderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AdvancedOrderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AdvancedOrderServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<AdvancedOrder>> Create(
        AdvancedOrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AdvancedOrderCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var advancedOrder = await response.Deserialize<AdvancedOrder>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                advancedOrder.Validate();
            }
            return advancedOrder;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AdvancedOrder>> Retrieve(
        AdvancedOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.OrderID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.OrderID' cannot be null"
            );
        }

        HttpRequest<AdvancedOrderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var advancedOrder = await response.Deserialize<AdvancedOrder>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                advancedOrder.Validate();
            }
            return advancedOrder;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AdvancedOrder>> Retrieve(
        string orderID,
        AdvancedOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            OrderID = orderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AdvancedOrderListResponse>> List(
        AdvancedOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AdvancedOrderListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var advancedOrders = await response.Deserialize<AdvancedOrderListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                advancedOrders.Validate();
            }
            return advancedOrders;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AdvancedOrder>> UpdateRequirementGroup(
        AdvancedOrderUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AdvancedOrderID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AdvancedOrderID' cannot be null"
            );
        }

        HttpRequest<AdvancedOrderUpdateRequirementGroupParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var advancedOrder = await response.Deserialize<AdvancedOrder>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                advancedOrder.Validate();
            }
            return advancedOrder;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AdvancedOrder>> UpdateRequirementGroup(
        string advancedOrderID,
        AdvancedOrderUpdateRequirementGroupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateRequirementGroup(parameters with{
            AdvancedOrderID = advancedOrderID
        }, cancellationToken);
    }
}