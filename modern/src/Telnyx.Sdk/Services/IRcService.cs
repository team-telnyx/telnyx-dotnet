using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.Rcs;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRcService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRcServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRcService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IAgentService Agents { get; }

    IBrandService Brands { get; }
}

/// <summary>
/// A view of <see cref="IRcService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRcServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRcServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IAgentServiceWithRawResponse Agents { get; }

    IBrandServiceWithRawResponse Brands { get; }
}