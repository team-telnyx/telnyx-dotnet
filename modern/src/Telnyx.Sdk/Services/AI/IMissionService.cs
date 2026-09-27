using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Missions;
using Missions = Telnyx.Sdk.Services.AI.Missions;

namespace Telnyx.Sdk.Services.AI;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMissionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMissionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMissionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Missions::IRunService Runs { get; }

    Missions::IKnowledgeBaseService KnowledgeBases { get; }

    Missions::IMcpServerService McpServers { get; }

    Missions::IToolService Tools { get; }

    /// <summary>
/// Creates a new mission definition from the provided configuration and returns the
/// created mission. Execute the mission by starting runs against it.
/// </summary>
    Task<MissionResponse> Create(
        MissionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get a mission by ID (includes tools, knowledge_bases, mcp_servers)
/// </summary>
    Task<MissionResponse> Retrieve(
        MissionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MissionRetrieveParams, CancellationToken)"/>
    Task<MissionResponse> Retrieve(
        string missionID,
        MissionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of all mission definitions in your organization.
/// Missions describe a goal and the tools, knowledge bases, and MCP servers agents
/// may use to accomplish it.
/// </summary>
    Task<MissionListPage> List(
        MissionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Creates a copy of the specified mission as a new mission definition, so you can
/// iterate on its configuration without modifying the original.
/// </summary>
    Task<JsonElement> CloneMission(
        MissionCloneMissionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CloneMission(MissionCloneMissionParams, CancellationToken)"/>
    Task<JsonElement> CloneMission(
        string missionID,
        MissionCloneMissionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified mission definition and returns no content on
/// success.
/// </summary>
    Task DeleteMission(
        MissionDeleteMissionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteMission(MissionDeleteMissionParams, CancellationToken)"/>
    Task DeleteMission(
        string missionID,
        MissionDeleteMissionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of recent events across every mission in your
/// organization, optionally filtered by event type. Useful for building activity
/// feeds or monitoring dashboards.
/// </summary>
    Task<MissionListEventsPage> ListEvents(
        MissionListEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Replaces the specified mission's definition with the provided configuration and
/// returns the updated mission.
/// </summary>
    Task<MissionResponse> UpdateMission(
        MissionUpdateMissionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateMission(MissionUpdateMissionParams, CancellationToken)"/>
    Task<MissionResponse> UpdateMission(
        string missionID,
        MissionUpdateMissionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMissionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMissionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMissionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Missions::IRunServiceWithRawResponse Runs { get; }

    Missions::IKnowledgeBaseServiceWithRawResponse KnowledgeBases { get; }

    Missions::IMcpServerServiceWithRawResponse McpServers { get; }

    Missions::IToolServiceWithRawResponse Tools { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/missions</c>, but is otherwise the
/// same as <see cref="IMissionService.Create(MissionCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MissionResponse>> Create(
        MissionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions/{mission_id}</c>, but is otherwise the
/// same as <see cref="IMissionService.Retrieve(MissionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MissionResponse>> Retrieve(
        MissionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MissionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MissionResponse>> Retrieve(
        string missionID,
        MissionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions</c>, but is otherwise the
/// same as <see cref="IMissionService.List(MissionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MissionListPage>> List(
        MissionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/missions/{mission_id}/clone</c>, but is otherwise the
/// same as <see cref="IMissionService.CloneMission(MissionCloneMissionParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> CloneMission(
        MissionCloneMissionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CloneMission(MissionCloneMissionParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> CloneMission(
        string missionID,
        MissionCloneMissionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/missions/{mission_id}</c>, but is otherwise the
/// same as <see cref="IMissionService.DeleteMission(MissionDeleteMissionParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> DeleteMission(
        MissionDeleteMissionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteMission(MissionDeleteMissionParams, CancellationToken)"/>
    Task<HttpResponse> DeleteMission(
        string missionID,
        MissionDeleteMissionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions/events</c>, but is otherwise the
/// same as <see cref="IMissionService.ListEvents(MissionListEventsParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MissionListEventsPage>> ListEvents(
        MissionListEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /ai/missions/{mission_id}</c>, but is otherwise the
/// same as <see cref="IMissionService.UpdateMission(MissionUpdateMissionParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MissionResponse>> UpdateMission(
        MissionUpdateMissionParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateMission(MissionUpdateMissionParams, CancellationToken)"/>
    Task<HttpResponse<MissionResponse>> UpdateMission(
        string missionID,
        MissionUpdateMissionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}