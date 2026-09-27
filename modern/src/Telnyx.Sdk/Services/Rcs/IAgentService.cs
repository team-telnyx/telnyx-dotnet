using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Rcs.Agents;
using Telnyx.Sdk.Services.Rcs.Agents;

namespace Telnyx.Sdk.Services.Rcs;

/// <summary>
/// Manage RCS agent registration, testing, verification, and launch.
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

    ITestDeviceService TestDevices { get; }

    /// <summary>
/// Creates an editable RCS agent draft under a brand. The `Idempotency-Key` is
/// scoped to the authenticated organization. Reusing the key with the same request
/// returns the original agent, while reusing it with a different request returns a
/// conflict.
/// </summary>
    Task<AgentResponse> Create(
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves an RCS agent, section statuses, test devices, carrier approvals, and
/// provider capabilities.
/// </summary>
    Task<AgentResponse> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AgentRetrieveParams, CancellationToken)"/>
    Task<AgentResponse> Retrieve(
        string id,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates one or more fields on an agent while its status is `CREATED`. Submitted
/// agents cannot be changed through this endpoint.
/// </summary>
    Task<AgentResponse> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(AgentUpdateParams, CancellationToken)"/>
    Task<AgentResponse> Update(
        string id,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists RCS agents owned by the authenticated organization, optionally filtered by
/// brand.
/// </summary>
    Task<List<AgentResponse>> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Adds the campaign and testing configuration, then starts asynchronous carrier
/// launch. Agent basics must already be submitted. Repeating a launch that is
/// already in progress returns the current agent without creating new work.
/// </summary>
    Task<AgentResponse> Launch(
        AgentLaunchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Launch(AgentLaunchParams, CancellationToken)"/>
    Task<AgentResponse> Launch(
        string id,
        AgentLaunchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists carrier approval records for an RCS agent. The provider may expose
/// per-carrier, hub-level, or bot-level approval status.
/// </summary>
    Task<List<CarrierApprovalResponse>> RetrieveCarrierApprovals(
        AgentRetrieveCarrierApprovalsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveCarrierApprovals(AgentRetrieveCarrierApprovalsParams, CancellationToken)"/>
    Task<List<CarrierApprovalResponse>> RetrieveCarrierApprovals(
        string id,
        AgentRetrieveCarrierApprovalsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Starts asynchronous provider provisioning and submits the agent's basic
/// configuration. The brand must be `VERIFIED`. Repeating this request for an
/// in-progress agent returns its current state without creating new work.
/// </summary>
    Task<AgentResponse> Submit(
        AgentSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Submit(AgentSubmitParams, CancellationToken)"/>
    Task<AgentResponse> Submit(
        string id,
        AgentSubmitParams? parameters = null,
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

    ITestDeviceServiceWithRawResponse TestDevices { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /rcs/agents</c>, but is otherwise the
/// same as <see cref="IAgentService.Create(AgentCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AgentResponse>> Create(
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /rcs/agents/{id}</c>, but is otherwise the
/// same as <see cref="IAgentService.Retrieve(AgentRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AgentResponse>> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AgentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AgentResponse>> Retrieve(
        string id,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /rcs/agents/{id}</c>, but is otherwise the
/// same as <see cref="IAgentService.Update(AgentUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AgentResponse>> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(AgentUpdateParams, CancellationToken)"/>
    Task<HttpResponse<AgentResponse>> Update(
        string id,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /rcs/agents</c>, but is otherwise the
/// same as <see cref="IAgentService.List(AgentListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<List<AgentResponse>>> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /rcs/agents/{id}/launch</c>, but is otherwise the
/// same as <see cref="IAgentService.Launch(AgentLaunchParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AgentResponse>> Launch(
        AgentLaunchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Launch(AgentLaunchParams, CancellationToken)"/>
    Task<HttpResponse<AgentResponse>> Launch(
        string id,
        AgentLaunchParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /rcs/agents/{id}/carrier_approvals</c>, but is otherwise the
/// same as <see cref="IAgentService.RetrieveCarrierApprovals(AgentRetrieveCarrierApprovalsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<List<CarrierApprovalResponse>>> RetrieveCarrierApprovals(
        AgentRetrieveCarrierApprovalsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveCarrierApprovals(AgentRetrieveCarrierApprovalsParams, CancellationToken)"/>
    Task<HttpResponse<List<CarrierApprovalResponse>>> RetrieveCarrierApprovals(
        string id,
        AgentRetrieveCarrierApprovalsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /rcs/agents/{id}/submit</c>, but is otherwise the
/// same as <see cref="IAgentService.Submit(AgentSubmitParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AgentResponse>> Submit(
        AgentSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Submit(AgentSubmitParams, CancellationToken)"/>
    Task<HttpResponse<AgentResponse>> Submit(
        string id,
        AgentSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}