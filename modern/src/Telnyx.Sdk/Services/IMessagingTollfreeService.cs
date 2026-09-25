using System;
using Telnyx.Sdk.Core;
using MessagingTollfree = Telnyx.Sdk.Services.MessagingTollfree;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMessagingTollfreeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessagingTollfreeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingTollfreeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    MessagingTollfree::IVerificationService Verification { get; }
}

/// <summary>
/// A view of <see cref="IMessagingTollfreeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessagingTollfreeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingTollfreeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    MessagingTollfree::IVerificationServiceWithRawResponse Verification { get; }
}