using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Actions.Purchase;

namespace Telnyx.Sdk.Services.Actions;

/// <inheritdoc/>
public sealed class PurchaseService : IPurchaseService
{
    readonly Lazy<IPurchaseServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPurchaseServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPurchaseService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new PurchaseService(this._client.WithOptions(modifier)); }

    public PurchaseService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PurchaseServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PurchaseCreateResponse> Create(
        PurchaseCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PurchaseServiceWithRawResponse : IPurchaseServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPurchaseServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PurchaseServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PurchaseServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PurchaseCreateResponse>> Create(
        PurchaseCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PurchaseCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var purchase = await response.Deserialize<PurchaseCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                purchase.Validate();
            }
            return purchase;
        });
    }
}