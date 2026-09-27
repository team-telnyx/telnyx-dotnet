using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Missions.Tools;

namespace Telnyx.Sdk.Services.AI.Missions;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IToolService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IToolServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IToolService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Adds a new tool to the specified mission, defining an action agents can invoke
/// during runs of this mission.
/// </summary>
    Task<JsonElement> CreateTool(
        ToolCreateToolParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CreateTool(ToolCreateToolParams, CancellationToken)"/>
    Task<JsonElement> CreateTool(
        string missionID,
        ToolCreateToolParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes the specified tool from the mission so agents can no longer invoke it in
/// subsequent runs.
/// </summary>
    Task DeleteTool(
        ToolDeleteToolParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteTool(ToolDeleteToolParams, CancellationToken)"/>
    Task DeleteTool(
        string toolID,
        ToolDeleteToolParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the definition of a single tool configured on the specified mission.
/// </summary>
    Task<JsonElement> GetTool(
        ToolGetToolParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetTool(ToolGetToolParams, CancellationToken)"/>
    Task<JsonElement> GetTool(
        string toolID,
        ToolGetToolParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the tools configured on the specified mission. Tools define the actions
/// agents may invoke while executing the mission's runs.
/// </summary>
    Task<JsonElement> ListTools(
        ToolListToolsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListTools(ToolListToolsParams, CancellationToken)"/>
    Task<JsonElement> ListTools(
        string missionID,
        ToolListToolsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Replaces the definition of the specified tool on this mission.
/// </summary>
    Task<JsonElement> UpdateTool(
        ToolUpdateToolParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateTool(ToolUpdateToolParams, CancellationToken)"/>
    Task<JsonElement> UpdateTool(
        string toolID,
        ToolUpdateToolParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IToolService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IToolServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IToolServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/missions/{mission_id}/tools</c>, but is otherwise the
/// same as <see cref="IToolService.CreateTool(ToolCreateToolParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> CreateTool(
        ToolCreateToolParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CreateTool(ToolCreateToolParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> CreateTool(
        string missionID,
        ToolCreateToolParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/missions/{mission_id}/tools/{tool_id}</c>, but is otherwise the
/// same as <see cref="IToolService.DeleteTool(ToolDeleteToolParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> DeleteTool(
        ToolDeleteToolParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteTool(ToolDeleteToolParams, CancellationToken)"/>
    Task<HttpResponse> DeleteTool(
        string toolID,
        ToolDeleteToolParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions/{mission_id}/tools/{tool_id}</c>, but is otherwise the
/// same as <see cref="IToolService.GetTool(ToolGetToolParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> GetTool(
        ToolGetToolParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetTool(ToolGetToolParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> GetTool(
        string toolID,
        ToolGetToolParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions/{mission_id}/tools</c>, but is otherwise the
/// same as <see cref="IToolService.ListTools(ToolListToolsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> ListTools(
        ToolListToolsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListTools(ToolListToolsParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> ListTools(
        string missionID,
        ToolListToolsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /ai/missions/{mission_id}/tools/{tool_id}</c>, but is otherwise the
/// same as <see cref="IToolService.UpdateTool(ToolUpdateToolParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> UpdateTool(
        ToolUpdateToolParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateTool(ToolUpdateToolParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> UpdateTool(
        string toolID,
        ToolUpdateToolParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}