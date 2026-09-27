using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.AI.Typesafe;

namespace Telnyx.Sdk.Services.AI;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITypesafeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITypesafeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITypesafeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IV1Service V1 { get; }
}

/// <summary>
/// A view of <see cref="ITypesafeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITypesafeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITypesafeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IV1ServiceWithRawResponse V1 { get; }
}