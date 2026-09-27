using System;
using Telnyx.Sdk.Core;
using Knowledge = Telnyx.Sdk.Services.AI.Knowledge;

namespace Telnyx.Sdk.Services.AI;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IKnowledgeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IKnowledgeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IKnowledgeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Knowledge::ICollectionService Collections { get; }
}

/// <summary>
/// A view of <see cref="IKnowledgeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IKnowledgeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IKnowledgeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Knowledge::ICollectionServiceWithRawResponse Collections { get; }
}