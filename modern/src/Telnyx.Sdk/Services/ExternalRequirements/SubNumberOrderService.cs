using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.ExternalRequirements.SubNumberOrders;

namespace Telnyx.Sdk.Services.ExternalRequirements;

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
        SubNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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
        SubNumberOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            SubNumberOrderID = subNumberOrderID
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
        SubNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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
            Method = HttpMethod.Post,
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
        SubNumberOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            SubNumberOrderID = subNumberOrderID
        }, cancellationToken);
    }
}