using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.Compute;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IComputeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IComputeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IComputeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IFuncService Funcs { get; }
}

/// <summary>
/// A view of <see cref="IComputeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IComputeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IComputeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IFuncServiceWithRawResponse Funcs { get; }
}