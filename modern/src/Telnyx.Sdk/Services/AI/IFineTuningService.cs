using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.AI.FineTuning;

namespace Telnyx.Sdk.Services.AI;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFineTuningService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFineTuningServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFineTuningService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IJobService Jobs { get; }
}

/// <summary>
/// A view of <see cref="IFineTuningService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFineTuningServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFineTuningServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IJobServiceWithRawResponse Jobs { get; }
}