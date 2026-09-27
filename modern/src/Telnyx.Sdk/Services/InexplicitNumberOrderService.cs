using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.InexplicitNumberOrders;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class InexplicitNumberOrderService : IInexplicitNumberOrderService
{
    readonly Lazy<IInexplicitNumberOrderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInexplicitNumberOrderServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IInexplicitNumberOrderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InexplicitNumberOrderService(this._client.WithOptions(modifier));
    }

    public InexplicitNumberOrderService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new InexplicitNumberOrderServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<InexplicitNumberOrderCreateResponse> Create(
        InexplicitNumberOrderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InexplicitNumberOrderRetrieveResponse> Retrieve(
        InexplicitNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<InexplicitNumberOrderRetrieveResponse> Retrieve(
        string id,
        InexplicitNumberOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InexplicitNumberOrderListPage> List(
        InexplicitNumberOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class InexplicitNumberOrderServiceWithRawResponse : IInexplicitNumberOrderServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInexplicitNumberOrderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InexplicitNumberOrderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InexplicitNumberOrderServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<InexplicitNumberOrderCreateResponse>> Create(
        InexplicitNumberOrderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InexplicitNumberOrderCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var inexplicitNumberOrder = await response.Deserialize<InexplicitNumberOrderCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                inexplicitNumberOrder.Validate();
            }
            return inexplicitNumberOrder;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InexplicitNumberOrderRetrieveResponse>> Retrieve(
        InexplicitNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<InexplicitNumberOrderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var inexplicitNumberOrder = await response.Deserialize<InexplicitNumberOrderRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                inexplicitNumberOrder.Validate();
            }
            return inexplicitNumberOrder;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<InexplicitNumberOrderRetrieveResponse>> Retrieve(
        string id,
        InexplicitNumberOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InexplicitNumberOrderListPage>> List(
        InexplicitNumberOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InexplicitNumberOrderListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<InexplicitNumberOrderListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new InexplicitNumberOrderListPage(this, parameters, page);
        });
    }
}