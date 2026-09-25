using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.Pricing;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class PricingService : IPricingService
{
    readonly Lazy<IPricingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPricingServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPricingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new PricingService(this._client.WithOptions(modifier)); }

    public PricingService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PricingServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _products =new(() => new ProductService(client)) ;
    }

    readonly Lazy<IProductService> _products;
    public IProductService Products { get { return _products.Value; } }
}

/// <inheritdoc/>
public sealed class PricingServiceWithRawResponse : IPricingServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPricingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PricingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PricingServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _products =new(() => new ProductServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IProductServiceWithRawResponse> _products;
    public IProductServiceWithRawResponse Products {
        get { return _products.Value; }
    }
}