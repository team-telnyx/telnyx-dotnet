using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.X402;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IX402Service
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IX402ServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IX402Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    ICreditAccountService CreditAccount { get; }
}

/// <summary>
/// A view of <see cref="IX402Service"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IX402ServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IX402ServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ICreditAccountServiceWithRawResponse CreditAccount { get; }
}