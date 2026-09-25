using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.MessagingTollfree.Verification;

namespace Telnyx.Sdk.Services.MessagingTollfree;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IVerificationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVerificationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerificationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IRequestService Requests { get; }
}

/// <summary>
/// A view of <see cref="IVerificationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVerificationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerificationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IRequestServiceWithRawResponse Requests { get; }
}