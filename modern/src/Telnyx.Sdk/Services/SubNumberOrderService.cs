using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.SubNumberOrders;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class SubNumberOrderService : ISubNumberOrderService
{
    readonly Lazy<ISubNumberOrderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISubNumberOrderServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISubNumberOrderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new SubNumberOrderService(this._client.WithOptions(modifier)); }

    public SubNumberOrderService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SubNumberOrderServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<SubNumberOrderRetrieveResponse> Retrieve(
        SubNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SubNumberOrderRetrieveResponse> Retrieve(
        string subNumberOrderID,
        SubNumberOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            SubNumberOrderID = subNumberOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubNumberOrderUpdateResponse> Update(
        SubNumberOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SubNumberOrderUpdateResponse> Update(
        string subNumberOrderID,
        SubNumberOrderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            SubNumberOrderID = subNumberOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubNumberOrderListResponse> List(
        SubNumberOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SubNumberOrderCancelResponse> Cancel(
        SubNumberOrderCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Cancel(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SubNumberOrderCancelResponse> Cancel(
        string subNumberOrderID,
        SubNumberOrderCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with{
            SubNumberOrderID = subNumberOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubNumberOrderUpdateRequirementGroupResponse> UpdateRequirementGroup(
        SubNumberOrderUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateRequirementGroup(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SubNumberOrderUpdateRequirementGroupResponse> UpdateRequirementGroup(
        string id,
        SubNumberOrderUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateRequirementGroup(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SubNumberOrderServiceWithRawResponse : ISubNumberOrderServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISubNumberOrderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SubNumberOrderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SubNumberOrderServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubNumberOrderRetrieveResponse>> Retrieve(
        SubNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubNumberOrderID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.SubNumberOrderID' cannot be null"
            );
        }

        HttpRequest<SubNumberOrderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var subNumberOrder = await response.Deserialize<SubNumberOrderRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                subNumberOrder.Validate();
            }
            return subNumberOrder;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SubNumberOrderRetrieveResponse>> Retrieve(
        string subNumberOrderID,
        SubNumberOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            SubNumberOrderID = subNumberOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubNumberOrderUpdateResponse>> Update(
        SubNumberOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubNumberOrderID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.SubNumberOrderID' cannot be null"
            );
        }

        HttpRequest<SubNumberOrderUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var subNumberOrder = await response.Deserialize<SubNumberOrderUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                subNumberOrder.Validate();
            }
            return subNumberOrder;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SubNumberOrderUpdateResponse>> Update(
        string subNumberOrderID,
        SubNumberOrderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            SubNumberOrderID = subNumberOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubNumberOrderListResponse>> List(
        SubNumberOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SubNumberOrderListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var subNumberOrders = await response.Deserialize<SubNumberOrderListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                subNumberOrders.Validate();
            }
            return subNumberOrders;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubNumberOrderCancelResponse>> Cancel(
        SubNumberOrderCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubNumberOrderID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.SubNumberOrderID' cannot be null"
            );
        }

        HttpRequest<SubNumberOrderCancelParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<SubNumberOrderCancelResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SubNumberOrderCancelResponse>> Cancel(
        string subNumberOrderID,
        SubNumberOrderCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with{
            SubNumberOrderID = subNumberOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubNumberOrderUpdateRequirementGroupResponse>> UpdateRequirementGroup(
        SubNumberOrderUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SubNumberOrderUpdateRequirementGroupParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<SubNumberOrderUpdateRequirementGroupResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SubNumberOrderUpdateRequirementGroupResponse>> UpdateRequirementGroup(
        string id,
        SubNumberOrderUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateRequirementGroup(parameters with{
            ID = id
        }, cancellationToken);
    }
}