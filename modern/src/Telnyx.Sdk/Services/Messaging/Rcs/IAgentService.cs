using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging.Rcs.Agents;
using Agents = Telnyx.Sdk.Models.Rcs.Agents;

namespace Telnyx.Sdk.Services.Messaging.Rcs;

/// <summary>
/// Send RCS messages
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAgentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAgentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the configuration and current state of the specified RCS agent.
/// </summary>
    Task<Agents::RcsAgentResponse> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AgentRetrieveParams, CancellationToken)"/>
    Task<Agents::RcsAgentResponse> Retrieve(
        string id,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the supplied configuration fields on the specified RCS agent.
/// </summary>
    Task<Agents::RcsAgentResponse> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(AgentUpdateParams, CancellationToken)"/>
    Task<Agents::RcsAgentResponse> Update(
        string id,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns RCS agents available to the authenticated account.
/// </summary>
    Task<AgentListPage> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAgentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAgentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging/rcs/agents/{id}</c>, but is otherwise the
/// same as <see cref="IAgentService.Retrieve(AgentRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Agents::RcsAgentResponse>> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AgentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Agents::RcsAgentResponse>> Retrieve(
        string id,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /messaging/rcs/agents/{id}</c>, but is otherwise the
/// same as <see cref="IAgentService.Update(AgentUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Agents::RcsAgentResponse>> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(AgentUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Agents::RcsAgentResponse>> Update(
        string id,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging/rcs/agents</c>, but is otherwise the
/// same as <see cref="IAgentService.List(AgentListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AgentListPage>> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}