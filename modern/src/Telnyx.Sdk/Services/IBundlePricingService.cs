using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.BundlePricing;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBundlePricingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBundlePricingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBundlePricingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IBillingBundleService BillingBundles { get; }

    IUserBundleService UserBundles { get; }
}

/// <summary>
/// A view of <see cref="IBundlePricingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBundlePricingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBundlePricingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IBillingBundleServiceWithRawResponse BillingBundles { get; }

    IUserBundleServiceWithRawResponse UserBundles { get; }
}