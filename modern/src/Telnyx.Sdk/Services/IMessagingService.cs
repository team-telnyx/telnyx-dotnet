using System;
using Telnyx.Sdk.Core;
using Messaging = Telnyx.Sdk.Services.Messaging;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMessagingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessagingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Messaging::IRcService Rcs { get; }
}

/// <summary>
/// A view of <see cref="IMessagingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessagingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Messaging::IRcServiceWithRawResponse Rcs { get; }
}