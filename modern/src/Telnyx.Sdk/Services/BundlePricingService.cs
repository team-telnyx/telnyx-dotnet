using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.BundlePricing;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class BundlePricingService : IBundlePricingService
{
    readonly Lazy<IBundlePricingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBundlePricingServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IBundlePricingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new BundlePricingService(this._client.WithOptions(modifier)); }

    public BundlePricingService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new BundlePricingServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _billingBundles =new(() => new BillingBundleService(client)) ;
        _userBundles =new(() => new UserBundleService(client)) ;
    }

    readonly Lazy<IBillingBundleService> _billingBundles;
    public IBillingBundleService BillingBundles {
        get { return _billingBundles.Value; }
    }

    readonly Lazy<IUserBundleService> _userBundles;
    public IUserBundleService UserBundles { get { return _userBundles.Value; } }
}

/// <inheritdoc/>
public sealed class BundlePricingServiceWithRawResponse : IBundlePricingServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBundlePricingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BundlePricingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BundlePricingServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _billingBundles =new(
            () => new BillingBundleServiceWithRawResponse(client)
        ) ;
        _userBundles =new(() => new UserBundleServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IBillingBundleServiceWithRawResponse> _billingBundles;
    public IBillingBundleServiceWithRawResponse BillingBundles {
        get { return _billingBundles.Value; }
    }

    readonly Lazy<IUserBundleServiceWithRawResponse> _userBundles;
    public IUserBundleServiceWithRawResponse UserBundles {
        get { return _userBundles.Value; }
    }
}