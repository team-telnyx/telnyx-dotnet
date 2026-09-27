using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Missions.McpServers;

namespace Telnyx.Sdk.Services.AI.Missions;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMcpServerService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMcpServerServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMcpServerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Adds an MCP server to the specified mission, making the server's tools available
/// to agents during runs of this mission.
/// </summary>
    Task<JsonElement> CreateMcpServer(
        McpServerCreateMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CreateMcpServer(McpServerCreateMcpServerParams, CancellationToken)"/>
    Task<JsonElement> CreateMcpServer(
        string missionID,
        McpServerCreateMcpServerParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes the specified MCP server from the mission, revoking agent access to its
/// tools in subsequent runs.
/// </summary>
    Task DeleteMcpServer(
        McpServerDeleteMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteMcpServer(McpServerDeleteMcpServerParams, CancellationToken)"/>
    Task DeleteMcpServer(
        string mcpServerID,
        McpServerDeleteMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the configuration of a single MCP server attached to the specified
/// mission.
/// </summary>
    Task<JsonElement> GetMcpServer(
        McpServerGetMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetMcpServer(McpServerGetMcpServerParams, CancellationToken)"/>
    Task<JsonElement> GetMcpServer(
        string mcpServerID,
        McpServerGetMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the MCP servers configured on the specified mission. MCP servers expose
/// external tools and data sources agents can use during runs.
/// </summary>
    Task<JsonElement> ListMcpServers(
        McpServerListMcpServersParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListMcpServers(McpServerListMcpServersParams, CancellationToken)"/>
    Task<JsonElement> ListMcpServers(
        string missionID,
        McpServerListMcpServersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Replaces the configuration of the specified MCP server on this mission.
/// </summary>
    Task<JsonElement> UpdateMcpServer(
        McpServerUpdateMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateMcpServer(McpServerUpdateMcpServerParams, CancellationToken)"/>
    Task<JsonElement> UpdateMcpServer(
        string mcpServerID,
        McpServerUpdateMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMcpServerService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMcpServerServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMcpServerServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/missions/{mission_id}/mcp-servers</c>, but is otherwise the
/// same as <see cref="IMcpServerService.CreateMcpServer(McpServerCreateMcpServerParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> CreateMcpServer(
        McpServerCreateMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="CreateMcpServer(McpServerCreateMcpServerParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> CreateMcpServer(
        string missionID,
        McpServerCreateMcpServerParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/missions/{mission_id}/mcp-servers/{mcp_server_id}</c>, but is otherwise the
/// same as <see cref="IMcpServerService.DeleteMcpServer(McpServerDeleteMcpServerParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> DeleteMcpServer(
        McpServerDeleteMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="DeleteMcpServer(McpServerDeleteMcpServerParams, CancellationToken)"/>
    Task<HttpResponse> DeleteMcpServer(
        string mcpServerID,
        McpServerDeleteMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions/{mission_id}/mcp-servers/{mcp_server_id}</c>, but is otherwise the
/// same as <see cref="IMcpServerService.GetMcpServer(McpServerGetMcpServerParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> GetMcpServer(
        McpServerGetMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetMcpServer(McpServerGetMcpServerParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> GetMcpServer(
        string mcpServerID,
        McpServerGetMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/missions/{mission_id}/mcp-servers</c>, but is otherwise the
/// same as <see cref="IMcpServerService.ListMcpServers(McpServerListMcpServersParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> ListMcpServers(
        McpServerListMcpServersParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListMcpServers(McpServerListMcpServersParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> ListMcpServers(
        string missionID,
        McpServerListMcpServersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /ai/missions/{mission_id}/mcp-servers/{mcp_server_id}</c>, but is otherwise the
/// same as <see cref="IMcpServerService.UpdateMcpServer(McpServerUpdateMcpServerParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> UpdateMcpServer(
        McpServerUpdateMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateMcpServer(McpServerUpdateMcpServerParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> UpdateMcpServer(
        string mcpServerID,
        McpServerUpdateMcpServerParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}