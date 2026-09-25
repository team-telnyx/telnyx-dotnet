using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.Pricing;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPricingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPricingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPricingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IProductService Products { get; }
}

/// <summary>
/// A view of <see cref="IPricingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPricingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPricingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IProductServiceWithRawResponse Products { get; }
}