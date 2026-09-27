using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.AI.Memory;

namespace Telnyx.Sdk.Services.AI;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMemoryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMemoryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMemoryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    INamespaceService Namespaces { get; }
}

/// <summary>
/// A view of <see cref="IMemoryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMemoryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMemoryServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    INamespaceServiceWithRawResponse Namespaces { get; }
}