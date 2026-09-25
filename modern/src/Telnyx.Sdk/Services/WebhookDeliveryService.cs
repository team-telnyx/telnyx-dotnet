using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.WebhookDeliveries;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class WebhookDeliveryService : IWebhookDeliveryService
{
    readonly Lazy<IWebhookDeliveryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWebhookDeliveryServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IWebhookDeliveryService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new WebhookDeliveryService(this._client.WithOptions(modifier)); }

    public WebhookDeliveryService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new WebhookDeliveryServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<WebhookDeliveryRetrieveResponse> Retrieve(
        WebhookDeliveryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<WebhookDeliveryRetrieveResponse> Retrieve(
        string id,
        WebhookDeliveryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WebhookDeliveryListPage> List(
        WebhookDeliveryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class WebhookDeliveryServiceWithRawResponse : IWebhookDeliveryServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWebhookDeliveryServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WebhookDeliveryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WebhookDeliveryServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookDeliveryRetrieveResponse>> Retrieve(
        WebhookDeliveryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<WebhookDeliveryRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var webhookDelivery = await response.Deserialize<WebhookDeliveryRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                webhookDelivery.Validate();
            }
            return webhookDelivery;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<WebhookDeliveryRetrieveResponse>> Retrieve(
        string id,
        WebhookDeliveryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookDeliveryListPage>> List(
        WebhookDeliveryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WebhookDeliveryListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<WebhookDeliveryListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new WebhookDeliveryListPage(this, parameters, page);
        });
    }
}